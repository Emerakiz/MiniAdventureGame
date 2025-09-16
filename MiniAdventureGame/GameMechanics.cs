

using System.Numerics;

namespace MiniAdventureGame
{
    public static class GameMechanics
    {
        public static void GameStart()
        {
            string Title = "Dungeon Adventure Game";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Welcome to the {Title}!");
            Console.ResetColor();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("");


            Console.WriteLine("HOW TO PLAY:");
            Console.WriteLine("1. Choose your character class: Warrior, Rouge or Mage.");
            Console.WriteLine("2. Venture into the dungeon, fight monsters or find loot.");
            Console.WriteLine("3. During battles, choose to Attack, Rest or Flee.");
            Console.WriteLine("4. Rest to recover health.");
            Console.WriteLine("5. Gain experience and gold, level up and grow stronger!");


            Console.WriteLine("");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Press any key to start your adventure!");
            Console.ReadKey();
            Console.Clear();
        }

        public static void GameOver(Player player)
        {
            Console.WriteLine("You have been defeated...");
            player.DisplayStats(player);
            Console.WriteLine("Better luck next time!");
        }

        public static void Encounter(Player player, Enemy[] enemies)
        {
            Random random = new Random();

            int index = random.Next(0, enemies.Length);
            Enemy enemy = enemies[index].Clone();

            Console.Clear();

            //Chance for meeting stronger enemy
            if (player.PlayerLevel >= 2)
            {
                int chance = random.Next(0,100);
                if (chance < 25)
                {
                    enemy.EnemyLevel += 1;
                    enemy.EnemyHealth += 3;
                    enemy.EnemyMaxHealth += 3;
                    enemy.EnemyDamage += 4;
                    enemy.GoldReward += 5;
                    Console.WriteLine("Something strong is approching...");

                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine($"A level {enemy.EnemyLevel} {enemy.Type} appears!");
            Console.WriteLine("What will you do?");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("[1] Fight");
            Console.WriteLine("[2] Flee");
            Console.WriteLine(new string('=', 50));
            int input = int.Parse(Console.ReadLine());

            if (input == 2)
            {
                Console.Clear();

                player.PlayerHealth -= 5;
                player.PlayerGold -= 2;

                Console.WriteLine("You fled the battle!");
                Console.WriteLine("You took 5 damage and lost 2 Gold.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                if (player.PlayerGold < 0)
                {
                    player.PlayerGold = 0;
                }

            }
            else if (input == 1)
            {
                Fight(player, enemy);
            }
            else
            {
                Console.WriteLine("Invalid input, try again...Press any key to continue");
                Console.ReadKey();
                return;
            }

            player.CanRest = true;
        }

        public static void Fight(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("You chose to fight!");
            Thread.Sleep(1000);

            bool isFighting = true;

            while (isFighting)
            {
                Console.Clear();
                Console.WriteLine($"== {enemy.Type} Lvl {enemy.EnemyLevel} ==");
                Console.WriteLine("= What will you do? =");
                Console.WriteLine("[1] Attack");
                Console.WriteLine("[2] Rest");
                Console.WriteLine("[3] Show Stats");
                Console.WriteLine("[4] Flee");
                Console.WriteLine(new string('=', 50));

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //Player Attack
                        Console.WriteLine(new string('-', 50));

                        enemy.EnemyHealth -= player.PlayerDamage;
                        Console.WriteLine($"You dealt {player.PlayerDamage} damage to the {enemy.Type}!");

                        if (enemy.EnemyHealth <= 0)
                        {
                            Console.WriteLine($"You defeated the {enemy.Type}!");
                            player.PlayerXp += enemy.XpReward;
                            player.PlayerGold += enemy.GoldReward;
                            Console.WriteLine($"You gained {enemy.XpReward} XP and {enemy.GoldReward} Gold!");
                            

                            isFighting = false;
                        }
                        else
                        {
                            EnemyAttack(player, enemy);
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        player.CanRest = true;

                        break;
                    case 2:
                        player.Rest(player);
                        EnemyAttack(player, enemy);
                        break;
                    case 3:
                        player.DisplayStats(player);
                        break;
                    case 4:
                        Console.Clear();

                        player.PlayerHealth -= 5;
                        player.PlayerGold -= 5;

                        if (player.PlayerGold < 0)
                        {
                            player.PlayerGold = 0;
                        }

                        Console.WriteLine("You fled the battle!");
                        Console.WriteLine("You lost 5 HP and 5 gold pieces.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        isFighting = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again... Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

                if (player.PlayerHealth <= 0)
                {
                    isFighting = false;
                    GameOver(player);
                }
                
            }
        }

        public static void EnemyAttack(Player player, Enemy enemy)
        {
            player.PlayerHealth -= enemy.EnemyDamage;
            Console.WriteLine($"The {enemy.Type} dealt {enemy.EnemyDamage} damage to you!");

            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"Your HP: {player.PlayerHealth}/{player.PlayerMaxHealth}");
            Console.WriteLine($"{enemy.Type} HP: {enemy.EnemyHealth}/{enemy.EnemyMaxHealth}");
        }
    }
}
