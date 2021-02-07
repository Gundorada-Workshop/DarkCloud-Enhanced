using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class MiniBossThread
    {

        static int currentFloor, prevFloor, bossEnemy;
        static Random rnd = new Random();

        public const int enemyZeroWidth = 0x21E18530;
        public const int enemyZeroHight = 0x21E18534;
        public const int enemyZeroDepth = 0x21E18538;
        public const int scaleOffset = 0x3510; //Offset for size
        const int varOffset = 0x190; //Offset for attributes
        public const int enemyNewHP = 100; //Changes HP and also changes max HP
        public const float scaleSize = 1.5F; //Sets the total size of the miniboss
        public const int enemyHPMult= 5; //Changes miniboss hp multiplier

        public static void MiniBossTrait()
        {
            while (true)
            {
                if (Player.InDungeonFloor() == true)
                {
                    currentFloor = Memory.ReadByte(Addresses.checkFloor);
                    //Console.WriteLine("In Dungeon");

                    if (currentFloor != prevFloor)  //checking if player has entered a new floor
                    {
                        //Console.WriteLine("Floor Changed");
                        Thread.Sleep(2000);          
                        bossEnemy = rnd.Next(15);
                        int startBossHP = Memory.ReadByte(Enemies.Enemy0.hp + (varOffset * bossEnemy));
                        Memory.WriteFloat(enemyZeroWidth + (scaleOffset * bossEnemy), scaleSize); //Scales chosen enemy
                        Memory.WriteFloat(enemyZeroHight + (scaleOffset * bossEnemy), scaleSize);
                        Memory.WriteFloat(enemyZeroDepth + (scaleOffset * bossEnemy), scaleSize);
                        Memory.WriteByte(Enemies.Enemy0.hp + (varOffset * bossEnemy), Convert.ToByte((startBossHP * enemyHPMult))); //Changes Enemy HP and MaxHP to scaled number
                        Memory.WriteByte(Enemies.Enemy0.maxHp + (varOffset * bossEnemy), Convert.ToByte((startBossHP * enemyHPMult)));
                        prevFloor = currentFloor;
                    }
                }
                else
                {
                    prevFloor = 200;    //used to reset the floor data when going back to dungeon
                }
            }


        }
    }
}
