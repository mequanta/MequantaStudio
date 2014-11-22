using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using SmartQuant;
using SmartQuant.Controls.BarChart;

namespace MequantaStudio.SmartQuant
{
    public enum QuantControllerCommands
    {
        OpenQuantController
    }

    public enum DataCommands
    {
        OpenDataManager
    }

    public enum ImportCommands
    {
        ImportInstrument,
        ImportHistoricalData,
        ImportCsvOrTextFiles,
    }

    public enum OrderCommands
    {
        OpenOrderManager
    }

    public enum ChartCommands
    {
        OpenChart,
        OpenGaplessChart
    }

    public enum StrategyCommands
    {
        OpenStrategyMonitor,
        Start,
        Stop,
        Pause,
        Step
    }

    public enum QuoteCommands
    {
        OpenQuoteMonitor
    }

    public enum AccountCommands
    {
        Open
    }
        
    public class OpenStrategyMonitorCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            IdeApp.Workbench.OpenDocument(new StrategyMonitorWidget(), null, true);
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    public class OpenOrderManagerCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            IdeApp.Workbench.OpenDocument(new OrderManagerWidget(), null, true);
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    public class OpenAccountCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            IdeApp.Workbench.OpenDocument(new AccountWidget(), null, true);
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    class StartRunHandler: CommandHandler
    {
        protected override void Run()
        {
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    class PauseRunHandler: CommandHandler
    {
        protected override void Run()
        {
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    class ContinueRunHandler: CommandHandler
    {
        protected override void Run()
        {
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    class StopRunHandler: CommandHandler
    {
        protected override void Run()
        {
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    class StepNextHandler: CommandHandler
    {
        protected override void Run()
        {
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    class ImportCsvOrTextFileCommandHandler: CommandHandler
    {
        protected override void Run()
        {
            var wizard = new ImportWizard();
            wizard.ShowAll();
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    public class ImportInstrumentListHandler : CommandHandler
    {
        protected override void Update(CommandArrayInfo info)
        {
            foreach (var provider in Framework.Current.ProviderManager.Providers)
            {
                if (provider is IInstrumentProvider)
                {
                    var cmd = new CommandInfo(provider.Name);
                    cmd.Enabled = true;
                    cmd.Icon = provider.Status == ProviderStatus.Connected ? Gtk.Stock.Connect : Gtk.Stock.Disconnect;
                    cmd.Visible = true;
                    info.Add(cmd, provider);
                }
            }
        }

        protected override void Run(object dataItem)
        {
            var provider = dataItem as IInstrumentProvider;
            string contentId = string.Format("Import Instrument [{0}]", provider.Name);
            IdeApp.Workbench.OpenDocument(new ImportInstrumentWidget(provider.Name), contentId, true);
        }
    }

    public class ImportHistoricalDataListHandler : CommandHandler
    {
        protected override void Update(CommandArrayInfo info)
        {
            foreach (var provider in Framework.Current.ProviderManager.Providers)
            {
                if (provider is IHistoricalDataProvider)
                {
                    var cmd = new CommandInfo(provider.Name);
                    cmd.Enabled = true;
                    cmd.Icon = provider.Status == ProviderStatus.Connected ? Gtk.Stock.Connect : Gtk.Stock.Disconnect;
                    cmd.Visible = true;
                    info.Add(cmd, provider);
                }
            }
        }

        protected override void Run(object dataItem)
        {
            var provider = dataItem as IHistoricalDataProvider;
            string contentId = string.Format("Import Historical Data [{0}]", provider.Name);
            IdeApp.Workbench.OpenDocument(new ImportHistoricalDataWidget(provider.Name), contentId, true);
        }
    }
         
    public class OpenChartCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            IdeApp.Workbench.OpenBarChartViewContent(true);
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    public class OpenGaplessChartCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            IdeApp.Workbench.OpenBarChart2ViewContent(true);
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    public class QuoteMonitorListCommandHandler : CommandHandler
    {
        protected override void Update(CommandArrayInfo info)
        {
            foreach (var provider in Framework.Current.ProviderManager.Providers)
            {
                if (provider is IDataProvider)
                {
                    var cmd = new CommandInfo(provider.Name);
                    cmd.Icon = provider.Status == ProviderStatus.Connected ? Gtk.Stock.Connect : Gtk.Stock.Disconnect;
                    cmd.Enabled = true;
                    cmd.Visible = true;
                    info.Add(cmd, provider);
                }
            }
        }

        protected override void Run(object dataItem)
        {
            var provider = dataItem as IDataProvider;
            IdeApp.Workbench.OpenDocument(new QuoteMonitorWidget(provider.Name), provider.Name, true);
        }
    }

    public class OpenQuantControllerCommandHandler : CommandHandler
    {
        protected override void Run()
        {
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }

    public class OpenDataManagerCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            IdeApp.Workbench.OpenDocument(new DataManagerWidget(), null, true);
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }
}

