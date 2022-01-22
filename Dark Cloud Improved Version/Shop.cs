using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class Shop
    {
        static int itemOffset = 0xFC;
        static int tagOffset = 0x4;

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
