using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class ConstructionGUIItemButton : GUIButton
    {
        RenderWindow _screen;
        public ConstructionGUIItemButton(RenderWindow rw, int id, int x, int y, int slotid)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Visibility = true;
            SlotID = slotid;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (State == 0)
                {
                    ConstructionGUI g = (ConstructionGUI)Program.SM.States[1].GameGUI[9];
                    if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX] > -1)
                    {
                        if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX] > -1)
                        {
                            SpawnBuildable b = (SpawnBuildable)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX]];
                            if (SlotID + 3 * g.CurPage < b.Required.Count)
                            {
                                if (b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Count > 0)
                                {
                                    State = 1;
                                    Program.UsingButton = this;
                                    Program.MouseState = (int)MouseStateType.Dragging;

                                }
                            }
                        }

                    }
                }
                else
                {
                    HandleLocation();
                }
            }
            else
            {
            }
        }
        public bool isMouseHover()
        {
            return false;
        }
        public void Draw()
        {
            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 14;

            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);

            ConstructionGUI g = (ConstructionGUI)Program.SM.States[1].GameGUI[9];
            if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX] > -1)
            {
                SpawnBuildable b = (SpawnBuildable)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX]];
                if (SlotID + 3 * g.CurPage < b.Required.Count)//SlotID + 3 * g.CurPage < Program.Data.MySpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX]].ID].)
                {
                    s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[b.Required.ElementAt(SlotID + 3 * g.CurPage).Key.ID].Sprite]);
                    s.Position = new Vector2f(X, Y);
                    _screen.Draw(s);

                    t.DisplayedString = Program.Data.MyItems[b.Required.ElementAt(SlotID + 3 * g.CurPage).Key.ID].Name + ": " + (Program.Data.GetBuildableList()[b.ID].RequiredItems.ElementAt(SlotID + 3 * g.CurPage).Value - b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Count - b.Built.ElementAt(SlotID + 3 * g.CurPage).Value.Count) + "/" + b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Count + "/" + b.Built.ElementAt(SlotID + 3 * g.CurPage).Value.Count;
                    t.Position = new Vector2f(X + 38, Y + 8);
                    _screen.Draw(t);

                    if (State == 1)
                    {
                        b.Required.ElementAt(SlotID + 3 * g.CurPage).Key.DrawSprite(_screen, Mouse.GetPosition(_screen).X - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[b.Required.ElementAt(SlotID + 3 * g.CurPage).Key.ID].Sprite].Size.X / 2, Mouse.GetPosition(_screen).Y - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[b.Required.ElementAt(SlotID + 3 * g.CurPage).Key.ID].Sprite].Size.Y / 2);
                    }
                }
            }
        }

        public void HandleLocation()
        {
            ConstructionGUI g = (ConstructionGUI)Program.SM.States[1].GameGUI[9];
            SpawnItems temp;
            if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX] > -1)
            {
                SpawnBuildable b = (SpawnBuildable)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[g.LocY][g.LocX]];

                if (State == 1 && Program.UsingButton != null)
                {
                    int x = Mouse.GetPosition(_screen).X;
                    int y = Mouse.GetPosition(_screen).Y;
                    //if (x >= GameGUI[0].X && x <= GameGUI[0].X + 369 && y >= GameGUI[0].Y && y <= GameGUI[0].Y + 25)
                    //{
                    //    GameGUI[0].HandleMouse(key, x, y);
                    //}
                    if (x >= Program.SM.States[1].GameGUI[1].X && x <= Program.SM.States[1].GameGUI[1].X + 178 && y >= Program.SM.States[1].GameGUI[1].Y && y <= Program.SM.States[1].GameGUI[1].Y + 178)
                    {
                        if (Program.SM.States[1].GameGUI[1].Visibility)
                        {
                            for (int r = 0; r < 4; r++)
                            {
                                for (int c = 0; c < 4; c++)
                                {

                                    if (x >= Program.SM.States[1].GameGUI[1].X + (c * 38) + 6 && x <= Program.SM.States[1].GameGUI[1].X + 38 * (c + 1) && y >= Program.SM.States[1].GameGUI[1].Y + 26 + (r * 38) && y <= Program.SM.States[1].GameGUI[1].Y + (r + 1) * 38 + 26)
                                    {
                                        if (r * 4 + c >= 8 + Logic.CurrentParty.MainParty.MyParty[0].ExtraInventorySpace)
                                            return;
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c] = b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0];
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                            return;
                                        }

                                        else
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c];
                                            if (temp.ID == b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0].ID && Program.Data.MyItems[temp.ID].Stackable)
                                            {
                                                temp.Amount += b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0].Amount;
                                                b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                                State = 0;
                                                Program.UsingButton = null;
                                                Program.MouseState = (int)MouseStateType.Normal;
                                                return;
                                            }
                                            else
                                            {
                                                Logic.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c] = b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0];
                                                b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    else if (x >= Program.SM.States[1].GameGUI[2].X && x <= Program.SM.States[1].GameGUI[2].X + 140 && y >= Program.SM.States[1].GameGUI[2].Y && y <= Program.SM.States[1].GameGUI[2].Y + 200)
                    {
                        if (Program.SM.States[1].GameGUI[2].Visibility)
                        {
                            switch ((ItemType)Program.Data.MyItems[b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0].ID].Type)
                            {
                                case ItemType.Weapon:
                                    if (x >= Program.SM.States[1].GameGUI[2].X + 33 && x <= Program.SM.States[1].GameGUI[2].X + 65 && y >= Program.SM.States[1].GameGUI[2].Y + 95 && y <= Program.SM.States[1].GameGUI[2].Y + 127)
                                    {

                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[11] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 11);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[11].ID].Type == ItemType.Weapon)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[11];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 11);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    if (x >= X + 104 && x <= X + 136 && y >= Y + 95 && y <= Y + 127)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[7] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 7);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[7].ID].Type == ItemType.Weapon)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[7];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 7);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Storage:
                                    if (x >= X + 103 && x <= X + 135 && y >= Y + 163 && y <= Y + 195)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[10] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 10);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[10].ID].Type == ItemType.Weapon)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[10];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 10);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Ring:
                                    if (x >= X + 5 && x <= X + 37 && y >= Y + 163 && y <= Y + 195)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[9] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 9);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[9].ID].Type == ItemType.Ring)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[9];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 9);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }

                                    if (x >= X + 5 && x <= X + 37 && y >= Y + 128 && y <= Y + 160)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[8] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 8);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[8].ID].Type == ItemType.Ring)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[8];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 8);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;
                                case ItemType.Necklace:
                                    if (x >= X + 6 && x <= X + 38 && y >= Y + 26 && y <= Y + 58)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[6] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 6);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[6].ID].Type == ItemType.Necklace)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[6];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 6);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Helmet:
                                    if (x >= X + 68 && x <= X + 100 && y >= Y + 46 && y <= Y + 78)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[5] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 5);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[5].ID].Type == ItemType.Helmet)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[5];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 5);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Cape:
                                    if (x >= X + 104 && x <= X + 136 && y >= Y + 60 && y <= Y + 92)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[4] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 4);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[4].ID].Type == ItemType.Cape)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[4];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 4);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Bracelet:
                                    if (x >= X + 6 && x <= X + 32 && y >= Y + 62 && y <= Y + 94)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[3] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 3);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[3].ID].Type == ItemType.Bracelet)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[3];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 3);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Boot:
                                    if (x >= X + 69 && x <= X + 101 && y >= Y + 132 && y <= Y + 164)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[2] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 2);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[2].ID].Type == ItemType.Boot)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[2];
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 2);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Armor:
                                    if (x >= X + 68 && x <= X + 100 && y >= Y + 89 && y <= Y + 121)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[1] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 1);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[1].ID].Type == ItemType.Armor)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[1];
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 1);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                        }
                                    }
                                    break;

                                case ItemType.Ammunition:
                                    if (x >= X + 104 && x <= X + 136 && y >= Y + 25 && y <= Y + 57)
                                    {
                                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[0] == null)
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 0);
                                            b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else if ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[0].ID].Type == ItemType.Ammunition)
                                        {
                                            temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[0];
                                            if (temp.ID == b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0].ID && Program.Data.MyItems[temp.ID].Stackable)
                                            {
                                                temp.Amount += b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0].Amount;
                                                b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                                State = 0;
                                                Program.UsingButton = null;
                                                Program.MouseState = (int)MouseStateType.Normal;
                                            }
                                            else
                                            {
                                                Logic.CurrentParty.MainParty.MyParty[0].EquipItems(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0], 0);
                                                b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.Insert(0, temp);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }

                    }
                    else if (x >= Program.SM.States[1].GameGUI[5].X && x <= Program.SM.States[1].GameGUI[5].X + 178 && y >= Program.SM.States[1].GameGUI[5].Y && y <= Program.SM.States[1].GameGUI[5].Y + 140 && Program.SM.States[1].GameGUI[5].Visibility)
                    {
                        DropGUI dg = (DropGUI)Program.SM.States[1].GameGUI[5];
                        Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[dg.DropY][dg.DropX].Add(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0]);
                        b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                        State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                        return;
                    }
                    else if (x >= g.X && x <= g.X + 170 && y >= g.Y && y <= g.Y + 150 && g.Visibility)
                    {
                        for (int r = 0; r < 3; r++)
                        {
                            if (x >= g.X + 7 && x <= g.X + 138 && y >= g.Y + 27 + (r * 34) && y <= g.Y + (r + 1) * 34 + 27)
                            {
                                if (r + 3 * g.CurPage == SlotID + 3 * g.CurPage)
                                {
                                    if (b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0].ID == b.Required.ElementAt(SlotID + 3 * g.CurPage).Key.ID)
                                    {
                                        if (b.Required.ElementAt(r + 3 * g.CurPage).Value.Count < Program.Data.GetBuildableList()[b.ID].RequiredItems.ElementAt(r + 3 * g.CurPage).Value)
                                        {
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                            return;
                                        }
                                    }
                                }
                                else if (b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0].ID == b.Required.ElementAt(r + 3 * g.CurPage).Key.ID)
                                {
                                    if (b.Required.ElementAt(r + 3 * g.CurPage).Value.Count < Program.Data.GetBuildableList()[b.ID].RequiredItems.ElementAt(r + 3 * g.CurPage).Value)
                                    {
                                        b.Required.ElementAt(r + 3 * g.CurPage).Value.Add(b.Required.ElementAt(SlotID + 3 * g.CurPage).Value[0]);
                                        b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[Logic.CurrentParty.MainParty.MyParty[0].Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY][Logic.CurrentParty.MainParty.MyParty[0].X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX].Add(b.Required.ElementAt(SlotID + 3 * g.CurPage).Key);
                        b.Required.ElementAt(SlotID + 3 * g.CurPage).Value.RemoveAt(0);
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, Logic.CurrentParty.MainParty.MyParty[0].Name + " dropped a " + Program.Data.MyItems[b.Required.ElementAt(SlotID + 3 * g.CurPage).Key.ID].Name);
                        State = 0;
                        Program.UsingButton = null;
                        Program.MouseState = (int)MouseStateType.Normal;
                    }
                }
            }
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
        public int SlotID { get; set; }
        public int State { get; set; }
    }
}
