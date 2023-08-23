using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    internal class CheatCodes
    {
        public static byte[] attachmentValues = new byte[32];
        internal class InputBuffer
        {
            [Flags]
            public enum Button
            {
                None        = 0b_0000000000000000,
                L2          = 0b_0000000000000001,
                R2          = 0b_0000000000000010,
                L1          = 0b_0000000000000100,
                R1          = 0b_0000000000001000,
                Triangle    = 0b_0000000000010000,
                Circle      = 0b_0000000000100000,
                Cross       = 0b_0000000001000000,
                Square      = 0b_0000000010000000,
                Select      = 0b_0000000100000000,
                L3          = 0b_0000001000000000,
                R3          = 0b_0000010000000000,
                Start       = 0b_0000100000000000,
                DPad_Up     = 0b_0001000000000000,
                DPad_Right  = 0b_0010000000000000,
                DPad_Down   = 0b_0100000000000000,
                DPad_Left   = 0b_1000000000000000,
                All         = 0b_1111111111111111
            }

            public static int index = 0;
            public static bool firstDebugCheatActive = false;
            
            public static ushort previousInputs = 0;
            public static Button[] inputBuffer = new Button[10];
            public readonly Button[] empty = new Button[] {Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None};
            public static Button[] cheatGodmode = new Button[] { Button.DPad_Down, Button.DPad_Up, Button.Square, Button.Circle, Button.Select, Button.DPad_Right, Button.DPad_Left, Button.Circle, Button.Square, Button.R1 };
            
            public static Button[] cheatBrokenDagger = new Button[] { Button.Triangle, Button.L1, Button.R2, Button.Cross, Button.DPad_Left, Button.DPad_Up, Button.L2, Button.Circle, Button.DPad_Right, Button.Select };
            
            public static Button[] cheatPowerupPowders = new Button[] { Button.L2, Button.DPad_Down, Button.Select, Button.Square, Button.Triangle, Button.R2, Button.DPad_Up, Button.DPad_Right, Button.L1, Button.Cross };
            
            public static Button[] cheatMaxMoney = new Button[] { Button.R2, Button.DPad_Left, Button.L3, Button.Cross, Button.DPad_Up, Button.Select, Button.R1, Button.Triangle, Button.Square, Button.DPad_Down };
            
            public static Button[] cheatDebugMenusPart1 = new Button[] { Button.Select, Button.R3, Button.DPad_Down, Button.Triangle, Button.DPad_Up, Button.Cross, Button.Select, Button.L3, Button.R1, Button.L1 };
            
            public static Button[] cheatDebugMenusPart2 = new Button[] { Button.Circle, Button.L1, Button.DPad_Right, Button.DPad_Left, Button.R3, Button.R1, Button.Square, Button.Cross, Button.Select, Button.Cross };
            
            public static Button[] cheatUnlockFloors = new Button[] { Button.R3, Button.Triangle, Button.DPad_Up, Button.Select, Button.L2, Button.R2, Button.DPad_Left, Button.Select, Button.Circle, Button.R1 };

            public static List<Button> inputs = new List<Button>();

            public static Thread debugThread = new Thread(new ThreadStart(DebugOptions));
            internal static void Monitor()
            {
                InitializeBD();
                while (1 == 1)
                {
                    Thread.Sleep(50);
               
                    if (Player.CheckDunIsPaused() == true)
                    {
                        if (Memory.ReadUShort(Addresses.buttonInputs) != 0)
                        { //If button input detected
                            if (Memory.ReadUShort(Addresses.buttonInputs) != previousInputs)
                            {
                                Add((Button)Memory.ReadUShort(Addresses.buttonInputs)); //Add our button to the buffer
                                previousInputs = Memory.ReadUShort(Addresses.buttonInputs);
                            }
                        }

                        if (CheckSequence(cheatGodmode))
                        {
                            if (Memory.ReadByte(Player.Ultraman) == 0)
                            {
                                toggleGodMode(true);
                            }
                            else
                            {
                                toggleGodMode(false);
                            }
                            Memory.WriteByte(0x21CE446C, 1);
                        }

                        if (CheckSequence(cheatBrokenDagger))
                        {
                            SpawnBrokenDagger();
                            Memory.WriteByte(0x21CE446C, 1);
                        }

                        if (CheckSequence(cheatPowerupPowders))
                        {
                            SpawnPowerupPowders();
                            Memory.WriteByte(0x21CE446C, 1);
                        }

                        if (CheckSequence(cheatMaxMoney))
                        {
                            GiveMaxGilda();
                            Memory.WriteByte(0x21CE446C, 1);
                        }

                        if (CheckSequence(cheatDebugMenusPart1))
                        {
                            if (firstDebugCheatActive == false)
                                DebugMenusFirstPart();
                        }

                        if (CheckSequence(cheatDebugMenusPart2))
                        {
                            if (firstDebugCheatActive == true)
                            {
                                UnlockDebugMenus();
                                Memory.WriteByte(0x21CE446C, 1);
                            }
                        }

                        if (CheckSequence(cheatUnlockFloors))
                        {
                            byte currentdungeon = Memory.ReadByte(Addresses.checkDungeon);
                            UnlockFloors(currentdungeon);
                            Memory.WriteByte(0x21CE446C, 1);
                        }
                    }
                    

                    Button softResetList = Button.L1 | Button.L2 | Button.R1 | Button.R2 | Button.Select | Button.Start; //All at once

                    if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)softResetList)  //If L1+L2+R1+R2+Select+Start is pressed, return to main menu
                    {
                        Thread.Sleep(2000); //Wait two seconds
                        if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)softResetList)  //Check again
                        {
                            if (Player.InDungeonFloor() == true)
                                Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                            else
                                Memory.WriteByte(Addresses.townSoftReset, 1);
                        }
                    }
                }
            }

            public static void Add(Button button)
            {
                //inputBuffer[index] = button;                         

                if (inputs.Count == 10)
                {
                    inputs.RemoveAt(0);
                }
                inputs.Add(button);
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Button: " + button + " added to List");


                /*if (index < inputBuffer.Length - 1)
                {
                    index++;
                }

                else
                {
                    index = 0;
                }
                */
            }

            public static bool CheckSequence(Button[] cheatCodeArray)
            {
                Button[] tmp = { };

                
                if (inputs.SequenceEqual(cheatCodeArray)) //Matched sequence
                {
                    inputs.Clear();
                    return true;
                }
                

                return false;
            }

            private static void toggleGodMode(bool toggle)
            {
                if (toggle == true)
                {
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "God mode activated");
                    Dayuppy.DisplayMessage("^BCheater!!\n God Mode activated!^W", 2, 30, 3000);
                    Memory.WriteByte(Player.Ultraman, 2);
                }
                else
                {
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "God mode de-activated");
                    Dayuppy.DisplayMessage("^RCheat de-activated - God Mode^W", 1, 30, 3000);
                    Memory.WriteByte(Player.Ultraman, 0);
                }
            }

            private static void SpawnBrokenDagger()
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Cheat: Broken Dagger");
                Dayuppy.DisplayMessage("^BCheater!!\n Broken Dagger acquired!^W", 2, 30, 3000);
                if (Player.Inventory.GetBagAttachmentsFirstAvailableSlot() != -1) Memory.WriteByteArray(Addresses.firstBagAttachment + (0x20 * Player.Inventory.GetBagAttachmentsFirstAvailableSlot()), attachmentValues);
            }

            private static void SpawnPowerupPowders()
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Cheat: Powerup Powders");
                Dayuppy.DisplayMessage("^BCheater!!\n Acquired 10 Powerup Powders!!^W", 2, 30, 3000);
                for (int i = 0; i < 10; i++)
                {
                    if(Player.Inventory.GetBagItemsFirstAvailableSlot() != -1) Memory.WriteUShort(Addresses.firstBagItem + (0x2 * Player.Inventory.GetBagItemsFirstAvailableSlot()), 178);
                }
            }

            private static void GiveMaxGilda()
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Cheat: Max Gilda");
                Dayuppy.DisplayMessage("^BCheater!!\n Acquired Max Gilda!^W", 2, 30, 3000);
                Memory.WriteUShort(Addresses.gilda, 65535);
            }

            private static void DebugMenusFirstPart()
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Cheat: Debug Menus Part 1");
                Dayuppy.DisplayMessage("^BWhat are you doing?^W", 1, 20, 2500);
                firstDebugCheatActive = true;
            }

            private static void UnlockDebugMenus()
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Cheat: Debug Menus Unlocked");
                Dayuppy.DisplayMessage("^BCheater!!\n Debug Menus Unlocked!\n Have fun and be careful not to crash the game!^W", 3, 50, 5500);

                if (!debugThread.IsAlive)
                    debugThread.Start();
            }

            private static void UnlockFloors(byte currentDng)
            {
                switch (currentDng)
                {
                    case 0:
                        Memory.WriteByte(0x21CDD80B, 14);
                        break;
                    case 1:
                        Memory.WriteByte(0x21CDD80C, 16);
                        break;
                    case 2:
                        Memory.WriteByte(0x21CDD80D, 17);
                        break;
                    case 3:
                        Memory.WriteByte(0x21CDD80E, 17);
                        break;
                    case 4:
                        Memory.WriteByte(0x21CDD80F, 14);
                        break;
                    case 5:
                        Memory.WriteByte(0x21CDD810, 24);
                        break;
                    case 6:
                        Memory.WriteByte(0x21CDD811, 99);
                        break;
                }

                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Cheat: Unlock Floors");
                Dayuppy.DisplayMessage("^BCheater!!\n Unlocked all floors in this dungeon!^W", 2, 40, 3500);
            }

            private static Button[] ShiftElements(Button[] cheatCodeArray, int amount)
            {
                Button[] tmp = new Button [cheatCodeArray.Length];

                for (int i = 0; i < cheatCodeArray.Length; i++)
                {
                    tmp[(i + amount) % tmp.Length] = cheatCodeArray[i];
                }

                return tmp;
            }
        }
        public static void DebugOptions()
        {
            while (true)
            {
                if (Memory.ReadUShort(Addresses.buttonInputs) == 512)
                    Memory.WriteUShort(Addresses.itemDebugMenu, 5);

                if (Memory.ReadUShort(Addresses.buttonInputs) == 1024)
                {
                    Thread.Sleep(500);
                    if (Memory.ReadUShort(Addresses.buttonInputs) == 1024)
                    {
                        if (Memory.ReadByte(Addresses.dungeonDebugMenu) != 220)
                        {
                            Memory.WriteUShort(Addresses.dungeonDebugMenu, 220);
                        }
                    }
                }
                Thread.Sleep(50);
            }         
        }

        public static void InitializeBD() //set custom values for the broken dagger attachment
        {
            attachmentValues[0] = 90;
            attachmentValues[1] = 0;
            attachmentValues[2] = 1;
            attachmentValues[3] = 0;
            attachmentValues[4] = 226;
            attachmentValues[5] = 54;
            attachmentValues[6] = 0;
            attachmentValues[7] = 0;
            attachmentValues[8] = 0;
            attachmentValues[9] = 3;
            attachmentValues[10] = 0;
            attachmentValues[11] = 3;
            attachmentValues[12] = 0;
            attachmentValues[13] = 3;
            attachmentValues[14] = 0;
            attachmentValues[15] = 3;
            attachmentValues[16] = 99;
            attachmentValues[17] = 99;
            attachmentValues[18] = 99;
            attachmentValues[19] = 99;
            attachmentValues[20] = 99;
            attachmentValues[21] = 99;
            attachmentValues[22] = 99;
            attachmentValues[23] = 99;
            attachmentValues[24] = 99;
            attachmentValues[25] = 99;
            attachmentValues[26] = 99;
            attachmentValues[27] = 99;
            attachmentValues[28] = 99;
            attachmentValues[29] = 99;
            attachmentValues[30] = 99;
            attachmentValues[31] = 99;
        }
    }
}
