using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class World
    {
        public MainMap OverWorld { get; set; }
        public List<Map> SmallMap { get; set; }
        public string Name { get; set; }

        public int SpawnPlaceMapType { get; set; }
        public int SpawnMapX { get; set; }
        public int SpawnMapY { get; set; }
        public int SpawnMapIndex { get; set; }

        
        public World()
        {
            OverWorld = new MainMap();
            MapGenerator mg = new MapGenerator();

            OverWorld = mg.NewMap();

            SmallMap = new List<Map>();
            Name = "New World";

            SpawnPlaceMapType = (int)MapType.MainMap;
            SpawnMapX = 0;
            SpawnMapY = 0;
            SpawnMapIndex = 0;
        }
    }
}
