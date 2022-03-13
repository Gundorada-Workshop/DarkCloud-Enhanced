using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dark_Cloud_Improved_Version
{
    static class Program
    {
        static void PrintInfo()
        {
            Console.WriteLine("\nDark Cloud Enhanced - Created by Wordofwind, Dayuppy, MikeZorD, and Plgue");
            Console.WriteLine("Version 1.0 - Alpha\n");
        }

        public static void PressEntertoContinue() //Added a simple function for pausing and waiting for input from the user.
        {
            Console.WriteLine("\n\nPress the Enter key to continue");
            Console.Read(); //Wait for input and then discard it.
        }

        [STAThread]
        static void Main()
        {
            PrintInfo();

            
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

            Memory.WriteByte(0x21F10024, 0);
                //Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
            

            PressEntertoContinue();
        }
    }
}
