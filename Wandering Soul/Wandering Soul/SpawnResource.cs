using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class SpawnResource : SpawnSpawnable
    {
        public int ID { get; set; }
        public int CurHealth { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public SpawnResource(int id, int x, int y)
        {
            ID = id;
            X = x;
            Y = y;
            CurHealth = Program.Data.GetResourceList()[ID].MaxHealth;
        }

        public void DrawBot(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Resource)[Program.Data.GetResourceList()[ID].Sprite]);
            s.Position = new Vector2f((X + Program.MyMap.MinX) * Program.Data.TileSizeX, (Y + Program.MyMap.MinY) * Program.Data.TileSizeY);
            s.TextureRect = new IntRect(0, (int)(s.Texture.Size.Y - Program.Data.GetResourceList()[ID].SizeY * 16), (int)(s.Texture.Size.X), Program.Data.GetResourceList()[ID].SizeY * 16);
            rw.Draw(s);
        }

        public void DrawTop(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Resource)[Program.Data.GetResourceList()[ID].Sprite]);
            s.Position = new Vector2f((X + Program.MyMap.MinX) * Program.Data.TileSizeX, (Y + Program.MyMap.MinY - 1) * Program.Data.TileSizeX);
            s.TextureRect = new IntRect(0, 0, (int)(s.Texture.Size.X), (int)(s.Texture.Size.Y - Program.Data.GetResourceList()[ID].SizeY * 16));
            rw.Draw(s);
        }
    }
}
