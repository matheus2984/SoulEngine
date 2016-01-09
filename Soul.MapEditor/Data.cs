using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Soul.MapEditor.Core.TileEngine;

namespace Soul.MapEditor
{
    public static class Data
    {
        public static Tool CurrentTool { get; set; }
        public static Map Map { get; set; }
        public static List<Tileset> Tilesets { get; set; }
        public static Rectangle CurrentTileSource { get; set; }
    }
}