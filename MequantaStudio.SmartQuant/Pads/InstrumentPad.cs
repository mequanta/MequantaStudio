using System;
using MonoDevelop.Ide.Gui.Pads;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide;
using MonoDevelop.Core;
using Gtk;
using MonoDevelop.Components.Docking;
using MonoDevelop.Components;

namespace MonoDevelop.SmartQuant
{
    public class InstrumentPad : TreeViewPad
    {
        Button refreshButton;
        MenuButton groupButton;

        public override void Initialize(NodeBuilder[] builders, TreePadOption[] options, string contextMenuPath)
        {
            base.Initialize(builders, options, contextMenuPath);
            DockItemToolbar topToolbar = Window.GetToolbar(PositionType.Top);
            groupButton = new MenuButton();
            groupButton.StockImage = new IconId("md-sq-group");
            groupButton.ArrowType = ArrowType.Down;
            groupButton.TooltipText = GettextCatalog.GetString("Group instruments");
            groupButton.MenuCreator = delegate
            {
                Gtk.Menu menu = new Menu();
                menu.Add(new Gtk.MenuItem("Alphabetically"));
                menu.Add(new Gtk.SeparatorMenuItem());
                menu.Add(new Gtk.MenuItem("By Currency"));
                menu.Add(new Gtk.MenuItem("By Exchange"));
                menu.Add(new Gtk.MenuItem("By Instrument Type"));
                menu.Add(new Gtk.MenuItem("By Maturity"));
                menu.Add(new Gtk.SeparatorMenuItem());
                menu.Add(new Gtk.MenuItem("No Group"));
                menu.ShowAll();
                return menu;
            };
            topToolbar.Add(groupButton);
            refreshButton = new Button();
            refreshButton.TooltipText = GettextCatalog.GetString("Refresh instruments");
            refreshButton.Image = new Gtk.Image(Gtk.Stock.Refresh, IconSize.Menu);
            topToolbar.Add(refreshButton);
            topToolbar.ShowAll();

            TreeView.Clear();
            TreeView.LoadTree(new InstrumentFolderNode());
            Control.ShowAll();
        }
    }
}

