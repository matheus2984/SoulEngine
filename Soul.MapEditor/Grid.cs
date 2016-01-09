using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Soul.MapEditor.Core.Components;

namespace Soul.MapEditor
{
    public class Grid
    {
        public delegate void MouseClickEvent(Rectangle source);

        private readonly Texture2D selectedTexture;
        private readonly Texture2D texture;
        public GraphicsDevice GraphicsDevice;
        private bool s;
        private SpriteBatch spt;
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public List<Rectangle> Lines { get; set; }
        public List<Rectangle> Rectangles { get; set; }
        public Rectangle LastSelectedRectangle { get; set; }

        public Grid(GraphicsDevice graphicsDevice, int rows, int cols, int width = 16, int height = 16)
        {
            texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] {Color.Black});

            selectedTexture = new RenderTarget2D(graphicsDevice, 1, 1);
            selectedTexture.SetData(new[] {new Color(10, 10, 10, 255)});

            Width = width;
            Height = height;
            Rows = rows;
            Cols = cols;

            LastSelectedRectangle = Rectangle.Empty;
            Rectangles = new List<Rectangle>(rows*cols);
            Lines = new List<Rectangle>(rows + cols);

            GraphicsDevice = graphicsDevice;
            spt = new SpriteBatch(graphicsDevice);
            SetRectangles();
        }

        public event MouseClickEvent Click;

        private void SetRectangles()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    var rectangle = new Rectangle(i*Width, j*Height, Width, Height);
                    Rectangles.Add(rectangle);
                }
            }

            for (var i = 0; i < Rows + 1; i++)
            {
                var line = new Rectangle(0, i*Height, Width*Cols, 1);
                Lines.Add(line);
            }
            for (var i = 0; i < Cols + 1; i++)
            {
                var line = new Rectangle(i*Width, 0, 1, Height*Rows);
                Lines.Add(line);
            }
        }

        private void OnClick(Rectangle source)
        {
            if (Click != null)
                Click(source);
        }

        private bool GetIntersection(Rectangle rectangle, out Rectangle intersected)
        {
            for (var i = 0; i < Rectangles.Count; i++)
            {
                if (!Rectangles[i].Intersects(rectangle)) continue;
                intersected = Rectangles[i];
                return true;
            }

            intersected = Rectangle.Empty;
            return false;
        }

        public void Update(EditorViewControl viewControl, GameTime gameTime)
        {
            Mouse.WindowHandle = viewControl.Handle;
            MouseState mouseState = Mouse.GetState();
            if (mouseState.X > viewControl.Width || mouseState.X < 0 || mouseState.Y > viewControl.Height ||
                mouseState.Y < 0) return;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                var mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
                Rectangle rectangle;
                if (GetIntersection(mouseRectangle, out rectangle))
                {
                    LastSelectedRectangle = rectangle;
                    OnClick(rectangle);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //  spt.Begin();

            // spriteBatch.Draw(selectedTexture, new Rectangle(0, 0, 16, 16), Color.Black);
            if (s)
            {
                for (var i = 0; i < Lines.Count; i++)
                {
                    spriteBatch.Draw(texture, Lines[i], Color.Black);
                }
                if (LastSelectedRectangle != Rectangle.Empty)
                {
                    spriteBatch.Draw(selectedTexture, LastSelectedRectangle, Color.Gray);
                }
            }
            s = !s;
            //    spt.End();
        }
    }
}