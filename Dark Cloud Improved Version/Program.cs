using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
            //Dayuppy - Commented out the GUI form for now so that we may use the console to print variables for debugging purposes.
            //Console can be turned back to Windows Application in project properties. After that, uncomment the three lines below to display the GUI.

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());.

            Dungeon dungeon = new Dungeon(); //Create a new instance of our dungeon class within the main function so we may modify it
            Player player = new Player();

            int hasMagicCrystal = Memory.ReadInt(0x202A35A0);
            player.GetGilda();
            player.SetGilda(10990);
            Console.WriteLine("processHandle: " + Memory.processH);
            Console.WriteLine("hasMagicCrystal: " + Memory.ReadInt(0x202A35A0));  //Outputs 1 if player has Magic Crystal in inventory
            Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
            PressEntertoContinue();
            }
        }
    }

//Mike's comment
//Wind's comment woohoo
