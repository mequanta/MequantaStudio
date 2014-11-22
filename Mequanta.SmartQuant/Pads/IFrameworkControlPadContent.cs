using System;
using SmartQuant.Controls;
using MonoDevelop.Ide.Gui;

namespace MequantaStudio.SmartQuant
{
    public interface IFrameworkControlPadContent : IPadContent
    {
        FrameworkControl FrameworkControl { get; }

        void SuspendUpdates();

        void ResumeUpdates();
    }
}

