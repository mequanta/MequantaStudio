using System;
using MonoDevelop.Ide.Gui.Components;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{

    public class ProviderNode
    {
        public string Name { get; private set; }

        public ProviderNode(string name)
        {
            Name = name;
        }
    }

    public class ProviderFolderNode
    {
        public ProviderType Type { get; private set; }

        public List<ProviderNode> Providers { get; private set; }

        public string Label
        { 
            get
            {
                return Type.ToString();
            }
        }

        public ProviderFolderNode(ProviderType type)
        {
            Providers = new List<ProviderNode>();
            Type = type;
        }
    }

    public enum ProviderType
    {
        Execution,
        HistoricalData,
        Instrument,
        MakretData
    }

    public class ProviderFolderNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get { return typeof(ProviderFolderNode); }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            return ((ProviderFolderNode)dataObject).Label;
        }

        public override bool HasChildNodes(ITreeBuilder builder, object dataObject)
        {
            return true;
        }

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            var folder = dataObject as ProviderFolderNode;
            nodeInfo.Label = folder.Label;
            nodeInfo.Icon = Context.GetIcon("ms-sq-provider-folder");
        }

        public override void BuildChildNodes(ITreeBuilder builder, object dataObject)
        {
            var folder = dataObject as ProviderFolderNode;
            foreach (var provider in folder.Providers)
                builder.AddChild(provider);
        }
    }

    public class ProviderNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get
            { 
                return typeof(ProviderNode);
            }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            return ((ProviderNode)dataObject).Name;
        }

        public override string ContextMenuAddinPath
        {
            get
            { 
                return "/MequantaStudio/SmartQuant/ContextMenu/ProviderPad/ProviderNode";
            }
        }

        public override bool HasChildNodes(ITreeBuilder builder, object dataObject)
        {
            return false;
        }

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            var provider = dataObject as ProviderNode;
            nodeInfo.Label = provider.Name;
            nodeInfo.Icon = Context.GetIcon("ms-sq-provider");
        }
    }
}

