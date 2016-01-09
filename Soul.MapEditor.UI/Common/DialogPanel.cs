using System.Drawing;
using System.Windows.Forms;
using Soul.MapEditor.Core;

namespace Soul.MapEditor.UI.Common
{
    public class DialogPanel : Panel
    {
        public DialogPanel()
        {
            Dock = DockStyle.Bottom;
            DoubleBuffered = true;

            BackColor = Color.FromArgb(0x80, 0x80, 0x80);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var helper = new GraphicsHelper(e.Graphics);

            helper.Gradient(UColor.Blend(0x30, UColor.Black), UColor.Transparent, new Rectangle(0, 0, Width, Height/2),
                90);
            helper.Line(UColor.Blend(0x60, UColor.Black), 0, 0, Width, 0);
        }
    }
}