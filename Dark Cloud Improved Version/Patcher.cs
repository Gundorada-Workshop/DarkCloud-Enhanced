using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class Patcher
    {
        public static int HexStringToInt(string stringToParse)
        {
            int.TryParse(stringToParse, System.Globalization.NumberStyles.HexNumber, null, out int result);

            return result;
        }

        public static string[] GetPatchPaths()
        {
            string[] emptyPaths = { "empty" };

            if (Directory.Exists(".\\patches"))
                return Directory.GetFiles(".\\patches", "*.patch");

            else
                return emptyPaths;
        }

        public static bool CopyISO(string path, string newPath)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Attempting to copy " + path + " to " + newPath);
                if (File.Exists(newPath))
                {
                    Console.WriteLine("Existing copy found. Removing...");
                    File.Delete(newPath);
                    Thread.Sleep(500);
                    Console.WriteLine("Previous copy removed.");
                }

                File.Copy(path, newPath);
                Console.WriteLine(newPath + " created successfully.");
                return true;
            }
   
            else
            {
                Console.WriteLine("Failed to copy " + path + ". Does the file exist in the same directory?");
                return false;
            }
        }

        public static void PatchISO(byte[] ISO, int offset, byte[] patch)
        {
            for (int i = 0; i < patch.Length; i++)
            {
                ISO[offset] = patch[i];
                offset++;
            }
            
            File.WriteAllBytes("DarkCloud_Enhanced.iso", ISO); //Apply the patches to our ISO
        }

        public static void ApplyPatches()
        {
            bool copySuccess = CopyISO("DarkCloud.iso", "DarkCloud_Enhanced.iso");

            if (copySuccess)
            {
                byte[] ISO = File.ReadAllBytes("DarkCloud_Enhanced.iso"); //Load our new ISO into memory
                byte[] patch;

                string[] patchPaths = GetPatchPaths();
                string filepath, file, filename;

                int patchOffset;

                if (!patchPaths[0].SequenceEqual("empty")) //If our string array is not set to empty
                {
                    Console.WriteLine("Applying ISO patches...");

                    for (int i = 0; i < patchPaths.Length; i++) //Iterate through the array containing the paths to our patches
                    {
                        filepath = patchPaths[i];

                        file = filepath.Remove(0, 10);   //Remove the .\patches\ from the path
                        filename = file.Remove(8, 6);   //Remove the patch file extension from the file

                        patch = File.ReadAllBytes(filepath); //Load our file to patch with
                        patchOffset = HexStringToInt(filename); //Convert the name of our patch into the offset

                        Console.WriteLine("Applying patch " + (i + 1) + " of " + patchPaths.Length + ": " + file);
                        PatchISO(ISO, patchOffset, patch);
                    }
                    Console.WriteLine("Patches applied.");
                }
                else
                    Console.WriteLine("No .patch files were found in the patches folder. Skipping...");
            }
        }
    }
}
