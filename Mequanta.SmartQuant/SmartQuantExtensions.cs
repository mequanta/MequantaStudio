using System;
using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    public static class SmartQuantExtensions
    {
        public static void ToInstrumentRootNode(this InstrumentManager manager)
        {
            foreach (var instrument in manager.Instruments)
            {
            }
        }

        public static void ToProvideRootNode(this ProviderManager manager)
        {
            foreach (var provider in manager.Providers)
            {
            }
        }
    }
}

