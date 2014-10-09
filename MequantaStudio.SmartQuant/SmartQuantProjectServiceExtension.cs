using System;
using MonoDevelop.Projects;
using MonoDevelop.Ide;
using MonoDevelop.Core;

namespace MonoDevelop.SmartQuant
{
    public class SmartQuantProjectServiceExtension : ProjectServiceExtension
    {
        public override bool SupportsItem(IBuildTarget item)
        {
            return item is SmartQuantProject;
        }

        protected override BuildResult Build(IProgressMonitor monitor, SolutionEntityItem entry, ConfigurationSelector configuration)
        {
            return base.Build(monitor, entry, configuration);
        }
    }
}

