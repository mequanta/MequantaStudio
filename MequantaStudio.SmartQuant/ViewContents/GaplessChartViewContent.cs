using System;
using MonoDevelop.Ide.Gui;
using Gtk;
using MonoDevelop.Core;


namespace MequantaStudio.SmartQuant
{
    public class GaplessChartViewContent: NoProjectViewContent
    {
        private Button widget;

        public GaplessChartViewContent()
        {
            ContentName = GettextCatalog.GetString("Chart*");
            widget = new Button(Gtk.Stock.MediaPlay);
            Control.ShowAll();
        }

        public override Widget Control
        {
            get
            {
                return widget;
            }
        }
    }
}

