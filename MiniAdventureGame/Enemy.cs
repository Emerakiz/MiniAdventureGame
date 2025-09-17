using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventureGame
{
    public class Enemy
    {
        public string Type;
        public int EnemyLevel = 1;
        public int EnemyHealth;
        public int EnemyMaxHealth;
        public int EnemyDamage;
        public int EnemySpeed;
        public int GoldReward;
        public int XpReward;

        //Constructor
        public Enemy(int enemyLevel, int enemyHealth, int enemyMaxHealth, int enemyDamage, int enemySpeed, int goldReward, int xpReward)
        {
            EnemyLevel = enemyLevel;
            EnemyHealth = enemyHealth;
            EnemyMaxHealth = enemyMaxHealth;
            EnemyDamage = enemyDamage;
            EnemySpeed = enemySpeed;
            GoldReward = goldReward;
            XpReward = xpReward;
        }

        //Methods
        public Enemy Clone()
        {
            return new Enemy(EnemyLevel, EnemyHealth, EnemyMaxHealth, EnemyDamage, EnemySpeed, GoldReward, XpReward)
            {
                Type = this.Type
            };
        }
        public void EnemyDisplayStats(Enemy enemies)
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Type: {enemies.Type}");
            Console.WriteLine($"Level: {enemies.EnemyLevel}");
            Console.WriteLine($"Health: {enemies.EnemyHealth}/{enemies.EnemyMaxHealth}");
            Console.WriteLine($"Damage: {enemies.EnemyDamage}");
        }

        public void EnemyLevelUp(Enemy[] enemies)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enemies grew stronger!");
            Console.ResetColor();

            foreach (Enemy e in enemies)
            {
                e.EnemyLevel += 1;
                e.EnemyHealth += 3; 
                e.EnemyMaxHealth += 3;
                e.EnemyDamage += 2;
                e.GoldReward += 2;
            }
        }
    }
}
