using System;
using MonoDevelop.Ide.Gui.Components;

namespace MequantaStudio.SmartQuant
{
    public class ProviderNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get { return typeof(Provider); }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            return ((Provider)dataObject).Name;
        }

        public override string ContextMenuAddinPath
        {
            get
            { 
                return "/MonoDevelop/SmartQuant/ContextMenu/ProviderPad/ProviderNode";
            }
        }
    }
}

