using System;

namespace Dark_Cloud_Improved_Version
{
    internal class Player
    {
        public const int Gilda = 0x21CDD892;
        public const int MagicCrystal = 0x202A35A0;
        public const int Map = 0x202A359C;
        public const int MiniMap = 0x202A35B0;
        public const int Visibility = 0x202A359C;

        public const int PositionX = 0x21D331D8;
        public const int PositionY = 0x21D331D0;
        public const int PositionZ = 0x21D331D4;
        public const int DunPositionX = 0x21EA1D30;
        public const int DunPositionY = 0x21EA1D38;
        public const int DunPositionZ = 0x21EA1D34;

        public static ushort GetGilda() //These are example functions that we could make more of if we want. It will mean more code but better readability and function.
        {
            ushort value = Memory.ReadUShort(Gilda);
            Console.WriteLine("Player has " + value + " Gilda");
            return value;
        }

        public static void SetGilda(ushort value)
        {
            Console.WriteLine("Player's Gilda was set to: " + value);
            Memory.WriteUShort(Gilda, value);
        }

        internal class Toan
        {
            public const int HP = 0x21CD955E;
            public const int MaxHP = 0x21CD9552;
            public const int defence = 0x21CDD894;
        }

        internal class Xiao
        {
            public const int HP = 0x21CD9560;
            public const int MaxHP = 0x21CD9554;
            public const int defence = 0x21CDD898;
        }
    }
}
