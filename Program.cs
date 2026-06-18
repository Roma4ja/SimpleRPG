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

            int fightNumber = 1;
            while (fightNumber <= 3)
            {
                
                bool menu = true;
                while (menu)
                {
                    Console.WriteLine("\nЧто хотите сделать?");
                    Console.WriteLine("1. Вылечиться");
                    Console.WriteLine("2. Сразиться");
                    Console.WriteLine("3. Выйти");

                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        player.HP = player.MaxHP;
                        Console.WriteLine($"Вылечены! HP: {player.HP}/{player.MaxHP}");
                    }
                    else if (choice == "2")
                    {
                        menu = false; 
                    }
                    else if (choice == "3")
                    {
                        return; 
                    }
                    else
                    {
                        Console.WriteLine("Нет такого выбора!");
                    }
                }

                
                Enemy enemy;
                if (fightNumber == 1) enemy = new Enemy("Волк", 15, 5);
                else if (fightNumber == 2) enemy = new Enemy("Гоблин", 20, 7);
                else enemy = new Enemy("Тролль", 25, 10);

               
                bool won = battle.Fight(player, enemy);

                if (!player.IsAlive) { Console.WriteLine("Вы погибли..."); return; }
                if (!won) { Console.WriteLine("Вы сбежали..."); return; }

                fightNumber++;
            }

            Console.WriteLine("\n=== ВЫ ПОБЕДИЛИ ВСЕХ! ===");
            Console.ReadLine();
        }
    }
}