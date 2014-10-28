using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class CharacterCreationArrowRight : GUIButton
    {
        RenderWindow _screen;
        public CharacterCreationArrowRight(RenderWindow rw, int id, int x, int y, int slotid)
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
            CharacterCreationGUI g = (CharacterCreationGUI)Program.SM.States[0].GameGUI[4];
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                switch (SlotID)
                {
                    case 2:
                        g.CurBody++;
                        if (g.CurBody >= Program.Data.GetBodyBasedOnGender(g.CurGender).Count)
                            g.CurBody = Program.Data.GetBodyBasedOnGender(g.CurGender).Count - 1;
                        break;
                    case 1:
                        g.CurFace++;
                        if (g.CurFace >= Program.Data.GetFaceBasedOnGender(g.CurGender).Count)
                            g.CurFace = Program.Data.GetFaceBasedOnGender(g.CurGender).Count - 1;
                        break;
                    case 0:
                        g.CurHair++;
                        if (g.CurHair >= Program.Data.GetHairBasedOnGender(g.CurGender).Count)
                            g.CurHair = Program.Data.GetHairBasedOnGender(g.CurGender).Count - 1;
                        if (Program.Data.GetHairBasedOnGender(g.CurGender)[g.CurHair].ID.Count <= g.CurHairColor)
                        {
                            g.CurHairColor = Program.Data.GetHairBasedOnGender(g.CurGender)[g.CurHair].ID.Count - 1;
                        }
                        break;
                    case 3:
                        g.CurHairColor++;
                        if (g.CurHairColor >= Program.Data.GetHairBasedOnGender(g.CurGender)[g.CurHair].ID.Count)
                            g.CurHairColor = Program.Data.GetHairBasedOnGender(g.CurGender)[g.CurHair].ID.Count - 1;
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
