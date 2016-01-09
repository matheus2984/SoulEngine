using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Soul.Engine.UI;
using Soul.Engine.UI.Components;
using Soul.Engine.Window;
using IGameComponent = Soul.Engine.Common.IGameComponent;

namespace Soul.Client
{
    public class HUD : IGameComponent
    {
        public Button btn1;
        public TextBox txt1;

        public Container Container;

        public HUD(SoulGame game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            Container = new Container(game, content, graphicsDevice);
            btn1 = new Button();
            btn1.X = 100;
            btn1.Y = 100;
            btn1.Text = "oi";
            btn1.Width = 100;
            btn1.Height = 50;
            btn1.Font = content.Load<SpriteFont>("World");
            btn1.Click += btn1_Click;
            Container.Add(btn1);

            txt1 = new TextBox();
            txt1.X = 300;
            txt1.Y = 300;
            txt1.Width = 200;
            txt1.Height = 30;
            txt1.Font = content.Load<SpriteFont>("World");
            Container.Add(txt1);
            txt1.EnterPressed += txt1_EnterPressed;
        }

        void txt1_EnterPressed(object sender, TextEventArgs e)
        {
            ((TextBox) sender).Text = String.Empty;
            Console.WriteLine(e.Text);
        }

        private void btn1_Click(object sender, MouseEventArgs e)
        {
            Console.WriteLine("oi");
        }

        public void Update(GameTime gameTime)
        {
            Container.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Container.Draw(spriteBatch, gameTime);
        }
    }
}