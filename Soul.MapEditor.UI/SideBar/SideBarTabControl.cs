using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Soul.MapEditor.Core;

namespace Soul.MapEditor.UI.SideBar
{
    public class SideBarTabControl : UserControl
    {
        private int hoverIndex;
        private int selectedIndex;
        public string Title { get; set; }
        public List<SideBarTab> Tabs { get; private set; }
        public SideBar SideBar { get; set; }
        public Color TabColor { get; set; }
        public int TabHeight { get; set; }
        public int TabMarginTop { get; set; }
        public int TabMarginLeft { get; set; }
        public int TabSpacing { get; set; }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (SelectedIndexChanged != null)
                {
                    SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        public SideBarTabControl()
        {
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Dock = DockStyle.Fill;

            Tabs = new List<SideBarTab>();
            TabColor = Color.White;

            TabHeight = 24;
            TabMarginTop = 10;
            TabMarginLeft = 10;
            TabSpacing = 2;
        }

        public event EventHandler SelectedIndexChanged;

        public void Add(string caption)
        {
            var tab = new SideBarTab();
            tab.Caption = caption;

            Tabs.Add(tab);
        }

        public void Add(string caption, Image icon)
        {
            var tab = new SideBarTab();
            tab.Caption = caption;
            tab.Icon = icon;

            Tabs.Add(tab);
        }

        public int GetIndex(int mouseY)
        {
            for (var i = 0; i < Tabs.Count; i++)
            {
                int y = i*(TabHeight + TabSpacing) + TabMarginTop;

                if (mouseY > y && mouseY <= y + TabHeight + TabSpacing)
                {
                    return i;
                }
            }
            return -1;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int index = GetIndex(e.Y);
            if (index > -1)
            {
                SelectedIndex = index;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            hoverIndex = GetIndex(e.Y);
            Invalidate();

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hoverIndex = -1;
            Invalidate();

            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var helper = new GraphicsHelper(e.Graphics);
            var orientation = SideBarOrientation.Left;

            if (SideBar != null)
            {
                orientation = SideBar.Orientation;
            }
            for (var i = 0; i < Tabs.Count; i++)
            {
                SideBarTab tab = Tabs[i];

                Point currentPosition = Point.Empty;

                Rectangle tabRect = Rectangle.Empty,
                    textRect = Rectangle.Empty;

                switch (orientation)
                {
                    case SideBarOrientation.Left:
                        currentPosition = new Point(TabMarginLeft, i*(TabHeight + TabSpacing) + TabMarginTop);
                        tabRect = new Rectangle(currentPosition.X, currentPosition.Y, Width, TabHeight);
                        break;
                    case SideBarOrientation.Right:
                        currentPosition = new Point(TabMarginLeft, i*(TabHeight + TabSpacing) + TabMarginTop);
                        tabRect = new Rectangle(currentPosition.X - TabMarginLeft*2, currentPosition.Y, Width, TabHeight);
                        break;
                }

                var leftFormat = new StringFormat();
                leftFormat.LineAlignment = StringAlignment.Center;
                leftFormat.Alignment = StringAlignment.Near;

                if (i == SelectedIndex || i == hoverIndex)
                {
                    var gradient = new Rectangle(tabRect.X + 1, tabRect.Y + 1, tabRect.Width - 3, (tabRect.Height - 1)/2);

                    if (i == SelectedIndex)
                    {
                        helper.RoundedFill(UColor.White, tabRect, 4);
                    }
                    if (i == hoverIndex)
                    {
                        helper.RoundedFill(UColor.Blend(0x50, UColor.White), tabRect, 4);
                    }
                    helper.RoundedGradient(UColor.Blend(0x05, UColor.Black), UColor.Blend(0x20, UColor.Black), tabRect,
                        90, 4);

                    if (i == SelectedIndex)
                    {
                        helper.RoundedGradient(UColor.Blend(0xdd, UColor.White), UColor.White, gradient, 90, 4);
                    }

                    helper.RoundedOutline(UColor.Blend(0x60, UColor.White), tabRect.Inflated(1), 4);

                    if (i == SelectedIndex)
                    {
                        helper.RoundedOutline(UColor.Blend(0x90, UColor.Black), tabRect, 4);
                    }
                    else if (i == hoverIndex)
                    {
                        helper.RoundedOutline(UColor.Blend(0x50, UColor.Black), tabRect, 4);
                    }
                }

                if (tab.Changed)
                {
                    helper.RoundedFill(UColor.Blend(0x30, UColor.White), tabRect, 4);
                    helper.RoundedFill(UColor.Blend(0x20, UColor.Red), tabRect, 4);
                }
                if (tab.HasIcon)
                {
                    e.Graphics.DrawImage(tab.Icon,
                        new Point(currentPosition.X + TabMarginLeft, currentPosition.Y + TabHeight/2 - tab.Icon.Height/2));
                    currentPosition.Offset(TabMarginLeft + 2 + tab.Icon.Width, 0);
                }

                textRect = new Rectangle(currentPosition.X, currentPosition.Y, Width, TabHeight);
                if (i == SelectedIndex)
                {
                    helper.Text(tab.Caption, Font, UColor.Blend(0xff, UColor.White), textRect.ShrinkedY(-2), leftFormat);
                    helper.Text(tab.Caption, Font, UColor.Blend(0xdd, UColor.Black), textRect, leftFormat);
                }
                else
                {
                    helper.Text(tab.Caption, Font, UColor.Blend(0xee, UColor.Black), textRect.ShrinkedY(-2), leftFormat);
                    helper.Text(tab.Caption, Font, UColor.Blend(0xff, UColor.White), textRect, leftFormat);
                }
            }
        }
    }

    public struct SideBarTab
    {
        public string Caption { get; set; }
        public Image Icon { get; set; }
        public bool Changed { get; set; }

        public bool HasIcon
        {
            get { return Icon != null; }
        }
    }
}