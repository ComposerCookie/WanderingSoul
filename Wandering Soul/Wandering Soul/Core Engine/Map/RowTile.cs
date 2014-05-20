using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class RowTile
    {
        List<Tile> _tile;
        public RowTile()
        {
            _tile = new List<Tile>();
        }

        public List<Tile> Tile
        {
            get { return _tile; }
            set { _tile = value; }
        }
    }
}
