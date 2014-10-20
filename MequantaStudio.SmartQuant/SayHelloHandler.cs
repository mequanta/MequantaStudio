using System;
using MonoDevelop.Components.Commands;
using Gtk;
using MonoDevelop.Ide;

namespace MonoDevelop.SmartQuant
{
    public class SayHelloHandler : CommandHandler
    {
        protected override void Run()
        {
            MessageDialog dialog = new MessageDialog(IdeApp.Workbench.RootWindow, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, "Hello SmartQuant!");
            dialog.Run();
            dialog.Destroy();
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
        }
    }
}