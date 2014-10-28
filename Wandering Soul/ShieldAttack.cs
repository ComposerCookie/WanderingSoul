using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class ShieldAttack : Attack
    {
        public string Name { get; set; }
        public int BaseDamage { get; set; }
        public int Range { get; set; }
        public int Animation { get; set; }
        public byte Block { get; set; }
        public bool CompletelyBlock { get; set; }
        public int BlockTime { get; set; }

        public ShieldAttack(string name, int dmg, int anim, byte block, bool complete, int time)
        {
            Name = name;
            BaseDamage = dmg;
            Range = 1;
            Animation = anim;
            Block = block;
            CompletelyBlock = complete;
            BlockTime = time;
        }
    }
}
