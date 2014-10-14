using System;
using MonoDevelop.Components.Commands;

namespace MequantaStudio.SmartQuant
{
    public class Initializer : CommandHandler
    {
        protected override void Run()
        {
            //            Framework framework = new Framework("MonoDevelop Addin", true);
            //            foreach (Provider p in framework.ProviderManager.Providers)
            //                Console.WriteLine(p.Name);
            //            Framework.Current.ProviderManager.AddProvider(new QuantRouter(framework));
            //            Framework.Current.ProviderManager.AddProvider(new QuantBase(framework));
            //            Framework.Current.ProviderManager.AddProvider(new IBTWS(framework));
            //            Framework.Current.ProviderManager.AddProvider(new TTFIX(framework));
            //            OpenQuant.Shared.Global.RedServerManager = new RedServerManager("OpenQuant", new FileInfo(string.Format("{0}\\redservers.xml", (object) Global.Setup.Folders.Config.FullName)), (RedServerMonitorBase) new RedServerMonitor());
            //            Framework.Current.EventLoggerManager.Add(new RedServerLogger(framework, OpenQuant.Shared.Global.RedServerManager.Client));
        }
    }
}

