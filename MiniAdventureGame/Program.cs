using System.Dynamic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace MiniAdventureGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Enemies
            Enemy[] enemies = new Enemy[] {
                new Enemy(1, 7, 10, 3, 5, 4, 10) { Type = "Goblin" },
                new Enemy(1, 25, 25, 7, 1, 15, 30) { Type = "Orc" },
                new Enemy(1, 10, 10, 5, 3, 9, 15) { Type = "Bandit" },
                new Enemy(1, 15, 15, 4, 2, 6, 15) { Type = "Skeleton" }
            };  

            //Player
            Player player = new Player("Unknown", "Unknown", 1, 0, 50, 0, 0, 0, 0, 0);

            //Game start
            GameMechanics.GameStart();
            Console.WriteLine("Enter your character's name:");
            Console.WriteLine(new string('-', 50));
            player.Name = Console.ReadLine();

            player.ChooseClass(player);
            player.DisplayStats(player);
            Console.Clear();

            Console.WriteLine("Ready to adventure the dungeon?");
            Console.WriteLine("Press any key to enter..");
            Console.ReadKey();

            //Game loop
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                Console.WriteLine("= What you wanna do? =");
                Console.WriteLine("[1] Adventure deeper");
                Console.WriteLine("[2] Rest");
                Console.WriteLine("[3] Player status");
                Console.WriteLine("[4] Exit the dungeon");
                Console.WriteLine(new string('=', 50));

                int choice = int.Parse(Console.ReadLine());

                switch (choice) //Ändra färg på alla Press any key to blah blah
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("You venture deeper into the dungeon...");
                        Console.WriteLine(new string('-', 50));

                        Random random = new Random();
                        int encounterChance = random.Next(1, 101);

                        if (encounterChance <= 70)
                        {
                            GameMechanics.Encounter(player, enemies);
                        }
                        else
                        {
                            int lootChance = random.Next(1, 101);

                            if (lootChance <= 60)
                            {
                                int goldFound = random.Next(3, 11);
                                player.PlayerGold += goldFound;
                                Console.WriteLine($"You found a chest with {goldFound} gold pieces!");
                            } else if (lootChance > 60 && lootChance <= 70)
                            {
                                int healAmount = random.Next(5, 11);
                                player.PlayerHealth += healAmount;

                                if (player.PlayerHealth > player.PlayerMaxHealth)
                                {
                                    player.PlayerHealth = player.PlayerMaxHealth;
                                }

                                Console.WriteLine($"You found a small health potion and healed {healAmount} HP!");
                                Console.WriteLine($"Current health: {player.PlayerHealth}/{player.PlayerMaxHealth}");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 2:
                        player.Rest(player);
                        player.CanRest = false;
                        break;
                    case 3:
                        Console.Clear();
                        player.DisplayStats(player);
                        break;
                    case 4:
                        Console.WriteLine("You exit the dungeon.");
                        Console.WriteLine("Thanks for playing! Press any key to continue...");
                        gameRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again...");
                        break;

                }

                if (player.PlayerHealth <= 0)
                {
                    GameMechanics.GameOver(player);
                    gameRunning = false;
                }

                player.LevelUp(player, enemies);
            }

           

            
        }
    }
}
