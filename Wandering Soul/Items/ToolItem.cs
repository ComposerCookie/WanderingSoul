using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class ToolItem : WeaponItem
    {
        public ToolItem(string name, int type, int sprite, int dropsprite, bool stackable, Dictionary<int, int> required, int subtype, List<int> cla, Attack atk, int atkspd, int weapontype)
        {
            Name = name;
            ToolType = type;
            Sprite = sprite;
            DropSprite = dropsprite;
            Stackable = stackable;
            ItemRequired = required;
            Classification = cla;
            Attack = atk;
            AttackSpeed = atkspd;
            WeaponType = weapontype;
        }

        public int ToolType { get; set; }
    }
}
