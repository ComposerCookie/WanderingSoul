using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class HUDHealthBar : GUIButton
    {
        RenderWindow _screen;
        public HUDHealthBar(RenderWindow rw, int id, int x, int y)
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
            //if (Mouse.IsButtonPressed(Mouse.Button.Left))
            //Program.SM.States[1].GameGUI[1].Visibility = !Program.SM.States[1].GameGUI[1].Visibility;
        }
        public bool isMouseHover()
        {
            return false;
        }
        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            for (int p = 0; p < Logic.CurrentParty.MainParty.MyParty.Count; p++)
            {
                s.Position = new Vector2f(X, Y + (Program.Data.SpriteBasedOnType(SpriteType.GUI)[Program.SM.States[1].GameGUI[3].ID].Size.Y + 10) * p);
                s.TextureRect = new IntRect(0, 0, Logic.CurrentParty.MainParty.MyParty[p].CurrentHealth * 100  / Logic.CurrentParty.MainParty.MyParty[p].MaxHealth * (int)s.Texture.Size.X / 100, (int)s.Texture.Size.Y);
                _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
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
