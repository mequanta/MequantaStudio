using System;
using SmartQuant.Controls;
using System.ComponentModel;
using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    public class FrameworkControlViewContent : ViewOnlyViewContent
    {
        private ControlSettings settings;

        public FrameworkControl Widget
        {
            get
            { 
                return (FrameworkControl)Control;
            }
        }

        public static bool UpdateSuspended
        {
            get
            {
                return FrameworkControl.UpdatedSuspened;
            }
            set
            {
                FrameworkControl.UpdatedSuspened = value;
            }
        }

        public FrameworkControlViewContent(FrameworkControl widget, string contentId, string contentLabel = "")
            : base(widget, contentId, contentLabel)
        {
            this.settings = new ControlSettings();
            OnInit();
        }

        protected virtual void OnInit()
        {
            var f = Framework.Current;
            Widget.Init(f, this.settings, new object[0]);
        }

        public void SuspendUpdates()
        {
            Widget.SuspendUpdates();
        }

        public void ResumeUpdates()
        {
            Widget.ResumeUpdates();
        }

        public override void Dispose()
        {
            CancelEventArgs args = new CancelEventArgs();
            Widget.Close(args);
            base.Dispose();
        }
    }
}
