using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class NewWorldGUI : GUI
    {
        RenderWindow _screen;
        public NewWorldGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            X = 290;
            Y = 280;

            MyButton.Add(new NewWorldName(_screen, 89, X + 51, Y + 34));
            MyButton.Add(new NewWorldBack(_screen, 78, X + 147, Y + 219));
            MyButton.Add(new NewWorldOk(_screen, 79, X + 116, Y + 219));

            Clear();

            CurrentButton = 0;
            
        }

        public void Clear()
        {
            CurrentSession = new World();
            NewWorldName b = (NewWorldName)MyButton[0];
            b.Text = "";
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
            if (x >= X + 51 && x <= X + 173 && y >= Y + 34 && y <= Y + 49)
            {
                MyButton[0].Picked();
            }
            else if (x >= X + 147 && x <= X + 174 && y >= Y + 219 && y <= Y + 238)
            {
                MyButton[1].Picked();
            }

            else if (x >= X + 116 && x <= X + 143 && y >= Y + 219 && y <= Y + 238)
            {
                MyButton[2].Picked();
            }
        }

        public void HandleKey(Keyboard.Key key)
        {
            NewWorldName b = (NewWorldName)MyButton[0];
            if (b.Focus)
            {
                if (Keyboard.IsKeyPressed(key))
                {
                    if (key == Keyboard.Key.Back)
                    {
                        if (b.Text.Length > 0)
                            b.Text = b.Text.Remove(b.Text.Length - 1);
                    }
                    else
                    {
                        b.Text += Logic.GetLetterFromKeyboard(key);
                    }
                }
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
        public World CurrentSession { get; set; }
    }
}
