using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public interface SideMap : Map
    {
        void DrawMap(RenderWindow rw);
        void DrawNPC(RenderWindow rw);
        void DrawSpawnBot(RenderWindow rw);
        void DrawSpawnFringe(RenderWindow rw);
        void DrawAnimation(RenderWindow rw);
        void DrawMiniText(RenderWindow rw);
        void Update();

        int MinX { get; set; }

        int MinY { get; set; }

        int MaxX { get; set; }

        int MaxY { get; set; }

        List<RowTile> Y { get; set; }
        List<Terrain> SpawnedTerrain { get; set; }

        List<SpawnSpawnable> SpawnedSpawnable { get; set; }

        List<List<int>> SpawnedSpawnableLocation { get; set; }

        List<List<List<SpawnItems>>> Drop { get; set; }

        List<List<List<int>>> SpawnedLivingThing { get; set; }
        List<int> NullList { get; set; }
        List<LivingObject> LivingThing { get; set; }
        List<MiniText> MiniText { get; set; }

        AttackManager AtkM { get; set; }
        AnimationManager AnimM { get; set; }
    }
}
