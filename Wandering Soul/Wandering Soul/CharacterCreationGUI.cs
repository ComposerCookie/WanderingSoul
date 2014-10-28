using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Window;
using SFML.Graphics;
using System.Text;

namespace Lost_Soul
{
    public class CharacterCreationGUI : GUI
    {
        RenderWindow _screen;
        public CharacterCreationGUI(RenderWindow rw, int id)
        {
            MyButton = new List<GUIButton>();
            _screen = rw;
            ID = id;
            X = 460;
            Y = 240;

            MyButton.Add(new CharacterCreationBack(_screen, 78, X + 147, Y + 219));
            MyButton.Add(new CharacterCreationName(_screen, 89, X + 51, Y + 34));
            MyButton.Add(new CharacterCreationGender(_screen, 90, X + 58, Y + 52));
            MyButton.Add(new CharacterCreationFace(_screen, 80, X + 7, Y + 52));

            MyButton.Add(new CharacterCreationArrowLeft(_screen, 69, X + 96, Y + 67, 0));
            MyButton.Add(new CharacterCreationArrowLeft(_screen, 69, X + 96, Y + 81, 1));
            MyButton.Add(new CharacterCreationArrowLeft(_screen, 69, X + 96, Y + 95, 2));
            
            MyButton.Add(new CharacterCreationArrowRight(_screen, 68, X + 161, Y + 67, 0));
            MyButton.Add(new CharacterCreationArrowRight(_screen, 68, X + 161, Y + 81, 1));
            MyButton.Add(new CharacterCreationArrowRight(_screen, 68, X + 161, Y + 95, 2));
            
            MyButton.Add(new CharacterCreationOK(_screen, 79, X + 116, Y + 219));
            MyButton.Add(new CharacterCreationCharacter(_screen, 0, X + 116, Y + 67));

            MyButton.Add(new CharacterCreationArrowLeft(_screen, 69, X + 96, Y + 109, 3));
            MyButton.Add(new CharacterCreationArrowRight(_screen, 68, X + 161, Y + 109, 3));

            CurrentButton = 0;
            CurFace = CurBody = CurHair = CurHairColor = 0;
            CurGender = 0;
            
        }

        public void Initialize(PlayerParty p)
        {
            CurrentSession = p;
            CharacterCreationName b = (CharacterCreationName)MyButton[1];
            b.Text = "";

            CurFace = CurBody = CurHair = CurHairColor = 0;
            CurGender = 0;
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
            MyButton[11].Update();
        }

        public void Resize()
        { 
        }

        public void HandleMouse(Mouse.Button but, int x, int y)
        {
            if (x >= X + 147 && x <= X + 174 && y >= Y + 219 && y <= Y + 238)
            {
                MyButton[0].Picked();
            }
            else if (x >= X + 51 && x <= X + 173 && y >= Y + 34 && y <= Y + 49)
            {
                MyButton[1].Picked();
                return;
            }
            else if (x >= X + 58 && x <= X + 66 && y >= Y + 52 && y <= Y + 60)
            {
                CurGender = 0;
                CurHair = 0;
                CurFace = 0;
                CurHairColor = 0;
            }
            else if (x >= X + 82 && x <= X + 90 && y >= Y + 52 && y <= Y + 60)
            {
                CurGender = 1;
                CurHair = 0;
                CurFace = 0;
                CurHairColor = 0;
            }
            else if (x >= X + 7 && x <= X + 55 && y >= Y + 52 && y <= Y + 100)
            {
                MyButton[3].Picked();
            }

            else if (x >= X + 96 && x <= X + 101 && y >= Y + 67 && y <= Y + 76)
            {
                MyButton[4].Picked();
            }
            else if (x >= X + 96 && x <= X + 101 && y >= Y + 81 && y <= Y + 90)
            {
                MyButton[5].Picked();
            }
            else if (x >= X + 96 && x <= X + 101 && y >= Y + 95 && y <= Y + 104)
            {
                MyButton[6].Picked();
            }

            else if (x >= X + 161 && x <= X + 166 && y >= Y + 67 && y <= Y + 76)
            {
                MyButton[7].Picked();
            }
            else if (x >= X + 161 && x <= X + 166 && y >= Y + 81 && y <= Y + 90)
            {
                MyButton[8].Picked();
            }
            else if (x >= X + 161 && x <= X + 166 && y >= Y + 95 && y <= Y + 104)
            {
                MyButton[9].Picked();
            }

            else if (x >= X + 116 && x <= X + 143 && y >= Y + 219 && y <= Y + 238)
            {
                MyButton[10].Picked();
            }

            else if (x >= X + 96 && x <= X + 101 && y >= Y + 109 && y <= Y + 118)
            {
                MyButton[12].Picked();
            }

            else if (x >= X + 161 && x <= X + 166 && y >= Y + 109 && y <= Y + 118)
            {
                MyButton[13].Picked();
            }

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                CharacterCreationName b = (CharacterCreationName)MyButton[1];
                b.Focus = false;
            }
        }

        public void HandleKey(Keyboard.Key key)
        {
            CharacterCreationName b = (CharacterCreationName)MyButton[1];
            if (b.Focus)
            {
                if (Keyboard.IsKeyPressed(key))
                {
                    if (key == Keyboard.Key.Back)
                    {
                        if (b.Text.Length >0)
                            b.Text = b.Text.Remove(b.Text.Length - 1);
                    }
                    else
                    {
                        b.Text += Logic.GetLetterFromKeyboard(key);
                    }
                }
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
        public int CurBody { get; set; }
        public byte CurGender { get; set; }
        public int CurHair { get; set; }
        public int CurFace { get; set; }
        public PlayerParty CurrentSession { get; set; }
        public int CurHairColor { get; set; }
    }
}
