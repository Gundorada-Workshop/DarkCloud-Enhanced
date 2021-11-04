using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Dark_Cloud_Improved_Version
{
    public class CustomEffects
    {
        static int currentAddress;
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

        public static void BoneRapierEffect(bool isActive)
        {
            if (isActive)
            {
                //Set BypassBoneDoor
                if (!DungeonThread.IsBypassBoneDoor()) DungeonThread.SetBypassBoneDoor(true);
            }
            //Otherwise reset BypassBoneDoor
            else if (DungeonThread.IsBypassBoneDoor()) DungeonThread.SetBypassBoneDoor(false);
        }

        public static void BoneDoorTrigger()
        {
            while (!DungeonThread.doorIsOpen &&
                    Player.InDungeonFloor() &&
                    Player.Weapon.GetCurrentWeaponId() == 290)
            {
                //Bone door opened through Bone Rapier
                if (Memory.ReadByte(Addresses.dungDoorType) == 250 &&
                    DungeonThread.IsBypassBoneDoor() &&
                    Memory.ReadInt(0x21D56800) == 15903712) //Aux address to help determine if the bone door specifically was opened)
                {
                    int ms = 0;

                    while (Memory.ReadInt(Addresses.hideHud) == 1 && ms < 2000)
                    {
                        Thread.Sleep(100);
                        ms += 100;
                        continue;
                    }

                    //Display our custom message
                    Dayuppy.DisplayMessage("You can hear an ominous voice\nlaughing 'Rattle me bones!'", 2, 29, 4000);
                    DungeonThread.doorIsOpen = true;
                }
                //Bone door opened normally without Bone Rapier
                else if (Memory.ReadByte(Addresses.dungDoorType) == 250 &&
                        !DungeonThread.IsBypassBoneDoor() &&
                        Memory.ReadInt(0x21D56800) == 15903712 //Aux address to help determine if the bone door specifically was opened
                        )
                {
                    DungeonThread.doorIsOpen = true;
                }

                Thread.Sleep(500);
            }
        }

        public static bool CheckChronicle2(bool acquired)
        {
            if (Memory.ReadInt(Player.Toan.WeaponSlot0.id) == 298 || Memory.ReadInt(Player.Toan.WeaponSlot1.id) == 298 || Memory.ReadInt(Player.Toan.WeaponSlot2.id) == 298
                || Memory.ReadInt(Player.Toan.WeaponSlot3.id) == 298 || Memory.ReadInt(Player.Toan.WeaponSlot4.id) == 298 || Memory.ReadInt(Player.Toan.WeaponSlot5.id) == 298
                || Memory.ReadInt(Player.Toan.WeaponSlot6.id) == 298 || Memory.ReadInt(Player.Toan.WeaponSlot7.id) == 298 || Memory.ReadInt(Player.Toan.WeaponSlot8.id) == 298
                || Memory.ReadInt(Player.Toan.WeaponSlot9.id) == 298)
            {
                Console.WriteLine("Player has Chronicle 2");
                acquired = true;
            }
            else
            {
                currentAddress = 0x21CE22D8;
                for (int i = 0; i < 30; i++)
                {
                    if (Memory.ReadInt(currentAddress) == 298)
                    {
                        acquired = true;
                        Console.WriteLine("Player has Chronicle 2 in storage");
                    }
                    currentAddress += 0x000000F8;
                }

                if (acquired != true)
                {
                    Console.WriteLine("Player does not have Chronicle 2");
                    acquired = false;
                }
            }
            return acquired;
        }

        public static void SeventhHeaven()
        {
            //Store the first empty slot
            int slot = Player.Inventory.GetBagAttachmentsFirstAvailableSlot();

            //Store the item in that slot (by default should always be empty)
            int oldItem = Player.Inventory.GetBagAttachments()[slot];

            Thread.Sleep(250);

            //Re-check the item again in the same slot to see if a new item has been acquired
            int newItem = Player.Inventory.GetBagAttachments()[slot];

            //Check if a non gem attachment was obtained and proceed to make a copy of it
            if (newItem != oldItem && newItem >= Items.fire && newItem <= Items.mageslayer)
            {
                const int attachmentOffset = 0x20;
                const int attachmentValuesRange = 0x1F;

                //Store the newly obtained attachment values
                byte[] attachmentValues = Memory.ReadByteArray(Addresses.firstBagAttachment + (attachmentOffset * slot), attachmentValuesRange);

                //If the item is a gem, roll for 50% chance to duplicate
                if(newItem >= Items.garnet && newItem <= Items.turquoise)
                {
                    int roll = random.Next(100);

                    if(roll < 50)
                    {
                        //Put a copy of the same attachment on the next available slot
                        Memory.WriteByteArray(Addresses.firstBagAttachment + (attachmentOffset * Player.Inventory.GetBagAttachmentsFirstAvailableSlot()), attachmentValues);

                        Dayuppy.DisplayMessage("The 7th Heaven has blessed\nyou with a gift!", 2, 27);
                        return;
                    }
                }

                //Put a copy of the same attachment on the next available slot
                Memory.WriteByteArray(Addresses.firstBagAttachment + (attachmentOffset * Player.Inventory.GetBagAttachmentsFirstAvailableSlot()), attachmentValues);

                Dayuppy.DisplayMessage("The 7th Heaven has blessed\nyou with a gift!", 2, 27);
            }
        }

        public static void DragonsY()
        {
            const int dunPositionZ = 0x21EA1D34;
            const int dunPositionX = 0x21EA1D30;
            const int dunPositionY = 0x21EA1D38;

            float posX = Memory.ReadFloat(dunPositionX);
            float posY = Memory.ReadFloat(dunPositionY);
            //float posZ = Memory.ReadFloat(dunPositionZ);
            ushort healspeed1 = Memory.ReadUShort(0x202A2B88);

            var i = 0.15; // Acceleration modifier
            var a = 0.000001; // Base acceleration value

            while (Memory.ReadUShort(Addresses.buttonInputs) == 65        // X + L2 being pressed?
                && Memory.ReadFloat(dunPositionZ) < 30   /*     // Height below 25 units?
                && healspeed1 == Memory.ReadUShort(0x202A2B88)  // Is on a fountain?
                && Memory.ReadFloat(dunPositionX) == posX       // Is moving along the X axis?
                && Memory.ReadFloat(dunPositionY) == posY       // Is moving along the Y axis?
                && Player.CheckDunIsPaused() == false           // Is paused?
                && Player.CheckDunFirstPersonMode() == false    // Is in first person?
                && Player.CheckDunIsOpeningChest() == false     // Is opening a chest?
                && Player.CheckDunIsInteracting() == false*/)   // Is interacting with an element? (Doors, backfloor gates...))     
            {
                Memory.WriteFloat(dunPositionZ, Memory.ReadFloat(dunPositionZ) + ((float)(a * i)));
                i++;
            }
        }
        //Grants the ability to fly upwards

        public static void AngelGear()
        {
            //Initialize variables
            ushort HpValueAdd = 1;
            ushort Delay = 5000;
            ushort XiaoHp = 0;
            ushort XiaoMaxHp = 0;
            bool isHealXiao = false;

            //Run while Angel Gear is equipped and Player is in a non paused state
            while (Player.Weapon.GetCurrentWeaponId() == 313 &&
                    !Player.CheckDunIsInteracting() &&
                    !Player.CheckDunIsOpeningChest() &&
                    !Player.CheckDunIsPaused() &&
                    Player.CheckDunIsWalkingMode())
            {
                //Fetch HP values for characters
                ushort ToanHp = Player.Toan.GetHp();
                ushort ToanMaxHp = Player.Toan.GetMaxHp();
                ushort GoroHp = Player.Goro.GetHp();
                ushort GoroMaxHp = Player.Goro.GetMaxHp();
                ushort RubyHp = Player.Ruby.GetHp();
                ushort RubyMaxHp = Player.Ruby.GetMaxHp();
                ushort UngagaHp = Player.Ungaga.GetHp();
                ushort UngagaMaxHp = Player.Ungaga.GetMaxHp();
                ushort OsmondHp = Player.Osmond.GetHp();
                ushort OsmondMaxHp = Player.Osmond.GetMaxHp();

                //Check for the Heal special attribute on the weapon
                if (Player.Weapon.GetCurrentWeaponSpecial2() % 16 < 8 ||
                    Player.Weapon.GetCurrentWeaponSpecial2() % 16 > 11)
                {
                    isHealXiao = true;
                    XiaoHp = Player.Xiao.GetHp();
                    XiaoMaxHp = Player.Xiao.GetMaxHp();
                }

                //Add the HP value to the characters current HP
                if (ToanHp < ToanMaxHp) Player.Toan.SetHp((ushort)(ToanHp + HpValueAdd));

                Console.WriteLine("Toan HP add: " + (ToanHp + HpValueAdd));

                if (GoroHp < GoroMaxHp) Player.Goro.SetHp((ushort)(GoroHp + HpValueAdd));
                if (RubyHp < RubyMaxHp) Player.Ruby.SetHp((ushort)(RubyHp + HpValueAdd));
                if (UngagaHp < UngagaMaxHp) Player.Ungaga.SetHp((ushort)(UngagaHp + HpValueAdd));
                if (OsmondHp < OsmondMaxHp) Player.Osmond.SetHp((ushort)(OsmondHp + HpValueAdd));
                if (isHealXiao && XiaoHp < XiaoMaxHp) Player.Xiao.SetHp((ushort)(XiaoHp + HpValueAdd));

                //Wait in between additions
                Thread.Sleep(Delay);
            }
        }
        //Applies the Heal regeneration effect to all allies

        public static void TallHammer()
        {
            //Offset between the enemy's dimension addresses
            int scaleOffset = MiniBoss.scaleOffset;

            //Save weapon Whp
            float formerWhp = ReusableFunctions.GetCurrentEquippedWhp(Player.CurrentCharacterNum(), Player.Goro.GetWeaponSlot());

            //Save every enemy's HP on the current floor
            int[] formerEnemyHpList = ReusableFunctions.GetEnemiesHp();

            Thread.Sleep(250);

            //Re-save every enemy's HP on the current floor
            float currentWhp = ReusableFunctions.GetCurrentEquippedWhp(Player.CurrentCharacterNum(), Player.Goro.GetWeaponSlot());

            //Re-save every enemy's HP on the current floor
            int[] currentEnemyHpList = ReusableFunctions.GetEnemiesHp();

            //Compare the 2nd Whp save with the 1st Whp to check for a difference and also the average on all the enemies HP for a difference, this will tell us if the player has hit something
            if (currentWhp < formerWhp && currentEnemyHpList.Average() < formerEnemyHpList.Average())
            {
                //Store the damaged enemies ID onto a list
                List<int> enemyIds = ReusableFunctions.GetEnemiesHitIds(formerEnemyHpList, currentEnemyHpList);

                //Run through the enemies hit
                foreach (int id in enemyIds)
                {
                    //Declare the enemy dimensions based on the enemy that got hit
                    float enemyZeroWidth = Memory.ReadFloat(0x21E18530 + (scaleOffset * id));
                    float enemyZeroHeight = Memory.ReadFloat(0x21E18534 + (scaleOffset * id));
                    float enemyZeroDepth = Memory.ReadFloat(0x21E18538 + (scaleOffset * id));

                    //Set an initial acceleration value
                    float i = 0.15f;

                    //Set a counter for how many times to change the enemy's dimensions (this acts as a duration variable)
                    int counter = 0;

                    //Instructions will run for 1000 times (arbitrary number) and only while the enemy's dimensions are between 30% - 100% of their original size 
                    while (counter < 1000 && ((enemyZeroWidth >= 0.3f && enemyZeroWidth <= 1f) || (enemyZeroHeight >= 0.3f && enemyZeroHeight <= 1f) || (enemyZeroDepth >= 0.3f && enemyZeroDepth <= 1f)))
                    {
                        //Change the each of the enemy axis dimensions (X,Y and Z) based on the offset from the original Enemy 0 address
                        Memory.WriteFloat(MiniBoss.enemyZeroWidth + (scaleOffset * id), enemyZeroWidth - (i * 0.0001f));
                        Memory.WriteFloat(MiniBoss.enemyZeroHeight + (scaleOffset * id), enemyZeroHeight - (i * 0.0001f));
                        Memory.WriteFloat(MiniBoss.enemyZeroDepth + (scaleOffset * id), enemyZeroDepth - (i * 0.0001f));
                        i++;
                        counter++;
                    }
                }
            }
        }
        //Reduces enemies size on hit

        public static void MobiusRing()
        {

            //Check these addresses which tells us if Ruby is charging her attack either in 3rd or 1st person
            if (Memory.ReadUShort(0x21DC4484) == 14 || Memory.ReadUShort(0x21DC4488) == 14 /*&& Memory.ReadUShort(0x21DC448C) == 14*/)
            {
                //Fetch the active orbs
                List<int> OrbIds = RubyOrbs.GetRubyActiveOrbs();

                //Initialize the damage
                var damage = Player.Weapon.GetCurrentWeaponAttack() + Player.Weapon.GetCurrentWeaponMagic();

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
        //Increases damage output the longer you charge an attack

        public static void HerculesWrath()
        //Chance on getting hit to gain Stamina
        {
            //Check Ungaga's HP
            ushort formerHP = Memory.ReadUShort(Player.Ungaga.hp);

            Thread.Sleep(100);

            //Re-check Ungaga's HP
            ushort currentHP = Memory.ReadUShort(Player.Ungaga.hp);

            if (currentHP < formerHP)
            {
                //Declare the scale for the chance to base on (0 - 100)
                int procChance = random.Next(100);

                //Check for the chance to take effect (15 = 15%)
                if (procChance < 15)
                {
                    //Give the Stamina effect for 30 seconds (1800 = 30 seg)
                    Player.Ungaga.SetStatus("stamina", 1800);
                }
            }
        }

        public static void BabelSpear()
        //Chance on hit to apply stop to all enemies
        {
            //Save weapon Whp
            float formerWhp = ReusableFunctions.GetCurrentEquippedWhp(Player.CurrentCharacterNum(), Player.Ungaga.GetWeaponSlot());

            //Save every enemy's HP on the current floor
            int[] formerEnemiesHP = ReusableFunctions.GetEnemiesHp();

            Thread.Sleep(100);

            //Re-save every enemy's HP on the current floor
            float currentWhp = ReusableFunctions.GetCurrentEquippedWhp(Player.CurrentCharacterNum(), Player.Ungaga.GetWeaponSlot()); ;

            //Re-save every enemy's HP on the current floor
            int[] currentEnemiesHP = ReusableFunctions.GetEnemiesHp();

            //Compare the 2nd Whp save with the 1st Whp to check for a difference and also the average on all the enemies HP for a difference, this will tell us if the player has hit something
            if (currentWhp < formerWhp && currentEnemiesHP.Average() != formerEnemiesHP.Average())
            {
                int procChance = random.Next(100); //Chance to apply stop (4%)

                if (procChance < 4)
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

        public static void Supernova()
        //Chance on hit to apply a random status
        {

            //Get a read on all the enemies hp on the current floor
            int[] formerEnemyHpList = ReusableFunctions.GetEnemiesHp();

            Thread.Sleep(100);

            //Get a second read on all the enemies hp on the current floor
            int[] currentEnemyHpList = ReusableFunctions.GetEnemiesHp();

            //Check if any enemy got hit/damaged
            if (currentEnemyHpList.Average() != formerEnemyHpList.Average())
            {
                //Store the damaged enemies ID onto a list
                List<int> enemyIds = ReusableFunctions.GetEnemiesHitIds(formerEnemyHpList, currentEnemyHpList);

                //Go through the enemies IDs
                foreach (int id in enemyIds)
                {
                    int procChance = random.Next(100);    //Roll for chance to proc effect (8% chance)
                    int effect = random.Next(4);        //Roll for which effect to apply (Equal chance)

                    if (procChance <= 100)
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

        public static void StarBreaker()
        //Chance on kill to get an empty synthsphere (Breaks down any weapon)
        {
            //Save every enemy's HP on the current floor
            int[] formerEnemiesHP = ReusableFunctions.GetEnemiesHp();

            Thread.Sleep(250);

            //Re-save every enemy's HP on the current floor
            int[] currentEnemiesHP = ReusableFunctions.GetEnemiesHp();

            List<int> enemiesKilled = ReusableFunctions.GetEnemiesKilledIds(formerEnemiesHP, currentEnemiesHP);

            int roll = random.Next(100);

            //Console.WriteLine("Enemies killed count: " + enemiesKilled.Count);

            if(enemiesKilled.Count > 0 && roll >= 0)
            {
                if (Player.Inventory.GetBagAttachmentsFirstAvailableSlot() >= 0)
                {
                    Player.Inventory.SetBagAttachments(Items.synthsphere);

                    Dayuppy.DisplayMessage("The Star Breaker sent\n you a shooting star!", 2, 22);
                }
            }
        }
    }
}