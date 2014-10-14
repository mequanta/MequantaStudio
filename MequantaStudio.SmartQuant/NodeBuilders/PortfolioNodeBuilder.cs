using System;
using MonoDevelop.Ide.Gui.Components;

namespace MequantaStudio.SmartQuant
{
    public class PortfolioNode
    {
    }

    public class PortfolioNodeBuilder : TypeNodeBuilder
    {
        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            throw new NotImplementedException();
        }

        public override Type NodeDataType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

