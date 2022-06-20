using System;

namespace Dark_Cloud_Improved_Version
{
    public class DailyShopItem
    {
        public static int[] gems = { Items.garnet, Items.amethyst, Items.aquamarine, Items.diamond, Items.emerald, Items.pearl, Items.ruby, Items.peridot, Items.sapphire, Items.opal, Items.topaz, Items.turquoise};
        public static int[] usefulItems = { Items.amulet_antifreeze, Items.amulet_anticurse, Items.amulet_antigoo, Items.amulet_antidote, Items.staminadrink, Items.mightyhealing };

        public static int[] gafferDay1 = { Items.treasurechestkey, Items.treasurechestkey, Items.tramoil };
        public static int[] gafferDay2 = gems;
        public static int[] gafferDay3 = { Items.mimi, Items.prickly };
        public static int[] gafferDay4 = usefulItems;
        public static int[] gafferDay5 = CustomChests.dbcSecondHalfWeapons;
        public static int[][] gafferRotation = { gafferDay1, gafferDay2, gafferDay3, gafferDay4, gafferDay5 };

        public static int[] wiseowlDay1 = { Items.carrot, Items.minon, Items.battan };
        public static int[] wiseowlDay2 = usefulItems;
        public static int[] wiseowlDay3 = CustomChests.wiseowlSecondHalfWeapons;
        public static int[] wiseowlDay4 = { Items.treasurechestkey, Items.treasurechestkey, Items.sundew };
        public static int[] wiseowlDay5 = gems;
        public static int[][] wiseowlRotation = { wiseowlDay1, wiseowlDay2, wiseowlDay3, wiseowlDay4, wiseowlDay5 };

        public static int[] jackDay1 = CustomChests.shipwreckSecondHalfWeapons;
        public static int[][] jackRotation = { jackDay1, jackDay1, jackDay1, jackDay1, jackDay1 };

        public static int[] jokerDay1 = gems;
        public static int[] jokerDay2 = { Items.carrot, Items.minon, Items.battan, Items.mimi, Items.prickly };
        public static int[] jokerDay3 = usefulItems;
        public static int[] jokerDay4 = { Items.dragonslayer, Items.undeadbuster, Items.seakiller, Items.stonebreaker, Items.plantbuster, Items.beastbuster, Items.skyhunter, Items.metalbreaker, Items.mimicbreaker, Items.mageslayer };
        public static int[] jokerDay5 = { 181 };
        public static int[][] jokerRotation = { jokerDay1, jokerDay2, jokerDay3, jokerDay4, jokerDay5 };
       
        public static int[] brookeDay1 = { Items.amulet_antifreeze, Items.amulet_anticurse, Items.amulet_antigoo, Items.amulet_antidote, Items.staminadrink };
        public static int[] brookeDay2 = CustomChests.sunmoonSecondHalfWeapons;
        public static int[] brookeDay3 = { Items.treasurechestkey, Items.treasurechestkey, Items.secretpathkey };
        public static int[] brookeDay4 = gems;
        public static int[] brookeDay5 = { Items.poisonousapple, Items.carrot, Items.minon, Items.battan, Items.evy, Items.mimi, Items.prickly };
        public static int[][] brookeRotation = { brookeDay1, brookeDay2, brookeDay3, brookeDay4, brookeDay5 };

        public static int[] ledanDay1 = { Items.treasurechestkey, Items.treasurechestkey, Items.braverylaunch };
        public static int[] ledanDay2 = gems;
        public static int[] ledanDay3 = { Items.metalbreaker, Items.mimicbreaker };
        public static int[] ledanDay4 = usefulItems;
        public static int[] ledanDay5 = CustomChests.moonseaFirstHalfWeapons;
        public static int[][] ledanRotation = { ledanDay1, ledanDay2, ledanDay3, ledanDay4, ledanDay5 };

        public static int[] fairykingDay1 = CustomChests.galleryWeapons;
        public static int[] fairykingDay2 = { Items.treasurechestkey, Items.treasurechestkey, Items.flappingduster };
        public static int[] fairykingDay3 = { Items.poisonousapple, Items.carrot, Items.potatocake, Items.minon, Items.battan, Items.evy, Items.mimi, Items.prickly };
        public static int[] fairykingDay4 = usefulItems;
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

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Daily Shop Items rerolled!");

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

            if (Memory.ReadByte(0x21CE4464) != 0)
            {
                Memory.WriteUShort(0x202921EE, 231); //fairy king shop crystal eyeball and price
                Memory.WriteUShort(0x20291DD8, 5000);
            }
        }
    }
}
