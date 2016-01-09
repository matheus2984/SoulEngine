using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.Engine.UI.ViewStates.Button
{
    public class ButtonClicked : IViewState
    {
        private readonly Components.Button button;
        private Texture2D texture;

        public ButtonClicked(Components.Button button)
        {
            this.button = button;
        }

        public void LoadContent(ContentManager content)
        {
            GraphicsDevice graphics = button.GraphicsDevice;
            texture = new RenderTarget2D(graphics, 1, 1);
            Color[] data = {new Color(90, 50, 225, 255)};
            texture.SetData(data);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, button.Rectangle, Color.White);
        }
    }
}