using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class TreeResource : Resource
    {        
        public TreeResource(string name, int sprite, int sizeX, int sizeY, int maxhealth, List<SpawnItems> give, List<int> SpawnOn, byte block, int next, int tooltype)
        {
            Name = name;
            Sprite = sprite;
            SizeX = sizeX;
            SizeY = sizeY;
            MaxHealth = maxhealth;
            NextStage = next;
            Give = give;
            TerrainSpawnOn = SpawnOn;
            Blocked = block;
            ToolRequired = tooltype;
            Destroyable = true;
        }
    }
}
