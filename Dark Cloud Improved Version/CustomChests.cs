using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class CustomChests
    {
        //these are tables used in Chest Randomizer mod, to be changed later
        static int[] tieroneitems = { 132, 133, 134, 135, 145, 146, 148, 151, 152, 153, 155, 160, 161, 162, 163, 164, 165, 166, 167, 169, 170, 174, 175, 177, 227, 233, 234, 245, 246, 247 };
        static int[] tiertwoitems = { 81, 82, 83, 84, 85, 92, 93, 94, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 147, 149, 154, 159, 168, 176, 186, 187, 188, 189, 190, 193, 193, 195, 196, 197, 198, 199, 201, 202, 203, 204, 205, 206, 235 };
        static int[] tierthreeitems = { 91, 96, 97, 98, 99, 100, 101, 103, 104, 105, 106, 150, 181, 183, 224, 225, 226, 228, 229, 230, 231 };
        static int[] tierfouritems = { 95, 102, 107, 136, 137, 138, 139, 140, 141, 178 };
        static int[] tiertrollitems = { 171, 172, 173, 180, 182, 191, 241, 248, };
        static int[] tieroneweapons = { 257, 258, 259, 260, 262, 265, 290, 299, 300, 301, 304, 314, 315, 316, 321, 328, 331, 332, 333, 335, 347, 348, 363, 364 };
        static int[] tiertwoweapons = { 261, 264, 270, 283, 284, 286, 291, 302, 303, 305, 319, 320, 327, 334, 349, 350, 359, 365, 374 };
        static int[] tierthreeweapons = { 263, 266, 269, 272, 278, 282, 287, 288, 293, 306, 307, 311, 317, 318, 336, 337, 339, 343, 344, 351, 352, 353, 360, 368, 375 };
        static int[] tierfourweapons = { 267, 271, 279, 281, 285, 289, 292, 294, 308, 312, 322, 338, 354, 369, 370 };
        static int[] tierfiveweapons = { 273, 274, 275, 276, 280, 309, 323, 340, 355, 356, 371, 372 };
        static int[] tiersixweapons = { 295, 296, 297, 324, 325, 341, 357, 373 };
        static int tiersevenweapon = 298;

        static int currentFloor;
        static int prevFloor;
        static int firstChestItem;
        static int chestSize;
        static int tierRoll;
        static int storeItem;
        static int itemValue;
        static int currentAddress;
        static int checkMimic;

        static int loop = 1;

        static Random rnd = new Random();
        

        public static void ChestRandomizer()
        {
            Console.WriteLine("Chest rando running");
            while (loop == 1) {          
                if (Player.inDungeonFloor() == true)
                {
                    currentFloor = Memory.ReadByte(Addresses.checkFloor);

                    if (currentFloor != prevFloor)  //checking if player has entered a new floor
                    {
                        Thread.Sleep(2000); //2 seconds, waiting for game to roll chests first before we change them

                        firstChestItem = Memory.ReadByte(Addresses.firstChest); ;

                        if (firstChestItem == 233)  //We check if first chest has the dungeon map. This is because if the floor has a locked door, the game would always place the key on first chest. Doing this check avoids player getting softlocked without the door key.
                        {
                            chestSize = rnd.Next(20);       //This is the chance for regular chest to be a big chest

                            if (chestSize != 0)     //if roll is not 0, give normal item
                            {
                                Memory.WriteByte(Addresses.firstChestSize, 1);

                                tierRoll = rnd.Next(50);    //used to randomize the tier rarity.

                                if (tierRoll == 0)
                                {
                                    storeItem = rnd.Next(0, tierfouritems.Length);
                                    itemValue = tierfouritems[storeItem];
                                }
                                else if (1 <= tierRoll && tierRoll <= 4)
                                {
                                    storeItem = rnd.Next(0, tierthreeitems.Length);
                                    itemValue = tierthreeitems[storeItem];
                                }
                                else if (5 <= tierRoll && tierRoll <= 20)
                                {
                                    storeItem = rnd.Next(0, tiertwoitems.Length);
                                    itemValue = tiertwoitems[storeItem];
                                }
                                else
                                {
                                    storeItem = rnd.Next(0, tieroneitems.Length);
                                    itemValue = tieroneitems[storeItem];
                                }

                                Memory.Write(Addresses.firstChest, BitConverter.GetBytes(itemValue));
                            }
                            else    //if rolled for weapon
                            {
                                Memory.WriteByte(Addresses.firstChestSize, 0);

                                tierRoll = rnd.Next(500);

                                if (tierRoll == 0)
                                {
                                    itemValue = tiersevenweapon;
                                }
                                else if (1 <= tierRoll && tierRoll <= 5)
                                {
                                    storeItem = rnd.Next(0, tiersixweapons.Length);
                                    itemValue = tiersixweapons[storeItem];
                                }
                                else if (6 <= tierRoll && tierRoll <= 15)
                                {
                                    storeItem = rnd.Next(0, tierfiveweapons.Length);
                                    itemValue = tierfiveweapons[storeItem];
                                }
                                else if (16 <= tierRoll && tierRoll <= 40)
                                {
                                    storeItem = rnd.Next(0, tierfourweapons.Length);
                                    itemValue = tierfourweapons[storeItem];
                                }
                                else if (41 <= tierRoll && tierRoll <= 90)
                                {
                                    storeItem = rnd.Next(0, tierthreeweapons.Length);
                                    itemValue = tierthreeweapons[storeItem];
                                }
                                else if (91 <= tierRoll && tierRoll <= 200)
                                {
                                    storeItem = rnd.Next(0, tiertwoweapons.Length);
                                    itemValue = tiertwoweapons[storeItem];
                                }
                                else
                                {
                                    storeItem = rnd.Next(0, tieroneweapons.Length);
                                    itemValue = tieroneweapons[storeItem];
                                }

                                Memory.Write(Addresses.firstChest, BitConverter.GetBytes(itemValue));

                            }
                        }


                        currentAddress = Addresses.firstChest + 0x00000040;     //using the offset to reach 2nd chest

                        for (int i = 0; i < 7; i++)     //going through rest of chests using offsets
                        {
                            checkMimic = Memory.ReadShort(currentAddress);

                            if (checkMimic > 40)    //for some reason, when game spawns mimics it gives them really low item ID, and low ID's are only used in JP version. This checks for potential mimic spawns.
                            {
                                chestSize = rnd.Next(20);

                                if (chestSize != 0)     //if roll is not 0, give normal item
                                {

                                    tierRoll = rnd.Next(50);    //used to randomize the tier rarity.

                                    if (tierRoll == 0)
                                    {
                                        storeItem = rnd.Next(0, tierfouritems.Length);
                                        itemValue = tierfouritems[storeItem];
                                    }
                                    else if (1 <= tierRoll && tierRoll <= 4)
                                    {
                                        storeItem = rnd.Next(0, tierthreeitems.Length);
                                        itemValue = tierthreeitems[storeItem];
                                    }
                                    else if (5 <= tierRoll && tierRoll <= 20)
                                    {
                                        storeItem = rnd.Next(0, tiertwoitems.Length);
                                        itemValue = tiertwoitems[storeItem];
                                    }
                                    else
                                    {
                                        storeItem = rnd.Next(0, tieroneitems.Length);
                                        itemValue = tieroneitems[storeItem];
                                    }

                                    Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 1);
                                    currentAddress += 0x00000038;

                                    Console.WriteLine("Spawned item:" + itemValue);
                                }
                                else    //if rolled for weapon
                                {

                                    tierRoll = rnd.Next(500);

                                    if (tierRoll == 0)
                                    {
                                        itemValue = tiersevenweapon;
                                    }
                                    else if (1 <= tierRoll && tierRoll <= 5)
                                    {
                                        storeItem = rnd.Next(0, tiersixweapons.Length);
                                        itemValue = tiersixweapons[storeItem];
                                    }
                                    else if (6 <= tierRoll && tierRoll <= 15)
                                    {
                                        storeItem = rnd.Next(0, tierfiveweapons.Length);
                                        itemValue = tierfiveweapons[storeItem];
                                    }
                                    else if (16 <= tierRoll && tierRoll <= 40)
                                    {
                                        storeItem = rnd.Next(0, tierfourweapons.Length);
                                        itemValue = tierfourweapons[storeItem];
                                    }
                                    else if (41 <= tierRoll && tierRoll <= 90)
                                    {
                                        storeItem = rnd.Next(0, tierthreeweapons.Length);
                                        itemValue = tierthreeweapons[storeItem];
                                    }
                                    else if (91 <= tierRoll && tierRoll <= 200)
                                    {
                                        storeItem = rnd.Next(0, tiertwoweapons.Length);
                                        itemValue = tiertwoweapons[storeItem];
                                    }
                                    else
                                    {
                                        storeItem = rnd.Next(0, tieroneweapons.Length);
                                        itemValue = tieroneweapons[storeItem];
                                    }

                                    Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 0);
                                    currentAddress += 0x00000038;

                                }
                            }
                            else
                            {
                                currentAddress += 0x00000040;
                            }
                        }

                        currentAddress = Addresses.backfloorFirstChest;

                        for (int i = 0; i < 7; i++)
                        {
                            chestSize = rnd.Next(25);

                            checkMimic = Memory.ReadShort(currentAddress);

                            if (checkMimic > 40)
                            {
                                if (chestSize != 0)
                                {

                                    tierRoll = rnd.Next(80);

                                    if (tierRoll == 0)
                                    {
                                        storeItem = rnd.Next(0, tiertrollitems.Length);
                                        itemValue = tiertrollitems[storeItem];
                                    }
                                    else if (1 <= tierRoll && tierRoll <= 8)
                                    {
                                        storeItem = rnd.Next(0, tierfouritems.Length);
                                        itemValue = tierfouritems[storeItem];
                                    }
                                    else if (9 <= tierRoll && tierRoll <= 40)
                                    {
                                        storeItem = rnd.Next(0, tierthreeitems.Length);
                                        itemValue = tierthreeitems[storeItem];
                                    }
                                    else
                                    {
                                        storeItem = rnd.Next(0, tiertwoitems.Length);
                                        itemValue = tiertwoitems[storeItem];
                                    }

                                    Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 1);
                                    currentAddress += 0x00000038;

                                    Console.WriteLine("Spawned backfloor item:" + itemValue);

                                }
                                else
                                {

                                    tierRoll = rnd.Next(250);

                                    if (tierRoll == 0)
                                    {
                                        itemValue = tiersevenweapon;
                                    }
                                    else if (1 <= tierRoll && tierRoll <= 5)
                                    {
                                        storeItem = rnd.Next(0, tiersixweapons.Length);
                                        itemValue = tiersixweapons[storeItem];
                                    }
                                    else if (6 <= tierRoll && tierRoll <= 15)
                                    {
                                        storeItem = rnd.Next(0, tierfiveweapons.Length);
                                        itemValue = tierfiveweapons[storeItem];
                                    }
                                    else if (16 <= tierRoll && tierRoll <= 40)
                                    {
                                        storeItem = rnd.Next(0, tierfourweapons.Length);
                                        itemValue = tierfourweapons[storeItem];
                                    }
                                    else if (41 <= tierRoll && tierRoll <= 90)
                                    {
                                        storeItem = rnd.Next(0, tierthreeweapons.Length);
                                        itemValue = tierthreeweapons[storeItem];
                                    }
                                    else
                                    {
                                        storeItem = rnd.Next(0, tiertwoweapons.Length);
                                        itemValue = tiertwoweapons[storeItem];
                                    }

                                    Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                                    currentAddress += 0x00000008;
                                    Memory.WriteByte(currentAddress, 0);
                                    currentAddress += 0x00000038;

                                }

                            }
                            else
                            {
                                currentAddress += 0x00000040;
                            }


                        }
                        prevFloor = currentFloor;   //once everything is done, we initialize this so it wont reroll again in same floor
                    }


                }
                else
                {
                    prevFloor = 200;    //used to reset the floor data when going back to dungeon
                }
            }
        }
    }
}
