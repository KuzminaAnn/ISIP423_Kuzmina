using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ISIP423_KUZMINA
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int br = 1;

                Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В ИГРУ!");
                Console.WriteLine("Мой автосервис(почини авто(мы не определились с названием))");
                Console.WriteLine($"В начале игры у вас {money} монет");
                
            
            while (br == 1)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Нажмите (1) для обслуживания клиента");
                Console.WriteLine("Нажмите (2) для просмотря склада");
                Console.WriteLine("Нажмите (3) чтобы посетить магазин");
                Console.WriteLine("Нажмите (4) для завершения игры");
                Console.WriteLine($"Баланс: {money}");

                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                       
                        break;

                    case "2":
                        
                        break;

                    case "3":
                        
                        break;

                    case "4":
                        Console.WriteLine("Хорошая работа! Спасибо за игру!");
                        br = br - 1;
                        break;
                }
                if (br == 1)
                {
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                } 
            }
        }
    }
}
