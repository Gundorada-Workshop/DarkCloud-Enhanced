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
            //Dayuppy - Commented out the GUI form for now so that we may use the console to print variables for debugging purposes.
            //Console can be turned back to Windows Application in project properties. After that, uncomment the three lines below to display the GUI.

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Console.WriteLine("processHandle: " + Memory.processH);

            Console.WriteLine("Player's Gilda: " + Memory.ReadUShort(Player.Gilda));
            Console.WriteLine("Toan's HP: " + Memory.ReadUShort(Player.Toan.HP));
            Console.WriteLine("Toan's MaxHP: " + Memory.ReadUShort(Player.Toan.MaxHP));
            
            Player.SetGilda(100); // or Memory.WriteUShort(Player.Gilda, 100);

            Memory.WriteUShort(Player.Toan.HP, 100);
            Memory.WriteUShort(Player.Toan.MaxHP, 150);

            Memory.WriteUShort(Player.Xiao.HP, 62);
            Memory.WriteUShort(Player.Xiao.MaxHP, 78);

            Console.WriteLine("Player has Magic Crystal: " + Memory.ReadInt(Player.MagicCrystal));  //Outputs 1 if player has Magic Crystal in inventory
            //Console.WriteLine("Player PositionX: " + Memory.ReadInt(Player.PositionX)); //ReadFloat is not working currently.
            Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
            PressEntertoContinue();
            }
        }
    }

//Mike's comment
//Wind's comment woohoo
