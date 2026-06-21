namespace SimpleRPG
{
    internal class Battle
    {
        private Random rand = new Random(); 

        public bool Fight(ICombatant player, ICombatant enemy)
        {
            Console.WriteLine("========= Бой =========");
            Console.WriteLine($"{player.Name} VS {enemy.Name}");
            
            int initiative_Player = rand.Next(1, 20);
            int initiative_Enemy = rand.Next(1, 20);
            Console.WriteLine($"Бросок инициативы! \n Вам выпало: {initiative_Player} \n Противнику выпало: {initiative_Enemy}");

            if (initiative_Player >= initiative_Enemy)
            {
                Console.WriteLine($"Вы ходите первым! У вас: {player.HP}/{player.MaxHP} HP");
            }
            else
            {
                Console.WriteLine("Противник ходит первым!");
                int Hit_Enemy = rand.Next(1, 20);
                if (Hit_Enemy >= player.Defense)
                {
                    int Attack_damage = rand.Next(1, 10);
                    player.TakeDamage(Attack_damage);
                    Console.WriteLine($"{enemy.Name} атакует! \n {enemy.Name} наносит {Attack_damage} урона! \n У вас {player.HP}/{player.MaxHP} HP!");
                    if (!player.IsAlive)
                    {
                        Console.WriteLine("Вы погибли...");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Противник промахивается своей атакой! {Hit_Enemy}/{player.Defense}");
                }
            }

            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine("Что вы будете делать?");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Лечиться");
                Console.WriteLine("3. Сбежать");

                
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        int attackBonus = (player is Player p) ? p.AttackBonus : 0;
                        int damageBonus = (player is Player p2) ? p2.DamageBonus : 0;

                        int Hit_Player = rand.Next(1, 20) + attackBonus;
                        Console.WriteLine($"Вы наносите удар! {Hit_Player}/20");
                        if (Hit_Player >= enemy.Defense)
                        {
                            int Attack_damage = rand.Next(1, 10) + damageBonus;
                            enemy.TakeDamage(Attack_damage);
                            Console.WriteLine($"Вы попадаете! Вы нанесли {Attack_damage} урона!");
                        }
                        else
                        {
                            Console.WriteLine("Вы промахнулись!");
                        }
                        break;

                    case 2:
                        int healing = rand.Next(1, 10);
                        player.HP += healing; 
                        Console.WriteLine($"Вы вылечились на {healing} HP \n У вас {player.HP}/{player.MaxHP} HP!");
                        break;

                    case 3:
                        Console.WriteLine("Вы сбежали!");
                        return false;

                    default:
                        Console.WriteLine("Нет такого выбора!");
                        break;
                }

                if (enemy.IsAlive)
                {
                    int Hit_Enemy = rand.Next(1, 20);
                    if (Hit_Enemy >= player.Defense)
                    {
                        int Attack_damage = rand.Next(1, 10);
                        player.TakeDamage(Attack_damage);
                        Console.WriteLine($"{enemy.Name} атакует! Наносит {Attack_damage} урона! У вас {player.HP}/{player.MaxHP} HP!");
                        if (!player.IsAlive)
                        {
                            Console.WriteLine("Вы погибли...");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{enemy.Name} промахивается!");
                    }
                }
            }

            if (player.IsAlive && !enemy.IsAlive)
            {
                Console.WriteLine($"Победа! {enemy.Name} повержен!");
                return true;
            }

            return false;
        }
    }
}