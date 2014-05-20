using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Hostile : LivingObject
    {
        public Hostile(string name, int type, int sprite, int onmaptype, int speed, int range, int maxHP)
        {
            Name = name;
            Type = type;
            Sprite = sprite;
            OnMapType = onmaptype;
            Speed = speed;
            Dir = 3;
            Range = range;
            MaxHealth = maxHP;
            CurrentHealth = MaxHealth;
        }

        public override void Action()
        {

        }

        public override void Update()
        {
            if (IsWalking)
            {
                WalkCount += Speed;
                if (WalkCount >= 16)
                {
                    WalkCount = 0;
                    IsWalking = false;

                    switch (TargetDir)
                    {
                        case 0:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            X--;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            break;
                        case 1:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            Y--;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            break;
                        case 2:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            X++;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            break;
                        case 3:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            Y++;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            break;
                    }
                    WalkCooldown = 30;
                }
            }
            if (WalkCooldown == 0)
            {
                if (GeneralBehavior == (int)GeneralBehaviorType.FollowingPath)
                    Walk(PathfindingPath[0]);
                else if (GeneralBehavior == (int)GeneralBehaviorType.Normal)
                    Walk(Logic.RandomNumber(0, 3));
            }
            else
                WalkCooldown--;
        }
    }
}
