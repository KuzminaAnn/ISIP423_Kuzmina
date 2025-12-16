using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG.Enemy;

namespace ISIP423_Kuzmina.Model
{
    internal class Mage : Enemy
    {
        private double freezeChance = 0.25;
        public Mage() : base("Маг", 20, 12, 1) { }
        public override int CalculateDamage(Player player)
        {
            return Attack;
        }
        public override void ApplySpecialEffect(Player player)
        {
            if (RandomChoice.FreezChoiceM())
            {
                player.IsFrozen = true;
                Console.WriteLine("Маг заморозил вас! Вы пропустите следующий ход.");
            }
        }
    }
}
