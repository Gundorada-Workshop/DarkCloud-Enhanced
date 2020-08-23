using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Linq;

namespace Dark_Cloud_Improved_Version
{
    class Dayuppy
    {
        private static Thread elementSwapThread = new Thread(new ThreadStart(ElementSwapping)); //Create a new thread to run monitorElementSwapping()
        private static Thread dayChestThread = new Thread(new ThreadStart(DayChestRandomizer)); //Create a new thread to run monitorElementSwapping()
        private static byte[] originalDunMessage = Memory.ReadByteArray(Addresses.dunMessage10, 158); //Read 158 bytes of byte array that stores dungeon message 10

        private static byte[] MemTexture1_a = Memory.ReadByteArray(0x20388BF0, 0x203BAAC0 - 0x20388BF0);
        private static byte[] MemTexture2_a = Memory.ReadByteArray(0x203BAAC0, 0x203E46C0 - 0x203BAAC0);
        private static byte[] MemTexture3_a = Memory.ReadByteArray(0x203E46C0, 0x203E8B00 - 0x203E46C0);
        private static byte[] MemTexture4_a = Memory.ReadByteArray(0x203E8B00, 0x20429FA0 - 0x203E8B00);
        private static byte[] MemTexture5_a = Memory.ReadByteArray(0x20429FA0, 0x2042E3E0 - 0x20429FA0);
        private static byte[] MemTexture6_a = Memory.ReadByteArray(0x2042E3E0, 0x2043E820 - 0x2042E3E0);
        private static byte[] MemTexture7_a = Memory.ReadByteArray(0x2043E820, 0x2044EC60 - 0x2043E820);
        private static byte[] MemTexture8_a = Memory.ReadByteArray(0x2044EC60, 0x2045F0A0 - 0x2044EC60);
        private static byte[] MemTexture9_a = Memory.ReadByteArray(0x2045F0A0, 0x2046F4E0 - 0x2045F0A0);
        private static byte[] MemTexture10_a = Memory.ReadByteArray(0x2046F4E0, 0x20475920 - 0x2046F4E0);
        private static byte[] MemTexture11_a = Memory.ReadByteArray(0x20475920, 0x20649200 - 0x20475920);
        private static byte[] MemTexture12_a = Memory.ReadByteArray(0x20649200, 0x206528C0 - 0x20649200);
        private static byte[] MemTexture13_a = Memory.ReadByteArray(0x206528C0, 0x2065BC80 - 0x206528C0);
        private static byte[] MemTexture14_a = Memory.ReadByteArray(0x2065BC80, 0x2066B420 - 0x2065BC80);
        private static byte[] MemTexture15_a = Memory.ReadByteArray(0x2066B420, 0x2075E410 - 0x2066B420);
        private static byte[] MemTexture16_a = Memory.ReadByteArray(0x2075E410, 0x20762850 - 0x2075E410);
        private static byte[] MemTexture17_a = Memory.ReadByteArray(0x20762850, 0x20766C90 - 0x20762850);
        private static byte[] MemTexture18_a = Memory.ReadByteArray(0x20766C90, 0x2076B0D0 - 0x20766C90);
        private static byte[] MemTexture19_a = Memory.ReadByteArray(0x2076B0D0, 0x209CF380 - 0x2076B0D0);
        private static byte[] MemTexture20_a = Memory.ReadByteArray(0x209CF380, 0x20B69600 - 0x209CF380);
        private static byte[] MemTexture21_a = Memory.ReadByteArray(0x20B69600, 0x20B73280 - 0x20B69600);
        private static byte[] MemTexture22_a = Memory.ReadByteArray(0x20B73280, 0x20B7CF00 - 0x20B73280);
        private static byte[] MemTexture23_a = Memory.ReadByteArray(0x20B7CF00, 0x21698E10 - 0x20B7CF00);
        private static byte[] MemTexture24_a = Memory.ReadByteArray(0x21698E10, 0x216C9250 - 0x21698E10);
        private static byte[] MemTexture25_a = Memory.ReadByteArray(0x216C9250, 0x216D9690 - 0x216C9250);
        private static byte[] MemTexture26_a = Memory.ReadByteArray(0x216D9690, 0x2171FAD0 - 0x216D9690);
        private static byte[] MemTexture27_a = Memory.ReadByteArray(0x2171FAD0, 0x21747F10 - 0x2171FAD0);
        private static byte[] MemTexture28_a = Memory.ReadByteArray(0x21747F10, 0x217B6C20 - 0x21747F10);
        private static byte[] MemTexture29_a = Memory.ReadByteArray(0x217B6C20, 0x217D1770 - 0x217B6C20);
        private static byte[] MemTexture30_a = Memory.ReadByteArray(0x217D1770, 0x217DB470 - 0x217D1770);
        private static byte[] MemTexture31_a = Memory.ReadByteArray(0x217DB470, 0x217DF8B0 - 0x217DB470);
        private static byte[] MemTexture32_a = Memory.ReadByteArray(0x217DF8B0, 0x21824790 - 0x217DF8B0);
        private static byte[] MemTexture33_a = Memory.ReadByteArray(0x21824790, 0x2182C650 - 0x21824790);
        private static byte[] MemTexture34_a = Memory.ReadByteArray(0x2182C650, 0x21830DF0 - 0x2182C650);
        private static byte[] MemTexture35_a = Memory.ReadByteArray(0x21830DF0, 0x21FF0100 - 0x21830DF0);

        private static byte[] MemModel1_a = Memory.ReadByteArray(0x2190AA50, 625104); //Toan

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

        private static string[] ItemNameTbl = new string[] { "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Peridot", "Peridot", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Peridot", "Peridot", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Peridot", "Peridot", "Fire", "Ice", "Thunder", "Wind", "Holy", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Attack", "Endurance", "Speed", "Magic", "Garnet", "Amethyst", "Aquamarine", "Diamond", "Emerald", "Pearl", "Ruby", "Peridot", "Sapphire", "Opal", "Topaz", "Turquoise", "Sun", "Unknown", "Unknown", "Unknown", "Dinoslayer", "Undead Buster", "Sea Killer", "Stone Breaker", "Plant Buster", "Beast Buster", "Sky Hunter", "Metal Breaker", "Mimic Breaker", "Mage Slayer", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Anti-Freeze Amulet", "Anti-Curse Amulet", "Anti-Goo Amulet", "Antidote Amulet", "Fluffy Doughnut", "Fish Candy", "Grass Cake", "Witch Parfait", "Scorpion Jerky", "Carrot Cookie", "black square 142", "black square 143", "black square 144", "Regular Water", "Tasty Water", "Premium Water", "Bread", "Premium Chicken", "Stamina Drink", "Antidote Drink", "Holy Water", "Soap", "Mighty Healing", "Cheese", "black square 156", "black square 157", "black square 158", "Bomb", "Stone", "Inferno Gem", "Blizzard Gem", "Lightning Gem", "Whirlwind Gem", "Sacred Gem", "Throbbing Cherry", "Gooey Peach", "Bomb Nuts", "Poisonous Apple", "Mellow Banana", "Medusa Powder", "Unknown", "Warp Powder", "Stand-in Powder", "Escape Powder", "Revival Powder", "Repair Powder", "Powerup Powder", "Pocket", "Fruit of Eden", "Treasure Chest Key", "Gourd", "Auto Repair Powder", "black square 184", "Fishing Rod", "Carrot", "Potato cake", "Minon", "Battan", "Petite Fish", "Saving Book", "Gold Bullion", "Evy", "black square 194", "Dran's Crest", "Shiny Stone", "Mimi", "Red Berry", "Prickly", "Candy", "Hook", "King's Slate", "Gun Powder", "Clock Hands", "Pointy Chestnut", "Black Knight Crest", "Horned Key", "Moon Grass Seed", "Music Box Key", "Sun Signet", "Moon Signet", "Admission Ticket", "black square 213", "black square 214", "black square 215", "Bone Key", "Mustache Key", "Shipcabin Key", "Stone Key", "Handle", "Pitchdark Key", "Silver Key", "black square 223", "Tram Oil", "Sun Dew", "Flapping Fish", "Rotten Fish", "Secret Path Key", "Bravery Launch", "Flapping Duster", "Crystal Eyeball", "black square 232", "Map", "Magical Crystal", "Dran's Feather", "Cave Key", "Changing Potion", "World Map", "Bone Pendant", "Odd Tone Flute", "Magical Lamp", "Moon Orb", "Shell Ring", "Search Warrant", "Ice Block", "Small Ice", "Tiny Ice", "Flame Key", "Hunter's Earring", "Ointment Leaf", "Foundation", "Clay Doll", "Manual", "Sun Sphere", "black square 255", "black square 256", "Dagger (broken)", "Dagger", "Baselard", "Gladius", "Wise Owl Sword", "Crystal Knife", "Antique Sword", "Buster Sword", "Kitchen Knife", "Tsukikage", "Sun Sword", "Serpent Sword", "Macho Sword", "Shamshir", "Heaven's Cloud", "Lamb's Sword", "Dark Cloud", "Brave Ark", "Big Bang", "Atlamillia Sword", "glitched weapon", "Mardan Eins", "Mardan Twei", "Arise Mardan", "Aga's Sword", "Evilcise", "Small Sword", "Sand Breaker", "Drain Seeker", "Chopper", "Choora", "Claymore", "Maneater", "Bone Rapier", "Sax", "7 Branch Sword", "Dusack", "Cross Hinder", "7th Heaven", "Sword Of Zeus", "Chronicle Sword", "Chronicle 2", "Wooden Slingshot (broken)", "Wooden Slingshot", "Steel Slingshot", "Bandit Slingshot", "Steve", "Bone Slingshot", "Hardshooter", "Double Impact", "Dragon's Y", "Divine Beast Title", "Angel Shooter", "Flamingo", "Matador", "Super Steve", "Angel Gear", "Mallet (broken)", "Mallet", "Steel Hammer", "Magical Hammer", "Battle Ax", "Turtle Shell", "Big Bucks Hammer", "Frozen Tuna", "Gaia Hammer", "Last Judgement", "Tall Hammer", "Satan's Ax", "glitched weapon", "Plate Hammer", "Trial Hammer", "Inferno", "glitched weapon", "Gold Ring (broken)", "Gold Ring", "Bandit's Ring", "Crystal Ring", "Platinum Ring", "Goddess Ring", "Fairy's Ring", "Destruction Ring", "Satan's Ring", "Athena's Armlet", "Mobius Ring", "glitched weapon", "Pocklekul", "Thorn Armlet", "Secret Armlet", "glitched weapon", "Fighting Stick (broken)", "Fighting Stick", "Javelin", "Halberd", "DeSanga", "Scorpion", "Partisan", "Mirage", "Terra Sword", "Hercules' Wrath", "Babel's Spear", "glitched weapon", "5 Foot Nail", "Cactus", "glitched weapon", "glitched weapon", "Machine Gun (broken)", "Machine Gun", "Jackal", "Launcher [solid green model]", "Launcher V2 [solid red model]", "Blessing Gun", "Skunk", "G Crusher", "Hex aBlaster", "Star Breaker", "Supernova", "Snail", "Swallow", "empty slot" };

        private static Random random = new Random();

        private static int GetRandomLoot(int[] lootTable)
        {
            int randomItem = random.Next(lootTable.Length);

            return lootTable[randomItem];
        }

        private static int[] FilterLootTable(byte[] lootTable)
        {
            int[] filteredLootTable = new int[lootTable.Length / 4]; //Create a new table to store the ints only

            int t = 0;
            for (int i = 0; i < filteredLootTable.Length; i++) //Increment by 4
            {
                filteredLootTable[i] = BitConverter.ToInt32(lootTable, t); //Parse the byte arrays and store the int values
                //Console.WriteLine(ItemNameTbl[filteredLootTable[i]]);
                t += 4;
            }

            return filteredLootTable;
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

                                while (randomItem < 63 || randomItem > 258) //If valid item and not a weapon, else re-roll
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                Memory.Write(Addresses.firstChest, BitConverter.GetBytes(randomItem));
                            }
                            else    //if rolled for weapon
                            {
                                Memory.WriteByte(Addresses.firstChestSize, 0);

                                randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                while (randomItem < 258) //If valid item and not a weapon, else re-roll
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));

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

                                    while (randomItem < 63 || randomItem > 258) //If valid item and not a weapon, else re-roll
                                        randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                    Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 1);
                                    currentAddress += 0x00000038;

                                    Console.WriteLine("Spawned item:" + randomItem + " Name: " + ItemNameTbl[randomItem]);
                                }
                                else    //if rolled for weapon
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                    while (randomItem < 258)
                                        randomItem = GetRandomLoot(FilterLootTable(itemTable));

                                    Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 0);
                                    currentAddress += 0x00000038;

                                }
                            }
                            else
                                currentAddress += 0x00000040;
                        }

                        currentAddress = Addresses.backfloorFirstChest;

                        for (int i = 0; i < 7; i++)
                        {
                            chestSize = random.Next(25);

                            checkItemID = Memory.ReadShort(currentAddress);

                            if (checkItemID > 40)
                            {
                                if (chestSize != 0)
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(backfloorItemTable));

                                    while (randomItem < 63 || randomItem > 258)
                                        randomItem = GetRandomLoot(FilterLootTable(backfloorItemTable));

                                    Memory.Write(currentAddress, BitConverter.GetBytes(randomItem));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 1);
                                    currentAddress += 0x00000038;

                                    Console.WriteLine("Spawned backfloor item:" + randomItem + " Name: " + ItemNameTbl[randomItem]);
                                }
                                else
                                {
                                    randomItem = GetRandomLoot(FilterLootTable(backfloorItemTable));

                                    while (randomItem < 258)
                                        randomItem = GetRandomLoot(FilterLootTable(backfloorItemTable));

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

                if (Memory.ReadUShort(Addresses.buttonInputs) == 4096 && Player.InDungeonFloor() == true && Memory.ReadUInt(Addresses.dungeonDebugMenu) == 0)  //If DPadUp and in dungeon, go to previous element
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;
                    }
                }

                if ((Memory.ReadUShort(Addresses.buttonInputs) == 16384 && Player.InDungeonFloor() == true && Memory.ReadUInt(Addresses.dungeonDebugMenu) == 0))  //If DPadDOWN, go to next element
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
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
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private static byte[] displayMessage(string message)
        {
            //message =
            //    "Testing ABCDEFGHIJKLMNOPQRSTUVWXYZ\n" +
            //    "Testing ABCDEFGHIJKLMNOPQRSTUVWXYZ\n" +
            //    "Testing ABCDEFGHIJKLMNOPQRSTUVW";

            byte[] customMessage = Encoding.GetEncoding(10000).GetBytes(message);
            
            decimal maxNumLines = customMessage.Length / 28;

            byte[] outputMessage = new byte[customMessage.Length * 2];

            System.Math.Ceiling(maxNumLines);

            Console.WriteLine();
            Console.WriteLine("maxNumLines: " + maxNumLines);
            Console.WriteLine();
            Console.WriteLine("Custom  Message: " + BitConverter.ToString(customMessage));

            byte[] normalCharTable =
            {0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, //A-Z

            0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
            0x70, 0x71, 0x72, 0x73, 0x74 ,0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, //a-z

            //SPC
            0x20,
            
            //.    $      ?    !      %     &   \n
            0x2E, 0x24, 0x3F, 0x21, 0x25, 0x26, 0x0A

            };

            byte[] dcCharTable =
            {0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, //A-Z
            
            0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49,
            0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, //a-z

            //SPC
            0x02,

            //.    $    ?     !    %     &        \n
            0x6D, 0x6E, 0x59, 0x58, 0x60,  0x5B, 0x00
            
            };

            for (int i = 0; i < outputMessage.Length; i++)
            {
                outputMessage[i] = 0xFD;  //Initialize outputMessage to 0xFD and add new lines where appropriate
            }

            Console.WriteLine("Output  Message Initialized to: " + BitConverter.ToString(outputMessage));

            for (int i = 0; i < customMessage.Length; i++)
            {
                for (int t = 0; t < dcCharTable.Length; t++)
                {
                    if (customMessage[i] == normalCharTable[t])
                    {
                        if (normalCharTable[t] == 0x0A) //newLine
                        {
                            outputMessage[i * 2] = 0x00;
                            outputMessage[i *2 + 1] = 0xFF;
                            Console.WriteLine("New line detected.");
                        }

                        else if (normalCharTable[t] == 0x20) //SPC
                        {
                            outputMessage[i * 2] = 0x02;
                            outputMessage[i * 2 + 1] = 0xFF;
                        }

                        else
                            outputMessage[i * 2] = dcCharTable[t];
                    }
                }
            }
            Console.WriteLine(BitConverter.ToString(outputMessage));

            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            Memory.WriteByteArray(Addresses.dunMessage10, outputMessage);
            Thread.Sleep(50);
            Memory.WriteInt(Addresses.dunMessage, 10); //Display the 10th dungeon message
            Thread.Sleep(2000); //Wait two seconds
            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            Memory.WriteByteArray(Addresses.dunMessage10, originalDunMessage); //Revert message back to default

            return outputMessage;
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

        public static void Testing()
        {
            elementSwapThread.Start(); //Start thread
                dayChestThread.Start();

            //File.WriteAllBytes("Toan.mds", MemModel1_a);

            //byte[] Seda = File.ReadAllBytes("c07a.mds");

            //Memory.WriteByteArray(0x219A3420, Seda);
            
            //Console.WriteLine(string.Join("\n", FilterLootTable(ItemTbl1)));
            //FilterLootTable(ItemTblUnk);

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

            CallGameFunction(Addresses.functionBGMStop);
            Console.WriteLine("New Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));

            while (1 == 1)
            {
                int currentCharacter = Memory.ReadInt(Player.currentCharacter); //Read 4 bytes of currentCharacter value and check if Toan, Xiao, etc. Toan = 1680945251, Xiao = 1647587427

                if (Memory.ReadUInt(Addresses.dungeonClear) == 4294967281)
                {
                    Memory.WriteUInt(Addresses.dunMessage, 10); //Display dungeon leave message
                    Memory.WriteUInt(Addresses.dungeonClear, 0); //Change this value so that the message doesn't get written forever
                }

                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10); //Format the TimeSpan value.
                //Console.WriteLine("RunTime " + elapsedTime);

                if (Memory.ReadUShort(Addresses.buttonInputs) == 2319)  //If L1+L2+R1+R2+Select+Start is pressed, return to main menu
                {
                    Thread.Sleep(2000); //Wait two seconds
                    if ((Memory.ReadUShort(Addresses.buttonInputs) == 2319))  //Check again
                    {
                        if (Player.InDungeonFloor() == true)
                            Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                        else
                            Memory.WriteInt(Addresses.townSoftReset, 1); //If we are in town, this will take us to the main menu
                    }
                }

                if (Memory.ReadUShort(Addresses.buttonInputs) == 4111)  //If L1+L2+R1+R2+DpadUp is pressed, activate godmode
                {
                    Thread.Sleep(2000); //Wait two seconds
                    if (Memory.ReadUShort(Addresses.buttonInputs) == 4111)  //Check again
                    {
                        if (Player.InDungeonFloor() == true)
                        {
                            if (godMode == true)
                            {
                                godMode = false;
                                Memory.WriteByteArray(Addresses.dunMessage10, displayMessage("God Mode deactivated.             \n                    \nYou are no longer invincible to enemy damage."));
                            }

                            else if (godMode == false)
                            {
                                godMode = true;
                                displayMessage("God Mode activated.             \n                          \nYou are now invincible to enemy damage.      ");
                            }           
                        }
                    }
                }

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
