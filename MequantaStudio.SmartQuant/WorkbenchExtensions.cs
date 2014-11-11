using System;
using Gtk;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide;

namespace MequantaStudio.SmartQuant
{
    public static class WorkbenchExtensions
    {
        public static Document OpenDocument(this Workbench workbench, Widget widget, string contentId, bool bringToFront)
        {
            string id = string.IsNullOrWhiteSpace(contentId) ? widget.GetType().Name : contentId;
            foreach (var document in IdeApp.Workbench.Documents)
            {
                var vc = document.Window.ViewContent;
                if (vc is ViewOnlyViewContent && ((ViewOnlyViewContent)vc).ContentId == id)
                {
                    document.Window.SelectWindow();
                    return document;
                }
            }
            return IdeApp.Workbench.OpenDocument(new ViewOnlyViewContent(widget, id), bringToFront);
        }
    }
}
