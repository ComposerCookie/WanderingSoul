using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Hostile : LivingObject
    {
        public Hostile(string name, int type, int sprite, int onmaptype, int speed, int range, int maxHP, List<int> availatk, int atkspd)
        {
            Name = name;
            Type = type;
            Sprite = sprite;
            OnMapType = onmaptype;
            Speed = speed;
            Dir = 3;
            Range = range;
            MaxHealth = maxHP;
            CurHP = MaxHealth;
            AvailableAttack = availatk;
            AttackSpeed = atkspd;
            Ranged = false;
        }

        public override void Action(byte hand)
        {

        }

        public override void Update()
        {
            if (CurHP <= 0)
            {
                CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(Index);
                CurMap.LivingThing[CurMap.LivingThing.IndexOf(this)] = null;
            }
            if (Targeting != null && (OnMapType == Targeting.OnMapType && SideMapID == Targeting.SideMapID))
            {
                if (LeftAttackCooldown <= 0)
                {
                    if (!Ranged)
                    {

                        if (Targeting.X == X + 1 && Targeting.Y == Y)
                        {
                            Dir = 2;
                            CurMap.AtkM.ExistingAttack.Add(new BasicAttackAction(this, Program.Data.MyAttack[Logic.r.Next(0, AvailableAttack.Count - 1)], Dir, CurMap.AtkM));
                            LeftAttackCooldown = AttackSpeed;
                        }
                        else if (Targeting.X == X - 1 && Targeting.Y == Y)
                        {
                            Dir = 0;
                            CurMap.AtkM.ExistingAttack.Add(new BasicAttackAction(this, Program.Data.MyAttack[Logic.r.Next(0, AvailableAttack.Count - 1)], Dir, CurMap.AtkM));
                            LeftAttackCooldown = AttackSpeed;
                        }
                        else if (Targeting.Y == Y + 1 && Targeting.X == X)
                        {
                            Dir = 3;
                            CurMap.AtkM.ExistingAttack.Add(new BasicAttackAction(this, Program.Data.MyAttack[Logic.r.Next(0, AvailableAttack.Count - 1)], Dir, CurMap.AtkM));
                            LeftAttackCooldown = AttackSpeed;
                        }
                        else if (Targeting.Y == Y - 1 && Targeting.X == X)
                        {
                            Dir = 1;
                            CurMap.AtkM.ExistingAttack.Add(new BasicAttackAction(this, Program.Data.MyAttack[Logic.r.Next(0, AvailableAttack.Count - 1)], Dir, CurMap.AtkM));
                            LeftAttackCooldown = AttackSpeed;
                        }
                    }
                }
            }
            if (LeftAttackCooldown > 0)
                LeftAttackCooldown--;
            if (IsWalking)
            {
                WalkCount += Speed;

                if (WalkCount >= 64 && Moved)
                {
                    switch (TargetDir)
                    {
                        case 0:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(Index);
                            X--;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(Index);
                            Moved = false;
                            break;
                        case 1:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(Index);
                            Y--;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(Index);
                            Moved = false;
                            break;
                        case 2:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(Index);
                            X++;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(Index);
                            Moved = false;
                            break;
                        case 3:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(Index);
                            Y++;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(Index);
                            Moved = false;
                            break;
                    }
                }

                if (WalkCount >= 128)
                {
                    switch (TargetDir)
                    {
                        case 0:
                            LastX--;
                            break;
                        case 1:
                            LastY--;
                            break;
                        case 2:
                            LastX++;
                            break;
                        case 3:
                            LastY++;
                            break;
                    }

                    WalkCount = 0;
                    IsWalking = false;

                    
                    WalkCooldown = 30;
                }
            }

            else if (WalkCooldown == 0)
            {
                if (Targeting != null)
                {
                    if (Math.Abs(Targeting.X - X) == 1 && Targeting.Y == Y)
                        return;
                    if (Math.Abs(Targeting.Y - Y) == 1 && Targeting.X == X)
                        return;
                    TargetX = Targeting.X;
                    TargetY = Targeting.Y;

                    List<int>[] path = new List<int>[4];
                    TargetX--;
                    Logic.DoPathFinding(this);
                    path[0] = new List<int>(PathfindingPath);
                    TargetX++;

                    TargetY--;
                    Logic.DoPathFinding(this);
                    path[1] = new List<int>(PathfindingPath);
                    TargetY++;

                    TargetX++;
                    Logic.DoPathFinding(this);
                    path[2] = new List<int>(PathfindingPath);
                    TargetX--;

                    TargetY++;
                    Logic.DoPathFinding(this);
                    path[3] = new List<int>(PathfindingPath);

                    int bestpath = -1;
                    int smallest = 200;
                    for (int i = 0; i < 4; i++)
                    {
                        if (path[i].Count > 0 && path[i].Count < smallest)
                        {
                            smallest = path[i].Count;
                            bestpath = i;
                        }
                    }

                    PathfindingPath = path[bestpath];
                    
                    if (PathfindingPath.Count > 0)
                        Walk(PathfindingPath[PathfindingPath.Count - 1], true);
                }
                else
                {
                    if (GeneralBehavior == (int)GeneralBehaviorType.FollowingPath)
                        Walk(PathfindingPath[0], true);
                    else if (GeneralBehavior == (int)GeneralBehaviorType.Normal)
                        Walk(Logic.RandomNumber(0, 3), true);
                }
            }
            else
                WalkCooldown--;


        }

        public List<int> AvailableAttack { get; set; }
        public bool Ranged { get; set; }
    }
}
