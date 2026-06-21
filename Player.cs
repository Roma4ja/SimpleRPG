using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRPG
{
    internal class Player : Character
    {
        public Player(string name, int hp, int defense)
            : base(name, hp, defense)
        {
        }
        private int _xp;
        public int KillCount { get; set;  } = 0;
        public int TotalXp { get; set;  } = 0;
        public int AttackBonus { get; set; } = 0;
        public int DamageBonus { get; set; } = 0;

        public int XP
        {
            get
            {
                return _xp;

            }

            set
            {
                _xp = value;
                if (_xp >= level * 100)
                {
                    _xp = 0;
                    level = level + 1;
                    Console.WriteLine($"Уровень повышен! Теперь вы {level} уровня и ваши характеристики повышены! ");
                }
        }
        }

        private int _lvl = 1;
        public int level
        {
            get { return _lvl; }
            set
            {
                  if (value > _lvl)
                {
                    _lvl = value;
                    MaxHP += 10;
                    AttackBonus += 1; 
                    DamageBonus += 2;
                    Defense += 2;
                    HP = MaxHP;
                    Console.WriteLine($"=== УРОВЕНЬ ПОВЫШЕН! ===");
                    Console.WriteLine($"Уровень: {_lvl}");
                    Console.WriteLine($"Уровень: {_lvl}");
                    Console.WriteLine($"HP: {MaxHP}");
                    Console.WriteLine($"Защита: {Defense}");
                    Console.WriteLine($"Бонус к попаданию: +{AttackBonus}");
                    Console.WriteLine($"Бонус к урону: +{DamageBonus}");
                }
                else
                {
                    _lvl = value;
                }
            }
        }



    }
}
