using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class InGameLogGUI : GUI
    {
        RenderWindow _screen;

        public InGameLogGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 20;
            Y = 500;
            Visibility = true;

            MyButton.Add(new GUIHead(rw, 31, X + 19, Y, 4, 1));

            MyButton.Add(new InGameLogArrowDown(rw, 27, X + 234, Y + 103));
            MyButton.Add(new InGameLogArrowUp(rw, 26, X + 234, Y + 19));
            MyButton.Add(new InGameLogReturn(rw, 30, X + 229, Y + 117));
            MyButton.Add(new InGameLogClose(rw, 28, X, Y));
            MyButton.Add(new InGameLogOpen(rw, 29, X, Y));

            Log = new InGameLog(new IntRect(X + 3, Y + 21, 223, 87), rw);
        }

        public void HandleMouseMove()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (Moving)
                {
                    GUIHead g = (GUIHead)MyButton[0];
                    X = Mouse.GetPosition(_screen).X - g.TempX;
                    Y = Mouse.GetPosition(_screen).Y - g.TempY;
                    Resize();
                }
            }
        }

        public void Resize()
        {
            MyButton[0].X = X + 19;
            MyButton[0].Y = Y;

            MyButton[1].X = X + 234;
            MyButton[1].Y = Y + 103;
            MyButton[2].X = X + 234;
            MyButton[2].Y = Y + 19;
            MyButton[3].X = X + 229;
            MyButton[3].Y = Y + 117;
            MyButton[4].X = X;
            MyButton[4].Y = Y;
            MyButton[5].X = X;
            MyButton[5].Y = Y;

            Log.Restriction = new IntRect(X + 3, Y + 21, 223, 87);
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _screen.Draw(s);

            for (int i = 0; i < 4; i++)
            {
                MyButton[i].Draw();
                Log.DrawMessage();
            }

            if (Visibility)
            {
                MyButton[4].Draw();
            }
        }
        public void Update()
        {
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X && x <= X + 20 && y >= Y && y <= Y + 20)
            {
                if (Visibility)
                    MyButton[4].Picked();
                else
                    MyButton[5].Picked();
                //MyButton[16].Picked();
            }

            if (x >= X + 19 && x < X + 230 && y >= Y && y < Y + 13 && Visibility)
                MyButton[0].Picked();

            if (x >= X + 234 && x < X + 250 && y >= Y + 103 && y < Y + 119)
            {
                MyButton[1].Picked();
            }
            if (x >= X + 234 && x <= X + 250 && y >= Y + 19 && y < Y + 35)
            {
                MyButton[2].Picked();
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
        public InGameLog Log { get; set; }
    }
}
