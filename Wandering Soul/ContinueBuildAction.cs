using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class ContinueBuildAction : Action
    {
        public LivingObject Person { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public SpawnBuildable Object { get; set; }

        public void Update() { }
        public void Start() { }
        public void Finish() { }
    }
}
