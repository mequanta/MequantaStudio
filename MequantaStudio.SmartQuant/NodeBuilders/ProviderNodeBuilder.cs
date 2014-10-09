using System;
using MonoDevelop.Ide.Gui.Components;

namespace MonoDevelop.SmartQuant
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

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, ref string label, ref Gdk.Pixbuf icon, ref Gdk.Pixbuf closedIcon)
        {
            Provider provider = dataObject as Provider;
            label = provider.Name;
            icon = Context.GetIcon("md-sq-provider");
        }
    }
}

