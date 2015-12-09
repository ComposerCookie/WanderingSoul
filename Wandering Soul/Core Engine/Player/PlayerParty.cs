using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class PlayerParty : Party
    {
        List<NPC> _myParty;
        public PlayerParty()
        {
            _myParty = new List<NPC>();
        }

        public List<NPC> MyParty
        {
            get { return _myParty; }
            set { _myParty = value; }
        }

        public void SwapMember(int memID)
        {
            if (_myParty.Count < 2 || memID > _myParty.Count - 1)
                return;

            NPC tempNPC = _myParty[0];
            _myParty[0] = _myParty[memID];
            _myParty[0].PlayerParty = 0;
            _myParty[memID] = tempNPC;
            _myParty[memID].PlayerParty = memID;
        }

        public void AddMember(NPC npc)
        {
            if (_myParty.Count > 4)
                return;

            _myParty.Add(npc);
            npc.PlayerParty = _myParty.Count - 1;
        }

        public void RemoveMember(NPC npc)
        {
            npc.PlayerParty = -1;
            _myParty.Remove(npc);
        }

        public void RemoveMember(int at)
        {
            _myParty[at].PlayerParty = -1;
            _myParty.RemoveAt(at);
        }
    }
}
