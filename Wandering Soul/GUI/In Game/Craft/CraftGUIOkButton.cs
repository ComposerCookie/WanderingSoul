using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class CraftGUIOkButton : GUIButton
    {
        RenderWindow _screen;
        public CraftGUIOkButton(RenderWindow rw, int id, int x, int y)
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
                CraftGUI g = (CraftGUI)Program.SM.States[1].GameGUI[10];
                if (g.CurPick + 4 * g.PickPage < Logic.KnownRecipeForThisCharacter(Program.Data.CurrentParty.MainParty.MyParty[0], g.CurClass).Count)
                {
                    Items i = Program.Data.MyItems[Logic.KnownRecipeForThisCharacter(Program.Data.CurrentParty.MainParty.MyParty[0], g.CurClass)[g.CurPick + 4 * g.PickPage]];
                    bool cancraft = true;
                    for (int r = 0; r < i.ItemRequired.Count; r++)
                    {
                        if (Logic.GetTotalAmountOfThisItemIn(Program.Data.CurrentParty.MainParty.MyParty[0], i.ItemRequired.ElementAt(r).Key) < i.ItemRequired.ElementAt(r).Value)
                            cancraft = false;
                    }
                    if (cancraft)
                    {
                        int total = 0;
                        for (int r = 0; r < i.ItemRequired.Count; r++)
                        {
                            //Logic.RemoveItemsFromInventory(Program.Data.CurrentParty.MainParty.MyParty[0], i.ItemRequired.ElementAt(r).Key, i.ItemRequired.ElementAt(r).Value);
                            total += Logic.GetTotalAmountOfThisItemIn(Program.Data.CurrentParty.MainParty.MyParty[0], i.ItemRequired.ElementAt(r).Key);
                        }
                        Program.Data.CurrentParty.MainParty.MyParty[0].CurrentAction = 3;
                        Program.Data.CurrentParty.MainParty.MyParty[0].CurrentActionIndex = Logic.KnownRecipeForThisCharacter(Program.Data.CurrentParty.MainParty.MyParty[0], g.CurClass)[g.CurPick + 4 * g.PickPage];

                        Program.Data.CurrentParty.MainParty.MyParty[0].ActionCooldown = total * 30;
                        //Program.Data.CurrentParty.MainParty.MyParty[0].Inventory[Program.Data.CurrentParty.MainParty.MyParty[0].FindNextEmptySpace()] = new SpawnItems(Logic.KnownRecipeForThisCharacter(Program.Data.CurrentParty.MainParty.MyParty[0], g.CurClass)[g.CurPick + 4 * g.PickPage]);
                    }
                }
            }//Program.SM.States[1].GameGUI[2].Visibility = !Program.SM.States[1].GameGUI[2].Visibility;
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
