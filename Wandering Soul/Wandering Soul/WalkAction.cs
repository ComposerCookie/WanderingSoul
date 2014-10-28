using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class WalkAction : Action
    {
        public LivingObject Person { get; set; }
        public int Dir { get; set; }
        public bool ChangeDir { get; set; }

        public WalkAction(LivingObject p, int dir, bool change)
        {
            Person = p;
            Dir = dir;
            ChangeDir = change;
        }

        public void Update() 
        {

        }
        public void Start()
        { 

        }
        public void Finish() 
        { 

        }
    }
}
