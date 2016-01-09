using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.Engine.Serialization
{
    public class BinaryOutput : BinaryWriter
    {
        //   private GraphicsDevice GraphicsDevice { get; set; }

        public BinaryOutput(Stream stream) : base(stream)
        {
        }

        /*   public BinaryOutput(Stream stream, GraphicsDevice graphicsDevice) : base(stream)
        {
            GraphicsDevice = graphicsDevice;
        }*/

        public override void Write(char value)
        {
            byte data = Convert.ToByte(value);
            Write(data);
        }

        public void Write(ISerializable value)
        {
            value.Serialize(this);
        }

        public void Write(Vector2 value)
        {
            Write(value.X);
            Write(value.Y);
        }

        public void Write(Rectangle value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Width);
            Write(value.Height);
        }

        public void Write(Texture2D value, bool compressed = true)
        {
            Write(compressed);
            if (compressed == false)
            {
                var data = new byte[value.Width*value.Height*4];
                value.GetData(data);

                Write(value.Width);
                Write(value.Height);
                Write(data);
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    value.SaveAsPng(ms, value.Width, value.Height);

                    Write((int) ms.Length);
                    Write(ms.ToArray());
                }
            }
        }

        public void Write<T>(List<T> value) where T : ISerializable
        {
            Write(value.Count);
            for (var i = 0; i < value.Count; i++)
            {
                value[i].Serialize(this);
            }
        }
    }
}