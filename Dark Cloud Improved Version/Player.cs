using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    internal class Player
    {
        public const int HP = 0x21CD955E;
        public const int MaxHP = 0x21CD9552;
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

        //private Vector3 GetPosition()
        //{
        //    Vector3 Vec;

        //    Vec.X = ReadFloat(PlayerPositionX);
        //    Vec.Y = ReadFloat(PlayerPositionY);
        //    Vec.Z = ReadFloat(PlayerPositionZ);

        //    return Vec;
        //    }
        //}

        public static void SetGilda(short amount)
        {
            Console.WriteLine("Player's Gilda was set to: " + amount);
            Memory.WriteShort(Gilda, amount);
        }

        public static short GetGilda()
        {
            return Memory.ReadShort(Gilda);
        }
    }
}
