using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _3ISIP423_KUZMINA
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int br = 1;
            Basket kupt = new Basket();

            Console.WriteLine("Добро пожаловать в онлайн маркетплейс WONGG!");

                
            
            while (br == 1)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Нажмите (1) для того чтобы войти/зарегистрироваться");
                Console.WriteLine("Нажмите (2) для просмотра товаров");
                Console.WriteLine("Нажмите (3) чтобы просмотра корзины");
                Console.WriteLine("Нажмите (4) для выхода из магазина");


                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                       
                        break;

                    case "2":
                        List<Product> product = Core.Context.Product.ToList();
                        List<Basket> basket = Core.Context.Basket.ToList();
                        foreach (var producttt in product)
                        {
                            Console.WriteLine($"{producttt.ID_product}. {producttt.Name} - {producttt.Price} рублей");
                        }
                        Console.WriteLine("Добавить товар в корзину? д/н");

                        string ans = Console.ReadLine();
                        if (ans.ToLower() == "д")
                        {
                            Console.WriteLine("Напишите номер товара");
                            int t = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Сколько товара вы хотите преобрести?");
                            int k = Convert.ToInt32(Console.ReadLine());

                            kupt.Count += k;
                            Core.Context.Basket.Add(kupt);
                            Core.Context.SaveChanges();
                        }
                        else if (ans.ToLower() == "н")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор");
                        }

                            break;

                    case "3":
                        List<Basket> bbasket = Core.Context.Basket.ToList();
                        foreach (var bbaskettt in bbasket)
                        {
                            Console.WriteLine($"{bbaskettt.Product.ID_product}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Заходите ещё! Нагиев ждёт вас!!");
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
