using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class PlayerData
    {
        public PlayerData()
        {
            MainParty = new PlayerParty();
        }

        public PlayerParty MainParty { get; set; }

    }
}
