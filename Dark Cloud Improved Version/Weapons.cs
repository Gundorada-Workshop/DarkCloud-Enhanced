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
        public const int daggerid = 258;
        public const int woodenid = 300;
        public const int malletid = 315;
        public const int goldringid = 332;
        public const int stickid = 348;
        public const int machinegunid = 364;

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
