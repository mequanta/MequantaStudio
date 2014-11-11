using System;
using SmartQuant;
using System.Collections;
using MonoDevelop.Core;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;

namespace MequantaStudio.SmartQuant
{
    public static class SmartQuantService
    {
        private static SolutionRunner runner;
        public static Dictionary<string, byte> EventLookups { get; private set; }

        public static Framework Framework
        {
            get
            {
                return Framework.Current;
            }
        }

        public static SolutionRunner SolutionRunner
        {
            get
            {
                if (runner == null)
                    runner = new SolutionRunner(Framework);
                return runner;
            }
        }

        public static DataLoader DataLoader { get; private set; }

        static SmartQuantService()
        {
            string location = PropertyService.Get("MequantaStudio.SmartQuant.SmartQuantRuntimeLocation", "e:\\sqruntime");
            if (!string.IsNullOrEmpty(location) && Platform.IsWindows)
            {
                if (InitSmartQuantLibs(location))
                    LoggingService.LogInfo("Found SmartQuant Runtime at {0}", location);
                else
                    LoggingService.LogInfo("Can't found SmartQuant Runtime at {0}", location);
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetDllDirectory(string lpPathName);

        static bool InitSmartQuantLibs(string path)
        { 
            try
            {
                return SetDllDirectory("E:\\sqruntime");
            }
            catch (EntryPointNotFoundException)
            {
            }
            return false;
        }

        // This should be the first method to call.
        public static void Init()
        {
            // TODO: Install application data

            // TODO: Install samples

            // Initialize the framework
            Framework f = new Framework("MequantaStudio", true);
            f.IsDisposable = false;
            DataLoader = new DataLoader(f);
            f.GroupDispatcher = new GroupDispatcher(f);
            LoggingService.LogInfo("SmartQuant Initialized.");
        }

        static void ParepareData()
        {
            EventLookups = new Dictionary<string, byte>();
            foreach (var info in typeof(EventType).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                EventLookups.Add(info.Name, (byte)info.GetValue(null));
            }
        }

        public static void DeInit()
        {
        }
    }
}

