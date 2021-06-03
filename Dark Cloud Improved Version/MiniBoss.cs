using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    public class MiniBoss
    {

        static Random rnd = new Random();

        public const int enemyZeroWidth = 0x21E18530;  //Enemy Width multiplier
        public const int enemyZeroHeight = 0x21E18534; //Enemy Height multiplier
        public const int enemyZeroDepth = 0x21E18538;  //Enemy Depth multiplier
        public const int scaleOffset = 0x3510;         //Offset for size
        const int varOffset = 0x190;            //Offset for attributes
        const float scaleSize = 1.5F;           //Sets the total size of the miniboss
        const int enemyHPMult = 5;              //Miniboss HP multiplier
        const int enemyABSMult = 3;             //Miniboss ABS multiplier
        const int enemyItemResistMulti = 10;    //Miniboss Item Resistance multiplier
        const int enemyGoldMult = 3;            //Miniboss Gilda Drop multiplier
        const int enemyDropChance = 100;        //Miniboss Drop chance % (0 - 100)
        const byte staminaTimer = 79;          //Miniboss Stamina Timer (Currently 79 on the 3rd byte is roughly 1 day)

        //Get flying enemies
        static Dictionary<int, string> nonKeyEnemies = Enemies.EnemyList.enemiesFlying;

        //Define new loot tables for items
        static int[] attachmentsTableLucky = { 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106 }; //Gems
        static int[] attachmentsTableUnlucky =  {   81, 82, 83, 84, 85,                                 //Elements
                                                    91, 92, 93, 94,                                     //Stats
                                                    111, 112, 113, 114, 115, 116, 117, 118, 119, 120 }; //Anti-Stats
        static int[] itemTableLucky = { 150, 178, 235 };        //Stam Pot + Feather + PP
        static int[] itemTableUnlucky = { 132, 133, 134, 135 }; //Amulets

        public static bool MiniBossSpawn(bool skipFirstRoll = false, byte dungeon = 255, byte floor = 255)
        {
            //Rolls for a 30% chance to spawn the miniboss
            if (rnd.Next(100) <= 100 || skipFirstRoll)
            {
                //Choose the enemy to convert into mini boss
                int enemyNumber = rnd.Next(Enemies.GetFloorEnemiesIds().Count);

                //Check if chosen enemy is flying type
                if (!nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(enemyNumber)))
                {
                    //Check if chosen enemy has the key
                    if (Enemies.EnemyHasKey(enemyNumber, dungeon))
                    {
                        Console.WriteLine("The Key has landed on the mini boss!");

                        int newEnemyNumber;

                        //Get the enemy key ID
                        byte KeyId = Memory.ReadByte(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber));

                        //Re-roll for a different enemy that does not hold the key and is non flying
                        do { newEnemyNumber = rnd.Next(Enemies.GetFloorEnemiesIds().Count - 1); } while (   newEnemyNumber == enemyNumber &&
                                                                                                            Enemies.EnemyHasKey(newEnemyNumber, dungeon) &&
                                                                                                            nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(enemyNumber)));
                        
                        //Set the key onto a new enemy
                        Memory.WriteByte(Enemies.Enemy0.forceItemDrop + (varOffset * newEnemyNumber), KeyId);

                        //Reset enemeyNumber var
                        enemyNumber = newEnemyNumber;
                    }

                    //Get base values from the chosen enemy
                    int startBossHP =   Memory.ReadByte(Enemies.Enemy0.hp + (varOffset * enemyNumber));
                    int startAbs    =   Memory.ReadInt(Enemies.Enemy0.abs + (varOffset * enemyNumber));
                    int startGold   =   Memory.ReadInt(Enemies.Enemy0.minGoldDrop + (varOffset * enemyNumber));

                    // === Set mini boss new stats ===
                    Memory.WriteFloat(enemyZeroWidth + (scaleOffset * enemyNumber), scaleSize);   //Scales Width
                    Memory.WriteFloat(enemyZeroHeight + (scaleOffset * enemyNumber), scaleSize);  //Scales Height
                    Memory.WriteFloat(enemyZeroDepth + (scaleOffset * enemyNumber), scaleSize);   //Scales Depth
                    Memory.WriteInt(Enemies.Enemy0.hp + (varOffset * enemyNumber), (startBossHP * enemyHPMult));        //Changes Enemy HP                  
                    Memory.WriteInt(Enemies.Enemy0.maxHp + (varOffset * enemyNumber), (startBossHP * enemyHPMult));     //Changes MaxHP
                    Memory.WriteInt(Enemies.Enemy0.abs + (varOffset * enemyNumber), (startAbs * enemyABSMult));         //Changes ABS reward
                    Memory.WriteInt(Enemies.Enemy0.itemResistance + (varOffset * enemyNumber), enemyItemResistMulti);   //Changes the enemies item resistance
                    Memory.WriteInt(Enemies.Enemy0.minGoldDrop + (varOffset * enemyNumber), startGold * enemyGoldMult); //Changes the enemies gilda drop amount
                    Memory.WriteInt(Enemies.Enemy0.dropChance + (varOffset * enemyNumber), enemyDropChance);            //Changes the enemies drop chance
                    Memory.WriteByte(Enemies.Enemy0.staminaTimer + (varOffset * enemyNumber) + 0x2, staminaTimer);      //Changes the enemies stamina timer

                    // === Set mini boss new item ===

                    int[] weaponTable = CustomChests.GetDungeonWeaponsTable(dungeon, floor);

                    //Roll first for the backfloor key
                    if(rnd.Next(100) < 50)
                    {
                        //Fetch the backfloor key
                        byte backFloorKey = DungeonThread.GetDungeonBackFloorKey(dungeon);

                        //Set the miniboss item as the backfloor key
                        Memory.WriteInt(Enemies.Enemy0.itemDropId + (varOffset * enemyNumber), backFloorKey);
                    }
                    //If backfloor key roll fails, roll for weapon
                    else if (rnd.Next(100) < 15)
                    {
                        //Fetch a random weapon from the current dungeon and floor table
                        Memory.WriteInt(Enemies.Enemy0.itemDropId + (varOffset * enemyNumber), weaponTable[rnd.Next(weaponTable.Count())]);
                        Console.WriteLine("Miniboss rolled with weapon!");
                    }
                    //If weapon roll fails, roll for attachments
                    else if (rnd.Next(100) < 50)
                    {
                        //Roll for lucky
                        if (rnd.Next(100) < 30) Memory.WriteInt(Enemies.Enemy0.itemDropId + (varOffset * enemyNumber), attachmentsTableLucky[rnd.Next(attachmentsTableLucky.Count())]);
                        else Memory.WriteInt(Enemies.Enemy0.itemDropId + (varOffset * enemyNumber), attachmentsTableUnlucky[rnd.Next(attachmentsTableUnlucky.Count())]);
                        Console.WriteLine("Miniboss rolled with attachment!");
                    }
                    else //If previous rolls fail, default to items
                    {
                        //Roll for lucky
                        if (rnd.Next(100) < 30) Memory.WriteInt(Enemies.Enemy0.itemDropId + (varOffset * enemyNumber), itemTableLucky[rnd.Next(itemTableLucky.Count())]);
                        else Memory.WriteInt(Enemies.Enemy0.itemDropId + (varOffset * enemyNumber), itemTableUnlucky[rnd.Next(itemTableUnlucky.Count())]);
                        Console.WriteLine("Miniboss rolled with item!");
                    }

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