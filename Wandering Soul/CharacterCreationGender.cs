using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class CharacterCreationGender : GUIButton
    {
        RenderWindow _screen;
        public CharacterCreationGender(RenderWindow rw, int id, int x, int y)
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
        public void Draw()
        {
            CharacterCreationGUI g = (CharacterCreationGUI)Program.State[0].GameGUI[4];
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            switch (g.CurGender)
            {
                case 0:
                    s.Position = new Vector2f(X + 1, Y + 1);
                    break;
                case 1:
                    s.Position = new Vector2f(X + 25, Y + 1);
                    break;
            }
            
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
