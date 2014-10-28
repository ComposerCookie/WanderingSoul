using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public interface Projectile
    {
        string Name { get; set; }
        int Range { get; set; }
        int Animation { get; set; }

    }
}
