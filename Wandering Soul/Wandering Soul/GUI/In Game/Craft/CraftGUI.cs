using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class CraftGUI : GUI
    {
        RenderWindow _screen;
        public CraftGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 200;
            Y = 400;
            Visibility = false;

            MyButton.Add(new GUIClose(rw, 20, X + 150, Y, 10, 1));
            MyButton.Add(new GUIHead(rw, 55, X, Y, 10, 1));

            MyButton.Add(new CraftGUIClassLeftButton(rw, 46, X + 4, Y + 22));
            MyButton.Add(new CraftGUIClassRightButton(rw, 47, X + 155, Y + 22));
            MyButton.Add(new CraftGUIPickArrowUp(rw, 51, X + 2, Y + 57));
            MyButton.Add(new CraftGUIPickArrowDown(rw, 50, X + 2, Y + 199));
            MyButton.Add(new CraftGUIArrowLeftButton(rw, 44, X + 53, Y + 189));
            MyButton.Add(new CraftGUIArrowRightButton(rw, 45, X + 104, Y + 189));
            MyButton.Add(new CraftGUIOkButton(rw, 49, X + 130, Y + 190));

            MyButton.Add(new CraftGUISquareClassButton(rw, 7, X + 16, Y + 22));
            MyButton.Add(new CraftGUISquareClassButton(rw, 7, X + 51, Y + 22));
            MyButton.Add(new CraftGUISquareClassButton(rw, 7, X + 86, Y + 22));
            MyButton.Add(new CraftGUISquareClassButton(rw, 7, X + 121, Y + 22));

            MyButton.Add(new CraftGUISquarePickButton(rw, 7, X + 2, Y + 67, 0));
            MyButton.Add(new CraftGUISquarePickButton(rw, 7, X + 2, Y + 100, 1));
            MyButton.Add(new CraftGUISquarePickButton(rw, 7, X + 2, Y + 133, 2));
            MyButton.Add(new CraftGUISquarePickButton(rw, 7, X + 2, Y + 166, 3));

            MyButton.Add(new CraftGUISquareItemButton(rw, 54, X + 37, Y + 86, 0));
            MyButton.Add(new CraftGUISquareItemButton(rw, 54, X + 37, Y + 119, 1));
            MyButton.Add(new CraftGUISquareItemButton(rw, 54, X + 37, Y + 152, 2));
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

            MyButton[2].X = X + 4; MyButton[2].Y = Y + 22;
            MyButton[3].X = X + 155; MyButton[3].Y = Y + 22;

            MyButton[4].X = X + 2; MyButton[4].Y = Y + 57;
            MyButton[5].X = X + 2; MyButton[5].Y = Y + 199;

            MyButton[6].X = X + 53; MyButton[6].Y = Y + 189;
            MyButton[7].X = X + 104; MyButton[7].Y = Y + 189;
            MyButton[8].X = X + 130; MyButton[8].Y = Y + 190;

            MyButton[9].X = X + 16; MyButton[9].Y = Y + 22;
            MyButton[10].X = X + 51; MyButton[10].Y = Y + 22;
            MyButton[11].X = X + 86; MyButton[11].Y = Y + 22;
            MyButton[12].X = X + 121; MyButton[12].Y = Y + 22;

            MyButton[13].X = X + 2; MyButton[13].Y = Y + 67;
            MyButton[14].X = X + 2; MyButton[14].Y = Y + 100;
            MyButton[15].X = X + 2; MyButton[15].Y = Y + 133;
            MyButton[16].X = X + 2; MyButton[16].Y = Y + 166;

            MyButton[17].X = X + 37; MyButton[17].Y = Y + 86;
            MyButton[18].X = X + 37; MyButton[18].Y = Y + 119;
            MyButton[19].X = X + 37; MyButton[19].Y = Y + 152;
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
            if (x >= X + 150 && x <= X + 170 && y >= Y && y <= Y + 20)
            {
                MyButton[0].Picked();
            }

            else if (x >= X && x <= X + 150 && y >= Y && y <= Y + 20)
            {
                MyButton[1].Picked();
            }
            else if (x >= X + 4 && x <= X + 14 && y >= Y + 22 && y <= Y + 54)
            {
                MyButton[2].Picked();
            }
            else if (x >= X + 155 && x <= X + 165 && y >= Y + 22 && y <= Y + 54)
            {
                MyButton[3].Picked();
            }
            else if (x >= X + 2 && x <= X + 34 && y >= Y + 57 && y <= Y + 66)
            {
                MyButton[4].Picked();
            }
            else if (x >= X + 2 && x <= X + 34 && y >= Y + 199 && y <= Y + 208)
            {
                MyButton[5].Picked();
            }
            else if (x >= X + 53 && x <= X + 63 && y >= Y + 189 && y <= Y + 208)
            {
                MyButton[6].Picked();
            }
            else if (x >= X + 104 && x <= X + 114 && y >= Y + 189 && y <= Y + 208)
            {
                MyButton[7].Picked();
            }
            else if (x >= X + 130 && x <= X + 159 && y >= Y + 190 && y <= Y + 210)
            {
                MyButton[8].Picked();
            }
            else if (x >= X + 16 && x <= X + 48 && y >= Y + 22 && y <= Y + 54)
            {
                MyButton[9].Picked();
            }
            else if (x >= X + 51 && x <= X + 83 && y >= Y + 22 && y <= Y + 54)
            {
                MyButton[10].Picked();
            }
            else if (x >= X + 86 && x <= X + 118 && y >= Y + 22 && y <= Y + 54)
            {
                MyButton[11].Picked();
            }
            else if (x >= X + 121 && x <= X + 153 && y >= Y + 22 && y <= Y + 54)
            {
                MyButton[12].Picked();
            }
            else if (x >= X + 2 && x <= X + 34 && y >= Y + 67 && y <= Y + 99)
            {
                MyButton[13].Picked();
            }
            else if (x >= X + 2 && x <= X + 34 && y >= Y + 100 && y <= Y + 132)
            {
                MyButton[14].Picked();
            }
            else if (x >= X + 2 && x <= X + 34 && y >= Y + 133 && y <= Y + 165)
            {
                MyButton[15].Picked();
            }
            else if (x >= X + 2 && x <= X + 34 && y >= Y + 166 && y <= Y + 198)
            {
                MyButton[16].Picked();
            }
            else if (x >= X + 37 && x <= X + 69 && y >= Y + 86 && y <= Y + 118)
            {
                MyButton[17].Picked();
            }
            else if (x >= X + 37 && x <= X + 69 && y >= Y + 119 && y <= Y + 151)
            {
                MyButton[18].Picked();
            }
            else if (x >= X + 37 && x <= X + 69 && y >= Y + 152 && y <= Y + 184)
            {
                MyButton[19].Picked();
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
