using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    public class DailyShopItem
    {
        public static int[] gems = { 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106 };

        public static int[] gafferDay1 = { 181, 224 };
        public static int[] gafferDay2 = gems;
        public static int[] gafferDay3 = { 197, 199 };
        public static int[] gafferDay4 = { 132, 133, 134, 135, 150, 154 };
        public static int[] gafferDay5 = CustomChests.dbcSecondHalfWeapons;
        public static int[][] gafferRotation = { gafferDay1, gafferDay2, gafferDay3, gafferDay4, gafferDay5 };

        public static int[] wiseowlDay1 = { 186, 188, 189 };
        public static int[] wiseowlDay2 = { 132, 133, 134, 135, 150, 154 };
        public static int[] wiseowlDay3 = CustomChests.wiseowlSecondHalfWeapons;
        public static int[] wiseowlDay4 = { 181, 225 };
        public static int[] wiseowlDay5 = gems;
        public static int[][] wiseowlRotation = { wiseowlDay1, wiseowlDay2, wiseowlDay3, wiseowlDay4, wiseowlDay5 };

        public static int[] jackDay1 = CustomChests.shipwreckSecondHalfWeapons;
        public static int[][] jackRotation = { jackDay1, jackDay1, jackDay1, jackDay1, jackDay1 };

        public static int[] jokerDay1 = gems;
        public static int[] jokerDay2 = { 186, 188, 189, 197, 199 };
        public static int[] jokerDay3 = { 132, 133, 134, 135, 150, 154 };
        public static int[] jokerDay4 = { 111, 112, 113, 114, 115, 116, 117, 118, 119, 120 };
        public static int[] jokerDay5 = { 181 };
        public static int[][] jokerRotation = { jokerDay1, jokerDay2, jokerDay3, jokerDay4, jokerDay5 };
       
        public static int[] brookeDay1 = { 132, 133, 134, 135, 150 };
        public static int[] brookeDay2 = CustomChests.sunmoonSecondHalfWeapons;
        public static int[] brookeDay3 = { 181, 228 };
        public static int[] brookeDay4 = gems;
        public static int[] brookeDay5 = { 169, 186, 188, 189, 193, 197, 199 };
        public static int[][] brookeRotation = { brookeDay1, brookeDay2, brookeDay3, brookeDay4, brookeDay5 };

        public static int[] ledanDay1 = { 181, 229 };
        public static int[] ledanDay2 = gems;
        public static int[] ledanDay3 = { 118, 119 };
        public static int[] ledanDay4 = { 132, 133, 134, 135, 150, 154 };
        public static int[] ledanDay5 = CustomChests.moonseaFirstHalfWeapons;
        public static int[][] ledanRotation = { ledanDay1, ledanDay2, ledanDay3, ledanDay4, ledanDay5 };

        public static int[] fairykingDay1 = CustomChests.galleryWeapons;
        public static int[] fairykingDay2 = { 181, 230 };
        public static int[] fairykingDay3 = { 169, 185, 187, 188, 189, 193, 197, 199 };
        public static int[] fairykingDay4 = { 132, 133, 134, 135, 150, 154 };
        public static int[][] fairykingRotation = { fairykingDay1, fairykingDay2, fairykingDay3, fairykingDay4, fairykingDay2 };

        static Random rnd = new Random();

        public static void BaseShopChanges()
        {
            //Gaffer shop changes
            Memory.WriteUShort(0x20292038, 81);
            Memory.WriteUShort(0x2029203A, 82);
            Memory.WriteUShort(0x2029203C, 83);
            Memory.WriteUShort(0x2029203E, 84);
            Memory.WriteUShort(0x20292040, 85);
            Memory.WriteUShort(0x20292042, 111);
            Memory.WriteUShort(0x20292044, 192);

            //Fairy King attachment shop changes
            Memory.WriteUShort(0x202922E0, 118);
            Memory.WriteUShort(0x202922E2, 119);
        }
        public static void RerollDailyRotation(int currentInGameDay)
        {
            int currentItemRotation = currentInGameDay % 5;

            int randomItem = rnd.Next(0, gafferRotation[currentItemRotation].Length);
            int randomItemFromTable = gafferRotation[currentItemRotation][randomItem];
            Memory.WriteUShort(0x21CE447C, (ushort)randomItemFromTable);

            randomItem = rnd.Next(0, wiseowlRotation[currentItemRotation].Length);
            randomItemFromTable = wiseowlRotation[currentItemRotation][randomItem];
            Memory.WriteUShort(0x21CE447E, (ushort)randomItemFromTable);

            randomItem = rnd.Next(0, jackRotation[currentItemRotation].Length);
            randomItemFromTable = jackRotation[currentItemRotation][randomItem];
            Memory.WriteUShort(0x21CE4480, (ushort)randomItemFromTable);

            randomItem = rnd.Next(0, jokerRotation[currentItemRotation].Length);
            randomItemFromTable = jokerRotation[currentItemRotation][randomItem];
            Memory.WriteUShort(0x21CE4482, (ushort)randomItemFromTable);

            randomItem = rnd.Next(0, brookeRotation[currentItemRotation].Length);
            randomItemFromTable = brookeRotation[currentItemRotation][randomItem];
            Memory.WriteUShort(0x21CE4484, (ushort)randomItemFromTable);

            randomItem = rnd.Next(0, ledanRotation[currentItemRotation].Length);
            randomItemFromTable = ledanRotation[currentItemRotation][randomItem];
            Memory.WriteUShort(0x21CE4486, (ushort)randomItemFromTable);

            randomItem = rnd.Next(0, fairykingRotation[currentItemRotation].Length);
            randomItemFromTable = fairykingRotation[currentItemRotation][randomItem];
            Memory.WriteUShort(0x21CE4488, (ushort)randomItemFromTable);

            Console.WriteLine("Daily Shop Items rerolled!");

            SetDailyItemsToShop();
        }

        public static void SetDailyItemsToShop()
        {
            Memory.WriteUShort(0x20292046, Memory.ReadUShort(0x21CE447C));
            Memory.WriteUShort(0x20292068, Memory.ReadUShort(0x21CE447E));
            Memory.WriteUShort(0x20292178, Memory.ReadUShort(0x21CE4480));
            Memory.WriteUShort(0x2029221A, Memory.ReadUShort(0x21CE4482));
            Memory.WriteUShort(0x202921A8, Memory.ReadUShort(0x21CE4484));
            Memory.WriteUShort(0x202921CE, Memory.ReadUShort(0x21CE4486));
            Memory.WriteUShort(0x202921EC, Memory.ReadUShort(0x21CE4488));
        }
    }
}
