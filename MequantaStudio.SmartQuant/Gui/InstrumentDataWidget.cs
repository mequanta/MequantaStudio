using System;
using Gtk;
using SmartQuant;
using MonoDevelop.Core;

namespace MequantaStudio.SmartQuant
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InstrumentDataWidget : Gtk.Bin
    {
        private Instrument instrument;

        public InstrumentDataWidget(string symbol)
        {
            this.Build();

            dsTvw.AppendColumn("Data Series", new CellRendererText());
            dsTvw.AppendColumn("Object Count", new CellRendererText());
            dsTvw.AppendColumn("First DateTime", new CellRendererText());
            dsTvw.AppendColumn("Last DateTime", new CellRendererText());
            dsTvw.HeadersVisible = true;
            var model = new TreeStore(typeof(string), typeof(long), typeof(DateTime), typeof(DateTime));
            dsTvw.Model = model;

            var f = Framework.Current;
            this.instrument = f.InstrumentManager.Get(symbol);

            // Get Dataseries List
            foreach (var ds in f.DataManager.GetDataSeriesList(this.instrument, null))
            {
            //    Console.WriteLine("DataSeries: {0}", ds.Name);
                byte dataType = DataSeriesNameHelper.GetDataType(ds);
                BarType barType;
                long barSize;
                DataSeriesNameHelper.TryGetBarTypeSize(ds, out barType, out barSize);
                var name = GetSeriesName(dataType, barType, barSize);
              //  Console.WriteLine("name:{0}", name);
                model.AppendValues(name, ds.Count, ds.DateTime1, ds.DateTime2);
            }

            // detail viewer


           // var column = new TreeViewColumn("Data Series", new Gtk.CellRendererText());
        }

        private void Load()
        {
        }

        public static string GetSeriesName(byte dataType, BarType? barType = null, long? barSize = null)
        {
            switch (dataType)
            {
                case DataObjectType.Bid:
                    return "Bid";
                case DataObjectType.Ask:
                    return "Ask";
                case  DataObjectType.Trade:
                    return "Trade";
                case  DataObjectType.Quote:
                    return "Quote";
                case  DataObjectType.Bar:
                    if (!barType.HasValue)
                        return "Bar";
                    if (!barSize.HasValue)
                        return string.Format("Bar {0}", barType.Value);
                    else
                        return string.Format("Bar {0} {1}", barType.Value, barSize.Value);
                default:
                    return string.Format("DataType #{0}", dataType);
            }
        }
    }
}

