using System;
using System.Collections.Generic;
using System.Numerics;

namespace TextRPG
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        protected Item(string name)
        {
            Name = name;
        }
    }

    public class Weapon : Item
    {
        public int Attack { get; private set; }
        public Weapon(string name, int attack) : base(name)
        {
            Attack = attack;
        }
        public override string ToString()
        {
            return $"{Name} (Атака: {Attack})";
        }
    }

    public class Armor : Item
    {
        public int Defense { get; private set; }

        public Armor(string name, int defense) : base(name)
        {
            Defense = defense;
        }
        public override string ToString()
        {
            return $"{Name} (Защита: {Defense})";
        }
    }
    public class HealthPotion : Item
    {
        public HealthPotion() : base("Лечебное зелье") { }
        public override string ToString()
        {
            return $"{Name} (Восстанавливает всё здоровье)";
        }
    }

    public abstract class Enemy
    {
        public string Name { get; protected set; }
        public int MaxHP { get; protected set; }
        public int CurrentHP { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public bool IsFrozen { get; set; }

        protected Random random;

        protected Enemy(string name, int hp, int attack, int defense)
        {
            Name = name;
            MaxHP = hp;
            CurrentHP = hp;
            Attack = attack;
            Defense = defense;
            random = new Random();
            IsFrozen = false;
        }
        public virtual void TakeDamage(int damage)
        {
            CurrentHP -= damage;
            if (CurrentHP < 0) CurrentHP = 0;
        }
        public abstract int CalculateDamage(Player player);
        public abstract void ApplySpecialEffect(Player player);
        public bool IsAlive => CurrentHP > 0;
        public virtual string GetStatus()
        {
            return $"{Name} - HP: {CurrentHP}/{MaxHP}, Атака: {Attack}, Защита: {Defense}";
        }
    }
    public class Goblin : Enemy
    {
        private double critChance = 0.2;
        public Goblin() : base("Гоблин", 30, 8, 3) { }
        public override int CalculateDamage(Player player)
        {
            int damage = Attack;
            if (random.NextDouble() < critChance)
            {
                damage = (int)(damage * 1.5);
                Console.WriteLine("Критический урон!");
            }
            return damage;
        }
        public override void ApplySpecialEffect(Player player) { }
    }

    public class Skeleton : Enemy
    {
        public Skeleton() : base("Скелет", 25, 10, 2) { }

        public override int CalculateDamage(Player player)
        {
            return Attack; 
        }
        public override void ApplySpecialEffect(Player player) { }
    }

    public class Mage : Enemy
    {
        private double freezeChance = 0.25;
        public Mage() : base("Маг", 20, 12, 1) { }
        public override int CalculateDamage(Player player)
        {
            return Attack;
        }
        public override void ApplySpecialEffect(Player player)
        {
            if (random.NextDouble() < freezeChance)
            {
                player.IsFrozen = true;
                Console.WriteLine("Маг заморозил вас! Вы пропустите следующий ход.");
            }
        }
    }
    public class VVG : Goblin
    {
        public VVG() : base()
        {
            Name = "ВВГ (Босс Гоблин)";
            MaxHP = (int)(MaxHP * 2.0);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.5);
            Defense = (int)(Defense * 1.2);
        }
        public override int CalculateDamage(Player player)
        {
            int damage = Attack;
            if (random.NextDouble() < 0.3)
            {
                damage = (int)(damage * 1.5);
                Console.WriteLine("ВВГ наносит критический урон!");
            }
            return damage;
        }
    }

    public class Kovalsky : Skeleton
    {
        public Kovalsky() : base()
        {
            Name = "Ковальский (Босс Скелет)";
            MaxHP = (int)(MaxHP * 2.5);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.3);
            Defense = (int)(Defense * 1.4);
        }
        public override int CalculateDamage(Player player)
        {
            return Attack;
        }
    }

    public class ArchmageCPP : Mage
    {
        public ArchmageCPP() : base()
        {
            Name = "Архимаг C++ (Босс Маг)";
            MaxHP = (int)(MaxHP * 1.8);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.6);
            Defense = (int)(Defense * 1.1);
        }
        public override void ApplySpecialEffect(Player player)
        {
            if (random.NextDouble() < 0.35)
            {
                player.IsFrozen = true;
                Console.WriteLine("Архимаг C++ заморозил вас! Вы пропустите следующий ход.");
            }
        }
    }

    public class PestovC : Skeleton
    {
        private double freezeChance = 0.4;
        public PestovC() : base()
        {
            Name = "Пестов С-- (Босс Скелет)";
            MaxHP = (int)(MaxHP * 1.3);
            CurrentHP = MaxHP;
            Attack = (int)(Attack * 1.8);
            Defense = (int)(Defense * 0.6);
        }
        public override int CalculateDamage(Player player)
        {
            return Attack;
        }
        public override void ApplySpecialEffect(Player player)
        {
            if (random.NextDouble() < freezeChance)
            {
                player.IsFrozen = true;
                Console.WriteLine("Пестов С-- заморозил вас! Вы пропустите следующий ход.");
            }
        }
    }
    public class Player
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
