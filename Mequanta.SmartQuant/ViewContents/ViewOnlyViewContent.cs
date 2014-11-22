using System;
using Gtk;
using MonoDevelop.Ide.Gui;

namespace MequantaStudio.SmartQuant
{
    public class ViewOnlyViewContent : AbstractViewContent
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

        public ViewOnlyViewContent(Widget widget, string contentId, string contentLabel = "")
        {
            this.widget = widget;
            ContentName = !string.IsNullOrEmpty(contentLabel) ? contentLabel : contentId;
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

