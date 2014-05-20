using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class PlayerData
    {
        PlayerParty _mainParty;

        public PlayerData()
        {
            _mainParty = new PlayerParty();
        }

        public PlayerParty MainParty
        {
            get { return _mainParty; }
        }
    }
}
