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
        private double critChance = 0.2; // 20% шанс крита
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
            return Attack; // Игнорирует защиту
        }
        public override void ApplySpecialEffect(Player player) { }
    }

    public class Mage : Enemy
    {
        private double freezeChance = 0.25; // 25% шанс заморозки
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