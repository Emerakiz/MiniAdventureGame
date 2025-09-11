using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventureGame
{
    public class Enemy
    {
        public string Type = "";
        public int EnemyLevel = 1;
        public int EnemyHealth = 0;
        public int EnemyMaxHealth = 0;
        public int EnemyDamage = 0;
        public int EnemySpeed = 0;
        public int GoldReward = 0;
        public int XpReward = 0;

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
        public void EnemyLevelUp(Enemy[] enemies)
        {
            Console.WriteLine("Enemies grew stronger!");

            foreach (Enemy e in enemies)
            {
                e.EnemyLevel += 1;
                e.EnemyHealth += 3; //???? Kanske bara göra denna som MaxHealth - Player HP = Health i logik ist
                e.EnemyMaxHealth += 3;
                e.EnemyDamage += 2;
                e.GoldReward += 5;

            }
        }
    }
}
