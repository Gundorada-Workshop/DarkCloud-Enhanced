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


            //Everything below is just testing and examples of how to read/write with the new functions.
            Console.WriteLine("processHandle: " + Memory.processH);

            Console.WriteLine("Player's Gilda: " + Memory.ReadUShort(Player.gilda));
            Console.WriteLine("Toan's HP: " + Memory.ReadUShort(Player.Toan.hp));
            Console.WriteLine("Toan's MaxHP: " + Memory.ReadUShort(Player.Toan.maxHP));
            
            //Player.SetGilda(100); // or Memory.WriteUShort(Player.Gilda, 100);

            Memory.WriteUShort(Player.Toan.hp, 100);

            Memory.WriteUShort(Player.gilda, 65000);
            Console.WriteLine("Player's Gilda: " + Memory.ReadUShort(Player.gilda));

            Memory.WriteUShort(Player.Toan.maxHP, 150);

            Memory.WriteUShort(Player.Xiao.hp, 62);
            Memory.WriteUShort(Player.Xiao.maxHP, 78);

            Memory.WriteByte(Player.Toan.status, 08); //set stamina Buff
            Memory.WriteInt(Player.Toan.WeaponSlot1.type, 290); //Bone Rapier in Weapon Slot 1 for Toan

            Console.WriteLine("Player has Magic Crystal: " + Memory.ReadInt(Player.magicCrystal));  //Outputs 1 if player has Magic Crystal in inventory
            Console.WriteLine("Player Position X: " + Memory.ReadFloat(Player.positionX) + "\tPlayer Position Y: " + Memory.ReadFloat(Player.positionY) + "\tPlayer Position Z: " + Memory.ReadFloat(Player.positionZ));
            Console.WriteLine("Dungeon Player Position X: " + Memory.ReadFloat(Player.dunPositionX) + "\tDungeon Player Position Y: " + Memory.ReadFloat(Player.dunPositionY) + "\tDungeon Player Position Z: " + Memory.ReadFloat(Player.dunPositionZ));

            Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
            PressEntertoContinue();
            }
        }
    }

//Mike's comment
//Wind's comment woohoo
