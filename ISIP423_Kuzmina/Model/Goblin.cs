using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace ISIP423_Kuzmina.Model
{
    internal class Goblin : Enemy
    {
        private double critChance = 0.2;
        public Goblin() : base("Гоблин", 30, 8, 3) { }
        public override int CalculateDamage(Player player)
        {
            int damage = Attack;
            if (RandomChoice.KritChoice())
            {
                damage = (int)(damage * 1.5);
                Console.WriteLine("Критический урон!");
            }
            return damage;
        }
        public override void ApplySpecialEffect(Player player) { }
    }
}
