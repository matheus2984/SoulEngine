using Microsoft.Xna.Framework;
using Soul.Engine.Serialization;

namespace Soul.Engine.World.TileEngine
{
    public class Tile : ISerializable
    {
        public int Col;
        public int Row;
        public int TilesetID;
        public int X;
        public int Y;

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
        }

        public Tile()
        {
        }

        public Tile(int tilesetId, int row, int col, int x, int y)
        {
            TilesetID = tilesetId;
            Row = row;
            Col = col;
            X = x;
            Y = y;
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(TilesetID);
            output.Write(Row);
            output.Write(Col);
            output.Write(X);
            output.Write(Y);
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            TilesetID = input.ReadInt32();
            Row = input.ReadInt32();
            Col = input.ReadInt32();
            X = input.ReadInt32();
            Y = input.ReadInt32();
            return this;
        }
    }
}