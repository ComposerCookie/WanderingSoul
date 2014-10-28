using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class BasicAttack : Attack
    {
        public string Name { get; set; }
        public int BaseDamage { get; set; }
        public int Range { get; set; }
        public int Animation { get; set; }

        public BasicAttack(string name, int damage, int range, int anim)
        {
            Name = name;
            BaseDamage = damage;
            Range = range;
            Animation = anim;
        }
    }
}
