using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRPG
{
    internal interface ICombatant
    {
        string Name { get; set; }
        int MaxHP { get; set; }
        int HP { get; set; }
        
        int Defense { get; set; }
        bool IsAlive { get; }
        void TakeDamage(int damage);
    }
}
