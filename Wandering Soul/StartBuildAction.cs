using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class StartBuildAction : Action
    {
        public LivingObject Person { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Buildable BuildObject { get; set; }

        public void Update() { }
        public void Start() { }
        public void Finish() { }
    }
}
