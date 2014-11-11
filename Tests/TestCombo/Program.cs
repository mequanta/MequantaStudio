using System;
using Gtk;

namespace TestCombo
{
    public class CellRenderCalender : CellRenderer
    {
    }

    public class MainWindow : Window
    {
        public MainWindow()
            : base(WindowType.Toplevel)
        {
            var store = new ListStore(typeof(Widget));
            store.AppendValues(new Calendar());
            var tv = new TreeView();
            tv.Model = store;
            Add(tv);
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
