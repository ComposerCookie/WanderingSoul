using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class EquipmentGUI : GUI
    {
        RenderWindow _screen;
        public EquipmentGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 100;
            Y = 500;
            Visibility = false;

            MyButton.Add(new GUIClose(rw, 20, X + 120, Y, 2, 1));
            MyButton.Add(new GUIHead(rw, 22, X, Y, 2, 1));

            MyButton.Add(new EquipmentSlot(_screen, 9, X + 104, Y + 25, (int)ItemType.Ammunition));
            MyButton.Add(new EquipmentSlot(_screen, 10, X + 68, Y + 89, (int)ItemType.Armor));
            MyButton.Add(new EquipmentSlot(_screen, 11, X + 69, Y + 132, (int)ItemType.Boot));
            MyButton.Add(new EquipmentSlot(_screen, 12, X + 6, Y + 62, (int)ItemType.Bracelet));
            MyButton.Add(new EquipmentSlot(_screen, 13, X + 104, Y + 60, (int)ItemType.Cape));
            MyButton.Add(new EquipmentSlot(_screen, 14, X + 68, Y + 46, (int)ItemType.Helmet));
            MyButton.Add(new EquipmentSlot(_screen, 15, X + 6, Y + 26, (int)ItemType.Necklace));
            MyButton.Add(new EquipmentSlot(_screen, 16, X + 104, Y + 95, (int)ItemType.Offhand));
            MyButton.Add(new EquipmentSlot(_screen, 17, X + 5, Y + 128, (int)ItemType.Ring));
            MyButton.Add(new EquipmentSlot(_screen, 17, X + 5, Y + 163, (int)ItemType.Ring));
            MyButton.Add(new EquipmentSlot(_screen, 18, X + 103, Y + 163, (int)ItemType.Storage));
            MyButton.Add(new EquipmentSlot(_screen, 19, X + 33, Y + 95, (int)ItemType.Weapon));

            EquipmentSlot e = (EquipmentSlot)MyButton[13];
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
            MyButton[0].X = X + 120; MyButton[0].Y = Y;
            MyButton[1].X = X; MyButton[1].Y = Y;
            MyButton[2].X = X + 104; MyButton[2].Y = Y + 25;
            MyButton[3].X = X + 68; MyButton[3].Y = Y + 89;
            MyButton[4].X = X + 69; MyButton[4].Y = Y + 132;
            MyButton[5].X = X + 6; MyButton[5].Y = Y + 62;
            MyButton[6].X = X + 104; MyButton[6].Y = Y + 60;
            MyButton[7].X = X + 68; MyButton[7].Y = Y + 46;
            MyButton[8].X = X + 6; MyButton[8].Y = Y + 26;
            MyButton[9].X = X + 104; MyButton[9].Y = Y + 95;
            MyButton[10].X = X + 5; MyButton[10].Y = Y + 128;
            MyButton[11].X = X + 5; MyButton[11].Y = Y + 163;
            MyButton[12].X = X + 103; MyButton[12].Y = Y + 163;
            MyButton[13].X = X + 33; MyButton[13].Y = Y + 95;
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
            if (x >= X + 120 && x <= X + 140 && y >= Y && y <= Y + 20)
            {
                MyButton[0].Picked();
            }

            if (x >= X + 0 && x <= X + 120 && y >= Y && y <= Y + 20)
            {
                MyButton[1].Picked();
            }

            if (x >= X + 104 && x <= X + 136 && y >= Y + 25 && y <= Y + 57)
            {
                MyButton[2].Picked();
            }
            if (x >= X + 68 && x <= X + 100 && y >= Y + 89 && y <= Y + 121)
            {
                MyButton[3].Picked();
            }
            if (x >= X + 69 && x <= X + 101 && y >= Y + 132 && y <= Y + 164)
            {
                MyButton[4].Picked();
            }
            if (x >= X + 6 && x <= X + 32 && y >= Y + 62 && y <= Y + 94)
            {
                MyButton[5].Picked();
            }
            if (x >= X + 104 && x <= X + 136 && y >= Y + 60 && y <= Y + 92)
            {
                MyButton[6].Picked();
            }
            if (x >= X + 68 && x <= X + 100 && y >= Y + 46 && y <= Y + 78)
            {
                MyButton[7].Picked();
            }
            if (x >= X + 6 && x <= X + 38 && y >= Y + 26 && y <= Y + 58)
            {
                MyButton[8].Picked();
            }
            if (x >= X + 104 && x <= X + 136 && y >= Y + 95 && y <= Y + 127)
            {
                MyButton[9].Picked();
            }
            if (x >= X + 5 && x <= X + 37 && y >= Y + 128 && y <= Y + 160)
            {
                MyButton[10].Picked();
            }
            if (x >= X + 5 && x <= X + 37 && y >= Y + 163 && y <= Y + 195)
            {
                MyButton[11].Picked();
            }
            if (x >= X + 103 && x <= X + 135 && y >= Y + 163 && y <= Y + 195)
            {
                MyButton[12].Picked();
            }
            if (x >= X + 33 && x <= X + 65 && y >= Y + 95 && y <= Y + 127)
            {
                MyButton[13].Picked();
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
    }
}
