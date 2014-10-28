using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class DropGUI : GUI
    {
        RenderWindow _screen;
        public DropGUI(RenderWindow rw, int id, int x, int y)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 700;
            Y = 300;
            Visibility = false;

            ScrollCount = 0;


            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    MyButton.Add(new DropGUISlotButton(_screen, 7, c * 32 + c * 6 + X + 6, r * 32 + r * 6 + Y + 26, r * 4 + c));
                }
            }
            //PlayerInventorySizeChange();

            MyButton.Add(new GUIClose(rw, 20, X + 158, Y, 5, 1));
            MyButton.Add(new GUIHead(rw, 35, X, Y, 5, 1));
            MyButton.Add(new DropPickUpAllButton(rw, 36, X + 155, Y + 111));
            //MyButton.Add(new InventoryQuickCraftButton(rw, 32, X + 155, Y + 29));
            //MyButton.Add(new InventoryDropAllButton(rw, 33, X + 155, Y + 128));
            //MyButton.Add(new InventoryDestroyButton(rw, 34, X + 155, Y + 151));
        }


        public void HandleMouseMove()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (Moving)
                {
                    GUIHead g = (GUIHead)MyButton[13];
                    X = Mouse.GetPosition(_screen).X - g.TempX;
                    Y = Mouse.GetPosition(_screen).Y - g.TempY;
                    Resize();
                }
            }
        }

        public void Resize()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    MyButton[r * 4 + c].X = c * 32 + c * 6 + X + 6;
                    MyButton[r * 4 + c].Y = r * 32 + r * 6 + Y + 26;
                }
            }

            MyButton[12].X = X + 158; MyButton[12].Y = Y;
            MyButton[13].X = X; MyButton[13].Y = Y;
            MyButton[14].X = X + 155; MyButton[14].Y = Y + 111;
            //MyButton[19].X = X + 155; MyButton[19].Y = Y + 128;
            //MyButton[20].X = X + 155; MyButton[20].Y = Y + 151;
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
            if (x >= X + 158 && x <= X + 178 && y >= Y && y <= Y + 20)
            {
                MyButton[12].Picked();
            }

            if (x >= X + 0 && x <= X + 158 && y >= Y && y <= Y + 20)
            {
                MyButton[13].Picked();
            }

            if (x >= X + 155 && x <= X + 172 && y >= Y + 111 && y <= Y + 128)
            {
                MyButton[14].Picked();
            }

            if (x >= X + 155 && x <= X + 172 && y >= Y + 121 && y <= Y + 138)
            {
                //MyButton[19].Picked();
            }

            if (x >= X + 155 && x <= X + 172 && y >= Y + 158 && y <= Y + 175)
            {
                //MyButton[20].Picked();
            }

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    if (x >= X + (c * 38) + 6 && x <= X + 38 * (c + 1) && y >= Y + 26 + (r * 38) && y <= Y + (r + 1) * 38 + 26)
                    {
                        MyButton[r * 4 + c].Picked();
                        break;
                    }
                }
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
        public int ScrollCount { get; set; }
        public int DropX { get; set; }
        public int DropY { get; set; }
    }
}
