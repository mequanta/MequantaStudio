using System;
using MonoDevelop.Projects;
using MonoDevelop.Core;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace MonoDevelop.SmartQuant
{
    public class SmartQuantProject : DotNetAssemblyProject
    {
        public SmartQuantProject()
        {
        }

        public SmartQuantProject(string languageName) : base(languageName)
        {
        }

        public SmartQuantProject(string languageName, ProjectCreateInformation projectCreateInfo, XmlElement projectOptions) : base(languageName, projectCreateInfo, projectOptions)
        {
        }

        public override string ProjectType
        { 
            get
            {
                return "SmartQuant";
            }
        }

        public override IconId StockIcon
        { 
            get
            { 
                return "md-sq-project"; 
            }
        }
    }
}

