using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Lost_Soul
{
    public interface GUI
    {
        List<GUIButton> MyButton { get; set; }
        int CurrentButton { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int ID { get; set; }
        void Draw();
        void Update();
        void HandleKey(Keyboard.Key key);
        void HandleMouse(Mouse.Button but, int x, int y);
        void HandleMouseMove();
        bool Visibility { get; set; }
        void Resize();
        bool Moving { get; set; }
    }
}
