using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    class RightClickWalk : RightClickButton
    {
        RenderWindow _screen;

        public RightClickWalk(RenderWindow rw, int id, int x, int y, int locx, int locy)
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

                Text t = new Text("Walk", Program.Data.Font, 10);
                t.Position = new Vector2f(s.Position.X + 14, s.Position.Y + 3);
                _screen.Draw(t);
            }
        }
        public void Update() { }

        public void Clicked() { }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Program.Data.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                Program.Data.CurrentParty.MainParty.MyParty[0].TargetX = LocX - Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.MinX;
                Program.Data.CurrentParty.MainParty.MyParty[0].TargetY = LocY - Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.MinY;
                Logic.DoPathFinding(Program.Data.CurrentParty.MainParty.MyParty[0]);
                Program.SM.States[1].GameGUI[9].Visibility = false;

            }
        }
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
