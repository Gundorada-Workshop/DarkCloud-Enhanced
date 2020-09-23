using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class TownCharacter
    {
        static char[] characters = { ' ', '!', '"', '#', '$', '%', '&', '`', '(', ')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@',
                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '§', ']', '^', '_', '`',
                              'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~' };
        static int currentAddress;
        static byte[] value1 = new byte[1];
        static byte[] value = new byte[2];
        static byte[] value4 = new byte[4];
        static byte checkByte;

        static string cfgFile;
        static string chrFilePath;

        static bool successful;
        static bool charSelected;
        static bool indungeon;
        static bool charaSwitchFunctionsRestored = false;

        static int[] originalFunctions1 = { 201865816, 0, 201653168, 0, 201653040, 0, 604241921, 201865772 };
        static int[] originalFunctions2 = { 604241921, 201865856, 0, 209125176, 0, 604241921, 201840320 };

        public static void InitializeChrOffsets()
        {

            Console.WriteLine("Towncharacter running");

            Memory.VirtualProtect(Memory.processH, Addresses.chrConfigFileOffset, 8, Memory.PAGE_EXECUTE_READWRITE, out _);
            successful = Memory.VirtualProtectEx(Memory.processH, Addresses.chrConfigFileOffset, 8, Memory.PAGE_EXECUTE_READWRITE, out _);
            
            if (successful == false) //There was an error
                Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

            Memory.Write(Addresses.chrConfigFileOffset, BitConverter.GetBytes(608545264)); //this changes the offset value in game's code to make it read the file in right location


            currentAddress = Addresses.chrConfigFileLocation;

            for (int i = 0; i < 15; i++)    //clear the previous values in config file location
            {
                Memory.WriteByte(currentAddress, 0);
                currentAddress += 0x00000001;
            }

            currentAddress = 0x2029AA18;

            for (int i = 0; i < 9; i++)    //clear the previous values in config file location
            {
                Memory.WriteByte(currentAddress, 0);
                currentAddress += 0x00000001;
            }

            cfgFile = "info.cfg";

            currentAddress = Addresses.chrConfigFileLocation;

            for (int i = 0; i < cfgFile.Length; i++)
            {
                char character = cfgFile[i];

                for (int a = 0; a < characters.Length; a++)
                {
                    if (character.Equals(characters[a]))
                    {
                        value1 = BitConverter.GetBytes(a + 32);
                    }
                }

                Memory.WriteByte(currentAddress, value1[0]);

                currentAddress += 0x00000001;

            }



            chrFilePath = "chara/c01d.chr"; //the path to the character file that should be loaded

            currentAddress = Addresses.chrFileLocation;

            for (int i = 0; i < chrFilePath.Length; i++)
            {
                char character = chrFilePath[i];

                for (int a = 0; a < characters.Length; a++)
                {
                    if (character.Equals(characters[a]))
                    {
                        value1 = BitConverter.GetBytes(a + 32);
                    }
                }

                Memory.WriteByte(currentAddress, value1[0]);

                currentAddress += 0x00000001;

            }

            

            

            while (1 == 1)
            {
                //jal editinit = e0 e0 05 0c / 224 224 5 12
                if (Memory.ReadByte(Addresses.mode) == 0x3)
                {
                    indungeon = true;
                }
                else
                {
                    indungeon = false;
                }


                if (indungeon == true && charaSwitchFunctionsRestored == false)     //check if player is on DUNGEON, change/restore ingame functions
                {
                    currentAddress = 0x201F74B4;
                    for (int i = 0; i < originalFunctions1.Length; i++)
                    {
                        Memory.VirtualProtect(Memory.processH, currentAddress, 4, Memory.PAGE_EXECUTE_READWRITE, out _);
                        successful = Memory.VirtualProtectEx(Memory.processH, currentAddress, 4, Memory.PAGE_EXECUTE_READWRITE, out _);

                        if (successful == false) //There was an error
                            Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

                        Memory.WriteInt(currentAddress, originalFunctions1[i]);

                        currentAddress += 0x00000004;
                    }

                    currentAddress = 0x201F7524;
                    for (int i = 0; i < originalFunctions2.Length; i++)
                    {
                        Memory.VirtualProtect(Memory.processH, currentAddress, 4, Memory.PAGE_EXECUTE_READWRITE, out _);
                        successful = Memory.VirtualProtectEx(Memory.processH, currentAddress, 4, Memory.PAGE_EXECUTE_READWRITE, out _);

                        if (successful == false) //There was an error
                            Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

                        Memory.WriteInt(currentAddress, originalFunctions2[i]);

                        currentAddress += 0x00000004;
                    }

                    charaSwitchFunctionsRestored = true;
                }
                else if (indungeon == false && charaSwitchFunctionsRestored == true)        //check if player is on TOWN, change ingame functions
                {

                    Memory.VirtualProtect(Memory.processH, Addresses.assignEditInit, 4, Memory.PAGE_EXECUTE_READWRITE, out _);
                    successful = Memory.VirtualProtectEx(Memory.processH, Addresses.assignEditInit, 4, Memory.PAGE_EXECUTE_READWRITE, out _);

                    if (successful == false) //There was an error
                        Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

                    Memory.Write(Addresses.assignEditInit, BitConverter.GetBytes(201711840));


                    currentAddress = 0x201F74BC;

                    for (int i = 0; i < 24; i++)    //Clear the previous functions when switching chara so the game doesnt crash/freeze
                    {
                        Memory.WriteByte(currentAddress, 0);
                        currentAddress += 0x00000001;
                    }


                    currentAddress = 0x201F7524;    //Clear the previous functions when switching chara so the game doesnt crash/freeze

                    for (int i = 0; i < 28; i++)
                    {
                        Memory.WriteByte(currentAddress, 0);
                        currentAddress += 0x00000001;
                    }




                    charaSwitchFunctionsRestored = false;
                }

                if (Memory.ReadByte(Addresses.mode) == 0x2 && Memory.ReadByte(Addresses.selectedMenu) == 0x3)
                {
                    if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.Cross)
                    {
                        if (charSelected == false)
                        {
                            Console.WriteLine("Chara selected");

                            chrFilePath = "chara/f01a.chr"; //the path to the character file that should be loaded

                            currentAddress = Addresses.chrFileLocation;

                            for (int i = 0; i < chrFilePath.Length; i++)
                            {
                                char character = chrFilePath[i];

                                for (int a = 0; a < characters.Length; a++)
                                {
                                    if (character.Equals(characters[a]))
                                    {
                                        value1 = BitConverter.GetBytes(a + 32);
                                    }
                                }

                                Memory.WriteByte(currentAddress, value1[0]);

                                currentAddress += 0x00000001;

                            }

                            Memory.WriteInt(0x202A2524, -1);

                            //Memory.WriteByte(Addresses.activateCharacter, 4);

                            charSelected = true;
                        }
                    }
                }
            }

        }
    }
}
