using System;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Projects;

namespace MequantaStudio.SmartQuant
{
    public abstract class NoProjectViewContent : AbstractViewContent
    {
        public override Project Project
        {
            get
            {
                return null;
            } 
            set
            { 
            } 
        }

        public override bool IsViewOnly
        {
            get
            { 
                return true;
            }
            set
            {
            }
        }

        public override bool IsFile { get { return false; } }

        public override void Load(string fileName)
        {
        }

    }
}

