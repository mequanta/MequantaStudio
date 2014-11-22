using System;
using System.Collections;
using Gtk;
using MonoDevelop.Components;
using MonoDevelop.Components.Docking;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads;
using SmartQuant;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{
    public enum ProviderType
    {
        Execution,
        HistoricalData,
        Instrument,
        MakretData
    }

    public class ProviderNode
    {
        public IProvider Provider { get; private set; }

        public ProviderNode(IProvider provider)
        {
            Provider = provider;
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
            nodeInfo.Icon = Context.GetIcon(Gtk.Stock.Network);
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

        public override Type CommandHandlerType
        {
            get
            { 
                return typeof(ProviderCommandHandler);
            }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            return ((ProviderNode)dataObject).Provider.Name;
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
            var provider = (dataObject as ProviderNode).Provider;
            nodeInfo.Label = provider.Name;
            nodeInfo.Icon = provider.IsConnected ? Context.GetIcon(Gtk.Stock.Connect) : Context.GetIcon(Gtk.Stock.Disconnect);
        }
    }

    public class ProviderPad : TreeViewPad
    {
        Dictionary<string, ProviderNode> mapNodes = new Dictionary<string, ProviderNode>();

        ProviderFolderNode mdFolder = new ProviderFolderNode(ProviderType.MakretData);
        ProviderFolderNode execFolder = new ProviderFolderNode(ProviderType.Execution);
        ProviderFolderNode hisFolder = new ProviderFolderNode(ProviderType.HistoricalData);
        ProviderFolderNode instFolder = new ProviderFolderNode(ProviderType.Instrument);

        public override void Initialize(NodeBuilder[] builders, TreePadOption[] options, string contextMenuPath)
        {
            base.Initialize(builders, options, contextMenuPath);
            LoadTree();
            Control.ShowAll();
        }

        private void LoadTree()
        {
            TreeView.Clear();
            var f = Framework.Current; 
            foreach (var provider in f.ProviderManager.Providers)
            {
                var node = new ProviderNode(provider);
                if (provider is IDataProvider)
                    mdFolder.Providers.Add(node);
                else if (provider is IExecutionProvider)
                    execFolder.Providers.Add(node);
                else if (provider is IHistoricalDataProvider)
                    hisFolder.Providers.Add(node);
                else if (provider is IInstrumentProvider)
                    instFolder.Providers.Add(node);
                mapNodes[provider.Name] = node;
            }

            foreach (var node in new object[] { mdFolder, execFolder, hisFolder, instFolder })
                TreeView.AddChild(node);

            f.EventManager.Dispatcher.ProviderStatusChanged += (sender, args) =>
            {
                DispatchService.GuiDispatch(delegate
                {
                    var provider = args.Provider;
                    var node = mapNodes[provider.Name];
                    var iter = TreeView.GetNodeAtObject(node);
                    TreeView.RefreshNode(iter);
                });
            };
        }
    }
}
