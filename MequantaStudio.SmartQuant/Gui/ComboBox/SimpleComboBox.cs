using System;
using Gtk;
using Gdk;

namespace MequantaStudio.SmartQuant
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class SimpleComboBox : Gtk.Bin
    {
        private ComboListWindow popup;

        public event EventHandler DropDownOpened;
        public event EventHandler DropDownClosed;
        public event EventHandler TextChanged;

        public SimpleComboBox()
        {
        }
    }

    public partial class ComboListWindow : Gtk.Window
    {
        private ScrolledWindow sw;
        private SimpleList list;

        public ComboListWindow() : base("ComboListWindow")
        {
            WindowPosition = WindowPosition.CenterOnParent;
            Decorated = false;
            this.sw = new ScrolledWindow();
            sw.ShadowType = ShadowType.In;
            this.list = new SimpleList();
            this.sw.Add(this.list);
            Add(this.sw);
            Child.ShowAll();

            DefaultWidth = 264;
            DefaultHeight = 242;
            Show();
            ButtonPressEvent += new ButtonPressEventHandler(this.OnButtonPressEvent);
        }

        private void Close()
        {
            Hide();
        }

        protected virtual void OnButtonPressEvent(object o, ButtonPressEventArgs args)
        {
            Close();
        }
    }

    public class SimpleList : Gtk.TreeView
    {
        public SimpleList()
        {
            HeadersVisible = false;
        }

        protected override bool OnButtonPressEvent(EventButton evnt)
        {
            return base.OnButtonPressEvent(evnt);
        }

        protected override void OnRowActivated(TreePath path, TreeViewColumn column)
        {
            base.OnRowActivated(path, column);
        }

        protected override void OnCursorChanged()
        {
            base.OnCursorChanged();
        }
    }
}

