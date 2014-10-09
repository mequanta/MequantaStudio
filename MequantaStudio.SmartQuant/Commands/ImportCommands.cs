using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace MonoDevelop.SmartQuant.Commands
{
    public enum ImportCommands
    {
        ImportCsvOrTextFiles,
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

    class ImportCsvOrTextFileHandler: CommandHandler
    {
        protected override void Run()
        {
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
//            var files = DesktopService.RecentFiles.GetFiles ();
//            if (files.Count == 0)
//                return;
//
//            int i = 0;
//            foreach (var ri in files) {
//                string acceleratorKeyPrefix = i < 10 ? "_" + ((i + 1) % 10).ToString() + " " : "";
//                var cmd = new CommandInfo (acceleratorKeyPrefix + ri.DisplayName.Replace ("_", "__")) {
//                    Description = GettextCatalog.GetString ("Open {0}", ri.FileName)
//                };
//                Gdk.Pixbuf icon = DesktopService.GetPixbufForFile (ri.FileName, IconSize.Menu);
//                #pragma warning disable 618
//                if (icon != null)
//                    cmd.Icon = ImageService.GetStockId (icon, IconSize.Menu);
//                #pragma warning restore 618
//                info.Add (cmd, ri.FileName);
//                i++;
//            }
            var cmd = new CommandInfo("tttt");
            cmd.Enabled = true;
            cmd.Visible = true;
            info.Add(cmd, "null");
  
        }

        protected override void Run(object dataItem)
        {
//            IdeApp.Workbench.OpenDocument((string)dataItem);
        }
    }

    public class ImportHistoricalListHandler : CommandHandler
    {
        protected override void Update(CommandArrayInfo info)
        {
            var cmd = new CommandInfo("tttt");
            cmd.Enabled = true;
            cmd.Visible = true;
            info.Add(cmd, "null");
        }

        protected override void Run(object dataItem)
        {
            //            IdeApp.Workbench.OpenDocument((string)dataItem);
        }
    }
}

