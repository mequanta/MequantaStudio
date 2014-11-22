using System;
using Gtk;
using MequantaStudio.SmartQuant;

namespace ImportWizardDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            var wizard = new ImportWizard();
            wizard.DeleteEvent += (o, e) => {
                Application.Quit();
                e.RetVal = true;
            };
            wizard.Cancel += (sender, e) =>
            {
                Application.Quit();
            };

            wizard.ShowAll();
            Application.Run();
        }
    }
}