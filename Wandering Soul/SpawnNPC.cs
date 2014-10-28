using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class SpawnNPC
    {
        int _id;
        public SpawnNPC(int id)
        {
            _id = id;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
