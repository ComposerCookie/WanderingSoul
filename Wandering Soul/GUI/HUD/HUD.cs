using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class HUD : GUI
    {
        RenderWindow _screen;
        public HUD(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 50;
            Y = 50;
            Visibility = true;

            MyButton.Add(new HUDHealthBar(rw, 23, X + 51, Y + 13));
            MyButton.Add(new HUDManaBar(rw, 24, X + 51, Y + 25));
            MyButton.Add(new HUDExperienceBar(_screen, 25, X + 51, Y + 36));
        }

        public void HandleMouseMove()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
            }
        }

        public void Resize()
        {
        }

        public void Draw()
        {
            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 10;
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            for (int p = 0; p < Logic.CurrentParty.MainParty.MyParty.Count; p++)
            {
                s.Position = new Vector2f(X, Y + (s.Texture.Size.Y + 10) * p);
                _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
                _screen.Draw(s);

                t.DisplayedString = Logic.CurrentParty.MainParty.MyParty[p].Name;
                t.Position = new Vector2f(X + 50, Y + (s.Texture.Size.Y + 10) * p - 1);
                _screen.Draw(t);

                t.DisplayedString = "Level: " + Logic.CurrentParty.MainParty.MyParty[p].Level;
                t.Position = new Vector2f(X + 100, Y + (s.Texture.Size.Y + 10) * p + 38);
                _screen.Draw(t);

                t.DisplayedString = Enum.GetName(typeof(JobType),(JobType)Logic.CurrentParty.MainParty.MyParty[p].Job);
                t.Position = new Vector2f(X + 50, Y + (s.Texture.Size.Y + 10) * p + 38);
                _screen.Draw(t);
            }
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
            if (x >= X + 158 && x <= X + 158 && y >= Y && y <= Y + 20)
            {
                //MyButton[16].Picked();
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
