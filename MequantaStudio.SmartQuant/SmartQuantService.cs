using System;
using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    public static class SmartQuantService
    {
        static SmartQuantService()
        {
//            Framework framework = new Framework("mstudio", true);
//            ProviderManager pmgr = framework.ProviderManager;
//            //            pmgr.AddProvider(new IBTWS(framework));
//            framework.EventLoggerManager.Add(new ConsoleEventLogger(framework));
        }

        public static object GetInstrumentRootNode()
        {
            var folder = new InstrumentFolderNode("Instruments");
            folder.Instruments.Add(new InstrumentNode("AAPL"));
            folder.Instruments.Add(new InstrumentNode("AMD"));
            return folder;
        }
    }
}

