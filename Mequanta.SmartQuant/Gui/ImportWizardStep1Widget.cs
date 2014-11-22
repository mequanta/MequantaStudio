using Gtk;
using System;

namespace MequantaStudio.SmartQuant
{
    public partial class ImportWizardStep1Widget: Gtk.Bin
    {
        public ImportWizardStep1Widget()
        {
            Build();
        }

        protected void OnAddFileClicked (object sender, System.EventArgs e)
        {
            var filter = new FileFilter();
            filter.Name = "CSV files";
            filter.AddPattern("*.csv");
            filter.AddPattern("*.txt");
            filter.AddPattern("*.*");
            var fc = new Gtk.FileChooserDialog("Select File(s) to Import", null, FileChooserAction.Open, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);
            fc.SelectMultiple = true;
            fc.AddFilter(filter);

            if (fc.Run() == (int)ResponseType.Accept)
            {
                Console.WriteLine(fc.Filenames);
            }
            fc.Destroy();
        }

        protected void OnAddDirectoryClicked (object sender, EventArgs e)
        {
            var fc = new Gtk.FileChooserDialog("Select directory with CSV or text files.", null, FileChooserAction.CreateFolder, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);
            if (fc.Run() == (int)ResponseType.Accept)
            {
                Console.WriteLine(fc.Filename);
            }
            fc.Destroy();
        }

        protected void OnRemoveClicked (object sender, EventArgs e)
        {
           // throw new NotImplementedException ();
        }
    }
}