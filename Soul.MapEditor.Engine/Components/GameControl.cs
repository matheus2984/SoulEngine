using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = System.Drawing.Color;
using IGameComponent = Soul.MapEditor.Core.Common.IGameComponent;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Soul.MapEditor.Core.Components
{
    public class GameControl : Control
    {
        private readonly DateTime startTime;
        private string errorMessage;
        private Thread eventThread;
        private Thread gameLoopThread;
        private DateTime lastDraw;
        private DateTime lastUpdate;
        private GraphicsDeviceService service;
        public IGameComponent Component { get; set; }
        public bool GameLoopEnabled { get; set; }
        public float TimeStep { get; set; }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                if (!DesignMode)
                {
                    return service.GraphicsDevice;
                }
                return null;
            }
        }

        public ContentManager Content { get; private set; }
        public ServiceContainer Services { get; private set; }

        public GameControl()
        {
            Services = new ServiceContainer();

            Content = new ContentManager(Services);
            Content.RootDirectory = ".";

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            SetStyle(ControlStyles.UserPaint, true);

            GameLoopEnabled = true;
            TimeStep = 16.66666f;

            startTime = DateTime.Now;
        }

        public virtual void Initialize()
        {
        }

        public virtual void LoadContent()
        {
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (Component != null)
            {
                Component.Draw(gameTime);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Component != null)
            {
                Component.Update(gameTime);
            }
        }

        public void BeginDraw()
        {
            if (service == null)
            {
                errorMessage = Messages.LostDevice;
            }
            handleDeviceReset();

            if (string.IsNullOrEmpty(errorMessage))
            {
                setupViewport();
            }
        }

        public void EndDraw()
        {
            try
            {
                GraphicsDevice.Present(
                    new Rectangle(0, 0, ClientSize.Width, ClientSize.Height),
                    null, Handle);
            }
            catch (DeviceLostException)
            {
                handleDeviceReset();
            }
        }

        public void Reset()
        {
            try
            {
                service.ResetDevice(ClientSize.Width, ClientSize.Height);
            }
            catch
            {
                errorMessage = Messages.ResetFailed;
            }
        }

        private void setupViewport()
        {
            if (ClientSize.Width > 0 && ClientSize.Height > 0)
            {
                GraphicsDevice.Viewport = new Viewport
                {
                    X = 0,
                    Y = 0,
                    Width = ClientSize.Width,
                    Height = ClientSize.Height,
                    MinDepth = 0,
                    MaxDepth = 1
                };
            }
        }

        private void handleDeviceReset()
        {
            var needsReset = false;
            switch (GraphicsDevice.GraphicsDeviceStatus)
            {
                case GraphicsDeviceStatus.Lost:
                    errorMessage = Messages.LostDevice;
                    break;

                case GraphicsDeviceStatus.NotReset:
                    needsReset = true;
                    break;

                default:
                    PresentationParameters pp = GraphicsDevice.PresentationParameters;
                    needsReset = (ClientSize.Width > pp.BackBufferWidth) || (ClientSize.Height > pp.BackBufferHeight);
                    break;
            }
            if (needsReset)
            {
                Reset();
            }
        }

        private void paintDefault(Graphics graphics, string text)
        {
            graphics.Clear(Color.DodgerBlue);

            using (Brush brush = new SolidBrush(Color.Black))
            {
                using (var format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    graphics.DrawString(text, Font, brush, ClientRectangle, format);
                }
            }
        }

        private void gameLoop()
        {
            Action loadContent = LoadContent;
            Action unloadContent = UnloadContent;

            lastUpdate = DateTime.Now;
            lastDraw = DateTime.Now;

            Invoke(loadContent);
            while (!IsDisposed)
            {
                try
                {
                    DateTime drawStart = DateTime.Now;

                    Action performDraw = () =>
                    {
                        BeginDraw();
                        Draw(new GameTime(drawStart - startTime, drawStart - lastDraw));
                        EndDraw();
                    };
                    Invoke(performDraw);
                    lastDraw = drawStart;

                    DateTime updateStart = DateTime.Now;

                    Action performUpdate =
                        () => { Update(new GameTime(updateStart - startTime, updateStart - lastUpdate)); };
                    Invoke(performUpdate);
                    lastUpdate = updateStart;

                    TimeSpan elapsed = DateTime.Now - drawStart;
                    if (elapsed.TotalMilliseconds >= TimeStep) continue;

                    Thread.Sleep(TimeSpan.FromMilliseconds(TimeStep) - elapsed);
                }
                catch
                {
                }
            }
            Invoke(unloadContent);
        }

        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                service = GraphicsDeviceService.AddReference(
                    Handle,
                    ClientSize.Width,
                    ClientSize.Height);

                service.DeviceReset += onDeviceReset;
                Services.AddService<IGraphicsDeviceService>(service);

                if (GameLoopEnabled)
                {
                    gameLoopThread = new Thread(gameLoop);
                    gameLoopThread.IsBackground = true;
                    gameLoopThread.Priority = ThreadPriority.Normal;

                    gameLoopThread.Start();
                }
                else
                {
                    LoadContent();
                }
            }
            base.OnCreateControl();
        }

        protected override void Dispose(bool disposing)
        {
            if (service != null)
            {
                service.Release(disposing);
                service = null;

                if (gameLoopThread != null && gameLoopThread.IsAlive)
                {
                    gameLoopThread.Abort();
                }
            }
            base.Dispose(disposing);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (DesignMode)
            {
                e.Graphics.Clear(Color.CornflowerBlue);
            }
            else
            {
                if (!GameLoopEnabled && GraphicsDevice != null)
                {
                    var gameTime = new GameTime(TimeSpan.Zero, TimeSpan.Zero);

                    BeginDraw();
                    {
                        Draw(gameTime);
                    }
                    EndDraw();
                }
            }
        }

        private void onDeviceReset(object sender, EventArgs e)
        {
            Initialize();
            errorMessage = string.Empty;
        }

        public static class Messages
        {
            public static string DesignMode = "DESIGN MODE";
            public static string LostDevice = "LOST DEVICE";
            public static string ResetFailed = "RESET FAILED";
        }
    }
}