using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventureGame
{
    public class Player
    {
        public string Name;
        public string PlayerClass;
        public int PlayerLevel = 1;
        public int PlayerXp = 0;
        public int PlayerMaxXp;
        public int PlayerHealth;
        public int PlayerMaxHealth;
        public int PlayerDamage;
        public int PlayerSpeed;
        public int PlayerGold = 0;


        //Constructor
        public Player(string name, string playerClass, int playerLevel, int playerXp, int playerMaxXp, int playerHealth, int playerMaxHealth, int playerDamage, int playerSpeed, int playerGold)
        {
            Name = name;
            PlayerLevel = playerLevel;
            PlayerClass = playerClass;
            PlayerXp = playerXp;
            PlayerMaxXp = playerMaxXp;
            PlayerHealth = playerHealth;
            PlayerMaxHealth = playerMaxHealth;
            PlayerDamage = playerDamage;
            PlayerSpeed = playerSpeed;
            PlayerGold = playerGold;

            //MaxXp kanske onödig? köra ex if ( playerXp > 100 ) = Level 2 typ osv (kanske inte en if stats? switch?)

        }

        //Methods
        
        public void ChooseClass(Player p)
        {
            //??????????????????


            while (true)
            {



                Console.WriteLine(new string('-', 50));

                Console.WriteLine("Choose your class (Warrior, Rogue, Mage):");

                Console.WriteLine(new string('-', 50));


                p.PlayerClass = Console.ReadLine().ToLower();


                if (p.PlayerClass == "warrior")
                {
                    p.PlayerClass = "Warrior";
                    p.PlayerHealth = 40;
                    p.PlayerMaxHealth = 40;
                    p.PlayerDamage = 8;
                    p.PlayerSpeed = 2;
                    break;

                }
                else if (p.PlayerClass == "rogue")
                {
                    p.PlayerClass = "Rouge";
                    p.PlayerHealth = 25;
                    p.PlayerMaxHealth = 25;
                    p.PlayerDamage = 10;
                    p.PlayerSpeed = 5;
                    break;

                }
                else if (p.PlayerClass == "mage")
                {
                    p.PlayerClass = "Mage";
                    p.PlayerHealth = 30;
                    p.PlayerMaxHealth = 30;
                    p.PlayerDamage = 7;
                    p.PlayerSpeed = 3;
                    break;

                }
                else
                {
                    Console.WriteLine("Invalid class selection. Please choose Warrior, Rogue, or Mage.");
                }

                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"You chose {p.PlayerClass}!");
                Console.WriteLine(new string('-', 50));
            }

        }

        public void DisplayStats(Player p)
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"{p.Name} the {p.PlayerClass}!");
            Console.WriteLine($"Level: {p.PlayerLevel} ({p.PlayerXp}/{p.PlayerMaxXp}xp)");
            Console.WriteLine($"Health: {p.PlayerHealth}/{p.PlayerMaxHealth}");
            Console.WriteLine($"Damage: {p.PlayerDamage}");
            Console.WriteLine($"Speed: {p.PlayerSpeed}");
            Console.WriteLine($"Gold: {p.PlayerGold}");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("Press any key to contuine...");
            Console.ReadKey();

        }



    }
}
