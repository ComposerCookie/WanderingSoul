using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class Tile
    {
        int _id; //this link to a spawned terrain

        public Tile(int id, int x, int y)
        {
            _id = id;
            X = x;
            Y = y;
            Variation = -1;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Variation { get; set; }

        public void Draw(RenderWindow rw, Map m, int x, int y) // Autotile included
        {
            /*
             1 = Left
             2 = Up
             3 = Right
             4 = Down
             
             */


            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Tile)[m.SpawnedTerrain[ID].Type]);
            s.Position = new Vector2f(x * Program.Data.TileSizeX, y * Program.Data.TileSizeY);
            //Get the 4 tile around it
            int[] Around = new int[5];
            Around[0] = m.SpawnedTerrain[m.Y[y].Tile[x].ID].Type; // This tile
            Around[1] = m.SpawnedTerrain[m.Y[y].Tile[x - 1].ID].Type; // Left Tile
            Around[2] = m.SpawnedTerrain[m.Y[y - 1].Tile[x].ID].Type; // Up Tile
            Around[3] = m.SpawnedTerrain[m.Y[y].Tile[x + 1].ID].Type; // Right Tile
            Around[4] = m.SpawnedTerrain[m.Y[y + 1].Tile[x].ID].Type; // Down Tile

            if (Around[0] != Around[1] && Around[0] != Around[2] && Around[0] != Around[3] && Around[0] != Around[4]) // case All Side Blocked, not equal anything
            {
                s.TextureRect = new IntRect(48, 192, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(32, 192, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(48, 176, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(64, 192, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(48, 208, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] == Around[1] && Around[0] == Around[3] && Around[0] != Around[2] && Around[0] != Around[4]) // Case Penetration Vertical
            {
                s.TextureRect = new IntRect(32, 176, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(32, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[4]];
                s.TextureRect = new IntRect(32, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] == Around[2] && Around[0] == Around[4] && Around[0] != Around[1] && Around[0] != Around[3]) // Case Penetration Horizontal
            {
                s.TextureRect = new IntRect(32, 160, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(16, 96, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(48, 96, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] != Around[2] && Around[0] != Around[4] && Around[0] == Around[1] && Around[0] != Around[3]) // Case Dead End Left
            {
                s.TextureRect = new IntRect(16, 192, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(48, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(0, 192, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[4]];
                s.TextureRect = new IntRect(64, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] == Around[2] && Around[0] != Around[4] && Around[0] != Around[1] && Around[0] != Around[3]) // Case Dead End Up
            {
                s.TextureRect = new IntRect(16, 208, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(0, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(48, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[4]];
                s.TextureRect = new IntRect(0, 208, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] != Around[2] && Around[0] != Around[4] && Around[0] != Around[1] && Around[0] == Around[3]) // Case Dead End Right
            {
                s.TextureRect = new IntRect(16, 160, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(0, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(0, 160, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[4]];
                s.TextureRect = new IntRect(16, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] != Around[2] && Around[0] == Around[4] && Around[0] != Around[1] && Around[0] != Around[3]) // Case Dead End Down
            {
                s.TextureRect = new IntRect(16, 176, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(0, 176, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(64, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(16, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] != Around[2] && Around[0] == Around[4] && Around[0] != Around[1] && Around[0] == Around[3]) // Case Corner Left Top
            {
                s.TextureRect = new IntRect(16, 16, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(16, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(0, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

            }

            else if (Around[0] != Around[2] && Around[0] == Around[4] && Around[0] == Around[1] && Around[0] != Around[3]) // Case Corner Right Top
            {
                s.TextureRect = new IntRect(48, 16, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(48, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(64, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

            }

            else if (Around[0] == Around[2] && Around[0] != Around[4] && Around[0] != Around[1] && Around[0] == Around[3]) // Case Corner Left Bottom
            {
                s.TextureRect = new IntRect(16, 48, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(0, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[4]];
                s.TextureRect = new IntRect(16, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

            }

            else if (Around[0] == Around[2] && Around[0] != Around[4] && Around[0] == Around[1] && Around[0] != Around[3]) // Case Corner Right Bottom
            {
                s.TextureRect = new IntRect(48, 48, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[4]];
                s.TextureRect = new IntRect(64, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(48, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

            }

            else if (Around[0] == Around[2] && Around[0] == Around[4] && Around[0] != Around[1] && Around[0] == Around[3]) // Case Edge Left
            {
                s.TextureRect = new IntRect(16, 32, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[1]];
                s.TextureRect = new IntRect(16, 96, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] != Around[2] && Around[0] == Around[4] && Around[0] == Around[1] && Around[0] == Around[3]) // Case Edge Top
            {
                s.TextureRect = new IntRect(32, 16, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[2]];
                s.TextureRect = new IntRect(32, 80, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] == Around[2] && Around[0] == Around[4] && Around[0] == Around[1] && Around[0] != Around[3]) // Case Edge Right
            {
                s.TextureRect = new IntRect(48, 32, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[3]];
                s.TextureRect = new IntRect(48, 96, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else if (Around[0] == Around[2] && Around[0] != Around[4] && Around[0] == Around[1] && Around[0] == Around[3]) // Case Edge Bottom
            {
                s.TextureRect = new IntRect(32, 48, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);

                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Tile)[Around[4]];
                s.TextureRect = new IntRect(32, 112, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            else
            {
                s.TextureRect = new IntRect(32, 32, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }

            if (Variation > -1)
            {
                s.Texture = Program.Data.SpriteBasedOnType(SpriteType.Variation)[Program.Data.MyVariation[Variation].ID];
                s.TextureRect = new IntRect(0, 0, Program.Data.TileSizeX, Program.Data.TileSizeY);
                rw.Draw(s);
            }
        }
    }
}
