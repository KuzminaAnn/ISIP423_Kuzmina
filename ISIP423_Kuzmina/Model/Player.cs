using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP423_Kuzmina.Model
{
    internal class Player
    {
            public int MaxHP { get; private set; }
            public int CurrentHP { get; private set; }
            public Weapon CurrentWeapon { get; private set; }
            public Armor CurrentArmor { get; private set; }
            public bool IsFrozen { get; set; }
            public bool IsDefending { get; private set; }

            private Random random;
            public Player()
            {
                MaxHP = 100;
                CurrentHP = MaxHP;
                CurrentWeapon = new Weapon("Кулаки", 5);
                CurrentArmor = new Armor("Одежда", 2);
                random = new Random();
                IsFrozen = false;
                IsDefending = false;
            }
            public void TakeDamage(int damage)
            {
                if (IsDefending)
                {
                    if (random.NextDouble() < 0.4)
                    {
                        Console.WriteLine("Вы увернулись от атаки!");
                        IsDefending = false;
                        return;
                    }
                    double blockPercent = 0.7 + (random.NextDouble() * 0.3);
                    int blockedDamage = (int)(damage * (1 - blockPercent));
                    damage = Math.Max(1, blockedDamage);
                    Console.WriteLine($"Вы заблокировали урон! Получено урона: {damage}");
                    IsDefending = false;
                }
                CurrentHP -= damage;
                if (CurrentHP < 0) CurrentHP = 0;
            }
            public int CalculateAttack()
            {
                return CurrentWeapon.Attack;
            }
            public int CalculateDefense()
            {
                return CurrentArmor.Defense;
            }
            public void Heal()
            {
                CurrentHP = MaxHP;
                Console.WriteLine("Ваше здоровье полностью восстановлено!");
            }
            public void SetWeapon(Weapon weapon)
            {
                CurrentWeapon = weapon;
            }
            public void SetArmor(Armor armor)
            {
                CurrentArmor = armor;
            }
            public void SetDefending(bool defending)
            {
                IsDefending = defending;
            }
            public bool IsAlive => CurrentHP > 0;
            public string GetStatus()
            {
                return $"Игрок - HP: {CurrentHP}/{MaxHP}, Оружие: {CurrentWeapon.Name} (Атака: {CurrentWeapon.Attack}), " +
                       $"Доспехи: {CurrentArmor.Name} (Защита: {CurrentArmor.Defense})";
            }
    }
}
