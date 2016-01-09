using System.Windows.Forms;

namespace Soul.MapEditor.UI.Menu
{
    public class ToolBar : ToolStrip
    {
        public bool RenderBackground
        {
            get { return ((Menu.MenuRenderer) Renderer).RenderBackground; }
            set { ((Menu.MenuRenderer) Renderer).RenderBackground = value; }
        }

        public ToolBar()
        {
            Renderer = new Menu.MenuRenderer();
            DoubleBuffered = true;
        }
    }
}