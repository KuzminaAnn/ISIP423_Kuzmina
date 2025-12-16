using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace ISIP423_Kuzmina.Model
{
    internal class PestovC : Skeleton
    {
        private double freezeChance = 0.4;
        public PestovC() : base()
        {
            Name = "Пестов С-- (Босс Скелет)";
            MaxHP = (int)(MaxHP * 1.3);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.8);
            Defense = (int)(Defense * 0.6);
        }
        public override int CalculateDamage(Player player)
        {
            return Attack;
        }
        public override void ApplySpecialEffect(Player player)
        {
            if (random.NextDouble() < freezeChance)
            {
                player.IsFrozen = true;
                Console.WriteLine("Пестов С-- заморозил вас! Вы пропустите следующий ход.");
            }
        }
    }
}
