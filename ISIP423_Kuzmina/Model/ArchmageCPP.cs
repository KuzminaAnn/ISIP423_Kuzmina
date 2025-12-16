using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace ISIP423_Kuzmina.Model
{
    internal class ArchmageCPP : Mage
    {
        public ArchmageCPP() : base()
        {
            Name = "Архимаг C++ (Босс Маг)";
            MaxHP = (int)(MaxHP * 1.8);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.6);
            Defense = (int)(Defense * 1.1);
        }
        public override void ApplySpecialEffect(Player player)
        {
            if (random.NextDouble() < 0.35)
            {
                player.IsFrozen = true;
                Console.WriteLine("Архимаг C++ заморозил вас! Вы пропустите следующий ход.");
            }
        }
    }
}
