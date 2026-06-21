using System.ComponentModel.Design;

namespace SimpleRPG
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("========== Добро пожаловать! ==========");
            Console.Write("Введите свое имя: ");
            string name = Console.ReadLine();

            Player player = new Player(name, 20, 10);
            Battle battle = new Battle();

            Console.WriteLine($"Ваши характеристики: \n Имя: {name} \n HP: {player.HP}/{player.MaxHP} \n Защита: {player.Defense}");


            List<Enemy> enemies_lvl1 = new List<Enemy>()
                {
                    new Enemy("Волк", 10, 5, 10),
                    new Enemy("Гоблин,", 15, 7, 15),
                    new Enemy("Тролль", 20, 10, 20)


                };

            List<Enemy> enemies_lvl2 = new List<Enemy>()
                {
                    new Enemy("Варвар", 20, 12, 25),
                    new Enemy("Берсерк", 25, 14, 30),
                    new Enemy("Вождь", 25, 15, 30)
                };
            List<Enemy> enemies_lvl3 = new List<Enemy>()
                {
                    new Enemy("Рекрут", 20, 10, 20),
                    new Enemy("Рыцарь", 25, 14, 30),
                    new Enemy("Командир", 30, 15, 50)
                };



            while (true)
            {




                bool menu = true;

                while (menu)
                {
                    Console.WriteLine("================= Меню ================");
                    Console.WriteLine("1. В бой!");
                    Console.WriteLine("2. Лечиться");
                    Console.WriteLine("3. Посмореть свои характеристики");
                    Console.WriteLine("4. Выход");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            {


                                menu = false;




                                break;
                            }





                        case "2":
                            {
                                player.HP = player.MaxHP;
                                Console.WriteLine($"Вы вылечились! {player.HP}/{player.MaxHP}");

                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("====== Ваша статистика ======");
                                Console.WriteLine($"Ваше имя: {player.Name}");
                                Console.WriteLine($"Ваш уровень {player.level}");
                                Console.WriteLine($"Ваше HP: {player.HP}/{player.MaxHP}");
                                Console.WriteLine($"Ваша броня: {player.Defense}");
                                Console.WriteLine($"Ваше XP: {player.XP}/{player.level * 100}");
                                Console.WriteLine($"Бонус к атаке: {player.AttackBonus}");
                                Console.WriteLine($"Бонус к урону: {player.DamageBonus}");
                                Console.WriteLine($"Всего заработано XP: {player.TotalXp}");
                                Console.WriteLine($"Количество убийств: {player.KillCount}");
                                break;
                            }

                        case "4":
                            {
                                return;

                            }
                        default:
                            {
                                Console.WriteLine("Нет такой команды!");
                                break;
                            }



                    }















                }


                Enemy template;
                Random enemy_rand = new Random();


                List<Enemy> currentEnemies;

                if (player.level < 2)
                {
                    currentEnemies = enemies_lvl1; 
                }
                else if (player.level > 1 && player.level < 3)
                {

                    currentEnemies = new List<Enemy>();
                    currentEnemies.AddRange(enemies_lvl1);
                    currentEnemies.AddRange(enemies_lvl2);
                }
                

                else
                {
                    
                    currentEnemies = new List<Enemy>();
                    currentEnemies.AddRange(enemies_lvl1);
                    currentEnemies.AddRange(enemies_lvl2);
                    currentEnemies.AddRange(enemies_lvl3);
                
                }
                template = currentEnemies[enemy_rand.Next(0, currentEnemies.Count)];


                Enemy enemy = new Enemy(template.Name, template.MaxHP, template.Defense, template.Exp);

                bool won = battle.Fight(player, enemy);

                if (!player.IsAlive)
                {
                    Console.WriteLine("Вы погибли... Игра окончена.");
                    Console.ReadLine();
                    return;
                }

                if (won)
                {
                    player.KillCount++;
                    player.XP += enemy.Exp;
                    player.TotalXp += enemy.Exp;
                    Console.WriteLine($"Получено {enemy.Exp} опыта!");
                }
                else
                {
                    Console.WriteLine("Вы сбежали... Возвращаемся в меню.");
                }






                







            }













        }
    }
}
