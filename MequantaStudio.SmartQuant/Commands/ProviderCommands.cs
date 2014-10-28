using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;

namespace  MequantaStudio.SmartQuant
{
    public enum ProviderCommands
    {
        Connect,
        Disconnect
    }

    public class ProviderCommandHandler : PropertyNodeCommandHandler
    {
        [CommandUpdateHandler(ProviderCommands.Connect)]
        public void UpdateConnect(CommandInfo ci)
        {
            var provider = CurrentNode.DataItem as ProviderNode;
            ci.Visible = true;
            ci.Enabled = !provider.Connected;
        }

        [CommandHandler(ProviderCommands.Connect)]
        public void Connect()
        {
            var provider = CurrentNode.DataItem as ProviderNode;
            Console.WriteLine("Do connect");
        }

        [CommandUpdateHandler(ProviderCommands.Disconnect)]
        public void UpdateDisconnect(CommandInfo ci)
        {
            var provider = CurrentNode.DataItem as ProviderNode;
            ci.Visible = true;
            ci.Enabled = provider.Connected;
        }

        [CommandHandler(ProviderCommands.Disconnect)]
        public void Disconnect()
        {
            var provider = CurrentNode.DataItem as ProviderNode;
            Console.WriteLine("Do connect");
        }
    }
}