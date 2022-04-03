using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Dark_Cloud_Improved_Version
{
    class Memory
    {
        //Define some needed flags
        public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        public const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        public const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        public const uint PROCESS_VM_READ = 0x0010;
        public const uint PROCESS_VM_WRITE = 0x0020;
        public const uint PROCESS_VM_OPERATION = 0x0008;
        public const uint PROCESS_SUSPEND_RESUME = 0x0800;

        public const uint PAGE_EXECUTE_READWRITE = 0x40;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetLastError();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr Arguments);
        
        [DllImport("user32.dll", SetLastError = true)] //Import DLL that will allow us to retrieve processIDs from Window Handles.
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processID); //This is a function within the dll that we are adding to our program.

        [DllImport("kernel32.dll", SetLastError = true)] //Import DLL for reading processes and add the function to our program.
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.ThisCall)]
        public static extern bool VirtualProtect(IntPtr processH, int lpAddress, int lpBuffer, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx(IntPtr processH, int lpAddress, int lpBuffer, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)] //Import for reading process memory.
        private static extern bool ReadProcessMemory(IntPtr processH, int lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)] //Import for writing process memory.
        private static extern bool WriteProcessMemory(IntPtr processH, int lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]  //Import DLL again for Closing Handles to processes and add the function to our program.
        internal static extern bool CloseHandle(IntPtr processH);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DebugActiveProcess(int PID);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DebugSetProcessKillOnExit(bool boolean);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DebugActiveProcessStop(int PID);

        public static void SuspendProcess(int processId)
        {
            DebugActiveProcess(processId);
            DebugSetProcessKillOnExit(false);
        }

        public static void ResumeProcess(int processId)
        {
            DebugActiveProcessStop(PID);
        }

        internal static string GetSystemMessage(uint errorCode)
        {
            IntPtr lpMsgBuf = IntPtr.Zero;

            int dwChars = FormatMessage(
                FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, IntPtr.Zero, (uint)errorCode, 0, ref lpMsgBuf, 0, IntPtr.Zero);

            string sRet = Marshal.PtrToStringAnsi(lpMsgBuf);

            return sRet;
        }

        public static int GetProcessID(string procName) //Function for retrieving processID from running processes.
        {
            Process[] Processes = Process.GetProcessesByName(procName); //Search the list of running processes for procName - ex. (pcsx2)
            if (Processes.Length > 0) //If we found the process, continue.
            {
                int PID = 0; //Initialize processID to 0
                IntPtr hWnd = IntPtr.Zero; //Initialize Window handle to 0x0

                hWnd = Processes[0].MainWindowHandle; //Grab the window handle
                GetWindowThreadProcessId(hWnd, out PID); //Retrieve the ProcessID using the handle to the Window we found and output to PID variable
                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "WindowHandle:" + hWnd);
                //Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "PID: " + PID);
                return PID; //Return our process ID
            }
            
            else //We did not find a process matching procName.
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + procName + " was not found in the list of running processes.");
                //CloseHandle(processH);
                return 0;
            }
        }

        //Make PID available anywhere within the program.
        internal static readonly int PID = GetProcessID("pcsx2");   //Case sensitive

        //Open process with Read and Write permissions
        internal static IntPtr processH = OpenProcess(PROCESS_VM_OPERATION | PROCESS_SUSPEND_RESUME | PROCESS_VM_READ | PROCESS_VM_WRITE, false, PID);

        public static void GetProcess(int PID)
        {
            processH = OpenProcess(PROCESS_VM_OPERATION | PROCESS_SUSPEND_RESUME | PROCESS_VM_READ | PROCESS_VM_WRITE, false, PID);
        }

        internal static byte ReadByte(int address)  //Read byte from address
        {
            byte[] dataBuffer = new byte[1];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return dataBuffer[0];
        }

        internal static byte[] ReadByteArray(int address, int numBytes)  //Read byte from address
        {
            byte[] dataBuffer = new byte[numBytes];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return dataBuffer;
        }

        internal static ushort ReadUShort(int address)  //Read unsigned short from address
        {
            byte[] dataBuffer = new byte[2];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _);

            return BitConverter.ToUInt16(dataBuffer, 0);
        }

        internal static short ReadShort(int address)
        {
            byte[] dataBuffer = new byte[2]; //Read this many bytes of the address

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToInt16(dataBuffer, 0); //Convert Bit Array to 16-bit Int (short) and return it
        }

        internal static uint ReadUInt(int address)
        {
            byte[] dataBuffer = new byte[4];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToUInt32(dataBuffer, 0);
        }

        internal static int ReadInt(int address)
        {
            byte[] dataBuffer = new byte[4];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return BitConverter.ToInt32(dataBuffer, 0);
        }

        internal static float ReadFloat(int address)
        {
            byte[] dataBuffer = new byte[8];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _);

            return BitConverter.ToSingle(dataBuffer, 0);
        }

        internal static double ReadDouble(int address)
        {
            byte[] dataBuffer = new byte[8];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _);

            return BitConverter.ToDouble(dataBuffer, 0); ;
        }

        internal static string ReadString(int address, int length)
        {
            //http://stackoverflow.com/questions/1003275/how-to-convert-byte-to-string
            byte[] dataBuffer = new byte[length];

            ReadProcessMemory(processH, address, dataBuffer, length, out _);
     
            return Encoding.GetEncoding(10000).GetString(dataBuffer);
        }

        internal static bool Write(int address, byte[] value)
        {
            return WriteProcessMemory(processH, address, value, value.Length, out _);
        }

        internal static bool WriteOneByte(int address, byte[] value)
        {
            return WriteProcessMemory(processH, address, value, 1, out _);
        }

        internal static bool WriteString(int address, string stringToWrite) //Untested
        {
            // http://stackoverflow.com/questions/16072709/converting-string-to-byte-array-in-c-sharp
            byte[] dataBuffer = Encoding.GetEncoding(10000).GetBytes(stringToWrite); //Western European (Mac) Encoding Table

            return WriteProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _);
        }

        internal static bool WriteByte(int address, byte value)
        {
            //return Write(address, BitConverter.GetBytes(value));
            return WriteOneByte(address, BitConverter.GetBytes(value));
        }

        internal static void WriteByteArray(int address, byte[] byteArray)  //Write byte array at address
        {
            bool successful;

            successful = VirtualProtectEx(processH, address, byteArray.Length, PAGE_EXECUTE_READWRITE, out _);
             
            if (successful == false) //There was an error
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + GetLastError() + " - " + GetSystemMessage(GetLastError())); //Get the last error code and write out the message associated with it.

            successful = WriteProcessMemory(processH, address, byteArray, byteArray.Length, out _);

            if (successful == false)
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + GetLastError() + " - " + GetSystemMessage(GetLastError()));
        }

        internal static bool WriteUShort(int address, ushort value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteInt(int address, int value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteUInt(int address, uint value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteFloat(int address, float value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static bool WriteDouble(int address, double value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static List<int> StringSearch(int startOffset, int stopOffset, string searchString)
        {
            byte[] stringBuffer = new byte[searchString.Length];
            List<int> resultsList = new List<int>();

            VirtualProtectEx(processH, startOffset, stopOffset - startOffset, PAGE_EXECUTE_READWRITE, out _); //Change our protection first

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Searching for " + searchString + ". This may take awhile.");

            for (int currentOffset = startOffset; currentOffset < stopOffset; currentOffset++)
            {
                if (ReadString(currentOffset, stringBuffer.Length) == searchString) //If we found a match
                    resultsList.Add(currentOffset); //Add it to the list

                ReadString(currentOffset, stringBuffer.Length); //Search for our string at the current offset
            }
            return resultsList;
        }

        internal static List<int> IntSearch(int startOffset, int stopOffset, int searchValue)
        {
            List<int> resultsList = new List<int>();

            VirtualProtectEx(processH, startOffset, stopOffset - startOffset, PAGE_EXECUTE_READWRITE, out _); //Change our protection first

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Searching for " + searchValue + ". This may take awhile.");

            for (int currentOffset = startOffset; currentOffset < stopOffset; currentOffset++)
            {
                if (ReadInt(currentOffset) == searchValue)
                    resultsList.Add(currentOffset);

                ReadInt(currentOffset);
            }
            return resultsList;
        }

        internal static List<int> ByteArraySearch(int startOffset, int stopOffset, byte[] byteArray)
        {
            List<int> resultsList = new List<int>();

            VirtualProtectEx(processH, startOffset, stopOffset - startOffset, PAGE_EXECUTE_READWRITE, out _);

            for (int currentOffset = startOffset; currentOffset < stopOffset; currentOffset++)
            {
                if (ReadByteArray(currentOffset, byteArray.Length).SequenceEqual(byteArray))
                    resultsList.Add(currentOffset);

                ReadInt(currentOffset);
            }
            return resultsList;
        }
    }
}
