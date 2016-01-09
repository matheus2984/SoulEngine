using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.Engine.Common
{
    public interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}