using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.MapEditor.Core.Components
{
    public delegate void ContentLoadEvent(object sender, ContentManager content);

    public delegate void UpdateEvent(object sender, GameTime gameTime);

    public delegate void DrawEvent(object sender, SpriteBatch spriteBatch, GameTime gameTime);
}