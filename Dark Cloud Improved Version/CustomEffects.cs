using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Dark_Cloud_Improved_Version
{
    public class CustomEffects
    {
        int[] currentEnemyHp = ReusableFunctions.GetEnemiesHp();

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

        public static void Xiao()
        {
            const int dunPositionZ = 0x21EA1D34;
            const int dunPositionX = 0x21EA1D30;
            const int dunPositionY = 0x21EA1D38;

            while (true)
            {
                if (Player.CurrentCharacterNum() == 1)
                {

                    /****************************************
                    *               Dragon's Y              * // DO FINAL REVISION
                    ****************************************/

                    if (Player.GetCurrentWeaponId() == 307)
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
                            && Memory.ReadFloat(dunPositionZ) < 30   /*       // Height below 25 units?
                            && healspeed1 == Memory.ReadUShort(0x202A2B88)  // Is on a fountain?
                            && Memory.ReadFloat(dunPositionX) == posX       // Is moving along the X axis?
                            && Memory.ReadFloat(dunPositionY) == posY       // Is moving along the Y axis?
                            && Player.CheckDunIsPaused() == false           // Is paused?
                            && Player.CheckDunFirstPersonMode() == false    // Is in first person?
                            && Player.CheckDunIsOpeningChest() == false     // Is opening a chest?
                            && Player.CheckDunIsInteracting() == false*/)     // Is interacting with an element? (Doors, backfloor gates...))     
                        {
                            Memory.WriteFloat(dunPositionZ, Memory.ReadFloat(dunPositionZ) + ((float)(0.000001 * i))); //Initial speed times acceleration
                            i++;
                        }
                    }
                }
            }
        }

        public static void Ruby()
        {
            while (true)
            {
                if (Player.CurrentCharacterNum() == 3 && Player.InDungeonFloor())
                {
                    /****************************************
                    *             MOBIUS RING               * 
                    ****************************************/

                    //Keeps increasing the damage while charging an attack
                    if (Player.GetCurrentWeaponId() == 341)
                    {
                        //Check these addresses which tells us if Ruby is charging her attack either in 3rd or 1st person
                        if(Memory.ReadUShort(0x21DC4484) == 14 || Memory.ReadUShort(0x21DC4488) == 14 /*&& Memory.ReadUShort(0x21DC448C) == 14*/)
                        {
                            //Fetch the active orbs
                            List<int> OrbIds = RubyOrbs.GetRubyActiveOrbs();

                            //Initialize the damage
                            var damage = Player.GetCurrentWeaponAttack() + Player.GetCurrentWeaponMagic();

                            //Declare inputs
                            string message;
                            int height;
                            int width;

                            while (Memory.ReadUShort(0x21DC4494) != 16 && Player.CheckDunIsPaused() == false)
                            {
                                damage += damage / 2;
                                
                                if (damage > 9000)
                                {
                                    message = "Total damage is over 9000";
                                    height = 1;
                                    width = 25;
                                }
                                else
                                {
                                    message = "Total damage " + damage;
                                    height = 1;
                                    width = 17;
                                }
                                //Reset Flash
                                Memory.WriteUShort(0x21DC449E, 0);
                                Thread.Sleep(1000);
                                //Display Message
                                Dayuppy.DisplayMessage(message, height, width);
                            }

                            foreach (int id in OrbIds)
                            {
                                switch (id)
                                {
                                    case 0:
                                        //Check if the orb is still alive
                                        while (Memory.ReadByte(RubyOrbs.Orb0.id) == 1) 
                                        {
                                            Memory.WriteInt(RubyOrbs.Orb0.damage, damage); //Set the damage
                                        }
                                        break;
                                    case 1:
                                        while (Memory.ReadByte(RubyOrbs.Orb1.id) == 1) 
                                        {
                                            Memory.WriteInt(RubyOrbs.Orb1.damage, damage);
                                        }
                                        break;
                                    case 2:
                                        while (Memory.ReadByte(RubyOrbs.Orb2.id) == 1) 
                                        {
                                            Memory.WriteInt(RubyOrbs.Orb2.damage, damage);
                                        }
                                        break;
                                    case 3:
                                        while (Memory.ReadByte(RubyOrbs.Orb3.id) == 1) 
                                    {
                                        Memory.WriteInt(RubyOrbs.Orb3.damage, damage);
                                    }
                                    break;
                                    case 4:
                                        while (Memory.ReadByte(RubyOrbs.Orb4.id) == 1) 
                                        {
                                            Memory.WriteInt(RubyOrbs.Orb4.damage, damage);
                                        }
                                        break;
                                    case 5:
                                        while (Memory.ReadByte(RubyOrbs.Orb5.id) == 1) 
                                    {
                                        Memory.WriteInt(RubyOrbs.Orb5.damage, damage);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

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
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot0.whp); break;
                        case 1:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot1.whp); break;
                        case 2:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot2.whp); break;
                        case 3:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot3.whp); break;
                        case 4:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot4.whp); break;
                        case 5:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot5.whp); break;
                        case 6:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot6.whp); break;
                        case 7:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot7.whp); break;
                        case 8:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot8.whp); break;
                        case 9:
                            formerWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot9.whp); break;
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
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot0.whp); break;
                        case 1:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot1.whp); break;
                        case 2:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot2.whp); break;
                        case 3:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot3.whp); break;
                        case 4:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot4.whp); break;
                        case 5:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot5.whp); break;
                        case 6:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot6.whp); break;
                        case 7:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot7.whp); break;
                        case 8:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot8.whp); break;
                        case 9:
                            currentWhp = Memory.ReadFloat(Player.Ungaga.WeaponSlot9.whp); break;
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

                                        //Chance on getting hit to gain stamina
                                        if (Player.GetCurrentWeaponId() == 356)
                    {
                        if (currentHP < formerHP)
                        {
                            int procChance = random.Next(100);

                            if (procChance < 15)
                            {
                                Player.Ungaga.SetStatus("stamina", 1800); //Give the Stamina effect for 30 seconds
                            }
                        }
                    }




                    /****************************************
                    *              BABEL SPEAL              *
                    ****************************************/

                    //Chance on hit to apply stop to all enemies
                    if (Player.GetCurrentWeaponId() == 357)
                    {
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

        public static void Osmond()
        {
            while (true)
            {
                if (Player.CurrentCharacterNum() == 5)
                {

                    /****************************************
                    *               Supernova               *
                    ****************************************/

                    //Chance of hit to apply a random effect to the enemy
                    if (Player.GetCurrentWeaponId() == 373)
                    {
                        //Get a read on all the enemies hp on the current floor
                        float formerWhp = ReusableFunctions.GetCurrentEquippedWhp(5, Memory.ReadByte(OsmondCurrentWeaponSlot));
                        int[] formerEnemyHpList = ReusableFunctions.GetEnemiesHp();

                        Thread.Sleep(100);

                        //Get a second read on all the enemies hp on the current floor
                        float currentWhp = ReusableFunctions.GetCurrentEquippedWhp(5, Memory.ReadByte(OsmondCurrentWeaponSlot));
                        int[] currentEnemyHpList = ReusableFunctions.GetEnemiesHp();

                        //Console.WriteLine(formerWhp);
                        //Console.WriteLine("New: " + currentWhp);
                        //Console.WriteLine(Memory.ReadByte(OsmondCurrentWeaponSlot));
                        //Console.WriteLine("Whp: " + (currentWhp < formerWhp) +"\n" + "HP: " + (currentEnemyHpList.Average() < formerEnemyHpList.Average()));

                        //Check if any enemy got hit/damaged
                        if (/*currentWhp < formerWhp && */currentEnemyHpList.Average() < formerEnemyHpList.Average())
                        {
                            //Console.WriteLine("I entered the IF");
                            //Store the damaged enemies ID onto a list
                            List<int> enemyIds = ReusableFunctions.GetEnemiesHit(formerEnemyHpList, currentEnemyHpList);

                            //Go through the enemies IDs
                            foreach (int id in enemyIds)
                            {
                                Console.WriteLine(id);              //Prints the damaged enemy IDs
                                int procChance = random.Next(100);    //Roll for chance to proc effect
                                int effect = random.Next(4);        //Roll for which effect to apply

                                if (procChance == 8)
                                {
                                    switch (id)
                                    {
                                        case 0:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy0.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy0.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy0.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy0.gooeyState, 1); break;
                                            }
                                            break;
                                        case 1:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy1.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy1.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy1.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy1.gooeyState, 1); break;
                                            }
                                            break;
                                        case 2:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy2.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy2.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy2.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy2.gooeyState, 1); break;
                                            }
                                            break;
                                        case 3:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy3.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy3.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy3.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy3.gooeyState, 1); break;
                                            }
                                            break;
                                        case 4:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy4.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy4.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy4.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy4.gooeyState, 1); break;
                                            }
                                            break;
                                        case 5:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy5.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy5.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy5.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy5.gooeyState, 1); break;
                                            }
                                            break;
                                        case 6:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy6.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy6.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy6.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy6.gooeyState, 1); break;
                                            }
                                            break;
                                        case 7:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy7.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy7.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy7.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy7.gooeyState, 1); break;
                                            }
                                            break;
                                        case 8:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy8.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy8.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy8.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy8.gooeyState, 1); break;
                                            }
                                            break;
                                        case 9:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy9.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy9.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy9.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy9.gooeyState, 1); break;
                                            }
                                            break;
                                        case 10:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy10.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy10.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy10.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy10.gooeyState, 1); break;
                                            }
                                            break;
                                        case 11:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy11.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy11.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy11.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy11.gooeyState, 1); break;
                                            }
                                            break;
                                        case 12:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy12.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy12.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy12.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy12.gooeyState, 1); break;
                                            }
                                            break;
                                        case 13:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy13.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy13.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy13.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy13.gooeyState, 1); break;
                                            }
                                            break;
                                        case 14:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy14.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy14.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy14.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy14.gooeyState, 1); break;
                                            }
                                            break;
                                        case 15:
                                            switch (effect)
                                            {
                                                case 0: Memory.WriteUShort(Enemies.Enemy15.freezeTimer, 300); break;
                                                case 1: Memory.WriteUShort(Enemies.Enemy15.poisonPeriod, 1); break;
                                                case 2: Memory.WriteUShort(Enemies.Enemy15.staminaTimer, 300); break;
                                                case 3: Memory.WriteUShort(Enemies.Enemy15.gooeyState, 1); break;
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

