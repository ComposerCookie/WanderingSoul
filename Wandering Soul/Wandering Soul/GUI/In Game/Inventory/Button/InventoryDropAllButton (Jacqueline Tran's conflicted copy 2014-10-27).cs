﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class InventoryDropAllButton : GUIButton
    {
        RenderWindow _screen;
        public InventoryDropAllButton(RenderWindow rw, int id, int x, int y)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            Visibility = true;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                for (int i = 0; i < Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Inventory.Count; i++)
                {
                    if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Inventory[i] != null)
                    {
                        Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].DropItemFromInventory(i);
                    }
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
    }
}
