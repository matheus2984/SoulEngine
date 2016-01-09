using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.MapEditor.Core.Serialization;

namespace Soul.MapEditor.Core.TileEngine
{
    public class Tileset : ISerializable
    {
        public int ID { get; set; }
        public TileableTexture TileableTexture { get; set; }
        public string Name { get; set; }

        public Tileset()
        {
        }

        public Tileset(int id, Texture2D texture)
        {
            ID = id;
            TileableTexture = new TileableTexture(texture);
        }

        public Rectangle? GetSource(int row, int col)
        {
            return TileableTexture.GetSource(row, col);
        }

        public override string ToString()
        {
            return Name;
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(ID);
            output.Write(Name);
            output.Write(TileableTexture);
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            ID = input.ReadInt32();
            Name = input.ReadString();
            TileableTexture = input.ReadObject<TileableTexture>();
            return this;
        }
    }
}