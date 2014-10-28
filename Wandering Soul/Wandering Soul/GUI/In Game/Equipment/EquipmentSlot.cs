using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class EquipmentSlot : GUIButton
    {
        RenderWindow _screen;
        public EquipmentSlot(RenderWindow rw, int id, int x, int y, int slotID)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Visibility = true;
            SlotID = slotID;
            State = 0;
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
                    if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] == null)
                    {
                        return;
                    }
                    State = 1;
                    Program.UsingButton = this;
                    Program.MouseState = (int)MouseStateType.Dragging;
                }
                else if (State == 1)
                {
                    HandleLocation();
                }
            }
            else
            {
            }
        }

        public void HandleLocation()
        {
            SpawnItems temp;
            int d;
            if (State == 1 && Program.UsingButton != null)
            {
                DropGUI g = (DropGUI)Program.SM.States[1].GameGUI[5];
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
                                        Logic.CurrentParty.MainParty.MyParty[0].UnequipItems(SlotID, r * 4 + c);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                    else
                                    {
                                        temp = Logic.CurrentParty.MainParty.MyParty[0].Inventory[r * 4 + c];
                                        if (temp.ID == Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].ID && Program.Data.MyItems[temp.ID].Stackable)
                                        {
                                            temp.Amount += Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].Amount;
                                            Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = null;
                                        }
                                        else
                                        {
                                            Logic.CurrentParty.MainParty.MyParty[0].UnequipItems(SlotID, r * 4 + c);
                                            Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = temp;
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
                        if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] == null)
                        {
                            return;
                        }
                        switch ((ItemType)Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].ID].Type)
                        {
                            case ItemType.Weapon:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 33 && x <= Program.SM.States[1].GameGUI[2].X + 65 && y >= Program.SM.States[1].GameGUI[2].Y + 95 && y <= Program.SM.States[1].GameGUI[2].Y + 127)
                                {
                                    if (SlotID == 11)
                                    {
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[11] == null)
                                    {
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[11] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else
                                    {
                                        temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[11];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[11] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = temp;
                                    }
                                }

                                else if (x >= Program.SM.States[1].GameGUI[2].X + 104 && x <= Program.SM.States[1].GameGUI[2].X + 136 && y >= Program.SM.States[1].GameGUI[2].Y + 95 && y <= Program.SM.States[1].GameGUI[2].Y + 127)
                                {
                                    if (SlotID == 7)
                                    {
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[7] == null)
                                    {
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[7] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else
                                    {
                                        temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[7];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[7] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = temp;
                                    }
                                }
                                break;
                            case ItemType.Storage:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 103 && x <= Program.SM.States[1].GameGUI[2].X + 135 && y >= Program.SM.States[1].GameGUI[2].Y + 163 && y <= Program.SM.States[1].GameGUI[2].Y + 195)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Ring:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 5 && x <= Program.SM.States[1].GameGUI[2].X + 37 && y >= Program.SM.States[1].GameGUI[2].Y + 128 && y <= Program.SM.States[1].GameGUI[2].Y + 160)
                                {
                                    if (SlotID == 10)
                                    {
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[10] == null)
                                    {
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[10] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else
                                    {
                                        temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[10];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[10] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = temp;
                                    }
                                }
                                else if (x >= Program.SM.States[1].GameGUI[2].X + 5 && x <= Program.SM.States[1].GameGUI[2].X + 37 && y >= Program.SM.States[1].GameGUI[2].Y + 163 && y <= Program.SM.States[1].GameGUI[2].Y + 195)
                                {
                                    if (SlotID == 11)
                                    {
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }

                                    else if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[11] == null)
                                    {
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[11] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else
                                    {
                                        temp = Logic.CurrentParty.MainParty.MyParty[0].Equipment[11];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[11] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = temp;
                                    }
                                }
                                break;
                            case ItemType.Necklace:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 6 && x <= Program.SM.States[1].GameGUI[2].X + 38 && y >= Program.SM.States[1].GameGUI[2].Y + 26 && y <= Program.SM.States[1].GameGUI[2].Y + 58)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Helmet:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 68 && x <= Program.SM.States[1].GameGUI[2].X + 100 && y >= Program.SM.States[1].GameGUI[2].Y + 46 && y <= Program.SM.States[1].GameGUI[2].Y + 78)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Cape:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 104 && x <= Program.SM.States[1].GameGUI[2].X + 136 && y >= Program.SM.States[1].GameGUI[2].Y + 60 && y <= Program.SM.States[1].GameGUI[2].Y + 92)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Bracelet:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 6 && x <= Program.SM.States[1].GameGUI[2].X + 32 && y >= Program.SM.States[1].GameGUI[2].Y + 62 && y <= Program.SM.States[1].GameGUI[2].Y + 94)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Boot:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 69 && x <= Program.SM.States[1].GameGUI[2].X + 101 && y >= Program.SM.States[1].GameGUI[2].Y + 132 && y <= Program.SM.States[1].GameGUI[2].Y + 164)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Armor:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 68 && x <= Program.SM.States[1].GameGUI[2].X + 100 && y >= Program.SM.States[1].GameGUI[2].Y + 89 && y <= Program.SM.States[1].GameGUI[2].Y + 121)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Ammunition:
                                if (x >= Program.SM.States[1].GameGUI[2].X + 104 && x <= Program.SM.States[1].GameGUI[2].X + 136 && y >= Program.SM.States[1].GameGUI[2].Y + 25 && y <= Program.SM.States[1].GameGUI[2].Y + 57)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
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
                                if (r * 4 + c + g.ScrollCount * 4 < Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX].Count)
                                {
                                    if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] == null)
                                    {
                                        Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].UnequipItems(SlotID);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                    else
                                    {
                                        temp = Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount];
                                        Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] = Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID];
                                        Logic.CurrentParty.MainParty.MyParty[0].UnequipItems(SlotID);
                                        Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = temp;
                                        return;
                                    }
                                }

                                else
                                {
                                    Logic.CurrentParty.MainParty.MyParty[0].CurMap.Drop[g.DropY][g.DropX].Add(Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID]);
                                    Logic.CurrentParty.MainParty.MyParty[0].UnequipItems(SlotID);
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                    return;
                                }
                                 * */
                                Logic.CurrentParty.MainParty.MyParty[0].DropItemFromEquipment(SlotID);
                                State = 0;
                                Program.UsingButton = null;
                                Program.MouseState = (int)MouseStateType.Normal;
                            }
                            

                        }
                    }
                }

                else if (x >= Program.SM.States[1].GameGUI[9].X && x <= Program.SM.States[1].GameGUI[9].X + 170 && y >= Program.SM.States[1].GameGUI[9].Y && y <= Program.SM.States[1].GameGUI[9].Y + 150 && Program.SM.States[1].GameGUI[9].Visibility)
                {
                    ConstructionGUI gc = (ConstructionGUI)Program.SM.States[1].GameGUI[9];
                    if (Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX] > -1)
                    {
                        SpawnBuildable b = (SpawnBuildable)Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnable[Logic.CurrentParty.MainParty.MyParty[0].CurMap.SpawnedSpawnableLocation[gc.LocY][gc.LocX]];
                        for (int r = 0; r < 3; r++)
                        {
                            if (r + gc.CurPage < b.Required.Count)
                            {
                                if (x >= gc.X + 7 && x <= gc.X + 138 && y >= gc.Y + 27 + (r * 34) && y <= gc.Y + (r + 1) * 34 + 27)
                                {
                                    if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].ID == b.Required.ElementAt(r + 3 * gc.CurPage).Key.ID)
                                    {
                                        if (b.Required.ElementAt(r + 3 * gc.CurPage).Value.Count < Program.Data.GetBuildableList()[b.ID].RequiredItems.ElementAt(r + 3 * gc.CurPage).Value)
                                        {
                                            if (Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].ID].Stackable)
                                            {
                                                b.Required.ElementAt(r + 3 * gc.CurPage).Value.Add(new SpawnItems(Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].ID));
                                                Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].Amount--;
                                                if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].Amount <= 0)
                                                {
                                                    Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = null;
                                                    State = 0;
                                                    Program.UsingButton = null;
                                                    Program.MouseState = (int)MouseStateType.Normal;
                                                }
                                            }
                                            else
                                            {
                                                b.Required.ElementAt(r + 3 * gc.CurPage).Value.Add(Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID]);
                                                Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] = null;
                                                State = 0;
                                                Program.UsingButton = null;
                                                Program.MouseState = (int)MouseStateType.Normal;
                                                return;
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
                    Logic.CurrentParty.MainParty.MyParty[0].DropItemFromEquipment(SlotID);
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

            if (Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID] != null)
            {
                if (State == 0)
                    Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].DrawSprite(_screen, X, Y);
                else
                {
                    Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].DrawSprite(_screen, Mouse.GetPosition(_screen).X - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].ID].Sprite].Size.X / 2, Mouse.GetPosition(_screen).Y - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[Logic.CurrentParty.MainParty.MyParty[0].Equipment[SlotID].ID].Sprite].Size.Y / 2);
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
        public SpawnItems Item { get; set; }
        public int State { get; set; }
    }
}
