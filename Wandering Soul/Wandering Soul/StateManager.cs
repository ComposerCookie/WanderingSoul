using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class StateManager
    {
        public List<GameState> States { get; set; }
        public int CurrentState { get; set; }
        public int MouseState { get; set; }
        public long LastUpdate { get; set; }

        public StateManager()
        {
            States = new List<GameState>();
            States.Add(new MainMenuState(Program.RW));
            States.Add(new InGameState(Program.RW));
            CurrentState = 0;
            MouseState = (int)MouseStateType.Normal;
            LastUpdate = 0;
        }

        public void Draw(RenderWindow Screen)
        {
            States[CurrentState].Draw();

            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Mouse)[MouseState]);
            switch ((MouseStateType)MouseState)
            {
                case MouseStateType.Normal:
                    s.Position = new Vector2f(Mouse.GetPosition(Screen).X - 3, Mouse.GetPosition(Screen).Y);
                    break;
                case MouseStateType.Dragging:
                    s.Position = new Vector2f(Mouse.GetPosition(Screen).X - 2, Mouse.GetPosition(Screen).Y + 3);
                    break;
            }
        }

        public void Update()
        {
            States[CurrentState].Update();
        }

        public void SwitchState(StateType type)
        {
            switch (type)
            {
                case StateType.MainMenu:
                    if (Logic.CurrentParty != null && Logic.CurrentWorld != null)
                    {
                        for (int i = 0; i < Logic.CurrentParty.MainParty.MyParty.Count; i++)
                        {
                            Logic.CurrentParty.MainParty.MyParty[i].CurMap.SpawnedLivingThing[Logic.CurrentParty.MainParty.MyParty[i].Y + Logic.CurrentParty.MainParty.MyParty[i].CurMap.MinY][Logic.CurrentParty.MainParty.MyParty[i].X + Logic.CurrentParty.MainParty.MyParty[i].CurMap.MinX].Remove(Logic.CurrentParty.MainParty.MyParty[i].Index);
                            Logic.CurrentParty.MainParty.MyParty[i].CurMap.LivingThing[Logic.CurrentParty.MainParty.MyParty[i].Index] = null;
                        }
                        CurrentState = 0;
                    }
                    break;
                case StateType.InGame:
                    if (Logic.CurrentParty != null && Logic.CurrentWorld != null)
                    {
                        for (int i = 0; i < Logic.CurrentParty.MainParty.MyParty.Count; i++)
                        {
                            Logic.CurrentParty.MainParty.MyParty[i].OnMapType = Logic.CurrentWorld.SpawnPlaceMapType;
                            Logic.CurrentParty.MainParty.MyParty[i].SideMapID = Logic.CurrentWorld.SpawnMapIndex;
                            Logic.CurrentParty.MainParty.MyParty[i].X = Logic.CurrentWorld.SpawnMapX;
                            Logic.CurrentParty.MainParty.MyParty[i].Y = Logic.CurrentWorld.SpawnMapY;
                            Logic.CurrentParty.MainParty.MyParty[i].PutOnMap();

                            InGameState s = (InGameState)Program.SM.States[1];
                            s.Initialize();
                            CurrentState = 1;
                        }
                    }
                    break;
            }
        }
    }
}
