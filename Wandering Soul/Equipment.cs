using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Equipment
    {
        public NPC Holder { get; set; }
        public SpawnItems Ammunition { get; set; }
        public SpawnItems Armor { get; set; }
        public SpawnItems Helmet { get; set; }
        public SpawnItems Boot { get; set; }
        public SpawnItems Cape { get; set; }
        public SpawnItems Bracelet1 { get; set; }
        public SpawnItems Bracelet2 { get; set; }
        public SpawnItems Ring1 { get; set; }
        public SpawnItems Ring2 { get; set; }
        public SpawnItems Storage { get; set; }
        public SpawnItems Weapon1 { get; set; }
        public SpawnItems Weapon2 { get; set; }
        public SpawnItems Necklace { get; set; }

        public Equipment(NPC p)
        {
            Holder = p;
            Ammunition = null;
            Armor = null;
            Helmet = null;
            Boot = null;
            Cape = null;
            Bracelet1 = null;
            Bracelet2 = null;
            Ring1 = null;
            Ring2 = null;
            Storage = null;
            Weapon1 = null;
            Weapon2 = null;
            Necklace = null;
        }

        public void DropItem(ItemType type, int secondary, int x, int y, Map m)
        {
            SpawnItems s = UnequipItem(type, secondary);
            if (s != null)
                m.Drop[y + m.MinY][x + m.MinX].Add(s);
        }

        public SpawnItems UnequipItem(ItemType type, int secondary)
        {
            SpawnItems s = null;
            switch (type)
            {
                case ItemType.Ammunition:
                    s = Ammunition;
                    Ammunition = null;
                    break;
                case ItemType.Armor:
                    s = Armor;
                    Armor = null;
                    break;
                case ItemType.Helmet:
                    s = Helmet;
                    Helmet = null;
                    break;
                case ItemType.Boot:
                    s = Boot;
                    Boot = null;
                    break;
                case ItemType.Cape:
                    s = Cape;
                    Cape = null;
                    break;
                case ItemType.Bracelet:
                    if (secondary == 0)
                    {
                        s = Bracelet1;
                        Bracelet1 = null;
                    }
                    else
                    {
                        s = Bracelet2;
                        Bracelet2 = null;
                    }
                    break;
                case ItemType.Ring:
                    if (secondary == 0)
                    {
                        s = Ring1;
                        Ring1 = null;
                    }
                    else
                    {
                        s = Ring2;
                        Ring2 = null;
                    }
                    break;
                case ItemType.Storage:
                    s = Storage;
                    Storage = null;
                    break;
                case ItemType.Weapon:
                    if (secondary == 0)
                    {
                        s = Weapon1;
                        Weapon1 = null;
                    }
                    else
                    {
                        s = Bracelet2;
                        Bracelet2 = null;
                    }
                    break;
                case ItemType.Necklace:
                    s = Necklace;
                    Necklace = null;
                    break;
            }
            return s;
        }

        public void EquipItem(SpawnItems s, ItemType type, int secondary)
        {

            switch (type)
            {
                case ItemType.Ammunition:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Ammunition)
                        Ammunition = s;
                    break;
                case ItemType.Armor:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Armor)
                        Armor = s;
                    break;
                case ItemType.Helmet:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Helmet)
                        Helmet = s;
                    break;
                case ItemType.Boot:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Boot)
                        Boot = s;
                    break;
                case ItemType.Cape:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Cape)
                        Cape = s;
                    break;
                case ItemType.Bracelet:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Bracelet)
                    {
                        if (secondary == 0)
                            Bracelet1 = s;
                        else
                            Bracelet2 = s;
                    }
                    break;
                case ItemType.Ring:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Ring)
                    {
                        if (secondary == 0)
                            Ring1 = s;
                        else
                            Ring2 = s;
                    }
                    break;
                case ItemType.Storage:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Storage)
                        Storage = s;
                    break;
                case ItemType.Weapon:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Weapon)
                    {
                        if (secondary == 0)
                            Weapon1 = s;
                        else
                            Weapon2 = s;
                    }
                    break;
                case ItemType.Necklace:
                    if ((ItemType)Program.Data.MyItems[s.ID].Type == ItemType.Necklace)
                        Necklace = s;
                    break;
            }
        }
    }
}
