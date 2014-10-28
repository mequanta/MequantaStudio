using System;
using SmartQuant;
using System.Collections;
using MonoDevelop.Core;
using System.IO;
using System.Runtime.InteropServices;

namespace MequantaStudio.SmartQuant
{
    public static class SmartQuantService
    {
        static SmartQuantService()
        {
            string location = PropertyService.Get("MequantaStudio.SmartQuant.SmartQuantRuntimeLocation", "");
            if (!string.IsNullOrEmpty(location) && Platform.IsWindows)
            {
                if (InitSmartQuantLibs(location))
                    LoggingService.LogInfo("Found SmartQuant Runtime at {0}", location);
            }

        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetDllDirectory(string lpPathName);

        static bool InitSmartQuantLibs(string path)
        { 
            try
            {
                return SetDllDirectory(path);
            }
            catch (EntryPointNotFoundException)
            {
            }
            return false;
        }

        public static void PrintInfo()
        {
        }
    }
}

