using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class StatsData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StatsData(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
