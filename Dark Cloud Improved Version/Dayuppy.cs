using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class Dayuppy
    {
        public static void Testing()
        {
            while (1 == 1)
            {
                #region softReset
                if ((Memory.ReadUShort(Addresses.buttonInputs) == 2316))  //If L1+R1+Select+Start is pressed, return to main menu
                    {
                    if(Player.inDungeonFloor() == true)
                            Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                    else
                            Memory.WriteInt(Addresses.townSoftReset, 1); //If we are in town, this will take us to the main menu
                     }
                #endregion

                Math.Vector3 position = new Math.Vector3();
                Math.Vector3 dunPosition = new Math.Vector3();

                position.x = Memory.ReadFloat(Player.positionX);
                position.y = Memory.ReadFloat(Player.positionY);
                position.z = Memory.ReadFloat(Player.positionZ);

                dunPosition.x = Memory.ReadFloat(Player.dunPositionX);
                dunPosition.y = Memory.ReadFloat(Player.dunPositionY);
                dunPosition.z = Memory.ReadFloat(Player.dunPositionZ);

                Console.WriteLine("Input: " + Memory.ReadUShort(Addresses.buttonInputs));
                
                if(Player.inDungeonFloor() == false)
                    Console.WriteLine("Player Position:\t\tX: " + position.x + "\t\tY: " + position.y + "\t\tY: " + position.z);
                else
                    Console.WriteLine("Dungeon Player Position:\t\tX: " + dunPosition.x + "\t\tY: " + dunPosition.y + "\t\tY: " + dunPosition.z);

                Thread.Sleep(8); //8ms
                Console.Clear();
            }
            //Console.WriteLine("L1+R1+Select+Start was pressed... broke out of loop.");
            //Form1.dayThread.Abort();
        }
    }
}
