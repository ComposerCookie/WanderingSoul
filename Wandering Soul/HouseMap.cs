using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class HouseMap : SideMap
    {
        public void DrawMap(RenderWindow rw) { }
        public void DrawNPC(RenderWindow rw) { }
        public void DrawSpawnBot(RenderWindow rw) { }
        public void DrawSpawnFringe(RenderWindow rw) { }
        public void DrawFringe(RenderWindow rw) { }
        public void DrawAnimation(RenderWindow rw) { }
        public void DrawMiniText(RenderWindow rw) { }
        public List<HouseAttribute> Attribute { get; set; }

        public void Update() { }

        public int MinX { get; set; }

        public int MinY { get; set; }

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public List<RowTile> Y { get; set; }
        public List<Terrain> SpawnedTerrain { get; set; }

        public List<SpawnSpawnable> SpawnedSpawnable { get; set; }

        public List<List<int>> SpawnedSpawnableLocation { get; set; }

        public List<List<List<SpawnItems>>> Drop { get; set; }

        public List<List<List<int>>> SpawnedLivingThing { get; set; }
        public List<int> NullList { get; set; }
        public List<LivingObject> LivingThing { get; set; }
        public List<MiniText> MiniText { get; set; }

        public AttackManager AtkM { get; set; }
        public AnimationManager AnimM { get; set; }
    }
}
