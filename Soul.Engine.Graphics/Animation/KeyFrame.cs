using Microsoft.Xna.Framework;
using Soul.Engine.Serialization;

namespace Soul.Engine.Graphics.Animation
{
    public class KeyFrame : ISerializable
    {
        public Rectangle Source { get; private set; }

        public Point Center
        {
            get { return Source.Center; }
        }

        public int X
        {
            get { return Source.X; }
        }

        public int Y
        {
            get { return Source.Y; }
        }

        public int Width
        {
            get { return Source.Width; }
        }

        public int Height
        {
            get { return Source.Height; }
        }

        public KeyFrame(int x, int y, int width, int height)
        {
            Source = new Rectangle(x, y, width, height);
        }

        public KeyFrame(Rectangle source)
        {
            Source = source;
        }

        public KeyFrame()
        {
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(Source);
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            Source = input.ReadRectangle();
            return this;
        }
    }
}