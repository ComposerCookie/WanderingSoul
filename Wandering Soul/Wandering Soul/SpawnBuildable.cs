﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class SpawnBuildable : SpawnSpawnable
    {
        public int ID { get; set; }
        public int CurHealth { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Builded { get; set; }
        public Dictionary<SpawnItems, List<SpawnItems>> Required { get; set; }
        public Dictionary<SpawnItems, int> Built { get; set; }

        public SpawnBuildable(int id, int x, int y)
        {
            ID = id;
            X = x;
            Y = y;
            CurHealth = Program.Data.GetBuildableList()[ID].MaxHealth;

            Required = new Dictionary<SpawnItems, List<SpawnItems>>();
            Built = new Dictionary<SpawnItems, int>();

            for (int i = 0; i < Program.Data.GetBuildableList()[ID].RequiredItems.Count; i++)
            {
                Required.Add(new SpawnItems(Program.Data.GetBuildableList()[ID].RequiredItems.ElementAt(i).Key.ID), new List<SpawnItems>());
                Built.Add(new SpawnItems(Program.Data.GetBuildableList()[ID].RequiredItems.ElementAt(i).Key.ID), 0);
            }
        }

        public void DrawBot(RenderWindow rw)
        {
            SFML.Graphics.Sprite s;
            if (Builded)
            {
                s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].Sprite]);
            }
            else
            {
                s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].StartSprite]);
            }
            s.Position = new Vector2f((X + Program.MyMap.MinX) * Program.Data.TileSizeX, (Y + Program.MyMap.MinY) * Program.Data.TileSizeY);
            s.TextureRect = new IntRect(0, (int)(s.Texture.Size.Y - Program.Data.GetBuildableList()[ID].SizeY * 16), (int)(s.Texture.Size.X), Program.Data.GetBuildableList()[ID].SizeY * 16);
            rw.Draw(s);
        }

        public void DrawTop(RenderWindow rw)
        {
            if (Builded)
            {
                SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].Sprite]);
                s.Position = new Vector2f((X + Program.MyMap.MinX) * Program.Data.TileSizeX, (Y + Program.MyMap.MinY - 1) * Program.Data.TileSizeX);
                s.TextureRect = new IntRect(0, 0, (int)(s.Texture.Size.X), (int)(s.Texture.Size.Y - Program.Data.GetBuildableList()[ID].SizeY * 16));
                rw.Draw(s);
            }
        }

        public void DrawBot(RenderWindow rw, int x, int y, bool yaynay)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].Sprite]);
            s.Position = new Vector2f((x + Program.MyMap.MinX) * Program.Data.TileSizeX, (y + Program.MyMap.MinY) * Program.Data.TileSizeY);
            s.TextureRect = new IntRect(0, (int)(s.Texture.Size.Y - Program.Data.GetBuildableList()[ID].SizeY * 16), (int)(s.Texture.Size.X), Program.Data.GetBuildableList()[ID].SizeY * 16);
            rw.Draw(s);
            RectangleShape r = new RectangleShape(new Vector2f((int)(s.Texture.Size.X), Program.Data.GetBuildableList()[ID].SizeY * 16));
            r.Position = s.Position;
            switch (yaynay)
            {
                case true:
                    r.FillColor = new Color(255, 0, 0, 127);
                    break;
                case false:
                    r.FillColor = new Color(0, 255, 0, 127);
                    break;
            }
            rw.Draw(r);
        }

        public void DrawTop(RenderWindow rw, int x, int y, bool yaynay)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].Sprite]);
            s.Position = new Vector2f((x + Program.MyMap.MinX) * Program.Data.TileSizeX, (y + Program.MyMap.MinY - 1) * Program.Data.TileSizeX);
            s.TextureRect = new IntRect(0, 0, (int)(s.Texture.Size.X), (int)(s.Texture.Size.Y - Program.Data.GetBuildableList()[ID].SizeY * 16));
            rw.Draw(s);
            if (Program.Data.GetBuildableList()[ID].SizeY > 1)
            {
                RectangleShape r = new RectangleShape(new Vector2f((int)(s.Texture.Size.X), Program.Data.GetBuildableList()[ID].SizeY * 16));
                r.Position = s.Position;
                switch (yaynay)
                {
                    case true:
                        r.FillColor = new Color(255, 0, 0, 127);
                        break;
                    case false:
                        r.FillColor = new Color(0, 255, 0, 127);
                        break;
                }
                rw.Draw(r);
            }
        }
    }
}
