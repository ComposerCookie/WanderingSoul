using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public interface GUIButton : GUIObject
    {
        void Clicked();
        void Picked();
        bool isMouseHover();
        bool isFocused();
        
        int Width { get; set; }
        int Height { get; set; }
        
    }
}
