using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;

namespace  MequantaStudio.SmartQuant
{
    public enum InstrumentNodeCommands
    {
        AddNew,
        OpenData,
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

        [CommandUpdateHandler(InstrumentNodeCommands.OpenData)]
        public void UpdateOpenData(CommandInfo ci)
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            ci.Visible = true;
        }

        [CommandHandler(InstrumentNodeCommands.OpenData)]
        public void OpenData()
        {
            var instrument = CurrentNode.DataItem as InstrumentNode;
            string label = string.Format("Data [{0}]", instrument.Symbol);
            foreach (var doc in IdeApp.Workbench.Documents)
            {
                if (doc.Window.ViewContent.ContentName == label)
                {
                    doc.Select();
                    return;
                }
            }
            IdeApp.Workbench.OpenDocument(new InstrumentDataViewContent(label), true);
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
