using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Dark_Cloud_Improved_Version
{ 
    public class Weapons
    {
        public static void Weapon1MagicIncrement()
        {
            int value = Memory.ReadInt(0x21CDDA62);
            Console.WriteLine("Player's Weapon Magic was set to: " + value);
            Memory.WriteInt(0x21CDDA62, value + 1);
        }
    }
}
