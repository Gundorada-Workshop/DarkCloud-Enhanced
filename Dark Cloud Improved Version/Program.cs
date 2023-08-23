using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;
using Application = System.Windows.Forms.Application;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Dark_Cloud_Improved_Version
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;

        internal static Form modWindowForm;

        internal static readonly IntPtr consoleH = GetConsoleWindow();

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            Console.WriteLine("Dark Cloud Enhanced - Created by Wordofwind, Dayuppy, MikeZorD, and Plgue");
            Console.WriteLine("Version 1.xxx - Release");

            //ShowWindow(consoleH, SW_HIDE); //Hide Console
            
            /*
            while (Memory.process == null)
            {
                GetPCSX2Executable();
            }
            Memory.WriteByte(0x21F10024, 0);
            */
            
            modWindowForm = new ModWindow();
            Application.Run(modWindowForm);
        }

        public static void GetPCSX2Executable()
        {
            Memory.Initialize();

            if (Memory.process == null)
            {
                ShowWindow(consoleH, SW_SHOW); //Show the console
                Console.WriteLine("\n{0} was not found in the list of running processes.", Memory.procName);
                Thread.Sleep(1000);
                return;
            }


            Console.WriteLine("\nFound running instance of {0} ({1})", Memory.process.ProcessName, Memory.process.Id);



            //Memory.EEMem_Offset = Memory.GetEEMem_Offset();

            //if (Memory.EEMem_Offset < 0)
            //{
            //    ShowWindow(consoleH, SW_SHOW); //Show the console

            //    if (Memory.EEMem_Offset == -1)
            //    {
            //        Console.WriteLine("\nUnable to locate pcsx2_offsetreader.exe in the resources directory");
            //    }

            //    Console.WriteLine("\nEEMem_Loc file from the pcsx2_offsetreader.exe helper application was not found.");

            //    Console.WriteLine("\nSetting EEMem location to 0x0. If you are not running pcsx2 version 1.6 or lower, this is a mistake! Please restart the mod and try again.");
            //}

            //Console.WriteLine("\nEEmem Location: {0:X8}", Memory.EEMem_Offset);  
            //Memory.TestProgress();

            Console.WriteLine("\nEEMem_Address: {0:X8}", $"0x{Memory.EEMem_Address:X}");
            Console.WriteLine("\nEEMem_Offset: {0:X8}", $"0x{Memory.EEMem_Offset:X}");
        }

        public static void ConsoleLogging()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            string logFileFolderPath = strWorkPath + @"\EnhancedModLogs";
            if (Directory.Exists(logFileFolderPath) == false)
            {
                System.IO.Directory.CreateDirectory(logFileFolderPath);
            }
            FileStream filestream = new FileStream(logFileFolderPath + @"\EnhancedModLogFile-" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".txt", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);
        }

        public static void PressAnyKey() //Added a simple function for pausing and waiting for input from the user.
        {
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey(); //Wait for input and then discard it.
        }
    }
}
