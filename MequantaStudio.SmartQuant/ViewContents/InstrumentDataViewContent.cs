using System;
using MonoDevelop.Ide.Gui;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    public class InstrumentDataViewContent : NoProjectViewContent
    {
        private InstrumentDataWidget widget;

        public override string TabPageLabel
        {
            get
            {
                return string.Format("Data [{0}]", ContentName);
            }
        }

        public InstrumentDataViewContent(string symbol)
        {
            ContentName = symbol;
            widget = new InstrumentDataWidget(symbol);
            Control.ShowAll();
        }

        public override Widget Control
        {
            get
            {
                return widget;
            }
        }
    }
}