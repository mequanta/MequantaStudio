using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;

namespace  MequantaStudio.SmartQuant
{
    public enum InstrumentNodeCommands
    {
        AddNew,
        ViewData,
        Delete
    }

    public class InstrumentNodeCommandHandler : PropertyNodeCommandHandler
    {
        [CommandUpdateHandler(InstrumentNodeCommands.AddNew)]
        public void UpdateAddNew(CommandInfo ci)
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            ci.Visible = true;
        }

        [CommandHandler(InstrumentNodeCommands.AddNew)]
        public void AddNew()
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            Console.WriteLine(instrument.Symbol);
        }

        [CommandUpdateHandler(InstrumentNodeCommands.ViewData)]
        public void UpdateOpenData(CommandInfo ci)
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            ci.Visible = true;
        }

        [CommandHandler(InstrumentNodeCommands.ViewData)]
        public void OpenData()
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            string viewId = instrument.Symbol;
            foreach (var doc in IdeApp.Workbench.Documents)
            {
                if (doc.Window.ViewContent.ContentName == viewId)
                {
                    doc.Select();
                    return;
                }
            }
            IdeApp.Workbench.OpenDocument(new InstrumentDataViewContent(viewId), true);
        }

        [CommandUpdateHandler(InstrumentNodeCommands.Delete)]
        public void UpdateDelete(CommandInfo ci)
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            ci.Visible = instrument != null;
        }

        [CommandHandler(InstrumentNodeCommands.Delete)]
        public void Delete()
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            Console.WriteLine(instrument.Symbol);
        }
    }
}
