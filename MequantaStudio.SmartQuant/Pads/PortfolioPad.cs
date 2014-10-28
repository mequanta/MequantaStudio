using System;
using MonoDevelop.Ide.Gui.Pads;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Components.Docking;
using Gtk;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Components;
using MonoDevelop.Components.PropertyGrid;
using Gdk;
using MonoDevelop.Ide;
using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    public class PortfolioPad : TreeViewPad
    {
        public PortfolioPad()
        {
            var f = Framework.Current;
            f.EventManager.Dispatcher.PortfolioAdded += (object sender, PortfolioEventArgs args) =>
            {
            };
            f.EventManager.Dispatcher.PortfolioDeleted += (object sender, PortfolioEventArgs args) =>
            {
            };
        }
    }
}
