using System;
using Gtk;
using SmartQuant;
using MonoDevelop.Core;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InstrumentDataWidget : Gtk.Bin
    {
        private Instrument instrument;
        private Dictionary<TreeIter, DataSeries> mapping;
        private TreeModel detailModel;

        public InstrumentDataWidget(string symbol)
        {
            Build();
            // dsTvw.CursorChanged += HandleCursorChanged;
            dsTvw.Selection.Changed += HandleChanged;
            dsTvw.AppendColumn("Data Series", new CellRendererText(), "text", 0);
            dsTvw.AppendColumn("Object Count", new CellRendererText(), "text", 1);
            dsTvw.AppendColumn("First DateTime", new CellRendererText(), "text", 2);
            dsTvw.AppendColumn("Last DateTime", new CellRendererText(), "text", 3);
            dsTvw.HeadersVisible = true;
           
            detailTvw.AppendColumn("DateTime", new CellRendererText(), "text", 0);
            detailTvw.AppendColumn("Price", new CellRendererText(), "text", 0);
            detailTvw.AppendColumn("Size", new CellRendererText(), "text", 0);
            detailTvw.HeadersVisible = true;

            mapping = new Dictionary<TreeIter, DataSeries>();
            var model = new TreeStore(typeof(string), typeof(long), typeof(string), typeof(string));
            dsTvw.Model = model;
            detailModel = new TreeStore(typeof(string), typeof(double), typeof(double));
            detailTvw.Model = detailModel;

            var f = Framework.Current;
            this.instrument = f.InstrumentManager.Get(symbol);
            foreach (var ds in f.DataManager.GetDataSeriesList(this.instrument, null))
            {
                byte dataType = DataSeriesNameHelper.GetDataType(ds);
                BarType barType;
                long barSize;
                DataSeriesNameHelper.TryGetBarTypeSize(ds, out barType, out barSize);
                var name = GetSeriesName(dataType, barType, barSize);
                var iter = model.AppendValues(name, ds.Count, ds.DateTime1.ToString(), ds.DateTime2.ToString());
                mapping.Add(iter, ds);
            }   
        }

        void HandleChanged(object sender, EventArgs e)
        {
            TreeIter iter;
            TreeModel model;

            if (((TreeSelection)sender).GetSelected(out model, out iter))
            {
                string val = (string)model.GetValue(iter, 0);
                Console.WriteLine("{0} was selected", val);
                Console.WriteLine("{0} was selected", mapping[iter].Name);
                //LoadDataSeriesDetail(mapping[iter]);
            }
        }

        void HandleCursorChanged(object sender, EventArgs e)
        {
            var selection = (sender as TreeView).Selection;

            TreeModel model;
            TreeIter iter;

            if (selection.GetSelected(out model, out iter))
                Console.WriteLine("Path of selected row = {0}", model.GetPath(iter));               
               
        }

        private void Load()
        {
        }

        void LoadDataSeriesDetail(DataSeries dataSeries)
        {
            byte dataType = DataSeriesNameHelper.GetDataType(dataSeries);
            BarType barType;
            long barSize;
            DataSeriesNameHelper.TryGetBarTypeSize(dataSeries, out barType, out barSize);

            var model = new TreeStore(typeof(string), typeof(double), typeof(double));
            for (int i =0; i< dataSeries.Count; ++i)
            {
                var item = dataSeries[i];
                switch (dataType)
                {
                    case DataObjectType.Bid:
                        Bid bid = (Bid)item;
                        model.AppendValues(bid.DateTime, bid.Price, bid.Size);
                        break;
                    case DataObjectType.Ask:
                        Ask ask = (Ask)item;
                        model.AppendValues(ask.DateTime, ask.Price, ask.Size);
                        break;
                    case  DataObjectType.Trade:
                        Trade trade = (Trade)item;
                        model.AppendValues(trade.DateTime, trade.Price, trade.Size);
                        break;
                    case  DataObjectType.Quote:
                        Quote quote = (Quote)item;
                        model.AppendValues(quote.DateTime, quote.Ask.Price, quote.Ask.Size);
                        break;
                    case  DataObjectType.Bar:
                        Bar bar = (Bar)item;
                        model.AppendValues(bar.DateTime, bar.Close, bar.Size);
                        break;
                }
            }

            detailTvw.Model = model;
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