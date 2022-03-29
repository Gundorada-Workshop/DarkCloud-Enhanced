using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    public class CustomEffects
    {
        static int currentAddress;
        public static bool evilciseNewFloor = false;
        public static bool chronicleNewFloor = false;
        static float chronicleCurrentWHP = 0;
        static float chronicleFormerWHP = 0;
        static int[] chronicleCurrentEnemyHP;
        static int[] chronicleFormerEnemyHP;
        public const int mode = Addresses.mode;                                            

        private static Random random = new Random();
        public static Thread damageFadeoutThread = new Thread(new ThreadStart(DamageFadeout));


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

        public static void Evilcise() //Currently unused effect due to memes happening
        {
            if (evilciseNewFloor == true)
            {
                Thread.Sleep(500);
                for (int i = 0; i < 15; i++)
                {
                    if (Memory.ReadByte(0x21E16BC8 + (i * 0x190)) == 8) 
                    {
                        Memory.WriteUShort(0x21E16C74 + (i * 0x190), 1);
                    }
                }

                for (int i = 0; i < 20; i++)
                {
                    if (Memory.ReadUShort(0x21DD0360 + (i * 0x40)) < 40)
                    {
                        Memory.WriteByte(0x21DD0380 + (i * 0x40), 0);
                    }
                }

                evilciseNewFloor = false;
                Console.WriteLine("Evilcise effect activated!");
            }
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

        public static void ChronicleSword()
        {
            if (chronicleNewFloor == true)
            {
                for (int i = 0; i < 7; i++ )
                {                   
                    Memory.WriteInt(0x21EC828C + (0x60 * i), 0);
                    Memory.WriteInt(0x21EC8290 + (0x60 * i), 158);
                    Memory.WriteInt(0x21EC8294 + (0x60 * i), 12);
                    Memory.WriteInt(0x21EC8298 + (0x60 * i), 18);
                }
                chronicleNewFloor = false;
            }

            Thread.Sleep(50);

            //Save weapon Whp
            chronicleCurrentWHP = ReusableFunctions.GetCurrentEquippedWhp(Player.CurrentCharacterNum(), Player.Toan.GetWeaponSlot());

            //Save every enemy's HP on the current floor
            chronicleCurrentEnemyHP = ReusableFunctions.GetEnemiesHp();

            int damagedEnemyNum = 0;
            if (chronicleCurrentWHP < chronicleFormerWHP && ReusableFunctions.GetRecentDamageDealtByPlayer() > 0)
            {
                float flashRGB_R = 0;
                float flashRGB_G = 0;
                float flashRGB_B = 0;
                float damageDealt = 0;
                for (int i = 0; i < 15; i++)
                {
                    if (chronicleCurrentEnemyHP[i] < chronicleFormerEnemyHP[i])
                    {
                        Console.WriteLine("Damaged enemy number: " + i);
                        damagedEnemyNum = i;
                        flashRGB_R = Memory.ReadFloat(Enemies.Enemy0.flashColorRed + (i * 0x190));
                        flashRGB_G = Memory.ReadFloat(Enemies.Enemy0.flashColorGreen + (i * 0x190));
                        flashRGB_B = Memory.ReadFloat(Enemies.Enemy0.flashColorBlue + (i * 0x190));
                        damageDealt = Memory.ReadInt(0x21DC452C);
                        break; 
                    }
                }

                float[] enemiesDistance = ReusableFunctions.GetEnemiesDistance();
                List<int> enemiesinRange = new List<int>();
                float[] enemiescoordinateX = new float[15];
                float[] enemiescoordinateY = new float[15];
                float[] enemiescoordinateZ = new float[15];
                float[] effectDamage = new float[15];
                int[] effectDamageDigit1 = new int[15];
                int[] effectDamageDigit2 = new int[15];
                int[] effectDamageDigit3 = new int[15];
                int[] effectDamageDigit4 = new int[15];
                int[] effectDamageDigit5 = new int[15];
                //List<float> enemiescoordinateZ = new List<float>();
                //List<float> enemiescoordinateY = new List<float>();

                for (int i= 0; i < 15; i++)
                {
                    if (i != damagedEnemyNum)
                    {
                        if (chronicleCurrentEnemyHP[i] > 0 && enemiesDistance[i] < 300)
                        {
                            if (enemiesDistance[i] > 0)
                            {
                                Console.WriteLine("Enemy " + i + " is in range");
                                enemiesinRange.Add(i);
                            }
                        }
                    }
                }

                if (enemiesinRange.Count > 0) 
                {
                    for (int i = 0; i < enemiesinRange.Count; i++)
                    {
                        Memory.WriteFloat(Enemies.Enemy0.flashColorRed + (0x190 * enemiesinRange[i]), flashRGB_R);
                        Memory.WriteFloat(Enemies.Enemy0.flashColorGreen + (0x190 * enemiesinRange[i]), flashRGB_G);
                        Memory.WriteFloat(Enemies.Enemy0.flashColorBlue + (0x190 * enemiesinRange[i]), flashRGB_B);
                        Memory.WriteFloat(Enemies.Enemy0.flashDuration + (0x190 * enemiesinRange[i]), (float)(0.1));
                        

                        enemiescoordinateX[i] = Memory.ReadFloat(Enemies.Enemy0.locationCoordinateX + (0x190 * enemiesinRange[i]));
                        enemiescoordinateZ[i] = Memory.ReadFloat(Enemies.Enemy0.locationCoordinateZ + (0x190 * enemiesinRange[i]));
                        enemiescoordinateY[i] = Memory.ReadFloat(Enemies.Enemy0.locationCoordinateY + (0x190 * enemiesinRange[i]));

                        Console.WriteLine("Enemy " + enemiesinRange[i] + " XZY coordinates: " + enemiescoordinateX[i] + " " + enemiescoordinateZ[i] + " " + enemiescoordinateY[i]);

                        if (enemiesDistance[enemiesinRange[i]] < 50)
                        {
                            effectDamage[i] = (float)System.Math.Floor(damageDealt / 2);
                        }
                        else
                        {
                            float effectDamagePercent = ((300 - enemiesDistance[enemiesinRange[i]]) / 5); 
                            if (effectDamagePercent < 1)
                            {
                                effectDamagePercent = 1;
                            }
                            effectDamage[i] = (float)System.Math.Floor(damageDealt * (effectDamagePercent / 100));
                        }
                        Console.WriteLine("Enemy " + enemiesinRange[i] + " effect dmg: " + effectDamage[i]);
                        
                    }

                    for (int i = 0; i < enemiesinRange.Count; i++)
                    {
                        int[] digitArray = GetIntArray((int)effectDamage[i]);

                        effectDamageDigit2[i] = -1;
                        effectDamageDigit3[i] = -1;
                        effectDamageDigit4[i] = -1;
                        effectDamageDigit5[i] = -1;
                        if (digitArray.Length > 0)
                        {
                            effectDamageDigit1[i] = digitArray[0];
                        }
                        if (digitArray.Length > 1)
                        {
                            effectDamageDigit2[i] = digitArray[1];
                        }
                        if (digitArray.Length > 2)
                        {
                            effectDamageDigit3[i] = digitArray[2];
                        }
                        if (digitArray.Length > 3)
                        {
                            effectDamageDigit4[i] = digitArray[3];
                        }
                        if (digitArray.Length > 4)
                        {
                            effectDamageDigit5[i] = digitArray[4];
                        }
                    }

                    for (int i = 0; i < enemiesinRange.Count; i++)
                    {
                        Memory.WriteFloat(0x21EC8240 + (0x60 * i), enemiescoordinateX[i]);
                        Memory.WriteFloat(0x21EC8244 + (0x60 * i), enemiescoordinateZ[i] - 3);
                        Memory.WriteFloat(0x21EC8248 + (0x60 * i), enemiescoordinateY[i]);
                        Memory.WriteFloat(0x21EC824C + (0x60 * i), 1);

                        Memory.WriteFloat(0x21EC8254 + (0x60 * i), 0);
                        Memory.WriteFloat(0x21EC8258 + (0x60 * i), 0);
                        Memory.WriteFloat(0x21EC825C + (0x60 * i), 0);
                        Memory.WriteFloat(0x21EC8260 + (0x60 * i), 0);
                        Memory.WriteFloat(0x21EC8264 + (0x60 * i), 0);

                        Memory.WriteInt(0x21EC8268 + (0x60 * i), effectDamageDigit1[i]);
                        Memory.WriteInt(0x21EC826C + (0x60 * i), effectDamageDigit2[i]);
                        Memory.WriteInt(0x21EC8270 + (0x60 * i), effectDamageDigit3[i]);
                        Memory.WriteInt(0x21EC8274 + (0x60 * i), effectDamageDigit4[i]);
                        Memory.WriteInt(0x21EC8278 + (0x60 * i), effectDamageDigit5[i]);

                        Memory.WriteFloat(0x21EC827C + (0x60 * i), 0);
                        Memory.WriteFloat(0x21EC8280 + (0x60 * i), 3);
                        Memory.WriteInt(0x21EC8284 + (0x60 * i), -1);

                        if (i == 7)
                        {
                            break;
                        }
                    }

                    for (int i = 0; i < enemiesinRange.Count; i++)
                    {
                        Memory.WriteInt(0x21EC829C + (0x60 * i), 1);
                        Memory.WriteByte(Enemies.Enemy0.flashActivation + (0x190 * enemiesinRange[i]), 1);

                        int enemyHP = Memory.ReadInt(Enemies.Enemy0.hp + (0x190 * enemiesinRange[i]));
                        int newEnemyHP = (int)(enemyHP - effectDamage[i]);
                        if (newEnemyHP < 1)
                        {
                            newEnemyHP = 1;
                            Memory.WriteByte(Enemies.Enemy0.poisonPeriod + (0x190 * enemiesinRange[i]), 1);
                        }
                        Memory.WriteInt(Enemies.Enemy0.hp + (0x190 * enemiesinRange[i]), newEnemyHP);
                    }

                    if (!damageFadeoutThread.IsAlive)
                    {
                        damageFadeoutThread = new Thread(new ThreadStart(DamageFadeout));
                        damageFadeoutThread.Start();
                    }
                }            
            }
            ReusableFunctions.ClearRecentDamageAndDamageSource();
            chronicleFormerWHP = chronicleCurrentWHP;
            chronicleFormerEnemyHP = chronicleCurrentEnemyHP;
        }

        public static void DamageFadeout()
        {
            Thread.Sleep(500);
            for (int i = 0; i < 7; i++)
            {
                Memory.WriteInt(0x21EC8284 + (0x60 * i), 1);
            }
            Thread.Sleep(200);
            for (int i = 0; i < 7; i++)
            {
                Memory.WriteInt(0x21EC829C + (0x60 * i), 0);
            }
        }

        public static int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            //listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        /// <summary>
        /// Grants the ability to fly upwards
        /// </summary>
        
        public static void DragonsY()
        {/*
            const int dunPositionZ = 0x21EA1D34;
            //const int dunPositionX = 0x21EA1D30;
            //const int dunPositionY = 0x21EA1D38;

            const int xiaoAnimationId = 0x21DC4484;

            //float posX = Memory.ReadFloat(dunPositionX);
            //float posY = Memory.ReadFloat(dunPositionY);
            //float posZ = Memory.ReadFloat(dunPositionZ);
            //ushort healspeed1 = Memory.ReadUShort(0x202A2B88);

            var i = 0.15; // Acceleration modifier
            var a = 0.000001; // Base acceleration value

            while (Memory.ReadUShort(Addresses.buttonInputs) == 1        //L2 being pressed?
                && Memory.ReadUShort(xiaoAnimationId) >= 11 && Memory.ReadUShort(xiaoAnimationId) <= 13
                && Memory.ReadFloat(dunPositionZ) < 30
                
                && !Player.CheckDunIsInteracting()
                && !Player.CheckDunIsOpeningChest()
                && !Player.CheckDunIsPaused()
                
                && healspeed1 == Memory.ReadUShort(0x202A2B88)  // Is on a fountain?
                && Memory.ReadFloat(dunPositionX) == posX       // Is moving along the X axis?
                && Memory.ReadFloat(dunPositionY) == posY       // Is moving along the Y axis?
                && Player.CheckDunIsPaused() == false           // Is paused?
                && Player.CheckDunFirstPersonMode() == false    // Is in first person?
                && Player.CheckDunIsOpeningChest() == false     // Is opening a chest?
                && Player.CheckDunIsInteracting() == false)   // Is interacting with an element? (Doors, backfloor gates...))     
            {
                Memory.WriteFloat(dunPositionZ, Memory.ReadFloat(dunPositionZ) + ((float)(a * i)));
                i++;
            }*/
        }

            /// <summary>
            /// Applies the Heal regeneration effect to all allies
            /// </summary>
            public static void AngelGear()
        {
            //Initialize variables
            ushort HpValueAdd = 1;
            ushort Delay = 5000;
            ushort XiaoHp = 0;
            ushort XiaoMaxHp = 0;
            bool isHealXiao = false;

            //Run while Angel Gear is equipped and Player is in valid state
            while (Player.Weapon.GetCurrentWeaponId() == Items.angelgear &&
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
                    //Console.WriteLine("Toan HP add: " + (ToanHp + HpValueAdd));
                if (GoroHp < GoroMaxHp) Player.Goro.SetHp((ushort)(GoroHp + HpValueAdd));
                if (RubyHp < RubyMaxHp) Player.Ruby.SetHp((ushort)(RubyHp + HpValueAdd));
                if (UngagaHp < UngagaMaxHp) Player.Ungaga.SetHp((ushort)(UngagaHp + HpValueAdd));
                if (OsmondHp < OsmondMaxHp) Player.Osmond.SetHp((ushort)(OsmondHp + HpValueAdd));
                if (isHealXiao && XiaoHp < XiaoMaxHp) Player.Xiao.SetHp((ushort)(XiaoHp + HpValueAdd));

                //Wait in between additions
                Thread.Sleep(Delay);
            }
        }

        /// <summary>
        /// Reduces enemies size on hit
        /// </summary>
        public static void TallHammer()
        {
            //Offset between the enemy's dimension addresses
            int scaleOffset = MiniBoss.scaleOffset;

            //Save every enemy's HP on the current floor
            int[] formerEnemyHpList = ReusableFunctions.GetEnemiesHp();

            Thread.Sleep(250);

            //Re-save every enemy's HP on the current floor
            int[] currentEnemyHpList = ReusableFunctions.GetEnemiesHp();

            int hit = ReusableFunctions.GetRecentDamageDealtByPlayer();

            bool hasHit = hit != 0 && ReusableFunctions.GetRecentDamageDealtByPlayer() != 0;

            if (hasHit)
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
                        //Change each of the enemy axis dimensions (X,Y and Z) based on the offset from the original Enemy 0 address
                        Memory.WriteFloat(MiniBoss.enemyZeroWidth + (scaleOffset * id), enemyZeroWidth - (i * 0.0001f));
                        Memory.WriteFloat(MiniBoss.enemyZeroHeight + (scaleOffset * id), enemyZeroHeight - (i * 0.0001f));
                        Memory.WriteFloat(MiniBoss.enemyZeroDepth + (scaleOffset * id), enemyZeroDepth - (i * 0.0001f));
                        i++;
                        counter++;
                    }
                }

                ReusableFunctions.ClearRecentDamageAndDamageSource();
            }
        }

        /// <summary>
        /// Increase attack power depending on health and thirst
        /// </summary>
        public static void Inferno()
        {
            float goroMaxHP = Player.Goro.GetMaxHp();   //Memory.ReadUShort(0x21CD9556);
            float goroCurrentHP = Player.Goro.GetHp();  //Memory.ReadUShort(0x21CD9562);

            float hpPercentage = 100 - (goroCurrentHP / goroMaxHP * 100);
            //Console.WriteLine("hpPercentage: " + hpPercentage);

            float goroMaxThirst = Memory.ReadFloat(0x21CDD840);
            float goroCurrentThirst = Player.Goro.GetThirst();  //Memory.ReadFloat(0x21CDD858);

            float thirstPercentage = 100 - (goroCurrentThirst / goroMaxThirst * 100);
            //Console.WriteLine("thirstPercentage: " + thirstPercentage);

            //byte currentWepNum = Player.Goro.GetWeaponSlot(); //Memory.ReadByte(0x21CDD88E);

            ushort currentBaseAttack = Player.Weapon.GetCurrentWeaponAttack();//Memory.ReadUShort(Player.Goro.WeaponSlot0.attack + (0xF8 * currentWepNum));

            ushort attachmentsAttack = 0;

            for (int i = 0; i < 4; i++)
            {
                attachmentsAttack += Memory.ReadUShort(0x21EA75C0 + (i * 0x20));
            }

            ushort currentTotalAttack = (ushort)(currentBaseAttack + attachmentsAttack);

            if (currentTotalAttack > 350)
            {
                currentTotalAttack = 350;
            }

            ushort hpAttackBoost = (ushort)((currentTotalAttack / 100) * hpPercentage);

            ushort thirstAttackBoost = (ushort)((currentTotalAttack / 100) * (thirstPercentage / 2));

            Memory.WriteUShort(0x21EA7594, (ushort)(currentTotalAttack + hpAttackBoost + thirstAttackBoost));
        }

        /// <summary>
        /// Increases damage output the longer you charge an attack
        /// </summary>
        public static void MobiusRing()
        {
            //Declare inputs
            string message;
            int height;
            int width;
            int sleep = 1500;
            int chargeGlowTimer = 0x21DC449E;
            ushort chargeTimer = 0;

            //Check these addresses which tells us if Ruby is charging
            if (Player.Ruby.IsChargingAttack())
            {
                //Fetch the active orbs
                List<int> OrbIds = RubyOrbs.GetRubyActiveOrbs();

                //Initialize the damage
                int damage = Player.Weapon.GetCurrentWeaponAttack() + Player.Weapon.GetCurrentWeaponMagic();

                while (Player.Ruby.IsChargingAttack())
                {
                    if (Player.CheckDunIsPaused())
                    {
                        ReusableFunctions.AwaitUnpause(1);
                    }

                    if (damage >= ushort.MaxValue)
                    {
                        damage = ushort.MaxValue;
                    }
                    else damage += damage / 2;

                    if (damage > 9000)
                    {
                        message = "Total damage is over 9000";
                        height = 1;
                        width = message.Length;
                    }
                    else
                    {
                        message = "Total damage " + damage;
                        height = 1;
                        width = message.Length;
                    }

                    //When this timer reaches 17008, Ruby flashes
                    while (Memory.ReadUShort(chargeGlowTimer) < 17008 && Player.Ruby.IsChargingAttack())
                    {
                        if (Player.CheckDunIsPaused())
                        {
                            ReusableFunctions.AwaitUnpause(1);
                        }
                        Thread.Sleep(100);
                        continue;
                    }

                    chargeTimer = Memory.ReadUShort(chargeGlowTimer);
                    if (chargeTimer == 17008)
                    {
                        //Display current damage
                        Dayuppy.DisplayMessage(message, height, width, sleep + 500);

                        Thread.Sleep(sleep);

                        //Reset Flash
                        Memory.WriteUShort(0x21DC449E, 0);
                    }

                    Thread.Sleep(100);
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
        
        /// <summary>
        /// Enables the Secret Armlet special effect:
        /// <br></br>
        /// <br>Makes all magic circle effects turn into positive ones.</br>
        /// </summary>
        /// <param name="isNewFloor">Determines if we have entered a new floor to know if we should run this code again.</param>
        public static bool SecretArmletEnable()
        {
            bool changed = false;

            //Check if any of the spawned circles have a negative effect and change into positive ones
            if (Memory.ReadByte(Addresses.circleSpawn1) != 0 && Memory.ReadByte(Addresses.circleEffect1) > 4)
                { int effectPositive1 = random.Next(5); Memory.WriteByte(Addresses.circleEffect1, (byte)effectPositive1); changed = true; }

            if (Memory.ReadByte(Addresses.circleSpawn2) != 0 && Memory.ReadByte(Addresses.circleEffect2) > 4)
                { int effectPositive2 = random.Next(5); Memory.WriteByte(Addresses.circleEffect2, (byte)effectPositive2); changed = true; }

            if (Memory.ReadByte(Addresses.circleSpawn3) != 0 && Memory.ReadByte(Addresses.circleEffect3) > 4)
                { int effectPositive3 = random.Next(5); Memory.WriteByte(Addresses.circleEffect3, (byte)effectPositive3); changed = true; }

            if (changed) return true; else return false;
        }

        /// <summary>
        /// Disables the Secret Armlet special effect and re-rolls any present magic circle outcome
        /// </summary>
        public static bool SecretArmletDisable()
        {
            bool changed = false;

            //Re-roll the existing circles
            if (Memory.ReadByte(Addresses.circleSpawn1) != 0)
                { int effectPositive1 = random.Next(10); Memory.WriteByte(Addresses.circleEffect1, (byte)effectPositive1); changed = true; }

            if (Memory.ReadByte(Addresses.circleSpawn2) != 0)
                { int effectPositive2 = random.Next(10); Memory.WriteByte(Addresses.circleEffect2, (byte)effectPositive2); changed = true; }

            if (Memory.ReadByte(Addresses.circleSpawn3) != 0)
                { int effectPositive3 = random.Next(10); Memory.WriteByte(Addresses.circleEffect3, (byte)effectPositive3); changed = true; }

            if (changed) return true; else return false;
        }

        /// <summary>
        /// Chance on getting hit to gain Stamina
        /// </summary>
        public static void HerculesWrath()
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

        /// <summary>
        /// Chance on hit to apply stop to all enemies
        /// </summary>
        public static void BabelSpear()
        {
            int hit = ReusableFunctions.GetRecentDamageDealtByPlayer();

            bool hasHit = hit > -1 && ReusableFunctions.GetDamageSourceCharacterID() == 4;

            if (hasHit)
            {
                int procChance = random.Next(100); //Chance to apply stop (4%)

                if (procChance < 50)
                {
                    if(Memory.ReadByte(Enemies.Enemy0.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy0.freezeTimer, 300); //Stop duration (300 = 5 seconds)
                    if (Memory.ReadByte(Enemies.Enemy1.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy1.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy2.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy2.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy3.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy3.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy4.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy4.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy5.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy5.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy6.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy6.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy7.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy7.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy8.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy8.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy9.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy9.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy10.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy10.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy11.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy11.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy12.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy12.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy13.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy13.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy14.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy14.freezeTimer, 300);
                    if (Memory.ReadByte(Enemies.Enemy15.renderStatus) == 2) Memory.WriteUShort(Enemies.Enemy15.freezeTimer, 300);
                }
            }
            ReusableFunctions.ClearRecentDamageAndDamageSource();
        }

        /// <summary>
        /// Chance on hit to apply a random status
        /// </summary>
        public static void Supernova()
        {
            //Get a read on all the enemies hp on the current floor
            int[] formerEnemyHpList = ReusableFunctions.GetEnemiesHp();

            Thread.Sleep(250);

            int hit = ReusableFunctions.GetRecentDamageDealtByPlayer();

            bool hasHit = hit != 0 && ReusableFunctions.GetRecentDamageDealtByPlayer() != 0;

            if (hasHit)
            {
                //Get a second read on all the enemies hp on the current floor
                int[] currentEnemyHpList = ReusableFunctions.GetEnemiesHp();

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

        /// <summary>
        /// Chance on kill to get an empty synthsphere (Breaks down any weapon)
        /// </summary>
        public static void StarBreaker()
        {
            //Save every enemy's HP on the current floor
            int[] formerEnemiesHP = ReusableFunctions.GetEnemiesHp();

            Thread.Sleep(250);

            //Re-save every enemy's HP on the current floor
            int[] currentEnemiesHP = ReusableFunctions.GetEnemiesHp();

            List<int> enemiesKilled = ReusableFunctions.GetEnemiesKilledIds(formerEnemiesHP, currentEnemiesHP);

            int roll = random.Next(100);

            //Console.WriteLine("Enemies killed count: " + enemiesKilled.Count);

            if(enemiesKilled.Count > 0 && roll < 100)
            {
                if (Player.Inventory.GetBagAttachmentsFirstAvailableSlot() >= 0)
                {
                    Player.Inventory.SetBagAttachments(Items.synthsphere);

                    Dayuppy.DisplayMessage("The Star Breaker sent\nyou a shooting star!", 2, 21);
                }
            }
        }
    }
}