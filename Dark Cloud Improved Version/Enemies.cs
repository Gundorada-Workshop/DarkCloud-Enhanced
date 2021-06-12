using System.Collections.Generic;
namespace Dark_Cloud_Improved_Version
{

    class Enemies
    {
        public const int offset = 0x190;        //Offset between floor enemies
        public const int tableOffset = 0x9C;    //Offset between table enemies

        public static Dictionary<ushort, string> GetNormalEnemies()
        {
            return EnemyList.enemiesNormal;
        }

        public static Dictionary<ushort, string> GetFlyingEnemies()
        {
            return EnemyList.enemiesFlying;
        }

        public static Dictionary<ushort, string> GetOverseasEnemies()
        {
            return EnemyList.enemiesOversea;
        }

        public static Dictionary<ushort, string> GetBossEnemies()
        {
            return EnemyList.enemiesBoss;
        }

        public static ushort GetFloorEnemyId(int enemyFloorNum)
        {
            return Memory.ReadUShort(Enemy0.nameTag + (offset * enemyFloorNum));
        }

        public static List<ushort> GetFloorEnemiesIds()
        {
            List<ushort> Ids = new List<ushort>();

            for (int i = 0; i <= 15; i++)
            {
                Ids.Add(Memory.ReadUShort(Enemy0.nameTag + (offset * i)));
            }

            return Ids;
        }

        public static bool EnemyHasKey(int enemyNumber, byte dungeon)
        {
            return DungeonThread.GetDungeonGateKey(dungeon).Contains(Memory.ReadByte(Enemy0.forceItemDrop + (offset * enemyNumber)));
        }

        internal class EnemyList
        {

            public static Dictionary<ushort, string> enemiesNormal = new Dictionary<ushort, string>()
            {
                { 1, "Master Jacket" },
                { 3, "Skeleton Soldier" },
                { 5, "Statue" },
                { 6, "Dasher" },
                { 7, "Werewolf" },
                { 8, "Fli Fli" },
                { 10, "Halloween" },
                { 11, "Cannibal Plant" },
                { 12, "Earth Digger" },
                { 14, "Sunday" },
                { 15, "Monday" },
                { 16, "Tuesday" },
                { 17, "Wednesday" },
                { 18, "Thursday" },
                { 19, "Friday" },
                { 20, "Saturday" },
                { 23, "Gunny" },
                { 24, "Gyon" },
                { 25, "Pirate's Chariot" }, //Longest name
                { 26, "Auntie Medu" },
                { 27, "Captain" },
                { 28, "Corcea" },
                { 30, "Golem" },
                { 31, "Mr. Blare" },
                { 32, "Dune" },
                { 33, "Titan" },
                { 34, "King Mimic (Divine Beast Cave)" },
                { 35, "Mimic (Divine Beast Cave)" },
                { 36, "King Mimic (Sun & Moon Temple)" },
                { 37, "Mimic (Sun & Moon Temple)" },
                { 38, "King Mimic (Moon Sea)" },
                { 39, "Mimic (Moon Sea)" },
                { 40, "Arthur" },
                { 43, "Alexander" },
                { 44, "Heart" },
                { 45, "Club" },
                { 46, "Diamond" },
                { 47, "Spade" },
                { 48, "Joker" },
                { 49, "Bomber Head" },
                { 50, "Mummy" },
                { 52, "Curse Dancer" },
                { 54, "Killer Snake" },
                { 55, "Living Armor" },
                { 56, "White Fang" },
                { 57, "Moon Bug" },
                { 59, "Dragon" },
                { 62, "Hell Pockle" },
                { 63, "Rash Dasher" },
                { 64, "Steel Giant" },
                { 65, "Blizzard" },
                { 66, "Moon Digger" },
                { 67, "Dark Flower" },
                { 68, "Cursed Rose" },
                { 69, "Billy" },
                { 70, "Vulcan" },
                { 71, "Crabby Hermit" },
                { 72, "Space Gyon" },
                { 73, "Blue Dragon" },
                { 74, "Black Dragon" },
                { 75, "Mask of Prajna" },
                { 76, "Crescent Baron" },
                { 77, "Rockanoff" },
                { 78, "King Mimic (Wise Owl)" },
                { 79, "Mimic (Wise Owl)" },
                { 80, "King Mimic (Shipwreck)" },
                { 81, "Mimic (Shipwreck)" },
                { 82, "King Mimic (Gallery of Time)" },
                { 83, "Mimic (Gallery of Time)" },
                { 85, "Sam" },
                { 90, "Gol" },
                { 91, "Sil" },
                { 301, "Yammich" },
                { 303, "Statue Dog" },
                { 304, "Opar" },
                { 305, "Haley Holey" },
                { 306, "King Prickly" },
                { 308, "Nikapous" },
                { 309, "Mimic (Demon Shaft)" },
                { 310, "King Mimic (Demon Shaft)" },
                { 311, "Gemron (Fire)" },
                { 312, "Gemron (Ice)" },
                { 313, "Gemron (Thunder)" },
                { 314, "Gemron (Wind)" },
                { 315, "Gemron (Holy)" },
                { 316, "Bishop Q" },
                { 317, "Gacious" },
                { 318, "Silver Gear" },
                { 319, "Horn Head" }
            };

            internal static Dictionary<ushort, string> enemiesFlying = new Dictionary<ushort, string>()
            {
                { 9, "Hornet" },
                { 21, "Witch Hellza" },
                { 22, "Witch Illza" },
                { 42, "Ghost" },
                { 51, "Lich" },
                { 58, "Phantom" },
                { 60, "Cave Bat" },
                { 61, "Evil Bat" },
            };

            internal static Dictionary<ushort, string> enemiesOversea = new Dictionary<ushort, string>()
            {
                { 301, "Yammich" },
                { 303, "Statue Dog" },
                { 304, "Opar" },
                { 305, "Haley Holey" },
                { 306, "King Prickly" },
                { 308, "Nikapous" },
                { 309, "Mimic (Demon Shaft)" },
                { 310, "King Mimic (Demon Shaft)" },
                { 311, "Gemron (Fire)" },
                { 312, "Gemron (Ice)" },
                { 313, "Gemron (Thunder)" },
                { 314, "Gemron (Wind)" },
                { 315, "Gemron (Holy)" },
                { 316, "Bishop Q" },
                { 317, "Gacious" },
                { 318, "Silver Gear" },
                { 319, "Horn Head" },
            };

            internal static Dictionary<ushort, string> enemiesBoss = new Dictionary<ushort, string>()
            {
                { 84, "Ice Arrow" },
                { 112, "Dran" },
                { 113, "Ice Queen" },
                { 114, "Master Utan" },
                { 115, "King's Curse" },
                { 116, "Minotaur Joe" },
                { 117, "Dark Genie" },
                { 119, "Right Hand" },
                { 120, "Left Hand" },
                { 121, "Wine Keg" },
                { 221, "Black Knight" },
            };
        }

        internal class Enemy0
        {
            public const int visible = 0x21E16BA0;
            public const int freezeTimer = 0x21E16BA8;
            public const int poisonPeriod = 0x21E16BAC;
            public const int staminaTimer = 0x21E16BB0;
            public const int gooeyState = 0x21E16BB4;
            public const int maxHp = 0x21E16BC0;
            public const int hp = 0x21E16BC4;
            public const int drop = 0x21E16C40;
            public const int nameTag = 0x21E16BE2;
            public const int minGoldDrop = 0x21E16BD4;      //Minimum value gold can drop
            public const int dropChance = 0x21E16BD8;       // 0 = 0% | 100 = 100%
            public const int forceItemDrop = 0x21E16C40;    //Default value is 65535 ...
                                                            //Turns into an item ID value once an item is dropped ...
                                                            //If value is changed before killed, it will drop that item, be it by weapon or throw kill
            public const int abs = 0x21E16C50;
            public const int stealItemId = 0x21E16C50;
            public const int itemResistance = 0x21E16C7C;   //0 = Immune | 100 = 100%
            public const int itemDropId = 0x21E16FA4;       //The item dropped by weapon kill
            public const int renderStatus = 0x21E16BA0;     //Determines the enemy status (-1 = Not spawned | 1 = Spawned but not rendered | 2 = Spawned and being rendered)

            //Add this to here later 21E17D74 (enemy 12 render distance default 300 float)
        }

        internal class Enemy1
        {
            const byte EnemyMultiplier = 1;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy2
        {
            const byte EnemyMultiplier = 2;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy3
        {
            const byte EnemyMultiplier = 3;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy4
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 4;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy5
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 5;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy6
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 6;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy7
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 7;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy8
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 8;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy9
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 9;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy10
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 10;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy11
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 11;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy12
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 12;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy13
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 13;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy14
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 14;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Enemy15
        {
            const int offset = 0x190;
            const byte EnemyMultiplier = 15;

            public const int visible = Enemy0.visible + (offset * EnemyMultiplier);
            public const int freezeTimer = Enemy0.freezeTimer + (offset * EnemyMultiplier);
            public const int poisonPeriod = Enemy0.poisonPeriod + (offset * EnemyMultiplier);
            public const int staminaTimer = Enemy0.staminaTimer + (offset * EnemyMultiplier);
            public const int gooeyState = Enemy0.gooeyState + (offset * EnemyMultiplier);
            public const int maxHp = Enemy0.maxHp + (offset * EnemyMultiplier);
            public const int hp = Enemy0.hp + (offset * EnemyMultiplier);
            public const int drop = Enemy0.drop + (offset * EnemyMultiplier);
            public const int nameTag = Enemy0.nameTag + (offset * EnemyMultiplier);
            public const int minGoldDrop = Enemy0.minGoldDrop + (offset * EnemyMultiplier);
            public const int dropChance = Enemy0.dropChance + (offset * EnemyMultiplier);
            public const int forceItemDrop = Enemy0.forceItemDrop + (offset * EnemyMultiplier);
            public const int abs = Enemy0.abs + (offset * EnemyMultiplier);
            public const int stealItemId = Enemy0.stealItemId + (offset * EnemyMultiplier);
            public const int itemResistance = Enemy0.itemResistance + (offset * EnemyMultiplier);
            public const int itemDropId = Enemy0.itemDropId + (offset * EnemyMultiplier);
            public const int renderStatus = Enemy0.renderStatus + (offset * EnemyMultiplier);
        }

        internal class Digger
        {
            public const int maxJumpDistance = 0x213F3D70;

        }
    }
}
