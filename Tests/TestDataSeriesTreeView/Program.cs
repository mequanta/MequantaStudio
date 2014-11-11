using System;
using Gtk;
using MequantaStudio.SmartQuant;
using SmartQuant;

namespace TestDataSeriesTreeView
{
    public class MainWindow : Window
    {
        public MainWindow()
            : base(WindowType.Toplevel)
        {
            var f = Framework.Current;
            var ds = f.DataManager.GetDataSeriesList()[0];
            var view = new DataSeriesTreeView(ds);
            Add(view);
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
