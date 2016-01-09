using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Soul.MapEditor.Core
{
    [DefaultEvent("Click")]
    public class Button : UserControl
    {
        public bool Hover { get; set; }
        public bool Pressed { get; set; }
        public Image Image { get; set; }
        public string Caption { get; set; }

        public Button()
        {
            BackColor = Color.Transparent;
            DoubleBuffered = true;

            Width = 85;
            Height = 28;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hover = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Pressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Pressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var helper = new GraphicsHelper(e.Graphics);
            var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            var inner = new Rectangle(1, 1, Width - 3, Height - 3);
            var gradient = new Rectangle(1, 1, Width - 3, (Height - 1)/2);
            var textShadow = new Rectangle(1, 1, Width - 2, Height - 1);

            helper.RoundedFill(UColor.White, bounds, 4);
            if (!Hover && !Pressed)
            {
                helper.RoundedGradient(UColor.Blend(0x05, UColor.Black), UColor.Blend(0x20, UColor.Black), bounds, 90, 4);
                helper.RoundedGradient(UColor.Blend(0xdd, UColor.White), UColor.White, gradient, 90, 4);

                helper.RoundedOutline(UColor.Blend(0x80, UColor.White), inner, 4);
                helper.RoundedOutline(UColor.Blend(0x70, UColor.Black), bounds, 4);

                helper.Text(Caption, Font, UColor.White, textShadow);
                helper.Text(Caption, Font, UColor.Blend(0xdd, UColor.Black), bounds);
            }
            if (Hover && !Pressed)
            {
                helper.RoundedFill(UColor.Blend(0x25, UColor.CornflowerBlue), bounds, 4);

                helper.RoundedGradient(UColor.Blend(0x15, UColor.Black), UColor.Blend(0x20, UColor.Black), bounds, 90, 4);
                helper.RoundedGradient(UColor.Blend(0x66, UColor.White), UColor.Blend(0x66, UColor.White), gradient, 90,
                    4);

                helper.RoundedOutline(UColor.Blend(0x60, UColor.White), inner, 4);
                helper.RoundedOutline(UColor.Blend(0x80, UColor.Black), bounds, 4);

                helper.Text(Caption, Font, UColor.Blend(0xaa, UColor.White), textShadow);
                helper.Text(Caption, Font, UColor.Blend(0xee, UColor.Black), bounds);
            }
            if (Pressed)
            {
                helper.RoundedFill(UColor.Blend(0x25, UColor.CornflowerBlue), bounds, 4);

                helper.RoundedGradient(UColor.Blend(0x30, UColor.Black), UColor.Blend(0x05, UColor.Black), bounds, 90, 4);

                helper.RoundedOutline(UColor.Blend(0x60, UColor.White), inner, 4);
                helper.RoundedOutline(UColor.Blend(0x80, UColor.Black), bounds, 4);

                helper.Text(Caption, Font, UColor.Blend(0xaa, UColor.White), textShadow);
                helper.Text(Caption, Font, UColor.Blend(0xee, UColor.Black), bounds);
            }
            if (!Enabled)
            {
                helper.Text(Caption, Font, UColor.Blend(0x30, UColor.White), bounds);
            }
            if (Image != null)
            {
                e.Graphics.DrawImage(Image, new Point(Width/2 - Image.Width/2, Height/2 - Image.Height/2));
            }
        }
    }
}