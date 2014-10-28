using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Resource : Spawnable
    {
        public Resource(string name, int sprite, int sizeX, int sizeY, int maxhealth, List<int> SpawnOn, byte block, int tooltype)
        {
            TerrainSpawnOn = SpawnOn;
            Name = name;
            Sprite = sprite;
            SizeX = sizeX;
            SizeY = sizeY;
            MaxHealth = maxhealth;
            Blocked = block;
            ToolRequired = tooltype;
            Destroyable = true;
        }

        public Resource()
        {
        }

        public int NextStage { get; set; }
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int Sprite { get; set; }
        public byte Blocked { get; set; }
        public List<int> TerrainSpawnOn { get; set; }
        public int DeadSprite { get; set; }
        public List<SpawnItems> Give{get;set;}
        public int ToolRequired { get; set; }
        public bool Destroyable { get; set; }
    }
}
