using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class BasicAttackAction : AttackAction
    {
        public LivingObject Caster { get; set; }
        public Attack ID { get; set; }
        public int Dir { get; set; }
        public AttackManager AM { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Cooldown { get; set; }
        public SpawnAnimation Animation { get; set; }
        public bool Attacked { get; set; }
        
        
        public BasicAttackAction(LivingObject caster, Attack id, int dir, AttackManager am)
        {
            Caster = caster;
            ID = id;
            Dir = dir;
            AM = am;
            switch (Dir)
            {
                case 0:
                    X = Caster.X - 1;
                    Y = Caster.Y;
                    break;
                case 1:
                    X = Caster.X;
                    Y = Caster.Y - 1;
                    break;
                case 2:
                    X = Caster.X + 1;
                    Y = Caster.Y;
                    break;
                case 3:
                    X = Caster.X;
                    Y = Caster.Y + 1;
                    break;
            }
            Animation = new SpawnAttackAnimation(ID.Animation, X, Y, Dir, false, this);
            Attacked = false;
        }

        public void Draw(RenderWindow rw)
        {
            if (Animation != null)
                Animation.Draw(rw);
        }

        public void Update()
        {
            int dmg;
            Animation.Update();
            if (Animation.Animated)
            {
                Attacked = true;
                if (Logic.GetBlockedByLivingThing(X + Caster.CurMap.MinX, Y + Caster.CurMap.MinY, Caster.CurMap))
                {
                    LivingObject p = Caster.CurMap.LivingThing[Caster.CurMap.SpawnedLivingThing[Y + Caster.CurMap.MinY][X + Caster.CurMap.MinX][0]];
                    if ((p is Hostile && Caster is NPC) || (p is NPC && Caster is Hostile))
                    {
                        dmg = (int)(ID.BaseDamage * ((float)Logic.RandomizeDamage() / 10));
                        p.ReceiveDamage(dmg, Caster);
                    }
                }
            }
        }
    }
}
