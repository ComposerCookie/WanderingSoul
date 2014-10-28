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


        static public int GetMaxHealthBasedOnStat(LivingObject p)
        {
            int maxhealth = 30; //base health for every playable character

            if (p is NPC)
            {
                NPC person = (NPC)p;
                switch ((JobType)person.Job)
                {
                    case JobType.Novice:
                        maxhealth += 10 * person.Level;
                        break;
                }
            }

            maxhealth += 15 * p.Endurance;

            return maxhealth;
        }

        static public int GetMaxManaBasedOnStat(LivingObject p)
        {
            int maxmana = 10; //base mana for every playable character
            if (p is NPC)
            {
                NPC person = (NPC)p;
                switch ((JobType)person.Job)
                {
                    case JobType.Novice:
                        maxmana += 2 * person.Level;
                        break;
                }
            }

            maxmana += 10 * p.Willpower;

            return maxmana;
        }

        static public int GetSpawnableType(SpawnSpawnable obj)
        {
            int type = -1;
            if (obj is SpawnResource)
                type = 0;
            else if (obj is SpawnBuildable)
            {
                if (obj is SpawnBuildableBuilding)
                    type = 1;
            }
            return type;
        }

        static public void SwitchState(int state)
        {
            switch (state)
            {
                case 0:
                    if (CurrentParty != null && CurrentWorld != null)
                    {
                        for (int i = 0; i < CurrentParty.MainParty.MyParty.Count; i++ )
                        {
                            CurrentParty.MainParty.MyParty[i].CurMap.SpawnedLivingThing[CurrentParty.MainParty.MyParty[i].Y + CurrentParty.MainParty.MyParty[i].CurMap.MinY][CurrentParty.MainParty.MyParty[i].X + CurrentParty.MainParty.MyParty[i].CurMap.MinX].Remove(CurrentParty.MainParty.MyParty[i].Index);
                            CurrentParty.MainParty.MyParty[i].CurMap.LivingThing[CurrentParty.MainParty.MyParty[i].Index] = null;
                        }
                        Program.InState = 0;
                    }
                    break;
                case 1:
                    if (CurrentParty != null && CurrentWorld != null)
                    {
                        for (int i = 0; i < Program.Data.CurrentParty.MainParty.MyParty.Count; i++)
                        {
                            Program.Data.CurrentParty.MainParty.MyParty[i].OnMapType = Program.Data.CurrentWorld.SpawnPlaceMapType;
                            Program.Data.CurrentParty.MainParty.MyParty[i].SideMapID = Program.Data.CurrentWorld.SpawnMapIndex;
                            Program.Data.CurrentParty.MainParty.MyParty[i].X = Program.Data.CurrentWorld.SpawnMapX;
                            Program.Data.CurrentParty.MainParty.MyParty[i].Y = Program.Data.CurrentWorld.SpawnMapY;
                            Program.Data.CurrentParty.MainParty.MyParty[i].PutOnMap();

                            InGameState s = (InGameState)Program.SM.States[1];
                            s.Initialize();
                            Program.InState = 1;
                        }
                    }
                    break;
            }
        }

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

        static public string GetLetterFromKeyboard(Keyboard.Key key)
        {
            string t = "";
            switch (key)
            {
                case Keyboard.Key.A:
                    t += "A";
                    break;
                case Keyboard.Key.B:
                    t += "B";
                    break;
                case Keyboard.Key.C:
                    t += "C";
                    break;
                case Keyboard.Key.D:
                    t += "D";
                    break;
                case Keyboard.Key.E:
                    t += "E";
                    break;
                case Keyboard.Key.F:
                    t += "F";
                    break;
                case Keyboard.Key.G:
                    t += "G";
                    break;
                case Keyboard.Key.H:
                    t += "H";
                    break;
                case Keyboard.Key.I:
                    t += "I";
                    break;
                case Keyboard.Key.J:
                    t += "J";
                    break;
                case Keyboard.Key.K:
                    t += "K";
                    break;
                case Keyboard.Key.L:
                    t += "L";
                    break;
                case Keyboard.Key.M:
                    t += "M";
                    break;
                case Keyboard.Key.N:
                    t += "N";
                    break;
                case Keyboard.Key.O:
                    t += "O";
                    break;
                case Keyboard.Key.P:
                    t += "P";
                    break;
                case Keyboard.Key.Q:
                    t += "Q";
                    break;
                case Keyboard.Key.R:
                    t += "R";
                    break;
                case Keyboard.Key.S:
                    t += "S";
                    break;
                case Keyboard.Key.T:
                    t += "T";
                    break;
                case Keyboard.Key.U:
                    t += "U";
                    break;
                case Keyboard.Key.V:
                    t += "V";
                    break;
                case Keyboard.Key.W:
                    t += "W";
                    break;
                case Keyboard.Key.X:
                    t += "X";
                    break;
                case Keyboard.Key.Y:
                    t += "Y";
                    break;
                case Keyboard.Key.Z:
                    t += "Z";
                    break;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) || (Keyboard.IsKeyPressed(Keyboard.Key.RShift)))
            {
            }
            else
            {
                t = t.ToLower();
            }

            return t;
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

        static public bool BlockedAt(int x, int y, Map m, byte checker)
        {
            if (GetBlockedByLivingThing(x, y, m) || GetBlockedBySpawnable(x, y, m, checker) || GetBlockedByTerrain(x, y, m))
            {
                return true;
            }
            return false;
        }
        
        static public bool GetBlockedByTerrain(int x, int y, Map m)
        {
            if (Program.Data.MyTerrain[m.SpawnedTerrain[m.Y[y].Tile[x].ID].Type].Blocked == 1)
                return true;
            return false;
        }

        static public bool GetBlockedBySpawnable(int x, int y, Map m, byte checker)
        {
            if (m.SpawnedSpawnableLocation[y][x] == -1)
                return false;
            if (Logic.GetSpawnableType(m.SpawnedSpawnable[m.SpawnedSpawnableLocation[y][x]]) == 0)
            {
                if (Program.Data.GetResourceList()[m.SpawnedSpawnable[m.SpawnedSpawnableLocation[y][x]].ID].Blocked == 1)
                    return true;
            }
            else if (Logic.GetSpawnableType(m.SpawnedSpawnable[m.SpawnedSpawnableLocation[y][x]]) == 1)
            {
                if (checker == 1)
                    return true;
                else
                {
                    BuildableHouse b = (BuildableHouse)Program.Data.GetBuildableList()[m.SpawnedSpawnable[m.SpawnedSpawnableLocation[y][x]].ID];
                    SpawnBuildableBuilding sb = (SpawnBuildableBuilding)m.SpawnedSpawnable[m.SpawnedSpawnableLocation[y][x]];
                    bool atdoor = false;
                    foreach (KeyValuePair<int, int> d in b.DoorLocation)
                    {
                        if (x == sb.X + d.Key && y == sb.Y + d.Value)
                            atdoor = true;
                    }
                    if (atdoor)
                        return false;
                    else
                        return true;
                }
            }
            else
            {

            }
            
            return false;
        }

        static public bool GetBlockedByLivingThing(int x, int y, Map m)
        {
            if (m.SpawnedLivingThing[y][x].Count > 0)
                return true;
            return false;
        }

        static public int RandomizeDamage()
        {
            return (r.Next(1, 20));
        }

        static public AttackAction CreateAttackActionFromAttack(Attack atk, LivingObject caster, AttackManager am)
        {
            AttackAction a = null;
            if (atk is BasicAttack)
                a = new BasicAttackAction(caster, atk, caster.Dir, am);
            else if (atk is ShieldAttack)
                a = new ShieldAction(caster, atk, caster.Dir, am);
            return a;
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
                            //    n.CurMap.Drop[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX].Add(r.Give[i]);
                            //}
                            n.CurMap.SpawnedSpawnable[n.CurMap.SpawnedSpawnableLocation[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX]] = null;
                            n.CurMap.NullList.Add(n.CurMap.SpawnedSpawnableLocation[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX]);
                            n.CurMap.SpawnedSpawnableLocation[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX] = -1;
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
                    if (((n.Equipment[11] != null && Program.Data.MyItems[n.Equipment[11].ID] is ToolItem) || (n.Equipment[7] != null && Program.Data.MyItems[n.Equipment[7].ID] is ToolItem)) && Program.Data.CurrentParty.MainParty.MyParty[0].KnowledgeKnown.Contains(1))
                    {
                        _object.CurHealth--;
                        if (_object.CurHealth == 0)
                        {
                            for (int i = 0; i < r.Give.Count; i++)
                            {
                                n.CurMap.Drop[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX].Add(new SpawnItems(r.Give[i].ID));
                            }
                            n.CurMap.SpawnedSpawnable[n.CurMap.SpawnedSpawnableLocation[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX]] = null;
                            n.CurMap.NullList.Add(n.CurMap.SpawnedSpawnableLocation[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX]);
                            n.CurMap.SpawnedSpawnableLocation[_object.Y + n.CurMap.MinY][_object.X + n.CurMap.MinX] = -1;
                        }
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, attacker.Name + " tried to harvest " + Program.Data.GetResourceList()[_object.ID].Name);
                    }
                    else
                        Program.Log.AddMessage((int)InGameLogMessageType.Notification, attacker.Name + " don't have the necessary tool or knowledge to harvest this");
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

        static public void RemoveItemsFromInventory(LivingObject p, int id, int amount)
        {
            int still = amount;
            if (p is NPC)
            {
                NPC npc = (NPC)p;
                if (GetTotalAmountOfThisItemIn(p, id) < amount)
                    return;
                for (int i = npc.Inventory.Count - 1; i >= 0; i--)
                {
                    if (npc.Inventory[i] != null && npc.Inventory[i].ID == id)
                    {
                        if (still - npc.Inventory[i].Amount >= 0)
                        {
                            still -= npc.Inventory[i].Amount;
                            npc.Inventory.RemoveAt(i);
                        }
                        else
                        {
                            npc.Inventory[i].Amount -= still;
                            return;
                        }
                    }
                    if (still == 0)
                        return;
                }
            }
        }

        static public int GetTotalAmountOfThisItemIn(LivingObject p, int id)
        {
            int total = 0;
            if (p is NPC)
            {
                NPC npc = (NPC)p;
                foreach (SpawnItems s in npc.Inventory)
                    if (s != null && s.ID == id)
                        total += s.Amount;
            }
            return total;
        }

        static public List<int> KnownBluePrintForThisCharacter(LivingObject p)
        {
            List<int> KnowBlueprint = new List<int>();
            if (p is NPC)
            {
                NPC npc = (NPC)p;
                foreach (int b in npc.KnownBlueprint)
                    KnowBlueprint.Add(b);

                foreach (int k in npc.KnowledgeKnown)
                    foreach (int b in Program.Data.MyKnowledge[k].BlueprintUnlock)
                        KnowBlueprint.Add(b);
            }
            return KnowBlueprint;
        }

        static public List<int> KnownBluePrintForThisCharacter(LivingObject p, int cla)
        {
            List<int> KnowBlueprint = new List<int>();
            if (p is NPC)
            {
                NPC npc = (NPC)p;
                foreach (int b in npc.KnownBlueprint)
                    if (Program.Data.GetBuildableList()[b].Classification.Contains(cla))
                        KnowBlueprint.Add(b);

                foreach (int k in npc.KnowledgeKnown)
                    foreach (int b in Program.Data.MyKnowledge[k].BlueprintUnlock)
                        if (Program.Data.GetBuildableList()[b].Classification.Contains(cla))
                            KnowBlueprint.Add(b);
            }
            return KnowBlueprint;
        }

        static public List<int> KnownRecipeForThisCharacter(LivingObject p)
        {
            List<int> KnowRecipe = new List<int>();
            if (p is NPC)
            {
                NPC npc = (NPC)p;
                foreach (int r in npc.KnownRecipe)
                    KnowRecipe.Add(r);

                foreach (int k in npc.KnowledgeKnown)
                    foreach (int r in Program.Data.MyKnowledge[k].RecipeUnlock)
                        KnowRecipe.Add(r);
            }
            return KnowRecipe;
        }

        static public List<int> KnownRecipeForThisCharacter(LivingObject p, int cla)
        {
            List<int> KnowRecipe = new List<int>();
            if (p is NPC)
            {
                NPC npc = (NPC)p;
                foreach (int r in npc.KnownRecipe)
                    if (Program.Data.MyItems[r].Classification.Contains(cla))
                        KnowRecipe.Add(r);

                foreach (int k in npc.KnowledgeKnown)
                    foreach (int r in Program.Data.MyKnowledge[k].RecipeUnlock)
                        if (Program.Data.MyItems[r].Classification.Contains(cla))
                            KnowRecipe.Add(r);
            }
            return KnowRecipe;
        }

        static public void CreateMessageOnScreen(string msg, uint size, Color c, int x, int y)
        {
            Text t = new Text(msg, Program.Data.Font, size);
            t.Color = c;
            t.Position = new Vector2f(x, y);
            Program.RW.Draw(t);
        }

        static public SpawnBuildable GetBuildableTypeBasedOnID(int id, int x, int y, Map m)
        {
            SpawnBuildable b = new SpawnBuildable();
            if (Program.Data.GetBuildableList()[id] is BuildFire)
            {
                b = new SpawnBuildableFire(id, x, y, m);
            }
            return b;
        }

        static public void BuildStuff(int x, int y, int id, RenderWindow rw, Map m)
        {
            bool buildable = true;
            for (int r = y; r < y + Program.Data.GetBuildableList()[id].SizeY; r++)
            {
                for (int c = x; c < x + Program.Data.GetBuildableList()[id].SizeX; c++)
                {
                    if (GetBlockedByLivingThing(c, r, m) || GetBlockedBySpawnable(c, r, m, 1) || GetBlockedByTerrain(c, r, m))
                    {
                        buildable = false;
                        break;
                    }
                }
            }

            if (buildable)
            {
                Program.Data.CurrentParty.MainParty.MyParty[0].TargetX = (int)Mouse.GetPosition(rw).X / 16 + Program.Data.CurrentParty.MainParty.MyParty[0].X - (int)rw.Size.X / 2 / 16 - 1;
                Program.Data.CurrentParty.MainParty.MyParty[0].TargetY = (int)(Mouse.GetPosition(rw).Y + 8) / 16 + Program.Data.CurrentParty.MainParty.MyParty[0].Y - (int)rw.Size.Y / 2 / 16 - 1;
                DoPathFinding(Program.Data.CurrentParty.MainParty.MyParty[0]);
                if (Program.Data.CurrentParty.MainParty.MyParty[0].PathfindingPath.Count < 1)
                    return;
                Program.Data.CurrentParty.MainParty.MyParty[0].ActionDir = Program.Data.CurrentParty.MainParty.MyParty[0].PathfindingPath[0];
                Program.Data.CurrentParty.MainParty.MyParty[0].PathfindingPath.RemoveAt(0);

                Program.Data.CurrentParty.MainParty.MyParty[0].CurrentAction = 1;
                Program.Data.CurrentParty.MainParty.MyParty[0].CurrentActionIndex = id;
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
            Pathfinder = p;
            if (Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[p.TargetY + Logic.Pathfinder.CurMap.MinY][p.TargetX + Logic.Pathfinder.CurMap.MinX] >= 0)
            {
                if (p is NPC)
                {
                    NPC n = (NPC)p;
                    if ((n.CurrentAction == 2 || n.CurrentAction == 4) && Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[p.TargetY + Logic.Pathfinder.CurMap.MinY][p.TargetX + Logic.Pathfinder.CurMap.MinX]] is SpawnBuildable)
                    {
                        SpawnBuildable b = (SpawnBuildable)Logic.Pathfinder.CurMap.SpawnedSpawnable[Logic.Pathfinder.CurMap.SpawnedSpawnableLocation[p.TargetY + Logic.Pathfinder.CurMap.MinY][p.TargetX + Logic.Pathfinder.CurMap.MinX]];
                        if (!b.Builded)
                        {
                        }
                        else if (n.CurrentAction == 4)
                        {
                        }
                    }
                    else
                    {
                        //Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
                        return;
                    }
                }
                else
                {
                    //Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
                    return;
                }
                
            }
            if (p.TargetX == p.X && p.TargetY == p.Y)
            {
                //Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
                return;
            }
            Destination = null;
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
                //Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can't be accessed");
            }
            else
            {
                //Program.Log.AddMessage((int)InGameLogMessageType.System, "Path can be accessed");
                Pathfinder.PathfindingPath.Clear();
                List<int> Reverse = new List<int>();
                for (int i = Destination.Parent.Count - 1; i >= 0; i--)
                    Reverse.Add(Destination.Parent[i]);
                Pathfinder.PathfindingPath = Reverse;
                //Pathfinder.PathfindingPath = Destination.Parent;
                Pathfinder.GeneralBehavior = (int)GeneralBehaviorType.FollowingPath;
                if (Pathfinder.IsWalking)
                {

                    int last = Pathfinder.PathfindingPath[Pathfinder.PathfindingPath.Count - 1];
                    switch (Pathfinder.Dir)
                    {
                        case 0:
                            if (last != 0)
                                Pathfinder.PathfindingPath.Add(2);
                            break;
                        case 1:
                            if (last != 1)
                                Pathfinder.PathfindingPath.Add(3);
                            break;
                        case 2:
                            if (last != 2)
                                Pathfinder.PathfindingPath.Add(0);
                            break;
                        case 3:
                            if (last != 3)
                                Pathfinder.PathfindingPath.Add(1);
                            break;
                    }

                    Pathfinder.PathfindingPath.Add(Pathfinder.Dir); // to remove the current walking effect
                }
            }
            //PathThread.Abort();
        }

    }
}
