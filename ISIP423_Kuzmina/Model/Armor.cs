using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_Kuzmina.Model
{
    internal class Armor : Item
    {
            public int Defense { get; private set; }

            public Armor(string name, int defense) : base(name)
            {
                Defense = defense;
            }
            public override string ToString()
            {
                return $"{Name} (Защита: {Defense})";
            }
    }
}
