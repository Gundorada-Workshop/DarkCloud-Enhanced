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

        public static byte currentDungeon = Memory.ReadByte(Addresses.checkDungeon);

        //Get flying enemies
        public static Dictionary<int, string> nonKeyEnemies = Enemies.EnemyList.enemiesFlying;

        //Define event and boss floors
        public static List<byte> excludeFloors = DungeonThread.GetDungeonEventFloors(currentDungeon);

        public static byte GetCurrentFloor()
        {
            return Memory.ReadByte(Addresses.checkFloor);
        }

        public static bool MiniBossSpawn()
        {
            //Exclude event and boss floors
            if(!excludeFloors.Contains(GetCurrentFloor())){
                //Rolls for a 30% chance to spawn the miniboss
                if (rnd.Next(100) <= 100)
                {
                    //Choose the enemy to convert into mini boss (0 - 15)
                    int bossEnemy = rnd.Next(15);
                    
                    //Exclude the flying enemies
                    if (!nonKeyEnemies.ContainsKey(bossEnemy)) {

                        //Get base values from the chosen enemy
                        int startBossHP = Memory.ReadByte(Enemies.Enemy0.hp + (varOffset * bossEnemy));
                        int startAbs = Memory.ReadInt(Enemies.Enemy0.abs + (varOffset * bossEnemy));
                        int startGold = Memory.ReadInt(Enemies.Enemy0.minGoldDrop + (varOffset * bossEnemy));

                        Memory.WriteFloat(enemyZeroWidth + (scaleOffset * bossEnemy), scaleSize);   //Scales Width
                        Memory.WriteFloat(enemyZeroHeight + (scaleOffset * bossEnemy), scaleSize);  //Scales Height
                        Memory.WriteFloat(enemyZeroDepth + (scaleOffset * bossEnemy), scaleSize);   //Scales Depth
                        Memory.WriteInt(Enemies.Enemy0.hp + (varOffset * bossEnemy), (startBossHP * enemyHPMult));      //Changes Enemy HP                  
                        Memory.WriteInt(Enemies.Enemy0.maxHp + (varOffset * bossEnemy), (startBossHP * enemyHPMult));   //Changes MaxHP
                        Memory.WriteInt(Enemies.Enemy0.abs + (varOffset * bossEnemy), (startAbs * enemyABSMult));       //Changes ABS reward
                        Memory.WriteInt(Enemies.Enemy0.itemResistance + (varOffset * bossEnemy), enemyItemResistMulti);         //Changes the enemies item resistance
                        Memory.WriteInt(Enemies.Enemy0.minGoldDrop + (varOffset * bossEnemy), startGold * enemyGoldMult);       //Changes the enemies gilda drop amount
                        return true;
                    }
                }
            } return false;
        }
    }
}