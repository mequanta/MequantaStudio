using System;
using MonoDevelop.Ide.Gui.Components;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{
    public enum InstrumentGroupMethod
    {
        Alphabetically,
        ByCurrency,
        ByExchange,
        ByInstrumentType,
        ByMaturity,
        NoGroup
    }

    public class InstrumentFolderNode
    {
        public InstrumentFolderNode(string label)
        {
            Instruments = new List<InstrumentNode>();
            Label = label;
        }

        public string Label { get; set; }
        public List<InstrumentNode> Instruments { get; set; }
    }

    public class InstrumentFolderNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get
            {
                return typeof(InstrumentFolderNode);
            }
        }

        public override string ContextMenuAddinPath
        {
            get 
            { 
                return "/MequantaStudio/SmartQuant/ContextMenu/InstrumentPad/InstrumentFolderNode"; 
            }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {

            return ((InstrumentFolderNode)dataObject).Label;
        }

        public override void BuildNode (ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            var folder = dataObject as InstrumentFolderNode;
            nodeInfo.Label = folder.Label;
            nodeInfo.Icon = Context.GetIcon("ms-sq-instrument-group");
        }

        public override void BuildChildNodes (ITreeBuilder builder, object dataObject)
        {
            var folder = dataObject as InstrumentFolderNode;
            foreach (var instrument in folder.Instruments)
                builder.AddChild (instrument);
        }

        public override bool HasChildNodes (ITreeBuilder builder, object dataObject)
        {
            return true;
        }
    }
}

