using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    public class CustomChests
    {
        public static int[] dbcFirstHalfItems = { 145, 146, 147, 148, 148, 155, 149, 159, 181, 178, 150, 151, 151, 224, 199, 197, 186, 187, 188, 189, 190, 152, 153, 177, 177, 177, 174, 224, 155, 175, 177, 175, 174, 91, 92, 93, 94, 81, 82, 83, 84, 85, 112, 117, 114, 224, 135, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170 };
        public static int[] dbcSecondfHalfItems = { 145, 146, 147, 148, 148, 155, 149, 159, 181, 178, 150, 151, 151, 224, 199, 197, 186, 187, 188, 189, 190, 152, 153, 177, 177, 224, 174, 176, 155, 175, 91, 92, 93, 94, 81, 82, 83, 84, 85, 111, 119, 120, 224, 135, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170 };
        public static int[] wiseowlFirstHalfItems = { 177, 177, 175, 176, 174, 181, 178, 148, 155, 149, 145, 146, 147, 159, 199, 197, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 160, 160, 225, 225, 150, 178, 225, 225, 225, 225, 150, 151, 151, 152, 153, 154, 132, 133, 134, 135, 235, 166, 167, 168, 169, 170, 148 };
        public static int[] wiseowlSecondHalfItems = { 177, 177, 175, 176, 174, 181, 178, 148, 155, 149, 145, 146, 147, 159, 199, 197, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 150, 178, 225, 225, 225, 225, 150, 151, 151, 152, 153, 154, 132, 133, 134, 135, 235, 166, 167, 168, 169, 170, 148 };
        public static int[] shipwreckFirstHalfItems = { 177, 177, 175, 176, 174, 178, 181, 235, 148, 155, 149, 145, 146, 147, 159, 150, 151, 151, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 226, 226, 245, 132, 133, 134, 135, 148 };
        public static int[] shipwreckSecondHalfItems = { 177, 177, 175, 176, 174, 178, 181, 235, 148, 155, 149, 145, 146, 147, 159, 150, 151, 151, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 226, 226, 245, 132, 133, 134, 135, 148 };
        public static int[] sunmoonFirstHalfItems = { 177, 177, 175, 176, 174, 181, 178, 235, 228, 155, 149, 145, 146, 147, 159, 150, 151, 228, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 228, 132, 133, 134, 135 };
        public static int[] sunmoonSecondHalfItems = { 177, 177, 175, 176, 174, 181, 178, 235, 228, 155, 149, 145, 146, 147, 159, 150, 151, 228, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 228, 132, 133, 134, 135 };
        public static int[] moonseaFirstHalfItems = { 177, 177, 175, 176, 174, 181, 178, 235, 229, 155, 149, 145, 146, 147, 159, 150, 151, 229, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 229, 132, 133, 134, 135 };
        public static int[] moonseaSecondHalfItems = { 177, 177, 175, 176, 174, 181, 178, 235, 229, 155, 149, 145, 146, 147, 159, 150, 151, 229, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 229, 132, 133, 134, 135 };
        public static int[] galleryItems = { 177, 177, 175, 176, 174, 181, 178, 235, 155, 149, 145, 146, 147, 159, 150, 151, 230, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 91, 92, 93, 94, 81, 82, 83, 84, 85, 230, 132, 133, 134, 135, 230 };
        public static int[] demonshaftItems = { 177, 177, 175, 176, 174, 231, 178, 235, 155, 149, 145, 146, 147, 159, 150, 231, 151, 152, 153, 166, 167, 168, 169, 170, 154, 199, 197, 193, 186, 187, 188, 189, 190, 161, 162, 163, 164, 165, 231, 231, 231, 94, 81, 82, 83, 84, 85, 91, 132, 133, 134, 135 };
        
        public static int[] dbcFirstHalfWeapons = { 259, 260, 262, 290 };
        public static int[] dbcSecondHalfWeapons = { 259, 260, 262, 270, 290, 301, 304 };
        public static int[] wiseowlFirstHalfWeapons = { 264, 270, 283, 284, 286, 291, 301, 303, 304 };
        public static int[] wiseowlSecondHalfWeapons = { 264, 270, 283, 284, 286, 291, 301, 303, 304, 316, 321, 328 };
        public static int[] shipwreckFirstHalfWeapons = { 261, 265, 282, 284, 286, 302, 305, 316, 319, 327, 328 };
        public static int[] shipwreckSecondHalfWeapons = { 261, 265, 282, 284, 286, 302, 305, 319, 327, 328, 333, 335, 343 };
        public static int[] sunmoonFirstHalfWeapons = { 263, 272, 282, 288, 293, 306, 318, 334, 337, 344 };
        public static int[] sunmoonSecondHalfWeapons = { 263, 272, 282, 288, 293, 306, 318, 334, 337, 344, 349, 350, 359 };
        public static int[] moonseaFirstHalfWeapons = { 272, 288, 281, 307, 322, 334, 344, 351, 352, 353 };
        public static int[] moonseaSecondHalfWeapons = { 272, 288, 281, 307, 322, 334, 344, 351, 352, 353, 365, 374 };
        public static int[] galleryWeapons = { 274, 281, 285, 292, 294, 308, 322, 336, 338, 339, 354, 360, 368, 375 };
        public static int[] demonshaftWeapons = { 276, 273, 275, 281, 285, 309, 311, 323, 325, 340, 338, 355, 359, 370, 371 };

        //backfloor loot table same in all dungeons from DBC to gallery (need to check demon shaft)
        static int[] BackfloorItems = { 91, 92, 93, 94, 81, 82, 83, 84, 85, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 161, 162, 163, 164, 165, 150, 151, 152, 153, 154, 132, 133, 134, 135, 235, 166, 167, 168, 169, 170, 178 };

        static int[] clownCommonBigTable = { 148, 155, 149, 146, 147, 132, 133, 134, 135 };
        static int[] clownCommonSmallTable = { 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 186, 187, 188, 189, 190, 197, 199, 224 };

        static int[] currentClownBigWeaponsTable;
        static int[] currentClownSmallWeaponsTable;

        static int currentBigBoxAddressArea;
        static int currentSmallBoxAddressArea;
        static int currentBackFloorBigBoxAddressArea;
        static int currentBackFloorSmallBoxAddressArea;

        static int[] dbcFirstHalfClownBigWeapons = { 264, 270, 283, 291 };
        static int[] dbcSecondHalfClownBigWeapons = { 264, 283, 291 };
        static int[] dbcSecondHalfClownSmallWeapons = { 303, 303 };
        static int[] wiseowlFirstHalfClownBigWeapons = { 261, 265, 286 };
        static int[] wiseowlFirstHalfClownSmallWeapons = { 302, 305 };
        static int[] wiseowlSecondHalfClownBigWeapons = { 261, 265, 286, 319, 320, 327 };
        static int[] wiseowlSecondHalfClownSmallWeapons = { 302, 305 };
        static int[] shipwreckFirstHalfClownBigWeapons = { 263, 288, 293, 318, 327 };
        static int[] shipwreckFirstHalfClownSmallWeapons = { 302, 306 };
        static int[] shipwreckSecondHalfClownBigWeapons = { 263, 288, 293, 318, 327 };
        static int[] shipwreckSecondHalfClownSmallWeapons = { 302, 306, 334, 337, 344 };
        static int[] sunmoonFirstHalfClownBigWeapons = { 272, 288, 322 };
        static int[] sunmoonFirstHalfClownSmallWeapons = { 307, 334, 344 };
        static int[] sunmoonSecondHalfClownBigWeapons = { 272, 288, 322, 351, 352, 353 };
        static int[] sunmoonSecondHalfClownSmallWeapons = { 307, 334, 344 };
        static int[] moonseaFirstHalfClownBigWeapons = { 274, 285, 292, 294, 323, 354, 360 };
        static int[] moonseaFirstHalfClownSmallWeapons = { 308, 312, 336, 338, 339 };
        static int[] moonseaSecondHalfClownBigWeapons = { 274, 285, 292, 294, 323, 354, 360 };
        static int[] moonseaSecondHalfClownSmallWeapons = { 308, 312, 336, 338, 339, 368, 375 };
        static int[] galleryClownBigWeapons = { 276, 273, 294, 285, 323, 355 };
        static int[] galleryClownSmallWeapons = { 312, 336, 338, 339, 369, 370, 371 };
        static int[] demonshaftClownBigWeapons = { 295, 296, 297, 324, 356, 357 };
        static int[] demonshaftClownSmallWeapons = { 309, 340, 341, 372, 373 };

        static int[] currentItemTable;
        static int[] currentWeaponTable;

        static bool itemQuestSpawn = false;
        static bool itemQuestSpawned = false;
        static byte itemQuestitemID;

        static int currentFloor;
        static int prevFloor;
        static int firstChestItem;
        static int chestSize;
        static int tierRoll;
        static int storeItem;
        static int itemValue;
        static int currentAddress;
        static int checkMimic;
        static int trapRoll;
        static int luckRoll;
        static int randomItem;
        static int randomItemValue;
        static int boxItemAddress;
        static int bigChestChance;
        static int luckyTableChance;

        static bool hasMap;
        static bool hasMC;

        static int loop = 1;

        static Random rnd = new Random();

        public static int[] GetBackFloorItems()
        {
            return BackfloorItems;
        }

        public static int[] GetDungeonWeaponsTable(byte dungeon, byte floor)
        {
            switch (dungeon)
            {
                case 0:
                    if (floor <= 8) { return dbcFirstHalfWeapons; } else return dbcSecondHalfWeapons;

                case 1:
                    if (floor <= 9) { return wiseowlFirstHalfWeapons; } else return wiseowlSecondHalfWeapons;

                case 2:
                    if (floor <= 9) { return shipwreckFirstHalfWeapons; } else return shipwreckSecondHalfWeapons;

                case 3:
                    if (floor <= 9) { return sunmoonFirstHalfWeapons; } else return sunmoonSecondHalfWeapons;

                case 4:
                    if (floor <= 8) { return moonseaFirstHalfWeapons; } else return moonseaSecondHalfWeapons;

                case 5:
                    return galleryWeapons;

                case 6:
                    return demonshaftWeapons;

                default:
                    return null;
            }
        }

        public static void ChestRandomizer(int currentDungeon, int currentFloor, bool chronicle2)
        {
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Custom chests activated");
            itemQuestSpawn = false;
            Thread.Sleep(100);

            switch (currentDungeon)
            {
                case 0:

                    if (currentFloor <= 8)
                    {
                        currentItemTable = dbcFirstHalfItems;
                        currentWeaponTable = dbcFirstHalfWeapons;
                        currentClownBigWeaponsTable = dbcFirstHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = clownCommonSmallTable;
                        currentBigBoxAddressArea = 0x20276418;
                        currentSmallBoxAddressArea = 0x20276518;
                        currentBackFloorBigBoxAddressArea = 0x20278088;
                        currentBackFloorSmallBoxAddressArea = 0x20278188;
                    }
                    else if (currentFloor > 8)
                    {
                        currentItemTable = dbcSecondfHalfItems;
                        currentWeaponTable = dbcSecondHalfWeapons;
                        currentClownBigWeaponsTable = dbcSecondHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = dbcSecondHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20276620;
                        currentSmallBoxAddressArea = 0x20276720;
                        currentBackFloorBigBoxAddressArea = 0x20278290;
                        currentBackFloorSmallBoxAddressArea = 0x20278390;
                    }

                    if (Memory.ReadByte(0x21CE4451) == 1) //laura quest check
                    {
                        RollItemQuest(171);
                    }                     
                    break;

                case 1:

                    if (currentFloor <= 9)
                    {
                        currentItemTable = wiseowlFirstHalfItems;
                        currentWeaponTable = wiseowlFirstHalfWeapons;
                        currentClownBigWeaponsTable = wiseowlFirstHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = wiseowlFirstHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20276828;
                        currentSmallBoxAddressArea = 0x20276928;
                        currentBackFloorBigBoxAddressArea = 0x20278498;
                        currentBackFloorSmallBoxAddressArea = 0x20278598;
                        clownCommonSmallTable[23] = 225;
                    }
                    else if (currentFloor > 9)
                    {
                        currentItemTable = wiseowlSecondHalfItems;
                        currentWeaponTable = wiseowlSecondHalfWeapons;
                        currentClownBigWeaponsTable = wiseowlSecondHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = wiseowlSecondHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20276A30;
                        currentSmallBoxAddressArea = 0x20276B30;
                        currentBackFloorBigBoxAddressArea = 0x202786A0;
                        currentBackFloorSmallBoxAddressArea = 0x202787A0;
                        clownCommonSmallTable[23] = 225;
                    }
                    if (Memory.ReadByte(0x21CE4452) == 1) //ro quest check
                    {
                        RollItemQuest(173);
                    }
                    break;

                case 2:

                    if (currentFloor <= 9)
                    {
                        currentItemTable = shipwreckFirstHalfItems;
                        currentWeaponTable = shipwreckFirstHalfWeapons;
                        currentClownBigWeaponsTable = shipwreckFirstHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = shipwreckFirstHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20276C38;
                        currentSmallBoxAddressArea = 0x20276D38;
                        currentBackFloorBigBoxAddressArea = 0x202788A8;
                        currentBackFloorSmallBoxAddressArea = 0x202789A8;
                        clownCommonSmallTable[23] = 226;
                    }
                    else if (currentFloor > 9)
                    {
                        currentItemTable = shipwreckSecondHalfItems;
                        currentWeaponTable = shipwreckSecondHalfWeapons;
                        currentClownBigWeaponsTable = shipwreckSecondHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = shipwreckSecondHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20276E40;
                        currentSmallBoxAddressArea = 0x20276F40;
                        currentBackFloorBigBoxAddressArea = 0x20278AB0;
                        currentBackFloorSmallBoxAddressArea = 0x20278BB0;
                        clownCommonSmallTable[23] = 226;
                    }
                    if (Memory.ReadByte(0x21CE4453) == 1) //phil quest check
                    {
                        RollItemQuest(243);
                    }
                    break;

                case 3:

                    if (currentFloor <= 9)
                    {
                        currentItemTable = sunmoonFirstHalfItems;
                        currentWeaponTable = sunmoonFirstHalfWeapons;
                        currentClownBigWeaponsTable = sunmoonFirstHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = sunmoonFirstHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20277048;
                        currentSmallBoxAddressArea = 0x20277148;
                        currentBackFloorBigBoxAddressArea = 0x20278CB8;
                        currentBackFloorSmallBoxAddressArea = 0x20278DB8;
                        clownCommonSmallTable[23] = 228;
                    }
                    else if (currentFloor > 9)
                    {
                        currentItemTable = sunmoonSecondHalfItems;
                        currentWeaponTable = sunmoonSecondHalfWeapons;
                        currentClownBigWeaponsTable = sunmoonSecondHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = sunmoonSecondHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20277250;
                        currentSmallBoxAddressArea = 0x20277350;
                        currentBackFloorBigBoxAddressArea = 0x20278EC0;
                        currentBackFloorSmallBoxAddressArea = 0x20278FC0;
                        clownCommonSmallTable[23] = 228;
                    }
                    if (Memory.ReadByte(0x21CE4454) == 1) //zabo quest check
                    {
                        RollItemQuest(172);
                    }
                    break;

                case 4:

                    if (currentFloor <= 8)
                    {
                        currentItemTable = moonseaFirstHalfItems;
                        currentWeaponTable = moonseaFirstHalfWeapons;
                        currentClownBigWeaponsTable = moonseaFirstHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = moonseaFirstHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20277458;
                        currentSmallBoxAddressArea = 0x20277558;
                        currentBackFloorBigBoxAddressArea = 0x202790C8;
                        currentBackFloorSmallBoxAddressArea = 0x202791C8;
                        clownCommonSmallTable[23] = 229;
                    }
                    else if (currentFloor > 8)
                    {
                        currentItemTable = moonseaSecondHalfItems;
                        currentWeaponTable = moonseaSecondHalfWeapons;
                        currentClownBigWeaponsTable = moonseaSecondHalfClownBigWeapons;
                        currentClownSmallWeaponsTable = moonseaSecondHalfClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20277660;
                        currentSmallBoxAddressArea = 0x20277760;
                        currentBackFloorBigBoxAddressArea = 0x202792D0;
                        currentBackFloorSmallBoxAddressArea = 0x202793D0;
                        clownCommonSmallTable[23] = 229;
                    }
                    break;

                case 5:

                    currentItemTable = galleryItems;
                    currentWeaponTable = galleryWeapons;
                    currentClownBigWeaponsTable = galleryClownBigWeapons;
                    currentClownSmallWeaponsTable = galleryClownSmallWeapons;
                    
                    if (currentFloor <= 11)
                    {
                        currentBigBoxAddressArea = 0x20277868;
                        currentSmallBoxAddressArea = 0x20277968;
                        currentBackFloorBigBoxAddressArea = 0x202794D8;
                        currentBackFloorSmallBoxAddressArea = 0x202795D8;
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "currentFloor: " + currentFloor);
                    }
                    else
                    {
                        currentBigBoxAddressArea = 0x20277A70;
                        currentSmallBoxAddressArea = 0x20277B70;
                        currentBackFloorBigBoxAddressArea = 0x202796E0;
                        currentBackFloorSmallBoxAddressArea = 0x202797E0;
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "currentFloor: " + currentFloor);
                    }
                    clownCommonSmallTable[23] = 230;

                    break;

                case 6:

                    if (currentFloor <= 49)
                    {
                        demonshaftItems[5] = 231;
                        currentItemTable = demonshaftItems;
                        currentWeaponTable = demonshaftWeapons;
                        currentClownBigWeaponsTable = demonshaftClownBigWeapons;
                        currentClownSmallWeaponsTable = demonshaftClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20277C78;
                        currentSmallBoxAddressArea = 0x20277D78;
                        currentBackFloorBigBoxAddressArea = 0x202798E8;
                        currentBackFloorSmallBoxAddressArea = 0x202799E8;
                    }
                    else
                    {
                        demonshaftItems[5] = 181;
                        currentItemTable = demonshaftItems;
                        currentWeaponTable = demonshaftWeapons;
                        currentClownBigWeaponsTable = demonshaftClownBigWeapons;
                        currentClownSmallWeaponsTable = demonshaftClownSmallWeapons;
                        currentBigBoxAddressArea = 0x20277E80;
                        currentSmallBoxAddressArea = 0x20277F80;
                        currentBackFloorBigBoxAddressArea = 0x20279AF0;
                        currentBackFloorSmallBoxAddressArea = 0x20279BF0;
                    }
                    //Demon shaft F1-50 0x202732D0

                    if (Memory.ReadByte(0x21CE4455) == 1) //demon shaft quest check
                    {
                        RollItemQuest(241, 85);
                    }

                    break;

            }

            int bigChestModifier = 15 * currentDungeon;

            bigChestChance = 880 + bigChestModifier;

            if (chronicle2)
            {
                bigChestModifier = (1000 - bigChestChance);
                bigChestChance -= bigChestModifier;   
            }

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Big chest chance: " + bigChestChance);

            hasMap = SideQuestManager.CheckItemQuestReward(233, true, false);
            hasMC = SideQuestManager.CheckItemQuestReward(234, true, false);

            firstChestItem = Memory.ReadByte(Addresses.firstChest);
            int offset;

            if (firstChestItem == 233)  //We check if first chest has the dungeon map. This is because if the floor has a locked door, the game would always place the key on first chest. Doing this check avoids player getting softlocked without the door key.
            {
                if (hasMap || hasMC)
                {
                    offset = 0x00000000;
                }
                else
                {
                    offset = 0x00000080;
                }
            }
            else
            {
                if (hasMap || hasMC)
                {
                    offset = 0x00000040;
                }
                else
                {
                    offset = 0x000000C0;
                }
            }


            currentAddress = Addresses.firstChest + offset;     //using the offset to reach 2nd chest

            
            for (int i = 0; i < 8; i++)     //going through rest of chests using offsets
            {
                bool spawnItem = true;

                if (i == 0 || i == 1)
                {
                    if (hasMap || hasMC)
                    {
                        if (i == 0 && hasMap)
                        {
                            spawnItem = true;
                        }
                        else if (i == 1 && hasMC)
                        {
                            spawnItem = true;
                        }
                        else
                        {
                            spawnItem = false;
                        }
                    }
                }



                if (spawnItem)
                {
                    checkMimic = Memory.ReadShort(currentAddress);

                    if (checkMimic > 40)    //for some reason, when game spawns mimics it gives them really low item ID, and low ID's are only used in JP version. This checks for potential mimic spawns.
                    {
                        chestSize = rnd.Next(1000);

                        if (chestSize < bigChestChance)
                        {
                            storeItem = rnd.Next(0, currentItemTable.Length);
                            itemValue = currentItemTable[storeItem];

                            if (itemValue == 178 && !chronicle2)
                            {
                                int successrate = rnd.Next(100);
                                if (successrate < 80)
                                {
                                    storeItem = rnd.Next(0, currentItemTable.Length);
                                    itemValue = currentItemTable[storeItem];
                                }
                            }

                            Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                            currentAddress += 0x00000008;
                            Memory.WriteByte(currentAddress, 1);
                            currentAddress += 0x00000038;

                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned item:" + itemValue);
                        }
                        else    //if rolled for weapon
                        {
                            storeItem = rnd.Next(0, currentWeaponTable.Length);
                            itemValue = currentWeaponTable[storeItem];


                            Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                            currentAddress += 0x00000008;
                            Memory.WriteByte(currentAddress, 0);

                            currentAddress += 0x00000008;

                            trapRoll = rnd.Next(6); //roll for big chest trap/clown
                            Memory.Write(currentAddress, BitConverter.GetBytes(trapRoll));

                            currentAddress += 0x00000030;

                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned weapon:" + itemValue);
                        }
                    }
                    else
                    {
                        currentAddress += 0x00000040;
                    }
                }
                else
                {
                    currentAddress += 0x00000040;
                }
            }

            currentAddress = Addresses.backfloorFirstChest;

            itemQuestSpawned = false;

            for (int i = 0; i < 7; i++)
            {
                chestSize = rnd.Next(1000);

                checkMimic = Memory.ReadShort(currentAddress);

                if (checkMimic > 40)
                {
                    if (chestSize < bigChestChance)
                    {
                        storeItem = rnd.Next(0, BackfloorItems.Length);
                        itemValue = BackfloorItems[storeItem];

                        if (itemValue == 178)
                        {
                            int successrate = rnd.Next(100);
                            if (successrate < 80)
                            {
                                storeItem = rnd.Next(0, BackfloorItems.Length);
                                itemValue = BackfloorItems[storeItem];
                            }
                        }

                        if (itemQuestSpawn) //check if current dng has item fetch quest unlocked & item was rolled successfully
                        {
                            if (itemQuestSpawned == false)
                            {
                                itemValue = itemQuestitemID;
                                itemQuestSpawned = true;
                            }
                        }

                        Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                        currentAddress += 0x00000008;
                        Memory.WriteByte(currentAddress, 1);
                        currentAddress += 0x00000038;

                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned backfloor item:" + itemValue);

                    }
                    else
                    {

                        storeItem = rnd.Next(0, currentWeaponTable.Length);
                        itemValue = currentWeaponTable[storeItem];

                        Memory.Write(currentAddress, BitConverter.GetBytes(itemValue));
                        currentAddress += 0x00000008;
                        Memory.WriteByte(currentAddress, 0);
                        currentAddress += 0x00000008;

                        trapRoll = rnd.Next(6); //roll for big chest trap/clown
                        Memory.Write(currentAddress, BitConverter.GetBytes(trapRoll));

                        currentAddress += 0x00000030;

                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Spawned backfloor weapon:" + itemValue);
                    }



                }
                else
                {
                    currentAddress += 0x00000040;
                }
            }

            if (hasMap)
            {
                Memory.WriteByte(Addresses.map, 1);
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Player has Map item");
            }
            if (hasMC)
            {
                Memory.WriteByte(Addresses.magicCrystal, 1);
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Player has Magical Crystal item");
            }
        }

        public static void ClownRandomizer(bool chronicle2)
        {
            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Clown spawned!");

            if (chronicle2)
                luckyTableChance = 0;
            else
                luckyTableChance = 50;

            if (Memory.ReadByte(0x202A34B4) == 0) //check if on backfloor
            {
                luckRoll = rnd.Next(100);   //big box table roll

                if (luckRoll >= luckyTableChance) //if lucky, weapon table
                {
                    randomItem = rnd.Next(0, currentClownBigWeaponsTable.Length);
                    randomItemValue = currentClownBigWeaponsTable[randomItem];

                    boxItemAddress = currentBigBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255) //replace all clown's rewards with rolled item
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                else //if unlucky, common table
                {
                    randomItem = rnd.Next(0, clownCommonBigTable.Length);
                    randomItemValue = clownCommonBigTable[randomItem];

                    boxItemAddress = currentBigBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255) //replace all clown's rewards with rolled item
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Big box item: " + randomItemValue);

                luckRoll = rnd.Next(100); //small box table roll

                if (luckRoll >= luckyTableChance)
                {
                    randomItem = rnd.Next(0, currentClownSmallWeaponsTable.Length);
                    randomItemValue = currentClownSmallWeaponsTable[randomItem];

                    boxItemAddress = currentSmallBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255)
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                else
                {
                    randomItem = rnd.Next(0, clownCommonSmallTable.Length);
                    randomItemValue = clownCommonSmallTable[randomItem];

                    boxItemAddress = currentSmallBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255)
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Small box item: " + randomItemValue);
            }
            else
            {
                luckRoll = rnd.Next(100);   //big box table roll

                if (luckRoll >= luckyTableChance) //if lucky, weapon table
                {
                    randomItem = rnd.Next(0, currentClownBigWeaponsTable.Length);
                    randomItemValue = currentClownBigWeaponsTable[randomItem];

                    boxItemAddress = currentBackFloorBigBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255) //replace all clown's rewards with rolled item
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                else //if unlucky, common table
                {
                    randomItem = rnd.Next(0, clownCommonBigTable.Length);
                    randomItemValue = clownCommonBigTable[randomItem];

                    boxItemAddress = currentBackFloorBigBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255) //replace all clown's rewards with rolled item
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Big box item: " + randomItemValue);

                luckRoll = rnd.Next(100); //small box table roll

                if (luckRoll >= luckyTableChance)
                {
                    randomItem = rnd.Next(0, currentClownSmallWeaponsTable.Length);
                    randomItemValue = currentClownSmallWeaponsTable[randomItem];

                    boxItemAddress = currentBackFloorSmallBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255)
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                else
                {
                    randomItem = rnd.Next(0, clownCommonSmallTable.Length);
                    randomItemValue = clownCommonSmallTable[randomItem];

                    boxItemAddress = currentBackFloorSmallBoxAddressArea;

                    while (Memory.ReadByte(boxItemAddress) != 255)
                    {
                        Memory.WriteInt(boxItemAddress, randomItemValue);
                        boxItemAddress += 0x00000004;
                    }
                }
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Small box item: " + randomItemValue);
            }
        }

        public static void RollItemQuest(byte itemQuestID, byte currentItemChance = 66)
        {
            int secretItemChance = rnd.Next(0, 100);
            if (secretItemChance > currentItemChance)
            {
                bool alreadyhasItem = SideQuestManager.CheckItemQuestReward(itemQuestID);
                if (alreadyhasItem == false)
                {
                    itemQuestSpawn = true;
                    itemQuestitemID = itemQuestID;
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Rolled sidequest secret item for this floor");
                }
                else
                {
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Player already has sidequest secret item");
                }
            }
        }
    }
}
