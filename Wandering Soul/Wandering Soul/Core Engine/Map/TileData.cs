using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class TileData
    {
        int _srcX;
        int _srcY;
        int _tileset;

        public TileData(int srcx, int srcy, int ts)
        {
            _srcX = srcx;
            _srcY = srcy;
            _tileset = ts;
        }

        public int SourceX
        {
            get { return _srcX; }
            set { _srcX = value; }
        }

        public int SourceY
        {
            get { return _srcY; }
            set { _srcY = value; }
        }

        public int Tileset
        {
            get { return _tileset; }
            set { _tileset = value; }
        }
    }
}
