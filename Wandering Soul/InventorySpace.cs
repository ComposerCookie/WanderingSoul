using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class InventorySpace
    {
        public SpawnItems Item { get; set; }
        public bool Locked { get; set; }

        public InventorySpace(bool locked)
        {
            Item = null;
            Locked = locked;
        }
    }
}
