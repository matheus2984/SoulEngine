using Microsoft.Xna.Framework;
using Soul.Engine.Input;

namespace Soul.Engine.Window
{
    public class SoulGame : Game
    {
        public readonly VirtualMouse Mouse;

        protected SoulGame()
        {
            Mouse = new VirtualMouse(this);
        }
    }
}