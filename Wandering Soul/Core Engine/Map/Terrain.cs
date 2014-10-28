using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Terrain
    {
        int _type;
        int _size;
        int _spawned;

        int _startX;
        int _startY;

        int MinVert;
        int MinHor;
        int MaxVert;
        int MaxHor;

        public Terrain(int size, int type, int startX, int startY)
        {
            _type = type;
            _size = size;
            _startX = startX;
            _startY = startY;
            MinHor = MinVert = MaxHor = MaxVert = 0;
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int Spawned
        {
            get { return _spawned; }
            set { _spawned = value; }
        }

        public int StartX
        {
            get { return _startX; }
        }

        public int StartY
        {
            get { return _startY; }
        }

        public int MaxVertical
        {
            get { return MaxVert; }
            set { MaxVert = value; }
        }

        public int MaxHorizontal
        {
            get { return MaxHor; }
            set { MaxHor = value; }
        }

        public int MinVertical
        {
            get { return MinVert; }
            set { MinVert = value; }
        }

        public int MinHorizontal
        {
            get { return MinHor; }
            set { MinHor = value; }
        }
    }
}
