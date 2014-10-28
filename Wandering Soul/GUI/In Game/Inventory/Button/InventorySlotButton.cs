using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class InventorySlotButton : GUIButton
    {
        RenderWindow _screen;
        public InventorySlotButton(RenderWindow rw, int id, int x, int y, int slotID)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Visibility = true;
            SlotID = slotID;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (SlotID < Program.Data.CurrentParty.MainParty.MyParty[0].Inventory.Count && Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] != null)
                {
                    if (State == 0)
                    {
                        if (Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] == null)
                        {
                            return;
                        }
                        State = 1;
                        Program.UsingButton = this;
                        Program.MouseState = (int)MouseStateType.Dragging;
                    }

                    else if (State == 1)
                    {
                        /*if (Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Type == (int)ItemType.Weapon || Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Type == (int)ItemType.Storage || Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Type == (int)ItemType.Ring)
                        {
                            switch ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Type)
                            {
                                case ItemType.Weapon:
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[11] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID);
                                        State = 0;
                                        Program.UsingButton = null;
                                    }
                            }
                        }*/
                            HandleLocation();
                    }
                }
            }
        }

        public void HandleLocation()
        {
            SpawnItems temp;
            int d;
            int m;
            if (State == 1 && Program.UsingButton != null)
            {
                int x = Mouse.GetPosition(_screen).X;
                int y = Mouse.GetPosition(_screen).Y;
                DropGUI g = (DropGUI)Program.SM.States[1].GameGUI[5];
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
                                    if (r * 4 + c >= 8 + Program.Data.CurrentParty.MainParty.MyParty[0].ExtraInventorySpace)
                                        return;
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c] = Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                    else if (r * 4 + c == SlotID)
                                    {
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                    else
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c];
                                        if (temp.ID == Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID && Program.Data.MyItems[temp.ID].Stackable)
                                        {
                                            temp.Amount += Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].Amount;
                                            Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = null;
                                            State = 0;
                                            Program.UsingButton = null;
                                            Program.MouseState = (int)MouseStateType.Normal;
                                            return;
                                        }
                                        else
                                        {
                                            Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c] = Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID];
                                            Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
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
                        switch ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Type)
                        {
                            case ItemType.Weapon:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 33 && x <= Program.SM.States[1].GameGUI[2].X + 65 && y >= Program.SM.States[1].GameGUI[2].Y + 95 && y <= Program.SM.States[1].GameGUI[2].Y + 127)
                                {

                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[11] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 11);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[11].ID].Type == ItemType.Weapon)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[11];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 11);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }

                                else if (x >= Program.SM.States[1].GameGUI[2].X + 104 && x <= Program.SM.States[1].GameGUI[2].X + 136 && y >= Program.SM.States[1].GameGUI[2].Y + 95 && y <= Program.SM.States[1].GameGUI[2].Y + 127)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[7] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 7);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[7].ID].Type == ItemType.Weapon)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[7];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 7);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;

                            case ItemType.Storage:
                                if (x >= X + 103 && x <= X + 135 && y >= Y + 163 && y <= Y + 195)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[10] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 10);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[10].ID].Type == ItemType.Storage)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[10];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 10);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;

                            case ItemType.Ring:
                                if (x >= X + 5 && x <= X + 37 && y >= Y + 163 && y <= Y + 195)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[9] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 9);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[9].ID].Type == ItemType.Ring)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[9];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 9);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }

                                if (x >= X + 5 && x <= X + 37 && y >= Y + 128 && y <= Y + 160)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[8] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 8);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[8].ID].Type == ItemType.Ring)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[8];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 8);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;

                            case ItemType.Necklace:
                                if (x >= X + 6 && x <= X + 38 && y >= Y + 26 && y <= Y + 58)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[6] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 6);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[6].ID].Type == ItemType.Necklace)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[6];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 6);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;
                                
                            case ItemType.Helmet:
                                if (x >= X + 68 && x <= X + 100 && y >= Y + 46 && y <= Y + 78)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[5] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 5);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[5].ID].Type == ItemType.Helmet)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[5];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 5);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;
                                
                            case ItemType.Cape:
                                if (x >= X + 104 && x <= X + 136 && y >= Y + 60 && y <= Y + 92)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[4] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 4);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[4].ID].Type == ItemType.Cape)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[4];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 4);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;

                            case ItemType.Bracelet:
                                if (x >= X + 6 && x <= X + 32 && y >= Y + 62 && y <= Y + 94)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[3] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 3);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[3].ID].Type == ItemType.Bracelet)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[3];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 3);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;

                            case ItemType.Boot:
                                if (x >= X + 69 && x <= X + 101 && y >= Y + 132 && y <= Y + 164)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[2] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 2);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[2].ID].Type == ItemType.Boot)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[2];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 2);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;

                            case ItemType.Armor:
                                if (x >= X + 68 && x <= X + 100 && y >= Y + 89 && y <= Y + 121)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[1] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 1);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[1].ID].Type == ItemType.Armor)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[1];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 1);
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }
                                }
                                break;

                            case ItemType.Ammunition:
                                if (x >= X + 104 && x <= X + 136 && y >= Y + 25 && y <= Y + 57)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[0] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 0);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if ((ItemType)Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[0].ID].Type == ItemType.Ammunition)
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].Equipment[0];
                                        if (temp.ID == Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID && Program.Data.MyItems[temp.ID].Stackable)
                                        {
                                                temp.Amount += Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].Amount;
                                                Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = null;
                                                State = 0;
                                                Program.UsingButton = null;
                                                Program.MouseState = (int)MouseStateType.Normal;
                                        }
                                        else
                                        {
                                            Program.Data.CurrentParty.MainParty.MyParty[0].EquipItems(SlotID, 0);
                                            Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                        }
                                    }
                                }
                                break;
                        }
                    }

                }

                else if (x >= Program.SM.States[1].GameGUI[5].X && x <= Program.SM.States[1].GameGUI[5].X + 178 && y >= Program.SM.States[1].GameGUI[5].Y && y <= Program.SM.States[1].GameGUI[5].Y + 140 && Program.SM.States[1].GameGUI[5].Visibility)
                {
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 4; c++)
                        {
                            if (x >= Program.SM.States[1].GameGUI[5].X + (c * 38) + 6 && x <= Program.SM.States[1].GameGUI[5].X + 38 * (c + 1) && y >= Program.SM.States[1].GameGUI[5].Y + 26 + (r * 38) && y <= Program.SM.States[1].GameGUI[5].Y + (r + 1) * 38 + 26)
                            {
                                /*
                                if (r * 4 + c + g.ScrollCount * 4 < Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX].Count)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] == null)
                                    {
                                        Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] = Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                    else
                                    {
                                        temp = Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] = Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID];
                                        Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = temp;
                                        return;
                                    }
                                }

                                else
                                {
                                    Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX].Add(Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID]);
                                    Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = null;
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                    return;
                                }*/
                                Program.Data.CurrentParty.MainParty.MyParty[0].DropItemFromInventory(SlotID);
                                State = 0;
                                Program.UsingButton = null;
                                Program.MouseState = (int)MouseStateType.Normal;
                                return;
                            }
                        }
                    }
                }
                else if (x >= Program.SM.States[1].GameGUI[9].X && x <= Program.SM.States[1].GameGUI[9].X + 170 && y >= Program.SM.States[1].GameGUI[9].Y && y <= Program.SM.States[1].GameGUI[9].Y + 150 && Program.SM.States[1].GameGUI[9].Visibility)
                {
                    ConstructionGUI gc = (ConstructionGUI)Program.SM.States[1].GameGUI[9];
                    if (Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] > -1)
                    {
                        SpawnBuildable b = (SpawnBuildable)Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Program.Data.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]];
                        for (int r = 0; r < 3; r++)
                        {
                            if (r + gc.CurPage < b.Required.Count)
                            {
                                if (x >= gc.X + 7 && x <= gc.X + 138 && y >= gc.Y + 27 + (r * 34) && y <= gc.Y + (r + 1) * 34 + 27)
                                {
                                    if (Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID == b.Required.ElementAt(r + 3 * gc.CurPage).Key.ID)
                                    {
                                        if (b.Required.ElementAt(r + 3 * gc.CurPage).Value.Count < Program.Data.GetBuildableList()[b.ID].RequiredItems.ElementAt(r + 3 * gc.CurPage).Value)
                                        {
                                            if (Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Stackable)
                                            {
                                                b.Required.ElementAt(r + 3 * gc.CurPage).Value.Add(new SpawnItems(Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID));
                                                Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].Amount--;
                                                if (Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].Amount <= 0)
                                                {
                                                    Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = null;
                                                    State = 0;
                                                    Program.UsingButton = null;
                                                    Program.MouseState = (int)MouseStateType.Normal;
                                                }
                                            }
                                            else
                                            {
                                                b.Required.ElementAt(r + 3 * gc.CurPage).Value.Add(Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID]);
                                                Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] = null;
                                                State = 0;
                                                Program.UsingButton = null;
                                                Program.MouseState = (int)MouseStateType.Normal;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Program.Data.CurrentParty.MainParty.MyParty[0].DropItemFromInventory(SlotID);
                    State = 0;
                    Program.UsingButton = null;
                    Program.MouseState = (int)MouseStateType.Normal;
                }
            }
            
        }
        public bool isMouseHover()
        {
            return false;
        }
        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);
            if (SlotID < Program.Data.CurrentParty.MainParty.MyParty[0].Inventory.Count && Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID] != null)
            {
                if (State == 0)
                    Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].DrawSprite(_screen, X, Y);
                else
                    Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].DrawSprite(_screen, Mouse.GetPosition(_screen).X - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Sprite].Size.X / 2, Mouse.GetPosition(_screen).Y - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[SlotID].ID].Sprite].Size.Y / 2);
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
