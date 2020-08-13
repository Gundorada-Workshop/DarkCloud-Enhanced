using System;
using System.Windows.Forms;

namespace Dark_Cloud_Improved_Version
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void PressEntertoContinue() //Dayuppy - Added a simple function for pausing and waiting for input from the user.
        {
            Console.Write("\n\nPress the Enter key to continue");
            Console.Read(); //Wait for input and then discard it.
        }

        [STAThread]
        static void Main()
        {
            if (Memory.PID != 0) //If we actually found a running instance of PCSX2, continue
                {
                Console.WriteLine("processHandle: " + Memory.processH);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

                Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
                }

            PressEntertoContinue();
        }
    }
}

//Mike's comment
//Wind's comment woohoo
