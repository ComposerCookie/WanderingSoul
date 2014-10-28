using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Inventory
    {
        public NPC Holder { get; set; }
        public List<InventorySpace> Slot { get; set; }

        public Inventory(NPC p, int slot, int locked)
        {
            Holder = p;
            for (int s = 0; s < slot; s++)
            {
                Slot.Add(new InventorySpace(s >= locked)); 
            }
        }

        public int FindOpenSlot()
        {
            int slot = -1;
            foreach(InventorySpace i in Slot)
            {
                if (i.Locked)
                    continue;

                if (i.Item == null)
                {
                    slot = Slot.IndexOf(i);
                    break;
                }
            }
            return slot;
        }

        public bool PutItem(SpawnItems s)
        {
            if (FindOpenSlot() <= -1)
                return false;
            Slot[FindOpenSlot()].Item = s;
            return true;
        }

        public SpawnItems GetItem(int slot)
        {
            return Slot[slot].Item;
        }

        public void DropItem(int slot, int x, int y, Map m)
        {
            if (slot > 16)
                return;

            if (Slot[slot].Item == null)
                return;

            m.Drop[y + m.MinY][x + m.MinX].Add(Slot[slot].Item);
        }


    }
}
