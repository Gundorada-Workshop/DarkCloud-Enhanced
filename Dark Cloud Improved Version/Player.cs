using System;

namespace Dark_Cloud_Improved_Version
{
    internal class Player
    {
        public const int gilda = 0x21CDD892;
        public const int inventoryCurrentSize = 0x21CDD8AD;
        public const int inventoryTotalSize = 0x21CDD8AC;
        public const int inventorySizeWeapons = 65;
        public const int inventorySizeAttachments = 40;

        public const int magicCrystal = 0x202A35A0;
        public const int map = 0x202A359C;
        public const int miniMap = 0x202A35B0;
        public const int visibility = 0x202A359C;

        public const int mostRecentDamage = 0x21DC452C; //most recent damage caused by the player, either with character or throwable
        public const int damageSource = 0x21DC4530; //source of damage, either character ID or throwable (-1)

        public const int positionX = 0x21D331D8;
        public const int positionY = 0x21D331D0;
        public const int positionZ = 0x21D331D4;
        public const int dunPositionX = 0x21EA1D30;
        public const int dunPositionY = 0x21EA1D38;
        public const int dunPositionZ = 0x21EA1D34;

        public const int townState = 0x202A1F50;            //Check Addresses.cs for value description
        public const int townFirstPerson = 0x202A26E0;      //0 = 3rd Person, 1 = 1st Person
        public const int dunCameraPerspective = 0x202A35EC; //0 = Normal
                                                            //10 = FPS
                                                            //155 = Static

        public const int Ultraman = 0x21D564B0;

        public const int currentCharacter = 0x20429E80;     //Tells the current player selected, string 4bytes long


        public static int CurrentCharacterNum()
        {
            if (Memory.ReadInt(currentCharacter) == 1680945251)
                return 0;
            else if (Memory.ReadInt(currentCharacter) == 1647587427)
                return 1;
            else if (Memory.ReadInt(currentCharacter) == 1630941283)
                return 2;
            else if (Memory.ReadInt(currentCharacter) == 1630875747)
                return 3;
            else if (Memory.ReadInt(currentCharacter) == 1630548323)
                return 4;
            else if (Memory.ReadInt(currentCharacter) == 1631072611)
                return 5;

            else return 255;
        }

        public static string GetCharacterName(int character)
        {
            switch (character)
            {
                case 0: return "Toan";
                case 1: return "Xiao";
                case 2: return "Goro";
                case 3: return "Ruby";
                case 4: return "Ungaga";
                case 5: return "Osmond";
                default: return null;
            }
        }

        public static bool InDungeonFloor()
        {
            if (Memory.ReadByte(0x21CD954F) != 255)  //Value is 255 when in town AND dungeon select, changes when floor is loaded. This also triggers when entering and leaving the menu in a dungeon.
                return true;

            else
                return false;
        }

        public ushort Gilda
        {
            get
            {
                ushort value = Memory.ReadUShort(gilda);
                Console.WriteLine("Player has " + value + " Gilda");
                return value;
            }
            set
            {
                Console.WriteLine("Player's Gilda was set to: " + value);
                Memory.WriteUShort(gilda, value);
            }
        }

        public static bool CheckTownFirstPersonMode()
        {
            if (Memory.ReadUShort(townFirstPerson) == 1)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckDunFirstPersonMode()
        {
            if (Memory.ReadUShort(dunCameraPerspective) == 10)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckDunIsOpeningChest()
        {
            if (Memory.ReadUShort(dunCameraPerspective) == 121 ||   //Big Chest
                Memory.ReadUShort(dunCameraPerspective) == 131)     //Normal Chest
            {
                return true;
            }
            else return false;
        }

        public static bool CheckDunIsInteracting()
        {
            if (Memory.ReadUShort(dunCameraPerspective) == 400 ||
                Memory.ReadUShort(dunCameraPerspective) == 401)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckTownIsPaused()
        {
            if (Memory.ReadUShort(townState) == 9)
            {
                return true;
            }
            else return false;
        }

        public static bool CheckDunIsPaused()
        {
            int dunPauseTitle = 0x202A35C4;
            int dunPausePlayerState = 0x202A3564;
            int dunPauseEnemyState = 0x202A34DC;

            if (Memory.ReadUShort(dunPausePlayerState) == 1
                && Memory.ReadUShort(dunPauseEnemyState) == 1
                && Memory.ReadUShort(dunPauseTitle) == 1
                && Memory.ReadUShort(dunCameraPerspective) == 155)
            {
                return true;
            }

            else return false;
        }

        public static bool CheckIsWorldMapMenu()
        {
            if (Memory.ReadUShort(townState) == 8) return true;
            else return false;
        }

        public static bool CheckIsGeoramaMode()
        {
            if (Memory.ReadUShort(townState) == 4) return true;
            else return false;
        }

        public static bool CheckIsFishingMode()
        {
            if (Memory.ReadUShort(townState) == 16) return true;
            else return false;
        }

        public static bool CheckDunIsWalkingMode()
        {
            if (Memory.ReadUShort(Addresses.dungeonMode) == 1) return true;
            else return false;
        }

        internal class Inventory
        {
            public static int GetBagCurrentCount()
            {
                /*int bagItemQuantity = 0;
                int activeItemQuantity = GetActiveItemsQuantity();

                foreach (int item in GetBagItems()){
                    if (item != -1) bagItemQuantity++; 
                }

                return bagItemQuantity + activeItemQuantity;*/

                return Memory.ReadByte(inventoryCurrentSize);

            }

            public static bool CheckBagItemsFull()
            {
                int currentCount = GetBagCurrentCount();
                int maxCount = Memory.ReadByte(inventoryTotalSize);

                if (currentCount >= maxCount) return true;
                else return false;
            }

            public static int[] GetActiveItems()
            {
                const byte itemOffset = 0x2;
                int[] activeItems = new int[3];

                for (int slot = 0; slot < 3; slot++)
                {
                    int itemId = Memory.ReadUShort(Addresses.activeItem1 + (itemOffset * slot));

                    //Check if the item is an inventory item
                    if (itemId >= Items.dummy129 && itemId <= Items.dummy256)
                    {
                        activeItems[slot] = itemId;
                    }
                    else activeItems[slot] = -1;
                }

                return activeItems;
            }

            public static int GetActiveItemsQuantity()
            {
                const byte itemOffset = 0x2;
                int quantityTotal = 0;
                
                for (int slot = 0; slot < 3; slot++)
                {
                    int itemQuantity = Memory.ReadUShort(Addresses.activeItem1Quantity + (itemOffset * slot));
                    quantityTotal += itemQuantity;
                }

                return quantityTotal;
            }

            public static void SetActiveItem(byte activeItemSlot, int itemId, int quantity)
            {

                int inventorySize = Memory.ReadByte(inventoryTotalSize);

                if (GetBagCurrentCount() < inventorySize)
                {
                    try
                    {
                        switch (activeItemSlot)
                        {
                            case 0:
                                Memory.WriteUShort(Addresses.activeItem1, (ushort)itemId);
                                Memory.WriteUShort(Addresses.activeItem1Quantity, (ushort)quantity);
                                break;
                            case 1:
                                Memory.WriteUShort(Addresses.activeItem2, (ushort)itemId);
                                Memory.WriteUShort(Addresses.activeItem2Quantity, (ushort)quantity);
                                break;
                            case 2:
                                Memory.WriteUShort(Addresses.activeItem3, (ushort)itemId);
                                Memory.WriteUShort(Addresses.activeItem3Quantity, (ushort)quantity);
                                break;
                            default:
                                Console.WriteLine("\nSetActiveItems: Arguments out of range!");
                                break;
                        }
                    }
                    catch { Console.WriteLine("\nInvalid inputs for SetActiveItem!"); };
                }
                else Console.WriteLine("\nBag inventory is full!");
            }

            public static int[] GetBagItems()
            
            {
                const byte itemOffset = 0x2;
                byte inventorySize = Memory.ReadByte(inventoryTotalSize);
                int[] inventoryItems = new int[inventorySize + 2]; //The 2 is to account for 2 extra yellow item slots

                //Run through the inventory bag
                for (int slot = 0; slot < inventorySize; slot++)
                {
                    //Read the current item ID
                    int itemId = Memory.ReadUShort(Addresses.firstBagItem + (itemOffset * slot));

                    //Check if the item is an inventory item, store the ID if it is; -1 if it isn't (aka empty)
                    if (itemId >= Items.dummy129  && itemId <= Items.dummy256) {
                        inventoryItems[slot] = itemId;
                    } else inventoryItems[slot] = -1;
                }
                Console.WriteLine("\nFinished GetBagItems process!");
                //foreach(int item in inventoryItems) Console.WriteLine(item);
                return inventoryItems;
            }

            public static int GetBagItemsFirstAvailableSlot()
            {
                int slot = 0;
                int[] inventoryBag = GetBagItems();

                foreach (int item in inventoryBag)
                {
                    //Run until it find an empty slot and return the slot number if found
                    if (item == -1)
                    {
                        //Console.WriteLine("\nFinished GetBagItemsFirstAvailableSlot process: " + slot);
                        return slot;
                    }
                    slot++;
                }

                //Return -1 if no empty slot was found
                return -1;
            }

            public static void SetBagItems(int slot, int itemId)
            {
                const byte itemOffset = 0x2;

                try
                {
                    if(GetBagItems()[slot] != -1) 
                        Memory.WriteUShort(Addresses.firstBagItem + (slot * itemOffset), (ushort)itemId);
                }
                catch
                {
                    if (slot > inventoryTotalSize && itemId >= Items.dummy129 || itemId <= Items.dummy256) SetBagItems(GetBagItemsFirstAvailableSlot(), itemId);
                    else Console.WriteLine("\nInvalid inputs for SetBagItems");
                }
                Console.WriteLine("\nFinished SetBagItems process!");
            }

            public static int[] GetBagWeapons(int character = -1)
            
            {
                int slot;
                int maxslot;
                int inventorySize;
                const int weaponOffset = 0xF8;
                const int characterWeaponOffset = 0xAA8;

                //Define the correct slot ranges to search in
                if (character != -1)
                {
                    slot = 0;
                    maxslot = 9;
                    inventorySize = 10;
                }
                else
                {
                    slot = 0;
                    maxslot = 64;
                    inventorySize = inventorySizeWeapons;
                }

                //Initialize the array
                int[] inventoryWeapons = new int[inventorySize];

                Console.WriteLine("GetBagWeapons for character " + GetCharacterName(character) + " process started!");

                //Run through the weapons bag
                while (slot <= maxslot)
                {
                    if (character == -1)
                    {
                        //Print the slots and skip the empty gaps between characters while printing their respecting name
                        switch (slot)
                        {
                            case 10: Console.WriteLine("Xiao:"); slot++; continue;
                            case 21: Console.WriteLine("Goro:"); slot++; continue;
                            case 32: Console.WriteLine("Ruby:"); slot++; continue;
                            case 43: Console.WriteLine("Ungaga:"); slot++; continue;
                            case 54: Console.WriteLine("Osmond:"); slot++; continue;
                        }
                    }
                    else if (character != -1 && slot == 0) Console.WriteLine(GetCharacterName(character) + ":");

                    //Store the weapon ID
                    int weaponId = Memory.ReadUShort(Addresses.firstBagWeapon + (weaponOffset * slot) + (characterWeaponOffset * character));

                    //Check if there is a weapon in the slot and store its ID or store -1 if no weapon is found
                    if (weaponId >= Items.brokendagger && weaponId <= Items.swallow)
                    {
                        //Store the weapon ID
                        inventoryWeapons[slot] = weaponId;
                        Console.WriteLine("Slot: " + slot + " WeaponID: " + weaponId);
                    }
                    //Store "empty" if no weapon is found
                    else
                    {
                        inventoryWeapons[slot] = -1;
                        Console.WriteLine("Slot: " + slot + " WeaponID: -1");
                    }

                    slot++;
                }

                /* Debug logs
                Console.WriteLine("\nFinished GetBagWeapons process:");
                foreach (int weapon in inventoryWeapons) Console.WriteLine(weapon);
                */

                Console.WriteLine("GetBagWeapons for character " + GetCharacterName(character) + " process finished!\n");

                //When returning the full weapons inventory (no character specified)
                //there will be a 0 value inbetween every character weapon set due to
                //having an empty range of addresses there, just ignore
                return inventoryWeapons;
            }

            public static int GetBagWeaponsFirstAvailableSlot(int character = -1)
            {
                int slot = 0;
                int[] weaponsBag = GetBagWeapons(character);

                //Console.WriteLine("Started GetBagWeaponsFirstAvailableSlot process!");

                foreach (int item in weaponsBag)
                {
                    //Run until you find an empty slot and return the slot number if found
                    if (item == -1)
                    {
                        Console.WriteLine("Finished GetBagWeaponsFirstAvailableSlot process:\n" + slot + "\n");
                        return slot;
                    }
                    slot++;
                }

                //Console.WriteLine("Finished GetBagWeaponsFirstAvailableSlot process:\nNo empty slot found!\n");

                //Return -1 if no empty slot was found
                return -1;
            }

            //NEEDS REWORK! (Address stat values do not correspond between Base Table and Bag Table)
            /*public static void SetBagWeapons(int weaponId, int slot)
            {
                int owner = -1;
                const int tableWeaponOffset = Weapons.weaponoffset;
                const int weaponValuesRange = 0x47;
                const int weaponBagOffset = 0xF8;
                const int chararacterOffSet = 0x9B0;
                const int tableDaggerFirstAddress = 0x2027A70C;

                //Check to whom the weapon belongs to
                foreach (int weapon in Toan.GetWeaponsList()) { if (weaponId.Equals(weapon)) owner = 0; };
                foreach (int weapon in Xiao.GetWeaponsList()) { if (weaponId.Equals(weapon)) owner = 1; };
                foreach (int weapon in Goro.GetWeaponsList()) { if (weaponId.Equals(weapon)) owner = 2; };
                foreach (int weapon in Ruby.GetWeaponsList()) { if (weaponId.Equals(weapon)) owner = 3; };
                foreach (int weapon in Ungaga.GetWeaponsList()) { if (weaponId.Equals(weapon)) owner = 4; };
                foreach (int weapon in Osmond.GetWeaponsList()) { if (weaponId.Equals(weapon)) owner = 5; };

               
                try
                {
                    if (GetBagWeapons(owner)[slot] == -1)
                    {
                        //Fetch the values from the original values database
                        byte[] weaponValues = Memory.ReadByteArray(tableDaggerFirstAddress + (tableWeaponOffset * (weaponId - Items.dagger)), weaponValuesRange);

                        //Write the values on the specified location
                        Memory.WriteByteArray(Addresses.firstBagWeapon + (chararacterOffSet * owner) + (weaponBagOffset * slot), weaponValues);
                    }
                    else
                    {
                        Console.WriteLine("Slot is not empty!\n Retrying...\n");
                        slot = GetBagWeaponsFirstAvailableSlot(owner);
                        if (slot > -1)
                        {
                            SetBagWeapons(weaponId, slot);
                        }
                        else Console.WriteLine("Inventory is full!\n");
                    }
                }
                catch
                {
                    //If the provided slot is out of bounds, retry again by using the next available free slot
                    Console.WriteLine("Invalid slot input for SetBagWeapons! Revoking function passing slot as GetBagWeaponsFirstAvailableSlot!\n");
                    SetBagWeapons(weaponId, GetBagWeaponsFirstAvailableSlot(owner));
                }

                //Debug
                Console.WriteLine("Table weapon ID: " + Memory.ReadByte(tableDaggerFirstAddress + (tableWeaponOffset * (weaponId - Items.dagger))));
                Console.WriteLine("Weapon Bag Slot: " + Memory.ReadByte(Addresses.firstBagWeapon + (chararacterOffSet * owner) + (weaponBagOffset * slot)));

                Console.WriteLine("\nFinished SetBagWeapons process!\n");
            }*/

            public static int[] GetBagAttachments()
            
            {
                const byte itemOffset = 0x20;
                byte inventorySize = inventorySizeAttachments;
                int[] inventoryAttachments = new int[inventorySize];

                //Console.WriteLine("GetBagAttachments process started!\n");

                //Run through the attachment bag
                for (int slot = 0; slot < inventorySize; slot++)
                {
                    //Store the attachment ID
                    int itemId = Memory.ReadUShort(Addresses.firstBagAttachment + (itemOffset * slot));

                    //Check if there is an attachment in the slot and store its ID or store -1 if no attachment is found
                    if (itemId >= Items.fire && itemId <= 1000)
                    {
                        inventoryAttachments[slot] = itemId;
                        //Console.WriteLine("Slot: " + slot + " AttachmentID: " + itemId);
                    }
                    else
                    {
                        inventoryAttachments[slot] = -1;
                        //Console.WriteLine("Slot: " + slot + " AttachmentID: -1");
                    }
                }

                //Console.WriteLine("\nGetBagAttachments process finished!\n");
                return inventoryAttachments;
            }

            public static int GetBagAttachmentsFirstAvailableSlot()
            {
                int slot = 0;
                int[] attachmentBag = GetBagAttachments();

                //Console.WriteLine("GetBagAttachmentsFirstAvailableSlot process started!\n");

                //Run until you find an empty slot and return the slot number if found
                foreach (int item in attachmentBag)
                {
                    if (item == -1)
                    {
                        //Console.WriteLine("Finished GetBagAttachmentsFirstAvailableSlot process:\nSlot " + slot + "\n");
                        return slot;
                    }
                    slot++;
                }

                //Return -1 if no empty slot was found
                //Console.WriteLine("Attachment bag is full!\n");
                return -1;
            }

            public static void SetBagAttachments(int attachmentId, int slot = -1)
            {
                const int attachmentOffset = 0x20;
                const int attachmentValuesRange = 0x1F;
                const int tableAttachmentFirstAddress = 0x2027CA60;

                if (slot >= 0)
                {
                    if (GetBagAttachments()[slot] == -1)
                    {
                        try
                        {
                            //Fetch the values from the original values database
                            byte[] attachmentValues = Memory.ReadByteArray(tableAttachmentFirstAddress + (attachmentOffset * (attachmentId - Items.fire)), attachmentValuesRange);

                            //Write the values on the specified location
                            Memory.WriteByteArray(Addresses.firstBagAttachment + (attachmentOffset * slot), attachmentValues);
                        }
                        catch
                        {
                            if (slot > inventoryTotalSize && (attachmentId >= Items.fire && attachmentId <= Items.mageslayer)) SetBagAttachments(attachmentId, GetBagAttachmentsFirstAvailableSlot());
                            else Console.WriteLine("Invalid inputs for SetBagAttachments\n");
                        }
                    }
                    else Console.WriteLine("Attachment bag is full!\n");
                }
                else
                {
                    SetBagAttachments(attachmentId, GetBagAttachmentsFirstAvailableSlot());
                    return;
                }

                Console.WriteLine("Finished SetBagAttachments process!\n");
            }
        }

        internal class Weapon
        //The current equipped weapon (THIS IS READ ONLY)
        {
            private const int id = 0x21EA7590;
            private const int level = 0x21EA7592;        //The level # displayed on the weapon name
            private const int attack = 0x21EA7594;
            private const int endurance = 0x21EA7594;
            private const int speed = 0x21EA7594;
            private const int magic = 0x21EA759A;
            private const int maxWhp = 0x21EA759C;
            private const int whp = 0x21EA75A0;
            private const int abs = 0x21EA75A4;
            private const int element = 0x21EA75A6;      //Which element is being used (0-4)
            private const int fire = 0x21EA75A7;
            private const int ice = 0x21EA75A8;
            private const int thunder = 0x21EA75A9;
            private const int wind = 0x21EA75AA;
            private const int holy = 0x21EA75AB;
            private const int aDragon = 0x21EA75AC;
            private const int aUndead = 0x21EA75AD;
            private const int aMarine = 0x21EA75AE;
            private const int aRock = 0x21EA75AF;
            private const int aPlant = 0x21EA75B0;
            private const int aBeast = 0x21EA75B1;
            private const int aSky = 0x21EA75B2;
            private const int aMetal = 0x21EA75B3;
            private const int aMimic = 0x21EA75B4;
            private const int aMage = 0x21EA75B5;
            private const int special1 = 0x21EA767E;     //01 unknown(default on Chronicle 2) | 02 Big bucks | 04 Poor | 08 Quench | 16 Thirst | 32 Poison | 64 Stop | 128 Steal
            private const int special2 = 0x21EA767F;     //02 Durable | 04 Drain | 08 Heal | 16 Critical | 32 Abs Up

            public static ushort GetCurrentWeaponId()
            //Returns the current equipped weapon ID
            {
                return Memory.ReadUShort(id);
            }

            public static byte GetCurrentWeaponAttack()
            //Returns the current equipped weapon Attack
            {
                return Memory.ReadByte(attack);
            }

            public static byte GetCurrentWeaponEndurance()
            //Returns the current equipped weapon Endurance
            {
                return Memory.ReadByte(endurance);
            }

            public static byte GetCurrentWeaponSpeed()
            //Returns the current equipped weapon Speed
            {
                return Memory.ReadByte(speed);
            }

            public static byte GetCurrentWeaponMagic()
            //Returns the current equipped weapon Magic
            {
                return Memory.ReadByte(magic);
            }

            public static float GetCurrentWeaponWhp()
            //Returns the current equipped weapon Whp
            {
                return Memory.ReadFloat(whp);
            }

            public static ushort GetCurrentWeaponMaxWhp()
            //Returns the current equipped weapon Max Whp
            {
                return Memory.ReadUShort(maxWhp);
            }

            public static ushort GetCurrentWeaponAbs()
            //Returns the current equipped weapon Abs
            {
                return Memory.ReadUShort(abs);
            }

            public static byte GetCurrentWeaponElement()
            //Returns the current equipped weapon element
            {
                return Memory.ReadByte(element);
            }

            public static byte GetCurrentWeaponFire()
            //Returns the current equipped weapon Fire
            {
                return Memory.ReadByte(fire);
            }

            public static byte GetCurrentWeaponIce()
            //Returns the current equipped weapon Ice
            {
                return Memory.ReadByte(ice);
            }

            public static byte GetCurrentWeaponThunder()
            //Returns the current equipped weapon Thunder
            {
                return Memory.ReadByte(thunder);
            }

            public static byte GetCurrentWeaponWind()
            //Returns the current equipped weapon Wind
            {
                return Memory.ReadByte(wind);
            }

            public static byte GetCurrentWeaponHoly()
            //Returns the current equipped weapon Fire
            {
                return Memory.ReadByte(holy);
            }

            public static byte GetCurrentWeaponDragon()
            //Returns the current equipped weapon Anti Dragon
            {
                return Memory.ReadByte(aDragon);
            }

            public static byte GetCurrentWeaponUndead()
            //Returns the current equipped weapon Anti Undead
            {
                return Memory.ReadByte(aUndead);
            }

            public static byte GetCurrentWeaponMarine()
            //Returns the current equipped weapon Anti Marine
            {
                return Memory.ReadByte(aMarine);
            }

            public static byte GetCurrentWeaponRock()
            //Returns the current equipped weapon Anti Rock
            {
                return Memory.ReadByte(aRock);
            }

            public static byte GetCurrentWeaponPlant()
            //Returns the current equipped weapon Anti Plant
            {
                return Memory.ReadByte(aPlant);
            }

            public static byte GetCurrentWeaponBeast()
            //Returns the current equipped weapon Anti Beast
            {
                return Memory.ReadByte(aBeast);
            }

            public static byte GetCurrentWeaponSky()
            //Returns the current equipped weapon Anti Sky
            {
                return Memory.ReadByte(aSky);
            }

            public static byte GetCurrentWeaponMetal()
            //Returns the current equipped weapon Anti Metal
            {
                return Memory.ReadByte(aMetal);
            }

            public static byte GetCurrentWeaponMimic()
            //Returns the current equipped weapon Anti Mimic
            {
                return Memory.ReadByte(aMimic);
            }

            public static byte GetCurrentWeaponMage()
            //Returns the current equipped weapon Anti Mage
            {
                return Memory.ReadByte(aMage);
            }

            public static byte GetCurrentWeaponSpecial1()
            //Returns the current equipped weapon Special attribute 1
            {
                return Memory.ReadByte(special1);
            }

            public static byte GetCurrentWeaponSpecial2()
            //Returns the current equipped weapon Special attribute 2
            {
                return Memory.ReadByte(special2);
            }
        }

        internal class Toan
        {
            private const int hp = 0x21CD955E;
            private const int maxHP = 0x21CD9552;
            private const int defense = 0x21CDD894;
            private const int thirst = 0x21CDD850;
            private const int thirstMax = 0x21CDD83A;
            private const int pocketSize = 0x21CDD8AC;
            private const int status = 0x21CDD814;           //04 Freeze, 08 Stamina, 16 Poison, 32 Curse, 64 Goo.
            private const int statusTimer = 0x21CDD824;
            private const int currentWeaponSlot = 0x21CDD88C;
            

            public static ushort GetHp()
            {
                return Memory.ReadUShort(hp);
            }

            public static void SetHp(ushort newhp)
            {
                Memory.WriteUShort(hp, newhp);
            }
            public static ushort GetMaxHp()
            {
                return Memory.ReadUShort(maxHP);
            }

            public static void SetMaxHp(int newmaxhp)
            {
                Memory.WriteInt(maxHP, newmaxhp);
            }
            public static int GetDefense()
            {
                return Memory.ReadInt(defense);
            }

            public static void SetDefense(int newdef)
            {
                Memory.WriteInt(defense, newdef);
            }

            public static int GetThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetThirst(int newthirst)
            {
                Memory.WriteInt(thirst, newthirst);
            }
            public static int GetMaxThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetMaxThirst(ushort newmaxthirst)
            {
                Memory.WriteUShort(thirstMax, newmaxthirst);
            }

            public static int GetStatus()
            {
                return Memory.ReadUShort(status);
            }

            public static void SetStatus(string type, ushort timer)
            {
                switch (type.ToLower())
                {
                    case "freeze":
                        Memory.WriteUShort(status, 4);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "stamina":
                        Memory.WriteUShort(status, 8);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "poison":
                        Memory.WriteUShort(status, 16);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "curse":
                        Memory.WriteUShort(status, 32);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "goo":
                        Memory.WriteUShort(status, 64);
                        Memory.WriteUShort(statusTimer, timer);
                        break;
                }
            }

            public static int[] GetWeaponsList()
            {
                int[] swords = { Items.brokendagger, Items.dagger, Items.baselard, Items.gladius, Items.wiseowlsword, Items.crystalknife, Items.antiquesword, Items.bustersword, Items.kitchenknife, Items.tsukikage, Items.sunsword, Items.serpentsword, Items.machosword, Items.shamshir, Items.heavenscloud, Items.lambsswordnormal, Items.darkcloud, Items.braveark, Items.bigbang, Items.atlamilliasword, Items.lamsswordtransformed, Items.mardaneins, Items.mardantwei, Items.arisemardan, Items.agassword, Items.evilcise, Items.smallsword, Items.sandbreaker, Items.drainseeker, Items.chopper, Items.choora, Items.claymore, Items.maneater, Items.bonerapier, Items.sax, Items.sevenbranchsword, Items.dusack, Items.crosshinder, Items.seventhheaven, Items.swordofzeus, Items.chroniclesword, Items.chronicletwo};
                return swords;
            }

            public static byte GetWeaponSlot()
            {
                return Memory.ReadByte(currentWeaponSlot);
            }
            
            //Addresses taken from https://deconstruction.fandom.com/wiki/Dark_Cloud
            internal class WeaponSlot0
            {
                public const int id = 0x21CDDA58;
                public const int level = 0x21CDDA5A;
                public const int attack = 0x21CDDA5C;
                public const int endurance = 0x21CDDA5E;
                public const int speed = 0x21CDDA60;
                public const int magic = 0x21CDDA62;
                public const int whpMax = 0x21CDDA64;
                public const int whp = 0x21CDDA68;
                public const int xp = 0x21CDDA6C;
                public const int elementHUD = 0x21CDDA6E; //00 Fire, 01 Ice, 02 Thunder, 03 Wind, 04 Holy, 05 None.
                public const int fire = 0x21CDDA6F;
                public const int ice = 0x21CDDA70;
                public const int thunder = 0x21CDDA71;
                public const int wind = 0x21CDDA72;
                public const int holy = 0x21CDDA73;
                public const int aDragon = 0x21CDDA74;
                public const int aUndead = 0x21CDDA75;
                public const int aMarine = 0x21CDDA76;
                public const int aRock = 0x21CDDA77;
                public const int aPlant = 0x21CDDA78;
                public const int aBeast = 0x21CDDA79;
                public const int aSky = 0x21CDDA7A;
                public const int aMetal = 0x21CDDA7B;
                public const int aMimic = 0x21CDDA7C;
                public const int aMage = 0x21CDDA7D;
                public const int special1 = 0x21CDDB46; //Special Bitfield 1 	  01 unknown(default on Chronicle 2),
                                                        //02 Big bucks
                                                        //04 Poor
                                                        //08 Quench
                                                        //16 Thirst
                                                        //32 Poison
                                                        //64 Stop
                                                        //128 Steal

                public const int special2 = 0x21CDDB47; //Special Bitfield 2    //02 Durable
                                                        //04 Drain
                                                        //08 Heal
                                                        //16 Critical
                                                        //32 Abs Up
                //Attachment slots values
                public const int slot1_itemId = 0x21CDDA80;                //The current socketed item
                public const int slot1_synthesisedItemId = 0x21CDDA82;     //Only for Synth Spheres; determines name in description and icon.
                public const int slot1_synthesisedItemLevel = 0x21CDDA86;  //Only for Synth Spheres; determines "+X" after name in description.
                public const int slot1_special1 = 0x21CDDA84;
                public const int slot1_special2 = 0x21CDDA85;
                public const int slot1_attack = 0x21CDDA88;
                public const int slot1_endurance = 0x21CDDA8A;
                public const int slot1_speed = 0x21CDDA8C;
                public const int slot1_magic = 0x21CDDA8E;
                public const int slot1_fire = 0x21CDDA90;
                public const int slot1_ice = 0x21CDDA91;
                public const int slot1_thunder = 0x21CDDA92;
                public const int slot1_wind = 0x21CDDA93;
                public const int slot1_holy = 0x21CDDA94;
                public const int slot1_dragon = 0x21CDDA95;
                public const int slot1_undead = 0x21CDDA96;
                public const int slot1_sea = 0x21CDDA97;
                public const int slot1_rock = 0x21CDDA98;
                public const int slot1_plant = 0x21CDDA99;
                public const int slot1_beast = 0x21CDDA9A;
                public const int slot1_sky = 0x21CDDA9B;
                public const int slot1_metal = 0x21CDDA9C;
                public const int slot1_mimic = 0x21CDDA9D;
                public const int slot1_mage = 0x21CDDA9E;
                //public const int slot2_Id = 0x21CDDAA0;

                //Custom attributes
                public const int hasChangedBySynth = 0x21CDDB20;        //Serves as place to store a flag for the Weapons.WeaponListenForSynthSphere function
                public const int weaponFormerStatsValue = 0x21CDDB22;   //Serves as place to keep track of a value used in the Weapons.WeaponListenForSynthSphere function
            }

            internal class WeaponSlot1
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const byte offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }
        }

        internal class Xiao
        {
            public const int hp = 0x21CD9560;
            public const int maxHP = 0x21CD9554;
            public const int defense = 0x21CDD898;
            public const int thirst = 0x21CDD854;
            public const int thirstMax = 0x21CDD83E;
            public const int status = 0x21CDD818;
            public const int statusTimer = 0x21CDD828;
            public const int currentWeaponSlot = 0x21CDD88D;

            public static ushort GetHp()
            {
                return Memory.ReadUShort(hp);
            }

            public static void SetHp(ushort newhp)
            {
                Memory.WriteUShort(hp, newhp);
            }
            public static ushort GetMaxHp()
            {
                return Memory.ReadUShort(maxHP);
            }

            public static void SetMaxHp(ushort newmaxhp)
            {
                Memory.WriteUShort(maxHP, newmaxhp);
            }
            public static int GetDefense()
            {
                return Memory.ReadInt(defense);
            }

            public static void SetDefense(int newdef)
            {
                Memory.WriteInt(defense, newdef);
            }

            public static int GetThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetThirst(int newthirst)
            {
                Memory.WriteInt(thirst, newthirst);
            }
            public static int GetMaxThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetMaxThirst(ushort newmaxthirst)
            {
                Memory.WriteUShort(thirstMax, newmaxthirst);
            }

            public static int GetStatus()
            {
                return Memory.ReadUShort(status);
            }

            public static void SetStatus(string type, ushort timer)
            {
                switch (type.ToLower())
                {
                    case "freeze":
                        Memory.WriteUShort(status, 4);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "stamina":
                        Memory.WriteUShort(status, 8);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "poison":
                        Memory.WriteUShort(status, 16);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "curse":
                        Memory.WriteUShort(status, 32);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "goo":
                        Memory.WriteUShort(status, 64);
                        Memory.WriteUShort(statusTimer, timer);
                        break;
                }
            }

            public static int[] GetWeaponsList()
            {
                int[] slingshots = { Items.brokenwoodenslingshot, Items.woodenslingshot, Items.steelslingshot, Items.banditslingshot, Items.steve, Items.boneslingshot, Items.hardshooter, Items.doubleimpact, Items.dragonsy, Items.divinebeasttitle, Items.angelshooter, Items.flamingo, Items.matador, Items.supersteve, Items.angelgear };
                return slingshots;
            }

            public static int GetWeaponSlot()
            {
                return Memory.ReadUShort(currentWeaponSlot);
            }

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int id = Toan.WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Toan.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = Toan.WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = Toan.WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = Toan.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Toan.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Toan.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Toan.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Toan.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Toan.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Toan.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Toan.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Toan.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Toan.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Toan.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Toan.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Toan.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Toan.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Toan.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Toan.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Toan.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Toan.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Toan.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Toan.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Toan.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Toan.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Toan.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = Toan.WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = Toan.WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = Toan.WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = Toan.WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = Toan.WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = Toan.WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = Toan.WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = Toan.WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = Toan.WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = Toan.WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = Toan.WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = Toan.WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = Toan.WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = Toan.WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = Toan.WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = Toan.WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = Toan.WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = Toan.WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = Toan.WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = Toan.WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = Toan.WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = Toan.WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = Toan.WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = Toan.WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = Toan.WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = Toan.WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }
        }

        internal class Goro
        {
            public const int hp = 0x21CD9562;
            public const int maxHP = 0x21CD9556;
            public const int defense = 0x21CDD89C;
            public const int thirst = 0x21CDD858;
            public const int thirstMax = 0x21CDD842;
            public const int status = 0x21CDD81C;
            public const int statusTimer = 0x21CDD82C;
            public const int currentWeaponSlot = 0x21CDD88E;

            public static ushort GetHp()
            {
                return Memory.ReadUShort(hp);
            }

            public static void SetHp(ushort newhp)
            {
                Memory.WriteUShort(hp, newhp);
            }
            public static ushort GetMaxHp()
            {
                return Memory.ReadUShort(maxHP);
            }

            public static void SetMaxHp(ushort newmaxhp)
            {
                Memory.WriteUShort(maxHP, newmaxhp);
            }
            public static int GetDefense()
            {
                return Memory.ReadInt(defense);
            }

            public static void SetDefense(int newdef)
            {
                Memory.WriteInt(defense, newdef);
            }

            public static int GetThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetThirst(int newthirst)
            {
                Memory.WriteInt(thirst, newthirst);
            }
            public static int GetMaxThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetMaxThirst(ushort newmaxthirst)
            {
                Memory.WriteUShort(thirstMax, newmaxthirst);
            }

            public static int GetStatus()
            {
                return Memory.ReadUShort(status);
            }

            public static void SetStatus(string type, ushort timer)
            {
                switch (type.ToLower())
                {
                    case "freeze":
                        Memory.WriteUShort(status, 4);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "stamina":
                        Memory.WriteUShort(status, 8);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "poison":
                        Memory.WriteUShort(status, 16);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "curse":
                        Memory.WriteUShort(status, 32);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "goo":
                        Memory.WriteUShort(status, 64);
                        Memory.WriteUShort(statusTimer, timer);
                        break;
                }
            }

            public static int[] GetWeaponsList()
            {
                int[] hammers = { Items.brokenmallet, Items.mallet, Items.steelhammer, Items.magicalhammer, Items.battleaxe, Items.turtleshell, Items.bigbuckshammer, Items.frozentuna, Items.gaiahammer, Items.lastjudgement, Items.tallhammer, Items.satansaxe, Items.platehammer, Items.trialhammer, Items.inferno };
                return hammers;
            }

            public static int GetWeaponSlot()
            {
                return Memory.ReadUShort(currentWeaponSlot);
            }

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int id = Xiao.WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Xiao.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = Xiao.WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = Xiao.WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = Xiao.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Xiao.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Xiao.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Xiao.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Xiao.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Xiao.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Xiao.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Xiao.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Xiao.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Xiao.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Xiao.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Xiao.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Xiao.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Xiao.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Xiao.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Xiao.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Xiao.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Xiao.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Xiao.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Xiao.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Xiao.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Xiao.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Xiao.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = Xiao.WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = Xiao.WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = Xiao.WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = Xiao.WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = Xiao.WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = Xiao.WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = Xiao.WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = Xiao.WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = Xiao.WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = Xiao.WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = Xiao.WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = Xiao.WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = Xiao.WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = Xiao.WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = Xiao.WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = Xiao.WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = Xiao.WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = Xiao.WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = Xiao.WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = Xiao.WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = Xiao.WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = Xiao.WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = Xiao.WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = Xiao.WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = Xiao.WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = Xiao.WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }
        }

        internal class Ruby
        {
            public const int hp = 0x21CD9564;
            public const int maxHP = 0x21CD9558;
            public const int defense = 0x21CDD8A0;
            public const int thirst = 0x21CDD85C;
            public const int thirstMax = 0x21CDD846;
            public const int status = 0x21CDD820;
            public const int statusTimer = 0x21CDD830;
            public const int currentWeaponSlot = 0x21CDD88F;

            public static ushort GetHp()
            {
                return Memory.ReadUShort(hp);
            }

            public static void SetHp(ushort newhp)
            {
                Memory.WriteUShort(hp, newhp);
            }
            public static ushort GetMaxHp()
            {
                return Memory.ReadUShort(maxHP);
            }

            public static void SetMaxHp(ushort newmaxhp)
            {
                Memory.WriteUShort(maxHP, newmaxhp);
            }
            public static int GetDefense()
            {
                return Memory.ReadInt(defense);
            }

            public static void SetDefense(int newdef)
            {
                Memory.WriteInt(defense, newdef);
            }

            public static int GetThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetThirst(int newthirst)
            {
                Memory.WriteInt(thirst, newthirst);
            }
            public static int GetMaxThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetMaxThirst(ushort newmaxthirst)
            {
                Memory.WriteUShort(thirstMax, newmaxthirst);
            }

            public static int GetStatus()
            {
                return Memory.ReadUShort(status);
            }

            public static void SetStatus(string type, ushort timer)
            {
                switch (type.ToLower())
                {
                    case "freeze":
                        Memory.WriteUShort(status, 4);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "stamina":
                        Memory.WriteUShort(status, 8);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "poison":
                        Memory.WriteUShort(status, 16);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "curse":
                        Memory.WriteUShort(status, 32);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "goo":
                        Memory.WriteUShort(status, 64);
                        Memory.WriteUShort(statusTimer, timer);
                        break;
                }
            }

            public static int[] GetWeaponsList()
            {
                int[] rings = { Items.brokengoldring, Items.goldring, Items.banditsring, Items.crystalring, Items.platinumring, Items.goddessring, Items.fairysring, Items.destructionring, Items.satansring, Items.athenasarmlet, Items.mobiusring, Items.pocklekul, Items.thornarmlet, Items.secretarmlet};
                return rings;
            }

            public static int GetWeaponSlot()
            {
                return Memory.ReadUShort(currentWeaponSlot);
            }

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int id = Goro.WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Goro.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = Goro.WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = Goro.WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = Goro.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Goro.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Goro.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Goro.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Goro.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Goro.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Goro.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Goro.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Goro.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Goro.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Goro.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Goro.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Goro.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Goro.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Goro.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Goro.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Goro.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Goro.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Goro.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Goro.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Goro.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Goro.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Goro.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = Goro.WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = Goro.WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = Goro.WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = Goro.WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = Goro.WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = Goro.WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = Goro.WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = Goro.WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = Goro.WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = Goro.WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = Goro.WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = Goro.WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = Goro.WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = Goro.WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = Goro.WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = Goro.WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = Goro.WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = Goro.WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = Goro.WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = Goro.WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = Goro.WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = Goro.WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = Goro.WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = Goro.WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = Goro.WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = Goro.WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }
        }

        internal class Ungaga
        {
            public const int hp = 0x21CD9566;
            public const int maxHP = 0x21CD955A;
            public const int defense = 0x21CDD8A4;
            public const int thirst = 0x21CDD860;
            public const int thirstMax = 0x21CDD84A;
            public const int status = 0x21CDD824;
            public const int statusTimer = 0x21CDD834;
            public const int currentWeaponSlot = 0x21CDD890;
            public static ushort GetHp()
            {
                return Memory.ReadUShort(hp);
            }

            public static void SetHp(ushort newhp)
            {
                Memory.WriteUShort(hp, newhp);
            }
            public static ushort GetMaxHp()
            {
                return Memory.ReadUShort(maxHP);
            }

            public static void SetMaxHp(ushort newmaxhp)
            {
                Memory.WriteUShort(maxHP, newmaxhp);
            }
            public static int GetDefense()
            {
                return Memory.ReadInt(defense);
            }

            public static void SetDefense(int newdef)
            {
                Memory.WriteInt(defense, newdef);
            }

            public static int GetThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetThirst(int newthirst)
            {
                Memory.WriteInt(thirst, newthirst);
            }
            public static int GetMaxThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetMaxThirst(ushort newmaxthirst)
            {
                Memory.WriteUShort(thirstMax, newmaxthirst);
            }

            public static int GetStatus()
            {
                return Memory.ReadUShort(status);
            }

            public static void SetStatus(string type, ushort timer)
            {
                switch (type.ToLower())
                {
                    case "freeze":
                        Memory.WriteUShort(status, 4);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "stamina":
                        Memory.WriteUShort(status, 8);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "poison":
                        Memory.WriteUShort(status, 16);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "curse":
                        Memory.WriteUShort(status, 32);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "goo":
                        Memory.WriteUShort(status, 64);
                        Memory.WriteUShort(statusTimer, timer);
                        break;
                }
            }

            public static int[] GetWeaponsList()
            {
                int[] sticks = { Items.brokenfightingstick, Items.fightingstick, Items.javelin, Items.halberd, Items.desanga, Items.scorpion, Items.partisan, Items.mirage, Items.terrasword, Items.herculeswrath, Items.babelsspear, Items.fivefootnail, Items.cactus };
                return sticks;
            }

            public static int GetWeaponSlot()
            {
                return Memory.ReadUShort(currentWeaponSlot);
            }

            internal class WeaponSlot0
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int id = Ruby.WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Ruby.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = Ruby.WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = Ruby.WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = Ruby.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Ruby.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Ruby.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Ruby.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Ruby.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Ruby.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Ruby.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Ruby.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Ruby.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Ruby.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Ruby.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Ruby.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Ruby.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Ruby.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Ruby.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Ruby.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Ruby.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Ruby.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Ruby.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Ruby.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Ruby.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Ruby.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Ruby.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = Ruby.WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = Ruby.WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = Ruby.WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = Ruby.WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = Ruby.WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = Ruby.WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = Ruby.WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = Ruby.WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = Ruby.WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = Ruby.WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = Ruby.WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = Ruby.WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = Ruby.WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = Ruby.WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = Ruby.WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = Ruby.WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = Ruby.WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = Ruby.WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = Ruby.WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = Ruby.WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = Ruby.WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = Ruby.WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = Ruby.WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = Ruby.WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = Ruby.WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = Ruby.WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }
        }

        internal class Osmond
        {
            public const int hp = 0x21CD9568;
            public const int maxHP = 0x21CD955C;
            public const int defense = 0x21CDD8A8;
            public const int thirst = 0x21CDD864;
            public const int thirstMax = 0x21CDD84E;
            public const int status = 0x21CDD828;
            public const int statusTimer = 0x21CDD838;
            public const int currentWeaponSlot = 0x21CDD891;

            public static ushort GetHp()
            {
                return Memory.ReadUShort(hp);
            }

            public static void SetHp(ushort newhp)
            {
                Memory.WriteUShort(hp, newhp);
            }
            public static ushort GetMaxHp()
            {
                return Memory.ReadUShort(maxHP);
            }

            public static void SetMaxHp(ushort newmaxhp)
            {
                Memory.WriteUShort(maxHP, newmaxhp);
            }
            public static int GetDefense()
            {
                return Memory.ReadInt(defense);
            }

            public static void SetDefense(int newdef)
            {
                Memory.WriteInt(defense, newdef);
            }

            public static int GetThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetThirst(int newthirst)
            {
                Memory.WriteInt(thirst, newthirst);
            }
            public static int GetMaxThirst()
            {
                return Memory.ReadInt(thirst);
            }

            public static void SetMaxThirst(ushort newmaxthirst)
            {
                Memory.WriteUShort(thirstMax, newmaxthirst);
            }

            public static int GetStatus()
            {
                return Memory.ReadUShort(status);
            }

            public static void SetStatus(string type, ushort timer)
            {
                switch (type.ToLower())
                {
                    case "freeze":
                        Memory.WriteUShort(status, 4);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "stamina":
                        Memory.WriteUShort(status, 8);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "poison":
                        Memory.WriteUShort(status, 16);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "curse":
                        Memory.WriteUShort(status, 32);
                        Memory.WriteUShort(statusTimer, timer);
                        break;

                    case "goo":
                        Memory.WriteUShort(status, 64);
                        Memory.WriteUShort(statusTimer, timer);
                        break;
                }
            }

            public static int[] GetWeaponsList()
            {
                int[] guns = { Items.brokenmachinegun, Items.machinegun, Items.jackal, Items.blessinggun, Items.skunk, Items.gcrusher, Items.hexablaster, Items.starbreaker, Items.supernova, Items.snail, Items.swallow };
                return guns;
            }

            public static int GetWeaponSlot()
            {
                return Memory.ReadUShort(currentWeaponSlot);
            }

            internal class WeaponSlot0 //Move to Player class instead of Ungaga
            {
                const int offset = 0xAA8;
                const byte weaponSlotMultiplier = 1;

                public const int id = Ungaga.WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = Ungaga.WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = Ungaga.WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = Ungaga.WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = Ungaga.WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = Ungaga.WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = Ungaga.WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = Ungaga.WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = Ungaga.WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = Ungaga.WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = Ungaga.WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = Ungaga.WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = Ungaga.WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = Ungaga.WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = Ungaga.WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = Ungaga.WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = Ungaga.WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = Ungaga.WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = Ungaga.WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = Ungaga.WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = Ungaga.WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = Ungaga.WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = Ungaga.WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = Ungaga.WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = Ungaga.WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = Ungaga.WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = Ungaga.WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = Ungaga.WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = Ungaga.WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = Ungaga.WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = Ungaga.WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = Ungaga.WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = Ungaga.WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = Ungaga.WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = Ungaga.WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = Ungaga.WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = Ungaga.WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = Ungaga.WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = Ungaga.WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = Ungaga.WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = Ungaga.WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = Ungaga.WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = Ungaga.WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = Ungaga.WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = Ungaga.WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = Ungaga.WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = Ungaga.WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = Ungaga.WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = Ungaga.WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = Ungaga.WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = Ungaga.WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = Ungaga.WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = Ungaga.WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot1
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 1;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot2
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 2;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot3
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 3;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot4
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 4;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot5
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 5;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot6
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 6;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot7
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 7;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot8
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 8;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }

            internal class WeaponSlot9
            {
                const int offset = 0xF8;
                const byte weaponSlotMultiplier = 9;

                public const int id = WeaponSlot0.id + (offset * weaponSlotMultiplier);             //WeaponSlot0 + offset * weapon slot
                public const int level = WeaponSlot0.level + (offset * weaponSlotMultiplier);
                public const int special1 = WeaponSlot0.special1 + (offset * weaponSlotMultiplier);
                public const int special2 = WeaponSlot0.special2 + (offset * weaponSlotMultiplier);
                public const int attack = WeaponSlot0.attack + (offset * weaponSlotMultiplier);
                public const int endurance = WeaponSlot0.endurance + (offset * weaponSlotMultiplier);
                public const int speed = WeaponSlot0.speed + (offset * weaponSlotMultiplier);
                public const int magic = WeaponSlot0.magic + (offset * weaponSlotMultiplier);
                public const int whpMax = WeaponSlot0.whpMax + (offset * weaponSlotMultiplier);
                public const int whp = WeaponSlot0.whp + (offset * weaponSlotMultiplier);
                public const int xp = WeaponSlot0.xp + (offset * weaponSlotMultiplier);
                public const int elementHUD = WeaponSlot0.elementHUD + (offset * weaponSlotMultiplier);
                public const int fire = WeaponSlot0.fire + (offset * weaponSlotMultiplier);
                public const int ice = WeaponSlot0.ice + (offset * weaponSlotMultiplier);
                public const int thunder = WeaponSlot0.thunder + (offset * weaponSlotMultiplier);
                public const int wind = WeaponSlot0.wind + (offset * weaponSlotMultiplier);
                public const int holy = WeaponSlot0.holy + (offset * weaponSlotMultiplier);
                public const int aDragon = WeaponSlot0.aDragon + (offset * weaponSlotMultiplier);
                public const int aUndead = WeaponSlot0.aUndead + (offset * weaponSlotMultiplier);
                public const int aMarine = WeaponSlot0.aMarine + (offset * weaponSlotMultiplier);
                public const int aRock = WeaponSlot0.aRock + (offset * weaponSlotMultiplier);
                public const int aPlant = WeaponSlot0.aPlant + (offset * weaponSlotMultiplier);
                public const int aBeast = WeaponSlot0.aBeast + (offset * weaponSlotMultiplier);
                public const int aSky = WeaponSlot0.aSky + (offset * weaponSlotMultiplier);
                public const int aMetal = WeaponSlot0.aMetal + (offset * weaponSlotMultiplier);
                public const int aMimic = WeaponSlot0.aMimic + (offset * weaponSlotMultiplier);
                public const int aMage = WeaponSlot0.aMage + (offset * weaponSlotMultiplier);

                //Attachment slots values
                public const int slot1_itemId = WeaponSlot0.slot1_itemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemId = WeaponSlot0.slot1_synthesisedItemId + (offset * weaponSlotMultiplier);
                public const int slot1_synthesisedItemLevel = WeaponSlot0.slot1_synthesisedItemLevel + (offset * weaponSlotMultiplier);
                public const int slot1_special1 = WeaponSlot0.slot1_special1 + (offset * weaponSlotMultiplier);
                public const int slot1_special2 = WeaponSlot0.slot1_special2 + (offset * weaponSlotMultiplier);
                public const int slot1_attack = WeaponSlot0.slot1_attack + (offset * weaponSlotMultiplier);
                public const int slot1_endurance = WeaponSlot0.slot1_endurance + (offset * weaponSlotMultiplier);
                public const int slot1_speed = WeaponSlot0.slot1_speed + (offset * weaponSlotMultiplier);
                public const int slot1_magic = WeaponSlot0.slot1_magic + (offset * weaponSlotMultiplier);
                public const int slot1_fire = WeaponSlot0.slot1_fire + (offset * weaponSlotMultiplier);
                public const int slot1_ice = WeaponSlot0.slot1_ice + (offset * weaponSlotMultiplier);
                public const int slot1_thunder = WeaponSlot0.slot1_thunder + (offset * weaponSlotMultiplier);
                public const int slot1_wind = WeaponSlot0.slot1_wind + (offset * weaponSlotMultiplier);
                public const int slot1_holy = WeaponSlot0.slot1_holy + (offset * weaponSlotMultiplier);
                public const int slot1_dragon = WeaponSlot0.slot1_dragon + (offset * weaponSlotMultiplier);
                public const int slot1_undead = WeaponSlot0.slot1_undead + (offset * weaponSlotMultiplier);
                public const int slot1_sea = WeaponSlot0.slot1_sea + (offset * weaponSlotMultiplier);
                public const int slot1_rock = WeaponSlot0.slot1_rock + (offset * weaponSlotMultiplier);
                public const int slot1_plant = WeaponSlot0.slot1_plant + (offset * weaponSlotMultiplier);
                public const int slot1_beast = WeaponSlot0.slot1_beast + (offset * weaponSlotMultiplier);
                public const int slot1_sky = WeaponSlot0.slot1_sky + (offset * weaponSlotMultiplier);
                public const int slot1_metal = WeaponSlot0.slot1_metal + (offset * weaponSlotMultiplier);
                public const int slot1_mimic = WeaponSlot0.slot1_mimic + (offset * weaponSlotMultiplier);
                public const int slot1_mage = WeaponSlot0.slot1_mage + (offset * weaponSlotMultiplier);

                //Custom attributes
                public const int hasChangedBySynth = WeaponSlot0.hasChangedBySynth + (offset * weaponSlotMultiplier);
                public const int weaponFormerStatsValue = WeaponSlot0.weaponFormerStatsValue + (offset * weaponSlotMultiplier);
            }
        }
    }
}
