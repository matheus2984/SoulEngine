using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.MapEditor.Core.Components
{
    public class EditorViewControl : GameControl
    {
        private double elapsed;
        private SpriteBatch spriteBatch;
        public event ContentLoadEvent LoadingContent;
        public event UpdateEvent Updating;
        public event DrawEvent Drawing;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            if (LoadingContent != null) LoadingContent(this, Content);
        }

        public override void Update(GameTime gameTime)
        {
            elapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsed >= 1)
            {
                elapsed = 0;
            }

            UpdateEvent onUpdating = Updating;
            if (onUpdating != null) onUpdating(this, gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawEvent onDrawing = Drawing;
            if (onDrawing != null) onDrawing(this, spriteBatch, gameTime);
            base.Draw(gameTime);
        }
    }
}