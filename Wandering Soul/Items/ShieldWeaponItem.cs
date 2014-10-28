using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class ShieldWeaponItem : WeaponItem
    {
        public ShieldWeaponItem(string name, int sprite, int type, int dropsprite, bool stackable, Attack atk, int atkspd, int weapontype)
        {
            Name = name;
            Sprite = sprite;
            Type = type;
            DropSprite = dropsprite;
            Stackable = stackable;
            ItemRequired = new Dictionary<int, int>();
            Classification = new List<int>();
            Attack = atk;
            AttackSpeed = atkspd;
            WeaponType = weapontype;
        }
    }
}
