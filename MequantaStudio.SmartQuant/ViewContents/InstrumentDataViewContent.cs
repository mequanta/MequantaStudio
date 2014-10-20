using System;
using MonoDevelop.Ide.Gui;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    public class InstrumentDataViewContent : NoProjectViewContent
    {
        private InstrumentDataWidget widget;

        public InstrumentDataViewContent(string label)
        {
            ContentName = label;
            widget = new InstrumentDataWidget();
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