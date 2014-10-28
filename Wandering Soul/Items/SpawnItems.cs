using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class SpawnItems
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public SpawnItems(int id)
        {
            ID = id;
            Amount = 1;
        }

        public void DrawSprite(RenderWindow rw, int X, int Y)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[ID].Sprite]);
            s.Position = new Vector2f(X, Y);
            rw.Draw(s);

            Text t = new Text();
            t.Font = Program.Data.Font;
            t.DisplayedString = "" + Amount;
            t.Position = new Vector2f(X + 26 - t.DisplayedString.Length * 5, Y + 14);
            t.CharacterSize = 14;

            if (Program.Data.MyItems[ID].Stackable)
            {
                rw.Draw(t);
            }
        }

        public void DrawDrop(RenderWindow rw, int X, int Y)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.DropSprite)[Program.Data.MyItems[ID].DropSprite]);
            s.Position = new Vector2f(X, Y);
            rw.Draw(s);
        }
    }
}
