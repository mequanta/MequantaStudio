using System;
using Gtk;
using MonoDevelop.Ide.Gui;

namespace MequantaStudio.SmartQuant
{
    class ViewOnlyViewContent : AbstractViewContent
    {
        private Widget widget;

        public string ContentId { get; private set; }

        public override string UntitledName
        {
            get
            {
                return widget.GetType().Name;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override Widget Control
        {
            get
            {
                return widget;
            }
        }

        public ViewOnlyViewContent(Widget widget, string contentId)
        {
            this.widget = widget;
            ContentName = contentId;
            ContentId = contentId;
            IsViewOnly = true;
            Control.ShowAll();
        }

        public override void Load(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}

