using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Soul.MapEditor.Core
{
    public class GraphicsHelper
    {
        private readonly Graphics graphics;

        public GraphicsHelper(Graphics graphics)
        {
            this.graphics = graphics;

            this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        public void Gradient(uint argb0, uint argb1, Rectangle rect, float angle)
        {
            Color from = argb0.ToColor();
            Color to = argb1.ToColor();

            graphics.FillRectangle(
                new LinearGradientBrush(
                    new Rectangle(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2),
                    from, to, angle),
                rect);
        }

        public void Clear(uint argb)
        {
            graphics.Clear(argb.ToColor());
        }

        public void Line(uint argb, int x0, int y0, int x1, int y1)
        {
            graphics.DrawLine(new Pen(argb.ToColor()), x0, y0, x1, y1);
        }

        public void Line(uint argb, int x0, int x1, int y)
        {
            Line(argb, x0, y, x1, y);
        }

        public void Outline(uint argb0, Rectangle rect)
        {
            graphics.DrawRectangle(new Pen(argb0.ToColor()), rect);
        }

        public void RoundedGradient(uint argb0, uint argb1, Rectangle rect, float angle, int radius)
        {
            GraphicsPath roundedPath = createRoundedPath(rect, radius);

            Color from = argb0.ToColor();
            Color to = argb1.ToColor();

            graphics.FillPath(new LinearGradientBrush(rect, from, to, angle), roundedPath);
        }

        public void RoundedFill(uint argb, Rectangle rect, int radius)
        {
            GraphicsPath roundedPath = createRoundedPath(rect, radius);
            graphics.FillPath(new SolidBrush(argb.ToColor()), roundedPath);
        }

        public void RoundedOutline(uint argb, Rectangle rect, int radius)
        {
            GraphicsPath roundedPath = createRoundedPath(rect, radius);
            graphics.DrawPath(new Pen(argb.ToColor()), roundedPath);
        }

        public void Text(string text, Font font, uint argb, Rectangle rect)
        {
            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Text(text, font, argb, rect, format);
        }

        public void Text(string text, Font font, uint argb, Rectangle rect, StringFormat format)
        {
            graphics.DrawString(
                text, font,
                new SolidBrush(argb.ToColor()),
                rect, format);
        }

        private GraphicsPath createRoundedPath(Rectangle rect, int radius)
        {
            var result = new GraphicsPath();
            result.AddLine(rect.X + radius, rect.Y, rect.X + rect.Width - radius, rect.Y);
            result.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);

            result.AddLine(rect.X + rect.Width, rect.Y + radius, rect.X + rect.Width, rect.Y + rect.Height - radius);
            result.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);

            result.AddLine(rect.X + rect.Width - radius, rect.Y + rect.Height, rect.X + radius, rect.Y + rect.Height);
            result.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);

            result.AddLine(rect.X, rect.Y + rect.Height - radius, rect.X, rect.Y + radius);
            result.AddArc(rect.X, rect.Y, radius, radius, 180, 90);

            result.CloseFigure();
            return result;
        }
    }

    public static class RectangleExtensions
    {
        public static Rectangle Inflated(this Rectangle rect, int radius)
        {
            rect.Inflate(-radius, -radius);
            return rect;
        }

        public static Rectangle Shrinked(this Rectangle rect, int amount)
        {
            rect.Width -= amount;
            rect.Height -= amount;

            return rect;
        }

        public static Rectangle ShrinkedX(this Rectangle rect, int amount)
        {
            rect.Width -= amount;
            return rect;
        }

        public static Rectangle ShrinkedY(this Rectangle rect, int amount)
        {
            rect.Height -= amount;
            return rect;
        }

        public static Rectangle Offseted(this Rectangle rect, int x, int y)
        {
            rect.X += x;
            rect.Y += y;

            return rect;
        }
    }

    public static class UColor
    {
        public static uint White = Color.White.ToUInt();
        public static uint Black = Color.Black.ToUInt();
        public static uint Transparent = Color.Transparent.ToUInt();
        public static uint CornflowerBlue = Color.CornflowerBlue.ToUInt();
        public static uint LightBlue = Color.LightBlue.ToUInt();
        public static uint Red = Color.Red.ToUInt();

        public static uint Blend(byte alpha, uint baseColor)
        {
            return (uint) (alpha << 24) + baseColor;
        }

        public static uint Argb(byte a, byte r, byte g, byte b)
        {
            return (uint) ((a << 24) | (r << 16) | (g << 8) | (b << 0));
        }

        public static uint Rgb(byte r, byte g, byte b)
        {
            return Argb(0xFF, r, g, b);
        }

        #region Extensions

        public static Color ToColor(this uint color)
        {
            var a = (byte) (color >> 24);
            var r = (byte) (color >> 16);
            var g = (byte) (color >> 8);
            var b = (byte) (color >> 0);

            return Color.FromArgb(a, r, g, b);
        }

        public static uint ToUInt(this Color color)
        {
            return (uint) ((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
        }

        #endregion
    }
}