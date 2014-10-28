using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Animation
    {
        public int TotalFrame { get; set; }
        public int FrameWidth { get; set; }
        public int ID { get; set; }
        public int FrameHeight { get; set; }
        public int NextFrameTimeCount { get; set; }
        public string Name { get; set; }

        public Animation(string name, int totalframe, int width, int height, int id, int time)
        {
            Name = name;
            TotalFrame = totalframe;
            FrameWidth = width;
            FrameHeight = height;
            ID = id;
            NextFrameTimeCount = time;
        }
    }
}
