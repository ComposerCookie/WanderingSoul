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
                                if (Y + Logic.Pathfinder.CurMap.MinY + 1 > Logic.Pathfinder.CurMap.MinY + Logic.Pathfinder.CurMap.MaxY && X + Logic.Pathfinder.CurMap.MinX + 1 > Logic.Pathfinder.CurMap.MinX + Logic.Pathfinder.CurMap.MaxX)
                                    break;
                                if (Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX - 1] >= 0 && Logic.GetBlockedBySpawnable(X + Logic.Pathfinder.CurMap.MinX - 1, Y + Logic.Pathfinder.CurMap.MinY, Logic.Pathfinder.CurMap, 0))
                                {
                                    if (Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX - 1]] is SpawnBuildable && Logic.Pathfinder == Logic.CurrentParty.MainParty.MyParty[0] && (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 2 || Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4) && Y == Logic.CurrentParty.MainParty.MyParty[0].TargetY && X - 1 == Logic.CurrentParty.MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX - 1]];
                                        if (b.Builded)
                                        {
                                            if (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4)
                                            {
                                            }
                                            else
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Logic.Pathfinder.CurMap.SpawnedLivingThing[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX - 1].Count > 0)
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
                                if (Y + Logic.Pathfinder.CurMap.MinY + 1 > Logic.Pathfinder.CurMap.MinY + Logic.Pathfinder.CurMap.MaxY && X + Logic.Pathfinder.CurMap.MinX + 1 > Logic.Pathfinder.CurMap.MinX + Logic.Pathfinder.CurMap.MaxX)
                                    break;
                                if (Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY - 1][X + Logic.Pathfinder.CurMap.MinX] >= 0 && Logic.GetBlockedBySpawnable(X + Logic.Pathfinder.CurMap.MinX, Y + Logic.Pathfinder.CurMap.MinY - 1, Logic.Pathfinder.CurMap, 0))
                                {
                                    if (Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY - 1][X + Logic.Pathfinder.CurMap.MinX]] is SpawnBuildable && Logic.Pathfinder == Logic.CurrentParty.MainParty.MyParty[0] && (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 2 || Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4) && Y - 1 == Logic.CurrentParty.MainParty.MyParty[0].TargetY && X == Logic.CurrentParty.MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY - 1][X + Logic.Pathfinder.CurMap.MinX]];
                                        if (b.Builded)
                                        {
                                            if (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4)
                                            {
                                            }
                                            else
                                                break;
                                        }
                                        
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Logic.Pathfinder.CurMap.SpawnedLivingThing[Y + Logic.Pathfinder.CurMap.MinY - 1][X + Logic.Pathfinder.CurMap.MinX].Count > 0)
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
                                if (Y + Logic.Pathfinder.CurMap.MinY + 1 > Logic.Pathfinder.CurMap.MinY + Logic.Pathfinder.CurMap.MaxY && X + Logic.Pathfinder.CurMap.MinX + 1 > Logic.Pathfinder.CurMap.MinX + Logic.Pathfinder.CurMap.MaxX)
                                    break;
                                if (Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX + 1] >= 0 && Logic.GetBlockedBySpawnable(X + Logic.Pathfinder.CurMap.MinX + 1, Y + Logic.Pathfinder.CurMap.MinY, Logic.Pathfinder.CurMap, 0))
                                {
                                    if (Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX + 1]] is SpawnBuildable && Logic.Pathfinder == Logic.CurrentParty.MainParty.MyParty[0] && (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 2 || Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4) && Y == Logic.CurrentParty.MainParty.MyParty[0].TargetY && X + 1 == Logic.CurrentParty.MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX + 1]];
                                        if (b.Builded)
                                        {
                                            if (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4)
                                            {
                                            }
                                            else
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Logic.Pathfinder.CurMap.SpawnedLivingThing[Y + Logic.Pathfinder.CurMap.MinY][X + Logic.Pathfinder.CurMap.MinX + 1].Count > 0)
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
                                if (Y + Logic.Pathfinder.CurMap.MinY + 1 > Logic.Pathfinder.CurMap.MinY + Logic.Pathfinder.CurMap.MaxY && X + Logic.Pathfinder.CurMap.MinX + 1 > Logic.Pathfinder.CurMap.MinX + Logic.Pathfinder.CurMap.MaxX)
                                    break;
                                if (Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY + 1][X + Logic.Pathfinder.CurMap.MinX] >= 0 && Logic.GetBlockedBySpawnable(X + Logic.Pathfinder.CurMap.MinX, Y + Logic.Pathfinder.CurMap.MinY + 1, Logic.Pathfinder.CurMap, 0))
                                {
                                    if (Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY + 1][X + Logic.Pathfinder.CurMap.MinX]] is SpawnBuildable && Logic.Pathfinder == Logic.CurrentParty.MainParty.MyParty[0] && (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 2 || Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4) && Y + 1 == Logic.CurrentParty.MainParty.MyParty[0].TargetY && X == Logic.CurrentParty.MainParty.MyParty[0].TargetX)
                                    {
                                        b = (SpawnBuildable)Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[Y + Logic.Pathfinder.CurMap.MinY + 1][X + Logic.Pathfinder.CurMap.MinX]];
                                        if (b.Builded)
                                        {
                                            if (Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4)
                                            {
                                            }
                                            else
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (Logic.Pathfinder.CurMap.SpawnedLivingThing[Y + Logic.Pathfinder.CurMap.MinY + 1][X + Logic.Pathfinder.CurMap.MinX].Count > 0)
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
