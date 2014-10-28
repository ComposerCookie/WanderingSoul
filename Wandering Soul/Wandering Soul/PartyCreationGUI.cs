using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class PartyCreationGUI : GUI
    {
        RenderWindow _screen;
        public PartyCreationGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            X = 350;
            Y = 350;

            MyButton.Add(new ViewPartyFace(_screen, 80, X + 5, Y + 33, 0));
            MyButton.Add(new ViewPartyFace(_screen, 80, X + 123, Y + 33, 1));
            MyButton.Add(new ViewPartyFace(_screen, 80, X + 242, Y + 33, 2));
            MyButton.Add(new ViewPartyFace(_screen, 80, X + 361, Y + 33, 3));

            MyButton.Add(new ViewPartyPlatform(_screen, 77, X + 11, Y + 220, 0));
            MyButton.Add(new ViewPartyPlatform(_screen, 77, X + 130, Y + 220, 1));
            MyButton.Add(new ViewPartyPlatform(_screen, 77, X + 249, Y + 220, 2));
            MyButton.Add(new ViewPartyPlatform(_screen, 77, X + 368, Y + 220, 3));

            MyButton.Add(new ViewPartyHealthBar(_screen, 81, 23, X + 6, Y + 96, 0));
            MyButton.Add(new ViewPartyHealthBar(_screen, 81, 23, X + 124, Y + 96, 1));
            MyButton.Add(new ViewPartyHealthBar(_screen, 81, 23, X + 243, Y + 96, 2));
            MyButton.Add(new ViewPartyHealthBar(_screen, 81, 23, X + 362, Y + 96, 3));

            MyButton.Add(new ViewPartyManaBar(_screen, 82, 24, X + 6, Y + 108, 0));
            MyButton.Add(new ViewPartyManaBar(_screen, 82, 24, X + 124, Y + 108, 1));
            MyButton.Add(new ViewPartyManaBar(_screen, 82, 24, X + 243, Y + 108, 2));
            MyButton.Add(new ViewPartyManaBar(_screen, 82, 24, X + 362, Y + 108, 3));

            MyButton.Add(new ViewPartyStaminaBar(_screen, 83, 25, X + 6, Y + 120, 0));
            MyButton.Add(new ViewPartyStaminaBar(_screen, 83, 25, X + 124, Y + 120, 1));
            MyButton.Add(new ViewPartyStaminaBar(_screen, 83, 25, X + 243, Y + 120, 2));
            MyButton.Add(new ViewPartyStaminaBar(_screen, 83, 25, X + 362, Y + 120, 3));

            MyButton.Add(new ViewPartyHungerBar(_screen, 84, X + 6, Y + 127, 0));
            MyButton.Add(new ViewPartyHungerBar(_screen, 84, X + 124, Y + 127, 1));
            MyButton.Add(new ViewPartyHungerBar(_screen, 84, X + 243, Y + 127, 2));
            MyButton.Add(new ViewPartyHungerBar(_screen, 84, X + 362, Y + 127, 3));

            MyButton.Add(new ViewPartyExperienceBar(_screen, 85, 86, X + 106, Y + 96, 0));
            MyButton.Add(new ViewPartyExperienceBar(_screen, 85, 86, X + 224, Y + 96, 1));
            MyButton.Add(new ViewPartyExperienceBar(_screen, 85, 86, X + 343, Y + 96, 2));
            MyButton.Add(new ViewPartyExperienceBar(_screen, 85, 86, X + 362, Y + 96, 3));

            MyButton.Add(new ViewPartyEquipmentLeft(_screen, 19, X + 54, Y + 49, 0));
            MyButton.Add(new ViewPartyEquipmentLeft(_screen, 19, X + 172, Y + 49, 1));
            MyButton.Add(new ViewPartyEquipmentLeft(_screen, 19, X + 291, Y + 49, 2));
            MyButton.Add(new ViewPartyEquipmentLeft(_screen, 19, X + 410, Y + 49, 3));

            MyButton.Add(new ViewPartyEquipmentRight(_screen, 16, X + 87, Y + 49, 0));
            MyButton.Add(new ViewPartyEquipmentRight(_screen, 16, X + 205, Y + 49, 1));
            MyButton.Add(new ViewPartyEquipmentRight(_screen, 16, X + 324, Y + 49, 2));
            MyButton.Add(new ViewPartyEquipmentRight(_screen, 16, X + 443, Y + 49, 3));
            
            CurrentButton = 0;
            
        }

        public void HandleMouseMove()
        {
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.GUI)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);

            foreach (GUIButton b in MyButton)
            {
                b.Draw();
            }
        }
        public void Update()
        {
        }

        public void Resize()
        { 
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X + 10 && x <= X + 90 && y >= Y + 17 && y <= Y + 47)
            {
            //    MyButton[0].Picked();
            }
            else if (x >= X + 10 && x <= X + 90 && y >= Y + 118 && y <= Y + 148)
            {
            //    MyButton[1].Picked();
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
                case Keyboard.Key.Down:
                    CurrentButton--;
                    if (CurrentButton < 0)
                        CurrentButton = MyButton.Count - 1;
                    break;
                case Keyboard.Key.Space:
                    MyButton[CurrentButton].Picked();
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
