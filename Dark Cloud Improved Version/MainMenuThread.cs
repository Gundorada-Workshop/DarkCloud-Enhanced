using System;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    public class MainMenuThread
    {
        public static bool firstlaunch;
        public static bool ingame;
        public static bool ingameFlag;
        public static bool userMode = false;
        public static bool saveStateUsed = false;
        public static bool saveFileMessageBox = false;
        public static int PID = 0;
        public static int currentFrameCounter = 0;
        public static int previousFrameCounter = 0;
        public static Thread townThread = new Thread(new ThreadStart(TownCharacter.InitializeChrOffsets));
        public static Thread changesThread = new Thread(new ThreadStart(ApplyNewChanges));
        public static Thread dungeonthread = new Thread(new ThreadStart(Dungeon.InsideDungeonThread));
        public static Thread weaponspecialeffectThread = new Thread(new ThreadStart(Weapons.RerollWeaponSpecialEffects));

        internal static void ApplyNewChanges()
        {
            Weapons.WeaponsBalanceChanges();
            Shop.UpdateShopPrices();
        }

        public static void CheckEmulatorAndGame()
        {
            firstlaunch = true;
            Program.ConsoleLogging(); //LOGS CONSOLE WRITES TO TEXT FILE!
            while (true)
            {
                Memory.WriteByte(0x21F10024, 0); //mod's flag for PNACH
                if (PID == 0)
                {
                    PID = Memory.GetProcessID("pcsx2");                   
                }
                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "CheckEmulatorAndGame");
                if (PID == 0)
                {
                    //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Memory PID 0");
                    ModWindow.EmulatorCount(0); //no emulators running
                }
                /*else if (PID > 1)
                {
                    Form1.EmulatorCount(2); //more than 1 emulator running
                } */
                else if (PID != 0)
                {
                    Memory.GetProcess(PID);
                    //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + Memory.ReadInt(0x20299540));
                    if (Memory.ReadInt(0x20299540) != 1802658116) //check if DC1 has been booted
                    {
                        PID = 0;
                        ModWindow.EmulatorCount(1);
                    }
                    else
                    {
                        if (Memory.ReadByte(0x21F10020) == 1) //check PNACH flag
                        {
                            if (firstlaunch)
                            {
                                if (Memory.ReadByte(Addresses.mode) == 2 || Memory.ReadByte(Addresses.mode) == 3 || Memory.ReadByte(Addresses.mode) == 5) //checks if player is already in-game
                                {
                                    if (saveFileMessageBox == false)
                                    {
                                        ModWindow.FirstLaunchGameMode(false);
                                        Thread.Sleep(100);
                                    }
                                }
                                else
                                {
                                    ModWindow.FirstLaunchGameMode(true);
                                    //firstlaunch = false;
                                    ingame = false;
                                    userMode = true;
                                    TitleMenu();
                                }
                            }
                        }
                        else
                        {
                            ModWindow.PnachNotActive();
                        }
                    }
                }

                if (saveStateUsed)
                {
                    break;
                }

                Thread.Sleep(1);
            }
        }

        public static void TitleMenu()
        {
            TownCharacter.InitializeCharacterOffsetValues();
            while (true)
            {
                currentFrameCounter = Memory.ReadInt(0x202A2400);
                if (currentFrameCounter > 0)
                {
                    break;
                }
            }
            previousFrameCounter = currentFrameCounter;
            Thread.Sleep(10);

            while (true)
            {
                if (Memory.ReadByte(0x21F10024) == 1)
                {
                    ModWindow.EnhancedModAlreadyOpen();
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Memory.WriteByte(0x21F10024, 1); //mod's flag for PNACH
                currentFrameCounter = Memory.ReadInt(0x202A2400);
                int currentMode = Memory.ReadByte(Addresses.mode);
                if (currentFrameCounter > 0)
                {
                    if (ingame == false)
                    {
                        if (currentMode == 0 || currentMode == 1)
                        {
                            ingame = false;
                            ingameFlag = false;
                            if (Memory.ReadByte(0x202A3420) == 9) //Opening book mode after you press start
                            {
                                ModWindow.CurrentlyInGame();
                            }
                            else
                            {
                                ModWindow.CurrentlyInMainMenu();
                            }
                        }
                        else if (currentMode == 2 || currentMode == 3 || currentMode == 5)
                        {
                            Thread.Sleep(100);
                            currentMode = Memory.ReadByte(Addresses.mode);
                            if (currentMode == 2 || currentMode == 3 || currentMode == 5)
                            {
                                if (ingameFlag == false)
                                {
                                    Thread.Sleep(100);

                                    if (currentMode == 5)
                                    {
                                        Thread.Sleep(800);
                                        Memory.WriteByte(0x21CE448A, 1);
                                        Thread.Sleep(200);
                                    }


                                    if (Memory.ReadByte(0x21CE448A) != 2)
                                    {
                                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered ingame, starting all threads!");
                                        changesThread = new Thread(() => ApplyNewChanges());
                                        townThread = new Thread(() => TownCharacter.InitializeChrOffsets());
                                        dungeonthread = new Thread(() => Dungeon.InsideDungeonThread());
                                        weaponspecialeffectThread = new Thread(() => Weapons.RerollWeaponSpecialEffects());
                                        if (!changesThread.IsAlive) changesThread.Start();
                                        if (!townThread.IsAlive) townThread.Start();
                                        if (!dungeonthread.IsAlive) dungeonthread.Start();
                                        if (!weaponspecialeffectThread.IsAlive) weaponspecialeffectThread.Start();
                                        ingameFlag = true;
                                    }
                                    else
                                    {
                                        if (Player.InDungeonFloor() == true)
                                            Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                                        else
                                            Memory.WriteByte(Addresses.mode, 1);
                                        ModWindow.NotEnhancedModSaveFile();
                                        break;
                                    }
                                }
                                ingame = true;
                                ModWindow.CurrentlyInGame();
                            }

                        }
                    }
                    else
                    {
                        if (currentMode == 0 || currentMode == 1)
                        {
                            Thread.Sleep(100);
                            currentMode = Memory.ReadByte(Addresses.mode);
                            if (currentMode == 0 || currentMode == 1)
                            {
                                ingame = false;
                                ingameFlag = false;
                                ModWindow.CurrentlyInMainMenu();
                            }
                        }
                        else if (currentMode == 2 || currentMode == 3 || currentMode == 5)
                        {
                            ingame = true;
                            ModWindow.CurrentlyInGame();
                        }
                    }
                }

                if (Memory.ReadInt(0x20299540) != 1802658116)
                {
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Dark Cloud was either closed, or save state was used!");
                    Thread.Sleep(50);
                    if (Memory.ReadInt(0x20299540) != 1802658116)
                    {
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Dark Cloud was closed!");
                        break;
                    }
                }

                if (currentFrameCounter < previousFrameCounter || currentFrameCounter > previousFrameCounter + 300 || currentFrameCounter == 0)
                {
                    Thread.Sleep(200);
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Save state detected!");
                    if (Player.InDungeonFloor() == true)
                        Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                    else
                        Memory.WriteByte(Addresses.townSoftReset, 1);

                    ModWindow.SaveStateDetected();
                    
                }

                if (currentFrameCounter > 0)
                {
                    if (Memory.ReadByte(0x21F10020) != 1) //check PNACH flag
                    {
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "PNACH cheats were disabled!");
                        break;
                    }
                }

                previousFrameCounter = currentFrameCounter;

                if (saveStateUsed)
                {
                    break;
                }

                Thread.Sleep(1);
            }

            Memory.WriteByte(0x21F10024, 0); //disable mod's flag for pnach
        }
    }
}
