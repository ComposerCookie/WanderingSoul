using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class BuildFire : Buildable
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int Sprite { get; set; }
        public int PickSprite { get; set; }
        public int StartSprite { get; set; }
        public int StageOneSprite { get; set; }
        public int StageTwoStage { get; set; }
        public int DestroyedStage { get; set; }
        public byte Blocked { get; set; }
        public List<int> Classification { get; set; }
        public Dictionary<SpawnItems, int> RequiredItems { get; set; }
        public List<SpawnItems> DestroyDrop { get; set; }
        public bool Destroyable { get; set; }
        public int Tick { get; set; }

        public BuildFire()
        {
        }

        public BuildFire(string name, int maxhealth, int sizex, int sizey, int sprite, int startsprite, int stage1, int stage2, int destroysprite, byte blocked, List<int> classific, Dictionary<SpawnItems, int> requried, List<SpawnItems> drop, int tick)
        {
            Name = name;
            MaxHealth = maxhealth;
            SizeX = sizex;
            SizeY = sizey;
            Sprite = sprite;
            StartSprite = startsprite;
            StageOneSprite = stage1;
            StageTwoStage = stage2;
            DestroyedStage = destroysprite;
            Blocked = blocked;
            Classification = classific;
            RequiredItems = requried;
            DestroyDrop = drop;
            Tick = tick;
        }
    }
}
