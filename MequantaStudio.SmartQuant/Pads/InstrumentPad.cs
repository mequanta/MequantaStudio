using System;
using Gtk;
using MonoDevelop.Components;
using MonoDevelop.Components.Docking;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads;
using MonoDevelop.DesignerSupport;

namespace MequantaStudio.SmartQuant
{
    public class InstrumentPad : TreeViewPad
    {
        Button buttonrefresh;
        MenuButton buttonGroup;

        public override void Initialize(NodeBuilder[] builders, TreePadOption[] options, string contextMenuPath)
        {
            base.Initialize(builders, options, contextMenuPath);
            var topToolbar = Window.GetToolbar(PositionType.Top);

            // Group button
            buttonGroup = new MenuButton();
            buttonGroup.StockImage = new IconId("ms-sq-group");
            buttonGroup.ArrowType = ArrowType.Down;
            buttonGroup.TooltipText = GettextCatalog.GetString("Group instruments");
            buttonGroup.MenuCreator = delegate
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
            topToolbar.Add(buttonGroup);

            // Refresh button
            buttonrefresh = new Button();
            buttonrefresh.Image = new Gtk.Image(Gtk.Stock.Refresh, IconSize.SmallToolbar);
            buttonrefresh.TooltipText = GettextCatalog.GetString("Refresh instruments");
            topToolbar.Add(buttonrefresh);

            topToolbar.ShowAll();
            var nodes = SmartQuantService.GetInstrumentRootNodes();
            foreach (var node in nodes)
                TreeView.AddChild(node);
            Control.ShowAll();
        }
    }
}
