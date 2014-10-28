using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class CraftGUISquareItemButton : GUIButton
    {
        RenderWindow _screen;
        public CraftGUISquareItemButton(RenderWindow rw, int id, int x, int y, int slotid)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            SlotID = slotid;
            Visibility = true;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            //if (Mouse.IsButtonPressed(Mouse.Button.Left))
                //Program.SM.States[1].GameGUI[2].Visibility = !Program.SM.States[1].GameGUI[2].Visibility;
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

            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 14;

            CraftGUI g = (CraftGUI)Program.SM.States[1].GameGUI[10];
            Items i = Program.Data.MyItems[Logic.KnownRecipeForThisCharacter(Logic.CurrentParty.MainParty.MyParty[0], g.CurClass).Count];
            {
                if (SlotID + 3 * g.CurPage < i.ItemRequired.Count)
                {
                    s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[i.ItemRequired.ElementAt(SlotID + 3 * g.CurPage).Key].Sprite]);
                    s.Position = new Vector2f(X, Y);
                    _screen.Draw(s);

                    t.DisplayedString = Program.Data.MyItems[i.ItemRequired.ElementAt(SlotID + 3 * g.CurPage).Key].Name + ": " + i.ItemRequired.ElementAt(SlotID + 3 * g.CurPage).Value;
                    t.Position = new Vector2f(X + 38, Y + 8);
                    _screen.Draw(t);
                }
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
        public int SlotID { get; set; }
        public bool Visibility { get; set; }
    }
}
