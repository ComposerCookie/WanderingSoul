using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class BuildGUISquarePickButton : GUIButton
    {
        RenderWindow _screen;
        public BuildGUISquarePickButton(RenderWindow rw, int id, int x, int y, int slotid)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Visibility = true;
            SlotID = slotid;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            //if (Mouse.IsButtonPressed(Mouse.Button.Left))
                //Program.State[1].GameGUI[2].Visibility = !Program.State[1].GameGUI[2].Visibility;
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

            BuildGUI g = (BuildGUI)Program.State[1].GameGUI[8];
            if (SlotID + 3 * g.PickPage < Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass).Count)
            {
                s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.BuildSprite)[Program.Data.GetBuildableList()[Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass)[SlotID + 3 * g.PickPage]].PickSprite]);
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
