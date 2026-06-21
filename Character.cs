using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace SimpleRPG
{
    internal class Character : ICombatant
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }

        public int Defense { get; set; }

        private int _hp;
        public int HP
        {
            get  { return _hp; }
            set
            {
                if (value < 0) _hp = 0;
                else if (value > MaxHP) _hp = MaxHP;
                else _hp = value;
            }




        }

        public bool IsAlive => HP > 0;
        public Character(string name, int hp, int defense)
        {
            Name = name;
            MaxHP = hp;
            HP = hp;
            
            Defense = defense;




        }
        public void TakeDamage(int Damage)
        {
            HP = HP - Damage;
        }
    }
}

