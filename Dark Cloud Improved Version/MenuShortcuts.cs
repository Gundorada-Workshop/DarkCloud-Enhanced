using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class MenuShortcut
    {
        public void AttributeShortcut()
        {
            if (Memory.ReadByte(Addresses.inputs1) == 10)
            {
                Console.WriteLine("DPad up");
            }
        }

    }
}
