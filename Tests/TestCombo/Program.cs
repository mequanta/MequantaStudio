using System;
using Gtk;
using Gdk;
using Cairo;

namespace TestCombo
{
    public class CellRendererWidget : CellRenderer
    {
        Widget widget;

        [GLib.Property("widget")]
        public virtual Widget Widget
        {
            get
            {
                return widget;
            }
            set
            {
                widget = value;
            }
        }

        protected override void Render(Drawable window, Widget widget, Gdk.Rectangle background_area, Gdk.Rectangle cell_area, Gdk.Rectangle expose_area, CellRendererState flags)
        {
            this.widget.SizeAllocate(cell_area);
            this.widget.Show();
         //   base.Render(window, widget, background_area, cell_area, expose_area, flags);
        }


//        protected override void Render(Gdk.Drawable window, Gtk.Widget widget, Gdk.Rectangle background_area, Gdk.Rectangle cell_area, Gdk.Rectangle expose_area, Gtk.CellRendererState flags)
//        {
//            if (!this.widget.Visible)
//                this.widget.Visible = true;
//            this.widget.ParentWindow = (Gdk.Window)window;
//            if (this.widget.Parent == null)
//                this.widget.Parent = widget;
//
//            if (!this.widget.IsRealized)
//                this.widget.Realize();
//            if (!this.widget.IsMapped)
//                this.widget.Map();
//            this.widget.SizeAllocate(cell_area);
//            this.widget.Show();
//        }
            
        public override void GetSize(Widget widget, ref Gdk.Rectangle cell_area, out int x_offset, out int y_offset, out int width, out int height)
        {
            widget.GetSizeRequest(out width, out height);
            width += (int)(2 * Xpad);
            height += (int)(2 * Ypad);
            x_offset = 0;
            y_offset = 0;
            if (!cell_area.Equals(Gdk.Rectangle.Zero))
            {
                x_offset = (int)(this.Xalign * (cell_area.Width - width));
                x_offset = Math.Max(x_offset, 0);

                y_offset = (int)(this.Yalign * (cell_area.Height - height));
                y_offset = Math.Max(y_offset, 0);
            }
        }
    }

    public class MainWindow : Gtk.Window
    {
        public MainWindow()
            : base(Gtk.WindowType.Toplevel)
        {
            var store = new ListStore(typeof(Widget), typeof(string));
            var b = new Button();
            b.Label = "Button";
            store.AppendValues(new Button(), "button");
            var tv = new TreeView();
            var col = new TreeViewColumn();
            var render = new CellRendererWidget();
            col.PackStart(render, true);
            col.Title = "Widget";
            col.AddAttribute(render, "widget", 0);
            tv.AppendColumn(col);
            tv.AppendColumn("Widget", new CellRendererText(), "text", 1);
            tv.Model = store;

            var vb = new VBox();
            var combo = new ComboBox();
            combo.Model = store;
            combo.SetCellDataFunc(render, delegate
            {
            });
            vb.PackStart(combo, false, true, 1);
            vb.PackEnd(tv, true, true, 1);
            Add(vb);
            SetDefaultSize(400, 300);
            ShowAll();
            DeleteEvent += (sender, e) =>
            {
                Application.Quit();
                e.RetVal = true;
            };
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            var win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
