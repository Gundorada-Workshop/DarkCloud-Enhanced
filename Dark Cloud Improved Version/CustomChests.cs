using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class CustomChests
    {
        public static void ChestRandomizer()
        {
            Memory.WriteUShort(Addresses.gilda, 1337);
        }
    }
}
