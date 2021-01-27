using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class TASThread
    {
        public static int[] buttonInputs = new int[500000];
        public static int[] buttonInputs2 = new int[500000];
        public static int[] buttonInputs3 = new int[500000];
        public static int[] buttonInputs4 = new int[500000];
        public static int[] buttonInputs5 = new int[500000];
        public static int frameCounter;
        public static int frameCounterChecker;
        //Square = 128        Cross = 64      Circle = 32       Triangle = 16
        //DPadLeft = 32768        DPadDown = 16384      DPadRight = 8192       DPadUP = 4096
        //Select = 256     L3 = 512      R3 = 1024      Start = 2048
        //L1 = 4        L2 = 1      R1 = 8      R2 = 2
        public static void RunTAS()
        {
            buttonInputs[108300] = 16;
            buttonInputs[108301] = 16;
            buttonInputs[108360] = 64;
            buttonInputs[108361] = 64;
            buttonInputs[108600] = 16;
            buttonInputs[108601] = 16;
            buttonInputs[108630] = 32768;
            buttonInputs[108631] = 32768;
            buttonInputs[108660] = 16;
            buttonInputs[108661] = 16;
            buttonInputs[108690] = 32768;
            buttonInputs[108691] = 32768;
            buttonInputs[108720] = 16;
            buttonInputs[108721] = 16;
            buttonInputs[108750] = 32768;
            buttonInputs[108751] = 32768;
            buttonInputs[108780] = 16;
            buttonInputs[108781] = 16;
            buttonInputs[108850] = 32;
            buttonInputs[108851] = 32;
            buttonInputs[108950] = 16384;
            buttonInputs[108951] = 16384;
            buttonInputs[109100] = 64;
            buttonInputs[109101] = 64;
            buttonInputs[109130] = 16384;
            buttonInputs[109131] = 16384;
            buttonInputs[109160] = 16384;
            buttonInputs[109161] = 16384;
            buttonInputs[109190] = 16384;
            buttonInputs[109191] = 16384;
            buttonInputs[109220] = 16384;
            buttonInputs[109221] = 16384;
            buttonInputs[109250] = 64;
            buttonInputs[109251] = 64;
            //buttonInputs[108500] = 64;
            //buttonInputs[108501] = 0;
            //buttonInputs[109000] = 64;
            //buttonInputs[109001] = 0;
            Memory.WriteUShort(0x300F7C6D, 37008);
            Memory.WriteUShort(0x300F7DE5, 37008);
            Memory.WriteUShort(0x300F7D87, 37008);
            Memory.WriteUShort(0x300F7D29, 37008);
            Memory.WriteUShort(0x300F7CCB, 37008);
            while (1 == 1)
            {
                frameCounter = Memory.ReadInt(0x202A2400);
                if (frameCounterChecker != frameCounter)
                {
                    if (buttonInputs[frameCounter] != 0)
                    {
                        Memory.WriteInt(0x21CBC544, buttonInputs[frameCounter]);
                    }
                    else
                    {
                        Memory.WriteInt(0x21CBC544, 0);
                    }
                    frameCounterChecker = frameCounter;
                }
               
            }
        }

        public static void RecordTAS()
        {
            while (frameCounter != 108500)
            {
                frameCounter = Memory.ReadInt(0x202A2400);

                if (frameCounterChecker != frameCounter)
                {
                    buttonInputs[frameCounter] = Memory.ReadInt(0x21CBC544);
                    buttonInputs2[frameCounter] = Memory.ReadInt(0x21CBC548);
                    buttonInputs3[frameCounter] = Memory.ReadInt(0x21CBC54C);
                    buttonInputs4[frameCounter] = Memory.ReadInt(0x21CBC550);
                    buttonInputs5[frameCounter] = Memory.ReadInt(0x21CBC554);

                    frameCounterChecker = frameCounter;
                }
            }
        }
    }
}
