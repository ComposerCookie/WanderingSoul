using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public interface Items
    {
        string Name { get; set; }
        int Sprite { get; set; }
        int Type { get; set; }
        int DropSprite { get; set; }
    }
}
