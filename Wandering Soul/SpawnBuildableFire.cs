using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class SpawnBuildableFire : SpawnBuildable
    {
        public bool OnFire { get; set; }
        public int TickLeft { get; set; }
        public int TillNextFrame { get; set; }
        public int CurrentFireFrame { get; set; }
        

        public SpawnBuildableFire(int id, int x, int y, Map m)
        {
            ID = id;
            X = x;
            Y = y;
            OnMap = m;
        }

        public override void Update()
        {
            BuildFire bf = (BuildFire)Program.Data.GetBuildableList()[ID];
            TickLeft++;
            TillNextFrame++;
            if (TickLeft > bf.Tick)
            {
                OnMap.SpawnedSpawnable[OnMap.SpawnedSpawnableLocation[Y + OnMap.MinY][X + OnMap.MinX]] = null;
                OnMap.SpawnedSpawnableLocation[Y + OnMap.MinY][X + OnMap.MinX] = -1;
            }
            if (TillNextFrame > bf.FireSpeed)
            {
                TillNextFrame = 0;
                CurrentFireFrame++;
                if (CurrentFireFrame >= bf.LittedSpriteAnim.Count)
                    CurrentFireFrame = 0;
            }
        }

        public override void DrawBot(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite();
            BuildFire bf = (BuildFire)Program.Data.GetBuildableList()[ID];
            if (Builded)
            {
                if (OnFire)
                    s.Texture = Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[bf.LittedSpriteAnim[CurrentFireFrame]];
                else
                    s.Texture = Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].Sprite];
            }
            else
            {
                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].StartSprite];
            }
            s.Position = new Vector2f((X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX) * Program.Data.TileSizeX, (Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY) * Program.Data.TileSizeY);
            s.TextureRect = new IntRect(0, (int)(s.Texture.Size.Y - Program.Data.GetBuildableList()[ID].SizeY * 16), (int)(s.Texture.Size.X), Program.Data.GetBuildableList()[ID].SizeY * 16);
            rw.Draw(s);
        }

        public override void DrawTop(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite();
            BuildFire bf = (BuildFire)Program.Data.GetBuildableList()[ID];
            if (Builded)
            {
                if (OnFire)
                    s.Texture = Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[bf.LittedSpriteAnim[CurrentFireFrame]];
                else
                    s.Texture = Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].Sprite];
            }
            else
            {
                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.BuildingSprite)[Program.Data.GetBuildableList()[ID].StartSprite];
            }

            s.Position = new Vector2f((X + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinX) * Program.Data.TileSizeX, (Y + Logic.CurrentParty.MainParty.MyParty[0].CurMap.MinY - 1) * Program.Data.TileSizeX);
            s.TextureRect = new IntRect(0, 0, (int)(s.Texture.Size.X), (int)(s.Texture.Size.Y - Program.Data.GetBuildableList()[ID].SizeY * 16));
            rw.Draw(s);
        }

        
    }
}
