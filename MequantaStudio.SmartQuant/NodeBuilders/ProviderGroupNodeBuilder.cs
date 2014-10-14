using System;
using MonoDevelop.Ide.Gui.Components;

namespace MequantaStudio.SmartQuant
{
    class ProviderGroupNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get { return typeof(ProviderGroup); }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            ProviderType type = ((ProviderGroup)dataObject).ProviderType;
            switch (type)
            {
                case ProviderType.Execution:
                    return "Exectuion";
                case ProviderType.HistoricalData:
                    return "Historical Data";
                case ProviderType.Instrument:
                    return "Instrument";
                case ProviderType.MakretData:
                    return "Market Data";
            }
            return null;
        }

        public override void GetNodeAttributes(ITreeNavigator treeNavigator, object dataObject, ref NodeAttributes attributes)
        {
            ProviderGroup folder = (ProviderGroup)dataObject;
        }
    }
}

