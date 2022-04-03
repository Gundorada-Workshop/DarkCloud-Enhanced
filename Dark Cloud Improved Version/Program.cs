using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace Dark_Cloud_Improved_Version
{
    static class Program
    {
        static void PrintInfo()
        {
            Console.WriteLine("\nDark Cloud Enhanced - Created by Wordofwind, Dayuppy, MikeZorD, and Plgue");
            Console.WriteLine("Version 0.8 - Beta\n");
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
                Application.Run(new ModWindow());

            Memory.WriteByte(0x21F10024, 0);
                //Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
            

            PressEntertoContinue();
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
    }
}
