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
        int _minX;
        int _minY;
        int _maxX;
        int _maxY;

        List<RowTile> _y;
        List<Terrain> _spawnedTerrain;
        List<SpawnSpawnable> _spawnedSpawnable;
        List<List<int>> _spawnedSpawnableLocation;
        List<List<List<int>>> _spawnedLivingObjects;
        List<List<List<SpawnItems>>> _drop;

        public MainMap()
        {
            _minX = -1;
            _minY = -1;
            _maxX = -1;
            _maxY = -1;
            _y = new List<RowTile>();
            _spawnedTerrain = new List<Terrain>();
            _spawnedSpawnable = new List<SpawnSpawnable>();
            _spawnedSpawnableLocation = new List<List<int>>();
            _spawnedLivingObjects = new List<List<List<int>>>();
            _drop = new List<List<List<SpawnItems>>>();
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

            for (int r = Logic.CurrentParty.MainParty.MyParty[0].Y + _minY - Program.VisibleMaxY / 2 - 3; r < Logic.CurrentParty.MainParty.MyParty[0].Y + _minY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Logic.CurrentParty.MainParty.MyParty[0].X + _minX - Program.VisibleMaxX / 2 - 3; t < Logic.CurrentParty.MainParty.MyParty[0].X + _minX + Program.VisibleMaxX / 2 + 3; t++)
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
            for (int r = Logic.CurrentParty.MainParty.MyParty[0].Y + _minY - Program.VisibleMaxY / 2 - 3; r < Logic.CurrentParty.MainParty.MyParty[0].Y + _minY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Logic.CurrentParty.MainParty.MyParty[0].X + _minX - Program.VisibleMaxX / 2 - 3; t < Logic.CurrentParty.MainParty.MyParty[0].X + _minX + Program.VisibleMaxX / 2 + 3; t++)
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
                if (LivingThing[i].X + _minX < Logic.CurrentParty.MainParty.MyParty[0].X + _minX + Program.VisibleMaxX / 2 + 3 && LivingThing[i].X + _minX > Logic.CurrentParty.MainParty.MyParty[0].X + _minX - Program.VisibleMaxX / 2 - 3 && LivingThing[i].Y + _minY < Logic.CurrentParty.MainParty.MyParty[0].Y + _minY + Program.VisibleMaxY / 2 + 3 && LivingThing[i].Y + _minY > Logic.CurrentParty.MainParty.MyParty[0].Y + _minY - Program.VisibleMaxY / 2 - 3)
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
            for (int r = Logic.CurrentParty.MainParty.MyParty[0].Y + _minY - Program.VisibleMaxY / 2 - 3; r < Logic.CurrentParty.MainParty.MyParty[0].Y + _minY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Logic.CurrentParty.MainParty.MyParty[0].X + _minX - Program.VisibleMaxX / 2 - 3; t < Logic.CurrentParty.MainParty.MyParty[0].X + _minX + Program.VisibleMaxX / 2 + 3; t++)
                {
                    if (_spawnedSpawnableLocation[r][t] == -1)
                        continue;
                    _spawnedSpawnable[_spawnedSpawnableLocation[r][t]].DrawBot(rw);
                }
            }
        }

        public void DrawSpawnFringe(RenderWindow rw)
        {
            for (int r = Logic.CurrentParty.MainParty.MyParty[0].Y + _minY - Program.VisibleMaxY / 2 - 3; r < Logic.CurrentParty.MainParty.MyParty[0].Y + _minY + Program.VisibleMaxY / 2 + 3; r++)
            {
                for (int t = Logic.CurrentParty.MainParty.MyParty[0].X + _minX - Program.VisibleMaxX / 2 - 3; t < Logic.CurrentParty.MainParty.MyParty[0].X + _minX + Program.VisibleMaxX / 2 + 3; t++)
                {
                    if (_spawnedSpawnableLocation[r][t] == -1)
                        continue;
                    _spawnedSpawnable[_spawnedSpawnableLocation[r][t]].DrawTop(rw);
                }
            }
        }

        public void AddLivingThing(LivingObject p, int x, int y)
        {
            LivingThing.Add(p);
            SpawnedLivingThing[y + MinY][x + MinX].Add(LivingThing.Count - 1);
        }

        public int MinX
        {
            get { return _minX; }
            set { _minX = value; }
        }

        public int MinY
        {
            get { return _minY; }
            set { _minY = value; }
        }

        public int MaxX
        {
            get { return _maxX; }
            set { _maxX = value; }
        }

        public int MaxY
        {
            get { return _maxY; }
            set { _maxY = value; }
        }

        public List<RowTile> Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public List<Terrain> SpawnedTerrain
        {
            get { return _spawnedTerrain; }
            set { _spawnedTerrain = value; }
        }

        public List<SpawnSpawnable> SpawnedSpawnable
        {
            get { return _spawnedSpawnable; }
            set { _spawnedSpawnable = value; }
        }

        public List<List<int>> SpawnedSpawnableLocation
        {
            get { return _spawnedSpawnableLocation; }
            set { _spawnedSpawnableLocation = value; }
        }

        public List<List<List<SpawnItems>>> Drop
        {
            get { return _drop; }
            set { _drop = value; }
        }

        public List<List<List<int>>> SpawnedLivingThing
        {
            get{return _spawnedLivingObjects;}
            set{_spawnedLivingObjects = value;}
        }

        public AttackManager AtkM { get; set; }
        public List<LivingObject> LivingThing { get; set; }
    }
}
