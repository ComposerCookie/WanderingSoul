using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class CharacterCreationCharacter : GUIButton
    {
        RenderWindow _screen;
        public CharacterCreationCharacter(RenderWindow rw, int id, int x, int y)
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
        }
        public bool isMouseHover()
        {
            return false;
        }

        public IntRect GetNextFrame()
        {
            IntRect frame = new IntRect(0, 0, 32, 32);
            switch (Frame)
            {
                case 0:
                case 2:
                    frame.Top = 0;
                    frame.Left = 32;
                    break;
                case 1:
                    frame.Top = 0;
                    frame.Left = 0;
                    break;
                case 3:
                    frame.Top = 0;
                    frame.Left = 64;
                    break;
                case 4:
                case 6:
                    frame.Top = 64;
                    frame.Left = 32;
                    break;
                case 5:
                    frame.Top = 64;
                    frame.Left = 0;
                    break;
                case 7:
                    frame.Top = 64;
                    frame.Left = 64;
                    break;
                case 8:
                case 10:
                    frame.Top = 96;
                    frame.Left = 32;
                    break;
                case 9:
                    frame.Top = 96;
                    frame.Left = 0;
                    break;
                case 11:
                    frame.Top = 96;
                    frame.Left = 64;
                    break;
                case 12:
                case 14:
                    frame.Top = 32;
                    frame.Left = 32;
                    break;
                case 13:
                    frame.Top = 32;
                    frame.Left = 0;
                    break;
                case 15:
                    frame.Top = 32;
                    frame.Left = 64;
                    break;
            }
            
            return frame;
        }
        public void Draw()
        {
            CharacterCreationGUI g = (CharacterCreationGUI)Program.State[0].GameGUI[4];
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Body)[Program.Data.GetBodyBasedOnGender(g.CurGender)[g.CurBody].ID]);
            s.Position = new Vector2f(X, Y);
            s.TextureRect = GetNextFrame();
            _screen.Draw(s);
            s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Face)[Program.Data.GetFaceBasedOnGender(g.CurGender)[g.CurFace].ID];
            _screen.Draw(s);
            s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Hair)[Program.Data.GetHairBasedOnGender(g.CurGender)[g.CurHair].ID[g.CurHairColor]];
            _screen.Draw(s);
        }
        public void Update()
        {
            NextFrame++;
            if (NextFrame > 20)
            {
                NextFrame = 0;
                Frame++;
                if (Frame > 15)
                    Frame = 0;
            }
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
        public int Frame { get; set; }
        public int NextFrame { get; set; }
    }
}
