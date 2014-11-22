using System;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.DesignerSupport;

namespace MequantaStudio.SmartQuant
{
    public class PropertyNodeCommandHandler : NodeCommandHandler, IPropertyPadProvider
    {
        public object GetActiveComponent()
        {
            return CurrentNodes.Length == 1 ? CurrentNode.DataItem : null;
        }

        public object GetProvider()
        {
            return null;
        }

        public void OnEndEditing(object obj)
        {
        }

        public void OnChanged(object obj)
        {
        }
    }

}

