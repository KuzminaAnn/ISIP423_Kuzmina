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

                    break;
                case "2":
                    List<Box> box = Core.Context.Box.ToList();
                    foreach (var boxx in box)
                    {
                        Console.WriteLine(boxx.Details.Name);
                        Console.WriteLine(boxx.Count);
                    }
                    break;
            }


        }
    }
}
