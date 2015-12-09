using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class CharacterCreationArrowLeft : GUIButton
    {
        RenderWindow _screen;
        public CharacterCreationArrowLeft(RenderWindow rw, int id, int x, int y, int slotid)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            SlotID = slotid;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            CharacterCreationGUI g = (CharacterCreationGUI)Program.State[0].GameGUI[4];
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                switch (SlotID)
                {
                    case 2:
                        g.CurBody--;
                        if (g.CurBody < 0)
                            g.CurBody = 0;
                        break;
                    case 1:
                        g.CurFace--;
                        if (g.CurFace < 0)
                            g.CurFace = 0;
                        break;
                    case 0:
                        g.CurHair--;
                        if (g.CurHair < 0)
                            g.CurHair = 0;
                        if (Program.Data.GetHairBasedOnGender(g.CurGender)[g.CurHair].ID.Count <= g.CurHairColor)
                        {
                            g.CurHairColor = Program.Data.GetHairBasedOnGender(g.CurGender)[g.CurHair].ID.Count - 1;
                        }
                        break;
                    case 3:
                        g.CurHairColor--;
                        if (g.CurHairColor < 0)
                            g.CurHairColor = 0;
                        break;
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
        public int SlotID { get; set; }
    }
}
