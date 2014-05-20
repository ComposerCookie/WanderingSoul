using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class BuildGUIOkButton : GUIButton
    {
        RenderWindow _screen;
        public BuildGUIOkButton(RenderWindow rw, int id, int x, int y)
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
            BuildGUI g = (BuildGUI)Program.State[1].GameGUI[8];
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (g.CurPick + 3 * g.PickPage < Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass).Count)
                {
                    InGameState s = (InGameState)Program.State[1];
                    s.CurrentObjectIndex = Program.Data.GetBuildableList().IndexOf(Program.Data.GetBuildableList()[Logic.KnownBluePrintForThisCharacter(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0], g.CurClass)[g.CurPick + 3 * g.PickPage]]);
                    s.ClickState = 0;
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
        public int State { get; set; }
    }
}
