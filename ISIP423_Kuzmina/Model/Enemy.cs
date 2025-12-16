using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace ISIP423_Kuzmina.Model
{
    internal abstract class Enemy
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
}
