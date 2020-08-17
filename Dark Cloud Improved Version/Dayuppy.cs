using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class Dayuppy
    {
        public static byte[] originalDunMessage = Memory.ReadByteArray(Addresses.dunMessage10, 157); //Read 157 bytes of byte array that stores dungeon message 10

        public static byte[] MesConvert(string message)
        {
            byte[] customMessage = Encoding.GetEncoding(10000).GetBytes(message);
            byte[] outputMessage = new byte[customMessage.Length * 2];

            decimal maxNumLines = customMessage.Length / 29;
            
            System.Math.Ceiling(maxNumLines);

            Console.WriteLine();
            Console.WriteLine("maxNumLines: " + maxNumLines);
            Console.WriteLine();
            Console.WriteLine("Custom  Message: " + BitConverter.ToString(customMessage));
            Console.WriteLine();
            Console.WriteLine("Dungeon Message: " + BitConverter.ToString(originalDunMessage));

            byte[] normalCharTable =
            {0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, //A-Z

            0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
            0x70, 0x71, 0x72, 0x73, 0x74 ,0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, //a-z
            
            //.    $      ?    !      %     &   \n
            0x2E, 0x24, 0x3F, 0x21, 0x25, 0x26, 0x0A

            };

            byte[] dcCharTable =
            {0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, //A-Z
            
            0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49,
            0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, //a-z

            //.    $    ?     !    %     &        \n
            0x6D, 0x6E, 0x59, 0x58, 0x60,  0x5B, 0x00
            
            };

            for (int i = 0; i < outputMessage.Length; i++)
            {
                outputMessage[i] = 0xFD;  //Initialize outputMessage to 0xFD
            }

            for (int i = 0; i < customMessage.Length; i++)
            {
                for (int t = 0; t < dcCharTable.Length; t++)
                {
                    if (customMessage[i] == normalCharTable[t])
                    {
                        outputMessage[i * 2] = dcCharTable[t];

                        if (normalCharTable[t] == 0x0A) //newLine
                        {
                            outputMessage[i * 2 + 1] = 0xFF;
                        }
                    }
                }
            }
            Console.WriteLine(BitConverter.ToString(outputMessage));
            return outputMessage;
        }

        public static void Testing()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool godMode = false;

            int textureAddress1 = 0x20429F10;
            int textureAddress2 = 0x2043A350;
            int textureAddress3 = 0x2044A790;

            byte[] modifiedTexture1 = FileSystem.ReadAllBytes("20429f10.tm2");
            byte[] modifiedTexture2 = FileSystem.ReadAllBytes("20429f10.tm2");
            byte[] modifiedTexture3= FileSystem.ReadAllBytes("20429f10.tm2");

            while (1 == 1)
            {
                int currentCharacter = Memory.ReadInt(Player.currentCharacter); //Read 4 bytes of currentCharacter value and check if Toan, Xiao, etc. Toan = 1680945251, Xiao = 1647587427
                
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10); //Format the TimeSpan value.
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
                        {
                            if (godMode == true)
                            {
                                godMode = false;
                                Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
                                Memory.WriteByteArray(Addresses.dunMessage10, MesConvert("God Mode deactivated.             \n                    \nYou are no longer invincible to enemy damage."));
                                Thread.Sleep(250);
                                Memory.WriteInt(Addresses.dunMessage, 10); //Display the 10th dungeon message
                                Thread.Sleep(3000); //Wait three seconds
                                Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
                                Memory.WriteByteArray(Addresses.dunMessage10, originalDunMessage); //Revert message back to default
                            }

                            else if (godMode == false)
                            {
                                godMode = true;
                                Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
                                Memory.WriteByteArray(Addresses.dunMessage10, MesConvert("God Mode activated.             \n                          \nYou are now invincible to enemy damage.      "));
                                Thread.Sleep(250);
                                Memory.WriteInt(Addresses.dunMessage, 10); //Display the 10th dungeon message
                                Thread.Sleep(3000); //Wait three seconds
                                Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
                                Memory.WriteByteArray(Addresses.dunMessage10, originalDunMessage); //Revert message back to default
                            }           
                        }
                    }
                }

                if (godMode == true)
                {
                    Thread.Sleep(50);
                    if (Player.inDungeonFloor() == false) //We left the dungeon
                        godMode = false; //Disable god mode.

                    if (currentCharacter == 1680945251) //Toan
                    {
                        Memory.WriteUShort(Player.Toan.hp, Memory.ReadUShort(Player.Toan.maxHP)); //Set Toan's HP to match max HP
                    }
                    else if (currentCharacter == 1647587427) //Xiao
                    {
                        Memory.WriteUShort(Player.Xiao.hp, Memory.ReadUShort(Player.Xiao.maxHP)); //Set Xiaos's HP to match max HP
                    }
                }
                #endregion

                if (currentCharacter == 1647587427) //If Xiao
                {
                    Memory.WriteByteArray(textureAddress1, modifiedTexture1);
                    Memory.WriteByteArray(textureAddress2, modifiedTexture2);
                    ///Memory.WriteByteArray(textureAddress3, modifiedTexture3);
                }
                //Memory.WriteInt(Addresses.hideHud, 1);

                Math.Vector3 position = new Math.Vector3();
                Math.Vector3 dunPosition = new Math.Vector3();

                position.x = Memory.ReadFloat(Player.positionX);
                position.y = Memory.ReadFloat(Player.positionY);
                position.z = Memory.ReadFloat(Player.positionZ);

                dunPosition.x = Memory.ReadFloat(Player.dunPositionX);
                dunPosition.y = Memory.ReadFloat(Player.dunPositionY);
                dunPosition.z = Memory.ReadFloat(Player.dunPositionZ);

                Console.WriteLine("Input: " + Memory.ReadUShort(Addresses.buttonInputs));
                
                //if(Player.inDungeonFloor() == false)
                //    Console.WriteLine("Player Position:\t\tX: " + position.x + "\t\tY: " + position.y + "\t\tY: " + position.z);
                //else
                //    Console.WriteLine("Dungeon Player Position:\t\tX: " + dunPosition.x + "\t\tY: " + dunPosition.y + "\t\tY: " + dunPosition.z);

                Thread.Sleep(10); //10ms
                Console.Clear();
            }
            //Console.WriteLine("L1+R1+Select+Start was pressed... broke out of loop.");
            //Form1.dayThread.Abort();
            //stopWatch.Stop();
        }
    }
}
