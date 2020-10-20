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

        public const int townState = 0x202A1F50;            //Check Addresses.cs for value description
        public const int townFirstPerson = 0x202A26E0;      //0 = 3rd Person, 1 = 1st Person
        public const int dunCameraPerspective = 0x202A1E94; //0 = Normal
                                                            //10 = FPS
                                                            //155 = Static

        public const int Ultraman = 0x21D564B0;

        public const int currentCharacter = 0x20429E80;     //Tells the current player selected, string 4bytes long

        public static bool InDungeonFloor()
        {
            if (Memory.ReadByte(0x21CD954F) != 255)         //Value is 255 when in town AND dungeon select, changes when floor is loaded. This also triggers when entering and leaving the menu in a dungeon.
                return true;

            else
                return false;
        }

        public static int CurrentCharacterNum()
        {
            if (Memory.ReadInt(currentCharacter) == 1680945251)
                return 0;
            else if (Memory.ReadInt(currentCharacter) == 1647587427)
                return 1;
            else if (Memory.ReadInt(currentCharacter) == 1630941283)
                return 2;
            else if (Memory.ReadInt(currentCharacter) == 1630875747)
                return 3;
            else if (Memory.ReadInt(currentCharacter) == 1630548323)
                return 4;
            else if (Memory.ReadInt(currentCharacter) == 1631072611)
                return 5;

            else return 255;
        }

        public static int GetCurrentWeaponId() //Returns the current equipped weapon ID
        {
            return Memory.ReadUShort(0x21EA7590);
        }

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

        public static bool CheckTownFirstPersonMode()
        {
            if (Memory.ReadUShort(townFirstPerson) == 1)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckDunFirstPersonMode()
        {
            if (Memory.ReadUShort(dunCameraPerspective) == 10)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckTownIsPaused()
        {
            if (Memory.ReadUShort(townState) == 9)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckDunIsPaused()
        {
            int dunPauseTitle = 0x202A35C4;
            int dunPausePlayerState = 0x202A3564;
            int dunPauseEnemyState = 0x202A34DC;

            if (Memory.ReadUShort(dunPausePlayerState) == 1
                && Memory.ReadUShort(dunPauseEnemyState) == 1
                && Memory.ReadUShort(dunPauseTitle) == 1
                && Memory.ReadUShort(dunCameraPerspective) == 155)
            {
                return true;
            }

            else return false;
        }

        public static bool CheckIsOnMenu()
        {
            if (Memory.ReadUShort(townState) == 8)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckIsOnGeoramaMode()
        {
            if (Memory.ReadUShort(townState) == 4)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckIsFishingMode()
        {
            if (Memory.ReadUShort(townState) == 16)
            {
                return true;
            }
            else return false;
        }

        public const int elementActual = 0x21EA75A6;

        internal class Toan
        {
            public const int hp = 0x21CE1FA8;
            public const int maxHP = 0x21CD9552;
            public const int defence = 0x21CDD894;
            public const int thirst = 0x21CDD850;
            public const int thirstMax = 0x21CDD838;
            public const int pocketSize = 0x21CDD8AC;
            public const int status = 0x21CDD814; //04 Freeze, 08 Stamina, 16 Poison, 32 Curse, 64 Goo.

            public const int currentWeaponSlot = 0x21CDD88C;

            //Addresses taken from https://deconstruction.fandom.com/wiki/Dark_Cloud
            internal class WeaponSlot0
            {
                public const int type = 0x21CDDA58; //257 through 298  //0x21CDDB50  F8
                public const int level = 0x21CDDA5A;
                public const int attack = 0x21CDDA5C;
                public const int endurance = 0x21CDDA5E;
                public const int speed = 0x21CDDA60;
                public const int magic = 0x21CDDA62;
                public const int whpMax = 0x21CDDA64;
                public const int whp = 0x21CDDA68; //Float
                public const int xp = 0x21CDDA6C;
                public const int elementHUD = 0x21CDDA6E; //00 Fire, 01 Ice, 02 Thunder, 03 Wind, 04 Holy, 05 None.
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
                public const int special1 = 0x21CDDB46; //Special Bitfield 1 	01 unknown(default on Chronicle 2), 02 Big bucks, 04 Poor, 08 Quench, 10 Thirst, 20 Poison, 40 Stop, 80 Steal.
                public const int special2 = 0x21CDDB47; //Special Bitfield 2 
            }

            internal class WeaponSlot1
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }
        }

        internal class Xiao
        {
            public const int hp = 0x21CE1FAA;
            public const int maxHP = 0x21CD9554;
            public const int defence = 0x21CDD898;

            public const int currentWeaponSlot = 0x21CDD88D;

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int type = Toan.WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Toan.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = Toan.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Toan.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Toan.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Toan.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Toan.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Toan.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Toan.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Toan.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Toan.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Toan.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Toan.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Toan.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Toan.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Toan.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Toan.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Toan.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Toan.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Toan.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Toan.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Toan.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Toan.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Toan.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Toan.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
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

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }
        }

        internal class Goro
        {
            public const int hp = 0x21CE1FAA; //Placeholder
            public const int maxHP = 0x21CD9554; //Placeholder
            public const int defence = 0x21CDD898; //Placeholder

            public const int currentWeaponSlot = 0x21CDD88E;

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int type = Xiao.WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Xiao.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = Xiao.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Xiao.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Xiao.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Xiao.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Xiao.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Xiao.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Xiao.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Xiao.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Xiao.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Xiao.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Xiao.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Xiao.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Xiao.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Xiao.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Xiao.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Xiao.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Xiao.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Xiao.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Xiao.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Xiao.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Xiao.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Xiao.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Xiao.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
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

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }
        }

        internal class Ruby
        {
            public const int hp = 0x21CE1FAA; //Placeholder
            public const int maxHP = 0x21CD9554; //Placeholder
            public const int defence = 0x21CDD898; //Placeholder

            public const int currentWeaponSlot = 0x21CDD88F;

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int type = Goro.WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Goro.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = Goro.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Goro.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Goro.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Goro.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Goro.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Goro.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Goro.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Goro.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Goro.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Goro.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Goro.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Goro.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Goro.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Goro.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Goro.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Goro.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Goro.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Goro.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Goro.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Goro.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Goro.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Goro.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Goro.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
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

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }
        }

        internal class Ungaga
        {
            public const int hp = 0x21CE1FAA; //Placeholder
            public const int maxHP = 0x21CD9554; //Placeholder
            public const int defence = 0x21CDD898; //Placeholder

            public const int currentWeaponSlot = 0x21CDD890;

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int type = Ruby.WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Ruby.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = Ruby.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Ruby.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Ruby.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Ruby.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Ruby.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Ruby.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Ruby.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Ruby.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Ruby.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Ruby.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Ruby.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Ruby.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Ruby.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Ruby.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Ruby.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Ruby.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Ruby.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Ruby.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Ruby.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Ruby.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Ruby.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Ruby.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Ruby.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
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

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }
        }

        internal class Osmond
        {
            public const int hp = 0x21CE1FAA; //Placeholder
            public const int maxHP = 0x21CD9554; //Placeholder
            public const int defence = 0x21CDD898; //Placeholder

            public const int currentWeaponSlot = 0x21CDD891;

            internal class WeaponSlot0 //Move to Player class instead of Ungaga
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int type = Ungaga.WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Ungaga.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = Ungaga.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Ungaga.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Ungaga.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Ungaga.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Ungaga.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Ungaga.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Ungaga.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Ungaga.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Ungaga.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Ungaga.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Ungaga.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Ungaga.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Ungaga.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Ungaga.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Ungaga.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Ungaga.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Ungaga.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Ungaga.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Ungaga.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Ungaga.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Ungaga.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Ungaga.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Ungaga.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
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

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int type = WeaponSlot0.type + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);
            }
        }
    }
}
