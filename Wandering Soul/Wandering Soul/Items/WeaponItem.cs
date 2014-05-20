using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class WeaponItem : Items
    {
        public WeaponItem()
        {
            Type = (int)ItemType.Weapon;
        }
        public WeaponItem(string name, int sprite, int type, int dropsprite)
        {
            Name = name;
            Sprite = sprite;
            Type = type;
            DropSprite = dropsprite;
        }

        public string Name { get; set; }
        public int Sprite { get; set; }
        public int Type { get; set; }
        public int DropSprite { get; set; }
    }
}
