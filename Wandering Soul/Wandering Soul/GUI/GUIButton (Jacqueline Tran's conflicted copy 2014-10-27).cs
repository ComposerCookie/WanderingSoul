using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public interface GUIButton
    {
        void Clicked();
        void Picked();
        bool isMouseHover();
        bool isFocused();
        int ID { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        bool Visibility { get; set; }
        void Draw();
        void Update();
    }
}
