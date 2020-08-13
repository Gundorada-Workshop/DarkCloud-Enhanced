using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class Addresses
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

        //The percent of damage poison does to you based on max hp, default is "0.04"
        public const int poisonDamagePercent = 0x202A1860;

        //This is the percent the lamb sword needs to be to transform to wolf sword, default is "0.2"
        public const int lambSwordPercent = 0x202A1818;

        //Debug Menus
        public const int itemDebugMenu = 0x21D9EC08;
        public const int dungeonDebugMenu = 0x202A35EC;

        public const int townSoftReset = 0x202A287C; //This allows resetting to main menu in town with a value of 1

        //Inputs
        public const int buttonInputs = 0x21CBC544; //UShort

        //Square = 128        Cross = 64      Circle = 32       Triangle = 16
        //DPadLeft = 32768        DPadDown = 16384      DPadRight = 8192       DPadUP = 4096
        //Select = 256     L3 = 512      R3 = 1024      Start = 2048
        //L1 = 4        L2 = 1      R1 = 8      R2 = 2

        public const int LeftAnalogInputX = 0x21CBC5E0; //Byte
        public const int LeftAnalogInputY = 0x21CBC54C;
        public const int RightAnalogInputX = 0x21CBC554;
        public const int RightAnalogInputY = 0x21CBC550;

        public const int checkFloor = 0x21CD954E;   //tells the current floor player is on, updates when entering the floor

        public const int firstChest = 0x21DD0260;   //first chest rolled in the floor
        public const int firstChestSize = 0x21DD0268;       //either small or big chest
        public const int backfloorFirstChest = 0x21DE0D70;
        public const int backfloorFirstChestSize = 0x21DE0D78;
    }
}
