using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class TerrainData
    {
        string _name;
        int _type;
        int _priority;
        int _tile;
        byte _blocked;

        public TerrainData(string name, int type, int priority, int tile, byte blocked)
        {
            _name = name;
            _type = type;
            _priority = priority;
            _tile = tile;
            _blocked = blocked;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public int Tile
        {
            get { return _tile; }
            set { _tile = value; }
        }

        public byte Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }
    }
}
