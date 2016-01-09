using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Soul.Engine.Extentions;
using Soul.Engine.Input;
using Soul.Engine.UI.ViewStates;
using Soul.Engine.Window;

namespace Soul.Engine.UI
{
    public abstract class Control : IComponent
    {
        public ContentManager Content;
        private MouseState currentMouseState;
        public GraphicsDevice GraphicsDevice;
        private MouseState lastMouseState;
        public Rectangle Rectangle;
        protected Dictionary<Enum, IViewState> ViewStates;
        protected StateType CurrentState { get; set; }
        protected SoulGame GameParent { get; set; }

        public bool IsFocused { get; set; }

        protected VirtualMouse Mouse
        {
            get { return GameParent.Mouse; }
        }

        public int Width
        {
            get { return Rectangle.Width; }
            set { Rectangle.Width = value; }
        }

        public int Height
        {
            get { return Rectangle.Height; }
            set { Rectangle.Height = value; }
        }

        public int X
        {
            get { return Rectangle.X; }
            set { Rectangle.X = value; }
        }

        public int Y
        {
            get { return Rectangle.Y; }
            set { Rectangle.Y = value; }
        }

        public Control()
        {
            Rectangle = new Rectangle();
            ViewStates = new Dictionary<Enum, IViewState>();
        }

        public event EventHandler<MouseEventArgs> Click;
        public event EventHandler<LoadEventArgs> Load;

        internal void MsgLoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            Content = content;
            LoadContent(content);
        }

        protected virtual void LoadContent(ContentManager content)
        {
        }

        internal void NextLoad(SoulGame game)
        {
            GameParent = game;

            OnLoad();
            Load.SafeInvoke(this, LoadEventArgs.Empty);
        }

        protected virtual void OnLoad()
        {
        }

        private void CheckState()
        {
            if (currentMouseState.LeftButton == ButtonState.Pressed)
                OnPressed();
            else
                OnReleased();
        }

        private void CheckClick()
        {
            if (currentMouseState.LeftButton != ButtonState.Released || lastMouseState.LeftButton != ButtonState.Pressed)
                return;

            OnClick();
            Click.SafeInvoke(this, MouseEventArgs.Empty);
        }

        protected virtual void OnPressed()
        {
        }

        protected virtual void OnReleased()
        {
        }

        protected virtual void OnClick()
        {
            IsFocused = true;
        }

        private void InputProcess()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        private void MouseChecks()
        {
            if (Mouse.GetRetangle().Intersects(Rectangle))
            {
                CheckState();
                CheckClick();
            }
            else
            {
                if (currentMouseState.LeftButton == ButtonState.Released &&
                    lastMouseState.LeftButton == ButtonState.Pressed)
                {
                    IsFocused = false;
                }

                OnReleased();
            }
        }

        internal void UpdateControl(GameTime gameTime)
        {
            InputProcess();
            MouseChecks();

            Update(gameTime);
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}