using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace ISIP423_Kuzmina.Model
{
    internal class Kovalsky : Skeleton
    {
        public Kovalsky() : base()
        {
            Name = "Ковальский (Босс Скелет)";
            MaxHP = (int)(MaxHP * 2.5);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.3);
            Defense = (int)(Defense * 1.4);
        }
        public override int CalculateDamage(Player player)
        {
            return Attack;
        }
    }
}
