

namespace MiniAdventureGame
{
    public static class GameMechanics
    {
        


        public static void GameStart()
        {
            string Title = "Dungeon Adventure Game";

            Console.WriteLine($"Welcome to the {Title}!");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("");


            Console.WriteLine("HOW TO PLAY:");
            Console.WriteLine("1. Choose your characther class: Warrior, Rouge or Mage.");
            Console.WriteLine("2. Explore the dungeon, fight monsters and find loot.");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");


            Console.WriteLine("");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Press any key to start your adventure!");
            Console.ReadKey();
            Console.Clear();


        }

        public static void Adventure()
        {
            Console.WriteLine("You venture deeper into the dungeon...");


            
        }

        public static void Fight(Enemy[] enemies)
        {
            Console.WriteLine($"You encountered a {enemies}!");
            Console.WriteLine("What will you do?");
            Console.WriteLine("[1] Fight");
            Console.WriteLine("[2] Flee");
            Console.WriteLine(new string('-', 50));
            int input = int.Parse(Console.ReadLine());

            if (input < 1 || input > 2)
            {
                Console.WriteLine("Invalid input, try again...");
                return;
            }

            if (input == 2)
            {
                Console.WriteLine("You fled the battle!");
                Console.WriteLine("Press any key to contuine...");
                Console.ReadKey();
                return;
            }

            if (input == 1)
            {

            }


        }

        public static void Rest(Player p)
        {
            Console.WriteLine(new string('=', 50));
            while (p.PlayerHealth < p.PlayerMaxHealth)
            {
                p.PlayerHealth += 10;

                if (p.PlayerHealth > p.PlayerMaxHealth)
                {
                    p.PlayerHealth = p.PlayerMaxHealth;
                }
            }

            if (p.PlayerHealth == p.PlayerMaxHealth)
            {
                Console.WriteLine("You are already fully healed!");
            } else
            {
                Console.WriteLine("You took a moment to rest...");
                Console.WriteLine("You gained 10 HP!");
            }


            Console.WriteLine($"Current HP: {p.PlayerHealth}/{p.PlayerMaxHealth}");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Press any key to contuine...");
            Console.ReadKey();
        }
    }
}
