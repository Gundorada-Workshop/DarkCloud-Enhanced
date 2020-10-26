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
        static string currentCharacter = "chara/c01d.chr";

        static bool successful;
        static bool charSelected;
        static bool indungeon;
        static bool charaSwitchFunctionsRestored = false;
        static bool changingLocation;
        static bool menuExited = true;
        static bool jokerHouse = false;

        static int[] originalFunctions1 = { 201865816, 0, 201653168, 0, 201653040, 0, 604241921, 201865772 };
        static int[] originalFunctions2 = { 604241921, 201865856, 0, 209125176, 0, 604241921, 201840320 };
        static int charNumber;
        static int prevCharNumber = 255;
        static int allyCount;
        static int currentHouseID;
        static int checkCompletion;
        static int partsCollected = 0;
        static int currentArea;

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
            /*
            Memory.VirtualProtect(Memory.processH, 0x201F7DB4, 4, Memory.PAGE_EXECUTE_READWRITE, out _);
            successful = Memory.VirtualProtectEx(Memory.processH, 0x201F7DB4, 4, Memory.PAGE_EXECUTE_READWRITE, out _);

            if (successful == false) //There was an error
                Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

            Memory.Write(0x201F7DB4, BitConverter.GetBytes(201711840));     //whenever X is pressed while on allies menu and in town, this will reload the town instead of playing a single sound
            */




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
                    

                    charaSwitchFunctionsRestored = true;
                }
                else if (indungeon == false && charaSwitchFunctionsRestored == true)        //check if player is on TOWN, change ingame functions
                {

                    charaSwitchFunctionsRestored = false;
                }

                if (Memory.ReadByte(Addresses.mode) == 0x2 && Memory.ReadByte(Addresses.selectedMenu) == 0x3)
                {
                    if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.Cross)
                    {
                        if (charSelected == true)
                        {
                            Console.WriteLine("Chara selected");

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

                    if (Memory.ReadInt(0x202A28F4) == 0)    //set currentCharacter after switching ally
                    {
                        currentCharacter = chrFilePath;
                    }

                    charNumber = Memory.ReadByte(0x21D90470);

                    if (prevCharNumber != charNumber)
                    {
                        allyCount = Memory.ReadByte(0x21CD9551);
                        Console.WriteLine(charNumber);
                        Console.WriteLine("different char");
                        currentAddress = Addresses.chrFileLocation;

                        for (int i = 0; i < 30; i++)
                        {
                            Memory.WriteByte(currentAddress, 0);
                            currentAddress += 0x00000001;
                        }

                        /*
                        Memory.VirtualProtect(Memory.processH, 0x201F7DB4, 4, Memory.PAGE_EXECUTE_READWRITE, out _);
                        successful = Memory.VirtualProtectEx(Memory.processH, 0x201F7DB4, 4, Memory.PAGE_EXECUTE_READWRITE, out _);

                        if (successful == false) //There was an error
                            Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError()));
                            */

                        if (charNumber == 0)
                        {
                            chrFilePath = "chara/c01d.chr";
                        }
                        else if (charNumber == 1)
                        {
                            /*
                            if (allyCount > 1)
                            {
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201711840));
                            }
                            else
                            {
                                Console.WriteLine("not enough allies");
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201896892));
                            }
                            */
                            chrFilePath = "gedit/e01/chara/c04pcat.chr";
                        }
                        else if (charNumber == 2)
                        {
                            /*
                            if (allyCount > 2)
                            {
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201711840));
                            }
                            else
                            {
                                Console.WriteLine("not enough allies");
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201896892));
                            }
                            */
                            chrFilePath = "gedit/s01/chara/c06p.chr";

                        }
                        else if (charNumber == 3)
                        {
                            /*
                            if (allyCount > 3)
                            {
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201711840));
                            }
                            else
                            {
                                Console.WriteLine("not enough allies");
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201896892));
                            }
                            */
                            chrFilePath = "gedit/e03/chara/c05a.chr";
                        }
                        else if (charNumber == 4)
                        {
                            /*
                            if (allyCount > 4)
                            {
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201711840));
                            }
                            else
                            {
                                Console.WriteLine("not enough allies");
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201896892));
                            }*/

                            chrFilePath = "gedit/s79/chara/c10a.chr";
                        }
                        else if (charNumber == 5)
                        {
                            /*
                            if (allyCount > 5)
                            {
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201711840));
                            }
                            else
                            {
                                Console.WriteLine("not enough allies");
                                Memory.Write(0x201F7DB4, BitConverter.GetBytes(201896892));
                            }*/
                            chrFilePath = "gedit/e05/chara/c18p.chr";
                        }
                        else
                        {
                            chrFilePath = "chara/c01d.chr";
                        }

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

                            /*Memory.VirtualProtect(Memory.processH, currentAddress, 8, Memory.PAGE_EXECUTE_READWRITE, out _);
                            successful = Memory.VirtualProtectEx(Memory.processH, currentAddress, 8, Memory.PAGE_EXECUTE_READWRITE, out _);

                            if (successful == false) //There was an error
                                Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError()));
                                */

                            Memory.WriteByte(currentAddress, value1[0]);


                            currentAddress += 0x00000001;

                        }

                        
                        prevCharNumber = charNumber;
                        menuExited = false;
                    }
                }
                else if (menuExited == false && Memory.ReadByte(0x202A1E90) == 255)   //if player exits allies menu without switching character, write the current character back
                {
                    chrFilePath = currentCharacter;
                    Console.WriteLine("hello");

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
                    menuExited = true;
                    prevCharNumber = 99;
                }

                if (Memory.ReadByte(0x21D33E28) == 9)   //cancel landing animation to avoid being stuck
                {
                    Memory.WriteByte(0x21D33E30, 3);
                }

                if (Memory.ReadInt(0x2029AA0E) != 1680945251)   //If not using Toan, force any house event to be cancelled
                {
                    currentHouseID = Memory.ReadByte(0x202A2820);

                    if (currentHouseID != 255)  //check if its actual georama house
                    {
                        checkCompletion = 0xE8 * currentHouseID + 0x21D19C58;

                        if (Memory.ReadByte(checkCompletion) == 0)  //checks if house has been completed when opening the door
                        {
                            int parts = 4;
                            checkCompletion = 0xE8 * currentHouseID + 0x21D19C80;

                            if (Memory.ReadByte(0x202A2518) == 0) //check if claude's house
                            {
                                if (currentHouseID == 4)
                                {
                                    parts = 5;
                                }
                            }
                            else if (Memory.ReadByte(0x202A2518) == 1) //check if cacaos house
                            {
                                if (currentHouseID == 1)
                                {
                                    parts = 5;
                                }
                            }                           


                            for (int i = 0; i < parts; i++)
                            {
                                partsCollected += Memory.ReadByte(checkCompletion);
                                checkCompletion += 0x20;
                            }

                            if ((parts == 4 && partsCollected == 4) || (parts == 5 && partsCollected == 5))
                            {
                                Memory.WriteByte(0x202A282C, 0);
                            }
                            else
                            {
                                Memory.WriteByte(0x202A282C, 128);
                            }
                            partsCollected = 0;
                        }
                        else
                        {
                            Memory.WriteByte(0x202A282C, 128);
                        }

                        if (Memory.ReadByte(0x202A2518) == 2)
                        {
                            if (Memory.ReadByte(0x21D196A4) == 4)
                            {
                                if (Memory.ReadByte(0x21D19FF8) != 1)
                                {
                                    if (Memory.ReadByte(0x21D19710) == 1 && jokerHouse == false) //check if at joker's house door
                                    {
                                        Console.WriteLine("entered jokerssss");
                                        Memory.WriteByte(0x202A2A08, 0);
                                        jokerHouse = true;
                                    }
                                    else if (Memory.ReadByte(0x21D19710) == 0 && jokerHouse == true)
                                    {
                                        Console.WriteLine("left jokerss");
                                        Memory.WriteByte(0x202A2A08, 1);
                                        jokerHouse = false;
                                    }
                                }
                            }
                        }
                
                    }
                    else
                    {
                        Memory.WriteByte(0x202A282C, 128);
                    }

                    if (Memory.ReadByte(0x202A2518) == 23)
                    {
                        Memory.WriteByte(0x21D2849C, 0); //despawn trade quest bunny
                    }
                    currentArea = Memory.ReadByte(0x202A2518);
                    if (currentArea == 11 || currentArea == 13 || currentArea == 19 || currentArea == 33 || currentArea == 35 || currentArea == 37 || currentArea == 14)
                    {
                        Memory.WriteByte(0x21F10000, 1); //disable eventpoints/triggers, pnach does rest
                    }
                    else
                    {
                        Memory.WriteByte(0x21F10000, 0);
                    }

                    if (Memory.ReadByte(0x21CDD80D) != 255)
                    {
                        Memory.WriteByte(0x21F10004, 1); //enable yaya
                    }
                }
                else
                {
                    Memory.WriteByte(0x21F10000, 0); //re-enable eventpoints if they were disable
                }

                if (Memory.ReadByte(0x202A1E90) != 255 && changingLocation == false)  //if changing location, swap back to Toan
                {
                    changingLocation = true;
                    Console.WriteLine("changing location");
                    chrFilePath = "chara/c01d.chr";
                    Memory.WriteByte(0x21F10000, 0); //re-enable eventpoints in case they were disabled

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
                }

                if (Memory.ReadByte(0x202A1E90) == 255)
                {
                    changingLocation = false;
                }

            }

        }
    }
}
