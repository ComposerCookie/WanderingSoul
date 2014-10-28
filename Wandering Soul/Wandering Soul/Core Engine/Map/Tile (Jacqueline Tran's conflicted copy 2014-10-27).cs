using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
