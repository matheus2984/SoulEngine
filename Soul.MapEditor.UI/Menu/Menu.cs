using System.Drawing;
using System.Windows.Forms;
using Soul.MapEditor.Core;

namespace Soul.MapEditor.UI.Menu
{
    public class Menu : MenuStrip
    {
        public bool RenderBackground
        {
            get { return ((MenuRenderer) Renderer).RenderBackground; }
            set { ((MenuRenderer) Renderer).RenderBackground = value; }
        }

        public Menu()
        {
            Renderer = new MenuRenderer();
            Padding = new Padding(5);

            DoubleBuffered = true;
        }

        internal class MenuRenderer : ToolStripRenderer
        {
            private readonly int innerShadow = 2;
            public bool RenderBackground { get; set; }

            public MenuRenderer()
            {
                RenderBackground = true;
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                var helper = new GraphicsHelper(e.Graphics);

                if (RenderBackground)
                {
                    helper.Clear(UColor.White);
                    helper.Gradient(UColor.Blend(0x05, UColor.Black), UColor.Blend(0x30, UColor.Black),
                        e.AffectedBounds.Inflated(-1), 90);
                }
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                var helper = new GraphicsHelper(e.Graphics);

                if (RenderBackground)
                {
                    helper.Line(UColor.Blend(0x7a, UColor.Black), 0, e.AffectedBounds.Width, e.AffectedBounds.Height - 1);
                    helper.Line(UColor.Blend(0xdd, UColor.White), 0, e.AffectedBounds.Width, e.AffectedBounds.Height - 2);
                }
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                var helper = new GraphicsHelper(e.Graphics);
                var button = e.Item as ToolStripButton;

                var shadow = new Rectangle(
                    e.TextRectangle.X + 1,
                    e.TextRectangle.Y + 1,
                    e.TextRectangle.Width,
                    e.TextRectangle.Height);

                uint shadowColor = UColor.Blend(0xdd, UColor.White);
                uint textColor = e.TextColor.ToUInt();

                if (e.Item.Selected || e.Item.Pressed || (button != null && button.Checked))
                {
                    shadowColor = UColor.Blend(0x7a, UColor.Black);
                    textColor = UColor.White;
                }

                var format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;

                helper.Text(e.Text, e.TextFont, shadowColor, shadow, format);
                helper.Text(e.Text, e.TextFont, textColor, e.TextRectangle, format);
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                OnRenderButtonBackground(e);
            }

            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                var helper = new GraphicsHelper(e.Graphics);
                var itemBounds = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
                var button = e.Item as ToolStripButton;

                if (e.Item.Selected && !e.Item.Pressed || (button != null && button.Checked))
                {
                    helper.RoundedFill(UColor.White, itemBounds, 4);
                    helper.RoundedGradient(
                        UColor.Blend(0x80, UColor.Black),
                        UColor.Blend(0x60, UColor.Black),
                        itemBounds,
                        90, 4);
                }
                if (e.Item.Pressed)
                {
                    helper.RoundedFill(UColor.White, itemBounds, 4);
                    helper.RoundedGradient(
                        UColor.Blend(0xa0, UColor.Black),
                        UColor.Blend(0x60, UColor.Black),
                        itemBounds,
                        90, 4);
                }
                if (e.Item.Selected || e.Item.Pressed || (button != null && button.Checked))
                {
                    for (int i = innerShadow; i >= 0; i--)
                    {
                        helper.RoundedOutline(UColor.Blend((byte) ((5 + innerShadow*10) - i*10), UColor.Black),
                            itemBounds.Inflated(i + 2), i + 1);
                    }
                    helper.RoundedOutline(UColor.Blend(0x60, UColor.Black), itemBounds.Inflated(1), 4);
                    helper.RoundedOutline(UColor.Blend(0xff, UColor.White), itemBounds, 4);
                }
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                var helper = new GraphicsHelper(e.Graphics);
                switch (e.Vertical)
                {
                    case true:
                        helper.Line(UColor.Blend(0x50, UColor.White), e.Item.Width/2 - 1, 0, e.Item.Width/2 - 1,
                            e.Item.Height);
                        helper.Line(UColor.Blend(0x60, UColor.Black), e.Item.Width/2, 0, e.Item.Width/2, e.Item.Height);
                        helper.Line(UColor.Blend(0x50, UColor.White), e.Item.Width/2 + 1, 0, e.Item.Width/2 + 1,
                            e.Item.Height);
                        break;
                    case false:
                        helper.Line(UColor.Blend(0x50, UColor.Black), 0, e.Item.Height/2, e.Item.Width, e.Item.Height/2);
                        helper.Line(UColor.Blend(0x80, UColor.White), 0, e.Item.Height/2 + 1, e.Item.Width,
                            e.Item.Height/2 + 1);
                        break;
                }
            }
        }
    }
}