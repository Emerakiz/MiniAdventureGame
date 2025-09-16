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
        public bool CanRest = true;


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
        }

        //Methods
        public void LevelUp(Player p, Enemy[] enemies)
        {
            if (p.PlayerXp >= p.PlayerMaxXp)
            {
                p.PlayerHealth = p.PlayerMaxHealth; //Reset Health

                p.PlayerLevel += 1;
                p.PlayerXp -= p.PlayerMaxXp;
                p.PlayerMaxXp += 50;

                if (p.PlayerClass == "Mage")
                {
                    p.PlayerHealth += 2;
                    p.PlayerMaxHealth += 2;
                    p.PlayerDamage += 2;
                }
                else if (p.PlayerClass == "Warrior")
                {
                    p.PlayerHealth += 4;
                    p.PlayerMaxHealth += 4;
                    p.PlayerDamage += 2;
                }
                else
                {
                    p.PlayerHealth += 3;
                    p.PlayerMaxHealth += 3;
                    p.PlayerDamage += 3;
                }
                Console.Clear();
                Console.WriteLine(new string ('-', 50));
                Console.WriteLine("You level up!");
                Console.WriteLine("Health is restored...");
                Console.WriteLine(new string('-', 50));

                enemies[0].EnemyLevelUp(enemies);
                p.DisplayStats(p);
            }
        }
        public void ChooseClass(Player p)
        {
            while (true)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Choose your class! (Warrior, Rouge, Mage)");
                Console.WriteLine("Warrior: High HP, Medium Damage, Slow");
                Console.WriteLine("Rouge: Low HP, High Damage, Fast");
                Console.WriteLine("Mage: Balanced");
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
                else if (p.PlayerClass == "rouge")
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

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public void Rest(Player p)
        {
            if (CanRest == true)
            {
                Console.WriteLine(new string('=', 50));
                if (p.PlayerHealth == p.PlayerMaxHealth)
                {
                    Console.WriteLine("You are already fully healed!");
                }
                else
                {
                    Console.WriteLine("You took a moment to rest...");
                    Console.WriteLine("You gained 10 HP!");
                }

                if (p.PlayerHealth < p.PlayerMaxHealth)
                {
                    p.PlayerHealth += 10;

                    if (p.PlayerHealth > p.PlayerMaxHealth)
                    {
                        p.PlayerHealth = p.PlayerMaxHealth;
                    }
                }
                Console.WriteLine($"Current HP: {p.PlayerHealth}/{p.PlayerMaxHealth}");
                Console.WriteLine(new string('=', 50));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                CanRest = false;
            } else
            {
                Console.WriteLine("You have already rested, venture into the dungeon before resting again!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }  
        }
    }
}

