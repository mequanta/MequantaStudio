using System;
using MonoDevelop.DesignerSupport;

namespace MonoDevelop.SmartQuant
{
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

