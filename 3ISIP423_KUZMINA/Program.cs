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
        public static Customers ranCu;
        static void Main(string[] args)
        {
            
            
                int money = 1000;

 
                Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В ИГРУ!");
                Console.WriteLine("Мой автосервис(почини авто(мы не определились с названием))");
                Console.WriteLine($"В начале игры у вас {money} монет");
                
            
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Нажмите (1) для начала игры");
                Console.WriteLine("Нажмите (2) для просмотря склада");

                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        List<Customers> cust = Core.Context.Customers.ToList();
                        List<Box> boxs = Core.Context.Box.ToList();
                        ranCu = cust[random.Next(0, cust.Count - 1)];
                        //List<Problems> pro = Core.Context.Problems.ToList();
                        Console.WriteLine("Игра начинается!");
                        Console.WriteLine("К вам приехал клиент!");
                        Console.WriteLine($"Имя: {ranCu.Name} на {ranCu.Car_brand}");
                        Console.WriteLine($"Проблема: {ranCu.Problems.Name}");
                        Console.WriteLine($"Деталь: {ranCu.Problems.Details.Name}");
                        Console.WriteLine($"Цена: {ranCu.Problems.Price} монет");
                        Console.WriteLine("Принять клиента? д/н");

                        if (Console.ReadLine().ToLower() == "д")
                        {
                            Box editCount = Core.Context.Box.First(b => b.Details.Name == ranCu.Problems.Details.Name); // находим пользователя для изменений
                            if (editCount.Count > 0)
                            {
                                Console.WriteLine("Деталь заменена!");
                                editCount.Count = editCount.Count - 1;
                                Core.Context.SaveChanges();
                                Console.WriteLine($"Итог: {money + ranCu.Problems.Price} монет, {ranCu.Problems.Details.Name} - {editCount.Count}");
                            }
                            else
                            {
                                Console.WriteLine("Детали нет на складе!");
                                Console.WriteLine($"Штраф: {money - ranCu.Problems.Price} монет");
                            }


                        }
                        //else
                        //    Console.WriteLine("Вы отказали клиенту в ремонте.Ваш штраф составил { blu - bla}.");

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
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
        }
    }
}
