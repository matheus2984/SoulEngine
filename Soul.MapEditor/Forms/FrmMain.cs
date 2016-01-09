using System;
using System.Windows.Forms;
using Soul.MapEditor.Core.TileEngine;
using WeifenLuo.WinFormsUI.Docking;

namespace Soul.MapEditor.Forms
{
    public partial class FrmMain : Form
    {
        private FrmMap frmMap;
        private FrmMinimap frmMinimap;
        private FrmTiles frmTiles;

        private Tool CurrentTool
        {
            get { return Data.CurrentTool; }
            set { Data.CurrentTool = value; }
        }

        public FrmMain()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetTheme();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CreateStandardControls();
        }

        private void SetTheme()
        {
            dockPanel.Theme = vS2012LightTheme1;
            vS2012LightTheme1.Apply(dockPanel);
        }

        private void CreateStandardControls()
        {
            frmMap = new FrmMap();
            frmTiles = new FrmTiles();
            frmMinimap = new FrmMinimap();

            frmTiles.Show(dockPanel, DockState.DockRight);
            frmMap.Show(dockPanel, DockState.Document);
            frmMinimap.Show(dockPanel, DockState.DockLeft);
            frmTiles.CloseButton = false;
            frmMap.CloseButton = false;
            frmMinimap.CloseButton = false;

            frmTiles.CloseButtonVisible = false;
            frmMinimap.CloseButtonVisible = false;
            frmMinimap.CloseButtonVisible = false;
        }

        private void NewMap_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNewFile())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Data.Map = frm.Map;
                    frmMap.Map = frm.Map;
                }
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
        }

        private void Save_Click(object sender, EventArgs e)
        {
        }

        private void Compile_Click(object sender, EventArgs e)
        {
        }

        private void Debug_Click(object sender, EventArgs e)
        {
        }

        private void NewTileset_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNewTileset())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Tileset tileset = frm.Tileset;
                    frmTiles.AddTileset(tileset);
                    frmMap.Map.AddTileset(tileset);
                }
            }
        }

        private void tsbPencil_Click(object sender, EventArgs e)
        {
            CurrentTool = Tool.Pencil;
        }

        private void tsbFill_Click(object sender, EventArgs e)
        {
            CurrentTool = Tool.Fill;
        }

        private void tsbErase_Click(object sender, EventArgs e)
        {
            CurrentTool = Tool.Erase;
        }

        private void tsbSelect_Click(object sender, EventArgs e)
        {
            CurrentTool = Tool.Selector;
        }
    }
}