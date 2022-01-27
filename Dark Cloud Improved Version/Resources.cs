using System;
using System.IO;
using System.Reflection;

namespace Dark_Cloud_Improved_Version
{
    internal class Resources
    {
        static string resourcesFolder = "Dark_Cloud_Improved_Version.Resources.";

        static Stream rubyFire = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcesFolder + "RubyMemeFix.Fire");
        static Stream rubyIce = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcesFolder + "RubyMemeFix.Ice");
        static Stream rubyThunder = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcesFolder + "RubyMemeFix.Thunder");
        static Stream rubyWind = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcesFolder + "RubyMemeFix.Wind");
        static Stream rubyHoly = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcesFolder + "RubyMemeFix.Holy");

        public static byte[] rubyFireTex = new byte[rubyFire.Length];
        public static byte[] rubyIceTex = new byte[rubyIce.Length];
        public static byte[] rubyThunderTex = new byte[rubyThunder.Length];
        public static byte[] rubyWindTex = new byte[rubyWind.Length];
        public static byte[] rubyHolyTex = new byte[rubyHoly.Length];

        public static void initiateRubyMemeFix()
        {
            for (int i = 0; i < rubyFire.Length; i++)
                rubyFireTex[i] = (byte)rubyFire.ReadByte();

            for (int i = 0; i < rubyIce.Length; i++)
                rubyIceTex[i] = (byte)rubyIce.ReadByte();

            for (int i = 0; i < rubyThunder.Length; i++)
                rubyThunderTex[i] = (byte)rubyThunder.ReadByte();

            for (int i = 0; i < rubyWind.Length; i++)
                rubyWindTex[i] = (byte)rubyWind.ReadByte();

            for (int i = 0; i < rubyHoly.Length; i++)
                rubyHolyTex[i] = (byte)rubyHoly.ReadByte();
        }
    }
}