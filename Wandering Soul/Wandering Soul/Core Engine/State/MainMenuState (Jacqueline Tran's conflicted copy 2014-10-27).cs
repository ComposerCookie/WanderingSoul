using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class MainMenuState : GameState
    {
        RenderWindow _screen;
        public MainMenuState(RenderWindow rw)
        {
            GameGUI = new List<GUI>();
            _screen = rw;
            GameGUI.Add(new MainMenuGUI(_screen, 0));
            CurrentGUI = 0;
        }

        public void Draw()
        {
            GameGUI[CurrentGUI].Draw();
        }

        public void Update()
        {
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
        }

        public void HandleKey(Keyboard.Key key)
        {
            GameGUI[CurrentGUI].HandleKey(key);
        }

        public void HandleMouse(Mouse.Button key)
        {
            int x = Mouse.GetPosition(_screen).X;
            int y = Mouse.GetPosition(_screen).Y;
            if (x >= GameGUI[0].X && x <= GameGUI[0].X + 100 && y >= GameGUI[0].Y && y <= GameGUI[0].Y + 160)
                GameGUI[0].HandleMouse(key, x, y);
        }

        public void HandleMouseMove()
        {
        }

        public List<GUI> GameGUI
        {
            get;
            set;
        }

        public int CurrentGUI
        {
            get;
            set;
        }

        public bool MovingGUI
        {
            get;
            set;
        }
    }
}
