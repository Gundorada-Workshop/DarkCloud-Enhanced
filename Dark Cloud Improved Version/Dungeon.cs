﻿using System;
using System.Threading;
using System.Collections.Generic;

namespace Dark_Cloud_Improved_Version
{
    internal class Dungeon
    {
        public const uint MagicCircleOne_PosX = 0x21DE61C0;
        public const uint MagicCircleOne_PosY = 0x21DE61C8;
        public const uint MagicCircleTwo_PosX = 0x21DE61E0;
        public const uint MagicCircleTwo_PosY = 0x21DE61E8;
        public const uint MagicCircleThree_PosX = 0x21DE61E0;
        public const uint MagicCircleThree_PosY = 0x21DE61E8;

    }

    public class DungeonThread
    {
        static int currentAddress;
        static byte currentDungeon;
        static byte currentFloor;
        static int prevFloor = 200;
        static bool clownOnScreen = false;
        static bool chronicle2 = false;
        static bool[] monstersDead = new bool[15];
        static bool monsterQuestActive = false;
        public static bool monsterQuestMachoActive = false;
        public static bool monsterQuestGobActive = false;
        public static bool monsterQuestJakeActive = false;
        public static bool monsterQuestChiefActive = false;
        public static bool hasMiniBoss = false;
        public static bool enemiesSpawn = false;
        public static List<byte> excludeFloors;
        public static Thread spawnsCheck;
        public static Thread minibossProcess;
        public static Thread miniBossMessage;
        public static Thread AngelGearThread = new Thread(new ThreadStart(CustomEffects.AngelGear));

        public static List<byte> GetDungeonGateKey(byte dungeon)
        {
            List<byte> key = new List<byte>();

            switch (dungeon)
            {
                //DBC
                case 0:
                    key.Add(195); break;
                //Wise Owl
                case 1:
                    key.Add(196); key.Add(198); key.Add(205); break; 
                //Shipwreck
                case 2:
                    key.Add(201); break;
                //Sun&Moon
                case 3:
                    key.Add(202); break;
                //Moon Sea
                case 4:
                    key.Add(203); break;
                //Gallery
                case 5:
                    key.Add(204); break;
                //Demon Shaft
                case 6:
                    key.Add(206); break;
                default:
                    break;
            }
            return key;
        }

        public static byte GetDungeonBackFloorKey(byte dungeon)
        {
            switch (dungeon)
            {
                //DBC
                case 0:
                    return 224;
                //Wise Owl
                case 1:
                    return 225;
                //Shipwreck
                case 2:
                    return 226;
                //Sun&Moon
                case 3:
                    return 228;
                //Moon Sea
                case 4:
                    return 229;
                //Gallery
                case 5:
                    return 230;
                //Demon Shaft
                case 6:
                    return 231;
                default:
                    return 255;
            }
        }

        public static List<byte> GetDungeonEventFloors(byte dungeon)
        {
            List<byte> floors = new List<byte>();

            switch (dungeon)
            {
                //DBC
                case 0:
                    floors.Add(3); floors.Add(7); floors.Add(14); break;
                //Wise Owl
                case 1:
                    floors.Add(8); floors.Add(16); break;
                //Shipwreck
                case 2:
                    floors.Add(8); floors.Add(16); break;
                //Sun&Moon
                case 3:
                    floors.Add(8); floors.Add(17); break;
                //Moon Sea
                case 4:
                    floors.Add(7); floors.Add(14); break;
                //Gallery
                case 5:
                    floors.Add(24); break;
                //Demon Shaft
                case 6:
                    floors.Add(99); break;
                default:
                    break;
            }
            return floors;
        }

        public static void InsideDungeonThread()
        {
            Console.WriteLine("Dungeon Thread Activated");
            while (true)
            {
                if (Player.InDungeonFloor())
                {
                    switch (Player.CurrentCharacterNum())
                    {
                        //Toan
                        case 0:
                            break;

                        //Xiao
                        case 1:
                            switch (Player.GetCurrentWeaponId())
                            {
                                case 307: // Dragon's Y ID
                                    CustomEffects.DragonsY();
                                    break;
                                case 313: //Angel Gear ID
                                    Console.WriteLine(AngelGearThread.ThreadState);
                                    if (AngelGearThread.ThreadState != ThreadState.Unstarted)
                                    {
                                        AngelGearThread = new Thread(new ThreadStart(CustomEffects.AngelGear));
                                        AngelGearThread.Start();
                                    }
                                    break;
                            }
                            break;

                        //Goro
                        case 2:
                            if (Player.GetCurrentWeaponId() == 324) //Tall Hammer ID
                            {
                                CustomEffects.TallHammer();
                            }
                            break;

                        //Ruby
                        case 3:
                            if (Player.GetCurrentWeaponId() == 341) //Mobius Ring ID
                            {
                                CustomEffects.MobiusRing();
                            }
                            break;

                        //Ungaga
                        case 4:
                            switch (Player.GetCurrentWeaponId())
                            {
                                case 356: //Hercules Wrath ID
                                    CustomEffects.HerculesWrath();
                                    break;
                                case 357: //Babel Spear ID
                                    CustomEffects.BabelSpear();
                                    break;
                            }
                            break;

                        //Osmond
                        case 5:
                            if (Player.GetCurrentWeaponId() == 373) //Supernova ID
                            {
                                CustomEffects.Supernova();
                            }
                            break;
                    }

                    //Get current Dungeon
                    currentDungeon = Memory.ReadByte(Addresses.checkDungeon);

                    //Define event and boss floors
                    excludeFloors = GetDungeonEventFloors(currentDungeon);

                    //Get current Floor
                    currentFloor = Memory.ReadByte(Addresses.checkFloor);

                    //Check if the player has entered a new floor
                    if (currentFloor != prevFloor)  
                    {
                        Console.WriteLine("Player has entered a new floor!");

                        //Check if player is not on an event floor and call the Mini Boss
                        if (!excludeFloors.Contains(currentFloor))
                        {
                            //Initialize the spawns check
                            spawnsCheck = new Thread(new ThreadStart (CheckSpawns));
                            spawnsCheck.Start();

                            //Initialize the mini boss thread
                            minibossProcess = new Thread(() => DoMinibossSpawn(currentDungeon));

                            chronicle2 = CustomEffects.CheckChronicle2(chronicle2);
                            CustomChests.ChestRandomizer(currentDungeon, currentFloor, chronicle2);

                            monsterQuestActive = SideQuestManager.CheckCurrentDungeonQuests(currentDungeon);

                            for (int i = 0; i < monstersDead.Length; i++)
                            {
                                monstersDead[i] = false;
                            }
                        }
                        else Console.WriteLine("Player has entered an event floor!");

                        //Once everything is done, we initialize this so it wont reroll again in same floor
                        prevFloor = currentFloor;
                    }

                    //Check if clown is triggered, then change loot table
                    if (Memory.ReadByte(Addresses.clownCheck) == 1 && clownOnScreen == false)
                    {
                        CustomChests.ClownRandomizer(chronicle2);
                        clownOnScreen = true;
                    }
                    else
                    {
                        if (clownOnScreen)
                        {
                            if (Memory.ReadByte(Addresses.clownCheck) == 0)
                            {
                                clownOnScreen = false;
                            }
                        }
                    }

                    if (monsterQuestActive)
                    {
                        for (int i = 0; i < monstersDead.Length; i++)
                        {

                            currentAddress = 0x21E16BC4 + (i * 0x190);

                            if (Memory.ReadUShort(currentAddress) > 0)
                            {
                                monstersDead[i] = false;
                            }
                            else
                            {
                                if (monstersDead[i] == false)
                                {
                                    CheckEnemyKill(currentAddress);
                                }

                                monstersDead[i] = true;
                            }
                        }
                    }

                }                    
                //Used to reset the floor data when going back to dungeon
                else prevFloor = 200;

                Thread.Sleep(10);
            }
        }

        public static void CheckEnemyKill(int currentEnemyAddress)
        {
            Console.WriteLine("Checking quest...");
            if (monsterQuestMachoActive)
            {
                Console.WriteLine("Macho quest active");
                int currentEnemyAddress2 = currentEnemyAddress + 0x0000001E;
                if (Memory.ReadByte(currentEnemyAddress2) == Memory.ReadByte(0x21CE4406))
                {
                    Console.WriteLine("Quest progress +1!");
                    byte killsleft = Memory.ReadByte(0x21CE4405);
                    killsleft--;
                    Memory.WriteByte(0x21CE4405, killsleft);

                    if (killsleft == 0)
                    {
                        Console.WriteLine("Quest complete!!");
                        Dayuppy.DisplayMessage("You completed Macho's quest!\nWell done!", 2, 30, 4000);
                        Memory.WriteByte(0x21CE4402, 2);
                        monsterQuestMachoActive = false;
                    }
                }
            }
            if (monsterQuestGobActive)
            {
                Console.WriteLine("Gob quest active");
                int currentEnemyAddress2 = currentEnemyAddress + 0x0000001E;
                if (Memory.ReadByte(currentEnemyAddress2) == Memory.ReadByte(0x21CE440B))
                {
                    Console.WriteLine("Quest progress +1!");
                    byte killsleft = Memory.ReadByte(0x21CE440A);
                    killsleft--;
                    Memory.WriteByte(0x21CE440A, killsleft);

                    if (killsleft == 0)
                    {
                        Console.WriteLine("Quest complete!!");
                        Dayuppy.DisplayMessage("You completed Gob's quest!\nWell done!", 2, 30, 4000);
                        Memory.WriteByte(0x21CE4407, 2);
                        monsterQuestGobActive = false;
                    }
                }
            }
            if (monsterQuestJakeActive)
            {
                Console.WriteLine("Jake quest active");
                int currentEnemyAddress2 = currentEnemyAddress + 0x0000001E;
                if (Memory.ReadByte(currentEnemyAddress2) == Memory.ReadByte(0x21CE4410))
                {
                    Console.WriteLine("Quest progress +1!");
                    byte killsleft = Memory.ReadByte(0x21CE440F);
                    killsleft--;
                    Memory.WriteByte(0x21CE440F, killsleft);

                    if (killsleft == 0)
                    {
                        Console.WriteLine("Quest complete!!");
                        Dayuppy.DisplayMessage("You completed Jake's quest!\nWell done!", 2, 30, 4000);
                        Memory.WriteByte(0x21CE440C, 2);
                        monsterQuestJakeActive = false;
                    }
                }
            }
            if (monsterQuestChiefActive)
            {
                Console.WriteLine("Chief quest active");
                int currentEnemyAddress2 = currentEnemyAddress + 0x0000001E;
                if (Memory.ReadByte(currentEnemyAddress2) == Memory.ReadByte(0x21CE4415))
                {
                    Console.WriteLine("Quest progress +1!");
                    byte killsleft = Memory.ReadByte(0x21CE4414);
                    killsleft--;
                    Memory.WriteByte(0x21CE4414, killsleft);

                    if (killsleft == 0)
                    {
                        Console.WriteLine("Quest complete!!");
                        Dayuppy.DisplayMessage("You completed Chief Bonka´s quest!\nWell done!", 2, 35, 4000);
                        Memory.WriteByte(0x21CE4411, 2);
                        monsterQuestChiefActive = false;
                    }
                }
            }
        }

        public static void CheckSpawns() 
        {
            Console.WriteLine("Checking spawns...");

            int ms = 0;

            //Listens for the enemy render address value to change from 0 or 10 seconds have passed
            //We use the enemy render value here because enemies spawn after chests
            while (Memory.ReadInt(Enemies.Enemy0.renderStatus) == -1 && ms < 10000)
            {
                Thread.Sleep(100);
                ms += 100;
                continue;
            }

            //Set the flag to true
            if(Memory.ReadInt(Enemies.Enemy0.renderStatus) > 0) enemiesSpawn = true;

            byte numNormalEnemies = 0;

            //Get the quantity of normal enemies in the floor
            foreach (byte enemy in Enemies.GetFloorEnemiesIds())
            {
                if (Enemies.GetNormalEnemies().ContainsKey(enemy)) numNormalEnemies++;
            }

            //Check if there are more than 3 normal enemies in the floor
            //This is to account for the Wise Owl 3 keys
            //There needs to be enough normal enemies to roll for the miniboss in order to avoid infinite retries
            if (numNormalEnemies > 3)
            {
                //Start the next thread
                minibossProcess.Start();
            }
            else Console.WriteLine("Not enough normal enemies in floor!");

            Console.WriteLine("Finished spawn checking");

            //Close this thread
            spawnsCheck.Abort();
        }

        public static void DoMinibossSpawn(byte currentDungeon)
        {
            Console.WriteLine("Processing mini boss...");

            hasMiniBoss = MiniBoss.MiniBossSpawn(false, currentDungeon, currentFloor); 

            //If the mini boss spawned, start its warning message thread
            if (hasMiniBoss) { 
                miniBossMessage = new Thread(new ThreadStart(MiniBossMessage));
                miniBossMessage.Start();
            }

            Console.WriteLine("Finished mini boss process!");

            minibossProcess.Abort();
        }

        public static void MiniBossMessage()
        {
            Console.WriteLine("Working on the message...");

            int ms = 0;

            //Wait until we get control, we use the HUD display as a flag
            while (Memory.ReadInt(Addresses.hideHud) == 1 && ms < 5000)
            {
                Thread.Sleep(100);
                ms += 100;
                continue;
            }

            //Check if a dungeon message is displaying
            if (Memory.ReadInt(Addresses.dunMessage) != -1)
            {
                //Reset timer
                ms = 0;

                //Wait for whatever message is currently displaying
                while(Memory.ReadInt(Addresses.dunMessage) != -1 && ms < 5000)
                {
                    Thread.Sleep(100);
                    ms += 100;
                    continue;
                }

                //Display our message
                Dayuppy.DisplayMessage("A mysterious enemy lurks\naround. Be careful!", 2, 24, 4000);
            }
            else Dayuppy.DisplayMessage("A mysterious enemy lurks\naround. Be careful!", 2, 24, 4000);

            Console.WriteLine("Finished message process!");

            miniBossMessage.Abort();
        }
    }
}