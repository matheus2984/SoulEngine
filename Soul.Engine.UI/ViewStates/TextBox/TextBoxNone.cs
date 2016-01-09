using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.Engine.UI.ViewStates.TextBox
{
    public class TextBoxNone : IViewState
    {
        private readonly Components.TextBox textBox;
        private Texture2D texture;

        public TextBoxNone(Components.TextBox textBox)
        {
            this.textBox = textBox;
        }

        public void LoadContent(ContentManager content)
        {
            GraphicsDevice graphics = textBox.GraphicsDevice;
            texture = new RenderTarget2D(graphics, 1, 1);
            Color[] data =
            {
                new Color(255, 255, 255, 255)
            };
            texture.SetData(data);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, textBox.Rectangle, Color.White);
        }
    }
}
