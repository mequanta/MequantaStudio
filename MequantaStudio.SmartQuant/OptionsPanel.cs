using System;

namespace MequantaStudio.SmartQuant
{
    public class OptionsPanel : MonoDevelop.Ide.Gui.Dialogs.OptionsPanel
    {
        OptionsPanelWidget w;

        public override Gtk.Widget CreatePanelWidget()
        {
            return w = new OptionsPanelWidget();
        }

        public override void ApplyChanges()
        {
        }
    }
}

