using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public class Knowledge
    {
        public string Name { get; set; }
        public List<int> RecipeUnlock { get; set; }
        public List<int> BlueprintUnlock { get; set; }
        public int Cost { get; set; }
        public int Sprite { get; set; }

        public Knowledge(string name, List<int> recipe, List<int> blueprint, int cost, int sprite)
        {
            Name = name;
            RecipeUnlock = recipe;
            BlueprintUnlock = blueprint;
            Cost = cost;
            Sprite = sprite;
        }
    }
}
