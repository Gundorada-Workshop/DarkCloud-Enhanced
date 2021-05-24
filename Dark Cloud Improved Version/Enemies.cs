namespace Dark_Cloud_Improved_Version
{
    class Enemies
    {

        //0x9C is the offset between table enemy addresses (The read only ones)

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
            public const int minGoldDrop = 0x21E16BD4; //Minimum value gold can drop
            public const int dropChance = 0x21E16BD8; // 0 = 0% | 100 = 100%
            public const int forceItemDrop = 0x21E16C40; //Default value is 65535 |
                                                         //Turns into an item ID value once an item is dropped |
                                                         //If value is changed before killed, it will drop that item, be it by weapon or throw kill |
            public const int abs = 0x21E16C50;
            public const int stealItemId = 0x21E16C50;
            public const int itemResistance = 0x21E16C7C; //0 = Immune | 100 = 100%
            public const int itemDropId = 0x21E16FA4; //The item dropped by weapon kill
        }

        internal class Enemy1
        {
            const int offset = 0x190;
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
        }

        internal class Enemy2
        {
            const int offset = 0x190;
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
        }

        internal class Enemy3
        {
            const int offset = 0x190;
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
        }

        internal class Digger
        {
            public const int maxJumpDistance = 0x213F3D70;

        }
    }
}
