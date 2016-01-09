using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Soul.Engine.Graphics;
using Soul.Engine.UI.ViewStates;
using Soul.Engine.UI.ViewStates.Button;

namespace Soul.Engine.UI.Components
{
    public class Button : Control
    {
        public SpriteFont Font { get; set; }
        public string Text { get; set; }

        public Button()
        {
            CurrentState = StateType.Released;
        }

        public Button(SpriteFont font, string text) : this()
        {
            Font = font;
            Text = text;
        }

        public Button(int x, int y, int width, int height) : this()
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Button(int x, int y, int width, int height, SpriteFont font, string text) : this(x, y, width, height)
        {
            Font = font;
            Text = text;
        }

        protected override void OnPressed()
        {
            CurrentState = StateType.Pressed;
        }

        protected override void OnReleased()
        {
            CurrentState = StateType.Released;
        }

        protected override void OnClick()
        {
        }

        protected override void LoadContent(ContentManager content)
        {
            IViewState state = new ButtonReleased(this);
            ViewStates.Add(StateType.Released, state);

            state = new ButtonClicked(this);
            ViewStates.Add(StateType.Pressed, state);

            for (var i = 0; i < ViewStates.Count; i++)
                ViewStates.ElementAt(i).Value.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            ViewStates[CurrentState].Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            ViewStates[CurrentState].Draw(spriteBatch, gameTime);
            if (Font != null && !string.IsNullOrEmpty(Text))
                spriteBatch.DrawString(Font,Text, Rectangle, FontAlignment.Alignment.Center, Color.Black);
        }
    }
}