using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Soul.MapEditor.Core.TileEngine;
using WeifenLuo.WinFormsUI.Docking;

namespace Soul.MapEditor.Forms
{
    public partial class FrmMap : DockContent
    {
        private Map _map;
        private Texture2D selectedTexture;
        private Rectangle test;

        public Map Map
        {
            get { return _map; }
            set
            {
                _map = value;
                Grid = new Grid(editorView.GraphicsDevice, value.Rows, value.Cols);
            }
        }

        public Grid Grid { get; set; }

        public FrmMap()
        {
            InitializeComponent();

            editorView.LoadingContent += editorView_LoadingContent;
            test = new Rectangle(0, 0, 32, 32);
        }

        private void editorView_LoadingContent(object sender, ContentManager content)
        {
            selectedTexture = new RenderTarget2D(editorView.GraphicsDevice, 1, 1);
            selectedTexture.SetData(new[] {Color.Black});

            editorView.Drawing += editorView_Drawing;
            editorView.Updating += editorView_Updating;
        }

        private void editorView_Updating(object sender, GameTime gameTime)
        {
            /*switch (Data.CurrentTool)
            {
            }*/
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                test.X += 5;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                test.X -= 5;
            }
            if (Grid != null)
            {
                Grid.Update(editorView, gameTime);
            }
        }

        private void editorView_Drawing(object sender, SpriteBatch spriteBatch, GameTime gameTime)
        {
            try
            {
                //    editorView.GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                spriteBatch.Draw(selectedTexture, test, Color.Black);
                if (Map != null)
                {
                    Map.Draw(spriteBatch, gameTime);
                    Grid.Draw(spriteBatch, gameTime);
                }

                spriteBatch.End();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}