using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Lost_Soul
{
    public class FPSCounter
    {
        public Stopwatch Timer { get; set; }
        public int Frame { get; set; }

        public FPSCounter()
        {
            Timer = new Stopwatch();
            Timer.Start();
            Frame = 0;
        }

        public void Stop()
        {
            Timer.Stop();
        }

        public void Reset()
        {
            Timer.Reset();
        }

    }
}
