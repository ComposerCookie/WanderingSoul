using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Blueprint : Items
    {
        public int BuildID { get; set; }
        public int UnlockType { get; set; }

        public string Name { get; set; }
        public int Sprite { get; set; }
        public int Type { get; set; }
        public int DropSprite { get; set; }
        public int SubType { get; set; }

        public bool Stackable { get; set; }
        public Dictionary<int, int> ItemRequired { get; set; }
        public List<int> Classification { get; set; }

        public Blueprint(string name, int sprite, int id, int locktype, int type, int dropsprite, bool stackable)
        {
            Name = name;
            Sprite = sprite;
            BuildID = id;
            UnlockType = locktype;
            Type = type;
            DropSprite = dropsprite;
            Stackable = stackable;
        }
    }
}
