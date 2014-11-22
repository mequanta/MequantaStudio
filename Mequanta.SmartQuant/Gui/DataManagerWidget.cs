using System;
using Gtk;
using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class DataManagerWidget : Gtk.ScrolledWindow
    {
        private Notebook nbDataType;
        private Notebook nbTypeDetail;

        private TreeView tvDataType;
        private TreeView tvTypeDetail;

        private ListStore dataTypeStore;

        public DataManagerWidget()
        {
            Build();

            this.dataTypeStore = new ListStore(typeof(string));
            foreach (var instrument in Framework.Current.InstrumentManager.Instruments)
            {
                foreach (var ds in Framework.Current.DataManager.GetDataSeriesList(instrument, null))
                {

                }
            }
        }
    }
}

