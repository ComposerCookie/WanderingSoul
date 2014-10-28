using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class ResourceItem : Items
    {
        public ResourceItem(string name, int sprite, int type, int dropsprite, bool stackable)
        {
            Name = name;
            Sprite = sprite;
            Type = type;
            DropSprite = dropsprite;
            Stackable = stackable;
            ItemRequired = new Dictionary<int, int>();
            Classification = new List<int>();
        }

        public string Name { get; set; }
        public int Sprite { get; set; }
        public int Type { get; set; }
        public int DropSprite { get; set; }
        public int SubType { get; set; }

        public bool Stackable { get; set; }
        public Dictionary<int, int> ItemRequired { get; set; }
        public List<int> Classification { get; set; }
    }
}
