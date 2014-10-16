using System;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Components;
using MonoDevelop.Components.Docking;
using Gtk;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Pads;

namespace MequantaStudio.SmartQuant
{
    public class ProviderPad : TreeViewPad
    {
        public override void Initialize(NodeBuilder[] builders, TreePadOption[] options, string contextMenuPath)
        {
            base.Initialize(builders, options, contextMenuPath);
            foreach (var node in SmartQuantService.GetProviderRootNodes())
                TreeView.AddChild(node);
            Control.ShowAll();
        }
    }
}

