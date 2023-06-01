using Dark_Cloud_Improved_Version.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Dark_Cloud_Improved_Version
{
    class Memory
    {
        internal static Process process;
        internal static string procName = "pcsx2";
        internal static long EEMem_Address, EEMem_Offset;
        internal static long Check_EEMem_Address, Check_EEMem_Offset;

        //Define some needed flags
        internal const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        internal const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        internal const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        internal const uint PROCESS_VM_READ = 0x0010;
        internal const uint PROCESS_VM_WRITE = 0x0020;
        internal const uint PROCESS_VM_OPERATION = 0x0008;
        internal const uint PROCESS_SUSPEND_RESUME = 0x0800;

        internal const uint PAGE_EXECUTE_READWRITE = 0x40;

        [DllImport("\\Resources\\pcsx2_offsetreader.dll", EntryPoint = "?GetEEMem@@YAJH@Z", CallingConvention = CallingConvention.Cdecl)]
        private static extern long GetEEMem(int procID);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern uint GetLastError();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr Arguments);

        [DllImport("user32.dll", SetLastError = true)] //Import DLL that will allow us to retrieve processIDs from Window Handles.
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processID); //This is a function within the dll that we are adding to our program.

        [DllImport("kernel32.dll", SetLastError = true)] //Import DLL for reading processes and add the function to our program.
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.ThisCall)]
        public static extern bool VirtualProtect(IntPtr processH, long lpAddress, long lpBuffer, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx(IntPtr processH, long lpAddress, long lpBuffer, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)] //Import for reading process memory.
        private static extern bool ReadProcessMemory(IntPtr processH, long lpBaseAddress, byte[] lpBuffer, long dwSize, out ulong lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)] //Import for writing process memory.
        private static extern bool WriteProcessMemory(IntPtr processH, long lpBaseAddress, byte[] lpBuffer, long dwSize, out ulong lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]  //Import DLL again for Closing Handles to processes and add the function to our program.
        internal static extern bool CloseHandle(IntPtr processH);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DebugActiveProcess(int PID);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DebugSetProcessKillOnExit(bool boolean);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DebugActiveProcessStop(int PID);

        public static void SuspendProcess()
        {
            DebugActiveProcess(process.Id);
            DebugSetProcessKillOnExit(false);
        }

        public static void ResumeProcess()
        {
            DebugActiveProcessStop(process.Id);
        }

        internal static string GetSystemMessage(uint errorCode)
        {
            IntPtr lpMsgBuf = IntPtr.Zero;

            int dwChars = FormatMessage(
                FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, IntPtr.Zero, (uint)errorCode, 0, ref lpMsgBuf, 0, IntPtr.Zero);

            string sRet = Marshal.PtrToStringAnsi(lpMsgBuf);
            return sRet;
        }

        //private static IntPtr GetEEmemAddress()
        //{
        //    switch(process.ProcessName)
        //    {
        //        case "pcsx2": //Most likely 1.6 or below version of pcsx2
        //            return (IntPtr)0x20000000; //Our addresses already include the previous fixed offset, so, return 0.

        //        case "pcsx2-qtx64":
        //            break;

        //        case "pcsx2x64-avx2":
        //            break;

        //        default:
        //            return IntPtr.Zero;
        //    }

        //    return GetProcAddressEx(process.MainModule.BaseAddress, process.Handle, "EEmem".ToCharArray());
        //}

        public static int Initialize()
        {
            process = GetProcess(procName);

            if (process != null)
            {
                Check_EEMem_Address = ReadLong(GetEEMem(process.Id));
                Check_EEMem_Offset = Check_EEMem_Address - 0x20000000;

                switch (process.ProcessName)
                {
                    case "pcsx2":
                        EEMem_Offset = 0x00000000;
                        break;
                }

                if (Check_EEMem_Address > 0x0)
                {
                    EEMem_Address = Check_EEMem_Address;
                    EEMem_Offset = Check_EEMem_Offset;
                    ModWindow.NightlyVersionCheck();
                }
            }

            return 0;
        }

        public static Process GetProcess(string procName) //Function for retrieving process from running processes.
        {
            Process[] processes = Process.GetProcesses(); //Fetch the array of running processes
            Process foundProcess = null;
            int processInstances = 0;

            procName = procName.ToLowerInvariant().Trim();

            foreach(Process process in processes)
            {
                if(process.ProcessName.ToLowerInvariant().Trim().Contains(procName)) //If we found the process, continue.
                {
                    foundProcess = process;
                    processInstances++;
                }
            }

            if(processInstances > 1)
            {
                Console.WriteLine("Found {0} running instances of {1}. Using the last instance found...", processInstances, foundProcess.ProcessName);
            }

            return foundProcess; //Return our process or default null if not found
        }

        public static IntPtr GetProcessHandle(int PID)
        {
            IntPtr processH = OpenProcess(PROCESS_VM_OPERATION | PROCESS_SUSPEND_RESUME | PROCESS_VM_READ | PROCESS_VM_WRITE, false, PID);
            return processH;
        }

        internal static byte ReadByte(long address)  //Read byte from address + EEMem_Offset
        {
            byte[] dataBuffer = new byte[1];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return dataBuffer[0];
        }

        internal static byte[] ReadByteArray(long address, long numBytes)  //Read byte array from address + EEMem_Offset
        {
            byte[] dataBuffer = new byte[numBytes];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.LongLength, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return dataBuffer;
        }

        internal static ushort ReadUShort(long address)  //Read unsigned short from address + EEMem_Offset
        {
            byte[] dataBuffer = new byte[2];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _);

            return BitConverter.ToUInt16(dataBuffer, 0);
        }

        internal static short ReadShort(long address)
        {
            byte[] dataBuffer = new byte[2]; //Read this many bytes of the address + EEMem_Offset

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToInt16(dataBuffer, 0); //Convert Bit Array to 16-bit Int (short) and return it
        }

        internal static uint ReadUInt(long address)
        {
            byte[] dataBuffer = new byte[4];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToUInt32(dataBuffer, 0);
        }

        internal static int ReadInt(long address)
        {
            byte[] dataBuffer = new byte[4];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToInt32(dataBuffer, 0);
        }

        internal static float ReadFloat(long address)
        {
            byte[] dataBuffer = new byte[4];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _);

            return BitConverter.ToSingle(dataBuffer, 0);
        }

        internal static double ReadDouble(long address)
        {
            byte[] dataBuffer = new byte[8];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _);

            return BitConverter.ToDouble(dataBuffer, 0); ;
        }

        internal static long ReadLong(long address)
        {
            byte[] dataBuffer = new byte[8];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToInt64(dataBuffer, 0);
        }

        internal static string ReadString(long address, long length)
        {
            //http://stackoverflow.com/questions/1003275/how-to-convert-byte-to-string
            byte[] dataBuffer = new byte[length];

            ReadProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, length, out _);

            return Encoding.GetEncoding(10000).GetString(dataBuffer);
        }

        internal static bool Write(long address, byte[] value)
        {
            return WriteProcessMemory(process.Handle, address + EEMem_Offset, value, value.LongLength, out _);
        }

        internal static bool WriteOneByte(long address, byte[] value)
        {
            return WriteProcessMemory(process.Handle, address + EEMem_Offset, value, sizeof(byte), out _);
        }

        internal static bool WriteString(long address, string stringToWrite) //Untested
        {
            // http://stackoverflow.com/questions/16072709/converting-string-to-byte-array-in-c-sharp
            byte[] dataBuffer = Encoding.GetEncoding(10000).GetBytes(stringToWrite); //Western European (Mac) Encoding Table

            return WriteProcessMemory(process.Handle, address + EEMem_Offset, dataBuffer, dataBuffer.LongLength, out _);
        }

        internal static bool WriteByte(long address, byte value)
        {
            //return Write(address + EEMem_Offset + EEMem_Offset, BitConverter.GetBytes(value));
            return WriteOneByte(address, BitConverter.GetBytes(value));
        }

        internal static void WriteByteArray(long address, byte[] byteArray)  //Write byte array at address + EEMem_Offset
        {
            bool successful;

            //successful = VirtualProtectEx(process.Handle, address + EEMem_Offset, byteArray.LongLength, PAGE_EXECUTE_READWRITE, out _);

            //if (successful == false) //There was an error
                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + GetLastError() + " - " + GetSystemMessage(GetLastError())); //Get the last error code and write out the message associated with it.

            successful = WriteProcessMemory(process.Handle, address + EEMem_Offset, byteArray, byteArray.LongLength, out _);

            if (successful == false)
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + GetLastError() + " - " + GetSystemMessage(GetLastError()));
        }

        internal static bool WriteUShort(long address, ushort value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteInt(long address, int value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteUInt(long address, uint value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteFloat(long address, float value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteDouble(long address, double value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static List<long> StringSearch(long startOffset, long stopOffset, string searchString)
        {
            byte[] stringBuffer = new byte[searchString.LongCount()];
            List<long> resultsList = new List<long>();

            VirtualProtectEx(process.Handle, startOffset, stopOffset - startOffset, PAGE_EXECUTE_READWRITE, out _); //Change our protection first

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Searching for " + searchString + ". This may take awhile.");

            for (long currentOffset = startOffset; currentOffset < stopOffset; currentOffset++)
            {
                if (ReadString(currentOffset, stringBuffer.LongLength) == searchString) //If we found a match
                    resultsList.Add(currentOffset); //Add it to the list

                ReadString(currentOffset, stringBuffer.LongLength); //Search for our string at the current offset
            }
            return resultsList;
        }

        internal static List<long> IntSearch(long startOffset, long stopOffset, int searchValue)
        {
            List<long> resultsList = new List<long>();

            VirtualProtectEx(process.Handle, startOffset, stopOffset - startOffset, PAGE_EXECUTE_READWRITE, out _); //Change our protection first

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Searching for " + searchValue + ". This may take awhile.");

            for (long currentOffset = startOffset; currentOffset < stopOffset; currentOffset++)
            {
                if (ReadInt(currentOffset) == searchValue)
                    resultsList.Add(currentOffset);

                //ReadInt(currentOffset);
            }
            return resultsList;
        }

        internal static List<long> ByteArraySearch(long startOffset, long stopOffset, byte[] byteArray)
        {
            List<long> resultsList = new List<long>();

            VirtualProtectEx(process.Handle, startOffset, stopOffset - startOffset, PAGE_EXECUTE_READWRITE, out _);

            for (long currentOffset = startOffset; currentOffset < stopOffset; currentOffset++)
            {
                if (ReadByteArray(currentOffset, byteArray.LongLength).SequenceEqual(byteArray))
                {
                    resultsList.Add(currentOffset);
                }

                Console.WriteLine("{0:X8}", currentOffset);
            }
            return resultsList;
        }
    }
}
