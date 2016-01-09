using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.MapEditor.Core.Serialization;

namespace Soul.MapEditor.Core.TileEngine
{
    public class Layer : ISerializable
    {
        public Map Map;
        public Tile[,] Tiles;

        private Dictionary<int, Tileset> Tilesets
        {
            get { return Map.Tilesets; }
        }

        public int Rows { get; set; }
        public int Cols { get; set; }

        public Layer()
        {
        }

        public Layer(Map map)
        {
            Map = map;
            Rows = map.Rows;
            Cols = map.Cols;
            Tiles = new Tile[Rows, Cols];
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    Tile tile = Tiles[i, j];
                    if (tile == null) continue;
                    Tileset tileset = Tilesets[tile.TilesetID];
                    spriteBatch.Draw(tileset.TileableTexture.Texture, tile.Position,
                        tileset.GetSource(tile.Row, tile.Col),
                        Color.White);
                }
            }
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(Rows);
            output.Write(Cols);

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    output.Write(Tiles[i, j]);
                }
            }
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            Rows = input.ReadInt32();
            Cols = input.ReadInt32();
            Tiles = new Tile[Rows, Cols];

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    Tiles[i, j] = input.ReadObject<Tile>();
                }
            }

            return this;
        }
    }
}