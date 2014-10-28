using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class ConstructionGUI : GUI
    {
        RenderWindow _screen;
        public ConstructionGUI(RenderWindow rw, int id, int x, int y)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 500;
            Y = 500;
            Visibility = false;

            MyButton.Add(new GUIClose(rw, 20, X + 150, Y, 9, 1));
            MyButton.Add(new GUIHead(rw, 52, X, Y, 9, 1));
            MyButton.Add(new ConstructionGUIBuildButton(rw, 53, X + 144, Y + 130));

            for (int r = 0; r < 3; r++)
            {
                MyButton.Add(new ConstructionGUIItemButton(rw, 54, X + 7, Y + 27 + r * 34, r));
            }
        }


        public void HandleMouseMove()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (Moving)
                {
                    GUIHead g = (GUIHead)MyButton[1];
                    X = Mouse.GetPosition(_screen).X - g.TempX;
                    Y = Mouse.GetPosition(_screen).Y - g.TempY;
                    Resize();
                }
            }
        }

        public void Resize()
        {
            MyButton[0].X = X + 150; MyButton[0].Y = Y;
            MyButton[1].X = X; MyButton[1].Y = Y;
            MyButton[2].X = X + 144; MyButton[2].Y = Y + 130;
            for (int r = 3; r < 6; r++)
            {
                MyButton[r].X = X + 7; MyButton[r].Y = Y + 27 + (r - 3) * 34;
            }
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _screen.Draw(s);

            foreach (GUIButton b in MyButton)
            {
                b.Draw();
            }
        }
        public void Update()
        {
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X + 150 && x <= X + 170 && y >= Y && y <= Y + 20)
            {
                MyButton[0].Picked();
            }

            else if (x >= X + 0 && x <= X + 150 && y >= Y && y <= Y + 20)
            {
                MyButton[1].Picked();
            }

            else if (x >= X + 144 && x <= X + 161 && y >= Y + 130 && y <= Y + 147)
            {
                MyButton[2].Picked();
            }

            else if (x >= X + 7 && x <= X + 138 && y >= Y + 27 && y <= Y + 59)
            {
                MyButton[3].Picked();
            }

            else if (x >= X + 7 && x <= X + 138 && y >= Y + 61 && y <= Y + 93)
            {
                MyButton[4].Picked();
            }

            else if (x >= X + 7 && x <= X + 138 && y >= Y + 95 && y <= Y + 129)
            {
                MyButton[5].Picked();
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
        public int LocX { get; set; }
        public int LocY { get; set; }
        public int CurPage { get; set; }
    }
}
