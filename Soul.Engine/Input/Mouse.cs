using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Soul.Engine.Window;

namespace Soul.Engine.Input
{
    public class VirtualMouse
    {
        private readonly SoulGame game;

        public bool IsVisible
        {
            get { return game.IsMouseVisible; }
            set { game.IsMouseVisible = value; }
        }

        public VirtualMouse(SoulGame game)
        {
            this.game = game;
        }

        public MouseState GetState()
        {
            if (NativeMethods.GetForegroundWindow() == game.Window.Handle)
                return Mouse.GetState(game.Window);

            return new MouseState(-1, -1, 0, ButtonState.Released, ButtonState.Released,
                ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        public void MouseSetPosition(int x, int y)
        {
            Mouse.SetPosition(x, y);
        }

        public Rectangle GetRetangle()
        {
            MouseState state = GetState();
            return new Rectangle(state.X, state.Y, 1, 1);
        }
    }
}