
namespace Dark_Cloud_Improved_Version
{
    class Shop
    {
        static int itemOffset = 0xFC;
        static int tagOffset = 0x4;

        public static void UpdateShopPrices() {

            //Treasure Key (Reduced to half)
            Memory.WriteUShort(0x20291D10, 400);
            Memory.WriteUShort(0x20291D12, 200);

            //Anti-Curse Amulet (Round to 400)
            Memory.WriteUShort(0x20291C50, 400);
            Memory.WriteUShort(0x20291C52, 200);

            //Anti-Goo Amulet (Round to 400)
            Memory.WriteUShort(0x20291C54, 400);
            Memory.WriteUShort(0x20291C56, 200);

            //Reduce all baits selling prices to 1/4
            ushort baitPriceReduceFactor = 0x4;

            Memory.WriteUShort(0x20291D26, (ushort)(Memory.ReadUShort(0x20291D24)/ baitPriceReduceFactor)); //Carrot
            Memory.WriteUShort(0x20291D2A, (ushort)(Memory.ReadUShort(0x20291D28)/ baitPriceReduceFactor)); //Potato Cake
            Memory.WriteUShort(0x20291D2E, (ushort)(Memory.ReadUShort(0x20291D2C)/ baitPriceReduceFactor)); //Minon
            Memory.WriteUShort(0x20291D32, (ushort)(Memory.ReadUShort(0x20291D30)/ baitPriceReduceFactor)); //Battan
            Memory.WriteUShort(0x20291D36, (ushort)(Memory.ReadUShort(0x20291D34)/ baitPriceReduceFactor)); //Petite Fish
            Memory.WriteUShort(0x20291D42, (ushort)(Memory.ReadUShort(0x20291D40)/ baitPriceReduceFactor)); //Evy
            Memory.WriteUShort(0x20291D52, (ushort)(Memory.ReadUShort(0x20291D50)/ baitPriceReduceFactor)); //Mimi
            Memory.WriteUShort(0x20291D5A, (ushort)(Memory.ReadUShort(0x20291D58)/ baitPriceReduceFactor)); //Prickly

            //SET THE PRICES FOR THE BACKFLOOR KEYS
            //Tram Oil
            Memory.WriteUShort(0x20291DBC, 600);    //Buy
            Memory.WriteUShort(0x20291DBE, 300);    //Sell

            //Sundew
            Memory.WriteUShort(0x20291DC0, 750);
            Memory.WriteUShort(0x20291DC2, 375);

            //Flapping Fish (fresh)
            Memory.WriteUShort(0x20291DC4, 300);
            Memory.WriteUShort(0x20291DC6, 150);

            //Secret Path Key
            Memory.WriteUShort(0x20291DCC, 900);
            Memory.WriteUShort(0x20291DCE, 450);

            //Bravery Launch
            Memory.WriteUShort(0x20291DD0, 1200);
            Memory.WriteUShort(0x20291DD2, 600);

            //Flapping Duster
            Memory.WriteUShort(0x20291DD4, 1500);
            Memory.WriteUShort(0x20291DD6, 750);

            /* ALREADY CHANGING IN DailyShopItem.cs Line in SetDailyItemsToShop()
            //Crystal Eyeball
            Memory.WriteUShort(0x20291DD8, 5000);
            Memory.WriteUShort(0x20291DDA, 2500);
            */

            //All weapons ranging from the broken dagger all the way through Swallow (including dummy weapons)
            ushort[] newBuyPrices = { 2, 2, 500, 650, 2500, 900, 5000, 1800, 3000, 4500, 9000, 3000, 5500, 1250, 12000, 7888, 3642, 9500, 12726, 18000, 2, 12000, 18000, 30000, 9021, 4500, 1900, 2250, 11500, 2500, 5000, 6000, 8000, 1001, 2150, 9507, 5300, 10000, 23331, 37035, 40011, 45000, 2, 2, 900, 4200, 1999, 750, 2800, 3100, 5525, 9015, 18000, 2552, 6666, 14000, 33333, 2, 2, 1700, 7035, 6000, 2704, 3250, 1701, 8000, 12000, 21816, 19998, 2, 2600, 2300, 33027, 2, 2, 2, 3800, 4300, 2500, 8000, 5000, 9000, 8000, 16314, 24000, 2, 2007, 3500, 36000, 2, 2, 2, 3400, 4000, 4700, 6000, 5000, 7000, 13500, 21036, 35823, 2, 5555, 6500, 2, 2, 2, 2, 4000, 3200, 3300, 6000, 10450, 11943, 12018, 24000, 24000, 3000, 9000 };

            //All weapons ranging from the broken dagger all the way through Swallow (including dummy weapons)
            ushort[] newSellPrices = { 1, 1, 167, 217, 833, 300, 1667, 600, 1000, 1500, 3000, 1000, 1833, 417, 4000, 2629, 1214, 3167, 4242, 6000, 1, 4000, 6000, 10000, 3007, 1500, 633, 750, 3833, 833, 1667, 2000, 2667, 334, 717, 3169, 1767, 3333, 7777, 12345, 13337, 15000, 1, 1, 300, 1400, 666, 250, 933, 1033, 1842, 3005, 6000, 851, 2222, 4667, 11111, 1, 1, 567, 2345, 2000, 901, 1083, 567, 2667, 4000, 7272, 6666, 1, 867, 767, 11009, 1, 1, 1, 1267, 1433, 833, 2667, 1667, 3000, 2667, 5438, 8000, 1, 669, 1167, 12000, 1, 1, 1, 1133, 1333, 1567, 2000, 1667, 2333, 4500, 7012, 11941, 1, 1852, 2167, 1, 1, 1, 1, 1333, 800, 825, 2000, 3483, 3981, 4006, 8000, 8000, 1000, 3000 };

            //Initialize the starting price addresses
            int brokenDaggerBuyPrice = 0x20291E40;
            int brokenDaggerSellPrice = 0x20291E42;

            //Run through the price addresses (Buy and Sell) and set the new values
            for (int i = 0; i < newBuyPrices.Length; i++)
            {
                Memory.WriteUShort(brokenDaggerBuyPrice + (i* 0x4), newBuyPrices[i]);
                Memory.WriteUShort(brokenDaggerSellPrice + (i* 0x4), newSellPrices[i]);
            }
        }

        internal class ItemSlot0
        {
            public static int item = 0x218377A0;
            public static int tagType = 0x21833E20; // 0 = Null (becomes regular non-shop item)
                                                    // 1 = Purchase
                                                    // 2 = Sell

            public static ushort Item
            {
                get => Memory.ReadUShort(item);
                set => Memory.WriteUShort(item, value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(tagType);
                set => Memory.WriteInt(tagType, value);
            }
        }

        internal class ItemSlot1
        {
            static int offsetMultiplier = 1;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot2
        {
            
            static int offsetMultiplier = 2;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot3
        {
            
            static int offsetMultiplier = 3;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot4
        {
            
            static int offsetMultiplier = 4;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot5
        {
            
            static int offsetMultiplier = 5;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot6
        {
            
            static int offsetMultiplier = 6;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot7
        {
            
            static int offsetMultiplier = 7;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot8
        {
            
            static int offsetMultiplier = 8;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot9
        {
            
            static int offsetMultiplier = 9;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot10
        {
            
            static int offsetMultiplier = 10;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot11
        {
            
            static int offsetMultiplier = 11;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot12
        {
            
            static int offsetMultiplier = 12;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot13
        {
            
            static int offsetMultiplier = 13;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot14
        {
            
            static int offsetMultiplier = 14;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot15
        {
            
            static int offsetMultiplier = 15;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot16
        {
            
            static int offsetMultiplier = 16;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot17
        {
            
            static int offsetMultiplier = 17;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot18
        {
            
            static int offsetMultiplier = 18;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot19
        {
            
            static int offsetMultiplier = 19;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot20
        {
            
            static int offsetMultiplier = 20;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot21
        {
            
            static int offsetMultiplier = 21;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot22
        {
            
            static int offsetMultiplier = 22;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot23
        {
            
            static int offsetMultiplier = 23;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot24
        {
            
            static int offsetMultiplier = 24;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot25
        {
            
            static int offsetMultiplier = 25;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot26
        {
            
            static int offsetMultiplier = 26;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot27
        {
            
            static int offsetMultiplier = 27;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot28
        {
            
            static int offsetMultiplier = 28;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }

        internal class ItemSlot29
        {
            
            static int offsetMultiplier = 29;

            public static ushort Item
            {
                get => Memory.ReadUShort(ItemSlot0.item + (itemOffset * offsetMultiplier));
                set => Memory.WriteUShort(ItemSlot0.item + (itemOffset * offsetMultiplier), value);
            }

            /// <summary>
            /// 0 = Null (becomes regular non-shop item)<br></br>
            /// 1 = Purchase<br></br>
            /// 2 = Sell
            /// </summary>
            public static int Tag
            {
                get => Memory.ReadInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier));
                set => Memory.WriteInt(ItemSlot0.tagType + (tagOffset * offsetMultiplier), value);
            }
        }
    }
}
