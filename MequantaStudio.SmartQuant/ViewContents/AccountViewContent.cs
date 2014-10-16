using System;
using MonoDevelop.Ide.Gui;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    public class AccountViewContent : AbstractViewContent
    {
        private AccountWidget widget;
        public override Widget Control
        {
            get
            {
                return widget;
            }
        }

        public override void Load(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}

