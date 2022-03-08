using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    public class MainMenuThread
    {
        public static bool firstlaunch;
        public static bool ingame;
        public static int PID = 0;
        public static int currentFrameCounter = 0;
        public static int previousFrameCounter = 0;
        public static Thread townThread = new Thread(new ThreadStart(TownCharacter.InitializeChrOffsets));
        public static Thread weaponsThread = new Thread(new ThreadStart(Weapons.WeaponsBalanceChanges));
        public static Thread dungeonthread = new Thread(new ThreadStart(DungeonThread.InsideDungeonThread));

        public static void CheckEmulatorAndGame()
        {
            firstlaunch = true;
            while (true)
            {
                Memory.WriteByte(0x21F10024, 0); //mod's flag for PNACH
                if (PID == 0)
                {
                    PID = Memory.GetProcessID("pcsx2");                   
                }
                //Console.WriteLine("CheckEmulatorAndGame");
                if (PID == 0)
                {
                    //Console.WriteLine("Memory PID 0");
                    Form1.EmulatorCount(0); //no emulators running
                }
                /*else if (PID > 1)
                {
                    Form1.EmulatorCount(2); //more than 1 emulator running
                } */
                else if (PID != 0)
                {
                    Memory.GetProcess(PID);
                    Console.WriteLine(Memory.ReadInt(0x20299540));
                    if (Memory.ReadInt(0x20299540) != 1802658116) //check if DC1 has been booted
                    {
                        
                        Form1.EmulatorCount(1);
                    }
                    else
                    {
                        if (Memory.ReadByte(0x21F10020) == 1) //check PNACH flag
                        {
                            if (firstlaunch)
                            {
                                if (Memory.ReadByte(Addresses.mode) == 2 || Memory.ReadByte(Addresses.mode) == 3) //checks if player is already in-game
                                {
                                    Form1.FirstLaunchGameMode(false);
                                }
                                else
                                {
                                    Form1.FirstLaunchGameMode(true);
                                    firstlaunch = false;
                                    ingame = false;
                                    TitleMenu();
                                }
                            }
                        }
                        else
                        {
                            Form1.PnachNotActive();
                        }
                    }
                }

                Thread.Sleep(1);
            }
        }

        public static void TitleMenu()
        {
            previousFrameCounter = Memory.ReadInt(0x202A2400);
            TownCharacter.InitializeCharacterOffsetValues();
            while (true)
            {
                Memory.WriteByte(0x21F10024, 1); //mod's flag for PNACH
                currentFrameCounter = Memory.ReadInt(0x202A2400);
                int currentMode = Memory.ReadByte(Addresses.mode);
                if (ingame == false)
                {
                    if (currentMode == 2 || currentMode == 3)
                    {
                        ingame = true;
                        weaponsThread = new Thread(() => Weapons.WeaponsBalanceChanges());
                        townThread = new Thread(() => TownCharacter.InitializeChrOffsets());
                        dungeonthread = new Thread(() => DungeonThread.InsideDungeonThread());
                        if (!weaponsThread.IsAlive) weaponsThread.Start();
                        if (!townThread.IsAlive) townThread.Start();
                        if (!dungeonthread.IsAlive) dungeonthread.Start(); 
                    }
                }
                else
                {
                    if (currentMode == 0 || currentMode == 1)
                    {
                        ingame = false;
                    }
                }

                if (currentFrameCounter < previousFrameCounter || currentFrameCounter > previousFrameCounter + 300)
                {
                    if (currentFrameCounter > 10)
                    {
                        Console.WriteLine("Save state detected!");
                        if (Player.InDungeonFloor() == true)
                            Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                        else
                            Memory.WriteByte(Addresses.mode, 1);
                    }
                }

                if (Memory.ReadInt(0x20299540) != 1802658116)
                {
                    Console.WriteLine("Dark Cloud was closed!");
                    break;
                }

                if (Memory.ReadByte(0x21F10020) != 1) //check PNACH flag
                {
                    Console.WriteLine("PNACH cheats were disabled!");
                    break;
                }

                previousFrameCounter = currentFrameCounter;

                Thread.Sleep(1);
            }
        }
    }
}
