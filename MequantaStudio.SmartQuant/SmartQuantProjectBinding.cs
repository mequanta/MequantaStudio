using System;
using MonoDevelop.Projects;
using System.Xml;
using MonoDevelop.Core;

namespace MonoDevelop.SmartQuant
{
    public class SmartQuantProjectBinding : DotNetProjectBinding
    {
        public override string Name
        {
            get
            {
                return "SmartQuant";
            }
        }

        protected override DotNetProject CreateProject(string languageName, ProjectCreateInformation info, XmlElement projectOptions)
        {
            return new SmartQuantProject(languageName, info, projectOptions);
        }
    }
}