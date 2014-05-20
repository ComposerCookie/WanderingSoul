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
            NullList = new List<int>();
        }

        public List<int> NullList { get; set; }

        public void DrawMap(RenderWindow rw)
        {
            SFML.Graphics.Sprite s;
            for (int r = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY - 26; r < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY + 25; r++)
            {
                for (int t = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX - 34; t < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX + 33; t++)
                {
                    s = new SFML.Graphics.Sprite(Program.Data.MySprites[0].Texture);
                    if (_y[r].Tile[t].ID == -1)
                        continue;
                    s.TextureRect = new IntRect(Program.Data.MyTileData[Program.Data.MyTerrain[_spawnedTerrain[_y[r].Tile[t].ID].Type].Tile].SourceX, Program.Data.MyTileData[Program.Data.MyTerrain[_spawnedTerrain[_y[r].Tile[t].ID].Type].Tile].SourceY, Program.Data.TileSizeX, Program.Data.TileSizeY);
                    s.Position = new Vector2f(t * Program.Data.TileSizeX, r * Program.Data.TileSizeY);
                    rw.Draw(s);

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
            foreach (LivingObject o in Program.Data.MyLivingObject)
            {
                if (o == null)
                    continue;
                if (o.X + _minX < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX + 33 && o.X + _minX > Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX - 34 && o.Y + _minY < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY + 25 && o.Y + _minY > Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY - 26)
                {
                    o.Draw(rw);
                }
            }
        }

        public void DrawSpawnBot(RenderWindow rw)
        {
            for (int r = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY - 26; r < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY + 25; r++)
            {
                for (int t = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX - 34; t < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX + 33; t++)
                {
                    if (_spawnedSpawnableLocation[r][t] == -1)
                        continue;
                    _spawnedSpawnable[_spawnedSpawnableLocation[r][t]].DrawBot(rw);
                }
            }
        }

        public void DrawSpawnFringe(RenderWindow rw)
        {
            for (int r = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY - 26; r < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + _minY + 25; r++)
            {
                for (int t = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX - 34; t < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + _minX + 33; t++)
                {
                    if (_spawnedSpawnableLocation[r][t] == -1)
                        continue;
                    _spawnedSpawnable[_spawnedSpawnableLocation[r][t]].DrawTop(rw);
                }
            }
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
    }
}
