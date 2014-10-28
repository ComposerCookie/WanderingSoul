using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class PlayerParty : Party
    {
        public List<NPC> MyParty { get; set; }
        public PlayerParty()
        {
            MyParty = new List<NPC>();
        }

        public void SwapMember(int memID)
        {
            if (MyParty.Count < 2 || memID > MyParty.Count - 1)
                return;

            NPC tempNPC = MyParty[0];
            MyParty[0] = MyParty[memID];
            MyParty[0].PlayerPartySlot = 0;
            MyParty[memID] = tempNPC;
            MyParty[memID].PlayerPartySlot = memID;
        }

        public void AddMember(NPC npc)
        {
            if (MyParty.Count > 4)
                return;

            MyParty.Add(npc);
            npc.PlayerPartySlot = MyParty.Count - 1;
        }

        public void RemoveMember(NPC npc)
        {
            npc.PlayerPartySlot = -1;
            MyParty.Remove(npc);
        }

        public void RemoveMember(int at)
        {
            MyParty[at].PlayerPartySlot = -1;
            MyParty.RemoveAt(at);
        }
    }
}
