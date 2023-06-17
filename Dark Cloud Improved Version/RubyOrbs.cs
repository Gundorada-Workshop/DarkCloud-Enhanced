using System.Collections.Generic;

namespace Dark_Cloud_Improved_Version
{
    class RubyOrbs
    {
        const int offset = 4;

        internal class Orb0
        {
            public const int id = 0x21E97A60;
            public const int lifespan = 0x21E97A30;
            public const int damage = 0x21E97A70;
            public const int element = 0x21E97AD0; //Doesn't seem to alter anything
        }

        internal class Orb1
        {
            const byte OrbMultiplier = 1;

            public const int id = Orb0.id + 2;
            public const int lifespan = Orb0.lifespan + (offset * OrbMultiplier);
            public const int damage = Orb0.damage + (offset * OrbMultiplier);
            public const int element = Orb0.element + (offset * OrbMultiplier);
        }

        internal class Orb2
        {
            const byte OrbMultiplier = 2;

            public const int id = Orb0.id + 4;
            public const int lifespan = Orb0.lifespan + (offset * OrbMultiplier);
            public const int damage = Orb0.damage + (offset * OrbMultiplier);
            public const int element = Orb0.element + (offset * OrbMultiplier);
        }

        internal class Orb3
        {
            const byte OrbMultiplier = 3;

            public const int id = Orb0.id + 6;
            public const int lifespan = Orb0.lifespan + (offset * OrbMultiplier);
            public const int damage = Orb0.damage + (offset * OrbMultiplier);
            public const int element = Orb0.element + (offset * OrbMultiplier);
        }

        internal class Orb4
        {
            const byte OrbMultiplier = 4;

            public const int id = Orb0.id + 8;
            public const int lifespan = Orb0.lifespan + (offset * OrbMultiplier);
            public const int damage = Orb0.damage + (offset * OrbMultiplier);
            public const int element = Orb0.element + (offset * OrbMultiplier);
        }

        internal class Orb5
        {
            const byte OrbMultiplier = 5;

            public const int id = Orb0.id + 10;
            public const int lifespan = Orb0.lifespan + (offset * OrbMultiplier);
            public const int damage = Orb0.damage + (offset * OrbMultiplier);
            public const int element = Orb0.element + (offset * OrbMultiplier);
        }

        /// <summary>
        /// Returns a list with the IDs of the Ruby orbs that are currently active
        /// </summary>
        public static List<int> GetRubyActiveOrbs()
        {
            //Create a list to store the IDs
            List<int> OrbIds = new List<int>();

            //Check if the orb ID is active (1) and add it to the list
            if (Memory.ReadUShort(Orb0.id) == 1) OrbIds.Add(0);
            if (Memory.ReadUShort(Orb1.id) == 1) OrbIds.Add(1);
            if (Memory.ReadUShort(Orb2.id) == 1) OrbIds.Add(2);
            if (Memory.ReadUShort(Orb3.id) == 1) OrbIds.Add(3);
            if (Memory.ReadUShort(Orb4.id) == 1) OrbIds.Add(4);
            if (Memory.ReadUShort(Orb5.id) == 1) OrbIds.Add(5);

            return OrbIds;
        }
    }
}
