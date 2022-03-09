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

        static char[] gameCharacters = { '^', '@', '_', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§',
                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                              'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                              '´', '=', '"', '!', '?', '#', '&', '+', '-', '*', '/', '%', '(', ')', '@', '|', '<', '>', '{', '}', '[', ']', ':', ',', '.', '$',
                              '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static int currentAddress;
        static byte[] value1 = new byte[1];
        static byte[] value = new byte[2];
        static byte[] value4 = new byte[4];
        static byte checkByte;
        static byte[] townDialogueIDs = { 247, 167, 87, 27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, 240, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 101, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static byte[] fishArray = new byte[6];
        

        static string cfgFile;
        static string chrFilePath;
        static string currentCharacter = "chara/c01d.chr";

        static bool isUsingAlly = false;
        static bool successful;
        static bool charSelected;
        static bool indungeon;
        static bool charaSwitchFunctionsRestored = false;
        static bool changingLocation;
        static bool menuExited = true;
        static bool jokerHouse = false;
        static bool dialogueWritten = false;
        static bool nearNPC = false;
        static bool nearNPCSD = false;
        static bool checkBuildingFlag = false;
        static bool areaChanged = false;
        static bool sidequestOptionFlag = false;
        static bool isSideQuestDialogueActive = false;
        static bool fishingActive = false;
        public static bool queensQuest = false;
        static bool[] fishCaught = new bool[6];
        static bool currentlyInShop = false;
        static bool shopDataCleared = false;
        static bool fishingQuestCheck = false;
        public static bool mintTalk = false;
        public static byte mayorReward;

        static float fishSizeFloat = 0;

        public static bool talkableNPC = true;
        public static bool shopkeeper = false;
        public static bool fishingQuestPikeActive = false;
        public static bool fishingQuestPaoActive = false;
        public static bool fishingQuestSamActive = false;
        public static bool fishingQuestDeviaActive = false;
        public static bool hasMardanSword = false;
        public static byte mardanMultiplier;
        
        public static int onDialogueFlag = 0;
        public static int sidequestonDialogueFlag = 0;
        public static int itsfinishedonDialogueFlag = 0;
        static int[] originalFunctions1 = { 201865816, 0, 201653168, 0, 201653040, 0, 604241921, 201865772 };
        static int[] originalFunctions2 = { 604241921, 201865856, 0, 209125176, 0, 604241921, 201840320 };
        static int charNumber;
        static int prevCharNumber = 255;
        static int allyCount;
        static int currentHouseID;
        static int checkCompletion;
        static int partsCollected = 0;
        static int currentArea;
        static int buildingCheck;
        static int minFishSize = 0;
        static int maxFishSize = 0;
        static int fishSizeInt = 0;
        static int fishSizeAddress = 0;
        public static int characterIDData;
        public static int sidequestDialogueID = 0;
        public static int itsfinishedDialogueID = 0;
        
        //used bool checks in addresses: 21F10000,21F10004,21F10008 (check if player is next to NPC), 21F1000C, 21F100010 (toan next to pickle in brownboo), 21F100014, 21F10018 (element check), 21F1001C (clock check), 21F10020 (PNACH flag)

        public static void InitializeChrOffsets()
        {

            Console.WriteLine("Towncharacter running");

            Dialogues.InitializeDialogues();
            Memory.WriteByte(0x2027DD50, 0); //make shell ring discardable
            Memory.WriteByte(0x2027DD28, 0); //make magical lamp discardable
            Memory.WriteByte(0x2027DC80, 8); //change map ordering
            Memory.WriteByte(0x2027DC94, 8); //change magical crystal ordering
            Memory.WriteByte(0x20291CEE, 1); //make hardening powder cost 1g
            Memory.WriteByte(0x2027D808, 0); //make escape powder equippable+stackable
            Memory.WriteByte(0x2027D7F8, 2); //make escape powder have arrow point to active slots
            Memory.WriteByte(0x2027D81C, 0); //make revival powder stackable
            Memory.WriteByte(0x2027D830, 0); //make repair powder equipable+stackable
            Memory.WriteByte(0x2027D8A8, 0); //make auto-repair powder stackable
            Memory.WriteUShort(0x20292A3E, 2000); //make matador fishing cost to 2k
            Memory.WriteByte(0x21CB6AEC, 50); //fix matador model in chest loot
            Memory.WriteByte(0x21CB6AF7, 50); //
            Memory.WriteByte(0x21CB6B02, 51); //
            Memory.WriteByte(0x21CB6B0D, 51); //


            if (Memory.ReadByte(0x21CE446B) != 0) //max hps for mayor quest
            {
                Memory.WriteByte(0x20293978, 250);
                Memory.WriteByte(0x2029397A, 250);
                Memory.WriteByte(0x2029397C, 250);
                Memory.WriteByte(0x2029397E, 250);
                Memory.WriteByte(0x20293980, 250);
                Memory.WriteByte(0x20293982, 250);
            }

            DungeonThread.ChangeSoZMaxAtt(Memory.ReadUShort(0x21CE446D)); //NEEDS TO BE APPLIED AFTER SAVE LOAD!

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




            while (true)
            {
                if (Memory.ReadByte(Addresses.mode) == 2)
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
                        Console.WriteLine("re-writing current character back...");

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

                    if (Memory.ReadByte(0x21D33E28) == 9 && fishingActive == false)   //cancel landing animation to avoid being stuck
                    {
                        Memory.WriteByte(0x21D33E30, 3);
                    }


                    if (Memory.ReadInt(0x2029AA0E) != 1680945251)   //If not using Toan, force any house event to be cancelled
                    {
                        isUsingAlly = true;
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
                            if (Memory.ReadByte(0x21D28474) == 8)
                            {
                                Memory.WriteByte(0x21D2849C, 0); //despawn trade quest bunny
                            }
                            else
                            {
                                Memory.WriteByte(0x21D2849C, 1);
                            }
                        }
                        currentArea = Memory.ReadByte(0x202A2518);
                        if (currentArea == 11 || currentArea == 13 || currentArea == 13 || currentArea == 33 || currentArea == 35 || currentArea == 37 || currentArea == 14)
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

                        if (Memory.ReadByte(0x21F10014) == 1)
                        {
                            Memory.WriteByte(0x20415508, 0); //disable mayor door event
                            Memory.WriteByte(0x20415538, 0); //disable mayor door event mark
                        }

                        int checkNearNPC = 0;

                        for (int i = 0; i < 6; i++)     //check if player is next to a character. If so, jumps to SetDialogue() and writes the dialogues
                        {
                            currentAddress = i * 0x14A0 + 0x21D26FF8;
                            if (Memory.ReadByte(currentAddress) == 1)
                            {
                                if (nearNPC == false || onDialogueFlag == 1)
                                {
                                    Dialogues.SetDialogue(i, true, false);
                                    if (talkableNPC != false) //check if NPC is not llama
                                    {
                                        Memory.WriteByte(0x21F10008, 1); //nearNPC flag for PNACH to use
                                    }
                                    talkableNPC = true;
                                    nearNPC = true;
                                    if (onDialogueFlag == 1) onDialogueFlag = 2;    //if player was already on a dialogue, the next one was written ready
                                }
                                checkNearNPC++;
                            }
                        }
                        if (checkNearNPC == 0)
                        {
                            nearNPC = false;
                            Memory.WriteByte(0x21F10008, 0); //nearNPC flag for PNACH to use
                            onDialogueFlag = 0;
                        }

                        if (Memory.ReadByte(0x21D1CC0C) == townDialogueIDs[currentArea] && onDialogueFlag == 0) //check if current dialogue is our custom dialogue, set a flag
                        {
                            onDialogueFlag = 1;
                            Dialogues.ChangeDialogue(); //when we detect that player activates a dialogue, change the flag
                        }
                        else if (Memory.ReadByte(0x21D1CC0C) == townDialogueIDs[currentArea] && onDialogueFlag == 3) //check if current dialogue is our custom dialogue, set a flag
                        {
                            onDialogueFlag = 0;
                        }

                        if (onDialogueFlag == 2)
                        {
                            if (Memory.ReadByte(0x21D1CC0C) == 255) //check if previous custom dialogue has ended
                            {
                                onDialogueFlag = 3;
                            }
                        }

                        if (Memory.ReadInt(0x2029AA18) == 1882468451)   //if using Xiao, change talk camera
                        {
                            if (currentArea == 0)
                            {
                                Memory.WriteByte(0x202A2A6C, 0);
                                Memory.WriteByte(0x202A2A6E, 9);
                            }
                            else if (currentArea == 1)
                            {
                                Memory.WriteUShort(0x202A2A6C, 2544);
                                Memory.WriteByte(0x202A2A6E, 9);
                            }
                            else if (currentArea == 2)
                            {
                                Memory.WriteUShort(0x202A2A6C, 2306);
                                Memory.WriteByte(0x202A2A6E, 9);
                            }
                            Memory.WriteByte(0x21F1000C, 1); //xiaoFlag for PNACH
                        }
                        else
                        {
                            Memory.WriteByte(0x21F1000C, 0); //xiaoFlag for PNACH
                        }

                        if (shopkeeper == true)     //check shopkeeper and change dialogue ID
                        {
                            if (currentArea != 23)
                            {
                                Memory.WriteUShort(0x21D3D438, townDialogueIDs[currentArea]);
                                Memory.WriteInt(0x21D3D440, itsfinishedDialogueID); //its finished dialogue ID setup
                                SetItsFinishedDialogue();
                            }
                            else
                            {
                                if (sidequestOptionFlag == false && Memory.ReadByte(0x21D1CC0C) == 12)
                                {
                                    sidequestOptionFlag = true;
                                }
                                else if (sidequestOptionFlag == true && Memory.ReadByte(0x21D1CC0C) == 255)
                                {
                                    sidequestOptionFlag = false;
                                }

                                if (sidequestOptionFlag == true)
                                {
                                    Memory.WriteInt(0x21D3D43C, sidequestDialogueID); //THIS IS USED FOR POSSIBLE 4TH DIALOGUE OPTION (sidequests)
                                    SetSideQuestDialogue();

                                    if (Memory.ReadUShort(0x21D1CC0C) == sidequestDialogueID && isSideQuestDialogueActive == false)
                                    {
                                        CheckSideQuestDialogue();
                                        isSideQuestDialogueActive = true;
                                    }
                                    else if (Memory.ReadUShort(0x21D1CC0C) != sidequestDialogueID)
                                    {
                                        isSideQuestDialogueActive = false;
                                    }
                                }
                                else
                                {
                                    sidequestonDialogueFlag = 0;
                                    itsfinishedonDialogueFlag = 0;
                                }
                            }
                        }
                        else
                        {
                            if (currentArea != 38)
                            {
                                Memory.WriteUShort(0x21D3D434, townDialogueIDs[currentArea]);
                            }
                            if (sidequestOptionFlag == false && Memory.ReadByte(0x21D1CC0C) == 11)
                            {
                                sidequestOptionFlag = true;
                            }
                            else if (sidequestOptionFlag == true && Memory.ReadByte(0x21D1CC0C) == 255)
                            {
                                sidequestOptionFlag = false;
                            }

                            if (sidequestOptionFlag == true)
                            {
                                if (Memory.ReadByte(0x21F10014) == 1)
                                {
                                    Memory.WriteInt(0x21D3D438, sidequestDialogueID);
                                }
                                else
                                {
                                    Memory.WriteInt(0x21D3D440, sidequestDialogueID); //THIS IS USED FOR POSSIBLE 4TH DIALOGUE OPTION (sidequests)
                                    Memory.WriteInt(0x21D3D43C, itsfinishedDialogueID); //its finished dialogue ID setup
                                }
                                SetSideQuestDialogue();
                                SetItsFinishedDialogue();

                                if (Memory.ReadUShort(0x21D1CC0C) == sidequestDialogueID && isSideQuestDialogueActive == false)
                                {
                                    CheckSideQuestDialogue();
                                    isSideQuestDialogueActive = true;
                                }
                                else if (Memory.ReadUShort(0x21D1CC0C) != sidequestDialogueID)
                                {
                                    isSideQuestDialogueActive = false;
                                }
                            }
                            else
                            {
                                sidequestonDialogueFlag = 0;
                                itsfinishedonDialogueFlag = 0;
                            }
                        }

                    }
                    else
                    {
                        isUsingAlly = false;
                        Memory.WriteByte(0x21F10000, 0); //re-enable eventpoints if they were disable
                        Memory.WriteByte(0x21F1000C, 0); //xiaoFlag for PNACH

                        //if (Memory.ReadByte(0x21D1CC0C) == 12)

                        currentArea = Memory.ReadByte(0x202A2518);
                        if (currentArea == 0 || currentArea == 1 || currentArea == 2 || currentArea == 3)
                        {
                            if (sidequestOptionFlag == false && Memory.ReadByte(0x21D1CC0C) == 11)
                            {
                                sidequestOptionFlag = true;
                            }
                            else if (sidequestOptionFlag == true && Memory.ReadByte(0x21D1CC0C) == 255)
                            {
                                sidequestOptionFlag = false;
                            }
                            if (sidequestOptionFlag == true)
                            {
                                if (Memory.ReadByte(0x21F10014) == 1)
                                {
                                    Memory.WriteInt(0x21D3D438, sidequestDialogueID);
                                }
                                else
                                {
                                    Memory.WriteInt(0x21D3D440, sidequestDialogueID); //THIS IS USED FOR POSSIBLE 4TH DIALOGUE OPTION (sidequests)
                                }
                                SetSideQuestDialogue();

                                if (Memory.ReadUShort(0x21D1CC0C) == sidequestDialogueID && isSideQuestDialogueActive == false)
                                {
                                    CheckSideQuestDialogue();
                                    isSideQuestDialogueActive = true;
                                }
                                else if (Memory.ReadUShort(0x21D1CC0C) != sidequestDialogueID)
                                {
                                    isSideQuestDialogueActive = false;
                                }
                            }
                            else
                            {
                                sidequestonDialogueFlag = 0;
                            }
                        }
                        else if (currentArea == 23)
                        {
                            if (sidequestOptionFlag == false && Memory.ReadByte(0x21D1CC0C) == 12)
                            {
                                sidequestOptionFlag = true;
                            }
                            else if (sidequestOptionFlag == true && Memory.ReadByte(0x21D1CC0C) == 255)
                            {
                                sidequestOptionFlag = false;
                            }

                            if (sidequestOptionFlag == true)
                            {
                                Memory.WriteInt(0x21D3D43C, sidequestDialogueID); //THIS IS USED FOR POSSIBLE 4TH DIALOGUE OPTION (sidequests)
                                SetSideQuestDialogue();

                                if (Memory.ReadUShort(0x21D1CC0C) == sidequestDialogueID && isSideQuestDialogueActive == false)
                                {
                                    CheckSideQuestDialogue();
                                    isSideQuestDialogueActive = true;
                                }
                                else if (Memory.ReadUShort(0x21D1CC0C) != sidequestDialogueID)
                                {
                                    isSideQuestDialogueActive = false;
                                }
                            }
                            else
                            {
                                sidequestonDialogueFlag = 0;
                            }
                        }
                        else if (currentArea == 14)
                        {
                            int checkNearNPC = 0;
                            for (int i = 0; i < 6; i++)     //check if player is next to a character. If so, jumps to SetDialogue() and writes the dialogues
                            {
                                currentAddress = i * 0x14A0 + 0x21D26FF8;
                                if (Memory.ReadByte(currentAddress) == 1)
                                {
                                    if (nearNPC == false || onDialogueFlag == 1)
                                    {

                                        Dialogues.SetDialogue(i, false, false);
                                        Memory.WriteByte(0x21F10010, 1); //nearNPC flag for PNACH to use
                                        nearNPC = true;
                                        if (onDialogueFlag == 1) onDialogueFlag = 2;
                                    }
                                    checkNearNPC++;
                                    currentAddress = currentAddress - 0x00000024;
                                    if (Memory.ReadByte(currentAddress) == 5)
                                    {
                                        mintTalk = true;
                                    }
                                    else
                                    {
                                        mintTalk = false;
                                    }
                                }
                            }

                            if (checkNearNPC == 0)
                            {
                                nearNPC = false;
                                Memory.WriteByte(0x21F10010, 0); //nearNPC flag for PNACH to use
                                onDialogueFlag = 0;
                            }

                            if (Memory.ReadByte(0x21D1CC0C) == 200 && onDialogueFlag == 0) //check if current dialogue is our custom dialogue, set a flag
                            {
                                onDialogueFlag = 1;
                                if (mintTalk)
                                {
                                    if (Memory.ReadByte(0x21CE444F) == 1)
                                    {
                                        if (Dialogues.alreadyHasSavingBook == false)
                                        {
                                            Dialogues.GiveMasterFishQuestReward();
                                        }
                                    }
                                }
                            }

                            if (onDialogueFlag == 2)
                            {
                                if (Memory.ReadByte(0x21D1CC0C) == 255) //check if previous custom dialogue has ended
                                {
                                    onDialogueFlag = 0;
                                }
                            }
                        }
                    }

                    buildingCheck = Memory.ReadByte(0x202A281C); //is player inside house

                    int currentAreaFrames = Memory.ReadInt(0x202A2880);

                    if (currentAreaFrames < 25)
                    {
                        if (currentAreaFrames > 5)
                        {
                            CheckClockAdvancement(currentArea);
                        }
                    }

                    if (currentAreaFrames < 50) //check player duration in new area (to check if its a new/changed area)
                    {
                        if (currentAreaFrames > 30 && areaChanged == false)
                        {
                            areaChanged = true;
                            CheckAllyFishing();
                            if (currentArea == 42) Dialogues.SetDefaultDialogue(42);
                            else if (currentArea == 14) Dialogues.SetDefaultDialogue(14);

                            if (currentArea == 23)
                            {
                                if (Dialogues.storageOriginalDialogue != null)
                                {
                                    if (Dialogues.storageOriginalDialogue.Length > 0)
                                    {
                                        Array.Clear(Dialogues.storageOriginalDialogue, 0, Dialogues.storageOriginalDialogue.Length);
                                        Console.WriteLine("Cleared storage original dialogue");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        areaChanged = false;
                    }

                    if ((buildingCheck == 0 && checkBuildingFlag == true) || areaChanged == true) //check if player is not inside a house
                    {
                        Console.WriteLine("Currently in outside area");
                        Dialogues.SetDialogueOptions(currentArea, false);
                        Dialogues.SetStorageDialogue(currentArea, false);
                        checkBuildingFlag = false;
                        CheckAllyFishing();

                    }
                    else if (buildingCheck == 1 && checkBuildingFlag == false)
                    {
                        if (currentArea != 23)
                        {
                            Console.WriteLine("Currently inside building");
                            Dialogues.SetDialogueOptions(currentArea, true);
                            Dialogues.SetStorageDialogue(currentArea, true);
                            checkBuildingFlag = true;
                        }
                        else
                        {
                            if (Memory.ReadByte(0x21D26FD4) == 0 || Memory.ReadByte(0x21D26FD4) == 1)
                            {
                                Console.WriteLine("Currently inside building");
                                Dialogues.SetDialogueOptions(currentArea, true);
                                Dialogues.SetStorageDialogue(currentArea, true);
                                checkBuildingFlag = true;
                            }
                        }
                    }

                    if (Memory.ReadByte(0x202A1E90) != 255 && changingLocation == false)  //if changing location, swap back to Toan
                    {
                        changingLocation = true;
                        Console.WriteLine("changing location");
                        chrFilePath = "chara/c01d.chr";
                        Memory.WriteByte(0x21F10000, 0); //re-enable eventpoints in case they were disabled'



                        currentAddress = Addresses.chrFileLocation;

                        for (int i = 0; i < 30; i++)
                        {
                            Memory.WriteByte(currentAddress, 0);
                            currentAddress += 0x00000001;
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


                            Memory.WriteByte(currentAddress, value1[0]);


                            currentAddress += 0x00000001;

                        }

                        Thread.Sleep(350);
                        if (Memory.ReadByte(0x21D2DA4C) < 61)
                        {
                            int timerCheck = 0;
                            while (Memory.ReadByte(0x21D2DA4C) < 58 && timerCheck <= 25)
                            {
                                Thread.Sleep(50);
                                timerCheck++;
                            }
                        }
                        Memory.WriteByte(0x21F1001C, 0);
                    }

                    if (Memory.ReadByte(0x202A1E90) == 255)
                    {
                        changingLocation = false;
                    }

                    int checkFishing = Memory.ReadByte(0x21D19714);
                    if (fishingActive == false & checkFishing == 1)
                    {
                        fishingActive = true;
                        fishingQuestPikeActive = false;
                        fishingQuestPaoActive = false;
                        fishingQuestSamActive = false;
                        fishingQuestDeviaActive = false;
                        fishingQuestCheck = false;
                        CheckMardanSword();
                    }

                    if (fishingActive == true)
                    {
                        CheckFishingQuest(currentArea);
                        if (checkFishing == 0)
                        {
                            fishingActive = false;
                        }
                    }

                    if (!currentlyInShop)
                    {
                        if (Memory.ReadByte(0x21DA52E4) == 1 && Memory.ReadByte(0x21DA52E8) == 11)
                        {
                            currentlyInShop = true;
                            shopDataCleared = false;
                            Console.WriteLine("Entered a shop");
                        }
                    }

                    if (currentlyInShop)
                    {
                        if (!shopDataCleared)
                        {
                            Console.WriteLine("Fixing broken dagger glitch...");
                            FixBrokenDagger();
                            shopDataCleared = true;
                        }

                        if (Memory.ReadByte(0x21DA52E4) != 1)
                        {
                            currentlyInShop = false;
                            Console.WriteLine("Exited a shop");
                        }
                    }

                    DungeonThread.CheckWepLvlUp();

                    /*
                    if (dialogueWritten == false)
                    {
                        currentAddress = 0x21D3D434; //Dialogue ID for the first chat option

                        for (int s = 0; s < 4; s++)
                        {
                            Memory.WriteByte(currentAddress, 46);
                            currentAddress += 0x4;
                        }

                        string circletext = "I´ll have two number 9s, a number 9 large,^a number 6 with extra dip,^a number 7, two number 45s,^one with cheese, and a large soda.";

                        currentAddress = 0x206498A0;

                        for (int i = 0; i < circletext.Length; i++)
                        {
                            char character = circletext[i];

                            for (int a = 0; a < gameCharacters.Length; a++)
                            {
                                if (character.Equals(gameCharacters[a]))
                                {
                                    value1 = BitConverter.GetBytes(a);
                                }
                            }


                            Memory.WriteByte(currentAddress, value1[0]);

                            currentAddress += 0x00000001;

                            if (value1[0] == 0 || value1[0] == 2)
                            {
                                value1 = BitConverter.GetBytes(255);
                                Memory.WriteByte(currentAddress, value1[0]);
                            }
                            else
                            {
                                value1 = BitConverter.GetBytes(253);
                                Memory.WriteByte(currentAddress, value1[0]);
                            }

                            currentAddress += 0x00000001;
                        }

                        Memory.WriteByte(currentAddress, 1);
                        currentAddress += 0x00000001;
                        Memory.WriteByte(currentAddress, 255);
                        dialogueWritten = true;
                    }
                    */
                }
                
                if (Memory.ReadByte(Addresses.mode) == 0 || Memory.ReadByte(Addresses.mode) == 1)
                {
                    Console.WriteLine("Not ingame anymore! Exited from Towncharacter!");
                    break;
                }

                Thread.Sleep(50);
            }

        }

        public static void FixBrokenDagger()
        {
            currentAddress = 0x21839528;
            byte[] arrayy = new byte[18000];

            Memory.WriteByteArray(currentAddress, arrayy);

            /*for (int i = 0; i < 4500; i++)
            {
                Memory.WriteInt(currentAddress, 0);
                currentAddress += 0x00000004;
            }
            */
            Console.WriteLine("Broken dagger fix finished");
        }


        public static void SetSideQuestDialogue()
        {
            int checkNearNPC = 0;
            for (int i = 0; i < 6; i++)     //check if player is next to a character. If so, jumps to SetDialogue() and writes the dialogues
            {
                currentAddress = i * 0x14A0 + 0x21D26FF8;
                if (Memory.ReadByte(currentAddress) == 1)
                {
                    if (sidequestonDialogueFlag == 0)
                    {

                        Dialogues.SetDialogue(i, false, true);
                        Memory.WriteByte(0x21F10010, 1); //nearNPC flag for PNACH to use
                        nearNPCSD = true;
                        Console.WriteLine("sidequestdialogue set");
                        sidequestonDialogueFlag = 1;
                    }
                    checkNearNPC++;
                }
            }

            /*if (checkNearNPC == 0)
            {
                nearNPCSD = false;
                Memory.WriteByte(0x21F10010, 0); //nearNPC flag for PNACH to use
                sidequestonDialogueFlag = 0;
            } 

            if (Memory.ReadUShort(0x21D1CC0C) == sidequestDialogueID && sidequestonDialogueFlag == 0) //check if current dialogue is our custom dialogue, set a flag
            {
                sidequestonDialogueFlag = 1;
            }

            if (sidequestonDialogueFlag == 2)
            {
                if (Memory.ReadByte(0x21D1CC0C) == 255) //check if previous custom dialogue has ended
                {
                    sidequestonDialogueFlag = 0;
                }
            }
            */
        }

        public static void SetItsFinishedDialogue()
        {
            int checkNearNPC = 0;
            for (int i = 0; i < 6; i++)     //check if player is next to a character. If so, jumps to SetDialogue() and writes the dialogues
            {
                currentAddress = i * 0x14A0 + 0x21D26FF8;
                if (Memory.ReadByte(currentAddress) == 1)
                {
                    if (itsfinishedonDialogueFlag == 0)
                    {

                        Dialogues.SetDialogue(i, false, false, true);
                        Memory.WriteByte(0x21F10010, 1); //nearNPC flag for PNACH to use
                        nearNPCSD = true;
                        Console.WriteLine("itsfinished dialogue set");
                        itsfinishedonDialogueFlag = 1;
                    }
                    checkNearNPC++;
                }
            }
        }

        public static void CheckAllyFishing()
        {
            if (isUsingAlly)
            {
                if (currentArea == 0)
                {
                    Memory.WriteOneByte(0x2041BF4E, BitConverter.GetBytes(1)); //disable fishing
                    Dialogues.SetFishingDisabledDialogue(currentArea);               
                }
                else if (currentArea == 1)
                {
                    Memory.WriteOneByte(0x2041AABA, BitConverter.GetBytes(1)); //disable fishing
                    Dialogues.SetFishingDisabledDialogue(currentArea);
                }
                else if (currentArea == 19)
                {
                    Memory.WriteOneByte(0x2041495E, BitConverter.GetBytes(1)); //disable fishing
                    Dialogues.SetFishingDisabledDialogue(currentArea);
                    Memory.WriteByte(0x20420B6C, 0); //disable submarine
                    Memory.WriteByte(0x20420B7C, 0); //disable submarine
                }
                else if (currentArea == 3)
                {
                    Memory.WriteOneByte(0x20421A8A, BitConverter.GetBytes(1)); //disable fishing
                    Dialogues.SetFishingDisabledDialogue(currentArea);
                }
                
            }
        }

        public static void CheckSideQuestDialogue()
        {
            sidequestOptionFlag = false;
            
            if (characterIDData == 12592) //macho sidequest
            {
                if (Memory.ReadByte(0x21CE4402) == 0)
                {
                    Memory.WriteOneByte(0x21CE4402, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE4402) == 1)
                {
                    //Memory.WriteOneByte(0x21CE4402, BitConverter.GetBytes(2));
                }

                else if (Memory.ReadByte(0x21CE4402) == 2)
                {
                    SideQuestManager.MonsterQuestReward();
                    Memory.WriteOneByte(0x21CE4402, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 13618) //gob sidequest
            {
                if (Memory.ReadByte(0x21CE4407) == 0)
                {
                    Memory.WriteOneByte(0x21CE4407, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE4407) == 1)
                {
                    //Memory.WriteOneByte(0x21CE4402, BitConverter.GetBytes(2));
                }

                else if (Memory.ReadByte(0x21CE4407) == 2)
                {
                    SideQuestManager.MonsterQuestReward();
                    Memory.WriteOneByte(0x21CE4407, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 13108) //jake sidequest
            {
                if (Memory.ReadByte(0x21CE440C) == 0)
                {
                    Memory.WriteOneByte(0x21CE440C, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE440C) == 1)
                {
                    //Memory.WriteOneByte(0x21CE4402, BitConverter.GetBytes(2));
                }

                else if (Memory.ReadByte(0x21CE440C) == 2)
                {
                    SideQuestManager.MonsterQuestReward();
                    Memory.WriteOneByte(0x21CE440C, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 14388) //chiefbonka sidequest
            {
                if (Memory.ReadByte(0x21CE4411) == 0)
                {
                    Memory.WriteOneByte(0x21CE4411, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE4411) == 1)
                {
                    //Memory.WriteOneByte(0x21CE4402, BitConverter.GetBytes(2));
                }

                else if (Memory.ReadByte(0x21CE4411) == 2)
                {
                    SideQuestManager.MonsterQuestReward();
                    Memory.WriteOneByte(0x21CE4411, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 13872) //pike
            {
                if (Memory.ReadByte(0x21CE4416) == 0)
                {
                    Memory.WriteOneByte(0x21CE4416, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE4416) == 1)
                {
                    //Memory.WriteOneByte(0x21CE4416, BitConverter.GetBytes(2));
                }
                else if (Memory.ReadByte(0x21CE4416) == 2)
                {
                    SideQuestManager.GetFishingQuestReward();
                    Memory.WriteOneByte(0x21CE4416, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 13362) //pao
            {
                if (Memory.ReadByte(0x21CE441E) == 0)
                {
                    Memory.WriteOneByte(0x21CE441E, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE441E) == 1)
                {
                    //Memory.WriteOneByte(0x21CE441E, BitConverter.GetBytes(2));
                }
                else if (Memory.ReadByte(0x21CE441E) == 2)
                {
                    SideQuestManager.GetFishingQuestReward();
                    Memory.WriteOneByte(0x21CE441E, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 13363) //sam
            {
                if (Memory.ReadByte(0x21CE4427) == 0)
                {
                    Memory.WriteOneByte(0x21CE4427, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE4427) == 1)
                {
                    //Memory.WriteOneByte(0x21CE441E, BitConverter.GetBytes(2));
                }
                else if (Memory.ReadByte(0x21CE4427) == 2)
                {
                    SideQuestManager.GetFishingQuestReward();
                    if (queensQuest)
                    {
                        Memory.WriteByte(0x21CE4430, 1);
                    }
                    Memory.WriteOneByte(0x21CE4427, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 13109)
            {
                if (Memory.ReadByte(0x21CE4431) == 0)
                {
                    Memory.WriteOneByte(0x21CE4431, BitConverter.GetBytes(1));
                }
                else if (Memory.ReadByte(0x21CE4431) == 1)
                {
                    //Memory.WriteOneByte(0x21CE441E, BitConverter.GetBytes(2));
                }
                else if (Memory.ReadByte(0x21CE4431) == 2)
                {
                    SideQuestManager.GetFishingQuestReward();
                    Memory.WriteOneByte(0x21CE4431, BitConverter.GetBytes(0));
                }
            }
            else if (characterIDData == 13360) //laura
            {
                if (Memory.ReadByte(0x21CE4451) == 0)
                {
                    Memory.WriteByte(0x21CE4451, 1);
                }
            }
            else if (characterIDData == 12594) //ro
            {
                if (Memory.ReadByte(0x21CE4452) == 0)
                {
                    Memory.WriteByte(0x21CE4452, 1);
                }
            }
            else if (characterIDData == 12852) //phil
            {
                if (Memory.ReadByte(0x21CE4453) == 0)
                {
                    Memory.WriteByte(0x21CE4453, 1);
                }
            }
            else if (characterIDData == 12341) //zabo
            {
                if (Memory.ReadByte(0x21CE4454) == 0)
                {
                    Memory.WriteByte(0x21CE4454, 1);
                }
            }
            else if (characterIDData == 13361) //mayor
            {
                if (Memory.ReadByte(0x21CE4464) == 0)
                {
                    if (Memory.ReadByte(0x21CE4463) == 1)
                        Memory.WriteByte(0x21CE4464, 1);
                }
                else if (Memory.ReadByte(0x21CE4464) == 1)
                {
                    Memory.WriteByte(0x21CE4464, 2);
                }
                else if (Memory.ReadByte(0x21CE4464) == 2)
                {
                    if (Memory.ReadByte(0x21CE4468) == 0)
                    {
                        Memory.WriteByte(0x21CE4468, 1);
                    }
                    else if (Memory.ReadByte(0x21CE4468) == 2)
                    {
                        Memory.WriteUShort(Addresses.firstBagItem + (0x2 * Player.Inventory.GetBagItemsFirstAvailableSlot()), mayorReward);
                        Memory.WriteByte(0x21CE4468, 0);
                        if (Memory.ReadByte(0x21CE446B) == 1)
                        {
                            Memory.WriteByte(0x21CE4464, 3);
                        }
                    }
                }
            }

            if (currentArea == 23)
            {
                if (Memory.ReadByte(0x21D26FD4) == 0)
                {
                    if (Memory.ReadByte(0x21CE445D) == 1)
                    {
                        Memory.WriteByte(0x21CE445D, 2);
                        Memory.WriteByte(0x21CE4459, 2);
                        Memory.WriteUShort(Addresses.firstBagItem + (0x2 * Player.Inventory.GetBagItemsFirstAvailableSlot()), 234);
                    }                 
                }
                if (Memory.ReadByte(0x21D26FD4) == 1)
                {
                    if (Memory.ReadByte(0x21CE4462) == 1)
                    {
                        Memory.WriteByte(0x21CE445E, 2);
                        Memory.WriteByte(0x21CE4462, 2);
                        Memory.WriteUShort(Addresses.firstBagItem + (0x2 * Player.Inventory.GetBagItemsFirstAvailableSlot()), 233);
                    }
                }
            }
        }

        public static void CheckClockAdvancement(int area)
        {
            if (area == 23 || area == 40 || area == 38)
            {
                float currentClock = Memory.ReadFloat(0x21CD4310);

                Memory.WriteByte(0x21F1001C, 1);
                Thread.Sleep(10);

                Memory.WriteByte(0x203A3920, 0); //enable clock
                Memory.WriteFloat(0x202A28F4, currentClock);

                Console.WriteLine("Enabled clock");
            }
        }

        public static void CheckFishingQuest(int area)
        {
            if (area == 0)
            {
                if (!fishingQuestCheck)
                {
                    currentAddress = 0x214798D0;
                    for (int i = 0; i < 4; i++)
                    {
                        fishArray[i] = Memory.ReadByte(currentAddress);
                        currentAddress += 0x00002410;
                        Console.WriteLine("fish " + i + " ID: " + fishArray[i]);
                        fishCaught[i] = false;
                    }

                    if (Memory.ReadByte(0x21CE4416) == 1)
                    {
                        fishingQuestPikeActive = true;
                        Console.WriteLine("Currently on Pikes quest");

                        minFishSize = Memory.ReadByte(0x21CE441B);
                        maxFishSize = Memory.ReadByte(0x21CE441C);
                    }
                    if (hasMardanSword)
                    {
                        Thread.Sleep(300);
                        currentAddress = 0x214798E0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (fishArray[i] != 5)
                            {
                                if (fishArray[i] != 17)
                                {
                                    int FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x00000004;
                                    FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x0000240C;
                                    Console.WriteLine("Mardan multiplied FP's");
                                }
                                else
                                {
                                    currentAddress += 0x00002410;
                                }
                            }
                            else
                            {
                                currentAddress += 0x00002410;
                            }
                        }
                    }
                    fishingQuestCheck = true;
                }
                else
                {
                    currentAddress = 0x214798D0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (Memory.ReadByte(currentAddress) == 255 && fishCaught[i] == false && Memory.ReadByte(0x202A26E8) == 12)
                        {
                            fishCaught[i] = true;
                            Console.WriteLine("Fish caught -> ID: " + fishArray[i]);
                            FishAcquiredFlag(fishArray[i]);

                            if (fishingQuestPikeActive)
                            {
                                if (Memory.ReadByte(0x21CE4417) == 0) //check if fishing quest one
                                {
                                    if (fishArray[i] == Memory.ReadByte(0x21CE4419)) //check if caught fish matches quest fish ID
                                    {
                                        Console.WriteLine("Quest progress +1!");

                                        byte fishleft = Memory.ReadByte(0x21CE441A);
                                        fishleft--;
                                        Memory.WriteByte(0x21CE441A, fishleft);

                                        if (fishleft == 0)
                                        {
                                            Console.WriteLine("Quest complete!!");
                                            Memory.WriteByte(0x21CE4416, 2);
                                            fishingQuestPikeActive = false;
                                        }
                                    }
                                }
                                else //fishing quest two
                                {
                                    fishSizeAddress = currentAddress + 0x00000060;
                                    fishSizeFloat = Memory.ReadFloat(fishSizeAddress);
                                    fishSizeFloat = fishSizeFloat * 10;
                                    fishSizeFloat = (float)System.Math.Floor(fishSizeFloat);
                                    fishSizeInt = Convert.ToInt32(fishSizeFloat);

                                    if (minFishSize <= fishSizeInt && maxFishSize >= fishSizeInt)
                                    {
                                        Console.WriteLine("Quest complete!!");
                                        Memory.WriteByte(0x21CE4416, 2);
                                        fishingQuestPikeActive = false;
                                    }
                                }
                            }                        
                        }

                        currentAddress += 0x00002410;
                    }
                }
            }
            else if (area == 1)
            {
                if (!fishingQuestCheck)
                {
                    currentAddress = 0x214D9910;
                    for (int i = 0; i < 5; i++)
                    {
                        fishArray[i] = Memory.ReadByte(currentAddress);
                        currentAddress += 0x00002410;
                        Console.WriteLine("fish " + i + " ID: " + fishArray[i]);
                        fishCaught[i] = false;
                    }

                    if (Memory.ReadByte(0x21CE441E) == 1)
                    {
                        fishingQuestPaoActive = true;
                        Console.WriteLine("Currently on Paos quest");

                        minFishSize = Memory.ReadByte(0x21CE4423);
                        maxFishSize = Memory.ReadByte(0x21CE4424);                    
                    }
                    if (hasMardanSword)
                    {
                        Thread.Sleep(300);
                        currentAddress = 0x214D9920;
                        for (int i = 0; i < 5; i++)
                        {
                            if (fishArray[i] != 5)
                            {
                                if (fishArray[i] != 17)
                                {
                                    int FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x00000004;
                                    FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x0000240C;
                                    Console.WriteLine("Mardan multiplied FP's");
                                }
                                else
                                {
                                    currentAddress += 0x00002410;
                                }
                            }
                            else
                            {
                                currentAddress += 0x00002410;
                            }
                        }
                    }
                    fishingQuestCheck = true;
                }
                else
                {
                    currentAddress = 0x214D9910;
                    for (int i = 0; i < 5; i++)
                    {
                        if (Memory.ReadByte(currentAddress) == 255 && fishCaught[i] == false && Memory.ReadByte(0x202A26E8) == 12)
                        {
                            fishCaught[i] = true;
                            Console.WriteLine("Fish caught -> ID: " + fishArray[i]);
                            FishAcquiredFlag(fishArray[i]);

                            if (fishingQuestPaoActive)
                            {
                                if (Memory.ReadByte(0x21CE441F) == 0)
                                {
                                    if (fishArray[i] == Memory.ReadByte(0x21CE4421))
                                    {
                                        Console.WriteLine("Quest progress +1!");

                                        byte fishleft = Memory.ReadByte(0x21CE4422);
                                        fishleft--;
                                        Memory.WriteByte(0x21CE4422, fishleft);

                                        if (fishleft == 0)
                                        {
                                            Console.WriteLine("Quest complete!!");
                                            Memory.WriteByte(0x21CE441E, 2);
                                            fishingQuestPaoActive = false;
                                        }
                                    }
                                }
                                else
                                {
                                    fishSizeAddress = currentAddress + 0x00000060;
                                    fishSizeFloat = Memory.ReadFloat(fishSizeAddress);
                                    fishSizeFloat = fishSizeFloat * 10;
                                    fishSizeFloat = (float)System.Math.Floor(fishSizeFloat);
                                    fishSizeInt = Convert.ToInt32(fishSizeFloat);

                                    if (minFishSize <= fishSizeInt && maxFishSize >= fishSizeInt)
                                    {
                                        Console.WriteLine("Quest complete!!");
                                        Memory.WriteByte(0x21CE441E, 2);
                                        fishingQuestPaoActive = false;
                                    }
                                }
                            }
                        }

                        currentAddress += 0x00002410;
                    }
                }
            }
            else if (area == 19)
            {
                if (!fishingQuestCheck)
                {
                    currentAddress = 0x20DE0710;
                    for (int i = 0; i < 5; i++)
                    {
                        fishArray[i] = Memory.ReadByte(currentAddress);
                        currentAddress += 0x00002410;
                        Console.WriteLine("fish " + i + " ID: " + fishArray[i]);
                        fishCaught[i] = false;
                    }

                    if (Memory.ReadByte(0x21CE4427) == 1)
                    {
                        fishingQuestSamActive = true;
                        Console.WriteLine("Currently on Sams quest");

                        minFishSize = Memory.ReadByte(0x21CE442C);
                        maxFishSize = Memory.ReadByte(0x21CE442D);                      
                    }
                    if (hasMardanSword)
                    {
                        Thread.Sleep(300);
                        currentAddress = 0x20DE0720;
                        for (int i = 0; i < 5; i++)
                        {
                            if (fishArray[i] != 5)
                            {
                                if (fishArray[i] != 17)
                                {
                                    int FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x00000004;
                                    FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x0000240C;
                                    Console.WriteLine("Mardan multiplied FP's");
                                }
                                else
                                {
                                    currentAddress += 0x00002410;
                                }
                            }
                            else
                            {
                                currentAddress += 0x00002410;
                            }
                        }
                    }
                    fishingQuestCheck = true;
                }
                else
                {
                    currentAddress = 0x20DE0710;
                    for (int i = 0; i < 5; i++)
                    {
                        if (Memory.ReadByte(currentAddress) == 255 && fishCaught[i] == false && Memory.ReadByte(0x202A26E8) == 12)
                        {
                            fishCaught[i] = true;
                            Console.WriteLine("Fish caught -> ID: " + fishArray[i]);
                            FishAcquiredFlag(fishArray[i]);

                            if (fishingQuestSamActive)
                            {
                                if (Memory.ReadByte(0x21CE4428) == 0) //check if fishing quest one
                                {
                                    if (fishArray[i] == Memory.ReadByte(0x21CE442A)) //check if caught fish matches quest fish ID
                                    {
                                        Console.WriteLine("Quest progress +1!");

                                        byte fishleft = Memory.ReadByte(0x21CE442B);
                                        fishleft--;
                                        Memory.WriteByte(0x21CE442B, fishleft);

                                        if (fishleft == 0)
                                        {
                                            Console.WriteLine("Quest complete!!");
                                            Memory.WriteByte(0x21CE4427, 2);
                                            fishingQuestSamActive = false;
                                            byte questsDone = Memory.ReadByte(0x21CE442F);
                                            if (questsDone < 4)
                                            {
                                                questsDone++;
                                                Memory.WriteByte(0x21CE442F, questsDone);
                                            }
                                        }
                                    }
                                }
                                else //fishing quest two
                                {
                                    fishSizeAddress = currentAddress + 0x00000060;
                                    fishSizeFloat = Memory.ReadFloat(fishSizeAddress);
                                    fishSizeFloat = fishSizeFloat * 10;
                                    fishSizeFloat = (float)System.Math.Floor(fishSizeFloat);
                                    fishSizeInt = Convert.ToInt32(fishSizeFloat);

                                    if (minFishSize <= fishSizeInt && maxFishSize >= fishSizeInt)
                                    {
                                        Console.WriteLine("Quest complete!!");
                                        Memory.WriteByte(0x21CE4427, 2);
                                        fishingQuestSamActive = false;
                                        byte questsDone = Memory.ReadByte(0x21CE442F);
                                        if (questsDone < 4)
                                        {
                                            questsDone++;
                                            Memory.WriteByte(0x21CE442F, questsDone);
                                        }
                                    }
                                }
                            }
                        }

                        currentAddress += 0x00002410;
                    }
                }

                if (Memory.ReadByte(0x21CE4430) == 1)
                {
                    Memory.WriteByte(0x202A1FA0, 1);
                }
            }
            else if (area == 3)
            {
                if (!fishingQuestCheck)
                {
                    currentAddress = 0x213C3150;
                    for (int i = 0; i < 4; i++)
                    {
                        fishArray[i] = Memory.ReadByte(currentAddress);
                        currentAddress += 0x00002410;
                        Console.WriteLine("fish " + i + " ID: " + fishArray[i]);
                        fishCaught[i] = false;
                    }

                    if (Memory.ReadByte(0x21CE4431) == 1)
                    {
                        fishingQuestDeviaActive = true;
                        Console.WriteLine("Currently on Devias quest");

                        minFishSize = Memory.ReadByte(0x21CE4436);
                        maxFishSize = Memory.ReadByte(0x21CE4437);                      
                    }
                    if (hasMardanSword)
                    {
                        Thread.Sleep(300);
                        currentAddress = 0x213C3160;
                        for (int i = 0; i < 4; i++)
                        {
                            if (fishArray[i] != 5)
                            {
                                if (fishArray[i] != 17)
                                {
                                    int FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x00000004;
                                    FPavg = Memory.ReadInt(currentAddress);
                                    FPavg = FPavg * mardanMultiplier;
                                    Memory.WriteInt(currentAddress, FPavg);
                                    currentAddress += 0x0000240C;
                                    Console.WriteLine("Mardan multiplied FP's");
                                }
                                else
                                {
                                    currentAddress += 0x00002410;
                                }
                            }
                            else
                            {
                                currentAddress += 0x00002410;
                            }
                        }
                    }
                    fishingQuestCheck = true;
                }
                else
                {
                    currentAddress = 0x213C3150;

                    for (int i = 0; i < 4; i++)
                    {
                        if (Memory.ReadByte(currentAddress) == 255 && fishCaught[i] == false && Memory.ReadByte(0x202A26E8) == 12)
                        {
                            fishCaught[i] = true;
                            Console.WriteLine("Fish caught -> ID: " + fishArray[i]);
                            FishAcquiredFlag(fishArray[i]);

                            if (fishingQuestDeviaActive)
                            {
                                if (Memory.ReadByte(0x21CE4432) == 0) //check if fishing quest one
                                {
                                    if (fishArray[i] == Memory.ReadByte(0x21CE4434)) //check if caught fish matches quest fish ID
                                    {
                                        Console.WriteLine("Quest progress +1!");

                                        byte fishleft = Memory.ReadByte(0x21CE4435);
                                        fishleft--;
                                        Memory.WriteByte(0x21CE4435, fishleft);

                                        if (fishleft == 0)
                                        {
                                            Console.WriteLine("Quest complete!!");
                                            Memory.WriteByte(0x21CE4431, 2);
                                            fishingQuestDeviaActive = false;
                                        }
                                    }
                                }
                                else //fishing quest two
                                {
                                    fishSizeAddress = currentAddress + 0x00000060;
                                    fishSizeFloat = Memory.ReadFloat(fishSizeAddress);
                                    fishSizeFloat = fishSizeFloat * 10;
                                    fishSizeFloat = (float)System.Math.Floor(fishSizeFloat);
                                    fishSizeInt = Convert.ToInt32(fishSizeFloat);

                                    if (minFishSize <= fishSizeInt && maxFishSize >= fishSizeInt)
                                    {
                                        Console.WriteLine("Quest complete!!");
                                        Memory.WriteByte(0x21CE4431, 2);
                                        fishingQuestDeviaActive = false;
                                    }
                                }
                            }
                        }

                        currentAddress += 0x00002410;
                    }
                }
            }
        }

        public static void FishAcquiredFlag(byte caughtfishID)
        {
            int fishflag = 0x21CE4439;
            for (int f = 0; f < caughtfishID; f++)
            {
                fishflag += 0x00000001;
            }
            Memory.WriteByte(fishflag, 1);
        }

        public static void CheckMardanSword()
        {
            int slot = Player.Toan.GetWeaponSlot();
            int currentwepID = Memory.ReadUShort(0x21CDDA58 + (slot * 0xF8));

            if (currentwepID == 278)
            {
                hasMardanSword = true;
                mardanMultiplier = 2;
                Console.WriteLine("Player has Mardan Eins");
            }
            else if (currentwepID == 279)
            {
                hasMardanSword = true;
                mardanMultiplier = 3;
                Console.WriteLine("Player has Mardan Twei");
            }
            else if (currentwepID == 280)
            {
                hasMardanSword = true;
                mardanMultiplier = 5;
                Console.WriteLine("Player has Arise Mardan");
            }
            else
            {
                hasMardanSword = false;
            }
        }

        public static void InitializeCharacterOffsetValues()
        {
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
        }
    }
}
