using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.MapEditor.Core.TileEngine;

namespace Soul.MapEditor.Forms
{
    public partial class FrmNewTileset : Form
    {
        private static readonly int currentID = 0;
        public Tileset Tileset { get; private set; }

        public FrmNewTileset()
        {
            InitializeComponent();
            editorView.Drawing += editorView_Drawing;
            editorView.Updating += editorView_Updating;
        }

        private void editorView_Updating(object sender, GameTime gameTime)
        {
        }

        private void editorView_Drawing(object sender, SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Tileset == null) return;

            spriteBatch.Begin();
            spriteBatch.Draw(Tileset.TileableTexture.Texture, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnSearchPath_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtTilesetPath.Text = ofd.FileName;
                using (var stream = new FileStream(ofd.FileName, FileMode.Open))
                {
                    Tileset = new Tileset(currentID, Texture2D.FromStream(editorView.GraphicsDevice, stream));
                    Tileset.Name = txtName.Text;
                }
            }
        }
    }
}