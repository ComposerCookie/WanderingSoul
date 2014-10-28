using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class PickWorldGUI : GUI
    {
        RenderWindow _screen;
        public PickWorldGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            X = 820;
            Y = 480;

            SelectedWorld = 0;

            MyButton.Add(new PickWorldSelection(_screen, 75, X + 8, Y + 41, 87));
            MyButton.Add(new PickMoreWorldUp(_screen, 72, X + 153, Y + 41));
            MyButton.Add(new PickMoreWorldDown(_screen, 71, X + 153, Y + 205));
            MyButton.Add(new PickWorldMoreBar(_screen, 70, X + 153, Y + 60));
            MyButton.Add(new PickWorldLoading(_screen, 74, X + 8, Y + 228));
            MyButton.Add(new PickWorldNewWorld(_screen, 73, X + 114, Y + 228));
            MyButton.Add(new PickWorldPickButton(_screen, 79, X + 83, Y + 228));
            MyButton.Add(new PickWorldDeleteButton(_screen, 78, X + 145, Y + 228));
            MyButton.Add(new PickWorldBackButton(_screen, 20, X + 156, Y + 4));
            CurrentButton = 0;
            Visibility = false;
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
            if (x >= X + 8 && x <= X + 154 && y >= Y + 41 && y <= Y + 224)
            {
                //MyButton[0].Picked();
                for (int i = 0; i < 11; i++)
                {
                    if (y >= Y + 41 + i * 16 && y < Y + 41 + (i + 1) * 16)
                        SelectedWorld = i;
                }
            }
            else if (x >= X + 153 && x <= X + 172 && y >= Y + 41 && y <= Y + 60)
            {
                MyButton[1].Picked();
            }
            else if (x >= X + 153 && x <= X + 172 && y >= Y + 205 && y <= Y + 224)
            {
                MyButton[2].Picked();
            }
            else if (x >= X + 153 && x <= X + 172 && y >= Y + 60 && y <= Y + 79)
            {
                MyButton[3].Picked();
            }
            else if (x >= X + 8 && x <= X + 79 && y >= Y + 228 && y <= Y + 242)
            {
                MyButton[4].Picked();
            }
            else if (x >= X + 114 && x <= X + 141 && y >= Y + 228 && y <= Y + 247)
            {
                MyButton[5].Picked();
            }
            else if (x >= X + 83 && x <= X + 110 && y >= Y + 228 && y <= Y + 247)
            {
                MyButton[6].Picked();
            }
            else if (x >= X + 145 && x <= X + 172 && y >= Y + 228 && y <= Y + 247)
            {
                MyButton[7].Picked();
            }
            else if (x >= X + 156 && x <= X + 176 && y >= Y + 4 && y <= Y + 24)
            {
                MyButton[8].Picked();
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
        public int SaveDown { get; set; }
        public int SelectedWorld { get; set; }
    }
}
