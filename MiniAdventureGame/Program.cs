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
            Player player = new Player("Unknown", "Unknown", 1, 0, 100, 0, 0, 0, 0, 0);


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
                Console.WriteLine(new string('-', 50));

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You walked deeper into the dungeon..."); //Random, möta fiende, hitta loot, hitta inget.
                        break;
                    case 2:
                        //Healar x antal (går bara att göra en gång) if took heal cant until adventure
                        GameMechanics.Rest(player);
                        break;
                    case 3:
                        Console.Clear();
                        player.DisplayStats(player);
                        break;
                    case 4:
                        Console.WriteLine("You exit the dungeon.");
                        gameRunning = false;
                        break;

                }

            }

           

            
        }
    }
}
