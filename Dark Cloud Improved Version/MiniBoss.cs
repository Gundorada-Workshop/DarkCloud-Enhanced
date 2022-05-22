using System;
using System.Collections.Generic;
using System.Linq;

namespace Dark_Cloud_Improved_Version
{
    public class MiniBoss
    {
        //static string "[" + DateTime.Now + "]" + " " = ReusableVariables.Get"[" + DateTime.Now + "]" + " "();
        static Random rnd = new Random();

        public const int enemyZeroWidth = 0x21E18530;  //Enemy Width multiplier
        public const int enemyZeroHeight = 0x21E18534; //Enemy Height multiplier
        public const int enemyZeroDepth = 0x21E18538;  //Enemy Depth multiplier
        public const int scaleOffset = 0x3510;         //Offset for size
        const int varOffset = 0x190;            //Offset for attributes
        const float scaleSize = 1.5F;           //Sets the total size of the miniboss
        const int enemyHPMult = 3;              //Miniboss HP multiplier
        const int enemyABSMult = 3;             //Miniboss ABS multiplier
        const int enemyItemResistMulti = 10;    //Miniboss Item Resistance multiplier %
        const int enemyGoldMult = 3;            //Miniboss Gilda Drop multiplier
        const int enemyDropChance = 100;        //Miniboss Drop chance % (0 - 100)
        const byte staminaTimer = 79;           //Miniboss Stamina Timer (Currently 79 on the 3rd byte is roughly 1 day)

        //Get flying enemies
        static Dictionary<ushort, string> nonKeyEnemies = Enemies.GetFlyingEnemies();

        //Define new loot tables for items
        static ushort[] attachmentsTableLucky = { 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106 };  //Gems
        static ushort[] attachmentsTableUnlucky =  {   81, 82, 83, 84, 85,                                  //Elements
                                                    91, 92, 93, 94,                                         //Stats
                                                    111, 112, 113, 114, 115, 116, 117, 118, 119, 120 };     //Anti-Stats
        static ushort[] itemTableLucky = { 150, 178, 235 };        //Stam Pot + Feather + PP
        static ushort[] itemTableUnlucky = { 132, 133, 134, 135 }; //Amulets

        /// <summary>
        /// Picks and transforms an enemy on the current floor to become a Champion (Miniboss).
        /// </summary>
        /// <param name="skipFirstRoll">To skip the spawning chance roll.</param>
        /// <param name="dungeon">The number of the current dungeon.</param>
        /// <param name="floor">The number of the current floor.</param>
        /// <returns></returns>
        public static bool MiniBossSpawn(bool skipFirstRoll = false, byte dungeon = 255, byte floor = 255)
        {
            //Rolls for a 30% chance to spawn the miniboss
            if (rnd.Next(100) <= 30 || skipFirstRoll)
            {
                //Choose the enemy to convert into mini boss
                int enemyNumber = rnd.Next(Enemies.GetFloorEnemiesIds().Count);
                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "\nEnemyNumber rolled before flying check: " + enemyNumber + "\nIs flying enemy: " + nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(enemyNumber)) + "\nChosen miniboss: " + Enemies.GetFloorEnemyId(enemyNumber) + "\n");

                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "\n== Enemy IDs ==");
                //foreach (ushort enemy in Enemies.GetFloorEnemiesIds()) Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + enemy);

                //Check if the chosen enemy has an ID
                if (Enemies.GetFloorEnemyId(enemyNumber) > 0)
                {
                    //Check if chosen enemy is flying type
                    if (!nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(enemyNumber)))
                    {
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "\nEnemyNumber rolled after flying check: " + enemyNumber + "\nIs flying enemy: " + nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(enemyNumber)) + "\nChosen miniboss ID: " + Enemies.GetFloorEnemyId(enemyNumber) + "\n");

                        //Check if chosen enemy has the key
                        if (Enemies.EnemyHasKey(enemyNumber, dungeon))
                        {
                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "\nThe Key has landed on the mini boss!");

                            int newEnemyNumber;

                            //Get the enemy key ID
                            byte KeyId = Memory.ReadByte(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber));

                            //Re-roll for a different enemy that does not hold the key (due to Wise Owl) and is non flying
                            do { newEnemyNumber = rnd.Next(Enemies.GetFloorEnemiesIds().Count); } while (newEnemyNumber == enemyNumber &&
                                                                                                                Enemies.EnemyHasKey(newEnemyNumber, dungeon) &&
                                                                                                                nonKeyEnemies.ContainsKey(Enemies.GetFloorEnemyId(newEnemyNumber)));

                            //Remove the key from the original enemy
                            Memory.WriteUShort(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber), 0);

                            //Set the key onto a new enemy
                            Memory.WriteUShort(Enemies.Enemy0.forceItemDrop + (varOffset * newEnemyNumber), KeyId);
                        }

                        //  == Get base values from the chosen enemy ==
                        int startBossHP = Memory.ReadInt(Enemies.Enemy0.hp + (varOffset * enemyNumber));
                        int startAbs = Memory.ReadInt(Enemies.Enemy0.abs + (varOffset * enemyNumber));
                        int startGold = Memory.ReadInt(Enemies.Enemy0.minGoldDrop + (varOffset * enemyNumber));

                        // === Set mini boss new stats ===
                        Memory.WriteFloat(enemyZeroWidth + (scaleOffset * enemyNumber), scaleSize);                         //Scales Width
                        Memory.WriteFloat(enemyZeroHeight + (scaleOffset * enemyNumber), scaleSize);                        //Scales Height
                        Memory.WriteFloat(enemyZeroDepth + (scaleOffset * enemyNumber), scaleSize);                         //Scales Depth
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
                        if (rnd.Next(100) < 50)
                        {
                            //Fetch the backfloor key
                            byte backFloorKey = Dungeon.GetDungeonBackFloorKey(dungeon);

                            //Set the miniboss item as the backfloor key
                            Memory.WriteUShort(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber), backFloorKey);
                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Miniboss rolled with backfloor key!");
                        }
                        //If backfloor key roll fails, roll for weapon
                        else if (rnd.Next(100) < 15)
                        {
                            //Fetch a random weapon from the current dungeon and floor table
                            Memory.WriteInt(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber), weaponTable[rnd.Next(weaponTable.Count())]);
                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Miniboss rolled with weapon!");
                        }
                        //If weapon roll fails, roll for attachments
                        else if (rnd.Next(100) < 50)
                        {
                            //Roll for lucky
                            if (rnd.Next(100) < 30) Memory.WriteUShort(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber), attachmentsTableLucky[rnd.Next(attachmentsTableLucky.Count())]);
                            else Memory.WriteUShort(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber), attachmentsTableUnlucky[rnd.Next(attachmentsTableUnlucky.Count())]);
                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Miniboss rolled with attachment!");
                        }
                        else //If previous rolls fail, default to items
                        {
                            //Roll for lucky
                            if (rnd.Next(100) < 30) Memory.WriteUShort(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber), itemTableLucky[rnd.Next(itemTableLucky.Count())]);
                            else Memory.WriteUShort(Enemies.Enemy0.forceItemDrop + (varOffset * enemyNumber), itemTableUnlucky[rnd.Next(itemTableUnlucky.Count())]);
                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Miniboss rolled with item!");
                        }

                        return true; 
                    }
                    //Retry if landing on a flying enemy
                    else { Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + " Miniboss landed on flying enemy!"); MiniBossSpawn(true, dungeon, floor); return true; }
                }
                //Retry if landing on a enemy with ID 0
                else { Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Chosen enemy ID must not be 0!"); MiniBossSpawn(true, dungeon, floor); return true; }
            }
            else Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Failed to roll for Mini Boss!");

            return false;
        }
    }
}