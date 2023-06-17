namespace Dark_Cloud_Improved_Version
{
    class Addresses
    {
        /// <summary>
        ///     0 = Main title
        /// <br>1 = Intro</br>
        /// <br>2 = Town</br>
        /// <br>3 = Dungeon</br>
        /// <br>4 = ? (doesnt crash in dungeon)</br>
        /// <br>5 = Opening cutscene (dark shrine)</br>
        /// <br>7 = Debug menu</br>
        /// </summary>
        public const int mode = 0x202A2534;

        public const int gilda = 0x21CDD892;
        public const int magicCrystal = 0x202A35A0;
        public const int map = 0x202A359C;
        public const int miniMap = 0x202A35B0;
        public const int visibility = 0x202A359C;

        /// <summary>Timer that runs from boot and does not stop.</summary>
        public const int sessionTimer = 0x202A2400;
        /// <summary>Timer that runs from boot/resumes from load and stops whenever the game is paused or not rendering anything.</summary>
        public const int ingameTimer = 0x21CD4314;

        //Coordinates
        public const int positionX = 0x21D331D8;
        public const int positionY = 0x21D331D0;
        public const int positionZ = 0x21D331D4;
        public const int dunPositionX = 0x21EA1D30;
        public const int dunPositionY = 0x21EA1D38;
        public const int dunPositionZ = 0x21EA1D34;

        //Town Stuff
        /// <summary>This allows resetting to main menu in town with a value of 1.</summary>
        public const int townSoftReset = 0x202A287C;

        /// <summary>
        ///     0 = 3rd Person
        /// <br>1 = 1st Person</br>
        /// </summary>
        public const int townCameraPerspective = 0x202A26E0;
        public const int townMessageWidth = 0x21EB6438;
        public const int townMessageHeight = 0x21EB643C;

        /// <summary>
        ///     0 = No NPCS/Player
        /// <br>1 = Walking Mode</br>
        /// <br>2 = Returns to the last NPC spoken to (Crashes if no NPC has been interected with before a load)</br>
        /// <br>3 = Fade in transition (Reloads state to 1)</br>
        /// <br>4 = Georama Mode</br>
        /// <br>5 = Last Menu accessed</br>
        /// <br>6 = Georama Menu</br>
        /// <br>7 = Transitioning to the last previous menu</br>
        /// <br>8 = Is on a menu (If forcing it while on a menu, goes to state 1, if on state 1 already it just gives a blank screen)</br>
        /// <br>9 = Pause</br>
        /// <br>10 = Pause without character models on the background</br>
        /// <br>11 = Transition to Interior Mode (If used in Walking Mode: Freezes the game except some audio [CANNOT UNDO]))</br>
        /// <br>12 = Interior Mode (if used in Walking Mode: Same as 11 excepts BGM still plays [CANNOT UNDO])</br>
        /// <br>14 = Time Transition (Cannot Set)</br>
        /// <br>16 = Fishing Mode</br>
        /// </summary>
        public const int townMode = 0x202A1F50;

        /// <summary>
        ///     0 = Walking Mode
        /// <br>1 = Transitioning to the outside</br>
        /// <br>2 = Finished unloading the interior</br>
        /// <br>3 = Talking to NPC</br>
        /// <br>4 = ???</br>
        /// <br>5 = Pause the game</br>
        /// <br>6 = Transitioning to the last previous menu</br>
        /// <br>7 = Last previous menu</br>
        /// <br>8+ = Freeze (CAN UNDO)</br>
        /// <br>14 = Camera Zoom (still freeze, CAN UNDO)</br>
        /// </summary>
        public const int interiorMode = 0x202A2A84;

        //Dungeon Stuff
        public const int dungeonClear = 0x21DF881C;             //If this int = 4294967281, the dungeon is likely cleared. No idea why.
        public const int dunPauseTitle = 0x202A35C4;            //Show the "PAUSE" title on screen (0 = OFF/1 = ON)
        public const int dunPausePlayer = 0x202A3564;           //Is the player model in the pause state (0 = OFF/1 = ON)
        public const int dunPauseEnemy = 0x202A34DC;            //Are the enemy models in the pause state (0 = OFF/1 = ON)
        public const int dunMessage = 0x21EA76B4;               //Message box to display while in dungeon - 4294967295 shows nothing
        public const int dunItemMessage = 0x21CFCCEC;           //The tooltip that appears when picking up and item
        public const int dunToggle1 = 0x21EA7690;               //Toggles the message on/off
        public const int dunToggle2 = 0x21EA76AC;               //Toggles the message on/off
        public const int dunMessageWidth = 0x21EB6438;          // Value is equal to the number of chars in a string (Ex: 5 -> width of a 5 char string)
        public const int dunMessageHeight = 0x21EB643C;         // Value is equal to the number of lines of a string paragraph (Ex: 2 -> paragraph with 2 lines)
        public const int dunMessage10 = 0x20998BB8;             //The address pointing to the text of the 10th dungeon message. 157 Byte array
        public const int dunMessage11 = 0x20998C8E;             //The address pointing to the text of the 11th dungeon message. 172 Byte array
        public const int dunMessageLastEnemyName = 0x20999EE8;  //The address for the last enemy/last message content
        public const int dunMessageDuration = 0x21EA7694;       //How long to show the message
        public const int dunMessageDelay = 0x21EA7698;          //How long to wait until the message is shown
        public const int healingSpeed = 0x202A2B88;             //Counts every 10 frames when the player is inside a fountain
        public const int BoneDoorOpenType = 0x20931768;         //Default value is 21, change it to 5 and the bone door will open by pressing Square
        public const int dungDoorType = 0x21D56770;             //Tells us the type of door when interacting with X or Square
        public const int checkFloor = 0x21CD954E;               //Tells the current floor player is on, updates when entering the floor
        public const int checkDungeon = 0x202A3594;             //Tells what dungeon we are in. DBC = 0, Wise Owl = 1 etc.
        
        ///<summary>
        ///     1 = Walking Mode
        /// <br>2 = On Menu</br>
        /// <br>3 = Door Menu</br>
        /// <br>5 = Ally Quick Select</br>
        /// <br>7 = Next Floor Screen</br>
        ///</summary>
        public const int dungeonMode = 0x202A355C;

        /// <summary>
        ///     0 = Null
        /// <br>1 = Spawned</br>
        /// <br>2 = Destroy animation</br>
        /// </summary>
        public const int circleSpawn1 = 0x21DD56A0;

        /// <summary>
        ///     0 = Player stamina
        /// <br>1 = Funds Increased</br>
        /// <br>2 = Abs full</br>
        /// <br>3 = Max Whp increased</br>
        /// <br>4 = Whp recover</br>
        /// <br>5 = Monster stamina</br>
        /// <br>6 = Funds Decreased</br>
        /// <br>7 = Status changed</br>
        /// <br>8 = Max Whp decreased</br>
        /// <br>9 = Whp decrease</br>
        /// <br>10 = Unused effect (item "melted" into blank)</br>
        /// </summary>
        public const int circleEffect1 = 0x21DD56A4;
        public const int circleSpawn2 = 0x21DD56C0;
        public const int circleEffect2 = 0x21DD56C4;
        public const int circleSpawn3 = 0x21DD56E0;
        public const int circleEffect3 = 0x21DD56E4;

        public const int backfloorcircleSpawn1 = 0x21DE61B0;     
        public const int backfloorcircleEffect1 = 0x21DE61B4;
        public const int backfloorcircleSpawn2 = 0x21DE61D0;
        public const int backfloorcircleEffect2 = 0x21DE61D4;
        public const int backfloorcircleSpawn3 = 0x21DE61F0;
        public const int backfloorcircleEffect3 = 0x21DE61F4;

        public const int dunBackFloorFlag = 0x202A34B4;

        //Menu Stuff
        public const int menuWMIconHover = 0x202A2D4C;  //The walking mode menu icon the cursor is hovering
        public const int menuWMLastVisited = 0x202A2D48;//The last walking mode menu the player last accessed
        public const int menuGMIconHover = 0x21D9EF58;  //The georama mode menu the cursor is hovering

        /// <summary>
        /// Tells us which menu we are on:
        /// <br>0 = Game Menu</br>
        /// <br>1 = Item Menu</br>
        /// <br>2 = Weapon Menu</br>
        /// <br>3 = Allies Menu</br>
        /// <br>5 = Leave Dungeon/Map</br>
        /// <br>12 = Georama Parts Menu</br>
        /// <br>14 = Options</br>
        /// <br>15 = Save</br>
        /// <br>16 = Manuals</br>
        /// </summary>
        public const int selectedMenu = 0x202A2010;


        //2 byte addresses that have specific values depending on which map location the cursor is hovering
        /// <summary>
        ///     Norune Village = 13760
        /// <br>Divine Beast Case = 13776</br>
        /// <br>Matataki Village = 13792</br>
        /// <br>Wise Owl Forest = 13808</br>
        /// <br>Brownboo Village = 13824</br>
        /// <br>Queens = 13840</br>
        /// <br>Shipwreck = 13856</br>
        /// <br>Muska Lacka = 13872</br>
        /// <br>Sun & Moon Temple = 13888</br>
        /// <br>Sun & Moon Temple (Inside) = 13904</br>
        /// <br>Yellow Drops = 13920</br>
        /// <br>Moon Factory = 13936</br>
        /// <br>Moon Sea = 13952</br>
        /// <br>Dark Heaven Castle = 13968</br>
        /// <br>Gallery of Time = 13984</br>
        /// <br>Demon Shaft = 14000</br>
        /// </summary>
        public const int MapLocationHover1 = 0x202A2DBC;

        /// <summary>
        ///     Norune Village = 18064
        /// <br>Divine Beast Case = 18688</br>
        /// <br>Matataki Village = 17440</br>
        /// <br>Wise Owl Forest = 16816</br>
        /// <br>Brownboo Village = 16192</br>
        /// <br>Queens = 15568</br>
        /// <br>Shipwreck = 14944</br>
        /// <br>Muska Lacka = 14320</br>
        /// <br>Sun & Moon Temple = 20560</br>
        /// <br>Sun & Moon Temple (Inside) = 13696</br>
        /// <br>Yellow Drops = 19312</br>
        /// <br>Moon Factory = 13072</br>
        /// <br>Moon Sea = 12448</br>
        /// <br>Dark Heaven Castle = 19936</br>
        /// <br>Gallery of Time = 11824</br>
        /// <br>Demon Shaft = 21184</br>
        /// </summary>
        public const int MapLocationHover2 = 0x202A2DC0;

        //Hide HUD
        /// <summary>
        ///     0 = HUD active
        /// <br>1 = HUD hidden</br>
        /// </summary>
        public const int hideHud = 0x202A347C;
        public const int hideClock = 0x202A2894;
        public const int showNPCArrows = 0x202A28A4;

        //Time
        /// <summary>Same as Time of Day value but does not clear when leaving town.</summary>
        public const int timeofDayRead = 0x202A28F4;
        /// <summary>Time of Day in town.</summary>
        public const int timeofDayWrite = 0x21CD4310;
        /// <summary>Current ingame day.</summary>
        public const int currentDay = 0x21CD4318;

        //Inventory
        public const int activeItem1 = 0x21CDD8AE;
        public const int activeItem1Quantity = 0x21CDD8B4;
        public const int activeItem2 = 0x21CDD8B0;
        public const int activeItem2Quantity = 0x21CDD8B6;
        public const int activeItem3 = 0x21CDD8B2;
        public const int activeItem3Quantity = 0x21CDD8B8;

        public const int firstBagItem = 0x21CDD8BA;
        public const int firstBagWeapon = 0x21CDDA58;
        public const int firstBagAttachment = 0x21CE1A48;

        public const int firstStorageItem = 0x21CE21E8; 
        public const int firstStorageWeapon = 0x21CE22D8;
        public const int firstStorageAttachment = 0x21CE3FE8;

        //Weapon Menu
        /// <summary>
        ///     0 = Weapon Menu
        /// <br>1 = Weapon Options</br>
        /// <br>2 = Weapon Attribute Menu</br>
        /// <br>3 = Weapon upgrade confirmation prompt</br>
        /// <br>4 = Weapon status break confirmation prompt</br>
        /// <br>5 = Buildup list</br>
        /// <br>6 = Buildup confirmation prompt</br>
        /// <br>7 = Buildup list inspect</br>
        /// <br>8 = Customize menu (Cursor on weapon)</br>
        /// <br>9 = Customize menu (Cursor on synth slots)</br>
        /// <br>10 = Customize menu (Cursor on attachment bag)</br>
        /// <br>11 = Customize menu (Cursor on weapon stats)</br>
        /// </summary>
        public const int weaponsMode = 0x21D9EA72;

        /// <summary>
        ///     0 = Default
        /// <br>1 = Weapon menu fade in</br>
        /// <br>2 = Returns to the main menu</br>
        /// <br>5 = Triggers when "Equip" option is selected</br>
        /// <br>7 = In upgrade state</br>
        /// <br>8 = In statusbreak state</br>
        /// <br>9 = In buildup state</br>
        /// <br>10 = In repair state</br>
        /// <br>12 = "Dump" option is highlighted</br>
        /// <br>13 = "Dump" option confirmation prompt</br>
        /// </summary>
        public const int weaponMenuTransitions = 0x21D9EA7C;

        public const int weaponMenuMessageType = 0x21D9EA78;            //The message prompts that display during various weapon menu interactions
        public const int weaponMenuCurrentWeaponHover = 0x21D9EA74;     //Which weapon we are hovering (0-9)
        public const int weaponMenuCurrentCharacterHover = 0x21D9EA75;  //Which character we are hovering (0-5)
        public const int weaponMenuListIndex = 0x21D9EA90;              //Acts like an index pointer depending on the weaponsMode we are in:
                                                                        //weaponsMode 1:                    weaponsMode 3/4/6:              weaponMode 9:
                                                                        //              0 = Equip                             0 = "Yes"                  0 = 1st synth slot
                                                                        //              1 = Customize                         1 = "No"                   1 = 2nd synth slot
                                                                        //              2 = Attribute                                                    n = etc...
                                                                        //              3 = Repair          weaponsMode 5: (Build-up)       weaponsMode 10:
                                                                        //              4 = Upgrade                       0 = 1st choice                   0 = 1st bag slot
                                                                        //              5 = Status Break                  1 = 2nd choice                   1 = 2nd bag slot
                                                                        //              6 = Build-up                      n = etc...                       n = etc...

        public const int weaponMenuAttributeElementHover = 0x21D9EA77;  //Which element we are hovering on the weapon attribute menu
        public const int weaponMenuStatsTab = 0x21D9EBE8;               //Which weapon stats tab we are currently in (0-2)
        public const int weaponMenuStatsListIndex = 0x21D9EBE9;         //Which weapon stats we are currently hovering (0-5 / 0-4 / 0-9)

        //The percent of damage poison does to you based on max hp, default is "0.04"
        public const int poisonDamagePercent = 0x202A1860;

        //This is the percent the lamb sword needs to be to transform to wolf sword, default is "double 0.2"
        public const int lambSwordPercent = 0x202A1818;

        //This is the percent for when the stats for the lamb sword should increase, default is "float 0.2"
        public const int lambSwordStatsPercent = 0x202A188C;

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

        public const int RestoreControl = 0x21D4A464; //Restore control to player if value is 1 in things like cutscenes

        public const int functionEntryPoint = 0x201F61F4; //jal BattleMenuDraw__Fv
        public const int functionEntryPoint2 = 0x201FA8BC; //jal DrawWeaponElemTag__FiiP11WEAPON_HAVEiii
        
        public static byte[] functionOverride = { 28, 234, 7, 12 }; //jal DrawWeaponElemTag__FiiP11WEAPON_HAVEiii
        public static byte[] functionBGMPlay = { 204, 102, 5, 12 };
        public static byte[] functionBGMStop = { 232, 102, 5, 12 };

        public const int firstChest = 0x21DD0260;           //first chest rolled in the floor
        public const int firstChestSize = 0x21DD0268;       //either small or big chest
        public const int backfloorFirstChest = 0x21DE0D70;
        public const int backfloorFirstChestSize = 0x21DE0D78;
        public const int clownCheck = 0x202A2684;

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


        public const int activateCharacter = 0x21D90473; //while in char select screen, assigning this to value 4 will attempt to switch character

        public const int assignEditInit = 0x201F74B4; //when character is being selected, the game jumps to a function located in this address. We change this function to jal EditInit to reload map

    }
}
