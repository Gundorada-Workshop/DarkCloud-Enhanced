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
        public static void DragonsYEffect() //Change on hit to apply stop on all enemies for the current dungeon floor.
        {
            const int dunPositionZ = 0x21EA1D34;
            var setZ = 19.9;
            var i = 0.14;
            //Dragon's Y ID                              Xiao
            while (Memory.ReadUShort(currentWeapon) == 307 && Player.CurrentCharacterNum() == 1)
            {
                Console.WriteLine("Dragon's Y is running");
                while(Memory.ReadUShort(buttonInputs) == 65 && Memory.ReadFloat(dunPositionZ) < 25) // X + L2
                {
                    Console.WriteLine("Inputs are being read");
                    Memory.WriteFloat(dunPositionZ, (Memory.ReadFloat(dunPositionZ)+((float)(0.000002 * i))));
                    i++;
                }
                i = 0.1;
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

        public static void BabelSpearEffect() //Change on hit to apply stop on all enemies for the current dungeon floor.
        {
            float formerWhp = 0;
            float currentWhp = 0;

            /*Console.WriteLine("Current character: " + Player.CurrentCharacterNum());
            Console.WriteLine("Current weapon: " + Memory.ReadUShort(currentWeapon));
            Console.WriteLine("Current weapon slot: " + Memory.ReadByte(UngagaCurrentWeaponSlot));*/

                                              //Babel Spear's ID                            Ungaga
            while (Memory.ReadUShort(currentWeapon) == 357 && Player.CurrentCharacterNum() == 4)
            {
            Console.WriteLine("Babel is running");

                //Check on which slot is the weapon equipped on and save its Whp
                switch (Memory.ReadByte(UngagaCurrentWeaponSlot))
                {
                    case 0:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot0.whp);
                        break;

                    case 1:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot1.whp);
                        break;

                    case 2:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot2.whp);
                        break;

                    case 3:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot3.whp);
                        break;

                    case 4:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot4.whp);
                        break;

                    case 5:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot5.whp);
                        break;

                    case 6:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot6.whp);
                        break;

                    case 7:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot7.whp);
                        break;

                    case 8:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot8.whp);
                        break;

                    case 9:
                        formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot9.whp);
                        break;
                }

                //Console.WriteLine("Former Whp: " + formerWhp);

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

                //Console.WriteLine("Former Enemies HP: " + formerEnemiesHP);

                Thread.Sleep(100);

                //Re-check the slot to which the current weapon is equipped on and save its Whp again
                switch (Memory.ReadUShort(UngagaCurrentWeaponSlot))
                {
                    case 0:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot0.whp);
                        break;

                    case 1:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot1.whp);
                        break;

                    case 2:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot2.whp);
                        break;

                    case 3:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot3.whp);
                        break;

                    case 4:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot4.whp);
                        break;

                    case 5:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot5.whp);
                        break;

                    case 6:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot6.whp);
                        break;

                    case 7:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot7.whp);
                        break;

                    case 8:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot8.whp);
                        break;

                    case 9:
                        currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot9.whp);
                        break;
                }

                //Console.WriteLine("Current Whp: " + currentWhp);

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

                //Console.WriteLine("Current Enemies HP: " + currentEnemiesHP);

                //Compare the 2nd Whp save with the 1st Whp to check and also the average on all the enemies HP for a difference, this will tell us if the player has hit something
                if (currentWhp < formerWhp && currentEnemiesHP.Average() < formerEnemiesHP.Average())
                {                       
                    int procChance = random.Next(0); //Chance to apply stop (25 = 4%)

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

        /****************************************
        *                Osmond                 *
        ****************************************/
    }
}
