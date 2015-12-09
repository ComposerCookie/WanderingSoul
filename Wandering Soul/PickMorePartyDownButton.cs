using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class PickMorePartyDownButton : GUIButton
    {
        RenderWindow _screen;
        public PickMorePartyDownButton(RenderWindow rw, int id, int x, int y)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            //Logic.MainMap = Program.Generator.NewMap();
            PickPartyGUI g = (PickPartyGUI)Program.State[0].GameGUI[1];
            if (g.SaveDown + 11 < Program.Data.MyPlayerData.Count)
                g.SaveDown++;
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
