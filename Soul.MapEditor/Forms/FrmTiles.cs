using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.Engine.Common;
using Soul.MapEditor.Core.TileEngine;
using WeifenLuo.WinFormsUI.Docking;

namespace Soul.MapEditor.Forms
{
    public partial class FrmTiles : DockContent
    {
        private readonly List<Tileset> tilesets;
        private Dictionary<Tileset, Grid> Grids { get; set; }

        public FrmTiles Instance
        {
            get { return Static<FrmTiles>.Value; }
        }

        public FrmTiles()
        {
            InitializeComponent();
            editorView.Drawing += editorView_Drawing;
            editorView.Updating += editorView_Updating;
            tilesets = new List<Tileset>();
            Grids = new Dictionary<Tileset, Grid>();
            cbTileset.DisplayMember = "Name";
        }

        private void editorView_Updating(object sender, GameTime gameTime)
        {
            var tileset = (Tileset) cbTileset.SelectedItem;
            if (tileset == null) return;
            Grid grid = Grids[tileset];
            //   grid.Handle = editorView.Handle;
            grid.Update(editorView, gameTime);
        }

        private void editorView_Drawing(object sender, SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (cbTileset.SelectedItem == null) return;
            spriteBatch.Begin();
            var tileset = (Tileset) cbTileset.SelectedItem;
            Grid grid = Grids[tileset];
            spriteBatch.Draw(tileset.TileableTexture.Texture, Vector2.Zero, Color.White);
            grid.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }

        public void AddTileset(Tileset tileset)
        {
            tilesets.Add(tileset);
            var grid = new Grid(editorView.GraphicsDevice, tileset.TileableTexture.Rows,
                tileset.TileableTexture.Cols);
            Grids.Add(tileset, grid);
            cbTileset.Items.Add(tileset);
        }

        private void cbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}