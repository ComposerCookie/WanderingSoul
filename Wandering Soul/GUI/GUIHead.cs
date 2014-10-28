using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class GUIHead : GUIButton
    {
        RenderWindow _screen;
        public GUIHead(RenderWindow rw, int id, int x, int y, int gui, int state)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            GUIID = gui;
            StateID = state;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                TempX = Mouse.GetPosition(_screen).X - Program.SM.States[StateID].GameGUI[GUIID].X;
                TempY = Mouse.GetPosition(_screen).Y - Program.SM.States[StateID].GameGUI[GUIID].Y;
                Program.SM.States[StateID].CurrentGUI = GUIID;
                Program.SM.States[StateID].GameGUI[GUIID].Moving = true;
                Program.MouseState = (int)MouseStateType.Dragging;
            }

            else
            {
                Program.SM.States[StateID].GameGUI[GUIID].Moving = false;
                Program.MouseState = (int)MouseStateType.Normal;
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
        }
        public void Update()
        {
        }
        public bool isFocused()
        {
            return false;
        }
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Visibility { get; set; }
        public int GUIID { get; set; }
        public int StateID { get; set; }

        public int TempX { get; set; }
        public int TempY { get; set; }
    }
}
