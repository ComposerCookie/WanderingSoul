using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
namespace Lost_Soul
{
    public class MiniText
    {
        public Text Text { get; set; }
        public int Time { get; set; }
        public bool Move { get; set; }
        public float Speed { get; set; }

        public MiniText(string txt, int size, int x, int y, int time, Color color, bool move, float spd)
        {
            Text = new Text();
            Text.DisplayedString = txt;
            Text.Font = Program.Data.Font;
            Text.CharacterSize = (uint)size;
            Text.Position = new Vector2f(x, y);
            Text.Color = color;
            Time = time;
            Move = move;
            Speed = spd;
        }

        public void Update()
        {
            Time--;
        }

        public void Draw(RenderWindow rw)
        {   
            if (Move)
                Text.Position = new Vector2f(Text.Position.X, Text.Position.Y - Speed);
            rw.Draw(Text);
        }
    }
}
