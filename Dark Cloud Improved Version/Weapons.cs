using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Dark_Cloud_Improved_Version
{ 
    public class Weapons
    {
        //Dagger's ID
        public const int daggerid = 258;

        //Base database table Dagger addresses
        public const int synth1 = 0x2027A717; //Synth slot 1 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth2 = 0x2027A718; //Synth slot 2 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth3 = 0x2027A719; //Synth slot 3 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth4 = 0x2027A71A; //Synth slot 4 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth5 = 0x2027A71B; //Synth slot 5 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int synth6 = 0x2027A71C; //Synth slot 6 (0 = None, 1 = Regular gray slot, 2 = Synth blue slot); (ALSO RUNTIME)
        public const int ownership = 0x2027A716; //(0 = Toan, 1 = Xiao, 2 = Goro, 3 = Ruby, 4 = Ungaga, 5 = Osmond);
        public const int whp = 0x2027A70C; //Base weapon health points;
        public const int abs = 0x2027A73C; //Base weapon absorption points; (ALSO RUNTIME)
        public const int absadd = 0x2027A73E; //How much abs to be added per weapon level; (ALSO RUNTIME)
        public const int attack = 0x2027A70E; //Base weapon Attack stat;
        public const int endurance = 0x2027A710; //Base weapon Endurance stat;
        public const int speed = 0x2027A712; //Base weapon Speed stat;
        public const int magic = 0x2027A714; //Base weapon Magic stat;
        public const int fire = 0x2027A71E; //Base weapon Fire stat;
        public const int ice = 0x2027A720; //Base weapon Ice stat;
        public const int thunder = 0x2027A722; //Base weapon Thunder stat;
        public const int wind = 0x2027A724; //Base weapon Wind stat;
        public const int holy = 0x2027A726; //Base weapon Holy stat;
        public const int dinoslayer = 0x2027A728; //Base weapon Dinoslayer stat;
        public const int undead = 0x2027A72A; //Base weapon Undead Buster stat;
        public const int sea = 0x2027A72C; //Base weapon Sea Killer stat;
        public const int stone = 0x2027A72E; //Base weapon Stone Breaker stat;
        public const int plant = 0x2027A730; //Base weapon Plant Buster stat;
        public const int beast = 0x2027A732; //Base weapon Beast Buster stat;
        public const int sky = 0x2027A734; //Base weapon Sky Hunter stat;
        public const int metal = 0x2027A736; //Base weapon Metal Breaker stat;
        public const int mimic = 0x2027A738; //Base weapon Mimic Breaker stat;
        public const int mage = 0x2027A73A; //Base weapon Mage Slayer stat;
        public const int effect = 0x2027A744; //Base weapon special effects;
        public const int buildup = 0x2027A748; //Base weapon build-up branches;

        //Offset between each weapon
        public const int offset = 0x4C;

        public static void WeaponsBalanceChanges()
        {
            /* THIS WAS FOR TESTING
            int value = Memory.ReadInt(0x21CDDA62);
            Console.WriteLine("Player's Weapon Magic was set to: " + value);
            Memory.WriteInt(0x21CDDA62, value + 1);
            */

            /****************************************
             *               TOAN                   *
             ****************************************/

            //Baselard, id = 259
            Memory.WriteUShort(endurance + (offset * (259 - daggerid)), 30); //Endurance set to 30

            //Antique Sword, id = 263
            Memory.WriteUShort(speed + (offset * (263 - daggerid)), 70); //Speed set to 70
            Memory.WriteUShort(fire + (offset * (263 - daggerid)), 15); //Fire set to 15

            //Kitchen Knife, id = 265
            Memory.WriteUShort((whp + (offset * (265 - daggerid))), 50); //Whp set to 50
            Memory.WriteUShort((attack + (offset * (265 - daggerid))), 25); //Attack set to 25
            Memory.WriteUShort((endurance + (offset * (265 - daggerid))), 30); //Endurance set to 30
            Memory.WriteUShort((ice + (offset * (265 - daggerid))), 0); //Ice set to 0
            Memory.WriteUShort((thunder + (offset * (265 - daggerid))), 8); //Thunder set to 0
            Memory.WriteUShort((sea + (offset * (265 - daggerid))), 90); //Sea Killer set to 90

            //Tsukikage, id = 266
            Memory.WriteUShort((endurance + (offset * (266 - daggerid))), 33); //Endurance set to 33
            Memory.WriteUShort((speed + (offset * (266 - daggerid))), 80); //Speed set to 80

            //Macho Sword, id = 269
            //Memory.WriteUShort((effect + (offset * (269 - daggerid))), ??); //NEEDS TO ADD ABS UP

            //Heaven's Cloud, id = 271
            Memory.WriteUShort((synth3 + (offset * (271 - daggerid))), 1); //Adds a 3rd regular attachment slot
            //Memory.WriteUShort((effect + (offset * (271 - daggerid))), ??); //NEEDS TO ADD POISON OR CRITICAL AS A CHANCE

            //Lamb's Sword, id = 272
            Memory.WriteUShort((synth3 + (offset * (272 - daggerid))), 1); //Adds a 3rd regular attachment slot

            //Dark Cloud Ark, id = 273
            //Memory.WriteUShort((effect + (offset * (273 - daggerid))), ??); //NEEDS TO ADD POISON OR STOP AS A CHANCE

            //Brave Ark, id = 274
            Memory.WriteUShort((synth3 + (offset * (274 - daggerid))), 1); //Adds a 3rd regular attachment slot

            //Big Gang, id = 275
            Memory.WriteUShort((speed + (offset * (275 - daggerid))), 70); //Speed set to 70
            //Memory.WriteUShort((effect + (offset * (275 - daggerid))), ??); //NEEDS TO ADD CRITICAL OR STOP AS A CHANCE

            //Atlamillia Sword, id = 276
            //Memory.WriteUShort((effect + (offset * (276 - daggerid))), ??); //NEEDS TO ADD HEAL OR STOP AS A CHANCE

            //Small Sword, id = 283
            Memory.WriteUShort((whp + (offset * (283 - daggerid))), 35); //Whp set to 35
            Memory.WriteUShort((magic + (offset * (283 - daggerid))), 17); //Magic set to 17
            Memory.WriteUShort((sea + (offset * (283 - daggerid))), 0); //Sea Killer set to 0
            Memory.WriteUShort((metal + (offset * (283 - daggerid))), 10); //Metal Breaker set to 10

        }
    }
}
