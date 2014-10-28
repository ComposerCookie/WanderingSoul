using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class RightClickCastButton : RightClickButton
    {
        RenderWindow _screen;

        public RightClickCastButton(RenderWindow rw, int id, int x, int y, int locx, int locy)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Visibility = true;
            LocX = locx;
            LocY = locy;
        }

        public void Draw()
        {
            if (Visibility)
            {
                SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
                s.Position = new Vector2f(X, Y);
                _screen.Draw(s);

                Text t = new Text("Cast", Program.Data.Font, 10);
                t.Position = new Vector2f(s.Position.X, s.Position.Y);
                _screen.Draw(t);
            }
        }
        public void Update()
        {
        }

        public void Clicked()
        {
        }
        public void Picked() { }
        public bool isMouseHover() { return false; }
        public bool isFocused() { return false; }
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Visibility { get; set; }

        public int LocX { get; set; }
        public int LocY { get; set; }
    }
}
