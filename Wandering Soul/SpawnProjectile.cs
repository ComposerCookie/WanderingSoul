using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public interface SpawnProjectile
    {
        Attack ID { get; set; }
        LivingObject Caster { get; set; }
        int Dir { get; set; }
        AttackManager AM { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Cooldown { get; set; }
        SpawnAnimation Animation { get; set; }
        void Update();
        void Draw(RenderWindow rw);
        bool Attacked { get; set; }
    }
}
