using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    internal class Player
    {
        private const int HP = 0x21CD955E;
        private const int MaxHP = 0x21CD9552;
        private const int Gilda = 0x21CDD892;
        private const int MagicCrystal = 0x202A35A0;
        private const int Map = 0x202A359C;
        private const int MiniMap = 0x202A35B0;
        private const int Visibility = 0x202A359C;

        private const int PlayerPositionX = 0x21D331D8;
        private const int PlayerPositionY = 0x21D331D0;
        private const int PlayerPositionZ = 0x21D331D4;
        private const int PlayerDunPositionX = 0x21EA1D30;
        private const int PlayerDunPositionY = 0x21EA1D38;
        private const int PlayerDunPositionZ = 0x21EA1D34;

        //private Vector3 GetPosition()
        //{
        //    Vector3 Vec;

        //    Vec.X = ReadFloat(PlayerPositionX);
        //    Vec.Y = ReadFloat(PlayerPositionY);
        //    Vec.Z = ReadFloat(PlayerPositionZ);

        //    return Vec;
        //    }
        //}

        public void SetGilda(short amount)
        {
            Memory.WriteShort(Gilda, amount);
        }

        public short GetGilda()
        {
            return Memory.ReadShort(Gilda);
        }
    }
}
