using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public interface GUIObject
    {
        int ID { get; set; }
        int X { get; set; }
        int Y { get; set; }
        void Draw();
        void Update();
        bool Visibility { get; set; }
    }
}
