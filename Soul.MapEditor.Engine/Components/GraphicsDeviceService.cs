using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.MapEditor.Core.Components
{
    public class GraphicsDeviceService : IGraphicsDeviceService
    {
        private static GraphicsDeviceService instance;
        private static int referenceCount;
        private readonly PresentationParameters parameters;

        private GraphicsDeviceService(IntPtr windowHandle, int width, int height)
        {
            parameters = new PresentationParameters();

            parameters.BackBufferWidth = Math.Max(width, 1);
            parameters.BackBufferHeight = Math.Max(height, 1);
            parameters.BackBufferFormat = SurfaceFormat.Color;
            parameters.DepthStencilFormat = DepthFormat.Depth24;
            parameters.DeviceWindowHandle = windowHandle;
            parameters.PresentationInterval = PresentInterval.Immediate;
            parameters.IsFullScreen = false;

            GraphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, parameters);
        }

        public void Release(bool disposing)
        {
            if (Interlocked.Decrement(ref referenceCount) == 0)
            {
                if (disposing)
                {
                    if (DeviceDisposing != null)
                    {
                        DeviceDisposing(this, EventArgs.Empty);
                    }
                    GraphicsDevice.Dispose();
                }
                GraphicsDevice = null;
            }
        }

        public void ResetDevice(int width, int height)
        {
            if (DeviceResetting != null)
            {
                DeviceResetting(this, EventArgs.Empty);
            }

            parameters.BackBufferWidth = Math.Max(parameters.BackBufferWidth, width);
            parameters.BackBufferHeight = Math.Max(parameters.BackBufferHeight, height);
            GraphicsDevice.Reset(parameters);

            if (DeviceReset != null)
            {
                DeviceReset(this, EventArgs.Empty);
            }
        }

        public static GraphicsDeviceService AddReference(IntPtr windowHandle, int width, int height)
        {
            if (Interlocked.Increment(ref referenceCount) == 1)
            {
                instance = new GraphicsDeviceService(windowHandle, width, height);
            }
            return instance;
        }

        public GraphicsDevice GraphicsDevice { get; private set; }
        public event EventHandler<EventArgs> DeviceCreated;
        public event EventHandler<EventArgs> DeviceDisposing;
        public event EventHandler<EventArgs> DeviceReset;
        public event EventHandler<EventArgs> DeviceResetting;
    }
}