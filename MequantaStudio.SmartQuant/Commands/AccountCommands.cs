using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace MequantaStudio.SmartQuant
{
    public enum AccountCommands
    {
        Open
    }

    public class AccountCommandHandler : CommandHandler
    {
        protected override void Run ()
        {
            //IdeApp.Workbench.OpenDocument (new XwtView (), true);
        }

        protected override void Update (CommandInfo info)
        {
            info.Enabled = true;
        }
    }
}

