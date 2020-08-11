﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

//Dayuppy added this comment to commit a change.
//Dayuppy made another commit.

namespace Dark_Cloud_Improved_Version
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [DllImport("user32.dll", SetLastError = true)] //Import DLL that will allow us to retrieve processIDs from Window Handles.
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processID); //This is a function within the dll that we are adding to our program.

        [DllImport("kernel32.dll")] //Import DLL for reading processes and add the function to our program.
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]  //Import DLL again for Closing Handles to processes and add the function to our program.
        static extern int CloseHandle(IntPtr processH);

        [DllImport("kernel32.dll")] //Import for reading process memory.
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)] //Import for writing process memory.
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        private static int GetProcessID(string procName) //Function for retrieving processID from running processes.
        {
            Process[] Processes = Process.GetProcessesByName(procName); //Search the list of running processes for procName - ex. (pcsx2)
            if (Processes.Length > 0) //If we found the process, continue.
            {
                int PID = 0; //Initialize processID to 0
                IntPtr hWnd = IntPtr.Zero; //Initialize Window handle to 0x0

                hWnd = Processes[0].MainWindowHandle; //Grab the window handle
                GetWindowThreadProcessId(hWnd, out PID); //Retrieve the ProcessID using the handle to the Window we found and output to PID variable
                Console.WriteLine("WindowHandle:" + hWnd);
                Console.WriteLine("PID: " + PID);
                return PID; //Return our process ID
            }
            
            else //We did not find a process matching procName.
            {
                Console.WriteLine(procName + " was not found in the list of running processes.");
                return 0;
            }
        }

        //Define some Virtual Machine permissions
        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_SUSPEND_RESUME = 0x0800;

        //Make PID available anywhere within the program.
        static readonly int PID = GetProcessID("pcsx2");   //Case sensitive

        //Open process with Read and Write permissions
        static readonly IntPtr processH = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ | PROCESS_SUSPEND_RESUME, false, PID);

        private static void PressEntertoContinue() //Dayuppy - Added a simple function for pausing and waiting for input from the user.
        {
            Console.Write("\n\nPress the Enter key to continue");
            Console.Read(); //Wait for input and then discard it.
        }

        static int ReadInt(int address)
        {
            byte[] dataBuffer = new byte[4];

            ReadProcessMemory(processH, (IntPtr)address, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToInt32(dataBuffer, 0);
        }

        [STAThread]
            static void Main()
            {
            //Dayuppy - Commented out the GUI form for now so that we may use the console to print variables for debugging purposes.
            //Console can be turned back to Windows Application in project properties. After that, uncomment the three lines below to display the GUI.

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            int hasMagicCrystal = ReadInt(0x202A35A0);

            Console.WriteLine("processHandle: " + processH);
            Console.WriteLine("hasMagicCrystal: " + ReadInt(0x202A35A0));  //Outputs 1 if player has Magic Crystal in inventory
            CloseHandle(processH); //Close our handle to the process, we are finished with our program
            PressEntertoContinue();
            }
        }
    }

//Mike's comment
//Wind's comment woohoo
