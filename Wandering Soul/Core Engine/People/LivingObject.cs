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

            //CurMap = Logic.CurrentWorld.OverWorld;

            //_index = CurMap.LivingThing.Count;
            //CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(_index);

            Level = 1;

            SideMapID = 0;
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
            _index = CurMap.LivingThing.Count;
            //CurMap.SpawnedLivingThing[Y][X].Add(_index);
            CurMap = Logic.CurrentWorld.OverWorld;

            SideMapID = 0;
        }

        public void PutOnMap()
        {
            X = Logic.CurrentWorld.SpawnMapX;
            Y = Logic.CurrentWorld.SpawnMapY;
            OnMapType = Logic.CurrentWorld.SpawnPlaceMapType;
            SideMapID = Logic.CurrentWorld.SpawnMapIndex;

            switch ((MapType)OnMapType)
            {
                case MapType.MainMap:
                    if (CurMap != null)
                    {
                        CurMap.LivingThing.Remove(this);
                        CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(Index);
                    }
                    CurMap = Logic.CurrentWorld.OverWorld;
                    CurMap.LivingThing.Add(this);
                    Index = CurMap.LivingThing.Count - 1;
                    CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(Index);
                    break;
                case MapType.SmallMap:
                    if (CurMap != null)
                    {
                        CurMap.LivingThing.Remove(this);
                        CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(Index);
                    }
                    CurMap = Logic.CurrentWorld.SmallMap[SideMapID];
                    CurMap.LivingThing.Add(this);
                    Index = CurMap.LivingThing.Count - 1;
                    CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(Index);
                    break;
            }

            IsWalking = false;
            _walkCooldown = 30;
            _walkCount = 0;
            Moved = false;
            LastX = X;
            LastY = Y;
            TargetX = X;
            TargetY = Y;
            Dir = 3;
        }

        public virtual void Walk()
        {

        }

        public virtual void Walk(int dir, bool change)
        {
            if (_isWalking)
                return;

            _walkCount = 0;
            if (change)
            {
                _dir = dir;
            }
            
            _targetDir = dir;

            LastX = _x;
            LastY = _y;

            int tempx = X + CurMap.MinX;
            int tempY = Y + CurMap.MinY;

            switch (_targetDir)
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

            //if (OnMapType == (int)MapType.MainMap)
            //    m = Logic.MainMap;

            if (Logic.BlockedAt(tempx, tempY, CurMap, 0))
            {
                _walkCooldown = 30;
                return;
            }

            _isWalking = true;
            Moved = true;
        }

        public virtual void Update()
        {
            if (_isWalking)
            {
                if (_walkCount >= 64 && Moved)
                {
                    switch (_targetDir)
                    {
                        case 0:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(_index);
                            _x--;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(_index);
                            Moved = false;
                            break;
                        case 1:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(_index);
                            _y--;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(_index);
                            Moved = false;
                            break;
                        case 2:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(_index);
                            _x++;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(_index);
                            Moved = false;
                            break;
                        case 3:
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Remove(_index);
                            _y++;
                            CurMap.SpawnedLivingThing[Y + CurMap.MinY][X + CurMap.MinX].Add(_index);
                            Moved = false;
                            break;
                    }
                }

                _walkCount += _speed;
                if (_walkCount >= 128)
                {
                    switch (TargetDir)
                    {
                        case 0:
                            LastX--;
                            break;
                        case 1:
                            LastY--;
                            break;
                        case 2:
                            LastX++;
                            break;
                        case 3:
                            LastY++;
                            break;
                    }

                    _walkCount = 0;
                    _isWalking = false;
                }
            }
        }

        public virtual void Action(byte hand)
        {
            
        }

        public virtual void Draw(RenderWindow rw, int x, int y)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Sprite)[_sprite]);
            int width = (int)s.Texture.Size.X / 3;
            int height = (int)s.Texture.Size.Y / 4;
            if (_isWalking)
            {
                switch (_dir)
                {
                    case 0:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 1:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 2:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 3:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
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
            switch (_targetDir)
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

            s.Position = new Vector2f(x, y);
            rw.Draw(s);
        }


        public virtual void Draw(RenderWindow rw)
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Sprite)[_sprite]);
            int width = (int)s.Texture.Size.X / 3;
            int height = (int)s.Texture.Size.Y / 4;
            if (_isWalking)
            {
                switch (_dir)
                {
                    case 0:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 2, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 1:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 * 3, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 2:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
                            {
                                if (_lefted)
                                    s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                                else
                                    s.TextureRect = new IntRect(0, (int)s.Texture.Size.Y / 4 , (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            }
                        }
                        break;
                    case 3:
                        if (_speed < 48)
                        {
                            if (_walkCount < 48)
                                s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 48 && _walkCount < 88)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else if (_walkCount >= 88 && _walkCount < 128)
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 48 && _speed < 128)
                        {
                            if (_walkCount < 128)
                                s.TextureRect = new IntRect(0, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                            else
                                s.TextureRect = new IntRect((int)s.Texture.Size.X / 3 * 2, 0, (int)s.Texture.Size.X / 3, (int)s.Texture.Size.Y / 4);
                        }
                        else if (_speed >= 128)
                        {
                            if (_walkCount >= 128)
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
            switch (_targetDir)
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
            
            s.Position = new Vector2f((LastX + CurMap.MinX) * 16 + tempoffsetX / 8, (LastY + CurMap.MinY) * 16 - 10 + tempoffsetY / 8);
            rw.Draw(s);

            //Draw minihud
            
            s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.SmallHUD)[0]);
            s.TextureRect = new IntRect(0, 0, 1, 1);
            for (int i = 1; i < 3; i++)
            {
                s.Position = new Vector2f((LastX + CurMap.MinX) * 16 + tempoffsetX / 8, (LastY + CurMap.MinY) * 16 - 10 + tempoffsetY / 8 - height / 2 + 8 + i);
                rw.Draw(s);
                s.Position = new Vector2f((LastX + CurMap.MinX) * 16 + tempoffsetX / 8 + width, (LastY + CurMap.MinY) * 16 - 10 + tempoffsetY / 8 - height / 2 + 8 + i);
                rw.Draw(s);
            }
            for (int i = 0; i < width + 1; i++)
            {
                s.Position = new Vector2f((LastX + CurMap.MinX) * 16 + tempoffsetX / 8 + i, (LastY + CurMap.MinY) * 16 - 10 + tempoffsetY / 8 - height / 2 + 8);
                rw.Draw(s);
                s.Position = new Vector2f((LastX + CurMap.MinX) * 16 + tempoffsetX / 8 + i, (LastY + CurMap.MinY) * 16 - 10 + tempoffsetY / 8 - height / 2 + 10);
                rw.Draw(s);
            }
            //find health percentage
            int percentage = _curHP * 100 / MaxHealth;
            for (int i = 1; i < width; i++)
            {
                if (i * 100 / (width - 1) > percentage)
                    s.TextureRect = new IntRect(2, 0, 1, 1);
                else
                    s.TextureRect = new IntRect(1, 0, 1, 1);
                s.Position = new Vector2f((LastX + CurMap.MinX) * 16 + tempoffsetX / 8 + i - 8, (LastY + CurMap.MinY) * 16 - 10 + tempoffsetY / 8 - height / 2 - 8);
                rw.Draw(s);
            }

        }

        public void ReceiveDamage(int damage, LivingObject caster)
        {
            if (Targeting == null)
                Targeting = caster;
            if (CurrentDefenseAction != null)
            {
                damage -= (int)(CurrentDefenseAction.ID.BaseDamage * ((float)Logic.RandomizeDamage() / 10));
                if (damage < 0)
                    damage = 0;
            }
            _curHP -= damage;
            CurMap.MiniText.Add(new MiniText(damage + "", 10, (X + CurMap.MinX) * Program.Data.TileSizeX, (Y + CurMap.MinY) * Program.Data.TileSizeY - 18, 60, Color.Red, true, 0.4f));
        }

        public bool Lefted
        {
            get { return _lefted; }
            set { _lefted = value; }
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

        public bool Moved { get; set; }
        public List<int> PathfindingPath{ get; set; }
        public int LastX { get; set; }
        public int LastY { get; set; }
        public int SideMapID { get; set; }
        public Map CurMap { get; set; }
        public LivingObject Targeting { get; set; }
        public int LeftAttackCooldown { get; set; }
        public int RightAttackCooldown { get; set; }
        public int AttackSpeed { get; set; }
        public AttackAction CurrentDefenseAction { get; set; }
    }
}
