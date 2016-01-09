using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.MapEditor.Core.Serialization;

namespace Soul.MapEditor.Core.TileEngine
{
    public class TileableTexture : ISerializable
    {
        public const int TileWidth = 16;
        public const int TileHeigth = 16;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public Rectangle[,] TileSource { get; set; }

        public TileableTexture()
        {
        }

        public TileableTexture(Texture2D texture)
        {
            Texture = texture;
            SetTiles();
        }

        private void SetTiles()
        {
            Rows = Texture.Width/TileWidth;
            Cols = Texture.Height/TileHeigth;

            TileSource = new Rectangle[Cols, Rows];
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    var source = new Rectangle(i*TileWidth, j*TileHeigth, 16, 16);
                    TileSource[j, i] = source;
                }
            }
        }

        public Rectangle GetSource(int row, int col)
        {
            return TileSource[row, col];
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(Texture);
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            Texture = input.ReadTexture();
            SetTiles();
            return this;
        }
    }
}