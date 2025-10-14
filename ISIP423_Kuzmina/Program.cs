using System;
using System.Collections.Generic;

namespace TextRPG
{
    // Базовый класс для предметов
    public abstract class Item
    {
        public string Name { get; protected set; }
        protected Item(string name)
        {
            Name = name;
        }
    }

    // Оружие
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

    // Доспехи
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