using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class DropPickUpAllButton : GUIButton
    {
        RenderWindow _screen;
        public DropPickUpAllButton(RenderWindow rw, int id, int x, int y)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Visibility = true;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                DropGUI g = (DropGUI)Program.SM.States[1].GameGUI[5];
                for (int i = Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX].Count - 1; i >= 0; i--)
                {
                    if (Program.Data.CurrentParty.MainParty.MyParty[0].PickItems(Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][i]))
                        Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][i] = null;
                }
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
    }
}
