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
            Document document;
            if (workbench.TryFindDocumentByContentId(id, out document))
                document.Window.SelectWindow();
            else
                document = workbench.OpenDocument(new ViewOnlyViewContent(widget, id), bringToFront);
            return document;
//            foreach (var document in IdeApp.Workbench.Documents)
//            {
//                var vc = document.Window.ViewContent;
//                if (vc is ViewOnlyViewContent && ((ViewOnlyViewContent)vc).ContentId == id)
//                {
//                    document.Window.SelectWindow();
//                    return document;
//                }
//            }
//            return IdeApp.Workbench.OpenDocument(new ViewOnlyViewContent(widget, id), bringToFront);
        }

        public static Document OpenDocument(this Workbench workbench, FrameworkControlViewContent content, bool bringToFront)
        {
            Document document;
            if (workbench.TryFindDocumentByContentId(content.ContentId, out document))
                document.Window.SelectWindow();
            else
                document = workbench.OpenDocument(content, bringToFront);
            return document;
        }

        public static Document OpenBarChartViewContent(this Workbench workbench, bool bringToFront)
        {
            string contentId = "BarChart";
            Document document;
            if (workbench.TryFindDocumentByContentId(contentId, out document))
                document.Window.SelectWindow();
            else
            {
                var content = new BarChartViewContent();
                document = workbench.OpenDocument(content, bringToFront);
            }
            return document;
        }

        public static Document OpenBarChart2ViewContent(this Workbench workbench, bool bringToFront)
        {
            string contentId = "BarChart2";
            Document document;
            if (workbench.TryFindDocumentByContentId(contentId, out document))
                document.Window.SelectWindow();
            else
            {
                var content = new BarChart2ViewContent();
                document = workbench.OpenDocument(content, bringToFront);
            }
            return document;
        }

        private static bool TryFindDocumentByContentId(this Workbench workbench, string contentId, out Document document)
        {
            document = null;
            foreach (var doc in IdeApp.Workbench.Documents)
            {
                var vc = doc.Window.ViewContent;
                if (vc is ViewOnlyViewContent && ((ViewOnlyViewContent)vc).ContentId == contentId)
                {
                    document = doc;
                    return true;
                }
            }
            return false;
        }
    }
}
