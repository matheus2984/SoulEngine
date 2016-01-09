using Microsoft.Xna.Framework;

namespace Soul.MapEditor.Core
{
    public static class MathExtends
    {
        public static int RoundNum(int num, int multipler)
        {
            if (num >= 0)
                return ((num + (multipler/2))/multipler)*multipler;
            return ((num - (multipler/2))/multipler)*multipler;
        }

        public static Rectangle RectangleNormalize(int x1, int x2, int y1, int y2)
        {
            var rc = new Rectangle();
            if (x1 < x2)
            {
                rc.X = x1;
                rc.Width = x2 - x1;
            }
            else
            {
                rc.X = x2;
                rc.Width = x1 - x2;
            }
            if (y1 < y2)
            {
                rc.Y = y1;
                rc.Height = y2 - y1;
            }
            else
            {
                rc.Y = y2;
                rc.Height = y1 - y2;
            }
            return rc;
        }
    }
}