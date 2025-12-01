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
            User kupt = null;

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
                        Console.WriteLine("Нажмите (1) для входа");
                        Console.WriteLine("Нажмите (2) для регистрации");

                        string v = Console.ReadLine();
                        switch (v)
                        {
                            case "1":
                                List<User> users = Core.Context.User.ToList();
                                Console.WriteLine("Введите логин:");
                                string aflogin = Console.ReadLine();
                                User afuser = users.First(U => U.Login.ToLower() == aflogin.ToLower());
                                Console.WriteLine("Введите пароль:");
                                string afpasword = Console.ReadLine();
                                if (afuser.Password == afpasword)
                                {
                                    kupt = afuser;
                                    Console.WriteLine("Вы вошли в свой аккаунт!");
                                }
                                else
                                {
                                    Console.WriteLine("Неверный пароль");

                                }
                                break;

                            case "2":
                                List<User> userss = Core.Context.User.ToList();
                                Console.WriteLine("введите логин:");
                                string newlogin = Console.ReadLine();
                                Console.WriteLine("Введите пароль:");
                                string newpasword = Console.ReadLine();
                                Console.WriteLine("Введите пароль повторно:");
                                string newpasword1 = Console.ReadLine();

                                if (newpasword == newpasword1)
                                {
                                    User user = new User
                                    {
                                        Login = newlogin,
                                        Password = newpasword
                                    };
                                    Core.Context.User.Add(user);
                                    Core.Context.SaveChanges();

                                    kupt = user;
                                    Console.WriteLine("Вы вошли в свой аккаунт!");
                                }
                                else
                                {
                                    Console.WriteLine("Пароль не совпадает");
                                }
                                break;
                        }
                        break;

                    case "2":
                        List<Product> product = Core.Context.Product.ToList();
                        //List<Basket> basket = Core.Context.Basket.ToList();
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

                            Basket newBask = new Basket();
                            newBask.Count = k;
                            newBask.ID_product = t;
                            newBask.ID_user = kupt.ID_user;
                            Core.Context.Basket.Add(newBask);
                            Core.Context.SaveChanges();
                            Console.WriteLine("Товар добавлен в карзину!");
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
                        bbasket = bbasket.Where(b => b.ID_user == kupt.ID_user).ToList();
                        foreach (var bbaskettt in bbasket)
                        {
                            Console.WriteLine($"{bbaskettt.ID_product}. {bbaskettt.Product.Name} - {bbaskettt.Count}шт");
                        }
                        Console.WriteLine("Хотите сделать заказ? д/н");

                        string answ = Console.ReadLine();
                        if (answ.ToLower() == "д")
                        {
                            Console.WriteLine("Нажмите (1) для заказа всех товаров");
                            Console.WriteLine("Нажмите (2) для заказа одного товара");
                            string w = Console.ReadLine();
                                switch (w)
                                {
                                    case "1":
                                    Console.WriteLine("Выберете ПВЗ:");
                                    List<Point> ppoint = Core.Context.Point.ToList();
                                    foreach (var ppointtt in ppoint)
                                    {
                                        Console.WriteLine($"{ppointtt.ID_point}. {ppointtt.Adress}");
                                    }
                                    break;
                                    case "2":

                                        break;
                                }
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
