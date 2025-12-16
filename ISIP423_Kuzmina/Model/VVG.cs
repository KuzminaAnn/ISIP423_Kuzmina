using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG.Enemy;

namespace ISIP423_Kuzmina.Model
{
    internal class VVG : Goblin
    {
        public VVG() : base()
        {
            Name = "ВВГ (Босс Гоблин)";
            MaxHP = (int)(MaxHP * 2.0);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.5);
            Defense = (int)(Defense * 1.2);
        }
        public override int CalculateDamage(Player player)
        {
            int damage = Attack;
            if (random.NextDouble() < 0.3)
            {
                damage = (int)(damage * 1.5);
                Console.WriteLine("ВВГ наносит критический урон!");
            }
            return damage;
        }
    }
}
