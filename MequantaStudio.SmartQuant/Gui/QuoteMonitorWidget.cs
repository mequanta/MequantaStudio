using System;
using SmartQuant;
using System.Collections.Generic;
using System.Linq;

namespace MequantaStudio.SmartQuant
{
    public partial class QuoteMonitorWidget : Gtk.Bin
    {
        private IDataProvider dataProvider;
        private IExecutionProvider executionProvider;
        private Portfolio portfolio;
        private HashSet<Instrument> instruments = new HashSet<Instrument>();

        public QuoteMonitorWidget(string providerName)
        {
            Build();
            var f = Framework.Current;
            var provider = f.ProviderManager.GetProvider(providerName);
            this.dataProvider = provider as IDataProvider;
            this.executionProvider = provider as IExecutionProvider;
            this.portfolio = new Portfolio(f, "QuoteMonitor");

            f.EventManager.Dispatcher.Bid += new BidEventHandler(this.OnBid);
            f.EventManager.Dispatcher.Ask += new AskEventHandler(this.OnAsk);
            f.EventManager.Dispatcher.Trade += new TradeEventHandler(this.OnTrade);
        }

        protected override void OnDestroyed()
        {
            var f = Framework.Current;
            f.EventManager.Dispatcher.Bid -= new BidEventHandler(this.OnBid);
            f.EventManager.Dispatcher.Ask -= new AskEventHandler(this.OnAsk);
            f.EventManager.Dispatcher.Trade -= new TradeEventHandler(this.OnTrade);
            this.RemoveInstruments(Enumerable.ToArray<Instrument>(this.instruments));
            base.OnDestroyed();
        }

        private void AddInstruments(InstrumentList array)
        {
        }

        private void RemoveInstruments(Instrument[] array)
        {
        }

        protected virtual void OnBid(object sender, Bid bid)
        {
        }

        protected virtual void OnAsk(object sender, Ask ask)
        {
        }

        protected virtual void OnTrade(object sender, Trade trade)
        {
        }
    }
}

