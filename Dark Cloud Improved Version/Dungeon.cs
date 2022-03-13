using System;
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
        static bool eventfloor = false;
        static bool squareActive = false;
        static bool dunEscapeConfirm = false;
        static bool dunEscapeConfirmSpamCheck = false;
        static bool dunUsedActiveEscape = false;
        static bool dunUsedEscapeCheck = false;
        static bool wepMenuOpen = false;
        static bool PPowdermenuOpen = false;
        static byte[] wepLevelArray = new byte[10];
        public static bool monsterQuestMachoActive = false;
        public static bool monsterQuestGobActive = false;
        public static bool monsterQuestJakeActive = false;
        public static bool monsterQuestChiefActive = false;
        public static bool sambaChallengeQuest = false;
        public static bool sambaChallengeQuestActive = false;
        public static bool sambaChallengeQuestCheck = false;
        public static bool mayorQuest = false;
        public static bool mayorQuestCheck = false;
        public static bool mayorQuestActive = false;
        public static bool hasMiniBoss = false;
        public static bool enemiesSpawn = false;
        public static bool doorIsOpen = false;
        public static bool magicCircleChanged = false;
        public static List<byte> excludeFloors;

        //THREADS
        //Runs at the start of each floor
        public static Thread spawnsCheck;
        public static Thread minibossProcess;
        public static Thread miniBossMessage;
        
        //Weapon threads, only 1 should run at a time
        public static Thread boneDoorThread = new Thread(new ThreadStart(CustomEffects.BoneDoorTrigger));
        public static Thread seventhHeavenThread = new Thread(new ThreadStart(CustomEffects.SeventhHeaven));
        public static Thread chronicleSwordThread = new Thread(new ThreadStart(CustomEffects.ChronicleSword));
        public static Thread evilciseThread = new Thread(new ThreadStart(CustomEffects.Evilcise));
        public static Thread dragonsYThread = new Thread(new ThreadStart(CustomEffects.DragonsY));
        public static Thread angelGearThread = new Thread(new ThreadStart(CustomEffects.AngelGear));
        public static Thread tallHammerThread = new Thread(new ThreadStart(CustomEffects.TallHammer));
        public static Thread infernoHammerThread = new Thread(new ThreadStart(CustomEffects.Inferno));
        public static Thread mobiusRingThread = new Thread(new ThreadStart(CustomEffects.MobiusRing));
        public static Thread herculesWrathThread = new Thread(new ThreadStart(CustomEffects.HerculesWrath));
        public static Thread babelSpearThread = new Thread(new ThreadStart(CustomEffects.BabelSpear));
        public static Thread supernovaThread = new Thread(new ThreadStart(CustomEffects.Supernova));
        public static Thread starBreakerThread = new Thread(new ThreadStart(CustomEffects.StarBreaker));
        public static Thread elementSwapThread = new Thread(new ThreadStart(Dayuppy.ElementSwapping)); //Create a new thread to run monitorElementSwapping()
        public static Thread dunEscapeConfirmThread;

        public static Thread cheatCodeThread = new Thread(new ThreadStart(CheatCodes.InputBuffer.Monitor));
        public static void InsideDungeonThread()
        {
            Console.WriteLine("Dungeon Thread Activated");
            cheatCodeThread = new Thread(new ThreadStart(CheatCodes.InputBuffer.Monitor));
            elementSwapThread = new Thread(new ThreadStart(Dayuppy.ElementSwapping));
            cheatCodeThread.Start();
            elementSwapThread.Start();
            Resources.initiateRubyMemeFix();
            while (true)
            {
                if (Player.InDungeonFloor())
                {
                    if (!Player.CheckDunIsPaused() && Player.CheckDunIsWalkingMode())
                    {
                        switch (Player.CurrentCharacterNum())
                        {
                            //Toan
                            case 0:
                                if(magicCircleChanged) CustomEffects.SecretArmletDisable(); magicCircleChanged = false;

                                switch (Player.Weapon.GetCurrentWeaponId())
                                {
                                    case Items.bonerapier:
                                        CustomEffects.BoneRapierEffect(true);

                                        if (!boneDoorThread.IsAlive)
                                        {
                                            boneDoorThread = new Thread(new ThreadStart(CustomEffects.BoneDoorTrigger));
                                            boneDoorThread.Start();
                                        }
                                        break;
                                    case Items.seventhheaven:
                                        CustomEffects.BoneRapierEffect(false);

                                        if (!seventhHeavenThread.IsAlive)
                                        {
                                            seventhHeavenThread = new Thread(new ThreadStart(CustomEffects.SeventhHeaven));
                                            seventhHeavenThread.Start();
                                        }
                                        break;
                                    case Items.chroniclesword:
                                        CustomEffects.BoneRapierEffect(false);

                                        if (!chronicleSwordThread.IsAlive)
                                        {
                                            chronicleSwordThread = new Thread(new ThreadStart(CustomEffects.ChronicleSword));
                                            chronicleSwordThread.Start();
                                        }
                                        break;



                                    default:
                                        CustomEffects.BoneRapierEffect(false);
                                        break;
                                }
                                break;

                            //Xiao
                            case 1:
                                CustomEffects.BoneRapierEffect(false);
                                if (magicCircleChanged) CustomEffects.SecretArmletDisable(); magicCircleChanged = false;

                                switch (Player.Weapon.GetCurrentWeaponId())
                                {
                                    case Items.dragonsy:
                                        if (!dragonsYThread.IsAlive)
                                        {
                                            dragonsYThread = new Thread(new ThreadStart(CustomEffects.DragonsY));
                                            dragonsYThread.Start();
                                        }
                                        break;

                                    case Items.angelgear:
                                        if (!angelGearThread.IsAlive)
                                        {
                                            angelGearThread = new Thread(new ThreadStart(CustomEffects.AngelGear));
                                            angelGearThread.Start();
                                        }
                                        break;
                                }
                                break;

                            //Goro
                            case 2:
                                CustomEffects.BoneRapierEffect(false);
                                if (magicCircleChanged) CustomEffects.SecretArmletDisable(); magicCircleChanged = false;

                                switch (Player.Weapon.GetCurrentWeaponId())
                                {
                                    case Items.tallhammer:
                                        if (!tallHammerThread.IsAlive)
                                        {
                                            tallHammerThread = new Thread(new ThreadStart(CustomEffects.TallHammer));
                                            tallHammerThread.Start();
                                        }
                                        break;
                                    case Items.inferno:
                                        if (!infernoHammerThread.IsAlive)
                                        {
                                            infernoHammerThread = new Thread(new ThreadStart(CustomEffects.Inferno));
                                            infernoHammerThread.Start();
                                        }
                                        break;

                                    default:
                                        break;
                                }
                                break;

                            //Ruby
                            case 3:
                                CustomEffects.BoneRapierEffect(false);

                                switch (Player.Weapon.GetCurrentWeaponId())
                                {
                                    case Items.mobiusring:
                                        if (magicCircleChanged) CustomEffects.SecretArmletDisable(); magicCircleChanged = false;

                                        if (!mobiusRingThread.IsAlive)
                                        {
                                            mobiusRingThread = new Thread(new ThreadStart(CustomEffects.MobiusRing));
                                            mobiusRingThread.Start();
                                        }
                                        break;
                                    case Items.secretarmlet:
                                        if (!magicCircleChanged) { 
                                            bool executed = CustomEffects.SecretArmletEnable();
                                            if(executed) magicCircleChanged = true;
                                        }
                                        break;
                                    default:
                                        if (magicCircleChanged) CustomEffects.SecretArmletDisable(); magicCircleChanged = false;
                                        break;
                                }
                                break;

                            //Ungaga
                            case 4:
                                CustomEffects.BoneRapierEffect(false);
                                if (magicCircleChanged) CustomEffects.SecretArmletDisable(); magicCircleChanged = false;


                                switch (Player.Weapon.GetCurrentWeaponId())
                                {
                                    case Items.herculeswrath:
                                        if (!herculesWrathThread.IsAlive)
                                        {
                                            herculesWrathThread = new Thread(new ThreadStart(CustomEffects.HerculesWrath));
                                            herculesWrathThread.Start();
                                        }
                                        break;

                                    case Items.babelsspear:
                                        if (!babelSpearThread.IsAlive)
                                        {
                                            babelSpearThread = new Thread(new ThreadStart(CustomEffects.BabelSpear));
                                            babelSpearThread.Start();
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            //Osmond
                            case 5:
                                CustomEffects.BoneRapierEffect(false);
                                if (magicCircleChanged) CustomEffects.SecretArmletDisable(); magicCircleChanged = false;

                                switch (Player.Weapon.GetCurrentWeaponId())
                                {
                                    case Items.supernova:
                                        if (!supernovaThread.IsAlive)
                                        {
                                            supernovaThread = new Thread(new ThreadStart(CustomEffects.Supernova));
                                            supernovaThread.Start();
                                        }
                                        break;

                                    case Items.starbreaker:
                                        if (!starBreakerThread.IsAlive)
                                        {
                                            starBreakerThread = new Thread(new ThreadStart(CustomEffects.StarBreaker));
                                            starBreakerThread.Start();
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                        }

                        CheckActiveItems();
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

                        doorIsOpen = false;
                        magicCircleChanged = false;
                        dunUsedActiveEscape = false;
                        dunUsedEscapeCheck = false;

                        //Check if player is not on an event floor and call the Mini Boss
                        if (!excludeFloors.Contains(currentFloor))
                        {
                            //Initialize the spawns check
                            Memory.WriteInt(Enemies.Enemy0.hp, 1);
                            spawnsCheck = new Thread(new ThreadStart(CheckSpawns));
                            spawnsCheck.Start();

                            //Initialize the mini boss thread
                            minibossProcess = new Thread(() => DoMinibossSpawn(currentDungeon));                         

                            monsterQuestActive = SideQuestManager.CheckCurrentDungeonQuests(currentDungeon);

                            for (int i = 0; i < monstersDead.Length; i++)
                            {
                                monstersDead[i] = false;
                            }

                            eventfloor = false;
                        }
                        else
                        {
                            eventfloor = true;
                            Console.WriteLine("Player has entered an event floor!");
                        }

                        FixUngagaDoors(currentDungeon);

                        //Once everything is done, we set this so it wont reroll again in same floor
                        prevFloor = currentFloor;
                    }

                    CheckWepLvlUp();
                    CheckClown();
                    CheckCurrentSidequests();
                    CheckDungeonLeaving();
                  

                }
                //Used to reset the floor data when going back to dungeon
                else prevFloor = 200;

                if (MainMenuThread.userMode == true)
                {
                    if (Memory.ReadByte(Addresses.mode) == 0 || Memory.ReadByte(Addresses.mode) == 1)
                    {
                        Thread.Sleep(100);
                        if (Memory.ReadByte(Addresses.mode) == 0 || Memory.ReadByte(Addresses.mode) == 1)
                        {
                            Console.WriteLine("Not ingame anymore! Exited from DungeonThread!");
                            break;
                        }
                    }
                }

                Thread.Sleep(10);
            }
        }

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

            //Listens for the enemy render address value to change, from 0 or 10 seconds have passed
            //We use the enemy render value here because enemies spawn after chests
            while (Memory.ReadInt(Enemies.Enemy0.hp) == 1 && ms < 1000)
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

            chronicle2 = CustomEffects.CheckChronicle2(chronicle2);
            CustomChests.ChestRandomizer(currentDungeon, currentFloor, chronicle2); //Randomize the chest loot

            CheckSidequests();

            //CustomEffects.evilciseNewFloor = true;
            CustomEffects.chronicleNewFloor = true;
            ReusableFunctions.ClearRecentDamageAndDamageSource();

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

        public static bool IsBypassBoneDoor()
        {
            return Memory.ReadByte(Addresses.BoneDoorOpenType) == 5 ? true: false;
        }

        public static void SetBypassBoneDoor(bool flag)
        {
            byte n;
            if (flag) n = 5;
            else n = 21;
            Memory.WriteByte(Addresses.BoneDoorOpenType, n);
        }

        public static void FixUngagaDoors(byte currentdng)
        {
            switch (currentdng)
            {
                case 3:
                    if (Memory.ReadFloat(0x20928670) == 150)
                    {
                        Memory.WriteByte(0x20985E0, 30);
                        Memory.WriteFloat(0x20928670, 50);
                        Memory.WriteFloat(0x20928928, 50);
                        Memory.WriteByte(0x20928B14, 30);
                        Memory.WriteByte(0x20928AE4, 30);
                        Console.WriteLine("Fixed Ungaga Doors");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't fix ungaga doors, or they were fixed already");
                    }
                    break;

                case 4:
                    if (Memory.ReadFloat(0x2092FA08) == 150)
                    {
                        Memory.WriteByte(0x2092F978, 30);
                        Memory.WriteFloat(0x2092FA08, 50);
                        Memory.WriteFloat(0x2092FCC0, 50);
                        Memory.WriteByte(0x2092FEAC, 30);
                        Memory.WriteByte(0x2092FE7C, 30);
                        Console.WriteLine("Fixed Ungaga Doors");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't fix ungaga doors, or they were fixed already");
                    }
                    break;

                case 5:
                    if (Memory.ReadFloat(0x209244AC) == 150)
                    {
                        Memory.WriteByte(0x2092441C, 30);
                        Memory.WriteFloat(0x209244AC, 50);
                        Memory.WriteFloat(0x20924764, 50);
                        Memory.WriteByte(0x20924920, 30);
                        Memory.WriteByte(0x20924950, 30);
                        Console.WriteLine("Fixed Ungaga Doors");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't fix ungaga doors, or they were fixed already");
                    }
                    break;

                default:
                    break;

            }
        }

        public static void CheckClown()
        {
            //Check if clown is triggered, then change loot table
            if (Memory.ReadInt(Addresses.clownCheck) == 30707852 && clownOnScreen == false && eventfloor == false)
            {
                CustomChests.ClownRandomizer(chronicle2);
                clownOnScreen = true;
            }
            else
            {
                if (clownOnScreen)
                {
                    if (Memory.ReadInt(Addresses.clownCheck) != 30707852)
                    {
                        clownOnScreen = false;
                    }
                }
            }
        }

        public static void CheckSidequests()
        {
            if (currentDungeon == 4 && currentFloor == 6 && Memory.ReadByte(0x21CE445E) == 1)
            {
                Console.WriteLine("Yellow drops challenge active");
                sambaChallengeQuest = true;
            }
            else
            {
                sambaChallengeQuest = false;
            }

            if (currentDungeon == 6)
            {
                if (Memory.ReadByte(0x21CE4468) == 1) //Mayor quest flag
                {
                    if (currentFloor == Memory.ReadByte(0x21CE4469) -1)
                    {
                        mayorQuest = true;
                        Console.WriteLine("Mayor quest active in this floor");
                    }
                    else
                    {
                        mayorQuest = false;
                    }
                }
                else
                {
                    mayorQuest = false;
                }
            }
            else
            {
                mayorQuest = false;
            }
        }

        public static void CheckCurrentSidequests()
        {
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

            if (sambaChallengeQuest)
            {
                SambaChallengeQuest();
            }

            if (mayorQuest)
            {
                MayorQuest();
            }
        }

        public static void SambaChallengeQuest()
        {
            ushort currentweaponID = Memory.ReadUShort(0x21EA7590);
            if (sambaChallengeQuestCheck == false && Memory.ReadByte(0x202A34CC) == 1)
            {
                if (Memory.ReadByte(Addresses.hideHud) == 0)
                {
                    if (Memory.ReadByte(0x202A3570) == 0 && (currentweaponID == 258 || currentweaponID == 257))
                    {
                        Memory.WriteInt(0x21CE205C, 0);
                        Dayuppy.DisplayMessage("Samba's quest started!\nClear all enemies using only Dagger!\nUsing a throwable also\ncancels the mission.", 4, 40, 8000);
                        sambaChallengeQuestActive = true;

                        for (int i = 0; i < 8; i++)
                        {
                            monstersDead[i] = false;
                        }
                    }
                    else if (Memory.ReadByte(0x202A3570) == 0 && currentweaponID != 258 && currentweaponID != 257)
                    {
                        Dayuppy.DisplayMessage("Samba's quest did not start.\nRe-enter with Dagger equipped.", 2, 30, 4000);
                        sambaChallengeQuestActive = false;
                    }
                    sambaChallengeQuestCheck = true;
                }
            }
            else if (sambaChallengeQuestCheck == true && Memory.ReadByte(0x202A34CC) == 0)
            {
                sambaChallengeQuestCheck = false;
                sambaChallengeQuestActive = false;
            }

            if (sambaChallengeQuestActive)
            {
                if ((currentweaponID != 258 && currentweaponID != 257) || Memory.ReadByte(0x21DC4484) == 26 || Memory.ReadByte(0x21DC4484) == 27)
                {
                    Thread.Sleep(500);
                    Dayuppy.DisplayMessage("Samba's quest has been cancelled.\nYou need to re-enter.", 2, 40, 4000);
                    sambaChallengeQuestActive = false;
                }
                byte enemieskilled = 0;
                for (int i = 0; i < 8; i++)
                {
                    currentAddress = 0x21E16BC4 + (i * 0x190);

                    if (Memory.ReadUShort(currentAddress) > 0)
                    {
                        monstersDead[i] = false;
                    }
                    else
                    {
                        monstersDead[i] = true;
                        enemieskilled++;
                    }
                }

                if (enemieskilled == 8)
                {
                    Dayuppy.DisplayMessage("Samba's quest completed!\nWell done!", 2, 28, 4000);
                    Memory.WriteByte(0x21CE4462, 1);
                    sambaChallengeQuest = false;
                }
            }
        }

        public static void MayorQuest()
        {
            if (mayorQuestCheck == false && Memory.ReadByte(0x202A34CC) == 1)
            {
                if (Memory.ReadByte(Addresses.hideHud) == 0)
                {
                    if (Memory.ReadByte(0x202A3570) == Memory.ReadByte(0x21CE446A)) //check if correct ally for quest
                    {
                        Memory.WriteInt(0x21CE205C, 0);
                        Dayuppy.DisplayMessage("Mayor's quest started!\nClear all enemies.\nCannot change character.\nThrowables are not allowed.", 4, 26, 5000);

                        mayorQuestActive = true;

                        for (int i = 0; i < 8; i++)
                        {
                            monstersDead[i] = false;
                        }
                    }
                    else
                    {
                        Dayuppy.DisplayMessage("Mayor's quest did not start.\nRe-enter with correct ally.", 2, 30, 4000);
                        mayorQuestActive = false;
                    }
                    mayorQuestCheck = true;
                }
            }
            else if (mayorQuestCheck == true && Memory.ReadByte(0x202A34CC) == 0)
            {
                mayorQuestCheck = false;
                mayorQuestActive = false;
            }

            if (mayorQuestActive)
            {
                if (Memory.ReadByte(0x21DC4484) == 26 || Memory.ReadByte(0x21DC4484) == 27)
                {
                    Thread.Sleep(500);
                    Dayuppy.DisplayMessage("Mayor's quest has been cancelled.\nYou need to re-enter.", 2, 40, 4000);
                    mayorQuestActive = false;
                }

                byte enemieskilled = 0;
                for (int i = 0; i < 8; i++)
                {
                    currentAddress = 0x21E16BC4 + (i * 0x190);

                    if (Memory.ReadUShort(currentAddress) > 0)
                    {
                        monstersDead[i] = false;
                    }
                    else
                    {
                        monstersDead[i] = true;
                        enemieskilled++;
                    }
                }

                if (enemieskilled == 8)
                {
                    Dayuppy.DisplayMessage("Mayor's quest completed!\nWell done!", 2, 28, 4000);
                    Memory.WriteByte(0x21CE4468, 2);
                    mayorQuest = false;
                }
            }
        }

        public static void CheckActiveItems()
        {
            if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)CheatCodes.InputBuffer.Button.Square)
            {
                int currentSlot = Memory.ReadInt(0x202A3598);
                int currentActiveItem = 0x21CDD8AC + (0x2 * currentSlot);

                if (Memory.ReadShort(currentActiveItem) == 175)
                {
                    if (Memory.ReadByte(0x21DC4484) == 0 || Memory.ReadByte(0x21DC4484) == 1 || Memory.ReadByte(0x21DC4484) == 2)
                    {
                        if (squareActive == false)
                        {
                            if (dunEscapeConfirm == false)
                            {
                                squareActive = true;
                                Dayuppy.DisplayMessage("^RAre you sure you want to leave?\n^WPress square to use Escape Powder.", 2, 36, 3000);
                                dunEscapeConfirmThread = new Thread(() => DunEscapeConfirmTimer());
                                dunEscapeConfirmThread.Start();
                                dunEscapeConfirm = true;
                                dunEscapeConfirmSpamCheck = false;
                            }
                            else if (dunEscapeConfirm)
                            {
                                if (dunEscapeConfirmSpamCheck == true)
                                {
                                    if (Memory.ReadByte(0x202A35EC) == 0)
                                    {
                                        squareActive = true;
                                        dunUsedActiveEscape = true;
                                        Console.WriteLine("Activated escape powder!");
                                        Memory.WriteByte(0x202A35EC, 170);
                                        byte currentPowders = Memory.ReadByte(0x21CDD8B2 + (0x2 * currentSlot));
                                        currentPowders--;
                                        Memory.WriteByte(0x21CDD8B2 + (0x2 * currentSlot), currentPowders);
                                        if (currentPowders == 0)
                                        {
                                            Memory.WriteUShort(currentActiveItem, 65535);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (Memory.ReadShort(currentActiveItem) == 177)
                {
                    if (Memory.ReadByte(0x21DC4484) == 0 || Memory.ReadByte(0x21DC4484) == 1 || Memory.ReadByte(0x21DC4484) == 2)
                    {
                        if (squareActive == false)
                        {
                            ushort currentmaxWHP = Player.Weapon.GetCurrentWeaponMaxWhp();

                            int currentChar = Memory.ReadByte(0x21CD9550);
                            int currentWepNum = Memory.ReadByte(0x21CDD88C + (0x1 * currentChar));
                            int whp;

                            if (currentChar == 0)
                            {
                                whp = Player.Toan.WeaponSlot0.whp + (0xF8 * currentWepNum);
                            }
                            else if (currentChar == 1)
                            {
                                whp = Player.Xiao.WeaponSlot0.whp + (0xF8 * currentWepNum);
                            }
                            else if (currentChar == 2)
                            {
                                whp = Player.Goro.WeaponSlot0.whp + (0xF8 * currentWepNum);
                            }
                            else if (currentChar == 3)
                            {
                                whp = Player.Ruby.WeaponSlot0.whp + (0xF8 * currentWepNum);
                            }
                            else if (currentChar == 4)
                            {
                                whp = Player.Ungaga.WeaponSlot0.whp + (0xF8 * currentWepNum);
                            }
                            else
                            {
                                whp = Player.Osmond.WeaponSlot0.whp + (0xF8 * currentWepNum);
                            }
                            float currentWHP = Memory.ReadFloat(whp);
                            if (currentWHP < currentmaxWHP)
                            {                         
                                Memory.WriteFloat(whp, currentmaxWHP);
                                Dayuppy.DisplayMessage("Used Repair Powder!", 1, 20, 2000);
                                byte currentPowders = Memory.ReadByte(0x21CDD8B2 + (0x2 * currentSlot));
                                currentPowders--;
                                Memory.WriteByte(0x21CDD8B2 + (0x2 * currentSlot), currentPowders);
                                squareActive = true;
                                if (currentPowders == 0)
                                {
                                    Memory.WriteUShort(currentActiveItem, 65535);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                squareActive = false;
            }          
        }

        public static void DunEscapeConfirmTimer()
        {
            Thread.Sleep(500);
            dunEscapeConfirmSpamCheck = true;
            Thread.Sleep(2500);
            dunEscapeConfirm = false;
        }

        public static void CheckDungeonLeaving()
        {
            if (dunUsedActiveEscape == false && dunUsedEscapeCheck == false)
            {
                if (Memory.ReadByte(0x202A35EC) == 171)
                {
                    CheckEscapePowders();
                    dunUsedEscapeCheck = true;
                }
            }
        }

        public static void CheckEscapePowders()
        {
            bool hasEscapeP = SideQuestManager.CheckItemQuestReward(175, true, false);

            if (hasEscapeP == false)
            {
                if (Memory.ReadByte(0x21CDD8AE) == 175)
                {
                    byte currentPowders = Memory.ReadByte(0x21CDD8B4);
                    currentPowders--;
                    Memory.WriteByte(0x21CDD8B4, currentPowders);
                    if (currentPowders == 0)
                    {
                        Memory.WriteUShort(0x21CDD8AE, 0);
                    }
                    Console.WriteLine("Consumed escape powder from active slots");
                }
                else if (Memory.ReadByte(0x21CDD8B0) == 175) 
                {
                    byte currentPowders = Memory.ReadByte(0x21CDD8B6);
                    currentPowders--;
                    Memory.WriteByte(0x21CDD8B6, currentPowders);
                    if (currentPowders == 0)
                    {
                        Memory.WriteUShort(0x21CDD8B0, 0);
                    }
                    Console.WriteLine("Consumed escape powder from active slots");

                }
                else if (Memory.ReadByte(0x21CDD8B2) == 175)
                {
                    byte currentPowders = Memory.ReadByte(0x21CDD8B8);
                    currentPowders--;
                    Memory.WriteByte(0x21CDD8B8, currentPowders);
                    if (currentPowders == 0)
                    {
                        Memory.WriteUShort(0x21CDD8B2, 0);
                    }
                    Console.WriteLine("Consumed escape powder from active slots");
                }
            }
        }

        public static void CheckWepLvlUp()
        {
            byte menuMode = Memory.ReadByte(0x202A2010);
            if (menuMode == 2 || menuMode == 1)
            {

                if (wepMenuOpen == false)
                {
                    for (int i = 0; i < wepLevelArray.Length; i++)
                    {
                        wepLevelArray[i] = Memory.ReadByte(0x21CDDA5A + (i * 0xF8));
                    }
                    wepMenuOpen = true;
                }
                else
                {
                    if (menuMode == 1) 
                    {
                        if (Memory.ReadByte(0x21D9EC08) == 6)
                        {
                            for (int i = 0; i < wepLevelArray.Length; i++)
                            {
                                wepLevelArray[i] = Memory.ReadByte(0x21CDDA5A + (i * 0xF8));
                            }
                            PPowdermenuOpen = true;
                        }
                        else
                        {
                            if (PPowdermenuOpen == true)
                            {
                                for (int i = 0; i < wepLevelArray.Length; i++)
                                {
                                    if (Memory.ReadByte(0x21CDDA5A + (i * 0xF8)) > wepLevelArray[i])
                                    {
                                        CheckSoZEffect(i);
                                        wepLevelArray[i] = Memory.ReadByte(0x21CDDA5A + (i * 0xF8));
                                    }
                                }
                            }
                            PPowdermenuOpen = false;
                        }                                            
                    }
                    else if (menuMode == 2)
                    {
                        for (int i = 0; i < wepLevelArray.Length; i++)
                        {
                            if (Memory.ReadByte(0x21CDDA5A + (i * 0xF8)) > wepLevelArray[i])
                            {
                                Console.WriteLine("Weapon(sword) leveled up!");
                                CheckSoZEffect(i);
                                wepLevelArray[i] = Memory.ReadByte(0x21CDDA5A + (i * 0xF8));
                            }
                        }
                    }
                }
            }
            else
            {
                wepMenuOpen = false;
            }
        }

        public static void CheckSoZEffect(int wepOffset)
        {
            ushort wepID = Memory.ReadUShort(Player.Toan.WeaponSlot0.id + (0xF8 * wepOffset));

            if (wepID == 296)
            {
                Console.WriteLine("SoZ leveled up!");
                byte currentThunder = Memory.ReadByte(Player.Toan.WeaponSlot0.thunder + (0xF8 * wepOffset));
                ushort storedThunder = (ushort)(Memory.ReadUShort(0x21CE446D) + currentThunder);
                if (storedThunder > 30000)
                {
                    storedThunder = 30000;
                }
                Memory.WriteByte(Player.Toan.WeaponSlot0.thunder + (0xF8 * wepOffset), 0);
                if (Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD + (0xF8 * wepOffset)) == 2)
                {
                    Memory.WriteByte(Player.Toan.WeaponSlot0.elementHUD + (0xF8 * wepOffset), 5);
                }
                Memory.WriteUShort(0x21CE446D, storedThunder);
                ChangeSoZMaxAtt(storedThunder);

            }
        }

        public static void ChangeSoZMaxAtt(ushort storedThunder)
        {
            ushort maxAttack = 199;
            if (storedThunder > 200)
            {
                if (storedThunder > 500)
                {
                    if (storedThunder > 1000)
                    {
                        if (storedThunder > 2000)
                        {
                            maxAttack = 599;
                            storedThunder -= 2000;

                            ushort attackboost = (ushort)(storedThunder / 20);
                            maxAttack = (ushort)(maxAttack + attackboost);
                        }
                        else
                        {
                            maxAttack = 499;
                            storedThunder -= 1000;

                            ushort attackboost = (ushort)(storedThunder / 10);
                            maxAttack = (ushort)(maxAttack + attackboost);
                        }
                    }
                    else
                    {
                        maxAttack = 399;
                        storedThunder -= 500;

                        ushort attackboost = (ushort)(storedThunder / 5);
                        maxAttack = (ushort)(maxAttack + attackboost);
                    }
                }
                else
                {
                    maxAttack = 299;
                    storedThunder -= 200;

                    ushort attackboost = (ushort)(storedThunder / 3);
                    maxAttack = (ushort)(maxAttack + attackboost);
                }
            }
            else
            {
                ushort attackboost = (ushort)(storedThunder / 2);
                maxAttack = (ushort)(maxAttack + attackboost);
                Console.WriteLine("maxattack: " + maxAttack);
            }
            Console.WriteLine("SoZ max attack changed!");
            Memory.WriteUShort(0x2027B298, maxAttack);
        }

    }
}