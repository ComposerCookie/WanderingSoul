using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class NewPartyGUI : GUI
    {
        RenderWindow _screen;
        public NewPartyGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            X = 290;
            Y = 280;

            Clear();

            MyButton.Add(new NewPartyFace(_screen, 80, X + 5, Y + 33, 0));
            MyButton.Add(new NewPartyFace(_screen, 80, X + 123, Y + 33, 1));
            MyButton.Add(new NewPartyFace(_screen, 80, X + 242, Y + 33, 2));
            MyButton.Add(new NewPartyFace(_screen, 80, X + 361, Y + 33, 3));

            MyButton.Add(new NewPartyPlatform(_screen, 77, X + 11, Y + 220, 0));
            MyButton.Add(new NewPartyPlatform(_screen, 77, X + 130, Y + 220, 1));
            MyButton.Add(new NewPartyPlatform(_screen, 77, X + 249, Y + 220, 2));
            MyButton.Add(new NewPartyPlatform(_screen, 77, X + 368, Y + 220, 3));

            MyButton.Add(new NewPartyHealthBar(_screen, 81, 23, X + 6, Y + 96, 0));
            MyButton.Add(new NewPartyHealthBar(_screen, 81, 23, X + 124, Y + 96, 1));
            MyButton.Add(new NewPartyHealthBar(_screen, 81, 23, X + 243, Y + 96, 2));
            MyButton.Add(new NewPartyHealthBar(_screen, 81, 23, X + 362, Y + 96, 3));

            MyButton.Add(new NewPartyManaBar(_screen, 82, 24, X + 6, Y + 108, 0));
            MyButton.Add(new NewPartyManaBar(_screen, 82, 24, X + 124, Y + 108, 1));
            MyButton.Add(new NewPartyManaBar(_screen, 82, 24, X + 243, Y + 108, 2));
            MyButton.Add(new NewPartyManaBar(_screen, 82, 24, X + 362, Y + 108, 3));

            MyButton.Add(new NewPartyStaminaBar(_screen, 83, 25, X + 6, Y + 120, 0));
            MyButton.Add(new NewPartyStaminaBar(_screen, 83, 25, X + 124, Y + 120, 1));
            MyButton.Add(new NewPartyStaminaBar(_screen, 83, 25, X + 243, Y + 120, 2));
            MyButton.Add(new NewPartyStaminaBar(_screen, 83, 25, X + 362, Y + 120, 3));

            MyButton.Add(new NewPartyHungerBar(_screen, 84, X + 6, Y + 127, 0));
            MyButton.Add(new NewPartyHungerBar(_screen, 84, X + 124, Y + 127, 1));
            MyButton.Add(new NewPartyHungerBar(_screen, 84, X + 243, Y + 127, 2));
            MyButton.Add(new NewPartyHungerBar(_screen, 84, X + 362, Y + 127, 3));

            MyButton.Add(new NewPartyExperienceBar(_screen, 85, 86, X + 106, Y + 96, 0));
            MyButton.Add(new NewPartyExperienceBar(_screen, 85, 86, X + 224, Y + 96, 1));
            MyButton.Add(new NewPartyExperienceBar(_screen, 85, 86, X + 343, Y + 96, 2));
            MyButton.Add(new NewPartyExperienceBar(_screen, 85, 86, X + 462, Y + 96, 3));

            MyButton.Add(new NewPartyEquipmentLeft(_screen, 19, X + 54, Y + 49, 0));
            MyButton.Add(new NewPartyEquipmentLeft(_screen, 19, X + 172, Y + 49, 1));
            MyButton.Add(new NewPartyEquipmentLeft(_screen, 19, X + 291, Y + 49, 2));
            MyButton.Add(new NewPartyEquipmentLeft(_screen, 19, X + 410, Y + 49, 3));

            MyButton.Add(new NewPartyEquipmentRight(_screen, 16, X + 87, Y + 49, 0));
            MyButton.Add(new NewPartyEquipmentRight(_screen, 16, X + 205, Y + 49, 1));
            MyButton.Add(new NewPartyEquipmentRight(_screen, 16, X + 324, Y + 49, 2));
            MyButton.Add(new NewPartyEquipmentRight(_screen, 16, X + 443, Y + 49, 3));

            MyButton.Add(new NewPartyBackButton(_screen, 20, X + 460, Y));
            MyButton.Add(new NewPartyNewCharacter(_screen, 73, X + 91, Y + 215));

            MyButton.Add(new NewPartyCharacterEdit(_screen, 88, X + 63, Y + 215, 0));
            MyButton.Add(new NewPartyCharacterEdit(_screen, 88, X + 182, Y + 215, 1));
            MyButton.Add(new NewPartyCharacterEdit(_screen, 88, X + 301, Y + 215, 2));
            MyButton.Add(new NewPartyCharacterEdit(_screen, 88, X + 420, Y + 215, 3));

            MyButton.Add(new NewPartyDeleteCharacter(_screen, 78, X + 91, Y + 215, 0));
            MyButton.Add(new NewPartyDeleteCharacter(_screen, 78, X + 210, Y + 215, 1));
            MyButton.Add(new NewPartyDeleteCharacter(_screen, 78, X + 329, Y + 215, 2));
            MyButton.Add(new NewPartyDeleteCharacter(_screen, 78, X + 448, Y + 215, 3));

            MyButton.Add(new NewPartyOk(_screen, 91, X + 438, Y));

            CurrentButton = 0;
            
        }

        public void Clear()
        {
            CurrentSession = new PlayerData();
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

            s.Texture = new Texture(Program.Data.SpriteBasedOnType(SpriteType.Button)[76]);
            s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X, (int)s.Texture.Size.Y);
            for (int i = Program.Data.PartySlotUnlock; i < 4; i++)
            {
                s.Position = new Vector2f(X + 2 + 119 * i, Y + 31);
                _screen.Draw(s);
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
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (x >= X + 460 && x <= X + 480 && y >= Y && y <= Y + 20)
                {
                    MyButton[36].Picked();
                }
                else if (x >= X + 91 + 119 * CurrentSession.MainParty.MyParty.Count && x <= X + 91 + 119 * CurrentSession.MainParty.MyParty.Count + 27 && y >= Y + 215 && y <= Y + 234)
                {
                    MyButton[37].Picked();
                    return;
                }

                else if (x >= X + 438 && x <= X + 458 && y >= Y && y <= Y + 20)
                {
                    MyButton[46].Picked();
                }

                for (int i = 0; i < CurrentSession.MainParty.MyParty.Count; i++)
                {
                    if (x >= X + 91 + 119 * i && x <= X + 91 + 119 * i + 27 && y >= Y + 215 && y <= Y + 234)
                    {
                        MyButton[42 + i].Picked();
                        return;
                    }
                    else if (x >= X + 63 + 119 * i && x <= X + 91 + 119 * i + 27 && y >= Y + 215 && y <= Y + 234)
                    {
                        MyButton[38 + i].Picked();
                        return;
                    }
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
        public PlayerData CurrentSession { get; set; }
    }
}
