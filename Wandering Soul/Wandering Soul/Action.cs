using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public interface Action
    {
        LivingObject Person { get; set; }
        void Update();
        void Start();
        void Finish();
    }
}
