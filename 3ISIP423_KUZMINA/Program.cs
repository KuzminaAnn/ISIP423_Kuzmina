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
                        foreach (var producttt in product)
                        {
                            Console.WriteLine($"{producttt.Name} - {producttt.Price} рублей");
                        }
                        break;

                    case "3":
                        
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
