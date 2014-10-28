using System;
using MonoDevelop.Ide.Gui;
using Gtk;
using MonoDevelop.Core;

namespace MequantaStudio.SmartQuant
{
    public class DataManagerViewContent: NoProjectViewContent
    {
        private DataManagerWidget widget;

        public override Widget Control
        {
            get
            {
                return widget;
            }
        }

        public DataManagerViewContent()
        {
            ContentName = GettextCatalog.GetString("Data Manager");
            widget = new DataManagerWidget();
            Control.ShowAll();
        }
    }
}

