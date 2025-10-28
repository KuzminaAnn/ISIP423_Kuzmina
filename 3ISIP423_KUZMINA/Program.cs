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
        public static int v = 0;
        public static bool b = false;
        static void Main(string[] args)
        {
            
            
                int money = 1000;
                int br = 1;
                Box kupt = new Box();
                int k = 0;


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
                        List<Customers> cust = Core.Context.Customers.ToList();
                        List<Box> boxs = Core.Context.Box.ToList();
                        ranCu = cust[random.Next(0, cust.Count - 1)];
                        Console.WriteLine("К вам приехал клиент!");
                        Console.WriteLine($"Имя: {ranCu.Name} на {ranCu.Car_brand}");
                        Console.WriteLine($"Проблема: {ranCu.Problems.Name}");
                        Console.WriteLine($"Деталь: {ranCu.Problems.Details.Name}");
                        Console.WriteLine($"Цена: {ranCu.Problems.Price} монет");
                        Console.WriteLine("Принять клиента? д/н");

                        string d = Console.ReadLine();
                        if (d.ToLower() == "д")
                        {
                            Box editCount = Core.Context.Box.First(b => b.Details.Name == ranCu.Problems.Details.Name); 
                            if (editCount.Count > 0)
                            {
                                Console.WriteLine("Деталь заменена!");
                                editCount.Count = editCount.Count - 1;
                                Core.Context.SaveChanges();
                                money = money + ranCu.Problems.Price;
                                Console.WriteLine($"Итог: {money} монет, {ranCu.Problems.Details.Name} - {editCount.Count}");
                            }
                            else
                            {
                                Console.WriteLine("Детали нет на складе!");
                                money = money - ranCu.Problems.Price;
                                Console.WriteLine($"Штраф: {ranCu.Problems.Price} монет");
                            }


                        }
                        else if (d.ToLower() == "н")  
                        {
                            Console.WriteLine("Клиент огорчен!");
                            money = money - ranCu.Problems.Price;
                            Console.WriteLine($"Штраф: {ranCu.Problems.Price} монет");
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор");
                            Console.WriteLine("Клиент в недоразумении...");
                            money = money - ranCu.Problems.Price;
                            Console.WriteLine($"Штраф: {ranCu.Problems.Price} монет");
                        }
                        if (b && v == 1)
                        {
                            kupt.Count += k;
                            Core.Context.SaveChanges();
                            b = false;
                            v = 0;
                            Console.WriteLine("Деталь добавлена на склад!");
                        }
                        else if (b)
                        {
                            v++;
                        }
                        break;
                    case "2":
                        List<Box> box = Core.Context.Box.ToList();
                        foreach (var boxx in box)
                        {
                            Console.WriteLine($"{boxx.Details.Name} - {boxx.Count}");
                        }
                        break;
                    case "3":
                        List<Details> det = Core.Context.Details.ToList();
                        foreach (var dett in det)
                        {
                            Console.WriteLine($"{dett.ID_details}. {dett.Name} - {dett.Price} монет");
                        }
                        Console.WriteLine("Напишите номер товара");
                        int t = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Сколько деталей вы хотите преобрести?");
                        k = Convert.ToInt32(Console.ReadLine());

                        kupt = Core.Context.Box.First(b => b.ID_details == t);
                        if ((kupt.Details.Price * k) < money)
                        {
                            money = money - (kupt.Details.Price * k);
                            Console.WriteLine($"Покупка совершена! Ваш баланс {money} монет");
                            Console.WriteLine("Деталь придет на склад через 2 клиента");
                            v = 0;
                            b = true;
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно средств");
                        }
                        if (b && v == 2)
                        {
                            kupt.Count += k;
                            Core.Context.SaveChanges();
                            Console.WriteLine("Деталь добавлена на склад!");
                        }
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
