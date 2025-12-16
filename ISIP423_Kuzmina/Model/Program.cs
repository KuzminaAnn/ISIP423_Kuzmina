using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_Kuzmina.Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            Console.WriteLine("\nСпасибо за игру!");
            Console.ReadKey();
        }
    }
}
