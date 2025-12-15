using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_Kuzmina.Model
{
    internal class Weapon : Item
    {
            public int Attack { get; private set; }
            public Weapon(string name, int attack) : base(name)
            {
                Attack = attack;
            }
            public override string ToString()
            {
                return $"{Name} (Атака: {Attack})";
            }
    }
}
