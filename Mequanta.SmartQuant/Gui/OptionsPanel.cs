using System;
using MonoDevelop.Core;
using MonoDevelop.Ide;

namespace MequantaStudio.SmartQuant
{
    class OptionsPanel : MonoDevelop.Ide.Gui.Dialogs.OptionsPanel
    {
        OptionsPanelWidget w;

        public override Gtk.Widget CreatePanelWidget()
        {
            return w = new OptionsPanelWidget();
        }

        public override bool ValidateChanges()
        {
            return w.ValidateChanges();
        }

        public override void ApplyChanges()
        {
            w.Store();
        }
    }

    public partial class OptionsPanelWidget : Gtk.Bin
    {
        public OptionsPanelWidget()
        {
            this.Build();
            folderEntry.Path = "e:\\sqruntime";
        }

        public bool ValidateChanges()
        {
            string location = folderEntry.Path;
            if (location.Length > 0)
            {
                if (!FileService.IsValidPath(location))
                {
                    MessageService.ShowError(GettextCatalog.GetString("Invalid path specified"));
                    return false;
                }
            }
            return true;
        }

        public void Store()
        {
            PropertyService.Set("SmartQuant.Location", folderEntry.Path);
        }
    }
}

