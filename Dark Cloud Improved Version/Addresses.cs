namespace Dark_Cloud_Improved_Version
{
    class Addresses
    {
        public const int gilda = 0x21CDD892;
        public const int magicCrystal = 0x202A35A0;
        public const int map = 0x202A359C;
        public const int miniMap = 0x202A35B0;
        public const int visibility = 0x202A359C;

        public const int ingameTimer = 0x21CD4314; //4 Bytes address that counts the time ingame

        //Coordinates
        public const int positionX = 0x21D331D8;
        public const int positionY = 0x21D331D0;
        public const int positionZ = 0x21D331D4;
        public const int dunPositionX = 0x21EA1D30;
        public const int dunPositionY = 0x21EA1D38;
        public const int dunPositionZ = 0x21EA1D34;

        //Town Stuff
        public const int townSoftReset = 0x202A287C;    //This allows resetting to main menu in town with a value of 1
        public const int townFirstPerson = 0x202A26E0;  //0 = 3rd Person, 1 = 1st Person
        public const int townMessageWidth = 0x21EB6438;
        public const int townMessageHeight = 0x21EB643C;
        public const int townMode = 0x202A1F50; //0 = No NPCS/Player
                                                //1 = Walking Mode
                                                //2 = Returns to the last NPC spoken to (Crashes if no NPC has been interected with before a load)
                                                //3 = Fade in transition (Reloads state to 1)
                                                //4 = Georama Mode
                                                //5 = Last Menu accessed
                                                //6 = Georama Menu
                                                //7 = Transitioning to a menu
                                                //8 = Is on a menu (If forcing it while on a menu, goes to state 1, if on state 1 already it just gives a blank screen)
                                                //9 = Pause
                                                //10 = Pause without character models on the background
                                                //11 = Transition to Interior Mode (If used in Walking Mode: Freezes the game except some audio [CANNOT UNDO]))
                                                //12 = Interior Mode (if used in Walking Mode: Same as 11 excepts BGM still plays [CANNOT UNDO])
                                                //14 = Time Transition (Cannot Set)
                                                //16 = Fishing Mode

        //Dungeon Stuff
        public const int dungeonClear = 0x21DF881C;     //If this int = 4294967281, the dungeon is likely cleared. No idea why.
        public const int dunPauseTitle = 0x202A35C4;    //Show the "PAUSE" title on screen (0 = OFF/1 = ON)
        public const int dunPausePlayer = 0x202A3564;   //Is the player model in the pause state (0 = OFF/1 = ON)
        public const int dunPauseEnemy = 0x202A34DC;    //Are the enemy models in the pause state (0 = OFF/1 = ON)
        public const int dunMessage = 0x21EA76B4;       //Message box to display while in dungeon - 4294967295 shows nothing
        public const int dunMessageWidth = 0x21EB6438;
        public const int dunMessageHeight = 0x21EB643C;
        public const int dunMessage10 = 0x20998BB8;     //The address pointing to the text of the 10th dungeon message. 157 Byte array
        public const int dunMessage11 = 0x20998C8E;     //The address pointing to the text of the 11th dungeon message. 172 Byte array
        public const int healingSpeed = 0x202A2B88;     //Counts every 10 frames when the player is inside a fountain

        //Menu Stuff
        public const int menuWMIconHover = 0x202A2D4C;  //The walking mode menu icon the cursor is hovering
        public const int menuWMLastVisited = 0x202A2D48;//The last walking mode menu the player last accessed
        public const int menuGMIconHover = 0x21D9EF58;  //The georama mode menu the cursor is hovering

        //2 byte addresses that have specific values depending on which map location the cursor is hovering
        public const int MapLocationHover1 = 0x202A2DBC; //Norune Village = 13760
                                                         //Divine Beast Case = 13776
                                                         //Matataki Village = 13792
                                                         //Wise Owl Forest = 13808
                                                         //Brownboo Village = 13824
                                                         //Queens = 13840
                                                         //Shipwreck = 13856
                                                         //Muska Lacka = 13872
                                                         //Sun & Moon Temple = 13888
                                                         //Sun & Moon Temple (Inside) = 13904
                                                         //Yellow Drops = 13920
                                                         //Moon Factory = 13936
                                                         //Moon Sea = 13952
                                                         //Dark Heaven Castle = 13968
                                                         //Gallery of Time = 13984
                                                         //Demon Shaft = 14000

        public const int MapLocationHover2 = 0x202A2DC0; //Norune Village = 18064
                                                         //Divine Beast Case = 18688
                                                         //Matataki Village = 17440
                                                         //Wise Owl Forest = 16816
                                                         //Brownboo Village = 16192
                                                         //Queens = 15568
                                                         //Shipwreck = 14944
                                                         //Muska Lacka = 14320
                                                         //Sun & Moon Temple = 20560
                                                         //Sun & Moon Temple (Inside) = 13696
                                                         //Yellow Drops = 19312
                                                         //Moon Factory = 13072
                                                         //Moon Sea = 12448
                                                         //Dark Heaven Castle = 19936
                                                         //Gallery of Time = 11824
                                                         //Demon Shaft = 21184

        //Hide HUD
        public const int hideHud = 0x202A347C;
        public const int hideClock = 0x202A2894;
        public const int showNPCArrows = 0x202A28A4;

        public const int timeofDayRead = 0x202A28F4;    //Same as Time of Day value but does not clear when leaving town. Only for reading
        public const int timeofDayWrite = 0x21CD4310;   //Time of Day in town 

        //The percent of damage poison does to you based on max hp, default is "0.04"
        public const int poisonDamagePercent = 0x202A1860;

        //This is the percent the lamb sword needs to be to transform to wolf sword, default is "0.2"
        public const int lambSwordPercent = 0x202A1818;

        //Debug Menus
        public const int itemDebugMenu = 0x21D9EC08;
        public const int dungeonDebugMenu = 0x202A35EC;

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

        //TownCharacter addresses

        public const int chrConfigFileLocation = 0x2029A9F0; //this is where we place the character's .cfg file which the game starts reading
        public const int chrFileLocation = 0x2029AA08; //here we write the path to the character file which we want to use (for example "chara/c01d.chr" for Toan)

        public const int chrConfigFileOffset = 0x201790D8; //this address has the offset value to know where to read the cfg file, this needs to be matched with "chrConfigFileLocation"
        public const int chrFileOffset = 0x201790D0; //same as previous, offset value for the character path file

        public const int selectedMenu = 0x202A2010; //used for checking menu screen, 3 = chara select

        public const int activateCharacter = 0x21D90473; //while in char select screen, assigning this to value 4 will attempt to switch character

        public const int assignEditInit = 0x201F74B4; //when character is being selected, the game jumps to a function located in this address. We change this function to jal EditInit to reload map

    }
}
