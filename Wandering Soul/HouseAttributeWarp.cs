using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class HouseAttributeWarp : HouseAttribute
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ToMapType { get; set; }
        public int MapID { get; set; }

        public HouseAttributeWarp(int x, int y, int maptype, int mapid)
        {
            X = x;
            Y = y;
            ToMapType = maptype;
            MapID = mapid;
        }
    }
}
