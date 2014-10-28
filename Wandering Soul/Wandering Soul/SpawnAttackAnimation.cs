using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class SpawnAttackAnimation : SpawnAnimation
    {
        public AttackAction Attack;
        public SpawnAttackAnimation(int id, int x, int y, int dir, bool auto, AttackAction atk)
        {
            ID = id;
            X = x;
            Y = y;
            Dir = dir;

            CurrentFrame = 0;
            NextFrame = 0;
            Attack = atk;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Animation)[Program.Data.MyAnimation[ID].ID]);
            int TilePerRow = (int)s.Texture.Size.X / Program.Data.MyAnimation[ID].FrameWidth;

            int PosX = CurrentFrame % TilePerRow;

            s.TextureRect = new IntRect(PosX * Program.Data.MyAnimation[ID].FrameWidth, Dir * Program.Data.MyAnimation[ID].FrameHeight, Program.Data.MyAnimation[ID].FrameWidth, Program.Data.MyAnimation[ID].FrameHeight);
            s.Position = new Vector2f((X + Attack.Caster.CurMap.MinX) * Program.Data.TileSizeX, (Y + Attack.Caster.CurMap.MinY) * Program.Data.TileSizeY);
            rw.Draw(s);
        }

    }
}
