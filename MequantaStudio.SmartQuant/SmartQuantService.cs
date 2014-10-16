using System;
using SmartQuant;
using System.Collections;

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

        public static object[] GetInstrumentRootNodes()
        {
            var folder = new InstrumentFolderNode("Instruments");
            folder.Instruments.Add(new InstrumentNode("AAPL"));
            folder.Instruments.Add(new InstrumentNode("AMD"));
            return new object[] { folder };
        }

        public static object[] GetProviderRootNodes()
        {
            var nodes = new ArrayList();
            var folder = new ProviderFolderNode(ProviderType.Execution);
            folder.Providers.Add(new ProviderNode("TTDE"));
            folder.Providers.Add(new ProviderNode("TWS"));
            nodes.Add(folder);
            nodes.Add(new ProviderFolderNode(ProviderType.HistoricalData));
            nodes.Add(new ProviderFolderNode(ProviderType.Instrument));
            nodes.Add(new ProviderFolderNode(ProviderType.MakretData));
            return nodes.ToArray();
        }
    }
}

