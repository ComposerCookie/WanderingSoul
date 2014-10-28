using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Lost_Soul
{
    public interface GUI : GUIObject
    {
        List<GUIButton> MyButton { get; set; }
        
        int CurrentButton { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        void HandleKey(Keyboard.Key key);
        void HandleMouse(Mouse.Button but, int x, int y);
        void HandleMouseMove();
        
        void Resize();
        bool Moving { get; set; }
    }
}
