using System;
using System.Windows.Forms;
using Soul.MapEditor.Core.TileEngine;

namespace Soul.MapEditor.Forms
{
    public partial class FrmNewFile : Form
    {
        public Map Map { get; set; }

        public FrmNewFile()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Map = new Map(txtName.Text, (int) nudMapWidth.Value, (int) nudMapHeight.Value);

            for (var i = 0; i < 4; i++)
            {
                var layer = new Layer(Map);
                Map.AddLayer(layer);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}