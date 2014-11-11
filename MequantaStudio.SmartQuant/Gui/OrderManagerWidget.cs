using System;
using SmartQuant;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MequantaStudio.SmartQuant
{
    public partial class OrderManagerWidget : Gtk.Bin
    {
        class DataTypeItemComparer : IComparer<DataTypeItem>
        {
            private Dictionary<byte, int> sortOrders = new Dictionary<byte, int>();

            public DataTypeItemComparer()
            {
                for (byte i = 0; i <= byte.MaxValue; ++i)
                    this.sortOrders.Add(i, i);
            }

            public int Compare(DataTypeItem x, DataTypeItem y)
            {
                if (x.DataType != DataObjectType.Bar || y.DataType != DataObjectType.Bar)
                    return this.sortOrders[x.DataType].CompareTo(this.sortOrders[y.DataType]);
                if (x.BarType.Value == y.BarType.Value)
                    return x.BarSize.Value.CompareTo(y.BarSize.Value);
                else
                    return this.sortOrders[(byte)x.BarType.Value].CompareTo(this.sortOrders[(byte)y.BarType.Value]);
            }
        }

        class InstrumentDataSeries
        {
            public Instrument Instrument { get; private set; }

            public DataSeries DataSeries { get; private set; }

            public DataTypeItem DataTypeItem { get; private set; }

            public InstrumentDataSeries(Instrument instrument, DataSeries dataSeries, DataTypeItem dataTypeItem)
            {
                Instrument = instrument;
                DataSeries = dataSeries;
                DataTypeItem = dataTypeItem;
            }
        }

        class DataTypeItem
        {
            public byte DataType { get; private set; }

            public BarType? BarType { get; private set; }

            public long? BarSize { get; private set; }

            public DataTypeItem(byte dataType, BarType? barType = null, long? barSize = null)
            {
                DataType = dataType;
                BarType = barType;
                BarSize = barSize;
            }

            public override string ToString()
            {
                return SmartQuantUtils.ConvertToString(this.DataType, this.BarType, this.BarSize);
            }
        }

        private SortedList<DataTypeItem, List<InstrumentDataSeries>> seriesLists;

        private PermanentQueue<Event> messageQueue;
        private OrderedDictionary allOrders;
        private OrderedDictionary workingOrders;
        private OrderedDictionary filledOrders;
        private OrderedDictionary cancelledOrders;
        private OrderedDictionary rejectedOrders;
        private OrderFactory orderFactory;
        public OrderManagerWidget()
        {
            Build();

            this.messageQueue = SmartQuantService.DataLoader.OrderManagerQueue;
            this.messageQueue.AddReader(this);
            allOrders = new OrderedDictionary();
            workingOrders = new OrderedDictionary();
            filledOrders = new OrderedDictionary();
            cancelledOrders = new OrderedDictionary();
            rejectedOrders = new OrderedDictionary();
            orderFactory = new OrderFactory();
//            this.seriesLists = new SortedList<DataTypeItem, List<InstrumentDataSeries>>(new DataTypeItemComparer());
//            var f = Framework.Current;
//            foreach (var instrument in f.InstrumentManager.Instruments)
//            {
//                foreach (var ds in f.DataManager.GetDataSeriesList(instrument, null))
//                {
//                    byte dataType = DataSeriesNameHelper.GetDataType(ds);
//                    DataTypeItem item = null;
//                    if (dataType == DataObjectType.Bar)
//                    {
//                        BarType barType;
//                        long barSize;
//                        if (DataSeriesNameHelper.TryGetBarTypeSize(ds, out barType, out barSize))
//                            item = new DataTypeItem(dataType, new BarType?(barType), new long?(barSize));
//                    }
//                    else
//                        item = new DataTypeItem(dataType, new BarType?(), new long?());
//                    if (item != null)
//                    {
//                        List<InstrumentDataSeries> list;
//                        if (!this.seriesLists.TryGetValue(item, out list))
//                        {
//                            list = new List<InstrumentDataSeries>();
//                            this.seriesLists.Add(item, list);
//                        }
//                        list.Add(new InstrumentDataSeries(instrument, ds, item));
//                    }
//                }
//            }
        }

        protected override void OnDestroyed()
        {
            this.messageQueue.RemoveReader(this);
            base.OnDestroyed();
        }

        private void UpdateOrders()
        {
            var events = this.messageQueue.DequeueAll(this);
            if (events == null)
                return;
            int count = this.allOrders.Count;
       //     this.lastUpdatedOrderList.Clear();
            foreach (Event e in events)
            {
                switch (e.TypeId)
                {
                    case EventType.ExecutionReport:
                        ProcessExecutionReport(e as ExecutionReport);
                        break;
                    case EventType.ExecutionCommand:
                        ProcessExecutionCommand(e as ExecutionCommand);
                        break;
                    case EventType.OnOrderManagerCleared:
                        Clear();
                        break;
                }
            }
//            foreach (Order order in this.lastUpdatedOrderList)
//                this.UpdateStatus(order);
        }

        private void ProcessExecutionReport(ExecutionReport executionReport)
        {
//            this.lastUpdatedOrderList.Add(this.orderFactory.OnExecutionReport(executionReport));
//            OrderViewItem orderViewItem = (OrderViewItem) null;
//            if (this.tOrders.Count != 0 && this.tOrders.TryGetValue(executionReport.OrderId, out orderViewItem))
//                orderViewItem.Update();
//            if (executionReport.Order != this.reportedOrder)
//                return;
//            this.ltvReports.Items.Add((ListViewItem) new ExecutionReportViewItem(executionReport));
        }

        private void ProcessExecutionCommand(ExecutionCommand executionCommand)
        {
            Order order = this.orderFactory.OnExecutionCommand(executionCommand);
//            this.lastUpdatedOrderList.Add(order);
//            if (executionCommand.Type == ExecutionCommandType.Send)
//                this.AddOrder(order);
//            if (executionCommand.Order != this.reportedOrder)
//                return;
//            this.ltvReports.Items.Add((ListViewItem) new ExecutionCommandViewItem(executionCommand));
        }

        private void AddOrder(Order order)
        {
            allOrders.Add(order, order);
        }

        private void Clear()
        {  
        }
    }
}

