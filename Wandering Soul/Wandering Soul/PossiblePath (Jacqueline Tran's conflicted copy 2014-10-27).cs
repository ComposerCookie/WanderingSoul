using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class PossiblePath
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<int> Parent { get; set; }

        public PossiblePath(int x, int y)
        {
            X = x;
            Y = y;
            Parent = new List<int>();
        }

        public PossiblePath(int x, int y, List<int> p)
        {
            X = x;
            Y = y;
            Parent = p;
        }


        public bool IsDestination()
        {
            if (Logic.Pathfinder.TargetX == X && Logic.Pathfinder.TargetY == Y)
                return true;
            return false;
        }

        public void FindMore()
        {
            if (IsDestination())
            {
                Logic.PathFound = true;
                Logic.Destination = this;
                return;
            }
            else if (GetTotalCost() > 70)
            {
                Logic.PathFound = true;
                return;
            }

            else
            {
                for (int i = 0; i < 4; i++)
                {
                    List<int> temp = new List<int>();
                    foreach (int n in Parent)
                        temp.Add(n);
                    SpawnBuildable b;
                    switch (i)
                    {
                        case 0:
                            temp.Add(0);
                            if (Logic.OldPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X - 1, Y)))
                            {
                                if (Logic.OldPathFindingSession[new KeyValuePair<int, int>(X - 1, Y)].GetTotalCost() > GetTotalCost() + 1)
                                {
                                    Logic.OldPathFindingSession[new KeyValuePair<int, int>(X - 1, Y)].Parent = temp;
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X - 1, Y), Logic.OldPathFindingSession[new KeyValuePair<int, int>(X - 1, Y)]);
                                    Logic.OldPathFindingSession.Remove(new KeyValuePair<int, int>(X - 1, Y));
                                    break;
                                }
                                else
                                    break;
                            }
                            else
                            {
                                if (Y + Program.MyMap.MinY + 1 > Program.MyMap.MinY + Program.MyMap.MaxY && X + Program.MyMap.MinX + 1 > Program.MyMap.MinX + Program.MyMap.MaxX)
                                    break;
                                if (Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY][X + Program.MyMap.MinX - 1] >= 0 && Logic.GetBlockedBySpawnable(X + Program.MyMap.MinX - 1, Y + Program.MyMap.MinY))
                                {
                                    if (Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY][X + Program.MyMap.MinX - 1]] is SpawnBuildable && Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentAction == 2 && Y == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetY && X - 1 == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY][X + Program.MyMap.MinX - 1]];
                                        if (b.Builded)
                                            break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX - 1].Count > 0)
                                    break;
                                if (Logic.NextPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X - 1, Y)))
                                {
                                    if (Logic.NextPathFindingSession[new KeyValuePair<int, int>(X - 1, Y)].GetTotalCost() > GetTotalCost() + 1)
                                        Logic.NextPathFindingSession[new KeyValuePair<int, int>(X - 1, Y)].Parent = temp;
                                    break;
                                }
                                else
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X - 1, Y), new PossiblePath(X - 1, Y, temp));
                            }
                            break;
                        case 1:
                            temp.Add(1);
                            if (Logic.OldPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X, Y - 1)))
                            {
                                if (Logic.OldPathFindingSession[new KeyValuePair<int, int>(X, Y - 1)].GetTotalCost() > GetTotalCost() + 1)
                                {
                                    Logic.OldPathFindingSession[new KeyValuePair<int, int>(X, Y - 1)].Parent = temp;
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X, Y - 1), Logic.OldPathFindingSession[new KeyValuePair<int, int>(X, Y - 1)]);
                                    Logic.OldPathFindingSession.Remove(new KeyValuePair<int, int>(X, Y - 1));
                                    break;
                                }
                                else
                                    break;
                            }
                            else
                            {
                                if (Y + Program.MyMap.MinY + 1 > Program.MyMap.MinY + Program.MyMap.MaxY && X + Program.MyMap.MinX + 1 > Program.MyMap.MinX + Program.MyMap.MaxX)
                                    break;
                                if (Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY - 1][X + Program.MyMap.MinX] >= 0 && Logic.GetBlockedBySpawnable(X + Program.MyMap.MinX, Y + Program.MyMap.MinY - 1))
                                {
                                    if (Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY - 1][X + Program.MyMap.MinX]] is SpawnBuildable && Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentAction == 2 && Y - 1 == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetY && X == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY - 1][X + Program.MyMap.MinX]];
                                        if (b.Builded)
                                            break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY - 1][X + Program.MyMap.MinX].Count > 0)
                                    break;
                                if (Logic.NextPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X, Y - 1)))
                                {
                                    if (Logic.NextPathFindingSession[new KeyValuePair<int, int>(X, Y - 1)].GetTotalCost() > GetTotalCost() + 1)
                                        Logic.NextPathFindingSession[new KeyValuePair<int, int>(X, Y - 1)].Parent = temp;
                                    break;
                                }
                                else
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X, Y - 1), new PossiblePath(X, Y - 1, temp));
                            }
                            break;
                        case 2:
                            temp.Add(2);
                            if (Logic.OldPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X + 1, Y)))
                            {
                                if (Logic.OldPathFindingSession[new KeyValuePair<int, int>(X + 1, Y)].GetTotalCost() > GetTotalCost() + 1)
                                {
                                    Logic.OldPathFindingSession[new KeyValuePair<int, int>(X + 1, Y)].Parent = temp;
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X + 1, Y), Logic.OldPathFindingSession[new KeyValuePair<int, int>(X + 1, Y)]);
                                    Logic.OldPathFindingSession.Remove(new KeyValuePair<int, int>(X + 1, Y));
                                    break;
                                }
                                else
                                    break;
                            }
                            else
                            {
                                if (Y + Program.MyMap.MinY + 1 > Program.MyMap.MinY + Program.MyMap.MaxY && X + Program.MyMap.MinX + 1 > Program.MyMap.MinX + Program.MyMap.MaxX)
                                    break;
                                if (Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY][X + Program.MyMap.MinX + 1] >= 0 && Logic.GetBlockedBySpawnable(X + Program.MyMap.MinX + 1, Y + Program.MyMap.MinY))
                                {
                                    if (Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY][X + Program.MyMap.MinX + 1]] is SpawnBuildable && Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentAction == 2 && Y == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetY && X + 1== Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY][X + Program.MyMap.MinX + 1]];
                                        if (b.Builded)
                                            break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX + 1].Count > 0)
                                    break;
                                if (Logic.NextPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X + 1, Y)))
                                {
                                    if (Logic.NextPathFindingSession[new KeyValuePair<int, int>(X + 1, Y)].GetTotalCost() > GetTotalCost() + 1)
                                        Logic.NextPathFindingSession[new KeyValuePair<int, int>(X + 1, Y)].Parent = temp;
                                    break;
                                }
                                else
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X + 1, Y), new PossiblePath(X + 1, Y, temp));
                            }
                            break;
                        case 3:
                            temp.Add(3);
                            if (Logic.OldPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X, Y + 1)))
                            {
                                if (Logic.OldPathFindingSession[new KeyValuePair<int, int>(X, Y + 1)].GetTotalCost() > GetTotalCost() + 1)
                                {
                                    Logic.OldPathFindingSession[new KeyValuePair<int, int>(X, Y + 1)].Parent = temp;
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X, Y + 1), Logic.OldPathFindingSession[new KeyValuePair<int, int>(X, Y + 1)]);
                                    Logic.OldPathFindingSession.Remove(new KeyValuePair<int, int>(X, Y + 1));
                                    break;
                                }
                                else
                                    break;
                            }
                            else
                            {
                                if (Y + Program.MyMap.MinY + 1 > Program.MyMap.MinY + Program.MyMap.MaxY && X + Program.MyMap.MinX + 1 > Program.MyMap.MinX + Program.MyMap.MaxX)
                                    break;
                                if (Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY + 1][X + Program.MyMap.MinX] >= 0 && Logic.GetBlockedBySpawnable(X + Program.MyMap.MinX, Y + Program.MyMap.MinY + 1))
                                {
                                    if (Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY + 1][X + Program.MyMap.MinX]] is SpawnBuildable && Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentAction == 2 && Y + 1 == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetY && X == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[Y + Program.MyMap.MinY + 1][X + Program.MyMap.MinX]];
                                        if (b.Builded)
                                            break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY + 1][X + Program.MyMap.MinX].Count > 0)
                                    break;
                                if (Logic.NextPathFindingSession.ContainsKey(new KeyValuePair<int, int>(X, Y + 1)))
                                {
                                    if (Logic.NextPathFindingSession[new KeyValuePair<int, int>(X, Y + 1)].GetTotalCost() > GetTotalCost() + 1)
                                        Logic.NextPathFindingSession[new KeyValuePair<int, int>(X, Y + 1)].Parent = temp;
                                    break;
                                }
                                else
                                    Logic.NextPathFindingSession.Add(new KeyValuePair<int, int>(X, Y + 1), new PossiblePath(X, Y + 1, temp));
                            }
                            break;

                    }
                }
            }
        }

        public int GetTotalCost()
        {
            return Parent.Count;
        }
    }
}
