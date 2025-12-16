using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace ISIP423_Kuzmina.Model
{
    internal class Skeleton : Enemy
    {
        public Skeleton() : base("Скелет", 25, 10, 2) { }

        public override int CalculateDamage(Player player)
        {
            return Attack;
        }
        public override void ApplySpecialEffect(Player player) { }
    }
}
