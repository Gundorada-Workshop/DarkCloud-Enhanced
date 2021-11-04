using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Dark_Cloud_Improved_Version
{ 
    public class Weapons
    {
        //Default Weapons ID
        public const int daggerid = Items.dagger;
        public const int woodenid = Items.woodenslingshot;
        public const int malletid = Items.mallet;
        public const int goldringid = Items.goldring;
        public const int stickid = Items.fightingstick;
        public const int machinegunid = Items.machinegun;

        //Base database table Dagger addresses
        public const int synth1 = 0x2027A717;       //Synth slot 1 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth2 = 0x2027A718;       //Synth slot 2 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth3 = 0x2027A719;       //Synth slot 3 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth4 = 0x2027A71A;       //Synth slot 4 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth5 = 0x2027A71B;       //Synth slot 5 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth6 = 0x2027A71C;       //Synth slot 6 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int ownership = 0x2027A716;    //(0 = Toan, 1 = Xiao, 2 = Goro, 3 = Ruby, 4 = Ungaga, 5 = Osmond);
        public const int whp = 0x2027A70C;          //Base weapon health points;
        public const int abs = 0x2027A73C;          //Base weapon absorption points; (ALSO RUNTIME)
        public const int absadd = 0x2027A73E;       //How much abs to be added per weapon level; (ALSO RUNTIME)
        public const int attack = 0x2027A70E;       //Base weapon Attack stat;
        public const int maxattack = 0x2027A750;    //Base weapon Max Attack stat; (ALSO RUNTIME)
        public const int endurance = 0x2027A710;    //Base weapon Endurance stat;
        public const int speed = 0x2027A712;        //Base weapon Speed stat;
        public const int magic = 0x2027A714;        //Base weapon Magic stat;
        public const int maxmagic = 0x2027A752;     //Base weapon Max Magic stat; (ALSO RUNTIME)
        public const int fire = 0x2027A71E;         //Base weapon Fire stat;
        public const int ice = 0x2027A720;          //Base weapon Ice stat;
        public const int thunder = 0x2027A722;      //Base weapon Thunder stat;
        public const int wind = 0x2027A724;         //Base weapon Wind stat;
        public const int holy = 0x2027A726;         //Base weapon Holy stat;
        public const int dinoslayer = 0x2027A728;   //Base weapon Dino Slayer stat;
        public const int undead = 0x2027A72A;       //Base weapon Undead Buster stat;
        public const int sea = 0x2027A72C;          //Base weapon Sea Killer stat;
        public const int stone = 0x2027A72E;        //Base weapon Stone Breaker stat;
        public const int plant = 0x2027A730;        //Base weapon Plant Buster stat;
        public const int beast = 0x2027A732;        //Base weapon Beast Buster stat;
        public const int sky = 0x2027A734;          //Base weapon Sky Hunter stat;
        public const int metal = 0x2027A736;        //Base weapon Metal Breaker stat;
        public const int mimic = 0x2027A738;        //Base weapon Mimic Breaker stat;
        public const int mage = 0x2027A73A;         //Base weapon Mage Slayer stat;
        public const int effect = 0x2027A744;       //Base weapon special effects (Set 1); (ALSO RUNTIME)
        public const int effect2 = 0x2027A745;      //Base weapon special effects (Set 2); (ALSO RUNTIME)
        public const int buildup = 0x2027A748;      //Base weapon build-up branches;

        //Offset between each weapon
        public const int weaponoffset = 0x4C;

        //Character offsets
        public const int xiaooffset = 0xC78;    //Xiao
        public const int gorooffset = 0x10EC;   //Goro
        public const int rubyoffset = 0x15F8;   //Ruby
        public const int ungagaoffset = 0x1AB8; //Ungaga
        public const int osmondoffset = 0x1F78; //Osmond

        //Lamb sword buff
        public const int lambTransformThreshold = 0x202A1818;
        public const int lambStatsThreshold = 0x202A188C;

        public static Thread weaponsMenuListener = new Thread(new ThreadStart(WeaponListenForSynthSphere));

        public static void WeaponListenForSynthSphere()
        {
            int attack;
            int endurance;
            int speed;
            int magic;
            int weaponLevel;
            int diffLevel;
            int diffLevelBeforeChange;
            int hasChangedBySynth;

            while (true)
            {
                int menuMode = Memory.ReadByte(Addresses.weaponsMode);

                //Check if player is in the weapon customize menu
                if(menuMode >= 8 && menuMode <= 11)
                {
                    int character = Memory.ReadByte(Addresses.weaponMenuCurrentCharacterHover);
                    int weapon = Memory.ReadByte(Addresses.weaponMenuCurrentWeaponHover);

                    switch (character)
                    {
                        case 0:
                            switch (weapon)
                            {
                                case 0:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot0.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot0.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot0.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot0.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot0.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot0.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot0.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot0.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot0.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot0.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot0.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot0.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot0.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot0.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot0.hasChangedBySynth, 1);
                                        }

                                    }else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot0.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot0.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot0.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot0.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot0.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot0.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot0.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 1:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot1.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot1.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot1.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot1.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot1.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot1.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot1.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot1.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot1.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot1.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot1.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot1.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot1.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot1.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot1.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot1.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot1.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot1.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot1.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot1.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot1.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot1.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot1.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 2:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot2.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot2.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot2.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot2.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot2.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot2.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot2.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot2.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot2.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot2.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot2.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot2.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot2.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot2.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot2.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot2.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot2.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 3:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot3.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot3.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot3.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot3.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot3.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot3.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot3.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot3.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot3.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot3.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot3.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot3.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot3.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot3.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot3.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot3.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot3.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot3.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot3.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot3.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot3.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot3.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot3.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 4:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot4.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot4.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot4.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot4.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot4.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot4.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot4.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot4.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot4.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot4.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot4.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot4.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot4.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot4.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot4.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot4.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot4.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot4.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot4.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot4.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot4.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot4.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot4.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 5:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot5.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot5.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot5.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot5.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot5.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot5.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot5.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot5.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot5.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot5.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot5.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot5.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot5.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot5.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot5.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot5.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot5.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot5.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot5.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot5.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot5.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot5.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot5.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 6:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot6.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot6.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot6.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot6.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot6.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot6.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot6.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot6.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot6.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot6.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot6.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot6.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot6.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot6.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot6.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot6.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot6.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot6.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot6.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot6.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot6.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot6.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot6.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 7:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot7.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot7.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot7.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot7.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot7.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot7.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot7.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot7.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot7.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot7.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot7.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot7.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot7.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot7.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot7.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot7.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot7.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot7.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot7.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot7.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot7.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot7.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot7.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 8:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot8.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot8.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot8.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot8.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot8.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot8.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot8.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot8.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot8.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot8.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot8.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot8.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot8.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot8.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot8.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot8.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot8.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot8.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot8.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot8.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot8.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot8.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot8.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 9:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Toan.WeaponSlot9.attack);
                                    endurance = Memory.ReadUShort(Player.Toan.WeaponSlot9.endurance);
                                    speed = Memory.ReadUShort(Player.Toan.WeaponSlot9.speed);
                                    magic = Memory.ReadUShort(Player.Toan.WeaponSlot9.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Toan.WeaponSlot9.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Toan.WeaponSlot9.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Toan.WeaponSlot9.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Toan.WeaponSlot9.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Toan.WeaponSlot9.level, 5);
                                            Memory.WriteUShort(Player.Toan.WeaponSlot9.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot9.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot9.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Toan.WeaponSlot9.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Toan.WeaponSlot9.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Toan.WeaponSlot9.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Toan.WeaponSlot9.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Toan.WeaponSlot9.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot9.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot9.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot9.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Toan.WeaponSlot9.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Toan.WeaponSlot9.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Toan.WeaponSlot9.hasChangedBySynth, 0);
                                    }
                                    break;
                            }
                            break;

                        case 1:
                            switch (weapon)
                            {
                                case 0:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot0.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot0.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot0.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot0.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot0.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot0.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot0.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot0.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot0.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot0.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot0.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot0.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot0.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot0.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot0.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot0.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot0.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot0.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot0.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot0.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot0.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot0.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot0.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 1:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot1.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot1.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot1.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot1.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot1.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot1.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot1.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot1.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot1.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot1.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot1.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot1.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot1.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot1.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot1.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot1.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot1.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot1.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot1.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot1.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot1.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot1.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot1.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 2:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot2.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot2.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot2.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot2.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot2.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot2.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot2.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot2.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot2.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot2.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot2.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot2.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot2.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot2.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot2.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot2.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot2.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot2.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot2.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot2.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot2.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot2.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot2.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 3:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot3.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot3.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot3.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot3.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot3.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot3.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot3.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot3.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot3.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot3.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot3.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot3.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot3.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot3.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot3.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot3.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot3.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot3.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot3.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot3.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot3.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot3.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot3.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 4:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot4.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot4.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot4.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot4.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot4.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot4.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot4.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot4.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot4.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot4.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot4.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot4.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot4.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot4.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot4.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot4.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot4.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot4.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot4.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot4.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot4.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot4.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot4.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 5:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot5.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot5.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot5.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot5.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot5.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot5.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot5.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot5.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot5.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot5.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot5.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot5.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot5.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot5.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot5.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot5.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot5.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot5.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot5.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot5.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot5.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot5.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot5.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 6:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot6.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot6.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot6.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot6.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot6.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot6.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot6.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot6.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot6.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot6.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot6.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot6.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot6.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot6.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot6.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot6.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot6.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot6.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot6.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot6.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot6.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot6.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot6.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 7:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot7.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot7.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot7.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot7.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot7.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot7.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot7.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot7.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot7.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot7.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot7.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot7.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot7.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot7.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot7.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot7.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot7.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot7.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot7.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot7.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot7.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot7.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot7.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 8:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot8.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot8.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot8.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot8.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot8.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot8.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot8.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot8.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot8.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot8.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot8.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot8.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot8.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot8.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot8.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot8.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot8.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot8.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot8.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot8.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot8.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot8.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot8.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 9:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Xiao.WeaponSlot9.attack);
                                    endurance = Memory.ReadUShort(Player.Xiao.WeaponSlot9.endurance);
                                    speed = Memory.ReadUShort(Player.Xiao.WeaponSlot9.speed);
                                    magic = Memory.ReadUShort(Player.Xiao.WeaponSlot9.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Xiao.WeaponSlot9.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Xiao.WeaponSlot9.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Xiao.WeaponSlot9.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Xiao.WeaponSlot9.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Xiao.WeaponSlot9.level, 5);
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot9.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot9.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot9.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot9.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot9.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Xiao.WeaponSlot9.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Xiao.WeaponSlot9.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot9.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot9.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot9.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot9.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot9.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot9.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Xiao.WeaponSlot9.hasChangedBySynth, 0);
                                    }
                                    break;
                            }
                            break;

                        case 2:
                            switch (weapon)
                            {
                                case 0:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot0.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot0.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot0.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot0.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot0.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot0.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot0.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot0.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot0.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot0.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot0.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot0.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot0.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot0.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot0.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot0.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot0.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot0.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot0.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot0.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot0.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot0.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot0.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 1:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot1.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot1.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot1.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot1.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot1.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot1.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot1.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot1.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot1.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot1.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot1.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot1.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot1.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot1.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot1.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot1.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot1.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot1.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot1.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot1.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot1.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot1.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot1.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 2:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot2.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot2.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot2.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot2.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot2.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot2.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot2.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot2.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot2.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot2.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot2.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot2.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot2.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot2.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot2.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot2.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot2.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot2.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot2.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot2.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot2.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot2.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot2.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 3:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot3.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot3.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot3.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot3.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot3.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot3.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot3.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot3.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot3.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot3.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot3.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot3.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot3.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot3.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot3.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot3.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot3.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot3.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot3.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot3.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot3.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot3.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot3.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 4:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot4.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot4.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot4.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot4.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot4.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot4.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot4.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot4.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot4.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot4.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot4.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot4.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot4.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot4.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot4.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot4.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot4.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot4.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot4.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot4.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot4.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot4.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot4.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 5:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot5.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot5.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot5.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot5.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot5.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot5.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot5.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot5.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot5.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot5.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot5.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot5.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot5.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot5.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot5.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot5.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot5.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot5.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot5.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot5.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot5.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot5.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot5.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 6:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot6.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot6.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot6.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot6.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot6.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot6.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot6.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot6.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot6.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot6.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot6.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot6.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot6.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot6.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot6.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot6.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot6.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot6.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot6.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot6.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot6.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot6.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot6.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 7:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot7.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot7.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot7.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot7.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot7.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot7.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot7.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot7.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot7.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot7.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot7.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot7.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot7.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot7.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot7.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot7.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot7.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot7.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot7.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot7.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot7.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot7.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot7.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 8:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot8.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot8.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot8.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot8.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot8.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot8.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot8.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot8.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot8.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot8.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot8.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot8.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot8.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot8.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot8.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot8.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot8.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot8.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot8.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot8.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot8.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot8.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot8.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 9:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Goro.WeaponSlot9.attack);
                                    endurance = Memory.ReadUShort(Player.Goro.WeaponSlot9.endurance);
                                    speed = Memory.ReadUShort(Player.Goro.WeaponSlot9.speed);
                                    magic = Memory.ReadUShort(Player.Goro.WeaponSlot9.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Goro.WeaponSlot9.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Goro.WeaponSlot9.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Goro.WeaponSlot9.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Goro.WeaponSlot9.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Goro.WeaponSlot9.level, 5);
                                            Memory.WriteUShort(Player.Goro.WeaponSlot9.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot9.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot9.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Goro.WeaponSlot9.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Goro.WeaponSlot9.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Goro.WeaponSlot9.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Goro.WeaponSlot9.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Goro.WeaponSlot9.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot9.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot9.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot9.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Goro.WeaponSlot9.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Goro.WeaponSlot9.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Goro.WeaponSlot9.hasChangedBySynth, 0);
                                    }
                                    break;
                            }
                            break;

                        case 3:
                            switch (weapon)
                            {
                                case 0:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot0.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot0.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot0.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot0.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot0.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot0.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot0.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot0.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot0.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot0.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot0.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot0.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot0.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot0.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot0.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot0.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot0.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot0.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot0.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot0.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot0.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot0.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot0.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 1:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot1.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot1.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot1.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot1.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot1.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot1.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot1.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot1.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot1.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot1.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot1.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot1.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot1.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot1.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot1.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot1.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot1.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot1.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot1.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot1.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot1.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot1.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot1.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 2:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot2.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot2.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot2.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot2.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot2.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot2.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot2.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot2.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot2.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot2.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot2.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot2.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot2.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot2.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot2.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot2.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot2.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot2.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot2.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot2.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot2.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot2.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot2.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 3:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot3.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot3.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot3.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot3.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot3.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot3.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot3.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot3.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot3.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot3.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot3.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot3.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot3.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot3.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot3.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot3.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot3.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot3.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot3.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot3.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot3.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot3.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot3.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 4:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot4.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot4.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot4.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot4.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot4.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot4.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot4.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot4.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot4.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot4.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot4.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot4.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot4.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot4.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot4.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot4.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot4.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot4.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot4.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot4.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot4.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot4.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot4.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 5:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot5.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot5.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot5.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot5.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot5.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot5.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot5.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot5.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot5.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot5.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot5.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot5.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot5.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot5.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot5.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot5.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot5.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot5.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot5.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot5.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot5.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot5.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot5.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 6:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot6.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot6.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot6.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot6.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot6.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot6.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot6.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot6.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot6.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot6.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot6.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot6.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot6.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot6.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot6.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot6.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot6.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot6.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot6.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot6.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot6.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot6.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot6.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 7:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot7.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot7.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot7.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot7.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot7.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot7.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot7.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot7.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot7.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot7.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot7.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot7.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot7.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot7.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot7.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot7.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot7.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot7.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot7.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot7.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot7.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot7.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot7.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 8:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot8.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot8.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot8.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot8.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot8.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot8.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot8.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot8.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot8.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot8.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot8.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot8.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot8.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot8.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot8.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot8.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot8.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot8.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot8.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot8.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot8.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot8.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot8.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 9:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ruby.WeaponSlot9.attack);
                                    endurance = Memory.ReadUShort(Player.Ruby.WeaponSlot9.endurance);
                                    speed = Memory.ReadUShort(Player.Ruby.WeaponSlot9.speed);
                                    magic = Memory.ReadUShort(Player.Ruby.WeaponSlot9.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ruby.WeaponSlot9.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ruby.WeaponSlot9.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ruby.WeaponSlot9.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ruby.WeaponSlot9.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ruby.WeaponSlot9.level, 5);
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot9.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot9.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot9.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot9.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot9.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ruby.WeaponSlot9.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ruby.WeaponSlot9.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot9.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot9.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot9.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot9.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot9.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot9.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ruby.WeaponSlot9.hasChangedBySynth, 0);
                                    }
                                    break;
                            }
                            break;

                        case 4:
                            switch (weapon)
                            {
                                case 0:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot0.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot0.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot0.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot0.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot0.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot0.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot0.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot0.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot0.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot0.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot0.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot0.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot0.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot0.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot0.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot0.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot0.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot0.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot0.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot0.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot0.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot0.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot0.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 1:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot1.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot1.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot1.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot1.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot1.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot1.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot1.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot1.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot1.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot1.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot1.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot1.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot1.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot1.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot1.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot1.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot1.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot1.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot1.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot1.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot1.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot1.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot1.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 2:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot2.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot2.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot2.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot2.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot2.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot2.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot2.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot2.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot2.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot2.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot2.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot2.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot2.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot2.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot2.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot2.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot2.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot2.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot2.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot2.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot2.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot2.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot2.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 3:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot3.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot3.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot3.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot3.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot3.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot3.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot3.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot3.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot3.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot3.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot3.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot3.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot3.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot3.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot3.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot3.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot3.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot3.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot3.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot3.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot3.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot3.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot3.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 4:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot4.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot4.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot4.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot4.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot4.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot4.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot4.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot4.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot4.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot4.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot4.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot4.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot4.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot4.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot4.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot4.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot4.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot4.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot4.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot4.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot4.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot4.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot4.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 5:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot5.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot5.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot5.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot5.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot5.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot5.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot5.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot5.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot5.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot5.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot5.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot5.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot5.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot5.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot5.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot5.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot5.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot5.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot5.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot5.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot5.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot5.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot5.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 6:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot6.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot6.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot6.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot6.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot6.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot6.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot6.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot6.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot6.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot6.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot6.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot6.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot6.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot6.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot6.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot6.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot6.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot6.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot6.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot6.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot6.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot6.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot6.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 7:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot7.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot7.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot7.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot7.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot7.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot7.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot7.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot7.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot7.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot7.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot7.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot7.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot7.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot7.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot7.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot7.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot7.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot7.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot7.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot7.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot7.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot7.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot7.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 8:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot8.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot8.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot8.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot8.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot8.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot8.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot8.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot8.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot8.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot8.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot8.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot8.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot8.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot8.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot8.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot8.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot8.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot8.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot8.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot8.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot8.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot8.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot8.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 9:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Ungaga.WeaponSlot9.attack);
                                    endurance = Memory.ReadUShort(Player.Ungaga.WeaponSlot9.endurance);
                                    speed = Memory.ReadUShort(Player.Ungaga.WeaponSlot9.speed);
                                    magic = Memory.ReadUShort(Player.Ungaga.WeaponSlot9.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Ungaga.WeaponSlot9.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Ungaga.WeaponSlot9.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Ungaga.WeaponSlot9.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Ungaga.WeaponSlot9.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Ungaga.WeaponSlot9.level, 5);
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot9.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot9.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot9.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot9.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot9.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Ungaga.WeaponSlot9.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Ungaga.WeaponSlot9.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot9.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot9.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot9.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot9.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot9.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot9.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Ungaga.WeaponSlot9.hasChangedBySynth, 0);
                                    }
                                    break;
                            }
                            break;

                        case 5:
                            switch (weapon)
                            {
                                case 0:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot0.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot0.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot0.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot0.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot0.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot0.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot0.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot0.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot0.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot0.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot0.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot0.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot0.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot0.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot0.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot0.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot0.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot0.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot0.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot0.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot0.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot0.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot0.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 1:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot1.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot1.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot1.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot1.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot1.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot1.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot1.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot1.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot1.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot1.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot1.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot1.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot1.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot1.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot1.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot1.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot1.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot1.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot1.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot1.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot1.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot1.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot1.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 2:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot2.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot2.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot2.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot2.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot2.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot2.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot2.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot2.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot2.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot2.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot2.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot2.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot2.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot2.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot2.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot2.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot2.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot2.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot2.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot2.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot2.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot2.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot2.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 3:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot3.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot3.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot3.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot3.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot3.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot3.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot3.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot3.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot3.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot3.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot3.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot3.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot3.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot3.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot3.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot3.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot3.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot3.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot3.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot3.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot3.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot3.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot3.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 4:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot4.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot4.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot4.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot4.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot4.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot4.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot4.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot4.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot4.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot4.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot4.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot4.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot4.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot4.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot4.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot4.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot4.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot4.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot4.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot4.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot4.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot4.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot4.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 5:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot5.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot5.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot5.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot5.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot5.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot5.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot5.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot5.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot5.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot5.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot5.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot5.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot5.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot5.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot5.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot5.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot5.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot5.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot5.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot5.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot5.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot5.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot5.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 6:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot6.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot6.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot6.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot6.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot6.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot6.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot6.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot6.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot6.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot6.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot6.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot6.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot6.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot6.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot6.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot6.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot6.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot6.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot6.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot6.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot6.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot6.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot6.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 7:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot7.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot7.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot7.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot7.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot7.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot7.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot7.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot7.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot7.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot7.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot7.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot7.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot7.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot7.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot7.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot7.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot7.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot7.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot7.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot7.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot7.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot7.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot7.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 8:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot8.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot8.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot8.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot8.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot8.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot8.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot8.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot8.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot8.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot8.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot8.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot8.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot8.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot8.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot8.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot8.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot8.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot8.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot8.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot8.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot8.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot8.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot8.hasChangedBySynth, 0);
                                    }
                                    break;

                                case 9:

                                    //Store the current weapon base stats
                                    attack = Memory.ReadUShort(Player.Osmond.WeaponSlot9.attack);
                                    endurance = Memory.ReadUShort(Player.Osmond.WeaponSlot9.endurance);
                                    speed = Memory.ReadUShort(Player.Osmond.WeaponSlot9.speed);
                                    magic = Memory.ReadUShort(Player.Osmond.WeaponSlot9.magic);
                                    hasChangedBySynth = Memory.ReadUShort(Player.Osmond.WeaponSlot9.hasChangedBySynth);

                                    //Store the current weapon level and calculate the difference to +5
                                    weaponLevel = Memory.ReadByte(Player.Osmond.WeaponSlot9.level);
                                    diffLevel = 5 - weaponLevel;

                                    //Has the empty synthshpere in socket?
                                    if (Memory.ReadUShort(Player.Osmond.WeaponSlot9.slot1_itemId) == Items.synthsphere &&
                                        Memory.ReadUShort(Player.Osmond.WeaponSlot9.slot1_synthesisedItemId) == 0)
                                    {
                                        //Weapon level is below +5 and has not yet been changed by an empty synthphere?
                                        if (diffLevel > 0 && hasChangedBySynth == 0)
                                        {
                                            //Set the weapon to +5 with the increase in main stats
                                            Memory.WriteByte(Player.Osmond.WeaponSlot9.level, 5);
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot9.attack, (ushort)(attack + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot9.endurance, (ushort)(endurance + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot9.speed, (ushort)(speed + diffLevel));
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot9.magic, (ushort)(magic + diffLevel));

                                            //Save former stat value
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot9.weaponFormerStatsValue, (ushort)diffLevel);

                                            //Set changed flag
                                            Memory.WriteUShort(Player.Osmond.WeaponSlot9.hasChangedBySynth, 1);
                                        }

                                    }
                                    else if (diffLevel == 0 && hasChangedBySynth == 1)
                                    {
                                        //Fetch the previous level before the change
                                        diffLevelBeforeChange = Memory.ReadUShort(Player.Osmond.WeaponSlot9.weaponFormerStatsValue);

                                        //Revert the weapons changes back to normal
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot9.level, (ushort)(5 - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot9.attack, (ushort)(attack - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot9.endurance, (ushort)(endurance - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot9.speed, (ushort)(speed - diffLevelBeforeChange));
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot9.magic, (ushort)(magic - diffLevelBeforeChange));

                                        //Reset flags
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot9.weaponFormerStatsValue, 0);
                                        Memory.WriteUShort(Player.Osmond.WeaponSlot9.hasChangedBySynth, 0);
                                    }
                                    break;
                            }
                            break;
                    }
                }

                Thread.Sleep(60);
            }
        }

        public static void WeaponsBalanceChanges()
        {
            Console.WriteLine("MikeZorD weapon changes have been applied...");


            /****************************************
             *               TOAN                   *
             ****************************************/

            //Baselard, id = 259
            Memory.WriteUShort(endurance + (weaponoffset * (259 - daggerid)), 30); //Endurance set to 30

            //Antique Sword, id = 263
            Memory.WriteUShort(speed + (weaponoffset * (263 - daggerid)), 70);  //Speed set to 70
            Memory.WriteUShort(fire + (weaponoffset * (263 - daggerid)), 15);   //Fire set to 15

            //Kitchen Knife, id = 265
            Memory.WriteUShort((whp + (weaponoffset * (265 - daggerid))), 50);          //Whp set to 50
            Memory.WriteUShort((attack + (weaponoffset * (265 - daggerid))), 25);       //Attack set to 25
            Memory.WriteUShort((endurance + (weaponoffset * (265 - daggerid))), 30);    //Endurance set to 30
            Memory.WriteUShort((ice + (weaponoffset * (265 - daggerid))), 0);           //Ice set to 0
            Memory.WriteUShort((thunder + (weaponoffset * (265 - daggerid))), 8);       //Thunder set to 0
            Memory.WriteUShort((sea + (weaponoffset * (265 - daggerid))), 90);          //Sea Killer set to 90
            Memory.WriteUShort((buildup + 5 + (weaponoffset * (265 - daggerid))), 0);   //Set build-up branches to none (The 5 was just to offset to the correct address since I wasn't finding a way to write 8 bytes)

            //Tsukikage, id = 266
            Memory.WriteUShort((endurance + (weaponoffset * (266 - daggerid))), 33);    //Endurance set to 33
            Memory.WriteUShort((speed + (weaponoffset * (266 - daggerid))), 80);        //Speed set to 80

            //Macho Sword, id = 269
            Memory.WriteUShort((effect2 + (weaponoffset * (269 - daggerid))), 32);  //Adds ABS up effect

            //Heaven's Cloud, id = 271
            Memory.WriteUShort((synth3 + (weaponoffset * (271 - daggerid))), 1);    //Adds a 3rd regular attachment slot

            //Lamb's Sword, id = 272
            Memory.WriteUShort((synth3 + (weaponoffset * (272 - daggerid))), 1);    //Adds a 3rd regular attachment slot
            Memory.WriteDouble(lambTransformThreshold, 0.5);                        //Change the percent limit for when the sword should transform
            Memory.WriteFloat(lambStatsThreshold, (float) 0.5);                     //Change the percent limit for when the sword stats should upgrade

            //Brave Ark, id = 274
            Memory.WriteUShort((synth3 + (weaponoffset * (274 - daggerid))), 1);    //Adds a 3rd regular attachment slot

            //Big Gang, id = 275
            Memory.WriteUShort((speed + (weaponoffset * (275 - daggerid))), 70);    //Speed set to 70

            //Small Sword, id = 283
            Memory.WriteUShort((whp + (weaponoffset * (283 - daggerid))), 35);      //Whp set to 35
            Memory.WriteUShort((magic + (weaponoffset * (283 - daggerid))), 17);    //Magic set to 17
            Memory.WriteUShort((sea + (weaponoffset * (283 - daggerid))), 0);       //Sea Killer set to 0
            Memory.WriteUShort((metal + (weaponoffset * (283 - daggerid))), 10);    //Metal Breaker set to 10

            //Sand Breaker, id = 284
            Memory.WriteUShort((whp + (weaponoffset * (284 - daggerid))), 45);          //Whp set to 45
            Memory.WriteUShort((endurance + (weaponoffset * (284 - daggerid))), 25);    //Endurance set to 25
            Memory.WriteUShort((synth3 + (weaponoffset * (284 - daggerid))), 1);        //Adds a 3rd regular attachment slot

            //Drain Seeker, id = 285
            Memory.WriteUShort((whp + (weaponoffset * (285 - daggerid))), 60); //Whp set to 60

            //Chopper, id = 286
            Memory.WriteUShort((speed + (weaponoffset * (286 - daggerid))), 60); //Speed set to 60

            //Choora, id = 287
            Memory.WriteUShort((whp + (weaponoffset * (287 - daggerid))), 57);      //Whp set to 57
            Memory.WriteUShort((attack + (weaponoffset * (287 - daggerid))), 45);   //Attack set to 45
            Memory.WriteUShort((speed + (weaponoffset * (287 - daggerid))), 70);    //Speed set to 70
            Memory.WriteUShort((ice + (weaponoffset * (287 - daggerid))), 10);      //Ice set to 10
            Memory.WriteUShort((thunder + (weaponoffset * (287 - daggerid))), 15);  //Thunder set to 15
            Memory.WriteUShort((undead + (weaponoffset * (287 - daggerid))), 15);   //Undead Buster set to 15
            Memory.WriteUShort((beast + (weaponoffset * (287 - daggerid))), 15);    //Beaster Buster set to 15
            Memory.WriteUShort((metal + (weaponoffset * (287 - daggerid))), 15);    //Metal Breaker set to 15
            Memory.WriteUShort((synth3 + (weaponoffset * (287 - daggerid))), 1);    //Adds a 3rd regular attachment slot

            //Claymore, id = 288
            Memory.WriteUShort((undead + (weaponoffset * (288 - daggerid))), 10);   //Undead Buster set to 10
            Memory.WriteUShort((beast + (weaponoffset * (288 - daggerid))), 10);    //Beaster Buster set to 10
            Memory.WriteUShort((mage + (weaponoffset * (288 - daggerid))), 10);     //Mage Slayer set to 10

            //Maneater, id = 289
            Memory.WriteUShort((endurance + (weaponoffset * (289 - daggerid))), 44);    //Endurance set to 44
            Memory.WriteUShort((speed + (weaponoffset * (289 - daggerid))), 70);        //Speed set to 70
            Memory.WriteUShort((magic + (weaponoffset * (289 - daggerid))), 45);        //Magic set to 45
            Memory.WriteUShort((ice + (weaponoffset * (289 - daggerid))), 15);          //Ice set to 15
            Memory.WriteUShort((thunder + (weaponoffset * (289 - daggerid))), 15);      //Thunder set to 15
            Memory.WriteUShort((holy + (weaponoffset * (289 - daggerid))), 15);         //Holy set to 15
            Memory.WriteUShort((undead + (weaponoffset * (289 - daggerid))), 15);       //Undead Buster set to 15
            Memory.WriteUShort((beast + (weaponoffset * (289 - daggerid))), 15);        //Beast Buster set to 15
            Memory.WriteUShort((metal + (weaponoffset * (289 - daggerid))), 15);        //Metal Breaker set to 15
            Memory.WriteUShort((mimic + (weaponoffset * (289 - daggerid))), 10);        //Mimic Breaker set to 10

            //Bone Rapier, id = 290
            Memory.WriteUShort((whp + (weaponoffset * (290 - daggerid))), 38);      //Whp set to 38
            Memory.WriteUShort((magic + (weaponoffset * (290 - daggerid))), 26);    //Magic set to 26

            //Sax, id = 291
            Memory.WriteUShort((speed + (weaponoffset * (291 - daggerid))), 60);    //Speed set to 60
            Memory.WriteUShort((fire + (weaponoffset * (291 - daggerid))), 6);      //Fire set to 6
            Memory.WriteUShort((sky + (weaponoffset * (291 - daggerid))), 10);      //Sky Hunter set to 10

            //7 Branch Sword, id = 292
            Memory.WriteUShort((whp + (weaponoffset * (292 - daggerid))), 47);          //Whp set to 47
            Memory.WriteUShort((endurance + (weaponoffset * (292 - daggerid))), 47);    //Endurance set to 47
            Memory.WriteUShort((magic + (weaponoffset * (292 - daggerid))), 37);        //Magic set to 37
            Memory.WriteUShort((dinoslayer + (weaponoffset * (292 - daggerid))), 7);    //Dino Slayer set to 7
            Memory.WriteUShort((undead + (weaponoffset * (292 - daggerid))), 7);        //Undead Buster set to 7
            Memory.WriteUShort((sea + (weaponoffset * (292 - daggerid))), 7);           //Sea Killer set to 7
            Memory.WriteUShort((stone + (weaponoffset * (292 - daggerid))), 7);         //Stone Breaker set to 7
            Memory.WriteUShort((plant + (weaponoffset * (292 - daggerid))), 7);         //Plant Buster set to 7
            Memory.WriteUShort((beast + (weaponoffset * (292 - daggerid))), 8);         //Beast Buster set to 8
            Memory.WriteUShort((sky + (weaponoffset * (292 - daggerid))), 7);           //Sea Killer set to 7
            Memory.WriteUShort((metal + (weaponoffset * (292 - daggerid))), 10);        //Metal Breaker set to 10
            Memory.WriteUShort((mimic + (weaponoffset * (292 - daggerid))), 7);         //Mimic Breaker set to 7
            Memory.WriteUShort((mage + (weaponoffset * (292 - daggerid))), 8);          //Mage Slayer set to 8

            //Cross Hinder, id = 294
            Memory.WriteUShort((endurance + (weaponoffset * (294 - daggerid))), 50);    //Endurance set to 50
            Memory.WriteUShort((speed + (weaponoffset * (294 - daggerid))), 70);        //Speed set to 70
            Memory.WriteUShort((magic + (weaponoffset * (294 - daggerid))), 32);        //Magic set to 32

            //Chronicle 2, id = 298
            Memory.WriteUShort((maxattack + (weaponoffset * (298 - daggerid))), 999); //Max Attack set to 999




            /****************************************
             *               XIAO                   *
             ****************************************/

            //Wooden Slingshot, id = 300
            Memory.WriteUShort((attack + (xiaooffset + (weaponoffset * (300 - woodenid)))), 6); //Attack set to 6
            Memory.WriteUShort((magic + (xiaooffset + (weaponoffset * (300 - woodenid)))), 2);  //Magic set to 2
            Memory.WriteUShort((fire + (xiaooffset + (weaponoffset * (300 - woodenid)))), 4);   //Fire set to 4

            //Bone Slingshot, id = 302
            Memory.WriteUInt((buildup + (xiaooffset + (weaponoffset * (302 - woodenid)))), 128); //Sets build-up to Double Impact only

            //Bone Slingshot, id = 304
            Memory.WriteUShort((attack + (xiaooffset + (weaponoffset * (304 - woodenid)))), 11);    //Attack set to 11
            Memory.WriteUShort((endurance + (xiaooffset + (weaponoffset * (304 - woodenid)))), 30); //Endurance set to 30

            //Hardshooter, id = 305
            Memory.WriteUShort((speed + (xiaooffset + (weaponoffset * (305 - woodenid)))), 60); //Speed set to 60

            //Matador, id = 311
            Memory.WriteUShort((effect2 + (xiaooffset + (weaponoffset * (311 - woodenid)))), 16); //Adds Critical effect




            /****************************************
             *               Goro                   *
             ****************************************/

            //Turtle Shell, id = 319
            Memory.WriteUShort((magic + (gorooffset + (weaponoffset * (319 - malletid)))), 10); //Magic set to 10

            //Big Bucks Hammer, id = 320
            Memory.WriteUInt((buildup + (gorooffset + (weaponoffset * (320 - malletid)))), 8); //Sets build-up branch to Magical Hammer only

            //Frozen Tuna, id = 321
            Memory.WriteUShort((whp + (gorooffset + (weaponoffset * (321 - malletid)))), 65); //Whp set to 65

            //Gaia Hammer, id = 322
            Memory.WriteUShort((endurance + (gorooffset + (weaponoffset * (322 - malletid)))), 25); //Endurance set to 25

            //Trial Hammer, id = 328
            Memory.WriteUShort((attack + (gorooffset + (weaponoffset * (328 - malletid)))), 30);    //Attack set to 30
            Memory.WriteUShort((endurance + (gorooffset + (weaponoffset * (328 - malletid)))), 25); //Endurance set to 25




            /****************************************
             *               Ruby                   *
             ****************************************/

            //Gold Ring, id = 332
            Memory.WriteUShort((attack + (rubyoffset + (weaponoffset * (332 - goldringid)))), 15);  //Attack set to 15
            Memory.WriteUShort((magic + (rubyoffset + (weaponoffset * (332 - goldringid)))), 30);   //Magic set to 30

            //Bandit's Ring, id = 333
            Memory.WriteUShort((attack + (rubyoffset + (weaponoffset * (333 - goldringid)))), 30);      //Attack set to 30
            Memory.WriteUShort((maxattack + (rubyoffset + (weaponoffset * (333 - goldringid)))), 50);   //Max Attack set to 50
            Memory.WriteUShort((magic + (rubyoffset + (weaponoffset * (333 - goldringid)))), 20);       //Magic set to 20
            Memory.WriteInt((buildup + (rubyoffset + (weaponoffset * (333 - goldringid)))), 8200);      //Sets build-up branches to both Crystal Ring and Thorn Armlet

            //Platinum Ring, id = 335
            Memory.WriteUShort((attack + (rubyoffset + (weaponoffset * (335 - goldringid)))), 23); //Attack set to 23

            //Pocklekul, id = 343
            Memory.WriteUShort((attack + (rubyoffset + (weaponoffset * (343 - goldringid)))), 28);      //Attack set to 28
            Memory.WriteUShort((magic + (rubyoffset + (weaponoffset * (343 - goldringid)))), 28);       //Magic set to 28
            Memory.WriteUShort((holy + (rubyoffset + (weaponoffset * (343 - goldringid)))), 0);         //Holy set to 0
            Memory.WriteUShort((buildup + (rubyoffset + (weaponoffset * (343 - goldringid)))), 8256);   //Sets build-up branches to both Fairy Ring and Thorn Armlet

            //Thorn Armlet, id = 344
            Memory.WriteUShort((maxmagic + (rubyoffset + (weaponoffset * (344 - goldringid)))), 65); //Max Magic set to 65
            Memory.WriteUShort((buildup + (rubyoffset + (weaponoffset * (344 - goldringid)))), 128); //Sets build-up branches to Destruction Ring




            /****************************************
             *               Ungaga                 *
             ****************************************/

            for (int ungagaweaponid = 348; ungagaweaponid <= 360; ungagaweaponid++)
            {
                if(ungagaweaponid != 357)
                {
                    int CurrWeaponAttack = Memory.ReadUShort((attack + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))));          //Reads the current weapon Attack value
                    int CurrWeaponMaxAttack = Memory.ReadUShort((maxattack + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))));    //Reads the current weapon Max Attack value
                    int CurrWeaponMagic = Memory.ReadUShort((magic + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))));            //Reads the current weapon Magic value
                    int CurrWeaponMaxMagic = Memory.ReadUShort((maxmagic + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))));      //Reads the current weapon Max Magic value

                    Memory.WriteUShort((attack + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))), (ushort)(CurrWeaponAttack + 10));       //Adds +10 Attack to the current weapon being looped through
                    Memory.WriteUShort((maxattack + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))), (ushort)(CurrWeaponMaxAttack + 10)); //Adds +10 Max Attack to the current weapon being looped through
                    Memory.WriteUShort((magic + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))), (ushort)(CurrWeaponMagic + 15));         //Adds +15 Magic to the current weapon being looped through
                    Memory.WriteUShort((maxmagic + (ungagaoffset + (weaponoffset * (ungagaweaponid - stickid)))), (ushort)(CurrWeaponMaxMagic + 15));   //Adds +15 Max Magic to the current weapon being looped through

                }
            }

            //Babel Spear, id = 357
            Memory.WriteUShort((synth4 + (ungagaoffset + (weaponoffset * (357 - stickid)))), 1); //Adds a 4th regular attackment slot




            /****************************************
             *               Osmond                 *
             ****************************************/

            for (int osmondweaponid = 364; osmondweaponid <= 375; osmondweaponid++)
            {
                int CurrWeaponAttack = Memory.ReadUShort((attack + (osmondoffset + (weaponoffset * (osmondweaponid - machinegunid)))));         //Reads the current weapon Attack value
                int CurrWeaponMaxAttack = Memory.ReadUShort((maxattack + (osmondoffset + (weaponoffset * (osmondweaponid - machinegunid)))));   //Reads the current weapon Max Attack value

                Memory.WriteUShort((attack + (osmondoffset + (weaponoffset * (osmondweaponid - machinegunid)))), (ushort)(CurrWeaponAttack + 15));      //Adds +15 Attack to the current weapon being looped through
                Memory.WriteUShort((maxattack + (osmondoffset + (weaponoffset * (osmondweaponid - machinegunid)))), (ushort)(CurrWeaponMaxAttack + 15)); //Adds +15 Max Attack to the current weapon being looped through
            }
        }
    }
}
