using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using System.Threading;

namespace Lost_Soul
{
    public class Logic
    {
        static public Random r = new Random();
        static public int GeneratorNumerator(int spawned, int size)
        {
            int num = 0;
            if (spawned == 0)
            {
                num = GetMaxTileBasedOnSize(size);
            }
            else if (spawned == GetMaxTileBasedOnSize(size))
            {
                num = 1;
            }
            else
            {
                num = GetMaxTileBasedOnSize(size) - spawned;
            }
            return num;
        }

        static public int GeneratorDenumerator(int spawned, int size)
        {
            int den = 0;
            if (spawned == 0)
            {
                den = GetMaxTileBasedOnSize(size);
            }
            else if (spawned == GetMaxTileBasedOnSize(size))
            {
                den = 2;
            }
            else
            {
                den = GetMaxTileBasedOnSize(size) - spawned + 1;
            }
            return den;
        }

        static public int GetMaxTileBasedOnSize(int size)
        {
            int _size = 0;
            switch (size)
            {
                case 0:
                    _size = 9;
                    break;
                case 1:
                    _size = 36;
                    break;
                case 2:
                    _size = 576;
                    break;
                case 3:
                    _size = 1600;
                    break;
                case 4:
                    _size = 3600;
                    break;
                case 5:
                    _size = 10000;
                    break;
            }
            return _size;
        }

        static public int GetMaxVerticleBasedOnSize(int size)
        {
            int _vert = 0;
            switch (size)
            {
                case 0:
                    _vert = 5;
                    break;
                case 1:
                    _vert = 8;
                    break;
                case 2:
                    _vert = 30;
                    break;
                case 3:
                    _vert = 50;
                    break;
                case 4:
                    _vert = 80;
                    break;
                case 5:
                    _vert = 120;
                    break;
            }
            return _vert;
        }

        static public int GetMaxHorizontalBasedOnSize(int size)
        {
            int _hor = 0;
            switch (size)
            {
                case 0:
                    _hor = 4;
                    break;
                case 1:
                    _hor = 8;
                    break;
                case 2:
                    _hor = 30;
                    break;
                case 3:
                    _hor = 50;
                    break;
                case 4:
                    _hor = 80;
                    break;
                case 5:
                    _hor = 120;
                    break;
            }
            return _hor;
        }

        static public bool BlockedAt(int x, int y)
        {
            if (GetBlockedByLivingThing(x, y) || GetBlockedBySpawnable(x, y) || GetBlockedByTerrain(x, y))
            {
                return true;
            }
            return false;
        }
        
        static public bool GetBlockedByTerrain(int x, int y)
        {
            if (Program.Data.MyTerrain[Program.MyMap.SpawnedTerrain[Program.MyMap.Y[y].Tile[x].ID].Type].Blocked == 1)
                return true;
            return false;
        }

        static public bool GetBlockedBySpawnable(int x, int y)
        {
            if (Program.MyMap.SpawnedSpawnableLocation[y][x] == -1)
                return false;
            if (Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[y][x]] is SpawnResource)
            {
                if (Program.Data.GetResourceList()[Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[y][x]].ID].Blocked == 1)
                    return true;
            }
            else if (Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[y][x]] is SpawnBuildable)
            {
                if (Program.Data.GetBuildableList()[Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[y][x]].ID].Blocked == 1)
                    return true;
            }
            
            return false;
        }

        static public bool GetBlockedByLivingThing(int x, int y)
        {
            if (Program.MyMap.SpawnedLivingThing[y][x].Count > 0)
                return true;
            return false;
        }

        static public void AttackLivingObject(LivingObject attacker, LivingObject receiver)
        {
            if (receiver is Hostile && attacker is NPC)
            {
                receiver.CurrentHealth--;
                if (receiver.CurrentHealth == 0)
                {
                    Program.MyMap.SpawnedLivingThing[receiver.Y + Program.MyMap.MinY][receiver.X + Program.MyMap.MinX].RemoveAt(Program.MyMap.SpawnedLivingThing[receiver.Y + Program.MyMap.MinY][receiver.X + Program.MyMap.MinX].Count - 1);
                    Program.Data.MyLivingObject[receiver.Index] = null;
                }

                Program.Log.AddMessage((int)InGameLogMessageType.BadCombat, attacker.Name + " attacked " + receiver.Name);
            }
        }

        static public void AttackSpawnable(LivingObject attacker, SpawnSpawnable _object)
        {
            if (_object is SpawnBuildable)
            {
                if (attacker is NPC)
                {
                    NPC n = (NPC)attacker;
                    Buildable r = (Buildable)Program.Data.GetBuildableList()[_object.ID];
                    //if (n.Equipment[11] != null && Program.Data.MyItems[n.Equipment[11].ID] is ToolItem)
                    //{
                        _object.CurHealth--;
                        if (_object.CurHealth == 0)
                        {
                            //for (int i = 0; i < r.Give.Count; i++)
                            //{
                            //    Program.MyMap.Drop[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX].Add(r.Give[i]);
                            //}
                            Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX]] = null;
                            Program.MyMap.NullList.Add(Program.MyMap.SpawnedSpawnableLocation[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX]);
                            Program.MyMap.SpawnedSpawnableLocation[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX] = -1;
                        }
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, attacker.Name + " attacked " + Program.Data.GetBuildableList()[_object.ID].Name);
                    //}
                    //else
                    //    Program.Log.AddMessage((int)InGameLogMessageType.Notification, attacker.Name + " don't have the necessary tool to harvest this");
                }
            }

            else if (_object is SpawnResource)
            {
                if (attacker is NPC)
                {
                    NPC n = (NPC)attacker;
                    Resource r = (Resource)Program.Data.GetResourceList()[_object.ID];
                    if (n.Equipment[11] != null && Program.Data.MyItems[n.Equipment[11].ID] is ToolItem)
                    {
                        _object.CurHealth--;
                        if (_object.CurHealth == 0)
                        {
                            for (int i = 0; i < r.Give.Count; i++)
                            {
                                Program.MyMap.Drop[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX].Add(r.Give[i]);
                            }
                            Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX]] = null;
                            Program.MyMap.NullList.Add(Program.MyMap.SpawnedSpawnableLocation[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX]);
                            Program.MyMap.SpawnedSpawnableLocation[_object.Y + Program.MyMap.MinY][_object.X + Program.MyMap.MinX] = -1;
                        }
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, attacker.Name + " tried to harvest " + Program.Data.GetResourceList()[_object.ID].Name);
                    }
                    else
                        Program.Log.AddMessage((int)InGameLogMessageType.Notification, attacker.Name + " don't have the necessary tool to harvest this");
                }
            }
        }

        static public int RandomNumber(int start, int end)
        {
            return r.Next(start, end);
        }

        static public int RequiredExperienceForNextLevel(int curLevel)
        {
            if (curLevel == 1)
            {
                return 10;
            }

            return (int)((1.5 + (curLevel * .25) ) + RequiredExperienceForNextLevel(curLevel - 1));
        }

        static public List<int> KnownBluePrintForThisCharacter(LivingObject p)
        {
            List<int> KnowRecipe = new List<int>();
            KnowRecipe.Add(0);
            return KnowRecipe;
        }

        static public List<int> KnownBluePrintForThisCharacter(LivingObject p, int cla)
        {
            List<int> KnowRecipe = new List<int>();
            KnowRecipe.Add(0);
            return KnowRecipe;
        }

        static public void CreateMessageOnScreen(string msg, uint size, Color c, int x, int y)
        {
            Text t = new Text(msg, Program.Data.Font, size);
            t.Color = c;
            t.Position = new Vector2f(x, y);
            Program.RW.Draw(t);
        }

        static public void BuildStuff(int x, int y, int id, RenderWindow rw)
        {
            bool buildable = true;
            for (int r = y; r < y + Program.Data.GetBuildableList()[id].SizeY; r++)
            {
                for (int c = x; c < x + Program.Data.GetBuildableList()[id].SizeX; c++)
                {
                    if (GetBlockedByLivingThing(c, r) || GetBlockedBySpawnable(c, r) || GetBlockedByTerrain(c, r))
                    {
                        buildable = false;
                        break;
                    }
                }
            }

            if (buildable)
            {
                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetX = (int)Mouse.GetPosition(rw).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)rw.Size.X / 2 / 16 - 1;
                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetY = (int)(Mouse.GetPosition(rw).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)rw.Size.Y / 2 / 16 - 1;
                DoPathFinding(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0]);
                if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].PathfindingPath.Count < 1)
                    return;
                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].ActionDir = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].PathfindingPath[0];
                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].PathfindingPath.RemoveAt(0);

                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentAction = 1;
                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentActionIndex = id;
            }
        }

        static public Dictionary<KeyValuePair<int, int>, PossiblePath> CurrentPathFindingSession { get; set; }
        static public Dictionary<KeyValuePair<int, int>, PossiblePath> NextPathFindingSession { get; set; }
        static public Dictionary<KeyValuePair<int, int>, PossiblePath> OldPathFindingSession { get; set; }
        static public bool PathFound { get; set; }
        static public LivingObject Pathfinder { get; set; }
        static public PossiblePath Destination { get; set; }
        static Thread PathThread { get; set; }
        static public void DoPathFinding(LivingObject p)
        {
            if (PathThread != null && PathThread.IsAlive)
                PathThread.Abort();
            if (Program.MyMap.SpawnedSpawnableLocation[p.TargetY + Program.MyMap.MinY][p.TargetX + Program.MyMap.MinX] >= 0)
            {
                if (p is NPC)
                {
                    NPC n = (NPC)p;
                    if (n.CurrentAction == 2 && Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[p.TargetY + Program.MyMap.MinY][p.TargetX + Program.MyMap.MinX]] is SpawnBuildable)
                    {
                        SpawnBuildable b = (SpawnBuildable)Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[p.TargetY + Program.MyMap.MinY][p.TargetX + Program.MyMap.MinX]];
                        if (!b.Builded)
                        {
                        }
                    }
                    else
                    {
                        Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
                        return;
                    }
                }
                else
                {
                    Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
                    return;
                }
                
            }
            if (p.TargetX == p.X && p.TargetY == p.Y)
            {
                Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
                return;
            }
            Destination = null;
            Pathfinder = p;
            PathFound = false;
            CurrentPathFindingSession = new Dictionary<KeyValuePair<int, int>, PossiblePath>();
            NextPathFindingSession = new Dictionary<KeyValuePair<int, int>, PossiblePath>();
            OldPathFindingSession = new Dictionary<KeyValuePair<int, int>, PossiblePath>();
            CurrentPathFindingSession.Add(new KeyValuePair<int, int>(p.X, p.Y), new PossiblePath(p.X, p.Y));

            PathfindingThread();
            //ThreadStart ts = new ThreadStart(PathfindingThread);
            //PathThread = new Thread(ts);
            //PathThread.Start();
        }

        static public void PathfindingThread()
        {
            int _count = 0;
            while (PathFound == false)
            {
                for (int i = 0; i < CurrentPathFindingSession.Count; i++)
                {
                    if (CurrentPathFindingSession.ElementAt(i).Value.GetTotalCost() == _count)
                        CurrentPathFindingSession.ElementAt(i).Value.FindMore();
                }

                for (int i = 0; i < CurrentPathFindingSession.Count; i++)
                    OldPathFindingSession.Add(CurrentPathFindingSession.ElementAt(i).Key, CurrentPathFindingSession.ElementAt(i).Value);
                CurrentPathFindingSession.Clear();

                for (int i = 0; i < NextPathFindingSession.Count; i++)
                    CurrentPathFindingSession.Add(NextPathFindingSession.ElementAt(i).Key, NextPathFindingSession.ElementAt(i).Value);
                NextPathFindingSession.Clear();

                _count++;
                if (_count > 71)
                    PathFound = true;
            }
            if (Destination == null)
            {
                Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
            }
            else
            {
                Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can be accessed");
                Pathfinder.PathfindingPath.Clear();
                List<int> Reverse = new List<int>();
                for (int i = Destination.Parent.Count - 1; i >= 0; i--)
                    Reverse.Add(Destination.Parent[i]);
                Pathfinder.PathfindingPath = Reverse;
                //Pathfinder.PathfindingPath = Destination.Parent;
                Pathfinder.GeneralBehavior = (int)GeneralBehaviorType.FollowingPath;
            }
            //PathThread.Abort();
        }

    }
}
