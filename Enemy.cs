using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRPG
{
    internal class Enemy : Character
    {
        public int Exp { get; set; } 

        public Enemy(string name, int hp, int defense, int exp)
            : base(name, hp, defense)
        {
            Exp = exp;
        }
    }
}
