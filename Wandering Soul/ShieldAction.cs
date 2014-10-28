using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class ShieldAction : AttackAction
    {
        public Attack ID { get; set; }
        public LivingObject Caster { get; set; }
        public int Dir { get; set; }
        public AttackManager AM { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Cooldown { get; set; }
        public SpawnAnimation Animation { get; set; }
        public bool Attacked { get; set; }

        public ShieldAction(LivingObject caster, Attack id, int dir, AttackManager am)
        {
            Caster = caster;
            ID = id;
            Dir = dir;
            AM = am;

            X = Caster.X;
            Y = Caster.Y;

            Animation = new SpawnAttackAnimation(ID.Animation, X, Y, Dir, false, this);
            Attacked = false;
            Caster.CurrentDefenseAction = this;
        }

        public void Update()
        {
            Animation.Update();
            if (Animation.Animated)
            {
                Attacked = true;
                Caster.CurrentDefenseAction = null;
            }
        }

        public void Draw(RenderWindow rw)
        {
            if (Animation != null)
                Animation.Draw(rw);
        }
    }
}
