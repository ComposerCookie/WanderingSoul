using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public interface GameState
    {
        int CurrentGUI { get; set; }
        void Draw();
        void Update();
        void HandleKey(Keyboard.Key key);
        void HandleMouse(Mouse.Button key);
        void HandleMouseMove();
        bool MovingGUI { get; set; }
        List<GUI> GameGUI { get; set; }
    }
}
