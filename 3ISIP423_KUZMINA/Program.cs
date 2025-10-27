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
        public static Random random = new Random();
        static void Main(string[] args)
        {
            
            int money = 1000;

            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В ИГРУ!");
            Console.WriteLine("Мой автосервис(почини авто(мы не определились с названием))");
            Console.WriteLine($"В начале игры у вас {money} монет");

            Console.WriteLine("Нажмите (1) для начала игры");
            Console.WriteLine("Нажмите (2) для просмотря склада");

            string a = Console.ReadLine();

            switch (a)
            {
                case "1":
                    List<Customers> cust = Core.Context.Customers.ToList();
                    Customers randomCust = cust[random.Next(0, cust.Count - 1)];
                    //List<Problems> pro = Core.Context.Problems.ToList();
                    Console.WriteLine("Игра начинается!");
                    Console.WriteLine("К вам приехал клиент!");
                    Console.WriteLine($"Имя: {randomCust.Name} на {randomCust.Car_brand}");
                    Console.WriteLine($"Проблема: {randomCust.Problems.Name}");
                    Console.WriteLine($"Деталь: {randomCust.Problems.Details.Name}");
                    Console.WriteLine($"Цена: {randomCust.Problems.Price} монет");
                    Console.WriteLine("Принять клиента? д/н");
                    break;
                case "2":
                    List<Box> box = Core.Context.Box.ToList();
                    //box[random.Next(0, box.Count - 1)].Details;
                    foreach (var boxx in box)
                    {
                        Console.WriteLine($"{boxx.Details.Name} - {boxx.Count}"); 
                    }
                    break;
            }


        }
    }
}
