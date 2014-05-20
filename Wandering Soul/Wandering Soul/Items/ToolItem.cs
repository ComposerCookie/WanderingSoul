using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class ToolItem : WeaponItem
    {
        public ToolItem(string name, int type, int sprite, int dropsprite)
        {
            Name = name;
            ToolType = type;
            Sprite = sprite;
            DropSprite = dropsprite;
        }

        public int ToolType { get; set; }
    }
}
