using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using SmartQuant;

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
            var provider = (CurrentNode.DataItem as ProviderNode).Provider;
            ci.Visible = true;
            ci.Enabled = !provider.IsConnected;
        }

        [CommandHandler(ProviderCommands.Connect)]
        public void Connect()
        {
            var pNode = CurrentNode.DataItem as ProviderNode;
            var f = Framework.Current;
            var provider = f.ProviderManager.GetProvider(pNode.Provider.Name);
            provider.Connect();
        }

        [CommandUpdateHandler(ProviderCommands.Disconnect)]
        public void UpdateDisconnect(CommandInfo ci)
        {
            var provider = (CurrentNode.DataItem as ProviderNode).Provider;
            ci.Visible = true;
            ci.Enabled = provider.IsConnected;
        }

        [CommandHandler(ProviderCommands.Disconnect)]
        public void Disconnect()
        {
            var pNode = CurrentNode.DataItem as ProviderNode;
            var f = Framework.Current;
            var provider = f.ProviderManager.GetProvider(pNode.Provider.Name);
            provider.Disconnect();
        }
    }
}