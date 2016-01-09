using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.Engine.Serialization;

namespace Soul.Engine.World.TileEngine
{
    public class Map : ISerializable
    {
        public string Name { get; set; }
        public Dictionary<int, Tileset> Tilesets { get; set; }
        public List<Layer> Layers { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public Map()
        {
        }

        public Map(string name, int rows, int cols)
        {
            Tilesets = new Dictionary<int, Tileset>();
            Name = name;
            Rows = rows;
            Cols = cols;
            Layers = new List<Layer>();
        }

        public Map(string name, int rows, int cols, List<Layer> layers) : this(name, rows, cols)
        {
            Layers = layers;
        }

        public void AddTileset(Tileset tileset)
        {
            if (Tilesets.ContainsKey(tileset.ID))
                throw new Exception("Este indice ja existe no dicionario");

            Tilesets.Add(tileset.ID, tileset);
        }

        public void RemoveTileset(int id)
        {
            if (!Tilesets.ContainsKey(id))
                throw new Exception("Este indice não existe no dicionario");

            Tilesets.Remove(id);
        }

        public void AddLayer(Layer layer)
        {
            Layers.Add(layer);
        }

        public void RemoveLayer(Layer layer)
        {
            Layers.Remove(layer);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (var i = 0; i < Layers.Count; i++)
            {
                Layers[i].Draw(spriteBatch, gameTime);
            }
        }

        public void Draw(int layerIndex, SpriteBatch spriteBatch, GameTime gameTime)
        {
            Layers[layerIndex].Draw(spriteBatch, gameTime);
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(Name);

            output.Write(Tilesets.Count);
            for (var i = 0; i < Tilesets.Count; i++)
            {
                KeyValuePair<int, Tileset> element = Tilesets.ElementAt(i);
                output.Write(element.Key);
                output.Write(element.Value);
            }

            output.Write(Layers);
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            Name = input.ReadString();

            int tilesetCount = input.ReadInt32();
            Tilesets = new Dictionary<int, Tileset>(tilesetCount);

            for (var i = 0; i < tilesetCount; i++)
            {
                int key = input.ReadInt32();
                var value = input.ReadObject<Tileset>();
                Tilesets.Add(key, value);
            }

            Layers = input.ReadList<Layer>();
            for (var i = 0; i < Layers.Count; i++)
            {
                Layers[i].Map = this;
            }
            return this;
        }
    }
}