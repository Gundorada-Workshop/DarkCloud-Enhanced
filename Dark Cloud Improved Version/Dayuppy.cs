using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace Dark_Cloud_Improved_Version
{
    class Dayuppy
    {
        private static Thread cheatCodeThread = new Thread(new ThreadStart(CheatCodes.InputBuffer.Monitor)); //Create a new thread to run monitorElementSwapping()
        private static Thread elementSwapThread = new Thread(new ThreadStart(ElementSwapping)); //Create a new thread to run monitorElementSwapping()
        private static Thread dayEnemyThread = new Thread(new ThreadStart(EnemyDropRandomizer)); //Create a new thread to run monitorElementSwapping()
        private static Thread dayChestThread = new Thread(new ThreadStart(DayChestRandomizer)); //Create a new thread to run monitorElementSwapping()
        public static Thread messageThread;
        //public static Thread messageThreadTimer;

        static byte[] dungeonMessage;
        //private static byte[] originalDunMessage = Memory.ReadByteArray(Addresses.dunMessage10, 210); //Read 210 bytes of byte array that stores dungeon message 10

        private static byte[] ItemTbl0 = Memory.ReadByteArray(Addresses.ItemTbl0, 252);         //DBC 1-7
        private static byte[] ItemTbl0_1 = Memory.ReadByteArray(Addresses.ItemTbl0_1, 252);     //DBC 9,10,12,13,14
        private static byte[] ItemTbl0_2 = Memory.ReadByteArray(Addresses.ItemTbl0_2, 304);     //DBC 11

        private static byte[] ItemTbl1 = Memory.ReadByteArray(Addresses.ItemTbl1, 308);         //Wise Owl 1-8
        private static byte[] ItemTbl1_1 = Memory.ReadByteArray(Addresses.ItemTbl1_1, 308);     //Wise Owl 10-16

        private static byte[] ItemTbl2 = Memory.ReadByteArray(Addresses.ItemTbl2, 304);         //Shipwreck 1-8
        private static byte[] ItemTbl2_1 = Memory.ReadByteArray(Addresses.ItemTbl2_1, 308);     //Shipwreck 10-17
            
        private static byte[] ItemTbl3 = Memory.ReadByteArray(Addresses.ItemTbl3, 316);         //Sun and Moon 1-8
        private static byte[] ItemTbl3_1 = Memory.ReadByteArray(Addresses.ItemTbl3_1, 336);     //Unknown
        private static byte[] ItemTbl3_2 = Memory.ReadByteArray(Addresses.ItemTbl3_2, 336);     //Unknown
        private static byte[] ItemTbl3_3 = Memory.ReadByteArray(Addresses.ItemTbl3_3, 336);     //Unknown

        private static byte[] ItemTbl4 = Memory.ReadByteArray(Addresses.ItemTbl4, 368);         //Moon Sea 1-7
        private static byte[] ItemTbl4_1 = Memory.ReadByteArray(Addresses.ItemTbl4_1, 384);     //Moon Sea 9-14

        private static byte[] ItemTbl5 = Memory.ReadByteArray(Addresses.ItemTbl5, 380);         //Gallery of Time 1-24
        private static byte[] ItemTbl5_1 = Memory.ReadByteArray(Addresses.ItemTbl5_1, 380);     //Gallery of Time 1-24 (Same)

        private static byte[] ItemTbl6 = Memory.ReadByteArray(Addresses.ItemTbl6, 376);         //DemonShaft Unknown
        private static byte[] ItemTbl6_1 = Memory.ReadByteArray(Addresses.ItemTbl6_1, 376);     //DemonShaft Unknown

        private static byte[] ItemTbl7 = Memory.ReadByteArray(Addresses.ItemTbl7, 212);         //DBC Backfloors 1-14
        private static byte[] ItemTbl7_1 = Memory.ReadByteArray(Addresses.ItemTbl7_1, 212);     //WiseOwl Backfloors 1-16

        private static byte[] ItemTbl8 = Memory.ReadByteArray(Addresses.ItemTbl8, 212);         //Shipwreck Backfloors 1-17
        private static byte[] ItemTbl8_1 = Memory.ReadByteArray(Addresses.ItemTbl8_1, 212);     //Sun and Moon Backfloors 1-17

        private static byte[] ItemTbl9 = Memory.ReadByteArray(Addresses.ItemTbl9, 212);         //Moon Sea 1-14
        private static byte[] ItemTbl9_1 = Memory.ReadByteArray(Addresses.ItemTbl9_1, 212);     //Unknown Backfloor

        private static byte[] ItemTbl10 = Memory.ReadByteArray(Addresses.ItemTbl10, 212);       //Unknown Backfloor
        private static byte[] ItemTbl10_1 = Memory.ReadByteArray(Addresses.ItemTbl10_1, 212);   //Unknown Backfloor

        private static byte[] ItemTbl11 = Memory.ReadByteArray(Addresses.ItemTbl11, 212);       //Unknown Backfloor
        private static byte[] ItemTbl11_1 = Memory.ReadByteArray(Addresses.ItemTbl11_1, 212);   //Unknown Backfloor

        private static byte[] ItemTbl12 = Memory.ReadByteArray(Addresses.ItemTbl12, 392);       //GOT Backflloor
        private static byte[] ItemTbl12_1 = Memory.ReadByteArray(Addresses.ItemTbl12_1, 392);   //Unknown Backfloor

        private static byte[] ItemTbl13 = Memory.ReadByteArray(Addresses.ItemTbl13, 296);       //Unknown Backfloor
        private static byte[] ItemTbl13_1 = Memory.ReadByteArray(Addresses.ItemTbl13_1, 296);   //Unknown Backfloor

        private static byte[] ItemTblPtr = Memory.ReadByteArray(Addresses.ItemTblPtr, 55);      //Unknown Pointer? Not a table.
        private static byte[] ItemTblUnk = Memory.ReadByteArray(Addresses.ItemTblUnk, 84);      //Unknown

        private static Random random = new Random();
        public static bool elemChanged = false;
        public static bool elemUp = false;
        public static bool elemDown = false;
        public static bool elemSwitching = false;
        public static byte[] elemTextureFire = new byte[53552];
        public static byte[] elemTextureIce = new byte[61008];
        public static byte[] elemTextureThunder = new byte[73280];
        public static byte[] elemTextureWind = new byte[73344];
        public static byte[] elemTextureHoly = new byte[80784];
        public static byte[] elemRGBFire = { 63, 15, 0, 63, 6, 1, 0, 63, 63, 15, 0, 31, 6, 1, 0, 31};
        public static byte[] elemRGBIce = { 25, 50, 63, 63, 2, 5, 6, 63, 25, 50, 63, 31, 2, 5, 6, 31};
        public static byte[] elemRGBThunder = { 63, 63, 25, 63, 6, 6, 2, 63, 63, 63, 25, 31, 6, 6, 2, 31};
        public static byte[] elemRGBWind = { 34, 63, 47, 63, 3, 6, 4, 63, 34, 63, 47, 31, 3, 6, 4, 31};
        public static byte[] elemRGBHoly = { 56, 37, 43, 63, 5, 3, 4, 63, 56, 37, 43, 31, 5, 3, 4, 31};
        public static byte[] elemRGBNone = { 64, 64, 64, 63, 6, 6, 6, 63, 64, 64, 64, 31, 6, 6, 6, 31};
        public static byte[][] elemRGBs = new byte[6][];

        private static int GetRandomLoot(int[] lootTable)
        {
            int randomItem = random.Next(lootTable.Length);

            if (Items.ItemRateTbl[lootTable[randomItem]] == 0) //Make sure we don't divide by zero
                return GetRandomLoot(lootTable); //If 0, re-roll

            int dropRate = 100 / Items.ItemRateTbl[lootTable[randomItem]];

            int roll2 = random.Next(dropRate); //Re-roll based on the drop rate of the item

            if (roll2 == dropRate - 1) //Random will never reach the max value, so decrement by one
                return lootTable[randomItem]; 

            else
                return GetRandomLoot(lootTable); //Re-run the function
        }

        private static int[] FilterLootTable(byte[] lootTable)
        {
            int[] filteredLootTable = new int[lootTable.Length / 4]; //Create a new table to store the ints only

            int t = 0;
            for (int i = 0; i < filteredLootTable.Length; i++)
            {
                filteredLootTable[i] = BitConverter.ToInt32(lootTable, t); //Parse the byte arrays and store the int values
                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Items.ItemNameTbl[filteredLootTable[i]]);
                t += 4;
            }

            return filteredLootTable;
        }

        public static void EnemyDropRandomizer()
        {
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Day's test monster drop randomizer is running...");
            int randomItem = 0;

            int currentAddress;
            int currentDungeon = 0;
            int currentFloor = 0;
            int prevFloor = 0;

            byte[] itemTable = ItemTbl0;
            byte[] backfloorItemTable = ItemTbl0_1;

            while (1 == 1)
            {
                Thread.Sleep(1000);
                if (Player.InDungeonFloor() == true)
                {
                    currentFloor = Memory.ReadByte(Addresses.checkFloor);
                    currentDungeon = Memory.ReadByte(Addresses.checkDungeon);

                    switch (currentDungeon)
                    {
                        case 0: //Divine Beast Cave

                            if (currentFloor <= 8)
                                itemTable = ItemTbl0;

                            else if (currentFloor == 9 || currentFloor == 10 || currentFloor == 12 || currentFloor == 13 || currentFloor == 14) //9 - 10 + 12-14
                                itemTable = ItemTbl0_1;

                            else if (currentFloor == 11)
                                itemTable = ItemTbl0_2;

                            backfloorItemTable = ItemTbl7;

                            break;

                        case 1: //Wise Owl

                            if (currentFloor <= 8)
                                itemTable = ItemTbl1;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl1_1;

                            backfloorItemTable = ItemTbl7_1;

                            break;

                        case 2: //Ship Wreck

                            if (currentFloor <= 8)
                                itemTable = ItemTbl2;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl2_1;

                            backfloorItemTable = ItemTbl8;

                            break;

                        case 3: //Sun and Moon Temple

                            if (currentFloor <= 8)
                                itemTable = ItemTbl3;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl3_1; //Maybe

                            backfloorItemTable = ItemTbl8_1;

                            break;

                        case 4: //Moon Sea

                            if (currentFloor <= 8)
                                itemTable = ItemTbl4;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl4_1;

                            backfloorItemTable = ItemTbl9;

                            break;

                        case 5: //Gallery of Time

                            itemTable = ItemTbl5;

                            backfloorItemTable = ItemTbl12;

                            break;

                        case 6: //Demon Shaft

                            itemTable = ItemTbl6;

                            backfloorItemTable = ItemTbl12_1;

                            break;
                    }

                    if (currentFloor != prevFloor)
                    {
                        Thread.Sleep(2000);

                        randomItem = GetRandomLoot(FilterLootTable(itemTable));

                        Memory.Write(Enemies.Enemy0.drop, BitConverter.GetBytes(randomItem));

                        currentAddress = Enemies.Enemy0.drop;

                        for (int i = 0; i < 16; i++)
                        {
                            int checkItemID = Memory.ReadShort(currentAddress);

                            if (checkItemID != 0xFFFF)
                            {
                                randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                while (randomItem < 81) //If not a valid item, re-roll
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                currentAddress += 0x190;

                                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Gave monster " + i + " item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
                            }
                            else
                                currentAddress += 0x190;
                        }
                        prevFloor = currentFloor;   //once everything is done, we initialize this so it wont reroll again in same floor
                    }
                }
                else
                    prevFloor = 200;    //used to reset the floor data when going back to dungeon
            }
        }

        public static void DayChestRandomizer()
        {
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Day's test chest randomizer is running...");
            int randomItem = 0;

            int currentAddress, checkItemID, firstChestItem, chestSize;
            int currentDungeon = 0;
            int currentFloor = 0;
            int prevFloor = 0;

            byte[] itemTable = ItemTbl0;
            byte[] backfloorItemTable = ItemTbl0_1;

            while (1 == 1)
            {
                Thread.Sleep(750);
                if (Player.InDungeonFloor() == true)
                {
                    currentFloor = Memory.ReadByte(Addresses.checkFloor);
                    currentDungeon = Memory.ReadByte(Addresses.checkDungeon);

                    switch (currentDungeon)
                    {
                        case 0: //Divine Beast Cave

                            if (currentFloor <= 8)
                                itemTable = ItemTbl0;

                            else if (currentFloor == 9 || currentFloor == 10 || currentFloor == 12 || currentFloor == 13 || currentFloor == 14) //9 - 10 + 12-14
                                itemTable = ItemTbl0_1;

                            else if (currentFloor == 11)
                                itemTable = ItemTbl0_2;

                            backfloorItemTable = ItemTbl7;

                            break;

                        case 1: //Wise Owl

                            if (currentFloor <= 8)
                                itemTable = ItemTbl1;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl1_1;

                            backfloorItemTable = ItemTbl7_1;

                            break;

                        case 2: //Ship Wreck

                            if (currentFloor <= 8)
                                itemTable = ItemTbl2;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl2_1;

                            backfloorItemTable = ItemTbl8;

                            break;

                        case 3: //Sun and Moon Temple

                            if (currentFloor <= 8)
                                itemTable = ItemTbl3;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl3_1; //Maybe

                            backfloorItemTable = ItemTbl8_1;

                            break;

                        case 4: //Moon Sea

                            if (currentFloor <= 8)
                                itemTable = ItemTbl4;

                            else if (currentFloor >= 9)
                                itemTable = ItemTbl4_1;

                            backfloorItemTable = ItemTbl9;

                            break;

                        case 5: //Gallery of Time

                            itemTable = ItemTbl5;

                            backfloorItemTable = ItemTbl12;

                            break;

                        case 6: //Demon Shaft

                            itemTable = ItemTbl6;

                            backfloorItemTable = ItemTbl12_1;

                            break;
                    }  

                    if (currentFloor != prevFloor)  //checking if player has entered a new floor
                    {
                        Thread.Sleep(2000); //2 seconds, waiting for game to roll chests first before we change them

                        firstChestItem = Memory.ReadByte(Addresses.firstChest); ;

                        if (firstChestItem == 233)  //We check if first chest has the dungeon map. This is because if the floor has a locked door, the game would always place the key on first chest. Doing this check avoids player getting softlocked without the door key.
                        {
                            chestSize = random.Next(8);       //This is the chance for regular chest to be a big chest

                            if (chestSize != 0)     //if roll is not 0, give normal item
                            {
                                Memory.WriteByte(Addresses.firstChestSize, 1);

                                randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                while (randomItem < 81 || randomItem > 257) //If outside of the range of valid items, re-roll
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                Memory.Write(Addresses.firstChest, BitConverter.GetBytes(randomItem));
                            }
                            else    //if rolled for weapon
                            {
                                Memory.WriteByte(Addresses.firstChestSize, 0);

                                randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                int attempts = 0; //Add this in case we don't have any weapons in the table to even pick from so we don't loop forever
                                while (randomItem < 257 && attempts != 10) //If item is not a weapon, re-roll
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));
                                    attempts++;
                                }

                                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);

                                Memory.Write(Addresses.firstChest, BitConverter.GetBytes(randomItem));
                            }
                        }

                        currentAddress = Addresses.firstChest + 0x00000040;     //using the offset to reach 2nd chest

                        for (int i = 0; i < 7; i++)     //going through rest of chests using offsets
                        {
                            checkItemID = Memory.ReadShort(currentAddress);

                            if (checkItemID > 40 && checkItemID != 233 && checkItemID != 234)
                            {
                                chestSize = random.Next(8);

                                if (chestSize != 0)     //if roll is not 0, give normal item
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                    while (randomItem < 81 || randomItem > 257)
                                        randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                    Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 1);
                                    currentAddress += 0x00000038;

                                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
                                }
                                else    //if rolled for weapon
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                    int attempts = 0; //Add this in case we don't have any weapons in the table to even pick from so we don't loop forever
                                    while (randomItem < 257 && attempts != 10)
                                    {
                                        randomItem = GetRandomLoot(FilterLootTable(itemTable));
                                        attempts++;
                                    }

                                    Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 0);
                                    currentAddress += 0x00000038;

                                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
                                }
                            }
                            else
                                currentAddress += 0x00000040;
                        }

                        currentAddress = Addresses.backfloorFirstChest;

                        for (int i = 0; i < 7; i++)
                        {
                            checkItemID = Memory.ReadShort(currentAddress);

                            if (checkItemID > 40)
                            {
                                chestSize = random.Next(25);
                                
                                if (chestSize != 0)
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(backfloorItemTable));

                                    while (randomItem < 81 || randomItem > 257)
                                        randomItem = GetRandomLoot(FilterLootTable(backfloorItemTable));

                                    Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 1);
                                    currentAddress += 0x00000038;

                                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned backfloor item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
                                }
                                else
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(backfloorItemTable));

                                    int attempts = 0; //Add this in case we don't have any weapons in the table to even pick from so we don't loop forever
                                    while (randomItem < 257 && attempts != 10)
                                    {
                                        randomItem = GetRandomLoot(FilterLootTable(itemTable));
                                        attempts++;
                                    }

                                    Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 0);
                                    currentAddress += 0x00000038;
                                }
                            }
                            else
                                currentAddress += 0x00000040;
                        }
                        prevFloor = currentFloor;   //once everything is done, we initialize this so it wont reroll again in same floor
                    }
                }
                else
                    prevFloor = 200;    //used to reset the floor data when going back to dungeon
            }
        }

        public static void ElementSwapping()
        {
            string[] elementName = new string[6];

            elementName[0] = "Fire";    //33
            elementName[1] = "Ice";     //32
            elementName[2] = "Thunder"; //36
            elementName[3] = "Wind";    //33
            elementName[4] = "Holy";    //33
            elementName[5] = "None";    //33

            byte elementSelected;
            elemRGBs[0] = elemRGBFire;
            elemRGBs[1] = elemRGBIce;
            elemRGBs[2] = elemRGBThunder;
            elemRGBs[3] = elemRGBWind;
            elemRGBs[4] = elemRGBHoly;
            elemRGBs[5] = elemRGBNone;

            int width;

            while (true)
            {
                int currentCharacter = Player.CurrentCharacterNum();
                byte currentWeaponSlot;

                
                //Free - Running
                //Free - Walking
                //Combat - Blocking Startup
                //Combat - Blocking Active
                //Combat - Blocking Recovery
                //Combat - Idle
                //Combat - Strafing Right
                //Combat - Strafing Left
                //Combat - Strafing Forwards
                //Combat - Strafing Backwards
                //Combat - Strafing Blocking

                //Check for character animations
                switch (Memory.ReadByte(0x21DC4484))
                {
                    default: break;
                    case 0:     //Free - Idle
                    case 1:     //Free - Running
                    case 2:     //Free - Walking
                    case 8:     //Combat - Blocking Startup
                    case 9:     //Combat - Blocking Active
                    case 10:    //Combat - Blocking Recovery
                    case 18:    //Combat - Idle
                    case 19:    //Combat - Strafing Right
                    case 20:    //Combat - Strafing Left
                    case 21:    //Combat - Strafing Forwards
                    case 22:    //Combat - Strafing Backwards
                    case 33:    //Combat - Strafing Blocking
                        {
                            if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.DPad_Up ||
                                Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.DPad_Down ||
                                Memory.ReadUShort(Addresses.buttonInputs) == 4104 ||    //DPad_Up + R1
                                Memory.ReadUShort(Addresses.buttonInputs) == 16392      //DPad_Down + R1
                                )
                            {
                                if (elemSwitching == false)
                                {
                                    if (Player.InDungeonFloor() == true && (Memory.ReadUInt(Addresses.dungeonDebugMenu) == 0 || Memory.ReadUInt(Addresses.dungeonDebugMenu) == 10))
                                    {
                                        byte currentSlot = Memory.ReadByte(0x21CDD88C + (currentCharacter * 0x1));
                                        int currentWepElemAddr;
                                        if (currentCharacter == 0)
                                        {
                                            currentWepElemAddr = Player.Toan.WeaponSlot0.elementHUD + (0xF8 * currentSlot);
                                        }
                                        else if (currentCharacter == 1)
                                        {
                                            currentWepElemAddr = Player.Xiao.WeaponSlot0.elementHUD + (0xF8 * currentSlot);
                                        }
                                        else if (currentCharacter == 2)
                                        {
                                            currentWepElemAddr = Player.Goro.WeaponSlot0.elementHUD + (0xF8 * currentSlot);
                                        }
                                        else if (currentCharacter == 3)
                                        {
                                            currentWepElemAddr = Player.Ruby.WeaponSlot0.elementHUD + (0xF8 * currentSlot);
                                        }
                                        else if (currentCharacter == 4)
                                        {
                                            currentWepElemAddr = Player.Ungaga.WeaponSlot0.elementHUD + (0xF8 * currentSlot);
                                        }
                                        else
                                        {
                                            currentWepElemAddr = Player.Osmond.WeaponSlot0.elementHUD + (0xF8 * currentSlot);
                                        }

                                        elementSelected = Memory.ReadByte(currentWepElemAddr);
                                        int weaponElemAmount = currentWepElemAddr + 0x00000001;
                                        bool validElement = false;
                                        if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.DPad_Up ||
                                            Memory.ReadUShort(Addresses.buttonInputs) == 4104)  //DPad_Up + R1
                                        {
                                            while (validElement == false)
                                            {
                                                elementSelected--;
                                                byte elemAmount = Memory.ReadByte(weaponElemAmount + (elementSelected * 0x1));

                                                if (elementSelected < 0)
                                                {
                                                    break;
                                                }

                                                if (elemAmount == 0)
                                                {
                                                    validElement = false;
                                                }
                                                else
                                                {
                                                    validElement = true;
                                                }
                                            }
                                        }
                                        else if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.DPad_Down ||
                                                Memory.ReadUShort(Addresses.buttonInputs) == 16392) //DPad_Down + R1
                                        {
                                            while (validElement == false)
                                            {
                                                elementSelected++;
                                                byte elemAmount = Memory.ReadByte(weaponElemAmount + (elementSelected * 0x1));

                                                if (elementSelected > 4)
                                                {
                                                    if (elementSelected > 5)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        if (currentCharacter == 3 || currentCharacter == 5)
                                                        {
                                                            break;
                                                        }
                                                    }

                                                }
                                                if (elementSelected < 5)
                                                {
                                                    if (elemAmount == 0)
                                                    {
                                                        validElement = false;
                                                    }
                                                    else
                                                    {
                                                        validElement = true;
                                                    }
                                                }
                                                else
                                                {
                                                    validElement = true;
                                                }
                                            }
                                        }
                                        if (validElement == true)
                                        {
                                            if (elementSelected >= 0 && elementSelected <= 5)
                                            {

                                                Memory.WriteByte(currentWepElemAddr, elementSelected); //Set element in HUD for weapon
                                                Memory.WriteUShort(0x21EA75A6, elementSelected); //Set element 
                                                                                                 //elemSwitching = true;

                                                if (currentCharacter == 3)
                                                {
                                                    CheckElements(elementSelected);
                                                    /*
                                                    if (elemChanged == false)
                                                    {
                                                        elemTextureHoly = Memory.ReadByteArray(0x217FD840, elemTextureHoly.Length);
                                                        elemChanged = true;
                                                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Element stored");
                                                        File.WriteAllBytes(@"c:\DC1Elements\holy.txt", elemTextureHoly);
                                                        //var elementFile = Properties.Resources.thunder;
                                                        //string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                                        //var bytes = File.ReadAllBytes(path + @"\thunder.txt");
                                                        //Memory.WriteByteArray(0x217FD840, bytes);

                                                    }
                                                    else if (elemChanged == true)
                                                    {
                                                        Memory.WriteByteArray(0x217FD840, elemTextureHoly);
                                                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Element written");
                                                    }
                                                    */
                                                    Memory.WriteByte(0x21F10018, 1);

                                                }

                                                Memory.WriteByteArray(0x21E59450, elemRGBs[elementSelected]);

                                                //Dynamically change the message width acording to the selected element word
                                                switch (elementSelected)
                                                {
                                                    case 1: width = 32; break;
                                                    case 2: width = 36; break;
                                                    default: width = 33; break;
                                                }

                                                DisplayMessage("Changed current attribute to " + elementName[elementSelected], 1, width, 1000);
                                                Thread.Sleep(1100);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                elemSwitching = false;
                            }

                            break;
                        }
                }

                Thread.Sleep(1);
            }
        }

        public static void CheckElements(byte currentElem)
        {

            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            byte[] bytes;
            int addressPointer = Memory.ReadInt(0x202A2DDC);
            
            addressPointer += 0x20000000;

            switch (currentElem)
            {
                case 0:
                    bytes = Resources.rubyFireTex;
                    Memory.WriteByteArray(addressPointer, bytes);
                    //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Wrote fire texture");

                    break;
                case 1:
                    bytes = Resources.rubyIceTex;
                    Memory.WriteByteArray(addressPointer, bytes);
                    //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Wrote ice texture");

                    break;
                case 2:
                    bytes = Resources.rubyThunderTex;
                    Memory.WriteByteArray(addressPointer, bytes);
                    //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Wrote thunder texture");

                    break;
                case 3:
                    bytes = Resources.rubyWindTex;
                    Memory.WriteByteArray(addressPointer, bytes);
                    //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Wrote wind texture");

                    break;
                case 4:
                    bytes = Resources.rubyHolyTex;
                    Memory.WriteByteArray(addressPointer, bytes);
                    //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Wrote holy texture");

                    break;
            }
        }

        /// <summary>
        /// Processes the dungeon message information and displays it onscreen
        /// </summary>
        /// <param name="message">The contents of the message.</param>
        /// <param name="height">The height of the message window. Each value represents a line, ie 2 = paragrah with 2 lines.</param>
        /// <param name="width">The width of the message window. Each value represents a character in the string, ie 24 = 24 characters wide.</param>
        /// <param name="displayTime">The amount of time to display the message. Keep in mind there is a 5 second timeout threshold in place.</param>
        /// <returns>An array of bytes with the output message.</returns>
        public static void DisplayMessage(string message, int height = 4, int width = 40, int displayTime = 8000, bool isFloorClearMessage = false)
        {
            //Convert miliseconds to frames per second
            displayTime = (int)System.Math.Round(displayTime / 16.7f);

            messageThread = new Thread(() => DisplayMessageProcess(message, height, width, displayTime, isFloorClearMessage));
            messageThread.Start();
        }

        /// <summary>
        /// Returns true if no message is being displayed on screen, await a set amount of time if it is. 
        /// </summary>
        /// <param name="timeout">Set a timeout in miliseconds (Default is 8 seconds)</param>
        /// <returns></returns>
        internal static bool CheckDisplayMessageAvailable(int timeout = 8000)
        {
            int ms;

            //Check if a dungeon message is displaying
            if (Memory.ReadInt(Addresses.dunMessage) != -1 && Memory.ReadInt(Addresses.dunMessage) != 171) //Thirst Message
            {
                //Reset timer
                ms = 0;

                //Wait for whatever message is currently displaying
                while (Memory.ReadInt(Addresses.dunMessage) != -1 && ms < timeout)
                {
                    Thread.Sleep(100);
                    ms += 100;
                    continue;
                }
                //if(ms < timeout) return true; else return false;
                return true;
            }
            else return true;
        }

        static byte[] DisplayMessageProcess(string message, int height, int width, int displayTime, bool isFloorClearMessage)
        {
            while (!CheckDisplayMessageAvailable())
            {
                continue;
            }

            byte[] customMessage = Encoding.GetEncoding(10000).GetBytes(message);
            if (isFloorClearMessage) { dungeonMessage = Memory.ReadByteArray(Addresses.dunMessageLastEnemyName, message.Length); }
            else { dungeonMessage = Memory.ReadByteArray(Addresses.dunMessage10, message.Length); }

            byte[] outputMessage = new byte[customMessage.Length * 2];

            byte[] normalCharTable =
            {0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, //A-Z

            0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
            0x70, 0x71, 0x72, 0x73, 0x74 ,0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, //a-z

            //0     1     2     3     4     5     6     7     8     9
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39,

            //'     =     "     !     ?     #     &     +     -     *     (     )    @     |     ^
            0x27, 0x3D, 0x22, 0x21, 0x3F, 0x23, 0x26, 0x2B, 0x2D, 0x2A, 0x28, 0x29, 0x40, 0x7C, 0x5E,
            
            //<     >     {    }     [     ]
            0x3C, 0x3E, 0x7B, 0x7D, 0x5B, 0x5D,

            //.    $     \n    SPC
            0x2E, 0x24,  0x0A, 0x20,

            //Cross     Circle
              0x8,       0x6,
            };

            byte[] dcCharTable =
            {0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, //A-Z

            0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49,
            0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, //a-z

            //0     1     2     3     4     5     6     7     8     9
            0x6F, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78,

            //'     =     "     !     ?     #     &     +     -     *     (     )     @    |     ^
            0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x5B, 0x5C, 0x5D, 0x5E, 0x61, 0x62, 0x63, 0x64, 0xFF, //Just needed for detection, doesn't matter what this is
            
            //<     >     {    }     [      ]
            0x65, 0x66, 0x67, 0x68, 0x69, 0x6A,

            //.     $    \n    SPC
            0x6D, 0x6E, 0x00, 0x02,

            //Cross     Circle
              0x8,       0x6,
            };

            
            //Initialize outputMessage to 0xFD
            for (int i = 0; i < outputMessage.Length; i++)
            {
                outputMessage[i] = 0xFD;  
            }

            //Initialize current dungeonMessage to nothing
            for (int i = 0; i < dungeonMessage.Length; i++)
            {
                dungeonMessage[i] = 0xFD;
            }

            /*
            for (int i = 0; i < dungeonMessage.Length; i += width) //Initialize Dungeon message with three lines.
            {
                //newLine
                dungeonMessage[i] = 0x00;
                dungeonMessage[i + 1] = 0xFF;
            }
            */

            if(isFloorClearMessage) Memory.WriteByteArray(Addresses.dunMessageLastEnemyName, dungeonMessage);
            else Memory.WriteByteArray(Addresses.dunMessage10, dungeonMessage);

            for (int i = 0; i < customMessage.Length; i++)
            {
                for (int t = 0; t < dcCharTable.Length; t++)
                {
                    if (customMessage[i] == normalCharTable[t])
                    {
                        if (normalCharTable[t] == 0x0A) //newLine
                        {
                            outputMessage[i * 2] = 0x00;
                            outputMessage[i * 2 + 1] = 0xFF;
                        }

                        else if (normalCharTable[t] == 0x20) //SPC
                        {
                            outputMessage[i * 2] = 0x02;
                            outputMessage[i * 2 + 1] = 0xFF;
                        }

                        else if (normalCharTable[t] == 0x5E) //^
                        {
                            if (customMessage[i + 1] == 0x57) //W
                            {
                                i++;  //Skip displaying the W
                                outputMessage[i * 2] = 0x01; //White
                                outputMessage[i * 2 + 1] = 0xFC;
                            }

                            else if (customMessage[i + 1] == 0x59) //Y
                            {
                                i++;
                                outputMessage[i * 2] = 0x02; //Yellow
                                outputMessage[i * 2 + 1] = 0xFC;
                            }

                            else if (customMessage[i + 1] == 0x42) //B
                            {
                                i++;
                                outputMessage[i * 2] = 0x03; //Blue
                                outputMessage[i * 2 + 1] = 0xFC;
                            }

                            else if (customMessage[i + 1] == 0x47) //G
                            {
                                i++;
                                outputMessage[i * 2] = 0x04; //Green
                                outputMessage[i * 2 + 1] = 0xFC;
                            }

                            //0x05 is a nasty brown color

                            else if (customMessage[i + 1] == 0x4F)
                            {
                                i++;
                                outputMessage[i * 2] = 0x06; //Orange
                                outputMessage[i * 2 + 1] = 0xFC;
                            }

                            //0x07 is a gray

                            else if (customMessage[i + 1] == 0x52)
                            {
                                i++;
                                outputMessage[i * 2] = 0xFF; //Red
                                outputMessage[i * 2 + 1] = 0xFC;
                            }
                        }

                        else
                            outputMessage[i * 2] = dcCharTable[t];
                    }
                }

                if(i == customMessage.Length - 1)
                {
                    int aux;

                    if (isFloorClearMessage) { aux = Addresses.dunMessageLastEnemyName + outputMessage.Length; }
                    else { aux = Addresses.dunMessage10 + outputMessage.Length; }

                    Memory.WriteByte(aux, 1);
                    Memory.WriteByte(aux + 0x1, 255);
                }
            }


            byte[] hornHead = { 40, 253, 73, 253, 76, 253, 72, 253, 40, 253, 63, 253, 59, 253, 62, 253, 1, 255 };
            byte[] original10Message = {52, 253, 66, 253, 63, 253, 76, 253, 63, 253, 2, 255, 67, 253, 77, 253, 2, 255, 72, 253, 73, 253, 2, 255, 77, 253, 67, 253, 65, 253, 72, 253, 2, 255, 73, 253, 64, 253, 2, 255, 71, 253, 73, 253, 72, 253, 77, 253, 78, 253, 63, 253, 76, 253, 77, 253, 2, 255, 0, 255, 73, 253, 72, 253, 2, 255, 78, 253, 66, 253, 67, 253, 77, 253, 2, 255, 64, 253, 70, 253, 73, 253, 73, 253, 76, 253, 109, 253, 2, 255, 57, 253, 73, 253, 79, 253, 2, 255, 61, 253, 59, 253, 72, 253, 2, 255, 79, 253, 77, 253, 63, 253, 2, 255, 83, 253, 73, 253, 79, 253, 76, 253, 2, 255, 0, 255, 63, 253, 77, 253, 61, 253, 59, 253, 74, 253, 63, 253, 2, 255, 77, 253, 69, 253, 67, 253, 70, 253, 70, 253, 109, 253, 0, 255, 3, 252, 87, 253, 44, 253, 63, 253, 59, 253, 80, 253, 63, 253, 2, 255, 36, 253, 79, 253, 72, 253, 65, 253, 63, 253, 73, 253, 72, 253, 87, 253, 0, 252, 2, 255, 59, 253, 80, 253, 59, 253, 67, 253, 70, 253, 59, 253, 60, 253, 70, 253, 63, 253, 88, 253, 1, 255};
            int messageId = 10;
            int messageAddress = Addresses.dunMessage10;

            if (isFloorClearMessage)
            {
                messageId = 3319;
                messageAddress = Addresses.dunMessageLastEnemyName;
                outputMessage = original10Message;//Memory.ReadByteArray(Addresses.dunMessage10, 157);
            }

            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            Memory.WriteByteArray(messageAddress, outputMessage);
            Memory.WriteInt(Addresses.dunMessage, messageId);
            Memory.WriteInt(Addresses.dunMessageDuration, displayTime);
            Thread.Sleep(300);
            if (isFloorClearMessage) Memory.WriteByteArray(messageAddress, hornHead); //Display the 3319th dungeon message (last enemy name [HornHead] message)
            /*messageThreadTimer = new Thread(() => DisplayMessageCustomTime(displayTime));
            messageThreadTimer.Start();*/

            return outputMessage;
        }

        /*
        public static void DisplayMessageCustomTime(int displayTime)
        {
            Thread.Sleep(displayTime);
            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            //Memory.WriteByteArray(Addresses.dunMessage10, originalDunMessage); //Revert message back to default
            //messageThread.Abort();
        }*/

        public static void CallGameFunction(byte[] function) // functionBGMStop
        {
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Function address to write: {0:X}", Addresses.functionEntryPoint);
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Current Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Function to write: " + BitConverter.ToString(Addresses.functionOverride));
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Attempting to write function value. ");

            byte[] function2OriginalOpcode = Memory.ReadByteArray(Addresses.functionEntryPoint2, 4);

            Memory.WriteByteArray(Addresses.functionEntryPoint, Addresses.functionOverride);
            Memory.WriteByteArray(Addresses.functionEntryPoint2, function); 
        }

        public static void TestElementFunctionStuff()
        {
            bool successful;

            Memory.VirtualProtect(Memory.processH, 0x201B6A0C, 8, Memory.PAGE_EXECUTE_READWRITE, out _);
            successful = Memory.VirtualProtectEx(Memory.processH, 0x201B6A0C, 8, Memory.PAGE_EXECUTE_READWRITE, out _);
            
            if (successful == false) //There was an error
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

            successful = Memory.VirtualProtectEx(Memory.processH, 0x201B6A14, 4, Memory.PAGE_EXECUTE_READWRITE, out _);

            if (successful == false) //There was an error
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

            Memory.WriteInt(0x201B6A0C, 0);
            Memory.WriteInt(0x201B6A14, 0);
        }

        public static void printItemTableNames(byte[] table)
        {
            int[] filteredLootTable = new int[table.Length / 4]; //Create a new table to store the ints only

            int t = 0;
            for (int i = 0; i < filteredLootTable.Length; i++) //Increment by 4
            {
                filteredLootTable[i] = BitConverter.ToInt32(table, t); //Parse the byte arrays and store the int values
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Items.ItemNameTbl[filteredLootTable[i]]);
                t += 4;
            }
        }

        [Flags]
        enum Specials1
        {
            None        =   0b_00000000,   // 0
            Unknown     =   0b_00000001,   // 1
            BigBucks    =   0b_00000010,   // 2
            Poor        =   0b_00000100,   // 4
            Quench      =   0b_00001000,   // 8
            Thirst      =   0b_00010000,   // 16
            Poison      =   0b_00100000,   // 32
            Stop        =   0b_01000000,   // 64
            Steal       =   0b_10000000,   // 128
            All         =   0b_11111111,   // 254      
        }

        [Flags]
        enum Specials2
        {
            None        =   0b_00000000,   // 0
            Fragile     =   0b_00000001,   // 1
            Durable     =   0b_00000010,   // 2
            Drain       =   0b_00000100,   // 4
            Heal        =   0b_00001000,   // 8
            Critical    =   0b_00010000,   // 16
            AbsUp       =   0b_00100000,   // 32
            All         =   0b_00111111,   // 63 
        }

        static void CheckSpecials1()
        {
            Specials1 special1 = (Specials1)Memory.ReadByte(Player.Toan.WeaponSlot0.special1); //Pull our value from the memory and cast it to our enumerated Specials type
            
            if (special1.HasFlag(Specials1.Unknown))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has Unknown Ability");

            if (special1.HasFlag(Specials1.BigBucks))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has BigBucks Ability");

            if (special1.HasFlag(Specials1.Poor))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has Poor Ability");

            if (special1.HasFlag(Specials1.Quench))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has Quench Ability");

            if (special1.HasFlag(Specials1.Thirst))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has Thirst Ability");

            if (special1.HasFlag(Specials1.Poison))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has Poison Ability");

            if (special1.HasFlag(Specials1.Stop))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has Stop Ability");

            if (special1.HasFlag(Specials1.Steal))
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Weapon Slot 0 has Steal Ability");
        }

        static void TestBitField(Specials1 special1, Specials2 special2)
        {
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + special1 + " " + (byte)special1);
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + special2 + " " + (byte)special2);
        }

        public static void retrieveMemTextures()
        {
            byte[] TIM2_Header = new byte[] { 0x54, 0x49, 0x4D, 0x32, 0x03, 0x00, 0x01 };
            byte[] texture;
            int size;
            int resultIndex;

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Retreiving and writing textures from memory to disk. This may take some time...");

            List<int> results = Memory.ByteArraySearch(0x20B69600, 0x2191F530, TIM2_Header);

            if (!Directory.Exists("memtextures"))
                Directory.CreateDirectory("memtextures");

            for (resultIndex = 0; resultIndex < results.Count - 1; resultIndex++)
            {
                size = results[resultIndex + 1] - results[resultIndex]; //This will not be able to determine the size of the last texture
                texture = Memory.ReadByteArray(results[resultIndex], size);

                File.WriteAllBytes("memtextures\\MemTexture" + resultIndex.ToString() + ".tm2", texture);
            }

            //Write our last texture
            size = 8388608; //Pick a big size, the texture file will still open without issue
            texture = Memory.ReadByteArray(results[resultIndex], size);

            File.WriteAllBytes("memtextures\\MemTexture" + (resultIndex).ToString() + ".tm2", texture);

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Finished writing textures to disk.");
        } 

        public static void Testing()
        {
            Resources.initiateRubyMemeFix(); //Load the texture resources to fix the Ruby Meme into memory.

            //CheatCodes.InputBuffer.Monitor();

            //List<int> results = Memory.StringSearch(0x20000000, 0x22000000, "TIM2");

            //for (int i = 0; i < results.Count; i++)
            //    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "0x{0:X8}", results[i]);

            //byte[] TIM2_Header = new byte[] { 0x54, 0x49, 0x4D, 0x32, 0x03, 0x00, 0x01};

            //List<int> results = Memory.ByteArraySearch(0x20900000, 0x22000000, TIM2_Header);

            //for (int i = 0; i < results.Count; i++)
            //    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "0x{0:X8}", results[i]);

            //Console.Clear();
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Memory.ReadUShort(Addresses.buttonInputs1));
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Memory.ReadByte(Addresses.buttonInputs1));
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Memory.ReadByte(Addresses.buttonInputs2));
            //Thread.Sleep(15);
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + GetRandomLoot(FilterLootTable(ItemTbl0)));
            //Thread.Sleep(1000);
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + i);
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Shop.ItemSlot0.item);
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Shop.ItemSlot0.price);
            //Thread.Sleep(1000);
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + );
            //Shop.ItemSlot0.item++;
            //i++;

            //Specials1 special1 = Specials1.None;
            //Specials2 special2 = Specials2.Critical;

            //CheckSpecials1();
            //TestBitField(special1, special2);
            //Memory.WriteUShort(Enemies.Enemy13.hp, 1000); 

            //printItemTableNames(ItemTbl6);      

            elementSwapThread.Start(); //Start thread
            cheatCodeThread.Start();
            dayChestThread.Start();
            dayEnemyThread.Start();  

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool godMode = false;

            int textureAddress1 = 0x20429F10;
            int textureAddress2 = 0x2043A350;
            //int textureAddress3 = 0x2044A790;

            byte[] testImage = new byte[] { 0x00 };
            byte[] modifiedTexture1 = new byte[] { 0x00 };
            byte[] modifiedTexture2 = new byte[] { 0x00 };

            if (File.Exists("test.tm2"))
            {
                testImage = File.ReadAllBytes("test.tm2");
            }

            if (File.Exists("20429f10.tm2"))
            {
                modifiedTexture1 = File.ReadAllBytes("20429f10.tm2");
                modifiedTexture2 = File.ReadAllBytes("20429f10.tm2");
                //modifiedTexture3 = File.ReadAllBytes("20429f10.tm2");
            }

            //CallGameFunction(Addresses.functionBGMStop);
            //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "New Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));

            while (1 == 1)
            {
                Memory.WriteFloat(Player.Ungaga.WeaponSlot4.whp, 5000);

                int currentCharacter = Memory.ReadInt(Player.currentCharacter); //Read 4 bytes of currentCharacter value and check if Toan, Xiao, etc. Toan = 1680945251, Xiao = 1647587427

                if (Memory.ReadUInt(Addresses.dungeonClear) == 4294967281)
                {
                    Memory.WriteInt(Addresses.dunMessage, 10); //Display dungeon leave message
                    Memory.WriteInt(Addresses.dungeonClear, 0); //Change this value so that the message doesn't get written forever
                }

                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10); //Format the TimeSpan value.
                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "RunTime " + elapsedTime);

                if (Memory.ReadUShort(Addresses.buttonInputs) == 128)  //If Square is pressed, activate BGMStop
                {
                    Thread.Sleep(2000); //Wait two seconds
                    if (Memory.ReadUShort(Addresses.buttonInputs) == 128)  //Check again
                    {
                        if (Player.InDungeonFloor() == true)
                        {
                            CallGameFunction(Addresses.functionBGMStop);
                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "New Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));
                            TestElementFunctionStuff();
                            Memory.WriteByteArray(Addresses.dunMessageLastEnemyName, DisplayMessageProcess("Background music stopped.", 1, 36, 3000, false));
                        }
                    }
                }



                //if (Memory.ReadUShort(Addresses.buttonInputs) == 4111)  //If L1+L2+R1+R2+DpadUp is pressed, activate godmode
                //{
                //    Thread.Sleep(2000); //Wait two seconds
                //    if (Memory.ReadUShort(Addresses.buttonInputs) == 4111)  //Check again
                //    {
                //        if (Player.InDungeonFloor() == true)
                //        {
                //            if (godMode == true)
                //            {
                //                godMode = false;
                //                Memory.WriteByteArray(Addresses.dunMessage10, DisplayMessage("God Mode deactivated.             \n                    \nYou are no longer invincible to enemy damage."));
                //            }

                //            else if (godMode == false)
                //            {
                //                godMode = true;
                //                DisplayMessage("God Mode activated.             \n                          \nYou are now invincible to enemy damage.      ");
                //            }           
                //        }
                //    }
                //}

                if (godMode == true)
                {
                    Thread.Sleep(50);
                    if (Player.InDungeonFloor() == false) //We left the dungeon
                        godMode = false; //Disable god mode.

                    if (currentCharacter == 1680945251) //Toan
                    {
                        Memory.WriteUShort(Player.Toan.GetHp(), Player.Toan.GetMaxHp()); //Set Toan's HP to match max HP
                    }
                    else if (currentCharacter == 1647587427) //Xiao
                    {
                        Memory.WriteUShort(Player.Xiao.hp, Memory.ReadUShort(Player.Xiao.maxHP)); //Set Xiaos's HP to match max HP
                    }
                }

                if (Player.CurrentCharacterNum() == 2) //If Xiao
                {
                    Memory.WriteByteArray(textureAddress1, modifiedTexture1);
                    Memory.WriteByteArray(textureAddress2, modifiedTexture2);
                    ///Memory.WriteByteArray(textureAddress3, modifiedTexture3);
                }

                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Input: " + Memory.ReadUShort(Addresses.buttonInputs));
                //Thread.Sleep(10); //10ms
                //Console.Clear();
            }
            //Form1.dayThread.Abort();
            //elementSwapThread.Abort();
            //stopWatch.Stop();
        }
    }
}
