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

        int _minVert;
        int _minHor;
        int _maxVert;
        int _maxHor;

        public Terrain(int size, int type, int startX, int startY)
        {
            _type = type;
            _size = size;
            _startX = startX;
            _startY = startY;
            _minHor = _minVert = _maxHor = _maxVert = 0;
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
            get { return _maxVert; }
            set { _maxVert = value; }
        }

        public int MaxHorizontal
        {
            get { return _maxHor; }
            set { _maxHor = value; }
        }

        public int MinVertical
        {
            get { return _minVert; }
            set { _minVert = value; }
        }

        public int MinHorizontal
        {
            get { return _minHor; }
            set { _minHor = value; }
        }
    }
}
