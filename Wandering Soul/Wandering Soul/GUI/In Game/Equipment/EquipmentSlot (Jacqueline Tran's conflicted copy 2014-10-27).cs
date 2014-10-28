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
                    if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] == null)
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
            if (State == 1 && Program.UsingButton != null)
            {
                DropGUI g = (DropGUI)Program.State[1].GameGUI[5];
                int x = Mouse.GetPosition(_screen).X;
                int y = Mouse.GetPosition(_screen).Y;
                //if (x >= GameGUI[0].X && x <= GameGUI[0].X + 369 && y >= GameGUI[0].Y && y <= GameGUI[0].Y + 25)
                //{
                //    GameGUI[0].HandleMouse(key, x, y);
                //}
                if (x >= Program.State[1].GameGUI[1].X && x <= Program.State[1].GameGUI[1].X + 178 && y >= Program.State[1].GameGUI[1].Y && y <= Program.State[1].GameGUI[1].Y + 178)
                {
                    if (Program.State[1].GameGUI[1].Visibility)
                    {
                        for (int r = 0; r < 4; r++)
                        {
                            for (int c = 0; c < 4; c++)
                            {

                                if (x >= Program.State[1].GameGUI[1].X + (c * 38) + 6 && x <= Program.State[1].GameGUI[1].X + 38 * (c + 1) && y >= Program.State[1].GameGUI[1].Y + 26 + (r * 38) && y <= Program.State[1].GameGUI[1].Y + (r + 1) * 38 + 26)
                                {
                                    if (r * 4 + c >= 8 + Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].ExtraInventorySpace)
                                        return;
                                    if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Inventory[r * 4 + c] == null)
                                    {
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].UnequipItems(SlotID, r * 4 + c);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                    else
                                    {
                                        temp = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Inventory[r * 4 + c];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].UnequipItems(SlotID, r * 4 + c);
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] = temp;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }


                else if (x >= Program.State[1].GameGUI[2].X && x <= Program.State[1].GameGUI[2].X + 140 && y >= Program.State[1].GameGUI[2].Y && y <= Program.State[1].GameGUI[2].Y + 200)
                {
                    if (Program.State[1].GameGUI[2].Visibility)
                    {
                        if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] == null)
                        {
                            return;
                        }
                        switch ((ItemType)Program.Data.MyItems[Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID].ID].Type)
                        {
                            case ItemType.Weapon:
                                if (x >= Program.State[1].GameGUI[2].X + 33 && x <= Program.State[1].GameGUI[2].X + 65 && y >= Program.State[1].GameGUI[2].Y + 95 && y <= Program.State[1].GameGUI[2].Y + 127)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;

                                    /*else if ((ItemType)Program.Data.MyItems[Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[11].ID].Type == ItemType.Weapon)
                                    {
                                        temp = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[11];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].EquipItems(SlotID);
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Inventory[SlotID] = temp;
                                    }*/
                                }
                                break;
                            case ItemType.Storage:
                                if (x >= Program.State[1].GameGUI[2].X + 103 && x <= Program.State[1].GameGUI[2].X + 135 && y >= Program.State[1].GameGUI[2].Y + 163 && y <= Program.State[1].GameGUI[2].Y + 195)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Ring:
                                if (x >= Program.State[1].GameGUI[2].X + 5 && x <= Program.State[1].GameGUI[2].X + 37 && y >= Program.State[1].GameGUI[2].Y + 128 && y <= Program.State[1].GameGUI[2].Y + 160)
                                {
                                    if (SlotID == 10)
                                    {
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[10] == null)
                                    {
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[10] = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else
                                    {
                                        temp = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[10];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[10] = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] = temp;
                                    }
                                }
                                else if (x >= Program.State[1].GameGUI[2].X + 5 && x <= Program.State[1].GameGUI[2].X + 37 && y >= Program.State[1].GameGUI[2].Y + 163 && y <= Program.State[1].GameGUI[2].Y + 195)
                                {
                                    if (SlotID == 11)
                                    {
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }

                                    else if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[11] == null)
                                    {
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[11] = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] = null;
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                    }
                                    else
                                    {
                                        temp = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[11];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[11] = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] = temp;
                                    }
                                }
                                break;
                            case ItemType.Offhand:
                                if (x >= Program.State[1].GameGUI[2].X + 104 && x <= Program.State[1].GameGUI[2].X + 136 && y >= Program.State[1].GameGUI[2].Y + 95 && y <= Program.State[1].GameGUI[2].Y + 127)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Necklace:
                                if (x >= Program.State[1].GameGUI[2].X + 6 && x <= Program.State[1].GameGUI[2].X + 38 && y >= Program.State[1].GameGUI[2].Y + 26 && y <= Program.State[1].GameGUI[2].Y + 58)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Helmet:
                                if (x >= Program.State[1].GameGUI[2].X + 68 && x <= Program.State[1].GameGUI[2].X + 100 && y >= Program.State[1].GameGUI[2].Y + 46 && y <= Program.State[1].GameGUI[2].Y + 78)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Cape:
                                if (x >= Program.State[1].GameGUI[2].X + 104 && x <= Program.State[1].GameGUI[2].X + 136 && y >= Program.State[1].GameGUI[2].Y + 60 && y <= Program.State[1].GameGUI[2].Y + 92)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Bracelet:
                                if (x >= Program.State[1].GameGUI[2].X + 6 && x <= Program.State[1].GameGUI[2].X + 32 && y >= Program.State[1].GameGUI[2].Y + 62 && y <= Program.State[1].GameGUI[2].Y + 94)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Boot:
                                if (x >= Program.State[1].GameGUI[2].X + 69 && x <= Program.State[1].GameGUI[2].X + 101 && y >= Program.State[1].GameGUI[2].Y + 132 && y <= Program.State[1].GameGUI[2].Y + 164)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Armor:
                                if (x >= Program.State[1].GameGUI[2].X + 68 && x <= Program.State[1].GameGUI[2].X + 100 && y >= Program.State[1].GameGUI[2].Y + 89 && y <= Program.State[1].GameGUI[2].Y + 121)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                            case ItemType.Ammunition:
                                if (x >= Program.State[1].GameGUI[2].X + 104 && x <= Program.State[1].GameGUI[2].X + 136 && y >= Program.State[1].GameGUI[2].Y + 25 && y <= Program.State[1].GameGUI[2].Y + 57)
                                {
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                }
                                break;
                        }
                    }

                }

                else if (x >= Program.State[1].GameGUI[5].X && x <= Program.State[1].GameGUI[5].X + 178 && y >= Program.State[1].GameGUI[5].Y && y <= Program.State[1].GameGUI[5].Y + 140)
                {
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 4; c++)
                        {
                            if (x >= Program.State[1].GameGUI[5].X + (c * 38) + 6 && x <= Program.State[1].GameGUI[5].X + 38 * (c + 1) && y >= Program.State[1].GameGUI[5].Y + 26 + (r * 38) && y <= Program.State[1].GameGUI[5].Y + (r + 1) * 38 + 26)
                            {
                                /*
                                if (r * 4 + c + g.ScrollCount * 4 < Program.MyMap.Drop[g.DropY][g.DropX].Count)
                                {
                                    if (Program.MyMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] == null)
                                    {
                                        Program.MyMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].UnequipItems(SlotID);
                                        State = 0;
                                        Program.UsingButton = null;
                                        Program.MouseState = (int)MouseStateType.Normal;
                                        return;
                                    }
                                    else
                                    {
                                        temp = Program.MyMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount];
                                        Program.MyMap.Drop[g.DropY][g.DropX][r * 4 + c + g.ScrollCount] = Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID];
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].UnequipItems(SlotID);
                                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] = temp;
                                        return;
                                    }
                                }

                                else
                                {
                                    Program.MyMap.Drop[g.DropY][g.DropX].Add(Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID]);
                                    Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].UnequipItems(SlotID);
                                    State = 0;
                                    Program.UsingButton = null;
                                    Program.MouseState = (int)MouseStateType.Normal;
                                    return;
                                }
                                 * */
                                Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].DropItemFromEquipment(SlotID);
                                State = 0;
                                Program.UsingButton = null;
                                Program.MouseState = (int)MouseStateType.Normal;
                            }
                            

                        }
                    }
                }

                else
                {
                    Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].DropItemFromEquipment(SlotID);
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

            if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID] != null)
            {
                if (State == 0)
                    Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID].DrawSprite(_screen, X, Y);
                else
                {
                    Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID].DrawSprite(_screen, Mouse.GetPosition(_screen).X - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID].ID].Sprite].Size.X / 2, Mouse.GetPosition(_screen).Y - (int)Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Equipment[SlotID].ID].Sprite].Size.Y / 2);
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
