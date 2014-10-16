using System;
using MonoDevelop.Ide.Gui;

namespace MequantaStudio.SmartQuant
{
    public class QuoteMonitorViewContent: AbstractViewContent
    {
        #region implemented abstract members of AbstractBaseViewContent
        public override Gtk.Widget Control
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region implemented abstract members of AbstractViewContent
        public override void Load(string fileName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

