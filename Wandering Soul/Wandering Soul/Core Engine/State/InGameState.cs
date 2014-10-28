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
        RectangleShape _rect;
        public InGameState(RenderWindow rw)
        {
            _screen = rw;
            GUIOrder = new List<int>();

            _rect = new RectangleShape(new Vector2f(16, 16));
            _rect.OutlineColor = Color.Red;
            _rect.OutlineThickness = 1;
            _rect.FillColor = Color.Transparent;
            ClickState = -1;

            
        }

        public void HandleMouseClickRight() { }
        public void HandleMouseClickLeft() { }

        public List<int> GUIOrder { get; set; }

        public void Initialize()
        {
            GameGUI = new List<GUI>();
            GameGUI.Add(new InGameGUI(_screen, 1));
            GameGUI.Add(new InventoryGUI(_screen, 2));
            GameGUI.Add(new EquipmentGUI(_screen, 3));
            GameGUI.Add(new HUD(_screen, 4));
            GameGUI.Add(new InGameLogGUI(_screen, 5));
            GameGUI.Add(new DropGUI(_screen, 6, Logic.CurrentParty.MainParty.MyParty[0].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX, Logic.CurrentParty.MainParty.MyParty[0].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY));
            GameGUI.Add(new RightClickGUI(_screen, Mouse.GetPosition(_screen).X, Mouse.GetPosition(_screen).Y, (int)(Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - _screen.Size.X / 2 / 16 - 1), (int)((Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - _screen.Size.Y / 2 / 16 - 1)));
            GameGUI.Add(new ActionGUI(_screen, 7));
            GameGUI.Add(new BuildGUI(_screen, 8));
            GameGUI.Add(new ConstructionGUI(_screen, 9, 0, 0));
            GameGUI.Add(new CraftGUI(_screen, 10));
            GameGUI.Add(new KnowledgeGUI(_screen, 11));

            for (int i = 0; i < GameGUI.Count; i++)
            {
                GUIOrder.Add(i);
            }
        }

        

        public void HandleResize()
        {
            
        }

        public void Draw()
        {
            Logic.CurrentParty.MainParty.MyParty[0].SetViewToThisNPC(_screen);
            Logic.CurrentParty.MainParty.MyParty[0].CurMap.DrawMap(_screen);
            Logic.CurrentParty.MainParty.MyParty[0].CurMap.DrawSpawnBot(_screen);
            Logic.CurrentParty.MainParty.MyParty[0].CurMap.DrawNPC(_screen);
            int tempx = Logic.CurrentParty.MainParty.MyParty[0].LastX; int tempy = Logic.CurrentParty.MainParty.MyParty[0].LastY;

            for (int i = Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.Count - 1; i >= 0; i--)
            {
                switch (Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath[i])
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
                _rect.Position = new Vector2f((tempx + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX) * 16, (tempy + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY) * 16);
                _screen.Draw(_rect);

            }

            Logic.CurrentParty.MainParty.MyParty[0].Draw(_screen);
            Logic.CurrentParty.MainParty.MyParty[0].CurMap.DrawSpawnFringe(_screen);

            _screen.SetView(new View(new FloatRect(0, 0, _screen.Size.X, _screen.Size.Y)));
            _rect.Position = new Vector2f(Mouse.GetPosition(_screen).X / 16 * 16, (Mouse.GetPosition(_screen).Y - 8) / 16 * 16 + 8);
            _screen.Draw(_rect);

            Logic.CurrentParty.MainParty.MyParty[0].SetViewToThisNPC(_screen);
            switch (ClickState)
            {
                case 0:
                    SpawnBuildable b = new SpawnBuildable(CurrentObjectIndex, -1, -1);
                    bool block = false;
                    for (int r = (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY; r < (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY + Program.Data.GetBuildableList()[CurrentObjectIndex].SizeY; r++)
                    {
                        for (int c = (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX; c < (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX + Program.Data.GetBuildableList()[CurrentObjectIndex].SizeX; c++)
                        {
                            if (Logic.BlockedAt(c, r, Logic.CurrentParty.MainParty.MyParty[0].CurMap, 1))
                            {
                                block = true;
                                break;
                            }
                        }
                    }
                    if (block)
                    {
                        b.DrawBot(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, true);
                        b.DrawTop(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, true);
                    }
                    else
                    {
                        b.DrawBot(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, false);
                        b.DrawTop(_screen, (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1, false);
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
                
            Logic.CurrentParty.MainParty.MyParty[0].SetViewToThisNPC(_screen);
            Logic.CurrentParty.MainParty.MyParty[0].CurMap.DrawAnimation(_screen);
            Logic.CurrentParty.MainParty.MyParty[0].CurMap.DrawMiniText(_screen);
        }

        public void Update()
        {
            Logic.CurrentParty.MainParty.MyParty[0].SpawnMoreMapDueToThisNPC();
            Logic.CurrentParty.MainParty.MyParty[0].Update();

            //foreach (LivingObject Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing[i] in Program.Data.MyLivingObject)
            for (int i = Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing.Count - 1; i >= 0; i--)
            {
                if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing[i] == null)
                    continue;
                if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing[i].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX < Logic.CurrentParty.MainParty.MyParty[0].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX + 33 && Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing[i].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX > Logic.CurrentParty.MainParty.MyParty[0].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX - 34 && Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing[i].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY < Logic.CurrentParty.MainParty.MyParty[0].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY + 25 && Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing[i].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY > Logic.CurrentParty.MainParty.MyParty[0].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY - 26)
                {
                    Logic.CurrentParty.MainParty.MyParty[0].CurMap.LivingThing[i].Update();
                }
            }

            Logic.CurrentParty.MainParty.MyParty[0].CurMap.Update();
        }

        public void HandleKey(Keyboard.Key key)
        {
            bool noitem;
            ConstructionGUI gc = (ConstructionGUI)GameGUI[9];
            SpawnBuildable sb = null;
            if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] > -1)
            {
                if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] is SpawnBuildable)
                    sb = (SpawnBuildable)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]];
            }
            switch (key)
            {
                case Keyboard.Key.Up:
                    Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                    noitem = true;
                    if (sb != null)
                    {
                        for (int bs = 0; bs < sb.Required.Count; bs++)
                        {
                            if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                noitem = false;

                        }
                        if (noitem)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                        }
                    }
                    GameGUI[9].Visibility = false;
                    Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.Clear();
                    Logic.CurrentParty.MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(1, false);
                    else
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(1, true);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                    }
                    break;
                case Keyboard.Key.Down:
                    Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                    noitem = true;
                    if (sb != null)
                    {
                        for (int bs = 0; bs < sb.Required.Count; bs++)
                        {
                            if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                noitem = false;
                        }

                        if (noitem)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                        }
                    }
                    GameGUI[9].Visibility = false;
                    Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.Clear();
                    Logic.CurrentParty.MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(3, false);
                    else
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(3, true);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.MouseState = (int)MouseStateType.Normal;
                        Program.UsingButton = null;
                    }
                    break;
                case Keyboard.Key.Left:
                    Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                    noitem = true;
                    if (sb != null)
                    {
                        for (int bs = 0; bs < sb.Required.Count; bs++)
                        {
                            if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                noitem = false;
                        }

                        if (noitem)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                        }
                    }
                    GameGUI[9].Visibility = false;
                    Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.Clear();
                    Logic.CurrentParty.MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(0, false);
                    else
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(0, true);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                    }
                    break;
                case Keyboard.Key.Right:
                    Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                    noitem = true;
                    if (sb != null)
                    {
                        for (int bs = 0; bs < sb.Required.Count; bs++)
                        {
                            if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                noitem = false;
                        }

                        if (noitem)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                        }
                    }
                    GameGUI[9].Visibility = false;
                    Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.Clear();
                    Logic.CurrentParty.MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(2, false);
                    else
                        Logic.CurrentParty.MainParty.MyParty[0].Walk(2, true);
                    if (Program.UsingButton is DropGUISlotButton)
                    {
                        DropGUISlotButton b = (DropGUISlotButton)Program.UsingButton;
                        b.State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                    }
                    break;
                case Keyboard.Key.Return:
                    //if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[Logic.CurrentParty.MainParty.MyParty[0].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][Logic.CurrentParty.MainParty.MyParty[0].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX].Count > 0)
                    //{
                        //Logic.CurrentParty.MainParty.MyParty[0].PickItems(Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[Logic.CurrentParty.MainParty.MyParty[0].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][Logic.CurrentParty.MainParty.MyParty[0].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX][Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[Logic.CurrentParty.MainParty.MyParty[0].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][Logic.CurrentParty.MainParty.MyParty[0].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX].Count - 1]);
                        GameGUI[5].Visibility = true;
                    //}
                    break;
                case Keyboard.Key.X:
                    Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                    noitem = true;
                    if (sb != null)
                    {
                        for (int bs = 0; bs < sb.Required.Count; bs++)
                        {
                            if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                noitem = false;
                        }

                        if (noitem)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                        }
                    }
                    GameGUI[9].Visibility = false;
                    Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.Clear();
                    Logic.CurrentParty.MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    Logic.CurrentParty.MainParty.MyParty[0].Action(0);
                    break;

                case Keyboard.Key.C:
                    Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                    noitem = true;
                    if (sb != null)
                    {
                        for (int bs = 0; bs < sb.Required.Count; bs++)
                        {
                            if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                noitem = false;
                        }

                        if (noitem)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                        }
                    }
                    GameGUI[9].Visibility = false;
                    Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.Clear();
                    Logic.CurrentParty.MainParty.MyParty[0].GeneralBehavior = (int)GeneralBehaviorType.Normal;
                    Logic.CurrentParty.MainParty.MyParty[0].Action(1);
                    break;
                case Keyboard.Key.Tab:
                    Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                    noitem = true;
                    if (sb != null)
                    {
                        for (int bs = 0; bs < sb.Required.Count; bs++)
                        {
                            if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                noitem = false;
                        }
                        if (noitem)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                            Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                        }
                    }
                    GameGUI[9].Visibility = false;
                    Logic.CurrentParty.MainParty.SwapMember(1);
                    break;
                case Keyboard.Key.Escape:
                    GameGUI[9].Visibility = false;
                    Program.SM.SwitchState(StateType.MainMenu);
                    break;
            }
        }

        public void HandleMouse(Mouse.Button key)
        {

            Map m = Logic.CurrentParty.MainParty.MyParty[0].CurMap;
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

            else if (x >= GameGUI[8].X && x <= GameGUI[8].X + 170 && y >= GameGUI[8].Y && y <= GameGUI[8].Y + 210 && GameGUI[8].Visibility)
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

            else if (x >= GameGUI[10].X && x <= GameGUI[10].X + 170 && y >= GameGUI[10].Y && y <= GameGUI[10].Y + 210 && GameGUI[10].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[10].HandleMouse(key, x, y);
            }

            else if (x >= GameGUI[11].X && x <= GameGUI[11].X + 200 && y >= GameGUI[11].Y && y <= GameGUI[11].Y + 200 && GameGUI[11].Visibility)
            {
                if (GameGUI[6] != null)
                    GameGUI[6].Visibility = false;
                GameGUI[11].HandleMouse(key, x, y);
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

                    GameGUI[6] = new RightClickGUI(_screen, Mouse.GetPosition(_screen).X, Mouse.GetPosition(_screen).Y, (int)(Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - _screen.Size.X / 2 / 16 - 1), (int)((Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - _screen.Size.Y / 2 / 16 - 1));
                    GameGUI[6].HandleMouse(key, x, y);


                    if (Mouse.IsButtonPressed(Mouse.Button.Right) && Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX] > -1 && Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX]] is SpawnBuildable)
                    {
                        SpawnBuildable b = (SpawnBuildable)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX]];
                        if (!b.Builded)
                        {
                            Logic.CurrentParty.MainParty.MyParty[0].TargetX = (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1;
                            Logic.CurrentParty.MainParty.MyParty[0].TargetY = (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1;
                            Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 2;
                            Logic.DoPathFinding(Logic.CurrentParty.MainParty.MyParty[0]);
                            Logic.CurrentParty.MainParty.MyParty[0].ActionDir = Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath[0];
                            Logic.CurrentParty.MainParty.MyParty[0].PathfindingPath.RemoveAt(0);
                            GameGUI[6].Visibility = false;

                        }

                        else
                        {
                            //if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX] > -1 && Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX]] is SpawnBuildableFire)
                            //{
                            //    SpawnBuildableFire bfire = (SpawnBuildableFire)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[(int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][(int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX]];
                                GameGUI[6] = new RightClickGUI(_screen, Mouse.GetPosition(_screen).X, Mouse.GetPosition(_screen).Y, (int)(Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - _screen.Size.X / 2 / 16 - 1), (int)((Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - _screen.Size.Y / 2 / 16 - 1));
                                GameGUI[6].HandleMouse(key, x, y);
                            //}
                        }
                    }


                }
                else
                {
                    switch (ClickState)
                    {
                        case 0:
                            GameGUI[9].Visibility = false;
                            Logic.BuildStuff((int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX, (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1 + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY, CurrentObjectIndex, _screen, m);
                            ClickState = -1;
                            break;
                        default:
                            if (GameGUI[6].Visibility)
                            {
                                GameGUI[6].HandleMouse(key, x, y);
                                GameGUI[6].Visibility = false;
                                if(Logic.CurrentParty.MainParty.MyParty[0].CurrentAction == 4)
                                {
                                }
                                return;
                            }
                            else if (Mouse.IsButtonPressed(Mouse.Button.Left))
                            {
                                Logic.CurrentParty.MainParty.MyParty[0].CurrentAction = 0;
                                Logic.CurrentParty.MainParty.MyParty[0].TargetX = (int)Mouse.GetPosition(_screen).X / 16 + Logic.CurrentParty.MainParty.MyParty[0].X - (int)_screen.Size.X / 2 / 16 - 1;
                                Logic.CurrentParty.MainParty.MyParty[0].TargetY = (int)(Mouse.GetPosition(_screen).Y + 8) / 16 + Logic.CurrentParty.MainParty.MyParty[0].Y - (int)_screen.Size.Y / 2 / 16 - 1;
                                Logic.Pathfinder = Logic.CurrentParty.MainParty.MyParty[0];
                                Logic.DoPathFinding(Logic.CurrentParty.MainParty.MyParty[0]);
                                ConstructionGUI gc = (ConstructionGUI)GameGUI[9];
                                bool noitem = true;
                                SpawnBuildable sb = null;
                                if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] > -1)
                                {
                                    if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] is SpawnBuildable)
                                        sb = (SpawnBuildable)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]];
                                }
                                if (sb != null)
                                {
                                    for (int bs = 0; bs < sb.Required.Count; bs++)
                                    {
                                        if (sb.Required.ElementAt(bs).Value.Count > 0 || sb.Builded)
                                            noitem = false;
                                    }

                                    if (noitem)
                                    {
                                        Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]] = null;
                                        Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] = -1;
                                    }
                                }
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
            else if (x >= GameGUI[3].X && x <= GameGUI[3].X + 147 && y >= GameGUI[3].Y && y <= GameGUI[3].Y + (Logic.CurrentParty.MainParty.MyParty.Count + 1) * 47 + (Logic.CurrentParty.MainParty.MyParty.Count) * 10)
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
