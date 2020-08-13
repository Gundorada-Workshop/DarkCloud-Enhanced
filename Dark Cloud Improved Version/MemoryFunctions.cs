using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Dark_Cloud_Improved_Version
{
    class Memory
    {
        [DllImport("user32.dll", SetLastError = true)] //Import DLL that will allow us to retrieve processIDs from Window Handles.
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processID); //This is a function within the dll that we are adding to our program.

        [DllImport("kernel32.dll", SetLastError = true)] //Import DLL for reading processes and add the function to our program.
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]  //Import DLL again for Closing Handles to processes and add the function to our program.
        internal static extern int CloseHandle(IntPtr processH);

        [DllImport("kernel32.dll", SetLastError = true)] //Import for reading process memory.
        private static extern int ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)] //Import for writing process memory.
        private static extern int WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);

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
                CloseHandle(processH);
                return 0;
            }
        }

        //Define some Virtual Machine permissions
        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_SUSPEND_RESUME = 0x0800;

        //Make PID available anywhere within the program.
        internal static readonly int PID = GetProcessID("pcsx2");   //Case sensitive

        //Open process with Read and Write permissions
        internal static readonly IntPtr processH = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ | PROCESS_SUSPEND_RESUME, false, PID);

        internal static ushort ReadByte(int address)  //Read byte from address
        {
            byte[] dataBuffer = new byte[1];

            ReadProcessMemory(processH, address, dataBuffer, dataBuffer.Length, out _); //_ seems to act as NULL, we don't need numOfBytesRead

            return dataBuffer[0];
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

        internal static Double ReadDouble(int address)
        {
            byte[] dataBuffer = new byte[8];

            ReadProcessMemory(processH, address, dataBuffer, 8, out _);

            return BitConverter.ToDouble(dataBuffer, 0); ;
        }

        internal static int Write(int address, byte[] value)
        {
            return WriteProcessMemory(processH, address, value, value.Length, out _);
        }

        internal static int WriteString(int address, String value) //Untested
        {
            // http://stackoverflow.com/questions/16072709/converting-string-to-byte-array-in-c-sharp
            var arr = Encoding.ASCII.GetBytes(value);

            return WriteProcessMemory(processH, address, arr, arr.Length, out _);
        }

        internal static int WriteByte(int address, byte value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static int WriteUShort(int address, ushort value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static int WriteInt(int address, int value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static int WriteFloat(int address, float value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }

        internal static int WriteDouble(int address, double value)
        {
            return Write(address, BitConverter.GetBytes(value));
        }
    }
}
