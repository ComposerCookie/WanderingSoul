using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class NewWorldName : GUIButton
    {
        RenderWindow _screen;
        public NewWorldName(RenderWindow rw, int id, int x, int y)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Focus = false;
            Text = "";
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Focus = true;
            }
        }
        public bool isMouseHover()
        {
            return false;
        }
        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);

            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 9;
            t.Position = new Vector2f(X + 3, Y + 3);
            t.DisplayedString = Text;
            _screen.Draw(t);
        }
        public void Update()
        {
        }
        public bool isFocused()
        {
            return false;
        }
        public string Text { get; set; }
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Visibility { get; set; }
        public bool Focus { get; set; }
    }
}
