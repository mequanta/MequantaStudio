using System;
using MonoDevelop.DesignerSupport;
using MonoDevelop.Core;

namespace MonoDevelop.SmartQuant
{
    public class ProviderItemDescriptor : CustomDescriptor
    {
        ProviderItem item;

        public ProviderItemDescriptor(ProviderItem item)
        {
            this.item = item;
        }

        [LocalizedCategory("Misc")]
        [LocalizedDisplayName("Name")]
        [LocalizedDescription("Name of the item.")]
        public string Name
        {
            get { return "ddddd"; }
            set
            {
//                IdeApp.ProjectOperations.RenameItem (item, value);
            }
        }

        [LocalizedCategory("Misc")]
        [LocalizedDisplayName("File Path")]
        [LocalizedDescription("File path of the item.")]
        public string FilePath
        {
            get
            {
                return "filnamevalue";
            }
        }
        //        [LocalizedCategory ("Misc")]
        //        [LocalizedDisplayName ("Root Directory")]
        //        [LocalizedDescription ("Root directory of source files and projects. File paths will be shown relative to this directory.")]
        //        public string RootDirectory {
        //            get {
        //                return item.BaseDirectory;
        //            }
        //            set {
        //                if (string.IsNullOrEmpty (value) || System.IO.Directory.Exists (value))
        //                    item.BaseDirectory = value;
        //            }
        //        }
        //        [LocalizedCategory ("Misc")]
        //        [LocalizedDisplayName ("File Format")]
        //        [LocalizedDescription ("File format of the project file.")]
        //        public string FileFormat {
        //            get {
        //                return item.FileFormat.Name;
        //            }
        //        }
    }
}

