using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public interface Spawnable
    {
        string Name { get; set; }
        int MaxHealth { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }
        int Sprite { get; set; }
        byte Blocked { get; set; }
        bool Destroyable { get; set; }
    }
}
