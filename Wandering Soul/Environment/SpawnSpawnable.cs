using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public interface SpawnSpawnable
    {
        int ID { get; set; }
        int CurHealth { get; set; }
        int X { get; set; }
        int Y { get; set; }
        Map OnMap { get; set; }

        void DrawTop(RenderWindow rw);
        void DrawBot(RenderWindow rw);
        void Update();

    }
}
