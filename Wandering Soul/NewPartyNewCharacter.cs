using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class NewPartyNewCharacter : GUIButton
    {
        RenderWindow _screen;
        public NewPartyNewCharacter(RenderWindow rw, int id, int x, int y)
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
            NewPartyGUI g = (NewPartyGUI)Program.State[0].GameGUI[3];
            if (g.CurrentSession.MainParty.MyParty.Count < 4 && g.CurrentSession.MainParty.MyParty.Count < Program.Data.PartySlotUnlock)
            {
                CharacterCreationGUI c = (CharacterCreationGUI)Program.State[0].GameGUI[4];
                c.Initialize(g.CurrentSession.MainParty);
                Program.State[0].GameGUI[3].Visibility = false;
                Program.State[0].GameGUI[4].Visibility = true;
                Program.State[0].CurrentGUI = 4;
            }
        }
        public bool isMouseHover()
        {
            return false;
        }
        public void Draw()
        {
            NewPartyGUI g = (NewPartyGUI)Program.State[0].GameGUI[3];
            if (g.CurrentSession.MainParty.MyParty.Count < 4 && g.CurrentSession.MainParty.MyParty.Count < Program.Data.PartySlotUnlock)
            {
                SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
                s.Position = new Vector2f(X + 119 * g.CurrentSession.MainParty.MyParty.Count, Y);
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
    }
}
