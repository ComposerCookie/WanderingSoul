using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class BuildableHouse : Buildable
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int PickSprite { get; set; }
        public int Sprite { get; set; }
        public int StartSprite { get; set; }
        public int StageOneSprite { get; set; }
        public int StageTwoStage { get; set; }
        public int DestroyedStage { get; set; }
        public byte Blocked { get; set; }
        public List<int> Classification { get; set; }
        public Dictionary<SpawnItems, int> RequiredItems { get; set; }
        public List<SpawnItems> DestroyDrop { get; set; }
        public bool Destroyable { get; set; }
        public List<int> BuildableOnType { get; set; }
        public List<KeyValuePair<int, int>> DoorLocation { get; set; }
        public List<int> TotalTerrainCount { get; set; }

        public List<List<List<int>>> TileData{get;set;}
        public List<List<HouseAttribute>> Attribute { get; set; }

        public BuildableHouse(string name, int maxhealth, int sizex, int sizey, int pick, int sprite, int start, int stage1, int stage2, int destroyedstage, byte block, List<int> classify, Dictionary<SpawnItems, int> required, List<SpawnItems> drop, bool destroy, List<List<List<int>>> tile, List<int> terrain, List<List<HouseAttribute>> attribute, List<KeyValuePair<int, int>> door)
        {
            Name = name;
            MaxHealth = maxhealth;
            SizeX = sizex;
            SizeY = sizey;
            PickSprite = pick;
            Sprite = sprite;
            StartSprite = start;
            StageOneSprite = stage1;
            StageTwoStage = stage2;
            DestroyedStage = destroyedstage;
            Blocked = block;
            Classification = classify;
            RequiredItems = required;
            DestroyDrop = drop;
            Destroyable = destroy;
            TileData = tile;
            TotalTerrainCount = terrain;
            DoorLocation = door;
            Attribute = attribute;
        }
    }
}
