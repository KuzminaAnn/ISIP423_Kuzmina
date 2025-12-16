using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_Kuzmina.Model
{
    internal class Game
    {
        private Player player;
        private Random random;
        private int turnCount;

        private List<Func<Enemy>> normalEnemies;
        private List<Func<Enemy>> bosses;

        public Game()
        {
            player = new Player();
            random = new Random();
            turnCount = 0;

            normalEnemies = new List<Func<Enemy>>
            {
                () => new Goblin(),
                () => new Skeleton(),
                () => new Mage(),
                () => new Slime()
            };

            bosses = new List<Func<Enemy>>
            {
                () => new VVG(),
                () => new Kovalsky(),
                () => new ArchmageCPP(),
                () => new PestovC()
            };
        }
        public void Start()
        {
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine("Каждый ход вы можете встретить сундук или врага.");
            Console.WriteLine("Каждые 10 ходов вас ждёт встреча с боссом!\n");

            while (player.IsAlive)
            {
                turnCount++;
                Console.WriteLine($"\n Ход {turnCount}");
                Console.WriteLine(player.GetStatus());

                if (player.IsFrozen)
                {
                    Console.WriteLine("Вы заморожены и пропускаете ход!");
                    player.IsFrozen = false;
                    continue;
                }

                if (random.NextDouble() < 0.5)
                {
                    EncounterEnemy();
                }
                else
                {
                    OpenChest();
                }

                if (turnCount % 10 == 0)
                {
                    Console.WriteLine("\nВНИМАНИЕ: Появляется босс");
                    EncounterBoss();
                }

                if (!player.IsAlive)
                {
                    Console.WriteLine("\nИгра окончена! Вы погибли:(");
                    break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
        }
        private void EncounterEnemy()
        {
            Console.WriteLine("\nВы встретили врага!");
            Enemy enemy = normalEnemies[random.Next(normalEnemies.Count)]();
            Console.WriteLine($"Перед вами: {enemy.GetStatus()}");

            Battle(enemy);
        }

        private void EncounterBoss()
        {
            Enemy boss = bosses[random.Next(bosses.Count)]();
            Console.WriteLine($"Перед вами: {boss.GetStatus()}");

            Battle(boss);
        }

        private void Battle(Enemy enemy)
        {
            while (enemy.IsAlive && player.IsAlive)
            {
                Console.WriteLine("\nВаш ход:");
                Console.WriteLine("1 - Атаковать");
                Console.WriteLine("2 - Защищаться");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    int playerDamage = player.CalculateAttack();
                    if (enemy is Slime)
                    {
                        Console.WriteLine($"Вы наносите {playerDamage - 2} урона!");
                        enemy.TakeDamage(playerDamage);
                    }
                    else
                    {
                        enemy.TakeDamage(playerDamage);
                        Console.WriteLine($"Вы нанесли {playerDamage} урона!");
                    }
                    player.SetDefending(false);
                }
                else if (choice == "2")
                {
                    player.SetDefending(true);
                    Console.WriteLine("Вы приготовились к защите!");
                }
                else
                {
                    Console.WriteLine("Неверный выбор, пропускаете ход!");
                }

                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"Вы победили {enemy.Name}!");
                    break;
                }

                Console.WriteLine($"\nХод {enemy.Name}:");

                int enemyDamage = enemy.CalculateDamage(player);
                int actualDamage = enemyDamage;

                if (!(enemy is Skeleton) && !(enemy is Kovalsky) && !(enemy is PestovC))
                {
                    actualDamage = Math.Max(1, enemyDamage - player.CalculateDefense());
                }

                player.TakeDamage(actualDamage);
                enemy.ApplySpecialEffect(player);

                Console.WriteLine($"{enemy.Name} наносит {actualDamage} урона!");
                Console.WriteLine(player.GetStatus());
                Console.WriteLine(enemy.GetStatus());

                if (!player.IsAlive)
                {
                    break;
                }
            }
        }
        private void OpenChest()
        {
            Console.WriteLine("\nВы нашли сундук!");

            double itemType = random.NextDouble();

            if (itemType < 0.33)
            {
                HealthPotion potion = new HealthPotion();
                Console.WriteLine($"В сундуке: {potion}");
                Console.WriteLine("Выпить зелье? (y/n)");

                if (Console.ReadLine().ToLower() == "y")
                {
                    player.Heal();
                }
            }
            else if (itemType < 0.66)
            {
                string[] weaponNames = { "Меч", "Топор", "Посох", "Кинжал", "Булава" };
                string name = weaponNames[random.Next(weaponNames.Length)];
                int attack = random.Next(8, 20);

                Weapon newWeapon = new Weapon(name, attack);
                Console.WriteLine($"В сундуке: {newWeapon}");
                Console.WriteLine($"Ваше текущее оружие: {player.CurrentWeapon}");
                Console.WriteLine("Заменить оружие? (y/n)");

                if (Console.ReadLine().ToLower() == "y")
                {
                    player.SetWeapon(newWeapon);
                    Console.WriteLine("Оружие заменено!");
                }
            }
            else
            {
                string[] armorNames = { "Кожаная броня", "Кольчуга", "Латы", "Мантия", "Роба" };
                string name = armorNames[random.Next(armorNames.Length)];
                int defense = random.Next(5, 15);

                Armor newArmor = new Armor(name, defense);
                Console.WriteLine($"В сундуке: {newArmor}");
                Console.WriteLine($"Ваши текущие доспехи: {player.CurrentArmor}");
                Console.WriteLine("Заменить доспехи? (y/n)");

                if (Console.ReadLine().ToLower() == "y")
                {
                    player.SetArmor(newArmor);
                    Console.WriteLine("Доспехи заменены!");
                }
            }
        }
    }
}
