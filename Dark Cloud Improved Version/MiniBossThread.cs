using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    public class MiniBossThread
    {

        static Random rnd = new Random();

        public const int enemyZeroWidth = 0x21E18530;
        public const int enemyZeroHeight = 0x21E18534;
        public const int enemyZeroDepth = 0x21E18538;
        const int scaleOffset = 0x3510;             //Offset for size
        const int varOffset = 0x190;                //Offset for attributes
        public const int enemyNewHP = 100;          //Changes HP and also changes max HP
        public const float scaleSize = 1.5F;        //Sets the total size of the miniboss
        public const int enemyHPMult = 5;           //Miniboss HP multiplier
        public const int enemyABSMult = 3;          //Miniboss ABS multiplier
        public const int enemyItemResistMulti = 30; //Miniboss Item Resistance multiplier
        public const int enemyGoldMult = 3;         //Miniboss Gilda Drop multiplier
        public const int enemyDropChance = 100;         //Miniboss Drop chance % (0 - 100)

        //Get flying enemies
        public static Dictionary<int, string> nonKeyEnemies = Enemies.EnemyList.enemiesFlying;

        public static bool MiniBossSpawn(bool skipFirstRoll = false, byte dungeon = 255)
        {
            //Rolls for a 30% chance to spawn the miniboss
            if (rnd.Next(100) <= 100 || skipFirstRoll)
            {
                //Choose the enemy to convert into mini boss (0 - 15)
                int enemyNumber = rnd.Next(16);

                //Check if enemy is flying type
                if (!nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(enemyNumber)))
                {
                    //Check if chosen enemy has the key
                    if(Enemies.EnemyHasKey(enemyNumber, dungeon))
                    {
                        Console.WriteLine("The Key has landed on the mini boss!");

                        int newEnemyNumber;

                        //Get the enemy key ID
                        byte KeyId = Memory.ReadByte(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber));

                        //Re-roll for a different enemy that does not hold the key and is non flying
                        do { newEnemyNumber = rnd.Next(15); } while (   newEnemyNumber == enemyNumber && 
                                                                        Enemies.EnemyHasKey(newEnemyNumber, dungeon) && 
                                                                        nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(enemyNumber))    );

                        //Set the key onto a new enemy
                        Memory.WriteByte(Enemies.Enemy0.forceItemDrop + (varOffset * newEnemyNumber), KeyId);
                    }

                    //Get base values from the chosen enemy
                    int startBossHP = Memory.ReadByte(Enemies.Enemy0.hp + (varOffset * enemyNumber));
                    int startAbs = Memory.ReadInt(Enemies.Enemy0.abs + (varOffset * enemyNumber));
                    int startGold = Memory.ReadInt(Enemies.Enemy0.minGoldDrop + (varOffset * enemyNumber));

                    Memory.WriteFloat(enemyZeroWidth + (scaleOffset * enemyNumber), scaleSize);   //Scales Width
                    Memory.WriteFloat(enemyZeroHeight + (scaleOffset * enemyNumber), scaleSize);  //Scales Height
                    Memory.WriteFloat(enemyZeroDepth + (scaleOffset * enemyNumber), scaleSize);   //Scales Depth
                    Memory.WriteInt(Enemies.Enemy0.hp + (varOffset * enemyNumber), (startBossHP * enemyHPMult));        //Changes Enemy HP                  
                    Memory.WriteInt(Enemies.Enemy0.maxHp + (varOffset * enemyNumber), (startBossHP * enemyHPMult));     //Changes MaxHP
                    Memory.WriteInt(Enemies.Enemy0.abs + (varOffset * enemyNumber), (startAbs * enemyABSMult));         //Changes ABS reward
                    Memory.WriteInt(Enemies.Enemy0.itemResistance + (varOffset * enemyNumber), enemyItemResistMulti);   //Changes the enemies item resistance
                    Memory.WriteInt(Enemies.Enemy0.minGoldDrop + (varOffset * enemyNumber), startGold * enemyGoldMult); //Changes the enemies gilda drop amount
                    Memory.WriteInt(Enemies.Enemy0.dropChance + (varOffset * enemyNumber), enemyDropChance);            //Changes the enemies drop chance
                    return true;
                }
                //Retry if landing on a flying enemy
                else { Console.WriteLine("Miniboss landed on flying enemy!"); MiniBossSpawn(true); }
            }
            else Console.WriteLine("Failed to roll for Mini Boos"); 
            return false;
        }
    }
}