using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Soul.Engine.Serialization
{
    public static class Serializer
    {
        public static void Serialize<T>(string path, ISerializable value)
        {
            using (var output = new BinaryOutput(File.Open(path, FileMode.Create)))
                Serialize(output, value);
        }

        public static void Serialize<T>(Stream stream, ISerializable value)
        {
            using (var output = new BinaryOutput(stream))
                Serialize(output, value);
        }

        public static void Serialize(BinaryOutput output, ISerializable value)
        {
            value.Serialize(output);
        }

        public static T Deserialize<T>(string path) where T : ISerializable, new()
        {
            using (FileStream stream = File.Open(path, FileMode.Open))
                return Deserialize<T>(stream);
        }

        public static T Deserialize<T>(Stream stream) where T : ISerializable, new()
        {
            using (var input = new BinaryInput(stream))
            {
                ISerializable result = new T();
                result.Deserialize(input);
                return (T) result;
            }
        }

        public static T Deserialize<T>(BinaryInput input) where T : ISerializable, new()
        {
            ISerializable result = new T();
            result.Deserialize(input);
            return (T) result;
        }

        public static T Deserialize<T>(string fileName, GraphicsDevice graphicsDevice) where T : ISerializable, new()
        {
            using (FileStream stream = File.Open(fileName, FileMode.Open))
                return Deserialize<T>(stream, graphicsDevice);
        }

        public static T Deserialize<T>(Stream stream, GraphicsDevice graphicsDevice) where T : ISerializable, new()
        {
            var input = new BinaryInput(stream, graphicsDevice);

            ISerializable result = new T();
            result.Deserialize(input);

            return (T) result;
        }
    }
}