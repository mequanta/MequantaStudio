using System;
using SmartQuant;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{
    enum ImportTaskState
    {
        Pending,
        Processing,
        Completed,
        Cancelled,
        Error,
    }

    class ImportTask
    {
        public Instrument Instrument { get; private set; }

        public ImportTaskState State { get; set; }

        public int Count { get; set; }

        public int TotalNum { get; set; }

        public string Message { get; set; }

        public ImportTask(Instrument instrument)
        {
            Instrument = instrument;
            State = ImportTaskState.Pending;
            Count = 0;
            TotalNum = 0;
            Message = string.Empty;
        }
    }

    public partial class ImportHistoricalDataWidget: Gtk.Bin
    {
        private IHistoricalDataProvider provider;
        private HashSet<Instrument> instruments;
//        private Dictionary<string, ImportTaskViewItem> taskItems;
        private List<HistoricalDataRequest> requests;
        private HashSet<string> workingRequests;
        private Dictionary<string, Quote> lastQuotes;

        public ImportHistoricalDataWidget(string providerName)
        {
            this.Build();
            this.instruments = new HashSet<Instrument>();
//            this.taskItems = new Dictionary<string, ImportTaskViewItem>();
            this.requests = new List<HistoricalDataRequest>();
            this.workingRequests = new HashSet<string>();
            this.lastQuotes = new Dictionary<string, Quote>();

            var f = Framework.Current;
            this.provider = f.ProviderManager.GetProvider(providerName) as IHistoricalDataProvider;
            f.EventManager.Dispatcher.HistoricalData += new HistoricalDataEventHandler(this.OnHistoricalData);
            f.EventManager.Dispatcher.HistoricalDataEnd += new HistoricalDataEndEventHandler(this.OnHistoricalDataEnd);
        }
        protected override void OnDestroyed()
        {
            var f = Framework.Current;
            f.EventManager.Dispatcher.HistoricalData -= new HistoricalDataEventHandler(this.OnHistoricalData);
            f.EventManager.Dispatcher.HistoricalDataEnd -= new HistoricalDataEndEventHandler(this.OnHistoricalDataEnd);
            base.OnDestroyed();
        }
        private void OnHistoricalData(object sender, HistoricalDataEventArgs args)
        {
            var f = Framework.Current;
            HistoricalData data = args.Data;
//            ImportTaskViewItem importTaskViewItem;
//            if (!this.taskItems.TryGetValue(data.RequestId, out importTaskViewItem))
//                return;
//            foreach (DataObject dataObject in data.Objects)
//            {
//                if (dataObject is Quote)
//                {
//                    Quote quote1 = (Quote) dataObject;
//                    Quote quote2;
//                    lock (this.lastQuotes)
//                    {
//                        if (!this.lastQuotes.TryGetValue(data.RequestId, out quote2))
//                        {
//                            quote2 = new Quote(new Bid(), new Ask());
//                            this.lastQuotes.Add(data.RequestId, quote2);
//                        }
//                    }
//                    if (quote1.Bid.Price != quote2.Bid.Price || quote1.Bid.Size != quote2.Bid.Size)
//                        f.DataManager.Save(importTaskViewItem.Task.Instrument, (SmartQuant.DataObject) new Bid(quote1.Bid), SaveMode.Add);
//                    if (quote1.Ask.Price != quote2.Ask.Price || quote1.Ask.Size != quote2.Ask.Size)
//                        f.DataManager.Save(importTaskViewItem.Task.Instrument, (SmartQuant.DataObject) new Ask(quote1.Ask), SaveMode.Add);
//                    quote2.Bid.Price = quote1.Bid.Price;
//                    quote2.Bid.Size = quote1.Bid.Size;
//                    quote2.Ask.Price = quote1.Ask.Price;
//                    quote2.Ask.Size = quote1.Ask.Size;
//                }
//                else
//                    this.framework.DataManager.Save(importTaskViewItem.Task.Instrument, dataObject, SaveMode.Add);
//            }
//            importTaskViewItem.Task.TotalNum = data.TotalNum;
//            importTaskViewItem.Task.Count += data.Objects.Length; 
        }

        private void OnHistoricalDataEnd(object sender, HistoricalDataEndEventArgs args)
        {
            HistoricalDataEnd end = args.End;
//            ImportTaskViewItem importTaskViewItem;
//            if (!this.taskItems.TryGetValue(end.RequestId, out importTaskViewItem))
//                return;
//            switch (end.Result)
//            {
//                case RequestResult.Completed:
//                    importTaskViewItem.Task.State = ImportTaskState.Completed;
//                    break;
//                case RequestResult.Cancelled:
//                    importTaskViewItem.Task.State = ImportTaskState.Cancelled;
//                    break;
//                case RequestResult.Error:
//                    importTaskViewItem.Task.State = ImportTaskState.Error;
//                    break;
//            }
//            importTaskViewItem.Task.Message = end.Text;
            lock (this.workingRequests)
                this.workingRequests.Remove(end.RequestId);   
        }


//        private void worker_DoWork(object sender, DoWorkEventArgs e)
//        {
//            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
//            ThreadPool.QueueUserWorkItem(new WaitCallback(this.UpdateThread), (object) cancellationTokenSource.Token);
//            int num = 0;
//            while (!this.worker.CancellationPending)
//            {
//                if (this.workingRequests.Count == 1)
//                    Thread.Sleep(TimeSpan.FromMilliseconds(1.0));
//                else if (num < this.requests.Count)
//                {
//                    HistoricalDataRequest historicalDataRequest = this.requests[num++];
//                    WaitCallback callBack = (WaitCallback) (obj => this.provider.Send((HistoricalDataRequest) obj));
//                    lock (this.workingRequests)
//                        this.workingRequests.Add(historicalDataRequest.RequestId);
//                    this.taskItems[historicalDataRequest.RequestId].Task.State = ImportTaskState.Processing;
//                    ThreadPool.QueueUserWorkItem(callBack, (object) historicalDataRequest);
//                }
//                else
//                    goto label_13;
//            }
//            e.Cancel = true;
//            label_13:
//            while (this.workingRequests.Count > 0)
//                Thread.Sleep(TimeSpan.FromMilliseconds(1.0));
//            cancellationTokenSource.Cancel();
//        }
//
//        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
//        {
//            this.InvokeAction((Action) (() =>
//            {
//                if (e.Error != null)
//                    this.tsiInfo.Text = e.Error.Message;
//                else if (e.Cancelled)
//                    this.tsiInfo.Text = "Cancelled";
//                else
//                    this.tsiInfo.Text = "Completed";
//                this.tsbInstrumentAdd.Enabled = true;
//                this.tsbInstrumentRemove.Enabled = true;
//                this.tsbImport_Start.Enabled = true;
//                this.tsbImport_Stop.Enabled = false;
//                this.gbxSettings.Enabled = true;
//            }));
//        }
    }
}

