using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.Engine.Serialization
{
    public class BinaryInput : BinaryReader
    {
        private GraphicsDevice GraphicsDevice { get; set; }

        public BinaryInput(Stream stream) : base(stream)
        {
        }

        public BinaryInput(Stream stream, GraphicsDevice graphicsDevice) : base(stream)
        {
            GraphicsDevice = graphicsDevice;
        }

        public T ReadObject<T>() where T : ISerializable, new()
        {
            ISerializable value = new T();
            value.Deserialize(this);

            return (T) value;
        }

        public Vector2 ReadVector2()
        {
            float x = ReadSingle();
            float y = ReadSingle();

            return new Vector2(x, y);
        }

        public Rectangle ReadRectangle()
        {
            int x = ReadInt32();
            int y = ReadInt32();
            int width = ReadInt32();
            int height = ReadInt32();

            return new Rectangle(x, y, width, height);
        }

        public Texture2D ReadTexture()
        {
            if (GraphicsDevice == null) throw new Exception("Set GraphicsDevice in BinaryInput");

            Texture2D texture;

            bool compressed = ReadBoolean();

            if (compressed == false)
            {
                int witdh = ReadInt32();
                int height = ReadInt32();
                var data = new byte[witdh*height*4];
                data = ReadBytes(data.Length);

                texture = new Texture2D(GraphicsDevice, witdh, height);
                texture.SetData(data);

                return texture;
            }
            int size = ReadInt32();
            using (var ms = new MemoryStream())
            {
                ms.Write(ReadBytes(size), 0, size);
                texture = Texture2D.FromStream(GraphicsDevice, ms);
            }

            return texture;
        }

        public List<T> ReadList<T>() where T : ISerializable, new()
        {
            int count = ReadInt32();
            var result = new List<T>();

            for (var i = 0; i < count; i++)
            {
                result.Add(ReadObject<T>());
            }

            return result;
        }
    }
}