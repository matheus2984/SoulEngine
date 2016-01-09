using System.Drawing;
using System.Windows.Forms;
using Soul.MapEditor.Core;

namespace Soul.MapEditor.UI.SideBar
{
    public enum SideBarOrientation
    {
        Left,
        Right
    }

    public class SideBar : Panel
    {
        private SideBarOrientation orientation;

        public SideBarOrientation Orientation
        {
            get { return orientation; }
            set
            {
                orientation = value;
                switch (orientation)
                {
                    case SideBarOrientation.Left:
                        Dock = DockStyle.Left;
                        break;
                    case SideBarOrientation.Right:
                        Dock = DockStyle.Right;
                        break;
                }
            }
        }

        public SideBar()
        {
            Width = 400;
            Height = 300;

            BackColor = Color.FromArgb(0x80, 0x80, 0x80);
            DoubleBuffered = true;

            Orientation = SideBarOrientation.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var helper = new GraphicsHelper(e.Graphics);
            var bounds = new Rectangle(0, 0, Width, Height);

            var shadowWidth = 20;

            switch (orientation)
            {
                case SideBarOrientation.Left:
                    helper.Line(UColor.Blend(0x50, UColor.Black), Width - 1, 0, Width - 1, Height);

                    helper.Gradient(UColor.Blend(0x20, UColor.Black), UColor.Transparent,
                        new Rectangle(Width - shadowWidth, 0, shadowWidth, Height), 180);

                    break;
                case SideBarOrientation.Right:
                    helper.Line(UColor.Blend(0x50, UColor.Black), 0, 0, 0, Height);

                    helper.Gradient(UColor.Blend(0x20, UColor.Black), UColor.Transparent,
                        new Rectangle(0, 0, shadowWidth, Height), 0);

                    break;
            }
        }
    }
}