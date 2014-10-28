using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class PickPartySelection : GUIButton
    {
        RenderWindow _screen;
        public PickPartySelection(RenderWindow rw, int id, int x, int y, int selectid)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            SelectID = selectid;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            //Logic.MainMap = Program.Generator.NewMap();
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

            PickPartyGUI g = (PickPartyGUI)Program.SM.States[0].GameGUI[1];

            Text t = new Text();
            t.CharacterSize = 11;
            t.Color = Color.White;
            t.Font = Program.Data.Font;

            for (int i = 0; i < 11; i++)
            {
                if (i + g.SaveDown < Program.Data.MyPlayerData.Count)
                {
                    t.DisplayedString = Program.Data.MyPlayerData[i + g.SaveDown].MainParty.MyParty[0].Name + "'s Party";
                    t.Position = new Vector2f(X + 4, Y + 2 + 16 * i);
                    _screen.Draw(t);
                }
            }

            if (Program.Data.MyPlayerData.Count > 0)
            {
                s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[SelectID]);
                s.Position = new Vector2f(X, Y + 16 * g.SelectedParty);
                _screen.Draw(s);
            }
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
        public int SelectID { get; set; }
    }
}
