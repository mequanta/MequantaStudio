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

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, ref string label, ref Gdk.Pixbuf icon, ref Gdk.Pixbuf closedIcon)
        {
            base.BuildNode(treeBuilder, dataObject, ref label, ref icon, ref closedIcon);
            Project p = dataObject as Project;
            if (p is SmartQuantProject)
                icon = Context.GetIcon("md-sq-project");
        }
    }
}

