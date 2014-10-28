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
        public SpawnItems(int id)
        {
            ID = id;
        }

        public void DrawSprite(RenderWindow rw, int X, int Y)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Items)[Program.Data.MyItems[ID].Sprite]);
            s.Position = new Vector2f(X, Y);
            rw.Draw(s);
        }

        public void DrawDrop(RenderWindow rw, int X, int Y)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.DropSprite)[Program.Data.MyItems[ID].DropSprite]);
            s.Position = new Vector2f(X, Y);
            rw.Draw(s);
        }
    }
}
