using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class BuildGUI : GUI
    {
        RenderWindow _screen;
        public BuildGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 200;
            Y = 200;
            Visibility = false;

            MyButton.Add(new GUIClose(rw, 20, X + 230, Y, 8, 1));
            MyButton.Add(new GUIHead(rw, 48, X, Y, 8, 1));

            MyButton.Add(new BuildGUIClassLeftButton(rw, 46, X + 7, Y + 24));
            MyButton.Add(new BuildGUIClassRightButton(rw, 47, X + 219, Y + 24));
            MyButton.Add(new BuildGUIPickArrowUp(rw, 51, X + 7, Y + 71));
            MyButton.Add(new BuildGUIPickArrowDown(rw, 50, X + 7, Y + 218));
            MyButton.Add(new BuildGUIArrowLeftButton(rw, 44, X + 131, Y + 229));
            MyButton.Add(new BuildGUIArrowRightButton(rw, 45, X + 178, Y + 229));
            MyButton.Add(new BuildGUIOkButton(rw, 49, X + 193, Y + 220));

            MyButton.Add(new BuildGUISquareClassButton(rw, 52, X + 44, Y + 27));
            MyButton.Add(new BuildGUISquareClassButton(rw, 52, X + 87, Y + 27));
            MyButton.Add(new BuildGUISquareClassButton(rw, 52, X + 130, Y + 27));
            MyButton.Add(new BuildGUISquareClassButton(rw, 52, X + 173, Y + 27));

            MyButton.Add(new BuildGUISquarePickButton(rw, 52, X + 14, Y + 103, 0));
            MyButton.Add(new BuildGUISquarePickButton(rw, 52, X + 14, Y + 141, 1));
            MyButton.Add(new BuildGUISquarePickButton(rw, 52, X + 14, Y + 179, 2));

            MyButton.Add(new BuildGUISquareItemButton(rw, 52, X + 73, Y + 120, 0));
            MyButton.Add(new BuildGUISquareItemButton(rw, 52, X + 73, Y + 158, 1));
            MyButton.Add(new BuildGUISquareItemButton(rw, 52, X + 73, Y + 196, 2));
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
            MyButton[0].X = X + 230; MyButton[0].Y = Y;
            MyButton[1].X = X; MyButton[1].Y = Y;
            MyButton[2].X = X + 7; MyButton[2].Y = Y + 24;
            MyButton[3].X = X + 219; MyButton[3].Y = Y + 24;
            MyButton[4].X = X + 7; MyButton[4].Y = Y + 71;
            MyButton[5].X = X + 7; MyButton[5].Y = Y + 218;
            MyButton[6].X = X + 131; MyButton[6].Y = Y + 229;
            MyButton[7].X = X + 178; MyButton[7].Y = Y + 229;
            MyButton[8].X = X + 193; MyButton[8].Y = Y + 220;
            MyButton[9].X = X + 44; MyButton[9].Y = Y + 27;
            MyButton[10].X = X + 87; MyButton[10].Y = Y + 27;
            MyButton[11].X = X + 130; MyButton[11].Y = Y + 27;
            MyButton[12].X = X + 173; MyButton[12].Y = Y + 27;
            MyButton[13].X = X + 14; MyButton[13].Y = Y + 103;
            MyButton[14].X = X + 14; MyButton[14].Y = Y + 141;
            MyButton[15].X = X + 14; MyButton[15].Y = Y + 179;
            MyButton[16].X = X + 73; MyButton[16].Y = Y + 120;
            MyButton[17].X = X + 73; MyButton[17].Y = Y + 158;
            MyButton[18].X = X + 73; MyButton[18].Y = Y + 196;
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _screen.Draw(s);

            foreach(GUIButton b in MyButton)
            {
                b.Draw();
            }
        }
        public void Update()
        {
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X + 230 && x <= X + 250 && y >= Y && y <= Y + 20)
            {
                MyButton[0].Picked();
            }

            else if (x >= X && x <= X + 230 && y >= Y && y <= Y + 20)
            {
                MyButton[1].Picked();
            }
            else if (x >= X + 7 && x <= X + 33 && y >= Y + 24 && y <= Y + 63)
            {
                MyButton[2].Picked();
            }
            else if (x >= X + 219 && x <= X + 245 && y >= Y + 24 && y <= Y + 63)
            {
                MyButton[3].Picked();
            }
            else if (x >= X + 7 && x <= X + 55 && y >= Y + 71 && y <= Y + 96)
            {
                MyButton[4].Picked();
            }
            else if (x >= X + 7 && x <= X + 55 && y >= Y + 218 && y <= Y + 243)
            {
                MyButton[5].Picked();
            }
            else if (x >= X + 131 && x <= X + 138 && y >= Y + 229 && y <= Y + 242)
            {
                MyButton[6].Picked();
            }
            else if (x >= X + 178 && x <= X + 185 && y >= Y + 229 && y <= Y + 242)
            {
                MyButton[7].Picked();
            }
            else if (x >= X + 193 && x <= X + 237 && y >= Y + 220 && y <= Y + 249)
            {
                MyButton[8].Picked();
            }
            else if (x >= X + 44 && x <= X + 77 && y >= Y + 27 && y <= Y + 60)
            {
                MyButton[9].Picked();
            }
            else if (x >= X + 87 && x <= X + 120 && y >= Y + 27 && y <= Y + 60)
            {
                MyButton[10].Picked();
            }
            else if (x >= X + 130 && x <= X + 163 && y >= Y + 27 && y <= Y + 60)
            {
                MyButton[11].Picked();
            }
            else if (x >= X + 173 && x <= X + 206 && y >= Y + 27 && y <= Y + 60)
            {
                MyButton[12].Picked();
            }
            else if (x >= X + 14 && x <= X + 47 && y >= Y + 103 && y <= Y + 136)
            {
                MyButton[13].Picked();
            }
            else if (x >= X + 14 && x <= X + 47 && y >= Y + 141 && y <= Y + 174)
            {
                MyButton[14].Picked();
            }
            else if (x >= X + 14 && x <= X + 47 && y >= Y + 179 && y <= Y + 212)
            {
                MyButton[15].Picked();
            }
            else if (x >= X + 73 && x <= X + 106 && y >= Y + 120 && y <= Y + 153)
            {
                MyButton[16].Picked();
            }
            else if (x >= X + 73 && x <= X + 106 && y >= Y + 158 && y <= Y + 191)
            {
                MyButton[17].Picked();
            }
            else if (x >= X + 73 && x <= X + 106 && y >= Y + 196 && y <= Y + 229)
            {
                MyButton[18].Picked();
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
        public int PickPage { get; set; }
        public int CurPick { get; set; }
        public int CurClass { get; set; }
        public int CurPage { get; set; }
    }
}
