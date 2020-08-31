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
        
        public const int townMessageWidth = 0x21EB6438;
        public const int townMessageHeight = 0x21EB643C;

        public const int dungeonClear = 0x21DF881C; //If this int = 4294967281, the dungeon is likely cleared. No idea why.

        public const int dunMessage = 0x21EA76B4; //Message box to display while in dungeon - 4294967295 shows nothing
        public const int dunMessageWidth = 0x21EB6438;
        public const int dunMessageHeight = 0x21EB643C;
        public const int dunMessage10 = 0x20998BB8; //The address pointing to the text of the 10th dungeon message. 157 Byte array
        public const int dunMessage11 = 0x20998C8E; //The address pointing to the text of the 11th dungeon message. 172 Byte array

        //Hide HUD
        public const int hideHud = 0x202A347C;
        public const int hideClock = 0x202A2894;
        public const int showNPCArrows = 0x202A28A4;

        public const int timeofDayRead = 0x202A28F4; //Same as Time of Day value but does not clear when leaving town. Only for reading
        public const int timeofDayWrite = 0x21CD4310; //Time of Day in town 

        //The percent of damage poison does to you based on max hp, default is "0.04"
        public const int poisonDamagePercent = 0x202A1860;

        //This is the percent the lamb sword needs to be to transform to wolf sword, default is "0.2"
        public const int lambSwordPercent = 0x202A1818;

        //Debug Menus
        public const int itemDebugMenu = 0x21D9EC08;
        public const int dungeonDebugMenu = 0x202A35EC;

        public const int townSoftReset = 0x202A287C; //This allows resetting to main menu in town with a value of 1

        //Inputs
        public const int buttonInputs = 0x21CBC544; //Two-byte Bitfield

        //Square = 128        Cross = 64      Circle = 32       Triangle = 16
        //DPadLeft = 32768        DPadDown = 16384      DPadRight = 8192       DPadUP = 4096
        //Select = 256     L3 = 512      R3 = 1024      Start = 2048
        //L1 = 4        L2 = 1      R1 = 8      R2 = 2

        public const int LeftAnalogInputX = 0x21CBC5E0; //Byte
        public const int LeftAnalogInputY = 0x21CBC54C;
        public const int RightAnalogInputX = 0x21CBC554;
        public const int RightAnalogInputY = 0x21CBC550;

        public const int functionEntryPoint = 0x201F61F4; //jal BattleMenuDraw__Fv
        public const int functionEntryPoint2 = 0x201FA8BC; //jal DrawWeaponElemTag__FiiP11WEAPON_HAVEiii
        
        public static byte[] functionOverride = { 28, 234, 7, 12 }; //jal DrawWeaponElemTag__FiiP11WEAPON_HAVEiii
        public static byte[] functionBGMPlay = { 204, 102, 5, 12 };
        public static byte[] functionBGMStop = { 232, 102, 5, 12 };

        public const int mode = 0x202A2534; //Values: 0=Main title, 1=Intro, 2=Town, 3=Dungeon, 4=? (doesnt crash in dungeon), 5=Opening cutscene(dark shrine), 6=?, 7=Debug menu
        public const int checkFloor = 0x21CD954E;   //tells the current floor player is on, updates when entering the floor
        public const int checkDungeon = 0x202A3594; //Tells what dungeon we are in. DBC = 0, Wise Owl = 1 etc.

        public const int firstChest = 0x21DD0260;   //first chest rolled in the floor
        public const int firstChestSize = 0x21DD0268;       //either small or big chest
        public const int backfloorFirstChest = 0x21DE0D70;
        public const int backfloorFirstChestSize = 0x21DE0D78;

        public const int ItemTbl0 = 0x20270C18;
        public const int ItemTbl0_1 = 0x20270E20;
        public const int ItemTbl0_2 = 0x20271020;

        public const int ItemTbl1 = 0x20271434;
        public const int ItemTbl1_1 = 0x2027163C;

        public const int ItemTbl2 = 0x20271A54;
        public const int ItemTbl2_1 = 0x20271C5C;

        public const int ItemTbl3 = 0x20272074;
        public const int ItemTbl3_1 = 0x20271C5C;
        public const int ItemTbl3_2 = 0x20272074;
        public const int ItemTbl3_3 = 0x2027227C;

        public const int ItemTbl4 = 0x20272694;
        public const int ItemTbl4_1 = 0x2027289C;

        public const int ItemTbl5 = 0x20272CB4;
        public const int ItemTbl5_1 = 0x20272EBC;

        public const int ItemTbl6 = 0x202732D4;
        public const int ItemTbl6_1 = 0x202734DC;

        public const int ItemTbl7 = 0x202738F4;
        public const int ItemTbl7_1 = 0x20273AFC;

        public const int ItemTbl8 = 0x20273F14;
        public const int ItemTbl8_1 = 0x2027411C;

        public const int ItemTbl9 = 0x20274534;
        public const int ItemTbl9_1 = 0x2027473C;

        public const int ItemTbl10 = 0x20274B54;
        public const int ItemTbl10_1 = 0x20274D5C;

        public const int ItemTbl11 = 0x20275174;
        public const int ItemTbl11_1 = 0x2027537C;

        public const int ItemTbl12 = 0x20275794;
        public const int ItemTbl12_1 = 0x2027599C;

        public const int ItemTbl13 = 0x20275DB4;
        public const int ItemTbl13_1 = 0x20275FBC;

        public const int ItemTblPtr = 0x202763D0;
        public const int ItemTblUnk = 0x20276410;

        public const int ItemPriceTable = 0x20291B80;
    }
}
