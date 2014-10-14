using System;
using MonoDevelop.DesignerSupport;
using MonoDevelop.Core;

namespace MequantaStudio.SmartQuant
{
    public class ProviderItem
    {
    }

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

    public class Provider
    {
        public string Name { get; set; }

        public Provider(string name)
        {
            this.Name = name;
        }
    }

    public class ProviderGroup
    {
        public ProviderType ProviderType { get; private set; }

        public ProviderGroup(ProviderType type)
        {
            this.ProviderType = type;
        }
    }

    public enum ProviderType
    {
        Execution,
        HistoricalData,
        Instrument,
        MakretData
    }

    public class ProviderItemPropertyProvider : IPropertyProvider
    {
        public object CreateProvider(object obj)
        {
            return new ProviderItemDescriptor((ProviderItem)obj);
        }

        public bool SupportsObject(object obj)
        {
            return obj is ProviderItem;
        }
    }
}

