using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class NewPartyCharacterEdit : GUIButton
    {
        RenderWindow _screen;
        public NewPartyCharacterEdit(RenderWindow rw, int id, int x, int y, int slotID)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            SlotID = slotID;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {

        }
        public bool isMouseHover()
        {
            return false;
        }
        public void Draw()
        {
            NewPartyGUI g = (NewPartyGUI)Program.SM.States[0].GameGUI[3];
            if (SlotID < g.CurrentSession.MainParty.MyParty.Count && SlotID < Program.Data.PartySlotUnlock)
            {
                SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
                s.Position = new Vector2f(X, Y);
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
        public int SlotID { get; set; }
    }
}
