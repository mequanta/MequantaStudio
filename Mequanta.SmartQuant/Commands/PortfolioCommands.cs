using MonoDevelop.Components.Commands;
using System;

namespace  MequantaStudio.SmartQuant
{
    public enum PortfolioCommands
    {
        AddNew,
        ViewData,
        Delete
    }

    public class PortfolioCommandHandler : PropertyNodeCommandHandler
    {
        [CommandUpdateHandler(PortfolioCommands.AddNew)]
        public void UpdateAddNew(CommandInfo ci)
        {
            var portfolio = CurrentNode.DataItem as PortfolioNode;
            ci.Visible = true;
        }

        [CommandHandler(PortfolioCommands.AddNew)]
        public void AddNew()
        {
            var portfolio = CurrentNode.DataItem as PortfolioNode;
            Console.WriteLine("Add New Port");
        }

        [CommandUpdateHandler(PortfolioCommands.ViewData)]
        public void UpdateViewData(CommandInfo ci)
        {
            var portfolio = CurrentNode.DataItem as PortfolioNode;
            ci.Visible = true;
        }

        [CommandHandler(PortfolioCommands.ViewData)]
        public void ViewData()
        {
            var portfolio = CurrentNode.DataItem as PortfolioNode;
            Console.WriteLine("Add New Port");
        }

        [CommandUpdateHandler(PortfolioCommands.Delete)]
        public void UpdateDelete(CommandInfo ci)
        {
            var portfolio = CurrentNode.DataItem as PortfolioNode;
            ci.Visible = true;
        }

        [CommandHandler(PortfolioCommands.Delete)]
        public void Delete()
        {
            var portfolio = CurrentNode.DataItem as PortfolioNode;
            Console.WriteLine("Delete");
        }
    }
}
