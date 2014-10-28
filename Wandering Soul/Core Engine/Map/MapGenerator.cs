using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

/*
 Dir 0 = Left
 * Dir 1 = Top
 * Dir 2 = Right
 * Dir 3 = Bottom
 */

namespace Lost_Soul
{
    public class MapGenerator
    {
        Random r;

        public MapGenerator()
        {
            r = new Random();
        }

        public MainMap NewMap()
        {
            MainMap m = new MainMap();
            RandomTerrain(m, 0, 0);

            SpawnRight(m);

            for (int i = 0; i < 100; i++)
            {
                SpawnBottom(m);
                SpawnRight(m);
                SpawnTop(m);
                SpawnLeft(m);
            }

            if (Program.Log != null)
                Program.Log.AddMessage((int)InGameLogMessageType.System, "The main map was regenerated");

            //Logic.MainMap = m;

            return m;
            
        }

        public int RandomSize()
        {
            return r.Next(0, (int)TerrainSizeEnum.TSizeCount - 1);
            //return 0;
        }

        public int RandomType()
        {
            return r.Next(0, (int)TerrainTypeEnum.TTypeCount);
        }

        public void RandomTerrain(Map m,int x, int y)
        {
            Terrain t = new Terrain(RandomSize(), RandomType(), x, y);
            m.SpawnedTerrain.Add(t);
        }

        public Tile SpawnTileBasedOnTerrain(int id, int x, int y)
        {
            Tile t = new Tile(id, x, y);
            return t;
        }

        public bool CheckListSameTerrain(List<Tile> list)
        {
            bool same = true;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID != list[0].ID)
                    same = false;
            }
            return same;
        }

        public bool IsSurrounded(Map m, int x, int y)
        {
            return false;
        }

        public List<int> MaxParameter(Map m, int x, int y)
        {
            List<int> Parameter = new List<int>();
            
            return Parameter;
        }

        public int GetHighestPriorityTile(Map m, List<Tile> list)
        {
            int highest = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (Program.Data.MyTerrain[m.SpawnedTerrain[list[i].ID].Type].Priority > Program.Data.MyTerrain[m.SpawnedTerrain[list[highest].ID].Type].Priority)
                    highest = i;
            }
            return highest;
        }

        public List<Tile> OptimizeList(List<Tile> l, Map m)
        {
            List<Tile> list = new List<Tile>();
            List<KeyValuePair<int, double>> toSort = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < l.Count; i++)
            {
                double d = (double)m.SpawnedTerrain[l[i].ID].Spawned / (double)Logic.GetMaxTileBasedOnSize(m.SpawnedTerrain[l[i].ID].Size);
                toSort.Add(new KeyValuePair<int, double>(i, d));
            }
            toSort = SortTileBasedOnSize(toSort);
            for (int i = 0; i < l.Count; i++)
            {
                list.Add(l[toSort[i].Key]);
            }
            
            return list;
        }

        public List<Tile> ReevaluatePriorityDueToNewTerrain(Map m, List<Tile> oldList, int x, int y, int dir)
        {
            List<Tile> newList = new List<Tile>();
            List<KeyValuePair<int, int>> toSort = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < oldList.Count; i++)
            {
                int abs = 0;
                if (dir == 0)
                {
                    abs = Math.Abs(y + oldList[i].Y + m.MinY);
                }
                else if (dir == 1)
                {
                    abs = Math.Abs(x + oldList[i].X + m.MinX);
                }
                else if (dir == 2)
                {
                    abs = Math.Abs(y - oldList[i].Y + m.MinY);
                }
                else if (dir == 3)
                {
                    abs = Math.Abs(x - oldList[i].X + m.MinX);
                }
                toSort.Add(new KeyValuePair<int, int>(i, abs));
            }
            toSort = SortTileBasedOnRelativePosition(toSort);
            for (int i = 0; i < oldList.Count; i++)
            {
                newList.Add(oldList[toSort[i].Key]);
            }
            return newList;
        }

        public List<KeyValuePair<int, int>> SortTileBasedOnRelativePosition(List<KeyValuePair<int, int>> a)
        {
            if (a.Count < 2)
            {
                return a;
            }
            int middle = a.Count / 2;
            List<KeyValuePair<int, int>> left = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < middle; i++)
            {
                left.Add(a[i]);
            }
            List<KeyValuePair<int, int>> right = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < a.Count - middle; i++)
            {
                right.Add(a[i + middle]);
            }
            left = SortTileBasedOnRelativePosition(left);
            right = SortTileBasedOnRelativePosition(right);

            int leftptr = 0;
            int rightptr = 0;

            List<KeyValuePair<int, int>> sorted = new List<KeyValuePair<int, int>>();
            for (int k = 0; k < a.Count; k++)
            {
                sorted.Add(new KeyValuePair<int, int>(0, 0));
            }
            for (int k = 0; k < a.Count; k++)
            {
                if (rightptr == right.Count || ((leftptr < left.Count) && (left[leftptr].Value <= right[rightptr].Value)))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Count || ((rightptr < right.Count) && (right[rightptr].Value <= left[leftptr].Value)))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;
        }

        public List<KeyValuePair<int, double>> SortTileBasedOnSize(List<KeyValuePair<int, double>> a)
        {
            if (a.Count < 2)
            {
                return a;
            }
            int middle = a.Count / 2;
            List<KeyValuePair<int, double>> left = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < middle; i++)
            {
                left.Add(a[i]);
            }
            List<KeyValuePair<int, double>> right = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < a.Count - middle; i++)
            {
                right.Add(a[i + middle]);
            }
            left = SortTileBasedOnSize(left);
            right = SortTileBasedOnSize(right);

            int leftptr = 0;
            int rightptr = 0;

            List<KeyValuePair<int, double>> sorted = new List<KeyValuePair<int, double>>();
            for (int k = 0; k < a.Count; k++)
            {
                sorted.Add(new KeyValuePair<int, double>(0, 0));
            }
            for (int k = 0; k < a.Count; k++)
            {
                if (rightptr == right.Count || ((leftptr < left.Count) && (left[leftptr].Value <= right[rightptr].Value)))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Count || ((rightptr < right.Count) && (right[rightptr].Value <= left[leftptr].Value)))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;
        }

        public bool HorVerLimitor(Map m, int dir, int _id)
        {
            if (dir == 0 || dir == 2)
            {
                if (m.SpawnedTerrain[_id].MaxHorizontal - m.SpawnedTerrain[_id].MinHorizontal <= (int)Math.Sqrt(Logic.GetMaxTileBasedOnSize(m.SpawnedTerrain[_id].Size)))
                    return true;
                else if (m.SpawnedTerrain[_id].MaxHorizontal - m.SpawnedTerrain[_id].MinHorizontal >= Logic.GetMaxHorizontalBasedOnSize(m.SpawnedTerrain[_id].Size))
                {
                    return WillSpawn(1, 2);
                }
            }
            else if (dir == 1 || dir == 3)
            {
                if (m.SpawnedTerrain[_id].MaxVertical - m.SpawnedTerrain[_id].MinVertical <= (int)Math.Sqrt(Logic.GetMaxTileBasedOnSize(m.SpawnedTerrain[_id].Size)))
                    return true;
                if (m.SpawnedTerrain[_id].MaxVertical - m.SpawnedTerrain[_id].MinVertical >= Logic.GetMaxVerticleBasedOnSize(m.SpawnedTerrain[_id].Size))
                    return WillSpawn(1, 2);
            }
            return true;
        }

        public void RandomTile(Map m, int dir, List<Tile> l)
        {
            List<Tile> Around = new List<Tile>();
            Tile ti = new Tile(0, 0, 0);
            List<Tile> Reverse = new List<Tile>();
            for (int i = 0; i < l.Count; i++)
            {
                Reverse.Add(l[l.Count - 1 - i]);
            }
            outerloop:
            for (int i = Reverse.Count - 1; i > -1; i--)
            {

                int tx = Reverse[i].X;
                int ty = Reverse[i].Y;

                if (dir == 0)
                {
                    tx = Reverse[i].X - 1;
                    if (m.MinX == 0)
                        Reverse[i].X = 0 - Reverse[i].X;
                }
                else if (dir == 1)
                {
                    ty = Reverse[i].Y - 1;
                    if (m.MinY == 0)
                        Reverse[i].Y = 0 - Reverse[i].Y;
                }
                else if (dir == 2)
                {
                    tx = Reverse[i].X + 1;
                }
                else if (dir == 3)
                {
                    ty = Reverse[i].Y + 1;
                }

                Around = AroundATile(m, tx, ty, dir);
                Around = OptimizeList(Around, m);

                bool Generated = false;

                if (Around.Count == 0)
                {
                    if (TileSpawned(m, Reverse[i].X, Reverse[i].Y, tx, ty, dir))
                    {
                        Reverse.RemoveAt(i);
                        Generated = true;
                        goto outerloop;
                    }
                    else
                        goto falseloop;
                }
                else
                {
                    for (int a = 0; a < Around.Count; a++)
                    {
                        if (TileSpawned(m, Around[a].X, Around[a].Y, tx, ty, dir))
                        {
                            Reverse.RemoveAt(i);
                            Generated = true;
                            goto outerloop;
                        }
                    }
                    goto falseloop;
                }
            falseloop:
                if (!Generated)
                {
                    int bonusx = 0;
                    int bonusy = 0;
                    if (dir == 0)
                        bonusx = 1;
                    //    tx++;
                    if (dir == 1)
                        bonusy = 1;
                    //    ty++;

                    RandomTerrain(m, tx, ty);                

                    m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx] = new Tile(m.SpawnedTerrain.Count - 1, tx, ty);
                    //if (m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MaxVertical < ty + m.MinY)
                        m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MaxVertical = ty + m.MinY;
                    //if (m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MinVertical > ty + m.MinY)
                        m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MinVertical = ty + m.MinY;
                    //if (m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MaxHorizontal < tx + m.MinX)
                        m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MaxHorizontal = tx + m.MinX;
                    //if (m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MinHorizontal > tx + m.MinX)
                        m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].MinHorizontal = tx + m.MinX;
                    Reverse.RemoveAt(i);
                    Reverse = ReevaluatePriorityDueToNewTerrain(m, Reverse, tx + m.MinX, ty + m.MinY, dir);

                    if (Program.Data.MyTileData[Program.Data.MyTerrain[m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].Type].Tile].Variation.Count > 0)
                    {
                        if (WillSpawn(1, 20))
                        {
                            m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].Variation = r.Next(0, Program.Data.MyTileData[Program.Data.MyTerrain[m.SpawnedTerrain[m.Y[ty + m.MinY + bonusy].Tile[tx + m.MinX + bonusx].ID].Type].Tile].Variation.Count - 1);
                        }
                    }

                    goto outerloop;
                }
            }
        }

        public bool TileSpawned(Map m, int x, int y, int x2, int y2, int dir)
        {
            int tempX = x + m.MinX;
            int tempY = y + m.MinY;
            int tempX2 = x2 + m.MinX;
            int tempY2 = y2 + m.MinY;
            if (dir == 0)
            {
                tempX++;
                tempX2++;
            }
            if (dir == 1)
            {
                tempY++;
                tempY2++;
            }
            if (!HorVerLimitor(m, dir, m.Y[tempY].Tile[tempX].ID))
            {
                return false;
            }
            if (m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Spawned * 100 / Logic.GetMaxTileBasedOnSize(m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Size) < 87)
            {
                m.Y[tempY2].Tile[tempX2] = new Tile(m.Y[tempY].Tile[tempX].ID, x2, y2);
                m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Spawned++;
                if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxVertical < tempY2)
                    m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxVertical = tempY2;
                if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinVertical > tempY2)
                    m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinVertical = tempY2;
                if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxHorizontal < tempX2)
                    m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxHorizontal = tempX2;
                if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinHorizontal > tempX2)
                    m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinHorizontal = tempX2;

                if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].Type == (int)TerrainTypeEnum.Forest)
                {
                    if (WillSpawn(2, 10))
                    {
                        if (m.NullList.Count == 0)
                        {
                            m.SpawnedSpawnable.Add(new SpawnResource(0, x2, y2));
                            m.SpawnedSpawnableLocation[tempY2][tempX2] = m.SpawnedSpawnable.Count - 1;
                        }
                        else
                        {
                            m.SpawnedSpawnable[m.NullList[0]] = new SpawnResource(0, x2, y2);
                            m.SpawnedSpawnableLocation[tempY2][tempX2] = m.NullList[0];
                            m.NullList.RemoveAt(0);
                        }
                    }
                }

                if (Program.Data.MyTileData[Program.Data.MyTerrain[m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].Type].Tile].Variation.Count > 0)
                {
                    if (WillSpawn(1, 20))
                    {
                        m.Y[tempY2].Tile[tempX2].Variation = r.Next(0, Program.Data.MyTileData[Program.Data.MyTerrain[m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].Type].Tile].Variation.Count - 1);
                    }
                }

                return true;
            }
            else
            {
                if (WillSpawn(Logic.GetMaxTileBasedOnSize(m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Size) - m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Spawned, Logic.GetMaxTileBasedOnSize(m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Size) - m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Spawned + 1))
                {
                    m.Y[tempY2].Tile[tempX2] = new Tile(m.Y[tempY].Tile[tempX].ID, x2, y2);
                    m.SpawnedTerrain[m.Y[tempY].Tile[tempX].ID].Spawned++;
                    if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxVertical < tempY2)
                        m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxVertical = tempY2;
                    if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinVertical > tempY2)
                        m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinVertical = tempY2;
                    if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxHorizontal < tempX2)
                        m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MaxHorizontal = tempX2;
                    if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinHorizontal > tempX2)
                        m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].MinHorizontal = tempX2;

                    if (m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].Type == (int)TerrainTypeEnum.Forest)
                    {
                        if (WillSpawn(2, 10))
                        {
                            if (m.NullList.Count == 0)
                            {
                                m.SpawnedSpawnable.Add(new SpawnResource(0, x2, y2));
                                m.SpawnedSpawnableLocation[tempY2][tempX2] = m.SpawnedSpawnable.Count - 1;
                            }
                            else
                            {
                                m.SpawnedSpawnable[m.NullList[0]] = new SpawnResource(0, x2, y2);
                                m.SpawnedSpawnableLocation[tempY2][tempX2] = m.NullList[0];
                                m.NullList.RemoveAt(0);
                            }
                        }
                    }

                    if (Program.Data.MyTileData[Program.Data.MyTerrain[m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].Type].Tile].Variation.Count > 0)
                    {
                        if (WillSpawn(1, 20))
                        {
                            m.Y[tempY2].Tile[tempX2].Variation = r.Next(0, Program.Data.MyTileData[Program.Data.MyTerrain[m.SpawnedTerrain[m.Y[tempY2].Tile[tempX2].ID].Type].Tile].Variation.Count - 1);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public bool WillSpawn(int num, int de)
        {
            if (de < 0)
                return false;

            return r.Next(0, de) <= num ? true : false;
        }

        public List<Tile> AroundATile(Map m, int x, int y, int dir)
        {
            List<Tile> myList = new List<Tile>();

            //if (x > m.MaxX + m.MinX || y > m.MaxY + m.MinY || x < 0 || y < 0)
            //    return myList;
            x += m.MinX;
            y += m.MinY;

            if (dir == 0)
            {
                x++;
            }
            if (dir == 1)
            {
                y++;
            }

            bool SubtractX = (x - 1 >= 0) ? true : false;
            bool SubtractY = (y - 1 >= 0) ? true : false;
            bool PlusX = (x + 1 < m.Y[0].Tile.Count) ? true : false;
            bool PlusY = (y + 1 < m.Y.Count) ? true : false;

            if (SubtractX)
                myList.Add(m.Y[y].Tile[x - 1]);
            if (SubtractY)
                myList.Add(m.Y[y - 1].Tile[x]);
            if (PlusX)
                myList.Add(m.Y[y].Tile[x + 1]);
            if (PlusY)
                myList.Add(m.Y[y + 1].Tile[x]);

            for (int i = myList.Count - 1; i > -1; i--)
            {
                if (myList[i].ID == -1)
                    myList.RemoveAt(i);
            }

            return myList;
        }

        public void SpawnTop(Map m)
        {
            if (m.MinY == -1)
            {
                SpawnBottom(m);
            }
            else
            {
                m.Y.Insert(0, new RowTile());
                m.SpawnedSpawnableLocation.Insert(0, new List<int>());
                m.Drop.Insert(0, new List<List<SpawnItems>>());
                m.SpawnedLivingThing.Insert(0, new List<List<int>>());
                for (int i = 0; i < m.Y[1].Tile.Count; i++)
                {
                    m.Y[0].Tile.Add(new Tile(-1, i - m.MinX, m.MinY + 1));
                    m.SpawnedSpawnableLocation[0].Add(-1);
                    m.Drop[0].Add(new List<SpawnItems>());
                    m.SpawnedLivingThing[0].Add(new List<int>());
                    //m.Y[m.MaxY + 1].Tile[m.Y[m.MaxY + 1].Tile.Count - 1] = RandomTile(m, i, m.MaxY);
                }

                List<Tile> _toOptimize = new List<Tile>();
                for (int i = 0; i < m.Y[1].Tile.Count; i++)
                {
                    _toOptimize.Add(m.Y[1].Tile[i]);
                }
                OptimizeList(_toOptimize, m);
                RandomTile(m, 1, _toOptimize);
                m.MinY++;
            }

            if (m.MaxX == -1)
            {
                m.MaxX = 0;
            }

            if (m.MinX == -1)
            {
                m.MinX = 0;
            }

            if (m.MaxY == -1)
            {
                m.MaxY = 0;
            }
        }

        public void SpawnLeft(Map m)
        {
            if (m.MinX == -1)
            {
                SpawnBottom(m);
            }

            else
            {
                for (int i = 0; i < m.Y.Count; i++)
                {
                    m.Y[i].Tile.Insert(0, new Tile(-1, m.MinX + 1, i - m.MinY));
                    m.SpawnedSpawnableLocation[i].Insert(0, -1);
                    m.Drop[i].Insert(0 ,new List<SpawnItems>());
                    m.SpawnedLivingThing[i].Insert(0, new List<int>());
                    //m.Y[i].Tile[m.Y[i].Tile.Count - 1] = RandomTile(m, m.MaxX, i);
                }

                List<Tile> _toOptimize = new List<Tile>();

                for (int i = 0; i < m.Y.Count; i++)
                {
                    _toOptimize.Add(m.Y[i].Tile[1]);
                }
                _toOptimize = OptimizeList(_toOptimize, m);
                RandomTile(m, 0, _toOptimize);
                m.MinX++;
            }
        }

        public void SpawnBottom(Map m)
        {
            m.Y.Add(new RowTile());
            m.SpawnedSpawnableLocation.Add(new List<int>());
            m.Drop.Add(new List<List<SpawnItems>>());
            m.SpawnedLivingThing.Add(new List<List<int>>());

            if (m.MaxY == -1)
            {
                m.Y[m.Y.Count - 1].Tile.Add(new Tile(0, m.MaxX + 1, m.MaxY + 1));
                m.SpawnedSpawnableLocation[m.Y.Count - 1].Add(-1);
                m.SpawnedLivingThing[m.Y.Count - 1].Add(new List<int>());
                m.Drop[m.Y.Count - 1].Add(new List<SpawnItems>());
                m.MaxY = 0;
            }

            else
            {
                for (int i = 0; i < m.Y[0].Tile.Count; i++)
                {
                    m.Y[m.Y.Count - 1].Tile.Add(new Tile(-1, i - m.MinX, m.MaxY + 1));
                    m.SpawnedSpawnableLocation[m.Y.Count - 1].Add(-1);
                    m.SpawnedLivingThing[m.Y.Count - 1].Add(new List<int>());
                    m.Drop[m.Y.Count - 1].Add(new List<SpawnItems>());
                    //m.Y[m.MaxY + 1].Tile[m.Y[m.MaxY + 1].Tile.Count - 1] = RandomTile(m, i, m.MaxY);
                }

                List<Tile> _toOptimize = new List<Tile>();

                for (int i = 0; i < m.Y[0].Tile.Count; i++)
                {
                    _toOptimize.Add(m.Y[m.Y.Count - 2].Tile[i]);
                }
                OptimizeList(_toOptimize, m);
                RandomTile(m, 3,_toOptimize);
                m.MaxY++;
            }

            if (m.MaxX == -1)
            {
                m.MaxX = 0;
            }

            if (m.MinX == -1)
            {
                m.MinX = 0;
            }

            if (m.MinY == -1)
            {
                m.MinY = 0;
            }
        }

        public void SpawnRight(Map m)
        {
            if (m.MaxX == -1)
            {
                SpawnBottom(m);
            }

            else
            {
                for (int i = 0; i < m.Y.Count; i++)
                {
                    m.Y[i].Tile.Add(new Tile(-1, m.MaxX + 1 ,i - m.MinY));
                    m.SpawnedSpawnableLocation[i].Add(-1);
                    m.SpawnedLivingThing[i].Add(new List<int>());
                    m.Drop[i].Add(new List<SpawnItems>());
                    //m.Y[i].Tile[m.Y[i].Tile.Count - 1] = RandomTile(m, m.MaxX, i);
                }

                List<Tile> _toOptimize = new List<Tile>();

                for (int i = 0; i < m.Y.Count; i++)
                {
                    _toOptimize.Add(m.Y[i].Tile[m.Y[i].Tile.Count - 2]);
                }
                _toOptimize = OptimizeList(_toOptimize, m);
                RandomTile(m, 2, _toOptimize);
                m.MaxX++;
            }
        }
    }
}
