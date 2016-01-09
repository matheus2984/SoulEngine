using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.Engine.Graphics
{
    public static class FontAlignment
    {
        public static void DrawString(this SpriteBatch spriteBatch, SpriteFont font, string text,
            Rectangle bounds, Alignment align, Color color)
        {
            Vector2 size = font.MeasureString(text);
            Vector2 pos = bounds.Center.ToVector2();
            Vector2 origin = size*0.5f;

            if (align.HasFlag(Alignment.Left))
                origin.X += bounds.Width*0.5f - size.X*0.5f;

            if (align.HasFlag(Alignment.Right))
                origin.X -= bounds.Width*0.5f - size.X*0.5f;

            if (align.HasFlag(Alignment.Top))
                origin.Y += bounds.Height*0.5f - size.Y*0.5f;

            if (align.HasFlag(Alignment.Bottom))
                origin.Y -= bounds.Height*0.5f - size.Y*0.5f;

            spriteBatch.DrawString(font, text, pos, color, 0, origin, 1, SpriteEffects.None, 0);
        }

        [Flags]
        public enum Alignment
        {
            Center = 0,
            Left = 1,
            Right = 2,
            Top = 4,
            Bottom = 8
        }
    }
}