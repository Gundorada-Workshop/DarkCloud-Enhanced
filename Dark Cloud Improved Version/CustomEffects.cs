using System;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing.Printing;

namespace Dark_Cloud_Improved_Version
{
    public class CustomEffects
    {
        //The current weapon equipped ID by the current loaded character
        public const int currentWeapon = 0x21EA7590;

        //The weapon slot on which the current equipped weapon is (0-9)
        public const int ToanCurrentWeaponSlot = 0x21CDD88C;
        public const int XiaoCurrentWeaponSlot = 0x21CDD88D;
        public const int GoroCurrentWeaponSlot = 0x21CDD88E;
        public const int RubyCurrentWeaponSlot = 0x21CDD88F;
        public const int UngagaCurrentWeaponSlot = 0x21CDD890;
        public const int OsmondCurrentWeaponSlot = 0x21CDD891;

        public const int mode = 0x202A2534; //Values:
                                            //0=Main title
                                            //1=Intro
                                            //2=Town
                                            //3=Dungeon
                                            //4=? (doesnt crash in dungeon)
                                            //5=Opening cutscene(dark shrine),
                                            //6=?
                                            //7=Debug menu

        private static Random random = new Random();

        public const int buttonInputs = 0x21CBC544; //Two-byte Bitfield
                                                    //Square = 128        Cross = 64      Circle = 32       Triangle = 16
                                                    //DPadLeft = 32768        DPadDown = 16384      DPadRight = 8192       DPadUP = 4096
                                                    //Select = 256     L3 = 512      R3 = 1024      Start = 2048
                                                    //L1 = 4        L2 = 1      R1 = 8      R2 = 2


        /****************************************
        *                 Toan                  *
        ****************************************/

        /****************************************
        *                 Xiao                  *
        ****************************************/
        public static void Xiao() //Change on hit to apply stop on all enemies for the current dungeon floor.
        {
            const int dunPositionZ = 0x21EA1D34;
            const int dunPositionX = 0x21EA1D30;
            const int dunPositionY = 0x21EA1D38;

            while (true)
            {
                if(Player.CurrentCharacterNum() == 1)
                {
                    if (Player.GetCurrentWeaponId() == 307) //Dragon's Y ID
                    {
                        float posX = Memory.ReadFloat(dunPositionX);
                        float posY = Memory.ReadFloat(dunPositionY);
                        //float posZ = Memory.ReadFloat(dunPositionZ);
                        ushort healspeed1 = Memory.ReadUShort(0x202A2B88);

                        var i = 0.15; // Set/reset the acceleration variable

                        //To define a dynamic Z axis limit
                        /*
                        if (posZ > 0 && Memory.ReadUShort(buttonInputs) != 65)
                        {
                            upperLimit = posZ + 25;
                            if(upperLimit >= 35)
                            {
                                upperLimit = 35;
                            }
                        }
                        else upperLimit = 25;*/

                        while (Memory.ReadUShort(buttonInputs) == 65        // X + L2 being pressed?
                            && Memory.ReadFloat(dunPositionZ) < 30          // Height below 25 units?
                            && Memory.ReadFloat(dunPositionX) == posX       // Is moving on the X axis?
                            && Memory.ReadFloat(dunPositionY) == posY       // Is moving on the Y axis?
                            && Player.CheckDunIsPaused() == false           // Is paused?
                            && Player.CheckDunFirstPersonMode() == false    // Is in first person?
                            && healspeed1 == Memory.ReadUShort(0x202A2B88)  // Is on a fountain?
                            && Player.CheckDunIsOpeningChest() == false     // Is opening a chest?
                            && Player.CheckDunIsInteracting() == false)     // Is interacting with an element? (Doors, backfloor gates...)
                        {
                            Memory.WriteFloat(dunPositionZ, Memory.ReadFloat(dunPositionZ) + ((float)(0.000001 * i))); //Inittial speed times acceleration
                            i++;
                        }
                    }
                }
            }
        }

        /****************************************
        *                 Goro                  *
        ****************************************/

        /****************************************
        *                 Ruby                  *
        ****************************************/

        /****************************************
        *                Ungaga                 *
        ****************************************/
        public static void Ungaga()
        {
            float formerWhp = 0;
            float currentWhp = 0;

            while (true)
            {
                if (Player.CurrentCharacterNum() == 4) //Is Ungaga?
                {
                    //Check Ungaga's HP
                    ushort formerHP = Memory.ReadUShort(Player.Ungaga.hp);

                    //Check on which slot is the weapon equipped on and save its Whp
                    switch (Memory.ReadByte(UngagaCurrentWeaponSlot))
                    {
                        case 0:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot0.whp);    break;
                        case 1:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot1.whp);    break;
                        case 2:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot2.whp);    break;
                        case 3:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot3.whp);    break;
                        case 4:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot4.whp);    break;
                        case 5:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot5.whp);    break;
                        case 6:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot6.whp);    break;
                        case 7:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot7.whp);    break;
                        case 8:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot8.whp);    break;
                        case 9:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot9.whp);    break;
                    }

                    //Save every enemy's HP on the current floor
                    int[] formerEnemiesHP = {   Memory.ReadUShort(Enemies.Enemy0.hp),
                                                Memory.ReadUShort(Enemies.Enemy1.hp),
                                                Memory.ReadUShort(Enemies.Enemy2.hp),
                                                Memory.ReadUShort(Enemies.Enemy3.hp),
                                                Memory.ReadUShort(Enemies.Enemy4.hp),
                                                Memory.ReadUShort(Enemies.Enemy5.hp),
                                                Memory.ReadUShort(Enemies.Enemy6.hp),
                                                Memory.ReadUShort(Enemies.Enemy7.hp),
                                                Memory.ReadUShort(Enemies.Enemy8.hp),
                                                Memory.ReadUShort(Enemies.Enemy9.hp),
                                                Memory.ReadUShort(Enemies.Enemy10.hp),
                                                Memory.ReadUShort(Enemies.Enemy11.hp),
                                                Memory.ReadUShort(Enemies.Enemy12.hp),
                                                Memory.ReadUShort(Enemies.Enemy13.hp),
                                                Memory.ReadUShort(Enemies.Enemy14.hp),
                                                Memory.ReadUShort(Enemies.Enemy15.hp)};

                    Thread.Sleep(100);

                    //Re-check Ungaga's HP
                    ushort currentHP = Memory.ReadUShort(Player.Ungaga.hp);

                    //Re-check the slot to which the current weapon is equipped on and save its Whp again
                    switch (Memory.ReadUShort(UngagaCurrentWeaponSlot))
                    {
                        case 0:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot0.whp);   break;
                        case 1:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot1.whp);   break;
                        case 2:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot2.whp);   break;
                        case 3:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot3.whp);   break;
                        case 4:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot4.whp);   break;
                        case 5:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot5.whp);   break;
                        case 6:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot6.whp);   break;
                        case 7:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot7.whp);   break;
                        case 8:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot8.whp);   break;
                        case 9:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot9.whp);   break;
                    }

                    //Re-save every enemy's HP on the current floor
                    int[] currentEnemiesHP = {  Memory.ReadUShort(Enemies.Enemy0.hp),
                                                Memory.ReadUShort(Enemies.Enemy1.hp),
                                                Memory.ReadUShort(Enemies.Enemy2.hp),
                                                Memory.ReadUShort(Enemies.Enemy3.hp),
                                                Memory.ReadUShort(Enemies.Enemy4.hp),
                                                Memory.ReadUShort(Enemies.Enemy5.hp),
                                                Memory.ReadUShort(Enemies.Enemy6.hp),
                                                Memory.ReadUShort(Enemies.Enemy7.hp),
                                                Memory.ReadUShort(Enemies.Enemy8.hp),
                                                Memory.ReadUShort(Enemies.Enemy9.hp),
                                                Memory.ReadUShort(Enemies.Enemy10.hp),
                                                Memory.ReadUShort(Enemies.Enemy11.hp),
                                                Memory.ReadUShort(Enemies.Enemy12.hp),
                                                Memory.ReadUShort(Enemies.Enemy13.hp),
                                                Memory.ReadUShort(Enemies.Enemy14.hp),
                                                Memory.ReadUShort(Enemies.Enemy15.hp)};




                    /****************************************
                    *             HERCULES WRATH            *
                    ****************************************/
                    //Chance to gain stamina on getting it
                    if (Player.GetCurrentWeaponId() == 356)
                    {
                        if (currentHP < formerHP)
                        {
                            int procChance = random.Next(0); //Chance to apply stamina (7 = 14.28...%)

                            if(procChance == 0)
                            {
                                Player.Ungaga.SetStatus("stamina",1800); //Give the Stamina effect for 30 seconds
                            }
                        }
                    }




                    /****************************************
                    *              BABEL SPEAL              *
                    ****************************************/

                    if (Player.GetCurrentWeaponId() == 357) { 
                        //Compare the 2nd Whp save with the 1st Whp to check and also the average on all the enemies HP for a difference, this will tell us if the player has hit something
                        if (currentWhp < formerWhp && currentEnemiesHP.Average() < formerEnemiesHP.Average())
                        {
                            int procChance = random.Next(25); //Chance to apply stop (25 = 4%)

                            if (procChance == 0)
                            {
                                Memory.WriteUShort(Enemies.Enemy0.freezeTimer, 300); //Stop duration (300 = 5 seconds)
                                Memory.WriteUShort(Enemies.Enemy1.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy2.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy3.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy4.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy5.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy6.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy7.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy8.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy9.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy10.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy11.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy12.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy13.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy14.freezeTimer, 300);
                                Memory.WriteUShort(Enemies.Enemy15.freezeTimer, 300);
                            }
                        }
                    }
                }
            }
        }
    }
}

