using System;
using Gtk;
using MonoDevelop.Components;
using MonoDevelop.Components.Docking;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads;

namespace MequantaStudio.SmartQuant
{
    public class InstrumentPad : TreeViewPad
    {
        Button refreshButton;
        MenuButton groupButton;

        public override void Initialize(NodeBuilder[] builders, TreePadOption[] options, string contextMenuPath)
        {
            base.Initialize(builders, options, contextMenuPath);
            var topToolbar = Window.GetToolbar(PositionType.Top);
//
//            // Group button
//            groupButton = new MenuButton();
//            groupButton.StockImage = new IconId("md-sq-group");
//            groupButton.ArrowType = ArrowType.Down;
//            groupButton.Image.Show();
//            groupButton.TooltipText = GettextCatalog.GetString("Group instruments");
//            groupButton.MenuCreator = delegate
//                {
//                    Gtk.Menu menu = new Menu();
//                    menu.Add(new Gtk.MenuItem("Alphabetically"));
//                    menu.Add(new Gtk.SeparatorMenuItem());
//                    menu.Add(new Gtk.MenuItem("By Currency"));
//                    menu.Add(new Gtk.MenuItem("By Exchange"));
//                    menu.Add(new Gtk.MenuItem("By Instrument Type"));
//                    menu.Add(new Gtk.MenuItem("By Maturity"));
//                    menu.Add(new Gtk.SeparatorMenuItem());
//                    menu.Add(new Gtk.MenuItem("No Group"));
//                    menu.ShowAll();
//                    return menu;
//                };
//            topToolbar.Add(groupButton);
//
//            // Refresh button
//            refreshButton = new Button();
//            refreshButton.TooltipText = GettextCatalog.GetString("Refresh instruments");
//            refreshButton.Image = new Gtk.Image(Gtk.Stock.Refresh, IconSize.Menu);
//            refreshButton.Image.Show();
//            topToolbar.Add(refreshButton);
//
            topToolbar.ShowAll();
            TreeView.Clear();
            TreeView.LoadTree(SmartQuantService.GetInstrumentRootNode());
            Control.ShowAll();
        }
    }
}

