using System;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Components;
using MonoDevelop.Components.Docking;
using Gtk;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Pads;
using SmartQuant;
using System.Collections;

namespace MequantaStudio.SmartQuant
{
    public class ProviderPad : TreeViewPad
    {
        public override void Initialize(NodeBuilder[] builders, TreePadOption[] options, string contextMenuPath)
        {
            base.Initialize(builders, options, contextMenuPath);
            LoadTree();
            Control.ShowAll();
        }

        private void LoadTree()
        {
            TreeView.Clear();
            foreach (var node in GetProviderRootNodes())
                TreeView.AddChild(node);
            var f = Framework.Current;
            f.EventManager.Dispatcher.ProviderAdded += (object sender, ProviderEventArgs args) =>
            {
            };
            f.EventManager.Dispatcher.ProviderStatusChanged += (object sender, ProviderEventArgs args) =>
            {
            };
        }

        private object[] GetProviderRootNodes()
        {
            var nodes = new ArrayList();
            var mdFolder = new ProviderFolderNode(ProviderType.MakretData);
            var execFolder = new ProviderFolderNode(ProviderType.Execution);
            var hisFolder = new ProviderFolderNode(ProviderType.HistoricalData);
            var instFolder = new ProviderFolderNode(ProviderType.Instrument);
            foreach (var provider in Framework.Current.ProviderManager.Providers)
            {
                var node = new ProviderNode(provider.Name);
                if (provider is IDataProvider)
                    mdFolder.Providers.Add(node);
                else if (provider is IExecutionProvider)
                    execFolder.Providers.Add(node);
                else if (provider is IHistoricalDataProvider)
                    hisFolder.Providers.Add(node);
                else if (provider is IInstrumentProvider)
                    instFolder.Providers.Add(node);
            }
            nodes.AddRange(new object[] { mdFolder, execFolder, hisFolder, instFolder }); 
            return nodes.ToArray();
        }
    }
}

