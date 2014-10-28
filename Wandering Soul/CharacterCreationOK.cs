using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class CharacterCreationOK : GUIButton
    {
        RenderWindow _screen;
        public CharacterCreationOK(RenderWindow rw, int id, int x, int y)
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
            CharacterCreationGUI g = (CharacterCreationGUI)Program.SM.States[0].GameGUI[4];
            CharacterCreationName b = (CharacterCreationName)g.MyButton[1];
            if (b.Text.Equals(""))
            {

            }
            else
            {
                NPC n = new NPC(b.Text, (int)LivingObjectType.NPC, g.CurGender, 0, false, g.CurBody, g.CurFace, g.CurHair, g.CurHairColor, (int)MapType.MainMap, true, 4, 8, 0, g.CurrentSession.MyParty.Count);
                n.Inventory.PutItem(new SpawnItems(1));
                g.CurrentSession.MyParty.Add(n);
            }
            Program.SM.States[0].GameGUI[4].Visibility = false;
            Program.SM.States[0].GameGUI[3].Visibility = true;
            Program.SM.States[0].CurrentGUI = 3;
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
