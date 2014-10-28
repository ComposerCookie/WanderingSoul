using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class SpawnAnimation
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Dir { get; set; }
        public int NextFrame { get; set; }
        public int CurrentFrame { get; set; }
        public bool Automatic { get; set; }
        public bool Animated { get; set; }

        public SpawnAnimation()
        {
        }

        public SpawnAnimation(int id, int x, int y, int dir, bool auto)
        {
            ID = id;
            X = x;
            Y = y;
            Dir = dir;

            CurrentFrame = 0;
            NextFrame = 0;
        }

        public virtual void Update()
        {
            if (NextFrame >= Program.Data.MyAnimation[ID].NextFrameTimeCount)
            {
                NextFrame = 0;
                CurrentFrame++;
                if (CurrentFrame >= Program.Data.MyAnimation[ID].TotalFrame)
                {
                    CurrentFrame = 0;
                    if (!Automatic)
                        Animated = true;
                }
            }
            NextFrame++;
        }

        public virtual void Draw(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Animation)[Program.Data.MyAnimation[ID].ID]);
            int TilePerRow = (int)s.Texture.Size.X / Program.Data.MyAnimation[ID].FrameWidth;

            int PosX = CurrentFrame % TilePerRow;

            s.TextureRect = new IntRect(PosX * Program.Data.MyAnimation[ID].FrameWidth, Dir * Program.Data.MyAnimation[ID].FrameHeight, Program.Data.MyAnimation[ID].FrameWidth, Program.Data.MyAnimation[ID].FrameHeight);
            s.Position = new Vector2f(X * Program.Data.TileSizeX, Y * Program.Data.TileSizeY);
        }
    }
}
