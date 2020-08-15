using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class Dayuppy
    {
        public static void Testing()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;

            //Format the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            bool godMode = false;

            while (1 == 1)
            {

                Console.WriteLine("RunTime " + elapsedTime);

                #region Cheat Codes
                if ((Memory.ReadUShort(Addresses.buttonInputs) == 2319))  //If L1+L2+R1+R2+Select+Start is pressed, return to main menu
                {
                    Thread.Sleep(2000); //Wait two seconds
                    if ((Memory.ReadUShort(Addresses.buttonInputs) == 2319))  //Check again
                    {
                        if (Player.inDungeonFloor() == true)
                            Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                        else
                            Memory.WriteInt(Addresses.townSoftReset, 1); //If we are in town, this will take us to the main menu
                    }
                }
                if ((Memory.ReadUShort(Addresses.buttonInputs) == 4111))  //If L1+L2+R1+R2+DpadUp is pressed, activate godmode
                {
                    Thread.Sleep(2000); //Wait two seconds
                    if ((Memory.ReadUShort(Addresses.buttonInputs) == 4111))  //Check again
                    {
                        if (Player.inDungeonFloor() == true)
                            godMode = true;
                    }
                }
                #endregion

                int currentCharacter = Memory.ReadInt(Player.currentCharacter); //Read 4 bytes of currentCharacter value and check if Toan, Xiao, etc. Toan = 1680945251, Xiao = 1647587427

                if (godMode == true)
                {
                    if (currentCharacter == 1680945251) //Toan
                        Memory.WriteUShort(Player.Toan.hp, Memory.ReadUShort(Player.Toan.maxHP)); //Set Toan's HP to match max HP
                    else if (currentCharacter == 1647587427) //Xiao
                        Memory.WriteUShort(Player.Xiao.hp, Memory.ReadUShort(Player.Xiao.maxHP)); //Set Xiaos's HP to match max HP
                }

                Memory.WriteInt(Addresses.hideHud, 1);

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
            stopWatch.Stop();
        }
    }
}
