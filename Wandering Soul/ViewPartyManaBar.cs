using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class ViewPartyManaBar : GUIButton
    {
        RenderWindow _screen;
        public ViewPartyManaBar(RenderWindow rw, int id, int barid,int x, int y, int slotid)
        {
            _screen = rw;
            ID = id;
            BarID = barid;
            X = x;
            Y = y;
            SlotID = slotid;
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
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);

            PickPartyGUI g = (PickPartyGUI)Program.SM.States[0].GameGUI[1];
            if (g.SelectedParty > -1 && g.SelectedParty < Program.Data.MyPlayerDatas.Count && Program.Data.MyPlayerDatas[g.SelectedParty] != null)
            {
                if (SlotID < Program.Data.MyPlayerDatas[g.SelectedParty].MainParty.MyParty.Count)
                {
                    s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Button)[BarID];
                    s.Position = new Vector2f(X + 2, Y + 2);
                    s.TextureRect = new IntRect(0, 0, Program.Data.MyPlayerDatas[g.SelectedParty].MainParty.MyParty[SlotID].CurMana * 100 / Logic.GetMaxManaBasedOnStat(Program.Data.MyPlayerDatas[g.SelectedParty].MainParty.MyParty[SlotID]) * (int)s.Texture.Size.X / 100, (int)s.Texture.Size.Y);
                    _screen.Draw(s);
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
        public int BarID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Visibility { get; set; }
        public int SlotID { get; set; }
    }
}
