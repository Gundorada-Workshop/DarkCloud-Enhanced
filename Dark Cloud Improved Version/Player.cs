using System;

namespace Dark_Cloud_Improved_Version
{
    internal class Player
    {
        public const int gilda = 0x21CDD892;
        public const int magicCrystal = 0x202A35A0;
        public const int map = 0x202A359C;
        public const int miniMap = 0x202A35B0;
        public const int visibility = 0x202A359C;

        public const int positionX = 0x21D331D8;
        public const int positionY = 0x21D331D0;
        public const int positionZ = 0x21D331D4;
        public const int dunPositionX = 0x21EA1D30;
        public const int dunPositionY = 0x21EA1D38;
        public const int dunPositionZ = 0x21EA1D34;

        public static ushort GetGilda() //These are example functions that we could make more of if we want. It will mean more code but better readability and function.
        {
            ushort value = Memory.ReadUShort(gilda);
            Console.WriteLine("Player has " + value + " Gilda");
            return value;
        }

        public static void SetGilda(ushort value)
        {
            Console.WriteLine("Player's Gilda was set to: " + value);
            Memory.WriteUShort(gilda, value);
        }

        internal class Toan
        {
            public const int hp = 0x21CD955E;
            public const int maxHP = 0x21CD9552;
            public const int defence = 0x21CDD894;
            public const int thirst = 0x21CDD850;
            public const int thirstMax = 0x21CDD838;
            public const int pocketSize = 0x21CDD8AC;
            public const int status = 0x21CDD814; //04 Freeze, 08 Stamina, 16 Poison, 32 Curse, 64 Goo.

            //Addresses taken from https://deconstruction.fandom.com/wiki/Dark_Cloud
            internal class WeaponSlot1
            {
                public const int type = 0x21CDDA58; //257 through 298
                public const int level = 0x21CDDA5A;
                public const int attack = 0x21CDDA5C;
                public const int endurance = 0x21CDDA5E;
                public const int speed = 0x21CDDA60;
                public const int magic = 0x21CDDA62;
                public const int whpMax = 0x21CDDA64;
                public const int whp = 0x21CDDA68;
                public const int xp = 0x21CDDA6C;
                public const int element = 0x21CDDA6E; //00 Fire, 01 Ice, 02 Thunder, 03 Wind, 04 Holy, 05 None.
                public const int fire = 0x21CDDA6F;
                public const int ice = 0x21CDDA70;
                public const int thunder = 0x21CDDA71;
                public const int wind = 0x21CDDA72;
                public const int holy = 0x21CDDA73;
                public const int aDragon = 0x21CDDA74;
                public const int aUndead = 0x21CDDA75;
                public const int aMarine = 0x21CDDA76;
                public const int aRock = 0x21CDDA77;
                public const int aPlant = 0x21CDDA78;
                public const int aBeast = 0x21CDDA79;
                public const int aSky = 0x21CDDA7A;
                public const int aMetal = 0x21CDDA7B;
                public const int aMimic = 0x21CDDA7C;
                public const int aMage = 0x21CDDA7D;
                //public const int weapon1 = 0x21CDDA80; //Attached 1 Weapon Type   51 through 78.
                //public const int weapon1 = 0x21CDDA82; //Attached 1 Former Weapon Type (2b)    Only for Synth Spheres; determines name in description.
                //public const int weapon1 = 0x21CDDA86; //Attached 1 Former Weapon Level(2b)    Only for Synth Spheres; determines "+X" after name in description.
                //public const int weapon1 = 0x21CDDA88; //Attached 1 Attack Bonus
                //public const int weapon1 = 0x21CDDA8A; //Attached 1 Endurance Bonus
                //public const int weapon1 = 0x21CDDA8C; //Attached 1 Speed Bonus
                //public const int weapon1 = 0x21CDDA8E; //Attached 1 Magical Power Bonus
                //public const int weapon1 = 0x21CDDA90; //Attached 1 Fire Bonus
                //public const int weapon1 = 0x21CDDA91; //Attached 1 Ice Bonus
                //public const int weapon1 = 0x21CDDA92; //Attached 1 Thunder Bonus
                //public const int weapon1 = 0x21CDDA93; //Attached 1 Wind Bonus
                //public const int weapon1 = 0x21CDDA94; //Attached 1 Holy Bonus
                //public const int weapon1 = 0x21CDDA95; //Attached 1 Anti-Dragon Bonus
                //public const int weapon1 = 0x21CDDA96; //Attached 1 Anti-Undead Bonus
                //public const int weapon1 = 0x21CDDA97; //Attached 1 Anti-Marine Bonus
                //public const int weapon1 = 0x21CDDA98; //Attached 1 Anti-Rock Bonus
                //public const int weapon1 = 0x21CDDA99; //Attached 1 Anti-Plant Bonus
                //public const int weapon1 = 0x21CDDA9A; //Attached 1 Anti-Beast Bonus
                //public const int weapon1 = 0x21CDDA9B; //Attached 1 Anti-Sky Bonus
                //public const int weapon1 = 0x21CDDA9C; //Attached 1 Anti-metal Bonus
                //public const int weapon1 = 0x21CDDA9D; //Attached 1 Anti-mimic Bonus
                //public const int weapon1 = 0x21CDDA9E; //Attached 1 Anti-Mage Bonus
                //public const int weapon1 = 0x21CDDAA0; //Attached 2 Type Attribute 
                //public const int weapon1 = 0x21CDDB46; //Special Bitfield 1 	01 unknown(default on Chronicle 2), 02 Big bucks, 04 Poor, 08 Quench, 10 Thirst, 20 Poison, 40 Stop, 80 Steal.
                //public const int weapon1 = 0x21CDDB47; //Special Bitfield 2 
            }
        }

        internal class Xiao
        {
            public const int hp = 0x21CD9560;
            public const int maxHP = 0x21CD9554;
            public const int defence = 0x21CDD898;
        }
    }
}
