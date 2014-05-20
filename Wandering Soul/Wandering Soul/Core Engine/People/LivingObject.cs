using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

using Sprite = SFML.Graphics.Sprite;

namespace Lost_Soul
{
    public class LivingObject
    {
        string _name;
        int _type;
        int _sprite;
        int _onMapType;
        int _x;
        int _y;
        int _targetX;
        int _targetY;
        int _dir;
        int _targetDir;
        int _walkCount;
        int _speed; //Please make it factor of 16 like 1 2 4 8
        int _range;
        int _level;
        
        int _index;

        int _generalBehavior;
        
        int _walkCooldown;
        int _maxHP;
        int _curHP;
        
        bool _lefted;

        bool _isWalking;

        public LivingObject()
        {
            PathfindingPath = new List<int>();
            _generalBehavior = 0;
            _walkCooldown = 0;

            _x = 0;
            _y = 0;

            _index = Program.Data.MyLivingObject.Count;
            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(_index);

            Level = 1;
        }

        public LivingObject(string name, int type, int sprite, int maptype, int x, int y, int speed, int maxHP)
        {
            PathfindingPath = new List<int>();
            _name = name;
            _type = type;
            _sprite = sprite;
            _onMapType = maptype;
            _x = x;
            _y = y;
            _isWalking = false;
            _speed = speed;
            _lefted = false;
            _dir = 3;
            _targetDir = 3;
            
            _walkCooldown = 0;
            
            _maxHP = maxHP;
            _curHP = _maxHP;

            Level = 1;

            _generalBehavior = 0;
            _index = Program.Data.MyLivingObject.Count;
            Program.MyMap.SpawnedLivingThing[Y][X].Add(_index);
        }

        public virtual void Walk()
        {

        }

        public virtual void Walk(int dir)
        {
            if (_isWalking)
                return;

            _walkCount = 0;
            _dir = dir;
            _targetDir = dir;

            int tempx = X + Program.MyMap.MinX;
            int tempY = Y + Program.MyMap.MinY;

            switch (dir)
            {
                case 0:
                    tempx--;
                    break;
                case 1:
                    tempY--;
                    break;
                case 2:
                    tempx++;
                    break;
                case 3:
                    tempY++;
                    break;
            }

            if (Logic.GetBlockedByTerrain(tempx, tempY))
            {
                _walkCooldown = 30;
                return;
            }

            if (Logic.GetBlockedBySpawnable(tempx, tempY))
            {
                _walkCooldown = 30;
                return;
            }
            if (Logic.GetBlockedByLivingThing(tempx, tempY))
            {
                _walkCooldown = 30;
                return;
            }
            _isWalking = true;
        }

        public virtual void Update()
        {
            if (_isWalking)
            {
                _walkCount += _speed;
                if (_walkCount >= 16)
                {
                    _walkCount = 0;
                    _isWalking = false;

                    switch (_targetDir)
                    {
                        case 0:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(_index);
                            _x--;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(_index);
                            break;
                        case 1:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(_index);
                            _y--;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(_index);
                            break;
                        case 2:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(_index);
                            _x++;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(_index);
                            break;
                        case 3:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(_index);
                            _y++;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(_index);
                            break;
                    }
                }
            }
        }

        public virtual void Action()
        {
            
        }


        public virtual void Draw(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Sprite)[_sprite]);
            if (_isWalking)
            {
                switch (_targetDir)
                {
                    case 0:
                        if (_speed < 6)
                        {
                            if (_walkCount < 6)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 6 && _walkCount < 11)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 11 && _walkCount < 16)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 6 && _speed < 8)
                        {
                            if (_walkCount < 8)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 8)
                        {
                            if (_walkCount >= 8)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 1:
                        if (_speed < 6)
                        {
                            if (_walkCount < 6)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 6 && _walkCount < 11)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 11 && _walkCount < 16)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 6 && _speed < 8)
                        {
                            if (_walkCount < 8)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 8)
                        {
                            if (_walkCount >= 8)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 2:
                        if (_speed < 6)
                        {
                            if (_walkCount < 6)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 6 && _walkCount < 11)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 11 && _walkCount < 16)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 6 && _speed < 8)
                        {
                            if (_walkCount < 8)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 8)
                        {
                            if (_walkCount >= 8)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 3:
                        if (_speed < 6)
                        {
                            if (_walkCount < 6)
                                s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 6 && _walkCount < 11)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 11 && _walkCount < 16)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 6 && _speed < 8)
                        {
                            if (_walkCount < 8)
                                s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 8)
                        {
                            if (_walkCount >= 8)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                }
            }
            else
            {
                switch (_dir)
                {
                    case 0:
                        s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        break;
                    case 1:
                        s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        break;
                    case 2:
                        s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        break;
                    case 3:
                        s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        break;
                }
            }
            int tempoffsetX = 0;
            int tempoffsetY = 0;
            switch (_dir)
            {
                case 0:
                    tempoffsetX = -_walkCount;
                    break;
                case 1:
                    tempoffsetY = -_walkCount;
                    break;
                case 2:
                    tempoffsetX = _walkCount;
                    break;
                case 3:
                    tempoffsetY = _walkCount;
                    break;
            }
            s.Position = new Vector2f((_x + Program.MyMap.MinX) * 16 + tempoffsetX, (_y + Program.MyMap.MinY) * 16 - 10 + tempoffsetY);
            rw.Draw(s);
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

        public int Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public int OnMapType
        {
            get { return _onMapType; }
            set { _onMapType = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int Dir
        {
            get { return _dir; }
            set { _dir = value; }
        }

        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }

        public int GeneralBehavior
        {
            get { return _generalBehavior; }
            set { _generalBehavior = value; }
        }

        
        public int TargetX
        {
            get { return _targetX; }
            set { _targetX = value; }
        }

        public int TargetY
        {
            get { return _targetY; }
            set { _targetY = value; }
        }

        public bool IsWalking
        {
            get { return _isWalking; }
            set { _isWalking = value; }
        }

        public int TargetDir
        {
            get { return _targetDir; }
            set { _targetDir = value; }
        }

        public int WalkCount
        {
            get { return _walkCount; }
            set { _walkCount = value; }
        }

        public int WalkCooldown
        {
            get { return _walkCooldown; }
            set { _walkCooldown = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public int CurrentHealth
        {
            get { return _curHP; }
            set { _curHP = value; }
        }

        public int MaxHealth
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public List<int> PathfindingPath{ get; set; }
    }
}
