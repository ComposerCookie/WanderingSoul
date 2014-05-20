using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class ConstructionGUIBuildButton : GUIButton
    {
        RenderWindow _screen;
        public ConstructionGUIBuildButton(RenderWindow rw, int id, int x, int y)
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
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                ConstructionGUI g = (ConstructionGUI)Program.State[1].GameGUI[9];
                if (Program.MyMap.SpawnedSpawnableLocation[g.LocY][g.LocX] > -1)
                {
                    SpawnBuildable b = (SpawnBuildable)Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[g.LocY][g.LocX]];
                    b.Builded = true;
                    g.Visibility = false;
                }
            }
            //    Program.State[1].GameGUI[8].Visibility = !Program.State[1].GameGUI[8].Visibility;
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
    }
}
