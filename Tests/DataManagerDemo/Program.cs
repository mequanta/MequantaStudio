using System;
using Gtk;
using SmartQuant;

namespace DataManagerDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
            : base(WindowType.Toplevel)
        {
            var f = Framework.Current;
            var ds = f.DataManager.GetDataSeriesList()[0];
            var view = new MequantaStudio.SmartQuant.DataManagerWidget();
            Add(view);
            SetDefaultSize(640, 480);
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
