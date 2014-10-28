using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class ActionGUI : GUI
    {
        RenderWindow _screen;
        public ActionGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 100;
            Y = 100;
            Visibility = false;

            MyButton.Add(new GUIClose(rw, 20, X + 112, Y, 7, 1));
            MyButton.Add(new GUIHead(rw, 42, X, Y, 7, 1));

            MyButton.Add(new ActionGUIBuildButton(rw, 38, X + 38, Y + 26));
            MyButton.Add(new ActionGUICraftButton(rw, 39, X + 7, Y + 26));
            MyButton.Add(new ActionGUILeftArrowButton(rw, 40, X + 69, Y + 57));
            MyButton.Add(new ActionGUIRightArrowButton(rw, 41, X + 100, Y + 57));
            Page = 0;
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
            MyButton[0].X = X + 112; MyButton[0].Y = Y;
            MyButton[1].X = X; MyButton[1].Y = Y;
            MyButton[2].X = X + 38; MyButton[2].Y = Y + 26;
            MyButton[3].X = X + 7; MyButton[3].Y = Y + 26;
            MyButton[4].X = X + 69; MyButton[4].Y = Y + 57;
            MyButton[5].X = X + 100; MyButton[5].Y = Y + 57;
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _screen.Draw(s);

            MyButton[0].Draw();
            MyButton[1].Draw();
            MyButton[4].Draw();
            MyButton[5].Draw();

            switch (Page)
            {
                case 0:
                    MyButton[2].Draw();
                    MyButton[3].Draw();
                    break;
            }
        }
        public void Update()
        {
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X + 112 && x <= X + 132 && y >= Y && y <= Y + 20)
            {
                MyButton[0].Picked();
            }

            else if (x >= X && x <= X + 112 && y >= Y && y <= Y + 20)
            {
                MyButton[1].Picked();
            }

            else if (x >= X + 38 && x <= X + 62 && y >= Y + 26 && y <= Y + 50)
            {
                if (Page == 0)
                    MyButton[2].Picked();
            }
            else if (x >= X + 7 && x <= X + 31 && y >= Y + 26 && y <= Y + 50)
            {
                if (Page == 0)
                    MyButton[3].Picked();
            }
            else if (x >= X + 69 && x <= X + 93 && y >= Y + 57 && y <= Y + 81)
            {
                MyButton[4].Picked();
            }
            else if (x >= X + 100 && x <= X + 124 && y >= Y + 57 && y <= Y + 81)
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
        public int Page { get; set; }
    }
}
