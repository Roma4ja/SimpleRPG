using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRPG
{
    internal class Player 
    {
        public string Name;
        public int HP;
        public int MaxHP;
        
        public int Defense;


        public Player(string name, int hp,  int defence)
        {
            Name = name;
            HP = hp;
            MaxHP = hp;
            
            Defense = defence;
        }

        public bool IsAlive
        {
            get { return HP > 0; }
        }

        public void TakeDamage(int Damage)
        {
            HP = HP - Damage;
            if (HP <= 0)
            {
                HP = 0;
            }

        }
}
}
