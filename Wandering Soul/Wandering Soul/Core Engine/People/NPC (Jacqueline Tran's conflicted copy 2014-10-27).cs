using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class NPC : LivingObject
    {
        bool _playable;
        byte _gender;

        int _playerParty;
        int _partyBehavior;

        int _curMP;
        int _maxMP;

        int _curEXP;

        int _job;

        int _extraInventorySpace;

        List<SpawnItems> _inventory;
        List<SpawnItems> _equipment;
        
        public NPC(string name, int type, byte gender, int sprite, int onmaptype, bool playable, int speed, int range, int job)
        {
            _inventory = new List<SpawnItems>();
            _equipment = new List<SpawnItems>();

            for (int i = 0; i < 12; i++)
                _equipment.Add(null);
            for (int i = 0; i < 16; i++)
                _inventory.Add(null);
            _playerParty = -1;

            _partyBehavior = (int)PartyBehaviorType.Roaming;

            Name = name;
            Type = type;
            Sprite = sprite;
            OnMapType = onmaptype;
            Speed = speed;
            _gender = gender;
            _playable = playable;
            Dir = 3;
            Range = range;
            MaxHealth =  CurrentHealth = 100;
            MaxMana = CurrentMana = 10;
            CurrentExperience = 0;

            CurrentHealth = 50;
            CurrentMana = 6;

            _extraInventorySpace = 0;
        }

        public void DropItemFromInventory(int id)
        {
            if (id >= 16)
                return;
            if (_inventory[id] != null)
            {
                Program.MyMap.Drop[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(_inventory[id]);
                if (_playerParty > -1)
                    Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " dropped a " + Program.Data.MyItems[_inventory[id].ID].Name);
                _inventory[id] = null;
            }
        }

        public void DropItemFromEquipment(int id)
        {
            if (id >= 12)
                return;
            if (_equipment[id] != null)
            {
                Program.MyMap.Drop[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(_equipment[id]);
                if (_playerParty > -1)
                    Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " dropped " + Program.Data.MyItems[_equipment[id].ID].Name);
                _equipment[id] = null;
            }
        }

        public void EquipItems(int id)
        {
            switch ((ItemType)Program.Data.MyItems[_inventory[id].ID].Type)
            {
                case ItemType.Weapon:
                    _equipment[11] = _inventory[id];
                    _inventory[id] = null;
                    if (_playerParty > -1)
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " equiped " + Program.Data.MyItems[_equipment[11].ID].Name);
                    break;
            }
        }

        public void EquipItems(SpawnItems s)
        {
            switch ((ItemType)Program.Data.MyItems[s.ID].Type)
            {
                case ItemType.Weapon:
                    _equipment[11] = s;
                    if (_playerParty > -1)
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " equiped " + Program.Data.MyItems[_equipment[11].ID].Name);
                    break;
            }
        }

        public int FindNextEmptySpace()
        {
            bool findnull = false;
            int nullat = 0;
            while (findnull == false)
            {
                if (_inventory[nullat] == null)
                {
                    findnull = true;
                }
                else
                {
                    nullat++;
                    if (nullat >= 16)
                        findnull = true;
                }
            }
            return nullat;
        }

        public void UnequipItems(int id)
        {
            if (_equipment[id] != null)
            {
                if (_playerParty > -1 && ((ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Weapon || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Storage || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Ring || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Offhand || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Necklace || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Helmet || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Cape || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Bracelet || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Boot || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Armor || (ItemType)Program.Data.MyItems[_equipment[id].ID].Type == ItemType.Ammunition))
                    Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " unquipped " + Program.Data.MyItems[_equipment[id].ID].Name);
                _equipment[id] = null;
            }
        }

        public bool UnequipItems(int id, int invid)
        {
            if (_equipment[id] != null)
            {
                if (_inventory[invid] == null)
                {
                    _inventory[invid] = _equipment[id];
                    if (_playerParty > -1 && ((ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Weapon || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Storage || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Ring || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Offhand || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Necklace || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Helmet ||(ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Cape ||(ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Bracelet ||(ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Boot ||(ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Armor ||(ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Ammunition))
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " unquipped " + Program.Data.MyItems[_inventory[invid].ID].Name);
                    _equipment[id] = null;
                }
                else
                {
                    _inventory[invid] = _equipment[id];
                    _equipment[id] = _inventory[invid];
                    if (_playerParty > -1 && ((ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Weapon || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Storage || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Ring || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Offhand || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Necklace || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Helmet || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Cape || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Bracelet || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Boot || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Armor || (ItemType)Program.Data.MyItems[_inventory[invid].ID].Type == ItemType.Ammunition))
                        Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " unquipped " + Program.Data.MyItems[_inventory[invid].ID].Name);
                    return true;
                }
            }
            return false;
        }

        public void PickItems(SpawnItems item)
        {
            //if (_inventory.Count >= 8 + ExtraInventorySpace)
            //    return;

            int nullat = FindNextEmptySpace();
            if (nullat < 8 + ExtraInventorySpace)
            {
                _inventory[nullat] = item;
                Program.MyMap.Drop[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(item);
                if (_playerParty > -1)
                    Program.Log.AddMessage((int)InGameLogMessageType.Event, Name + " picked a " + Program.Data.MyItems[item.ID].Name);
            }
        }

        public override void Update()
        {
            if (IsWalking)
            {
                WalkCount += Speed;
                if (WalkCount >= 16)
                {
                    DropGUI d = (DropGUI)Program.State[1].GameGUI[5];
                    WalkCount = 0;
                    IsWalking = false;

                    if (GeneralBehavior == (int)GeneralBehaviorType.FollowingPath)
                    {
                        if (PathfindingPath.Count > 0)
                        {
                            PathfindingPath.RemoveAt(PathfindingPath.Count - 1);
                            WalkCooldown = 15;
                        }
                    }

                    switch (TargetDir)
                    {
                        case 0:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            X--;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            if (this == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0])
                            {
                                d.DropX = X + Program.MyMap.MinX;
                                d.DropY = Y + Program.MyMap.MinY;
                            }
                            break;
                        case 1:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            Y--;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            if (this == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0])
                            {
                                d.DropX = X + Program.MyMap.MinX;
                                d.DropY = Y + Program.MyMap.MinY;
                            }
                            break;
                        case 2:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            X++;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            if (this == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0])
                            {
                                d.DropX = X + Program.MyMap.MinX;
                                d.DropY = Y + Program.MyMap.MinY;
                            }
                            break;
                        case 3:
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Remove(Index);
                            Y++;
                            Program.MyMap.SpawnedLivingThing[Y + Program.MyMap.MinY][X + Program.MyMap.MinX].Add(Index);
                            if (this == Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0])
                            {
                                d.DropX = X + Program.MyMap.MinX;
                                d.DropY = Y + Program.MyMap.MinY;
                            }
                            break;
                    }
                    if (_playerParty > 0)
                        WalkCooldown = 30;
                }
                return;
            }

            else if (PathfindingPath.Count == 0 && GeneralBehavior == (int)GeneralBehaviorType.FollowingPath)
            {
                int tempx = X;
                int tempY = Y;
                switch (ActionDir)
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
                GeneralBehavior = (int)GeneralBehaviorType.Normal;
                switch (CurrentAction)
                {
                    case 0:
                        break;
                    case 1:
                        Dir = ActionDir;

                        for (int r = tempY + Program.MyMap.MinY; r < tempY + Program.MyMap.MinY + Program.Data.GetBuildableList()[CurrentActionIndex].SizeY; r++)
                        {
                            for (int c = tempx + Program.MyMap.MinX; c < tempx + Program.MyMap.MinX + Program.Data.GetBuildableList()[CurrentActionIndex].SizeX; c++)
                            {
                                if (Logic.BlockedAt(c, r))
                                {
                                    CurrentActionIndex = -1;
                                    CurrentAction = 0;
                                    ActionDir = -1;
                                    return;
                                }
                            }
                        }
                        if (Program.MyMap.NullList.Count > 0)
                        {
                            Program.MyMap.SpawnedSpawnable[Program.MyMap.NullList[0]] = new SpawnBuildable(CurrentActionIndex, TargetX, TargetY);
                            for (int r = TargetY + Program.MyMap.MinY; r < TargetY + Program.MyMap.MinY + Program.Data.GetBuildableList()[CurrentActionIndex].SizeY; r++)
                            {
                                for (int c = TargetX + Program.MyMap.MinX; c < TargetX + Program.MyMap.MinX + Program.Data.GetBuildableList()[CurrentActionIndex].SizeX; c++)
                                {
                                    Program.MyMap.SpawnedSpawnableLocation[r][c] = Program.MyMap.NullList[0];
                                    Program.MyMap.NullList.RemoveAt(0);
                                }
                            }
                        }
                        else
                        {
                            Program.MyMap.SpawnedSpawnable.Add(new SpawnBuildable(CurrentActionIndex, TargetX, TargetY));
                            for (int r = TargetY + Program.MyMap.MinY; r < TargetY + Program.MyMap.MinY + Program.Data.GetBuildableList()[CurrentActionIndex].SizeY; r++)
                            {
                                for (int c = TargetX + Program.MyMap.MinX; c < TargetX + Program.MyMap.MinX + Program.Data.GetBuildableList()[CurrentActionIndex].SizeX; c++)
                                {
                                    Program.MyMap.SpawnedSpawnableLocation[r][c] = Program.MyMap.SpawnedSpawnable.Count - 1;
                                }
                            }
                        }
                        CurrentActionIndex = -1;
                        CurrentAction = 0;
                        ActionDir = -1;
                        ConstructionGUI cg1 = (ConstructionGUI)Program.State[1].GameGUI[9];
                        cg1.LocX = tempx + Program.MyMap.MinX;
                        cg1.LocY = tempY + Program.MyMap.MinY;
                        cg1.Visibility = true;
                        break;
                    case 2:
                        Dir = ActionDir;
                        CurrentAction = 0;
                        ActionDir = -1;
                        ConstructionGUI cg2 = (ConstructionGUI)Program.State[1].GameGUI[9];
                        cg2.LocX = tempx + Program.MyMap.MinX;
                        cg2.LocY = tempY + Program.MyMap.MinY;
                        cg2.Visibility = true;
                        break;
                }
            }

            else if (_playerParty > 0)
            {
                if (WalkCooldown == 0)
                {
                    switch ((PartyBehaviorType)_partyBehavior)
                    {
                        case PartyBehaviorType.Roaming:
                            Walk(Logic.RandomNumber(0, 4));
                            break;
                        case PartyBehaviorType.FollowTheLeader:
                            if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X < X && X - Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X > 1)
                            {
                                Walk(0);
                            }
                            else if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X > X && Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].X - X > 1)
                            {
                                Walk(2);
                            }
                            else if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y < Y && Y - Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y > 1)
                            {
                                Walk(1);
                            }
                            else if (Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y > Y && Program.Data.MyPlayerData[Program.CurrentSaveData].MainParty.MyParty[0].Y - Y > 1)
                            {
                                Walk(3);
                            }
                            break;
                    }
                }
                else
                {
                    WalkCooldown--;
                }
                return;
            }

            else if (PlayerParty == 0)
            {
                if (WalkCooldown == 0)
                {
                    if (GeneralBehavior == (int)GeneralBehaviorType.FollowingPath && PathfindingPath.Count > 0)
                    {
                        Walk(PathfindingPath[PathfindingPath.Count - 1]);
                    }
                }
                else
                    WalkCooldown--;
                //else if (GeneralBehavior == (int)GeneralBehaviorType.Normal)
                //    Walk(Logic.RandomNumber(0, 3));
            }
        }

        public override void Action()
        {
            int tempx = X;
            int tempy = Y;
            switch (Dir)
            {
                case 0:
                    tempx--;
                    break;
                case 1:
                    tempy--;
                    break;
                case 2:
                    tempx++;
                    break;
                case 3:
                    tempy++;
                    break;
            }

            if (Program.MyMap.SpawnedSpawnableLocation[tempy + Program.MyMap.MinY][tempx + Program.MyMap.MinX] > -1)
            {
                Logic.AttackSpawnable(this, Program.MyMap.SpawnedSpawnable[Program.MyMap.SpawnedSpawnableLocation[tempy + Program.MyMap.MinY][tempx + Program.MyMap.MinX]]);
            }

            if (Program.MyMap.SpawnedLivingThing[tempy + Program.MyMap.MinY][tempx + Program.MyMap.MinX].Count > 0)
            {
                Logic.AttackLivingObject(this, Program.Data.MyLivingObject[Program.MyMap.SpawnedLivingThing[tempy + Program.MyMap.MinY][tempx + Program.MyMap.MinX][Program.MyMap.SpawnedLivingThing[tempy + Program.MyMap.MinY][tempx + Program.MyMap.MinX].Count - 1]]);
            }
        }

        public void SetViewToThisNPC(RenderWindow rw)
        {
            int tempoffsetX = 0;
            int tempoffsetY = 0;
            switch (Dir)
            {
                case 0:
                    tempoffsetX = -WalkCount;
                    break;
                case 1:
                    tempoffsetY = -WalkCount;
                    break;
                case 2:
                    tempoffsetX = WalkCount;
                    break;
                case 3:
                    tempoffsetY = WalkCount;
                    break;
            }
            rw.SetView(new View(new FloatRect((X + Program.MyMap.MinX) * 16 - 8 - rw.Size.X / 2 + tempoffsetX, (Y + Program.MyMap.MinY) * 16 - 8 - rw.Size.Y / 2 + tempoffsetY, rw.Size.X, rw.Size.Y)));
        }

        public void SpawnMoreMapDueToThisNPC()
        {
            int tempx = X;
            int tempy = Y;
            if (IsWalking)
            {
                switch (Dir)
                {
                    case 0:
                        tempx--;
                        break;
                    case 1:
                        tempy--;
                        break;
                    case 2:
                        tempx++;
                        break;
                    case 3:
                        tempy++;
                        break;
                }
            }

            if (tempx + Program.MyMap.MinX < 50)
            {
                Program.Generator.SpawnLeft(Program.MyMap);
            }

            if (Program.MyMap.Y[0].Tile.Count - (tempx + Program.MyMap.MinX) < 50)
            {
                Program.Generator.SpawnRight(Program.MyMap);
            }

            if (tempy + Program.MyMap.MinY < 50)
            {
                Program.Generator.SpawnTop(Program.MyMap);
            }

            if (Program.MyMap.Y.Count - (tempy + Program.MyMap.MinY) < 50)
            {
                Program.Generator.SpawnBottom(Program.MyMap);
            }
        }

        public List<SpawnItems> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public int ExtraInventorySpace
        {
            get { return _extraInventorySpace; }
            set { _extraInventorySpace = value; }
        }

        public List<SpawnItems> Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        public int PartyBehavior
        {
            get { return _partyBehavior; }
            set { _partyBehavior = value; }
        }

        public int PlayerParty
        {
            get { return _playerParty; }
            set { _playerParty = value; }
        }

        public bool Playable
        {
            get { return _playable; }
            set { _playable = value; }
        }

        public byte Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int CurrentMana
        {
            get { return _curMP; }
            set { _curMP = value; }
        }

        public int MaxMana
        {
            get { return _maxMP; }
            set { _maxMP = value; }
        }

        public int CurrentExperience
        {
            get { return _curEXP; }
            set { _curEXP = value; }
        }

        public int Job
        {
            get { return _job; }
            set { _job = value; }
        }

        public int CurrentAction
        {
            get;
            set;
        }

        public int CurrentActionIndex
        {
            get;
            set;
        }

        public int ActionDir
        {
            get;
            set;
        }
    }
}
