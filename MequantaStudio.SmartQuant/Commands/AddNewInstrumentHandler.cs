using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace MequantaStudio.SmartQuant.Commands
{
    public class AddNewInstrumentHandler : CommandHandler
    {
        protected override void Run()
        {
            IdeApp.Workbench.ShowGlobalPreferencesDialog (null, "PackageSources");
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
            info.Visible = true;
        }
    }

}

