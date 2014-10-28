using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class AnimationManager
    {
        public List<SpawnAnimation> Animating { get; set; }
        public AnimationManager()
        {
            Animating = new List<SpawnAnimation>();
        }
        
        public void Update()
        {
            for (int i = Animating.Count - 1; i >= 0; i--)
            {
                Animating[i].Update();
                if (Animating[i].Animated)
                    Animating.RemoveAt(i);
            }
        }

        public void Draw(RenderWindow rw)
        {
            for (int i = Animating.Count - 1; i >= 0; i--)
            {
                Animating[i].Draw(rw);
            }
        }
    }
}
