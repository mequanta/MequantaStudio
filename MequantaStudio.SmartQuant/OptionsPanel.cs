using System;
using MonoDevelop.Ide.Gui.Dialogs;

namespace MonoDevelop.SmartQuant
{
    public class OptionsPanel: MonoDevelop.Ide.Gui.Dialogs.OptionsPanel
    {
        OptionsPanelWidget w;

        public override Gtk.Widget CreatePanelWidget()
        {
            return w = new OptionsPanelWidget();
        }

        public override void ApplyChanges()
        {
//            w.Store();
        }
    }

    [System.ComponentModel.ToolboxItem(true)]
    public partial class OptionsPanelWidget : Gtk.Bin
    {
        public OptionsPanelWidget()
        {
            this.Build();
        }
    }
}

