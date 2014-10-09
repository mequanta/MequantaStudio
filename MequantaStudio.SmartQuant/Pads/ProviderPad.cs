using System;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Components;
using MonoDevelop.Components.Docking;
using Gtk;
using SmartQuant;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Pads;

namespace MonoDevelop.SmartQuant
{
    public class ProviderPad : TreeViewPad
    {
        public override void Initialize(NodeBuilder[] builders, TreePadOption[] options, string contextMenuPath)
        {
            base.Initialize(builders, options, contextMenuPath);
            TreeView.Clear();
//            TreeView.LoadTree(new InstrumentFolderNode());
//            TreeView.LoadTree();

            foreach (global::SmartQuant.Provider provider in global::SmartQuant.Framework.Current.ProviderManager.Providers)
            {
                Console.WriteLine(provider.Name);
            }


            Control.ShowAll();
        }

    }
}

