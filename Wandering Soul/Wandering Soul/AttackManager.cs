using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class AttackManager
    {
        public List<AttackAction> ExistingAttack { get; set; }
        public Map Managing { get; set; }

        public AttackManager(Map m)
        {
            ExistingAttack = new List<AttackAction>();
            Managing = m;
        }

        public void Update()
        {
            for (int i = ExistingAttack.Count - 1; i >= 0; i--)
            {
                ExistingAttack[i].Update();
                if (ExistingAttack[i].Attacked)
                    ExistingAttack.RemoveAt(i);
            }
        }

        public void Draw(RenderWindow rw)
        {
            for (int i = ExistingAttack.Count - 1; i >= 0; i--)
            {
                ExistingAttack[i].Draw(rw);
            }
        }
    }
}
