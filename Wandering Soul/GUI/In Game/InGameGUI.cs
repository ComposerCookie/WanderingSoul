using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class InGameGUI : GUI
    {
        RenderWindow _screen;
        public InGameGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = (int)rw.Size.X - 400;
            Y = (int)rw.Size.Y - 50;
            MyButton.Add(new InventoryButton(_screen, 5, X + 7, Y));
            MyButton.Add(new EquipmentButton(_screen, 6, X + 87, Y));
            MyButton.Add(new ActionButton(_screen, 43, X + 127, Y));
            MyButton.Add(new KnowledgeButton(_screen, 66, X + 167, Y));
            Visibility = true;
        }

        public void HandleMouseMove()
        {
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _screen.Draw(s);

            foreach (GUIButton b in MyButton)
            {
                if (b.Visibility)
                    b.Draw();
            }
        }

        public void Resize()
        {
        }

        public void Update()
        {
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X + 7 && x <= X + 42 && y >= Y && y <= Y + 25)
            {
                MyButton[0].Picked();
            }

            if (x >= X + 87 && x <= X + 122 && y >= Y && y <= Y + 25)
            {
                MyButton[1].Picked();
            }

            if (x >= X + 127 && x <= X + 162 && y >= Y && y <= Y + 25)
            {
                MyButton[2].Picked();
            }

            if (x >= X + 167 && x <= X + 202 && y >= Y && y <= Y + 25)
            {
                MyButton[3].Picked();
            }
        }

        public void HandleKey(Keyboard.Key key)
        {
            switch (key)
            {
                case Keyboard.Key.I:
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
