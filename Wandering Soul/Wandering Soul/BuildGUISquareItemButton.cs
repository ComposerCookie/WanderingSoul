using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class BuildGUISquareItemButton : GUIButton
    {
        RenderWindow _screen;
        public BuildGUISquareItemButton(RenderWindow rw, int id, int x, int y, int slotid)
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
            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 14;

            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);

            BuildGUI g = (BuildGUI)Program.State[1].GameGUI[8];
            if (g.CurPick + 3 * g.PickPage < Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass).Count)
            {
                if (SlotID + 3 * g.CurPage < Program.Data.GetBuildableList()[Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass)[g.CurPick + 3 * g.PickPage]].RequiredItems.Count)
                {
                    s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.GetBuildableList()[Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass)[g.CurPick + 3 * g.PickPage]].RequiredItems.ElementAt(SlotID + 3 * g.CurPage).Key.ID]);
                    s.Position = new Vector2f(X, Y);
                    _screen.Draw(s);

                    t.DisplayedString = Program.Data.MyItems[Program.Data.GetBuildableList()[Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass)[g.CurPick + 3 * g.PickPage]].RequiredItems.ElementAt(SlotID + 3 * g.CurPage).Key.ID].Name + ": " + Program.Data.GetBuildableList()[Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass)[g.CurPick + 3 * g.PickPage]].RequiredItems.ElementAt(SlotID + 3 * g.CurPage).Value;
                    t.Position = new Vector2f(X + 40, Y + 7);
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
        public bool Visibility { get; set; }
        public int SlotID { get; set; }
    }
}
