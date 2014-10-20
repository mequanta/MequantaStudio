using System;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InstrumentDataWidget : Gtk.Bin
    {
        public InstrumentDataWidget()
        {
            this.Build();
            var model = new TreeStore(typeof(string), typeof(long), typeof(DateTime), typeof(DateTime));
            dsTvw.AppendColumn("Data Series", new CellRendererText());
            dsTvw.AppendColumn("Object Count", new CellRendererText());
            dsTvw.AppendColumn("First DateTime", new CellRendererText());
            dsTvw.AppendColumn("Last DateTime", new CellRendererText());
            model.AppendValues("dddd", "112", "fddsd", "sfdds");
            dsTvw.HeadersVisible = true;
            dsTvw.Model = model;
           // var column = new TreeViewColumn("Data Series", new Gtk.CellRendererText());
        }
    }
}

