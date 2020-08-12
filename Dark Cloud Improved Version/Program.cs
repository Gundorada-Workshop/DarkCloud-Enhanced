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
                    //Dayuppy - Commented out the GUI form for now so that we may use the console to print variables for debugging purposes.
                    //Console can be turned back to Windows Application in project properties. After that, uncomment the three lines below to display the GUI.

                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new Form1());

                    Console.WriteLine("processHandle: " + Memory.processH);

                    //Everything below is just testing and examples of how to read/write with the new functions.

                    Console.WriteLine("Player's Gilda: " + Memory.ReadUShort(Player.gilda));
                    Console.WriteLine("Toan's HP: " + Memory.ReadUShort(Player.Toan.hp));

                    Player.SetGilda(100); // or Memory.WriteUShort(Player.Gilda, 100);

                    //Test writing Unsigned Shorts, Bytes, Ints, and Floats. Will take effect immediately when the program is launched, and only once.
                    Memory.WriteUShort(Player.Toan.hp, 100);
                    Memory.WriteByte(Player.Toan.status, 08); //set stamina Buff
                    Memory.WriteInt(Player.Toan.WeaponSlot1.type, 290); //Bone Rapier in Weapon Slot 1 for Toan
                    Memory.WriteFloat(Player.positionX, 1000); //Set player's position out of dungeon to 1000

                    Console.WriteLine("Player has Magic Crystal: " + Memory.ReadInt(Player.magicCrystal));  //Outputs 1 if player has Magic Crystal in dungeon

                    Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
                }

            PressEntertoContinue();
        }
    }
}

//Mike's comment
//Wind's comment woohoo
