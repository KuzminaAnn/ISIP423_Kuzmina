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