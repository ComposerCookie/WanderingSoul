using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class InGameState : GameState
    {
        RenderWindow _screen;
        int _saveFile;
        RectangleShape _rect;
        public InGameState(RenderWindow rw, int saveFile)
        {
            _screen = rw;
            _saveFile = saveFile;
            GameGUI = new List<GUI>();
            GameGUI.Add(new InGameGUI(_screen, 1));
            GameGUI.Add(new InventoryGUI(_screen, 2));
            GameGUI.Add(new EquipmentGUI(_screen, 3));
            GameGUI.Add(new HUD(_screen, 4));
            GameGUI.Add(new InGameLogGUI(_screen, 5));
            GameGUI.Add(new DropGUI(_screen, 6, Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + Program.MyMap.MinX, Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + Program.MyMap.MinY));
            GameGUI.Add(new RightClickGUI(_screen, Mouse.GetPosition(_screen).X, Mouse.GetPosition(_screen).Y, (int)(Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - _screen.Size.X / 2 / 16 - 1), (int)((Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - _screen.Size.Y / 2 / 16 - 1)));
            GameGUI.Add(new ActionGUI(_screen, 7));
            GameGUI.Add(new BuildGUI(_screen, 8));
            GameGUI.Add(new ConstructionGUI(_screen, 9, 0, 0));
            _rect = new RectangleShape(new Vector2f(16, 16));
            _rect.OutlineColor = Color.Red;
            _rect.OutlineThickness = 1;
            _rect.FillColor = Color.Transparent;
            ClickState = -1;
        }

        public int SaveFile
        {
            get { return _saveFile; }
            set { _saveFile = value; }
        }

        public void Draw()
        {
            Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].SetViewToThisNPC(_screen);
            Program.MyMap.DrawMap(_screen);
            Program.MyMap.DrawSpawnBot(_screen);
            Program.MyMap.DrawNPC(_screen);
            int tempx = Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].X; int tempy = Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].Y;

            for (int i = Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].PathfindingPath.Count - 1; i >= 0; i--)
            {
                switch (Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].PathfindingPath[i])
                {
                    case 0:
                        tempx--;
                        break;
                    case 1:
                        tempy--;
                        break;
                    case 2:
                        tempx++;
                        break;
                    case 3:
                        tempy++;
                        break;
                }
                _rect.Position = new Vector2f((tempx + Program.MyMap.MinX) * 16, (tempy + Program.MyMap.MinY) * 16);
                _screen.Draw(_rect);

            }
            Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].Draw(_screen);
            Program.MyMap.DrawSpawnFringe(_screen);

            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _rect.Position = new Vector2f(Mouse.GetPosition(_screen).X / 16 * 16, (Mouse.GetPosition(_screen).Y - 8) / 16 * 16 + 8);
            _screen.Draw(_rect);

            Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].SetViewToThisNPC(_screen);
            switch (ClickState)
            {
                case 0:
                    SpawnBuildable b = new SpawnBuildable(CurrentObjectIndex, -1, -1);
                    bool block = false;
                    for (int r = (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Program.MyMap.MinY; r < (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Program.MyMap.MinY + Program.Data.GetBuildableList()[CurrentObjectIndex].SizeY; r++)
                    {
                        for (int c = (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Program.MyMap.MinX; c < (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Program.MyMap.MinX + Program.Data.GetBuildableList()[CurrentObjectIndex].SizeX; c++)
                        {
                            if (Logic.BlockedAt(c, r))
                            {
                                block = true;
                                break;
                            }
                        }
                    }
                    if (block)
                    {
                        b.DrawBot(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, true);
                        b.DrawTop(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, true);
                    }
                    else
                    {
                        b.DrawBot(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, false);
                        b.DrawTop(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, false);
                    }
                    break;
                default:
                    break;
            }

            foreach (GUI g in GameGUI)
            {
                if (g.Visibility)
                    g.Draw();
            }

            if (!GameGUI[4].Visibility)
                GameGUI[4].MyButton[5].Draw();
                
            Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].SetViewToThisNPC(_screen);
        }

        public void Update()
        {
            Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].SpawnMoreMapDueToThisNPC();
            Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].Update();

            foreach (LivingObject o in Program.Data.MyLivingObject)
            {
                if (o == null)
                    continue;
                if (o.X + Program.MyMap.MinX < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + Program.MyMap.MinX + 33 && o.X + Program.MyMap.MinX > Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + Program.MyMap.MinX - 34 && o.Y + Program.MyMap.MinY < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + Program.MyMap.MinY + 25 && o.Y + Program.MyMap.MinY > Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + Program.MyMap.MinY - 26)
                {
                    o.Update();
                }
            }
        }

        public void HandleKey(Keyboard.Key key)
        {
            switch (key)
            {
                case Keyboard.Key.Up:
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].CurrentAction = 0;
                    GameGUI[9].Visibility = false;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].PathfindingPath.Clear();
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].Walk(1);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                    }
                    break;
                case Keyboard.Key.Down:
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].CurrentAction = 0;
                    GameGUI[9].Visibility = false;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].PathfindingPath.Clear();
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].Walk(3);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.MouseState = (int)MouseStateType.Normal;
                        Program.UsingButton = null;
                    }
                    break;
                case Keyboard.Key.Left:
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].CurrentAction = 0;
                    GameGUI[9].Visibility = false;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].PathfindingPath.Clear();
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].Walk(0);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                    }
                    break;
                case Keyboard.Key.Right:
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].CurrentAction = 0;
                    GameGUI[9].Visibility = false;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].PathfindingPath.Clear();
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].Walk(2);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                    }
                    break;
                case Keyboard.Key.Return:
                    //if (Program.MyMap.Drop[Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + Program.MyMap.MinY][Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + Program.MyMap.MinX].Count > 0)
                    //{
                        //Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].PickItems(Program.MyMap.Drop[Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + Program.MyMap.MinY][Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + Program.MyMap.MinX][Program.MyMap.Drop[Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y + Program.MyMap.MinY][Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X + Program.MyMap.MinX].Count - 1]);
                        GameGUI[5].Visibility = true;
                    //}
                    break;
                case Keyboard.Key.C:
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].CurrentAction = 0;
                    GameGUI[9].Visibility = false;
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].PathfindingPath.Clear();
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Action();
                    break;
                case Keyboard.Key.Tab:
                    Program.Data.MyPlayerData[_saveFile].MainParty.MyParty[0].CurrentAction = 0;
                    GameGUI[9].Visibility = false;
                    Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.SwapMember(1);
                    break;
                case Keyboard.Key.Escape:
                    GameGUI[9].Visibility = false;
                    Program.InState = 0;
                    break;
            }
        }

        public void HandleMouse(Mouse.Button key)
        {
            int x = Mouse.GetPosition(_screen).X;
            int y = Mouse.GetPosition(_screen).Y;
            if (x >= GameGUI[0].X && x <= GameGUI[0].X + 369 && y >= GameGUI[0].Y && y <= GameGUI[0].Y + 25 && GameGUI[0].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[0].HandleMouse(key, x, y);
            }
            else if (x >= GameGUI[1].X && x <= GameGUI[1].X + 178 && y >= GameGUI[1].Y && y <= GameGUI[1].Y + 178 && GameGUI[1].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[1].HandleMouse(key, x, y);
            }
            else if (x >= GameGUI[2].X && x <= GameGUI[2].X + 140 && y >= GameGUI[2].Y && y <= GameGUI[2].Y + 200 && GameGUI[2].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[2].HandleMouse(key, x, y);
            }
            //if (x >= GameGUI[3].X && x <= GameGUI[3].X + 140 && y >= GameGUI[3].Y && y <= GameGUI[3].Y + 200)
            //{
            //    GameGUI[3].HandleMouse(key, x, y);
            //}
            else if (x >= GameGUI[4].X && x <= GameGUI[4].X + 250 && y >= GameGUI[4].Y && y <= GameGUI[4].Y + 130)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[4].HandleMouse(key, x, y);
            }

            else if (x >= GameGUI[5].X && x <= GameGUI[5].X + 178 && y >= GameGUI[5].Y && y <= GameGUI[5].Y + 140 && GameGUI[5].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[5].HandleMouse(key, x, y);
            }

            else if (x >= GameGUI[7].X && x <= GameGUI[7].X + 132 && y >= GameGUI[7].Y && y <= GameGUI[7].Y + 89 && GameGUI[7].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[7].HandleMouse(key, x, y);
            }

            else if (x >= GameGUI[8].X && x <= GameGUI[8].X + 250 && y >= GameGUI[8].Y && y <= GameGUI[8].Y + 250 && GameGUI[8].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[8].HandleMouse(key, x, y);
            }

            else if (x >= GameGUI[9].X && x <= GameGUI[9].X + 170 && y >= GameGUI[9].Y && y <= GameGUI[9].Y + 150 && GameGUI[9].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[9].HandleMouse(key, x, y);
            }

            else
            {
                if (key == Mouse.Button.Right)
                {
                    if (ClickState > -1)
                    {
                        ClickState = -1;
                        return;
                    }

                    GameGUI[6] = new RightClickGUI(_screen, Mouse.GetPosition(_screen).X, Mouse.GetPosition(_screen).Y, (int)(Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - _screen.Size.X / 2 / 16 - 1), (int)((Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - _screen.Size.Y / 2 / 16 - 1));
                    GameGUI[6].HandleMouse(key, x, y);

                    if (Mouse.IsButtonPressed(Mouse.Button.Right) && Program.MyMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Program.MyMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Program.MyMap.MinX] > -1 && Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Program.MyMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Program.MyMap.MinX]] is SpawnBuildable)
                    {
                        SpawnBuildable b = (SpawnBuildable)Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Program.MyMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Program.MyMap.MinX]];
                        if (!b.Builded)
                        {
                            Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetX = (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1;
                            Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetY = (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1;
                            Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentAction = 2;
                            Logic.DoPathFinding(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0]);
                            Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].ActionDir = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].PathfindingPath[0];
                            Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].PathfindingPath.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    switch (ClickState)
                    {
                        case 0:
                            GameGUI[9].Visibility = false;
                            Logic.BuildStuff((int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Program.MyMap.MinX, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Program.MyMap.MinY, CurrentObjectIndex, _screen);
                            ClickState = -1;
                            break;
                        default:
                            if (GameGUI[6].Visibility)
                            {
                                GameGUI[6].HandleMouse(key, x, y);
                                GameGUI[6].Visibility = false;
                                return;
                            }
                            else if (Mouse.IsButtonPressed(Mouse.Button.Left))
                            {
                                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].CurrentAction = 0;
                                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetX = (int)Mouse.GetPosition(_screen).X / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1;
                                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].TargetY = (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1;
                                Logic.DoPathFinding(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0]);
                                GameGUI[9].Visibility = false;
                                return;
                            }
                            break;
                    }
                    
                }
            }
        }

        public void HandleMouseMove()
        {
            GameGUI[CurrentGUI].HandleMouseMove();
            /*
            int x = Mouse.GetPosition(_screen).X;
            int y = Mouse.GetPosition(_screen).Y;
            if (x >= GameGUI[0].X && x <= GameGUI[0].X + 369 && y >= GameGUI[0].Y && y <= GameGUI[0].Y + 25)
                DrawBox = false;
            else if (x >= GameGUI[1].X && x <= GameGUI[1].X + 158 && y >= GameGUI[1].Y && y <= GameGUI[1].Y + 178)
                DrawBox = false;
            else if (x >= GameGUI[2].X && x <= GameGUI[2].X + 140 && y >= GameGUI[2].Y && y <= GameGUI[2].Y + 200)
                DrawBox = false;
            else if (x >= GameGUI[3].X && x <= GameGUI[3].X + 147 && y >= GameGUI[3].Y && y <= GameGUI[3].Y + (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty.Count + 1) * 47 + (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty.Count) * 10)
                DrawBox = false;
            else if (x >= GameGUI[4].X && x <= GameGUI[4].X + 250 && y >= GameGUI[4].Y && y <= GameGUI[4].Y + 130)
                DrawBox = false;
            else
                DrawBox = true;
             */
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

        public bool DrawBox
        {
            get;
            set;
        }

        public int ClickState
        {
            get;
            set;
        }

        public int CurrentObjectIndex
        {
            get;
            set;
        }
    }
}
