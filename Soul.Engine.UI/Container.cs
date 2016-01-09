using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Soul.Engine.Window;
using IGameComponent = Soul.Engine.Common.IGameComponent;

namespace Soul.Engine.UI
{
    public class Container : List<Control>, IGameComponent
    {
        private ContentManager Content { get; set; }
        private GraphicsDevice GraphicsDevice { get; set; }
        public SoulGame GameParent { get; private set; }

        public Container(SoulGame game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            GameParent = game;
            Content = content;
            GraphicsDevice = graphicsDevice;
        }

        public new void Add(Control component)
        {
            base.Add(component);
            component.MsgLoadContent(Content, GraphicsDevice);
            component.NextLoad(GameParent);
        }

        public void Update(GameTime gameTime)
        {
            for (var i = 0; i < Count; i++)
                this[i].UpdateControl(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (var i = 0; i < Count; i++)
                this[i].Draw(spriteBatch, gameTime);
        }
    }
}