using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class JobsData
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> BaseStats { get; set; }
        public List<int> PromoteTo { get; set; }

        public List<int> ExperienceRequired { get; set; }
        public List<KeyValuePair<int, int>> AttackUnlock { get; set; }

        public JobsData(string name, string description, List<int> basestats, List<int> promoteto, List<int> experience, List<KeyValuePair<int, int>> atkunlock)
        {
            Name = name;
            Description = description;
            BaseStats = basestats;
            PromoteTo = promoteto;
            ExperienceRequired = experience;
            AttackUnlock = atkunlock;
        }
    }
}
