using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class Items
    {
        public static string[] ItemNameTbl = new string[377] {"Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Peridot", "Peridot", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Peridot", "Peridot", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Peridot", "Peridot", "Fire", "Ice", "Thunder", "Wind", "Holy", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Attack", "Endurance", "Speed", "Magic", "Garnet", "Amethyst", "Aquamarine", "Diamond", "Emerald", "Pearl", "Ruby", "Peridot", "Sapphire", "Opal", "Topaz", "Turquoise", "Sun", "Unknown", "Unknown", "Unknown", "Dinoslayer", "Undead Buster", "Sea Killer", "Stone Breaker", "Plant Buster", "Beast Buster", "Sky Hunter", "Metal Breaker", "Mimic Breaker", "Mage Slayer", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Anti-Freeze Amulet", "Anti-Curse Amulet", "Anti-Goo Amulet", "Antidote Amulet", "Fluffy Doughnut", "Fish Candy", "Grass Cake", "Witch Parfait", "Scorpion Jerky", "Carrot Cookie", "black square 142", "black square 143", "black square 144", "Regular Water", "Tasty Water", "Premium Water", "Bread", "Premium Chicken", "Stamina Drink", "Antidote Drink", "Holy Water", "Soap", "Mighty Healing", "Cheese", "black square 156", "black square 157", "black square 158", "Bomb", "Stone", "Inferno Gem", "Blizzard Gem", "Lightning Gem", "Whirlwind Gem", "Sacred Gem", "Throbbing Cherry", "Gooey Peach", "Bomb Nuts", "Poisonous Apple", "Mellow Banana", "Medusa Powder", "Unknown", "Warp Powder", "Stand-in Powder", "Escape Powder", "Revival Powder", "Repair Powder", "Powerup Powder", "Pocket", "Fruit of Eden", "Treasure Chest Key", "Gourd", "Auto Repair Powder", "black square 184", "Fishing Rod", "Carrot", "Potato cake", "Minon", "Battan", "Petite Fish", "Saving Book", "Gold Bullion", "Evy", "black square 194", "Dran's Crest", "Shiny Stone", "Mimi", "Red Berry", "Prickly", "Candy", "Hook", "King's Slate", "Gun Powder", "Clock Hands", "Pointy Chestnut", "Black Knight Crest", "Horned Key", "Moon Grass Seed", "Music Box Key", "Sun Signet", "Moon Signet", "Admission Ticket", "black square 213", "black square 214", "black square 215", "Bone Key", "Mustache Key", "Shipcabin Key", "Stone Key", "Handle", "Pitchdark Key", "Silver Key", "black square 223", "Tram Oil", "Sun Dew", "Flapping Fish", "Rotten Fish", "Secret Path Key", "Bravery Launch", "Flapping Duster", "Crystal Eyeball", "black square 232", "Map", "Magical Crystal", "Dran's Feather", "Cave Key", "Changing Potion", "World Map", "Bone Pendant", "Odd Tone Flute", "Magical Lamp", "Moon Orb", "Shell Ring", "Search Warrant", "Ice Block", "Small Ice", "Tiny Ice", "Flame Key", "Hunter's Earring", "Ointment Leaf", "Foundation", "Clay Doll", "Manual", "Sun Sphere", "black square 255", "black square 256", "Dagger (broken)", "Dagger", "Baselard", "Gladius", "Wise Owl Sword", "Crystal Knife", "Antique Sword", "Buster Sword", "Kitchen Knife", "Tsukikage", "Sun Sword", "Serpent Sword", "Macho Sword", "Shamshir", "Heaven's Cloud", "Lamb's Sword", "Dark Cloud", "Brave Ark", "Big Bang", "Atlamillia Sword", "glitched weapon", "Mardan Eins", "Mardan Twei", "Arise Mardan", "Aga's Sword", "Evilcise", "Small Sword", "Sand Breaker", "Drain Seeker", "Chopper", "Choora", "Claymore", "Maneater", "Bone Rapier", "Sax", "7 Branch Sword", "Dusack", "Cross Hinder", "7th Heaven", "Sword Of Zeus", "Chronicle Sword", "Chronicle 2", "Wooden Slingshot (broken)", "Wooden Slingshot", "Steel Slingshot", "Bandit Slingshot", "Steve", "Bone Slingshot", "Hardshooter", "Double Impact", "Dragon's Y", "Divine Beast Title", "Angel Shooter", "Flamingo", "Matador", "Super Steve", "Angel Gear", "Mallet (broken)", "Mallet", "Steel Hammer", "Magical Hammer", "Battle Ax", "Turtle Shell", "Big Bucks Hammer", "Frozen Tuna", "Gaia Hammer", "Last Judgement", "Tall Hammer", "Satan's Ax", "glitched weapon", "Plate Hammer", "Trial Hammer", "Inferno", "glitched weapon", "Gold Ring (broken)", "Gold Ring", "Bandit's Ring", "Crystal Ring", "Platinum Ring", "Goddess Ring", "Fairy's Ring", "Destruction Ring", "Satan's Ring", "Athena's Armlet", "Mobius Ring", "Glitched Weapon", "Pocklekul", "Thorn Armlet", "Secret Armlet", "glitched weapon", "Fighting Stick (broken)", "Fighting Stick", "Javelin", "Halberd", "DeSanga", "Scorpion", "Partisan", "Mirage", "Terra Sword", "Hercules' Wrath", "Babel's Spear", "glitched weapon", "5 Foot Nail", "Cactus", "glitched weapon", "Glitched Weapon", "Machine Gun (broken)", "Machine Gun", "Jackal", "Launcher", "Launcher V2", "Blessing Gun", "Skunk", "G Crusher", "Hex aBlaster", "Star Breaker", "Supernova", "Snail", "Swallow", "Empty Slot" };

        public static int[] ItemRateTbl = new int[377] {
            00, 00, 00, 00, 00, 00, 00, 00, 00, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //20
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //40
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //60 
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //80
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //100
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //120
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //140
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //160
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //180
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //200
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //220
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //240
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //260
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //280
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //300
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //320
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //340
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, //360
            50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50};            //376

        public static byte[] PriceList = Memory.ReadByteArray(Addresses.ItemPriceTable, 1504);

        public static ushort GetPurchasePriceIndex(ushort item)
        {
            ushort itemIndex, buyIndex;

            for (itemIndex = 81, buyIndex = 0; itemIndex <= PriceList.Length / 4; itemIndex++, buyIndex += 4)
            {
                if (itemIndex == item)
                    break;
            }

            return buyIndex;
        }

        public static ushort GetSellPriceIndex(ushort item)
        {
            ushort itemIndex, sellIndex;

            for (itemIndex = 81, sellIndex = 2; itemIndex <= PriceList.Length / 4; itemIndex++, sellIndex += 4)
            {
                if (itemIndex == item)
                    break;
            }

            return sellIndex;
        }

        internal class item81
        {
            public static ushort ID = 81;
            static float _dropRate = 50;

            public static string Name
            {
                get => ItemNameTbl[ID];
                set => ItemNameTbl[ID] = value;
            }

            public static int DropRate
            {
                get => ItemRateTbl[ID];
                set => ItemRateTbl[ID] = value;
            }

            public static ushort ValueBuy
            {
                get => BitConverter.ToUInt16(PriceList, GetPurchasePriceIndex(ID));
                set => Memory.WriteUShort(Addresses.ItemPriceTable + GetPurchasePriceIndex(ID), value);
            }

            public static ushort ValueSell
            {
                get => BitConverter.ToUInt16(PriceList, GetSellPriceIndex(ID));
                set => Memory.WriteUShort(Addresses.ItemPriceTable + GetSellPriceIndex(ID), value);
            }
        }

        internal class item82
        {
            public static ushort ID = 82;
            static float _dropRate = 50;

            public static string Name
            {
                get => ItemNameTbl[ID];
            }

            public static float DropRate
            {
                get => _dropRate;
                set => _dropRate = value;
            }

            public static ushort ValueBuy
            {
                get => BitConverter.ToUInt16(PriceList, GetPurchasePriceIndex(ID));
                set => Memory.WriteUShort(Addresses.ItemPriceTable + GetPurchasePriceIndex(ID), value);
            }

            public static ushort ValueSell
            {
                get => BitConverter.ToUInt16(PriceList, GetSellPriceIndex(ID));
                set => Memory.WriteUShort(Addresses.ItemPriceTable + GetSellPriceIndex(ID), value);
            }
        }

        internal class item83
        {
            public static ushort ID = 83;
            static float _dropRate = 50;

            public static string Name
            {
                get => ItemNameTbl[ID];
            }

            public static float DropRate
            {
                get => _dropRate;
                set => _dropRate = value;
            }

            public static ushort ValueBuy
            {
                get => BitConverter.ToUInt16(PriceList, GetPurchasePriceIndex(ID));
                set => Memory.WriteUShort(Addresses.ItemPriceTable + GetPurchasePriceIndex(ID), value);
            }

            public static ushort ValueSell
            {
                get => BitConverter.ToUInt16(PriceList, GetSellPriceIndex(ID));
                set => Memory.WriteUShort(Addresses.ItemPriceTable + GetSellPriceIndex(ID), value);
            }
        }
    }
}
