using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class RightClickGUI : GUI
    {
        RenderWindow _screen;
        public RightClickGUI(RenderWindow rw, int x, int y, int corX, int corY)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = -1;
            CurrentButton = 0;
            X = x;
            Y = y;
            Visibility = true;

            MyButton.Add(new RightClickExamineButton(rw, 37, X, Y + MyButton.Count * 20, corX + Program.MyMap.MinX, corY + Program.MyMap.MinY));

            if (Program.MyMap.SpawnedSpawnableLocation[corY + Program.MyMap.MinY][corX + Program.MyMap.MinX] > -1)
            {
                MyButton.Add(new RightClickWalkHarvest(rw, 37, X, Y + MyButton.Count * 20, corX + Program.MyMap.MinX, corY + Program.MyMap.MinY));
            }
            if (Program.MyMap.SpawnedLivingThing[corY + Program.MyMap.MinY][corX + Program.MyMap.MinX].Count > 0)
            {
                MyButton.Add(new RightClickWalkAttack(rw, 37, X, Y + MyButton.Count * 20, corX + Program.MyMap.MinX, corY + Program.MyMap.MinY));
            }

            MyButton.Add(new RightClickWalk(rw, 37, X, Y + MyButton.Count * 20, corX + Program.MyMap.MinX, corY + Program.MyMap.MinY));
            MyButton.Add(new RightClickPickButton(rw, 37, X, Y + MyButton.Count * 20, corX + Program.MyMap.MinX, corY + Program.MyMap.MinY));
        }

        public void HandleMouseMove()
        {
        }

        public void Resize()
        {

        }

        public void Draw()
        {
            //SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            //s.Position = new Vector2f(X, Y);
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            //_screen.Draw(s);

            foreach (GUIButton b in MyButton)
            {
                b.Draw();
            }
        }
        public void Update()
        {
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                Visibility = true;
            }
            else
            {
                if (Visibility)
                {
                    int tempy = y - Y;
                    tempy /= 20;
                    if (tempy < MyButton.Count && tempy >= 0)
                        MyButton[tempy].Picked();
                }
            }
        }

        public void HandleKey(Keyboard.Key key)
        {
            switch (key)
            {
                case Keyboard.Key.Up:
                    CurrentButton++;
                    if (CurrentButton >= MyButton.Count)
                        CurrentButton = 0;
                    break;

            }
        }

        public List<GUIButton> MyButton { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ID { get; set; }
        public int CurrentButton { get; set; }
        public bool Visibility { get; set; }
        public bool Moving { get; set; }
    }
    
}
