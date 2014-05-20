using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class MainMenuGUI : GUI
    {
        RenderWindow _screen;
        public MainMenuGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            MyButton.Add(new NewGameButton(_screen, 0, 210, 416));
            MyButton.Add(new ExitGameButton(_screen, 1, 210, 519));
            CurrentButton = 0;
            X = 200;
            Y = 400;
        }

        public void HandleMouseMove()
        {
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);

            foreach (GUIButton b in MyButton)
            {
                b.Draw();
            }
        }
        public void Update()
        {
        }

        public void Resize()
        { 
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X + 10 && x <= X + 90 && y >= Y + 17 && y <= Y + 47)
            {
                MyButton[0].Picked();
            }
            else if (x >= X + 10 && x <= X + 90 && y >= Y + 118 && y <= Y + 148)
            {
                MyButton[1].Picked();
            }
        }

        public void HandleKey(Keyboard.Key key)
        {
            switch (key)
            {
                case Keyboard.Key.Up:
                    CurrentButton++;
                    if (CurrentButton >= MyButton.Count)
                        CurrentButton = 0;
                    break;
                case Keyboard.Key.Down:
                    CurrentButton--;
                    if (CurrentButton < 0)
                        CurrentButton = MyButton.Count - 1;
                    break;
                case Keyboard.Key.Space:
                    MyButton[CurrentButton].Picked();
                    break;
            }
        }

        public List<GUIButton> MyButton { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ID { get; set; }
        public int CurrentButton { get; set; }
        public bool Visibility { get; set; }
        public bool Moving { get; set; }
    }
}
