using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_Kuzmina.Model
{
    static public class RandomChoice
    {
        private static Random Rand = new Random();

        public static int Randoms(int min, int max)
        {
            return Rand.Next(min, max);
        }

        private static bool Choice(double Chains)
        {
            return Rand.NextDouble() <= Chains;
        }

        public static bool MainChoice()
        {
            return Choice(0.5);
        }

        public static bool DrinrChoice()
        {
            return Choice(0.3);
        }

        public static bool ArmChoice()
        {
            return Choice(0.66);
        }
        public static bool SitChoice()
        {
            return Choice(0.4);
        }

        public static bool KritChoice()
        {
            return Choice(0.15);
        }

        public static bool FreezChoice()
        {
            return Choice(0.4);
        }
        public static bool FreezChoiceM()
        {
            return Choice(0.25);
        }

        public static bool FreezChoiceA()
        {
            return Choice(0.35);
        }
    }
}
