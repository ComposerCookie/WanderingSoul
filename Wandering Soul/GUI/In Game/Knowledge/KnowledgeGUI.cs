using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class KnowledgeGUI : GUI
    {
        RenderWindow _screen;
        public KnowledgeGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            CurrentButton = 0;
            X = 500;
            Y = 500;
            Visibility = false;

            MyButton.Add(new GUIClose(rw, 20, X + 180, Y, 11, 1));
            MyButton.Add(new GUIHead(rw, 56, X, Y, 11, 1));

            MyButton.Add(new KnowledgeGUIKnowledgeButton(rw, 61, X, Y + 20));
            MyButton.Add(new KnowledgeGUICraftButton(rw, 60, X + 42, Y + 20));
            MyButton.Add(new KnowledgeGUIBlueprintButton(rw, 58, X + 84, Y + 20));

            MyButton.Add(new KnowledgeGUIScrollUpButton(rw, 65, X + 180, Y + 42));
            MyButton.Add(new KnowledgeGUIScrollBar(rw, 63, X + 180, Y + 61));
            MyButton.Add(new KnowledgeGUIScrollDownButton(rw, 64, X + 180, Y + 180));

            for (int i = 0; i < 6; i++)
            {
                MyButton.Add(new KnowledgeGUIBarButton(rw, 57, X + 1, Y + 43 + 26 * i, i)); 
            }

        }


        public void HandleMouseMove()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (Moving)
                {
                    GUIHead g = (GUIHead)MyButton[1];
                    X = Mouse.GetPosition(_screen).X - g.TempX;
                    Y = Mouse.GetPosition(_screen).Y - g.TempY;
                    Resize();
                }
            }
        }

        public void Resize()
        {
            MyButton[0].X = X + 180; MyButton[0].Y = Y;
            MyButton[1].X = X; MyButton[1].Y = Y;

            MyButton[2].X = X; MyButton[2].Y = Y + 20;
            MyButton[3].X = X + 42; MyButton[3].Y = Y + 20;
            MyButton[4].X = X + 84; MyButton[4].Y = Y + 20;
            MyButton[5].X = X + 180; MyButton[5].Y = Y + 42;
            MyButton[6].X = X + 180; MyButton[6].Y = Y + 61;
            MyButton[7].X = X + 180; MyButton[7].Y = Y + 180;

            for (int i = 0; i < 6; i++)
            {
                MyButton[8 + i].X = X + 1; MyButton[8 + i].Y = Y + 43 + 26 * i;
            }
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _screen.Draw(s);

            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 9;
            t.Color = Color.Yellow;
            t.DisplayedString = "" + Program.Data.CurrentParty.MainParty.MyParty[0].LearningPoint;
            t.Position = new Vector2f(X + 146, Y + 28);

            _screen.Draw(t);

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
            if (x >= X + 180 && x <= X + 200 && y >= Y && y <= Y + 20)
            {
                MyButton[0].Picked();
            }

            else if (x >= X + 0 && x <= X + 150 && y >= Y && y <= Y + 20)
            {
                MyButton[1].Picked();
            }

            else if (x >= X && x <= X + 43 && y >= Y + 20 && y <= Y + 43)
            {
                MyButton[2].Picked();
            }

            else if (x >= X + 42 && x <= X + 85 && y >= Y + 20 && y <= Y + 43)
            {
                MyButton[3].Picked();
            }

            else if (x >= X + 84 && x <= X + 107 && y >= Y + 20 && y <= Y + 43)
            {
                MyButton[4].Picked();
            }

            else if (x >= X + 180 && x <= X + 200 && y >= Y + 42 && y <= Y + 62)
            {
                MyButton[5].Picked();
            }

            else if (x >= X + 180 && x <= X + 200 && y >= Y + 61 && y <= Y + 181)
            {
                MyButton[6].Picked();
            }

            else if (x >= X + 180 && x <= X + 200 && y >= Y + 180 && y <= Y + 200)
            {
                MyButton[7].Picked();
            }

            for (int i = 0; i < 6; i++)
            {
                if (x >= X + 1 && x <= X + 200 && y >= Y + 43 + 26 * i && y <= Y + 43 + 26 * (i + 1))
                {
                    MyButton[8 + i].Picked();
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
        public int CurView { get; set; }
        public int KnowledgeDown { get; set; }
        public int CraftDown { get; set; }
        public int BlueprintDown { get; set; }
    }
}
