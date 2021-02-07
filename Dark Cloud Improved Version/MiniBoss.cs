using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class MiniBoss
    {

        static int currentFloor, prevFloor, bossEnemy;
        static Random rnd = new Random();

        public const int enemyZeroWidth = 0x21E18530;
        public const int enemyZeroHight = 0x21E18534;
        public const int enemyZeroDepth = 0x21E18538;
        public const int scaleOffset = 0x3510;

        public static void MiniBossTrait()
        {
            while (true)
            {
                if (Player.InDungeonFloor() == true)
                {
                    currentFloor = Memory.ReadByte(Addresses.checkFloor);

                    if (currentFloor != prevFloor)  //checking if player has entered a new floor
                    {
                        bossEnemy = rnd.Next(15);
                        Memory.WriteFloat(enemyZeroWidth + (scaleOffset * bossEnemy), 3); //Scales chosen enemy
                        Memory.WriteFloat(enemyZeroHight + (scaleOffset * bossEnemy), 3);
                        Memory.WriteFloat(enemyZeroDepth + (scaleOffset * bossEnemy), 3);
                        prevFloor = currentFloor;   //once everything is done, we initialize this so it wont reroll again in same floor
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
