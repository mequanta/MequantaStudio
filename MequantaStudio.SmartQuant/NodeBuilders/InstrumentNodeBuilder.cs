using System;
using MonoDevelop.Ide.Gui.Components;

namespace MequantaStudio.SmartQuant
{
    public class InstrumentNode
    {
        public string Symbol { get; set; }

        public InstrumentNode(string symbol)
        {
            Symbol = symbol;
        }
    }

    public class InstrumentNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get
            { 
                return typeof(InstrumentNode);
            }
        }

        public override string ContextMenuAddinPath
        {
            get { return "/MonoDevelop/SmartQuant/ContextMenu/InstrumentPad/InstrumentNode"; }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            return ((InstrumentNode)dataObject).Symbol;
        }

        public override bool HasChildNodes (ITreeBuilder builder, object dataObject)
        {
            return false;
        }

        public override void BuildNode (ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            var node = dataObject as InstrumentNode;
            nodeInfo.Label = node.Symbol;
            nodeInfo.Icon = Context.GetIcon("ms-sq-instrument");
        }
    }
}

