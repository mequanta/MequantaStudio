using System;
using MonoDevelop.Ide;
using MonoDevelop.Core.Execution;
using MonoDevelop.Core;

namespace MonoDevelop.SmartQuant
{
    public static class RunningService
    {
        public static bool PauseEnabled;
        public static DateTime PauseDateTime;

        static IConsole console;
        static string oldLayout;

        static public event EventHandler StartedEvent;
        static public event EventHandler PausedEvent;
        static public event EventHandler ResumedEvent;
        static public event EventHandler StoppedEvent;

        static RunningService()
        {
            IdeApp.Initialized += delegate
            {
            };
        }

        public static void SetUserOptions()
        {
//            PropertyService.Set ("MonoDevelop.SmartQuant.RunningService.StepOverPropertiesAndOperators", options.StepOverPropertiesAndOperators);

        }

        static void NotifyPaused ()
        {
            DispatchService.GuiDispatch (delegate {
                if (PausedEvent != null)
                    PausedEvent (null, EventArgs.Empty);
//                NotifyLocationChanged ();
                IdeApp.Workbench.GrabDesktopFocus ();
            });
        }

        public static void Stop ()
        {
//            if (!IsDebugging)
//                return;
//
//            session.Exit ();
//            Cleanup ();
        }

        public static void StepNext()
        {
//            if (!IsDebugging || IsRunning || CheckIsBusy ())
//                return;

//            session.StepLine ();
//            NotifyLocationChanged ();
        }
    }
}

