using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class TileData
    {
        public List<int> Variation;
        public int ID { get; set; }

        public TileData(List<int> varie)
        {
            Variation = varie;
        }

    }
}
