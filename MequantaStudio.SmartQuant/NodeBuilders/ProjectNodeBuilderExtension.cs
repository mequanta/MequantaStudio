using System;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Projects;
using MonoDevelop.Core;

namespace MonoDevelop.SmartQuant
{
    public class ProjectNodeBuilderExtension : NodeBuilderExtension
    {
        public override bool CanBuildNode(Type dataType)
        {
            return typeof(SmartQuantProject).IsAssignableFrom(dataType);
        }
    }
}

