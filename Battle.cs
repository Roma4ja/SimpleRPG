using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRPG
{
    internal class Battle
    {
        public  bool Fight(Player player, Enemy enemy)
        {
            
            Console.WriteLine("========= Бой =========");
            
            Console.WriteLine($"{player.Name} VS {enemy.Name}");

            int initiative_Player = new Random().Next(1, 20);
            int initiative_Enemy = new Random().Next(1, 20);
            Console.WriteLine($"Бросок инициативы! \n Вам выпало: {initiative_Player} \n Противнику выпало: {initiative_Enemy}");

            if (initiative_Player >= initiative_Enemy)
            {
                Console.WriteLine($"Вы ходите первым! У вас: {player.HP}/{player.MaxHP} HP");
            }
            else
            {
                Console.WriteLine("Противник ходит первым!");
                int Hit_Enemy = new Random().Next(1, 20);
                if (Hit_Enemy >= player.Defense)
                {
                    Console.WriteLine($"Противник попадает своей атакой! {Hit_Enemy}/{player.Defense}");
                    int Enemy_choice = 1;
                    if (Enemy_choice == 1)
                    {
                        int Attack_damage = new Random().Next(1, 10);
                        player.TakeDamage(Attack_damage);
                        Console.WriteLine($"{enemy.Name} атакует! \n {enemy.Name} наносит {Attack_damage} урона! \n У вас {player.HP}/{player.MaxHP} HP!");
                        if (!player.IsAlive)
                        {
                            Console.WriteLine("Вы погибли...");
                            return false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Противник промахивается своей атакой! {Hit_Enemy}/{player.Defense}");
                }
            }

            // === ОСНОВНОЙ ЦИКЛ БОЯ ===
            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine("Что вы будете делать?");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Лечиться");
                Console.WriteLine("3. Сбежать");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int Hit_Player = new Random().Next(1, 20);
                        Console.WriteLine($"Вы наносите удар! {Hit_Player}/20 ");
                        if (Hit_Player >= enemy.Defense)
                        {
                            int Attack_damage = new Random().Next(1, 10);
                            enemy.TakeDamage(Attack_damage);
                            Console.WriteLine($"Вы попадаете! Вы нанесли {Attack_damage} урона! У {enemy.Name} {enemy.HP}/{enemy.MaxHP} HP");
                            
                        }
                        else
                        {
                            Console.WriteLine($"Вы промахнулись! ");
                        }
                        break;
                    case 2:
                        int healing = new Random().Next(1, 10);
                        player.HP = player.HP + healing;
                        if (player.HP > player.MaxHP)
                        {
                            player.HP = player.MaxHP;
                            
                            
                        }
                        Console.WriteLine($"Вы вылечились на {healing} HP \n У вас {player.HP}/{player.MaxHP} HP!");
                        break;

                    case 3:
                        Console.WriteLine("Вы сбежали!");

                        return false;
                    default:
                        Console.WriteLine("Нет такого выбора!");
                        break;
                }

                // Если враг жив — он атакует
                if (enemy.IsAlive)
                {
                    int Hit_Enemy = new Random().Next(1, 20);
                    if (Hit_Enemy >= player.Defense)
                    {
                        int Attack_damage = new Random().Next(1, 10);
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
