using System;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    class ContentWidget : Gtk.ScrolledWindow
    {
        private TreeView tv1;
        private TreeView tv2;
        private TreeView tv3;


        public ContentWidget(string name)
        {
            // Building Paneds
            var outerVPaned = new VPaned();
            var innerVPaned = new VPaned();
            var middleNb = new Notebook();
            var lowerNb = new Notebook();
            this.tv1 = new TreeView();
            this.tv2 = new TreeView();
            this.tv3 = new TreeView();

            ScrolledWindow sw;
            sw = new ScrolledWindow();
            sw.ShadowType = ShadowType.In;
            sw.AddWithViewport(tv1);
            outerVPaned.Add1(sw);
            outerVPaned.Add2(innerVPaned);
            innerVPaned.Add1(middleNb);
            innerVPaned.Add2(lowerNb);
            sw = new ScrolledWindow();
            sw.ShadowType = ShadowType.In;
            sw.AddWithViewport(tv2);
            middleNb.Add(sw);
            sw = new ScrolledWindow();
            sw.ShadowType = ShadowType.In;
            sw.AddWithViewport(tv3);
            lowerNb.Add(sw);
            AddWithViewport(outerVPaned);
            ShowAll();
        }
    }

    public partial class StrategyMonitorWidget 
    {
        private Notebook contentNotebook;

        private void Build()
        {
            var vb = new VBox();

            // Build toolbar
            var toolbar = new Gtk.Toolbar();
            var tbiLayout = new MenuToolButton(null, "Layout");
            var layoutMenu =  new Menu();
            MenuItem mi;
            mi = new MenuItem("Load...");
            mi.Activated += OnLayoutLoad;
            layoutMenu.Add(mi); 
            layoutMenu.Add(new SeparatorMenuItem());
            mi = new MenuItem("Save");
            mi.Activated += OnLayoutSave;
            layoutMenu.Add(mi);
            mi = new MenuItem("Save As");
            mi.Activated += OnLayoutSaveAs;
            layoutMenu.Add(mi);
            tbiLayout.Menu = layoutMenu;
            layoutMenu.ShowAll();
            toolbar.Insert(tbiLayout, -1);
            vb.PackStart(toolbar, false, false, 0);

            this.contentNotebook = new Notebook();
            AddNewPage("strategy1");
            AddNewPage("strateg2");
            vb.PackStart(contentNotebook, true, true, 0);
            AddWithViewport(vb);
            ShowAll();
        }

        private void AddNewPage(string label)
        {
            var content = new ContentWidget(label);
            this.contentNotebook.Add(content);
            this.contentNotebook.SetMenuLabelText(content, label);
        }

        void OnLayoutLoad (object sender, EventArgs e)
        {
            Console.WriteLine("Load");
        }
        void OnLayoutSave (object sender, EventArgs e)
        {
            Console.WriteLine("save");
        }

        void OnLayoutSaveAs (object sender, EventArgs e)
        {
            Console.WriteLine("saveas");
        }
    }
}

