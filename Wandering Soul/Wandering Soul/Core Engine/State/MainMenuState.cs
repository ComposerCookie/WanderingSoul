using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class MainMenuState : GameState
    {
        RenderWindow _screen;
        public MainMenuState(RenderWindow rw)
        {
            GameGUI = new List<GUI>();
            _screen = rw;
            GameGUI.Add(new MainMenuGUI(_screen, 0));
            GameGUI.Add(new PickPartyGUI(_screen, 13));
            GameGUI.Add(new ViewPartyGUI(_screen, 14));
            GameGUI.Add(new NewPartyGUI(_screen, 14));
            GameGUI.Add(new CharacterCreationGUI(_screen, 12));
            GameGUI.Add(new PickWorldGUI(_screen, 15));
            GameGUI.Add(new NewWorldGUI(_screen, 16));
            CurrentGUI = 0;
        }

        public void HandleMouseClickRight() { }
        public void HandleMouseClickLeft() { }


        public List<int> GUIOrder { get; set; }
        public Object Tag { get; set; }

        public void HandleResize()
        {
        }

        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.TitleBackground)[0]);
            s.Position = new Vector2f(0, 0);
            _screen.Draw(s);

            s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.TitleBackground)[CurrentFire + 1]);
            s.Position = new Vector2f(0, 0);
            _screen.Draw(s);

            s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.TitleBackground)[CurrentShade + 5]);
            s.Position = new Vector2f(0, 0);
            _screen.Draw(s);
            

            //GameGUI[CurrentGUI].Draw();
            foreach (GUI g in GameGUI)
            {
                if (g.Visibility)
                    g.Draw();
            }
        }

        public void Update()
        {
            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            if (FireCooldown > 0)
                FireCooldown--;
            else
            {
                CurrentFire++;
                if (CurrentFire > 3)
                    CurrentFire = 0;

                FireCooldown = 20;
            }

            if (ShadeCooldown > 0)
                ShadeCooldown--;
            else
            {
                CurrentShade++;
                if (CurrentShade > 3)
                    CurrentShade = 0;

                ShadeCooldown = 40;
            }

            foreach (GUI g in GameGUI)
                g.Update();
        }

        public void HandleKey(Keyboard.Key key)
        {
            GameGUI[CurrentGUI].HandleKey(key);
        }

        public void HandleMouse(Mouse.Button key)
        {
            int x = Mouse.GetPosition(_screen).X;
            int y = Mouse.GetPosition(_screen).Y;
            if (x >= GameGUI[0].X && x <= GameGUI[0].X + 100 && y >= GameGUI[0].Y && y <= GameGUI[0].Y + 160 && GameGUI[0].Visibility)
                GameGUI[0].HandleMouse(key, x, y);
            else if (x >= GameGUI[1].X && x <= GameGUI[1].X + 180 && y >= GameGUI[1].Y && y <= GameGUI[1].Y + 250 && GameGUI[1].Visibility)
                GameGUI[1].HandleMouse(key, x, y);
            else if (x >= GameGUI[3].X && x <= GameGUI[3].X + 480 && y >= GameGUI[3].Y && y <= GameGUI[3].Y + 240 && GameGUI[3].Visibility)
                GameGUI[3].HandleMouse(key, x, y);
            else if (x >= GameGUI[4].X && x <= GameGUI[4].X + 180 && y >= GameGUI[4].Y && y <= GameGUI[4].Y + 240 && GameGUI[4].Visibility)
                GameGUI[4].HandleMouse(key, x, y);
            else if (x >= GameGUI[5].X && x <= GameGUI[5].X + 180 && y >= GameGUI[5].Y && y <= GameGUI[5].Y + 250 && GameGUI[5].Visibility)
                GameGUI[5].HandleMouse(key, x, y);
            else if (x >= GameGUI[6].X && x <= GameGUI[6].X + 180 && y >= GameGUI[6].Y && y <= GameGUI[6].Y + 240 && GameGUI[6].Visibility)
                GameGUI[6].HandleMouse(key, x, y);

        }

        public void HandleMouseMove()
        {
        }

        public List<GUI> GameGUI
        {
            get;
            set;
        }

        public int CurrentGUI
        {
            get;
            set;
        }

        public bool MovingGUI
        {
            get;
            set;
        }

        public int FireCooldown { get; set; }
        public int CurrentFire { get; set; }
        public int ShadeCooldown { get; set; }
        public int CurrentShade { get; set; }
    }
}
