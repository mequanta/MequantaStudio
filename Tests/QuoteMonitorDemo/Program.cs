using System;
using Gtk;
using SmartQuant;

namespace QuoteMonitorDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
            : base(WindowType.Toplevel)
        {
            var f = Framework.Current;
            var ds = f.DataManager.GetDataSeriesList()[0];
            var view = new MequantaStudio.SmartQuant.QuoteMonitorWidget("Data Simulator");
            Add(view);
            SetDefaultSize(400, 300);
            Title = view.Name;
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
