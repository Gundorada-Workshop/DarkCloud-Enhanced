using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace Dark_Cloud_Improved_Version
{
    class Dayuppy
    {
        private static Thread cheatCodeThread = new Thread(new ThreadStart(CheatCodes.InputBuffer.Monitor)); //Create a new thread to run monitorElementSwapping()
        private static Thread elementSwapThread = new Thread(new ThreadStart(ElementSwapping)); //Create a new thread to run monitorElementSwapping()
        private static Thread dayEnemyThread = new Thread(new ThreadStart(EnemyDropRandomizer)); //Create a new thread to run monitorElementSwapping()
        private static Thread dayChestThread = new Thread(new ThreadStart(DayChestRandomizer)); //Create a new thread to run monitorElementSwapping()
        public static Thread messageThread;

        private static byte[] originalDunMessage = Memory.ReadByteArray(Addresses.dunMessage10, 210); //Read 210 bytes of byte array that stores dungeon message 10

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
                //Console.WriteLine(Items.ItemNameTbl[filteredLootTable[i]]);
                t += 4;
            }

            return filteredLootTable;
        }

        public static void EnemyDropRandomizer()
        {
            Console.WriteLine("Day's test monster drop randomizer is running...");
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

                                Console.WriteLine("Gave monster " + i + " item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
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
            Console.WriteLine("Day's test chest randomizer is running...");
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
                        Console.WriteLine();
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

                                Console.WriteLine("Spawned item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);

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

                                    Console.WriteLine("Spawned item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
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

                                    Console.WriteLine("Spawned item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
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

                                    Console.WriteLine("Spawned backfloor item:" + randomItem + "\tName: " + Items.ItemNameTbl[randomItem]);
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

        private static void ElementSwapping()
        {
            string[] elementName = new string[6];

            elementName[0] = "Fire";
            elementName[1] = "Ice";
            elementName[2] = "Thunder";
            elementName[3] = "Wind";
            elementName[4] = "Holy";
            elementName[5] = "None";

            byte elementSelected;

            while (1 == 1)
            {
                int currentCharacter = Player.CurrentCharacterNum();
                byte currentWeaponSlot;

                if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.DPad_Up && Player.InDungeonFloor() == true && Memory.ReadUInt(Addresses.dungeonDebugMenu) == 0)  //If DPadUp and in dungeon, go to previous element
                {
                    switch (currentCharacter)
                    {
                        case 0:
                            currentWeaponSlot = Memory.ReadByte(Player.Toan.currentWeaponSlot);

                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 1:
                            currentWeaponSlot = Memory.ReadByte(Player.Xiao.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 2:
                            currentWeaponSlot = Memory.ReadByte(Player.Goro.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 3:
                            currentWeaponSlot = Memory.ReadByte(Player.Ruby.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 4:
                            currentWeaponSlot = Memory.ReadByte(Player.Ungaga.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 5:
                            currentWeaponSlot = Memory.ReadByte(Player.Osmond.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;
                    }
                }

                if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.DPad_Down && Player.InDungeonFloor() == true && Memory.ReadUInt(Addresses.dungeonDebugMenu) == 0)  //If DPadDOWN, go to next element
                {
                    switch (currentCharacter)
                    {
                        case 0:
                            currentWeaponSlot = Memory.ReadByte(Player.Toan.currentWeaponSlot);

                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 1:
                            currentWeaponSlot = Memory.ReadByte(Player.Xiao.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 2:
                            currentWeaponSlot = Memory.ReadByte(Player.Goro.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 3:
                            currentWeaponSlot = Memory.ReadByte(Player.Ruby.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 4:
                            currentWeaponSlot = Memory.ReadByte(Player.Ungaga.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 5:
                            currentWeaponSlot = Memory.ReadByte(Player.Osmond.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        DisplayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;
                    }
                }
            }
        }

        public static byte[] DisplayMessage(string message, int height = 4, int width = 27, int displayTime = 2000)
        {
            byte[] customMessage = Encoding.GetEncoding(10000).GetBytes(message);
            byte[] dungeonMessage = Memory.ReadByteArray(Addresses.dunMessage10, 210);
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

            for (int i = 0; i < dungeonMessage.Length; i += 27) //Initialize Dungeon message with three lines.
            {
                //newLine
                dungeonMessage[i] = 0x00;
                dungeonMessage[i + 1] = 0xFF;
            }
            Memory.WriteByteArray(Addresses.dunMessage10, dungeonMessage);

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
            }

            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            Memory.WriteByteArray(Addresses.dunMessage10, outputMessage);
            Thread.Sleep(50);
            Memory.WriteInt(Addresses.dunMessageHeight, height);
            Memory.WriteInt(Addresses.dunMessageWidth, width);
            Memory.WriteInt(Addresses.dunMessage, 10); //Display the 10th dungeon message
            Thread.Sleep(18);
            Memory.WriteInt(Addresses.dunMessageHeight, height);
            Memory.WriteInt(Addresses.dunMessageWidth, width);
            messageThread = new Thread(() => DisplayMessageCustomTime(displayTime));
            messageThread.Start();

            return outputMessage;
        }

        public static void DisplayMessageCustomTime(int displayTime)
        {
            Thread.Sleep(displayTime);
            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            Memory.WriteByteArray(Addresses.dunMessage10, originalDunMessage); //Revert message back to default
            messageThread.Abort();
        }

        public static void CallGameFunction(byte[] function) // functionBGMStop
        {
            Console.WriteLine("Function address to write: {0:X}", Addresses.functionEntryPoint);
            Console.WriteLine("Current Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));
            Console.WriteLine("Function to write: " + BitConverter.ToString(Addresses.functionOverride));
            Console.WriteLine("Attempting to write function value. ");

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
                Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

            successful = Memory.VirtualProtectEx(Memory.processH, 0x201B6A14, 4, Memory.PAGE_EXECUTE_READWRITE, out _);

            if (successful == false) //There was an error
                Console.WriteLine(Memory.GetLastError() + " - " + Memory.GetSystemMessage(Memory.GetLastError())); //Get the last error code and write out the message associated with it.

            Memory.WriteInt(0x201B6A0C, 0);
            //Memory.WriteInt(0x201B6A14, 0);
        }

        public static void printItemTableNames(byte[] table)
        {
            int[] filteredLootTable = new int[table.Length / 4]; //Create a new table to store the ints only

            int t = 0;
            for (int i = 0; i < filteredLootTable.Length; i++) //Increment by 4
            {
                filteredLootTable[i] = BitConverter.ToInt32(table, t); //Parse the byte arrays and store the int values
                Console.WriteLine(Items.ItemNameTbl[filteredLootTable[i]]);
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
                Console.WriteLine("Weapon Slot 0 has Unknown Ability");

            if (special1.HasFlag(Specials1.BigBucks))
                Console.WriteLine("Weapon Slot 0 has BigBucks Ability");

            if (special1.HasFlag(Specials1.Poor))
                Console.WriteLine("Weapon Slot 0 has Poor Ability");

            if (special1.HasFlag(Specials1.Quench))
                Console.WriteLine("Weapon Slot 0 has Quench Ability");

            if (special1.HasFlag(Specials1.Thirst))
                Console.WriteLine("Weapon Slot 0 has Thirst Ability");

            if (special1.HasFlag(Specials1.Poison))
                Console.WriteLine("Weapon Slot 0 has Poison Ability");

            if (special1.HasFlag(Specials1.Stop))
                Console.WriteLine("Weapon Slot 0 has Stop Ability");

            if (special1.HasFlag(Specials1.Steal))
                Console.WriteLine("Weapon Slot 0 has Steal Ability");
        }

        static void TestBitField(Specials1 special1, Specials2 special2)
        {
            Console.WriteLine(special1 + " " + (byte)special1);
            Console.WriteLine(special2 + " " + (byte)special2);
        }

        public static void retrieveMemTextures()
        {
            byte[] TIM2_Header = new byte[] { 0x54, 0x49, 0x4D, 0x32, 0x03, 0x00, 0x01 };
            byte[] texture;
            int size;
            int resultIndex;

            Console.WriteLine("Retreiving and writing textures from memory to disk. This may take some time...");

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

            Console.WriteLine("Finished writing textures to disk.");
        } 

        public static void Testing()
        {
            //CheatCodes.InputBuffer.Monitor();

            //List<int> results = Memory.StringSearch(0x20000000, 0x22000000, "TIM2");

            //for (int i = 0; i < results.Count; i++)
            //    Console.WriteLine("0x{0:X8}", results[i]);

            //byte[] TIM2_Header = new byte[] { 0x54, 0x49, 0x4D, 0x32, 0x03, 0x00, 0x01};

            //List<int> results = Memory.ByteArraySearch(0x20900000, 0x22000000, TIM2_Header);

            //for (int i = 0; i < results.Count; i++)
            //    Console.WriteLine("0x{0:X8}", results[i]);

            //Console.Clear();
            //Console.WriteLine(Memory.ReadUShort(Addresses.buttonInputs1));
            //Console.WriteLine(Memory.ReadByte(Addresses.buttonInputs1));
            //Console.WriteLine(Memory.ReadByte(Addresses.buttonInputs2));
            //Thread.Sleep(15);
            //Console.WriteLine(GetRandomLoot(FilterLootTable(ItemTbl0)));
            //Thread.Sleep(1000);
            //Console.WriteLine(i);
            //Console.WriteLine(Shop.ItemSlot0.item);
            //Console.WriteLine(Shop.ItemSlot0.price);
            //Thread.Sleep(1000);
            //Console.WriteLine();
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
            //Console.WriteLine("New Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));

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
                //Console.WriteLine("RunTime " + elapsedTime);



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
                        Memory.WriteUShort(Player.Toan.hp, Memory.ReadUShort(Player.Toan.maxHP)); //Set Toan's HP to match max HP
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

                //Console.WriteLine("Input: " + Memory.ReadUShort(Addresses.buttonInputs));
                //Thread.Sleep(10); //10ms
                //Console.Clear();
            }
            //Form1.dayThread.Abort();
            //elementSwapThread.Abort();
            //stopWatch.Stop();
        }
    }
}
