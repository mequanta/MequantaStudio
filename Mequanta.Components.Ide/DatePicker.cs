using System;
using Xwt;

namespace Mequanta.Components.Ide
{
    [System.ComponentModel.Category("Mequanta.Components")]
    [System.ComponentModel.ToolboxItem(true)]
    public class DatePicker : Gtk.EventBox
    {
        public DatePicker()
        {
            var picker = new Xwt.DatePicker();
            picker.Style = DatePickerStyle.Date;
            picker.DateTime = DateTime.Now;
            var widget = (Gtk.Widget)Xwt.Toolkit.CurrentEngine.GetNativeWidget(picker);
            Add(widget);
            ShowAll();
        }
    }
}