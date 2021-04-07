﻿using System;
using System.Threading;

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
        static int currentFloor;
        static int currentDungeon;
        static int prevFloor = 200;
        static bool clownOnScreen = false;
        static bool chronicle2 = false;

        public static void InsideDungeonThread()
        {

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
                            if (Player.GetCurrentWeaponId() == 307) // Dragon's Y ID
                            {
                                CustomEffects.DragonsY();
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
                            if (Player.GetCurrentWeaponId() == 356) //Hercules Wrath ID
                            {
                                CustomEffects.HerculesWrath();
                            }

                            if (Player.GetCurrentWeaponId() == 357) //Babel Spear ID
                            {
                                CustomEffects.BabelSpear();
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

                    currentFloor = Memory.ReadByte(Addresses.checkFloor);

                    if (currentFloor != prevFloor)  //checking if player has entered a new floor
                    {
                        
                        Console.WriteLine("new floor");
                        currentDungeon = Memory.ReadUShort(Addresses.checkDungeon);
                        Thread.Sleep(4000);
                        chronicle2 = CustomEffects.CheckChronicle2(chronicle2);
                        CustomChests.ChestRandomizer(currentDungeon, currentFloor, chronicle2);

                        bool HasMiniBoss = MiniBossThread.MiniBossSpawn();
                        Thread.Sleep(3500); //Wait an addition 3.5 seconds to check if a limited floor message is present
                        int DungeonMessage = Memory.ReadInt(0x21EA76B4);
                        Console.WriteLine(DungeonMessage);

                        if (HasMiniBoss && DungeonMessage == -1)
                        {
                            Dayuppy.DisplayMessage("A mysterious enemy lurks\naround. Be careful!", 2, 24);
                        }
                        if (HasMiniBoss && DungeonMessage != -1)
                        {
                            Thread.Sleep(4100);
                            Dayuppy.DisplayMessage("A mysterious enemy lurks\naround. Be careful!", 2, 24);
                        }

                        prevFloor = currentFloor;   //once everything is done, we initialize this so it wont reroll again in same floor
                    }

                    if (Memory.ReadByte(Addresses.clownCheck) == 1 && clownOnScreen == false) //check if clown is triggered, then change loot table
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
                }
                else
                {
                    prevFloor = 200;    //used to reset the floor data when going back to dungeon
                }
                Thread.Sleep(10);
            }
        }
    }
}