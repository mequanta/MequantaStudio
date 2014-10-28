using MonoDevelop.Ide.Gui;
using System;
using Gtk;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui;

namespace MequantaStudio.SmartQuant
{
    public class StrategyPad : IPadContent
    {
        private IPadWindow window;
        private Button buttonStart;
        private Button buttonStop;
        private Button buttonStep;
        private Button buttonPause;
        private ComboBox strategyMode;
        private ComboBox stepEvent;

        public string Id { get { return "MequantaStudio.Ide.Gui.Pads.StrategyPad"; } }

        public void Initialize(IPadWindow window)
        {
            this.window = window;
            window.Title = GettextCatalog.GetString("Strategy Controller");

            var toolbar = window.GetToolbar(PositionType.Top);

            buttonStart = new Button();
            buttonStart.Image = new Gtk.Image(MonoDevelop.Ide.Gui.Stock.RunProgramIcon, Gtk.IconSize.Menu);
            buttonStart.Image.Show();
            buttonStart.TooltipText = GettextCatalog.GetString("Start");
            buttonStart.Clicked += (object sender, EventArgs e) =>
            {
            };
            toolbar.Add(buttonStart);

            buttonPause = new Button();
            buttonPause.Image = new Gtk.Image("Pause", Gtk.IconSize.Menu);
            buttonPause.Image.Show();
            buttonPause.TooltipText = GettextCatalog.GetString("Pause");
            buttonPause.Clicked += (object sender, EventArgs e) =>
            {
            };
            toolbar.Add(buttonPause);

            buttonStop = new Button();
            buttonStop.Image = new Gtk.Image(Gtk.Stock.Stop, Gtk.IconSize.Menu);
            buttonStop.Image.Show();
            buttonStop.TooltipText = GettextCatalog.GetString("Stop");
            buttonStop.Clicked += (object sender, EventArgs e) =>
            {
            };
            toolbar.Add(buttonStop);
            toolbar.Add(new SeparatorToolItem());

            buttonStep = new Button();
            buttonStep.Image = new Gtk.Image(Gtk.Stock.Cdrom, Gtk.IconSize.Menu);
            buttonStep.Image.Show();
            buttonStep.TooltipText = GettextCatalog.GetString("Step");
            buttonStep.Clicked += (object sender, EventArgs e) =>
            {
            };
            toolbar.Add(buttonStep);

            strategyMode = new ComboBox(new string[] { "Backtest", "Paper", "Live" });
            strategyMode.Active = 0;
            toolbar.Add(strategyMode);

            stepEvent = new ComboBox(new string[] { "OnEvent", "OnBid", "OnAsk" });
            stepEvent.Active = 0;
            toolbar.Add(stepEvent);

            toolbar.ShowAll ();
        }


        public void RedrawContent()
        {
        }

        public Gtk.Widget Control
        {
            get
            {
                return null;
            }
        }

        public void Dispose()
        {
        }
    }
}