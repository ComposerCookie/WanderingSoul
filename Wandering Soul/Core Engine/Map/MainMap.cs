using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class MainMap : Map
    {
        public int MinX { get; set; }
        public int MinY { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public List<RowTile> Y { get; set; }
        public List<Terrain> SpawnedTerrain { get; set; }
        public List<SpawnSpawnable> SpawnedSpawnable { get; set; }
        public List<List<int>> SpawnedSpawnableLocation { get; set; }
        public List<List<List<int>>> SpawnedLivingObjects { get; set; }
        public List<List<List<SpawnItems>>> Drop { get; set; }

        public MainMap()
        {
            MinX = -1;
            MinY = -1;
            MaxX = -1;
            MaxY = -1;
            Y = new List<RowTile>();
            SpawnedTerrain = new List<Terrain>();
            SpawnedSpawnable = new List<SpawnSpawnable>();
            SpawnedSpawnableLocation = new List<List<int>>();
            SpawnedLivingObjects = new List<List<List<int>>>();
            Drop = new List<List<List<SpawnItems>>>();
            AtkM = new AttackManager(this);
            AnimM = new AnimationManager();
            NullList = new List<int>();
            LivingThing = new List<LivingObject>();
            MiniText = new List<MiniText>();
        }

        public void Update()
        {
            AtkM.Update();
            AnimM.Update();

            for (int i = MiniText.Count - 1; i >= 0; i--)
            {
                MiniText[i].Update();
                if (MiniText[i].Time <= 0)
                    MiniText.RemoveAt(i);
            }

            for (int r = Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY - Program.VisibleMaxY / 2 - 3; r < Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX - Program.VisibleMaxX / 2 - 3; t < Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX + Program.VisibleMaxX / 2 + 3; t++)
                {
                    if (SpawnedSpawnableLocation[r][t] == -1)
                        continue;

                    SpawnedSpawnable[SpawnedSpawnableLocation[r][t]].Update();
                }
            }
        }

        public AnimationManager AnimM { get; set; }
        public List<int> NullList { get; set; }
        public List<MiniText> MiniText { get; set; }

        public void DrawMiniText(RenderWindow rw)
        {
            foreach (MiniText m in MiniText)
                m.Draw(rw);
        }

        public void DrawMap(RenderWindow rw)
        {
            SFML.Graphics.Sprite s;
            for (int r = Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY - Program.VisibleMaxY / 2 - 3; r < Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX - Program.VisibleMaxX / 2 - 3; t < Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX + Program.VisibleMaxX / 2 + 3; t++)
                {
                    if (_y[r].Tile[t].ID == -1)
                        continue;

                    _y[r].Tile[t].Draw(rw, this, t, r);

                    if (_drop[r][t].Count > 0)
                    {
                        for (int i = 0; i < _drop[r][t].Count; i++)
                        {
                            _drop[r][t][i].DrawDrop(rw, t * Program.Data.TileSizeX, Program.Data.TileSizeY * r);
                        }
                    }
                }
            }
        }

        public void DrawNPC(RenderWindow rw)
        {
            //foreach (LivingObject LivingThing[i] in Program.Data.MyLivingObject)
            for (int i = LivingThing.Count - 1; i >= 0; i--)
            {
                if (LivingThing[i] == null)
                    continue;
                if (LivingThing[i].X + MinX < Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX + Program.VisibleMaxX / 2 + 3 && LivingThing[i].X + MinX > Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX - Program.VisibleMaxX / 2 - 3 && LivingThing[i].Y + MinY < Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY + Program.VisibleMaxY / 2 + 3 && LivingThing[i].Y + MinY > Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY - Program.VisibleMaxY / 2 - 3)
                {
                    LivingThing[i].Draw(rw);
                }
            }
        }

        public void DrawAnimation(RenderWindow rw)
        {
            AtkM.Draw(rw);
            AnimM.Draw(rw);
        }

        public void DrawSpawnBot(RenderWindow rw)
        {
            for (int r = Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY - Program.VisibleMaxY / 2 - 3; r < Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX - Program.VisibleMaxX / 2 - 3; t < Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX + Program.VisibleMaxX / 2 + 3; t++)
                {
                    if (SpawnedSpawnableLocation[r][t] == -1)
                        continue;
                    SpawnedSpawnable[SpawnedSpawnableLocation[r][t]].DrawBot(rw);
                }
            }
        }

        public void DrawSpawnFringe(RenderWindow rw)
        {
            for (int r = Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY - Program.VisibleMaxY / 2 - 3; r < Program.Data.CurrentParty.MainParty.MyParty[0].Y + MinY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX - Program.VisibleMaxX / 2 - 3; t < Program.Data.CurrentParty.MainParty.MyParty[0].X + MinX + Program.VisibleMaxX / 2 + 3; t++)
                {
                    if (SpawnedSpawnableLocation[r][t] == -1)
                        continue;
                    SpawnedSpawnable[SpawnedSpawnableLocation[r][t]].DrawTop(rw);
                }
            }
        }

        public void AddLivingThing(LivingObject p, int x, int y)
        {
            LivingThing.Add(p);
            SpawnedLivingThing[y + MinY][x + MinX].Add(LivingThing.Count - 1);
        }

        public AttackManager AtkM { get; set; }
        public List<LivingObject> LivingThing { get; set; }
    }
}
