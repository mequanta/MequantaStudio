using MonoDevelop.Ide.Gui;
using System;
using Gtk;
using System.Linq;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Projects;
using HollyLibrary;
using SmartQuant;
using System.Collections.Generic;
using System.Reflection;

namespace MequantaStudio.SmartQuant
{
    public class StrategyPad : IPadContent
    {
        private IPadWindow window;
        private Button buttonStart;
        private Button buttonStop;
        private Button buttonStep;
        private Button buttonPause;
        private ComboBox strategyMode;
        private ComboBox stepEvent;
        private HDateEdit dePause;

        private static Dictionary<string, byte> eventLookups;
        private static Dictionary<string, byte> modeLookups;

        static StrategyPad()
        {
            eventLookups = new Dictionary<string, byte>();
            eventLookups.Add("OnEvent", EventType.Event);
            eventLookups.Add("OnBid", EventType.Bid);
            eventLookups.Add("OnAsk", EventType.Ask);
            eventLookups.Add("OnTrade", EventType.Trade);
            eventLookups.Add("OnBar", EventType.Bar);
            eventLookups.Add("OnLevel2", EventType.Level2);
            eventLookups.Add("OnFundamental", EventType.Fundamental);
            eventLookups.Add("OnNews", EventType.News);
            eventLookups.Add("OnExecutionReport", EventType.ExecutionReport);
            eventLookups.Add("OnOrderFilled", EventType.OnOrderFilled);
            eventLookups.Add("OnOrderPartiallyFilled", EventType.OnOrderPartiallyFilled);
            eventLookups.Add("OnOrderCancelled", EventType.OnOrderCancelled);
            eventLookups.Add("OnOrderDone", EventType.OnOrderDone);
            eventLookups.Add("OnOrderReplaced", EventType.OnOrderReplaced);
            eventLookups.Add("OnOrderStatusChanged", EventType.OnOrderStatusChanged);
            eventLookups.Add("OnFill", EventType.OnFill);
            eventLookups.Add("OnPositionOpened", EventType.OnPositionOpened);
            eventLookups.Add("OnPositionClosed", EventType.OnPositionClosed);
            eventLookups.Add("OnPositionChanged", EventType.OnPositionChanged);

            modeLookups = new Dictionary<string, byte>();
            modeLookups.Add("Backtest", (byte)StrategyMode.Backtest);
            modeLookups.Add("Paper", (byte)StrategyMode.Paper);
            modeLookups.Add("Live", (byte)StrategyMode.Live);
        }

        public StrategyPad()
        {
//            IdeApp.ProjectOperations.CurrentProjectChanged += (sender, e) =>
//            {
//                var project = e.Project;
//                if (project != null)
//                    Console.WriteLine("current runnable:{0}", e.Project.Name);
//            };
//            IdeApp.ProjectOperations.CurrentSelectedSolutionChanged += (sender, e) =>
//            {
//            };
        }

        public string Id { get { return "MequantaStudio.Ide.Gui.Pads.StrategyPad"; } }

        public void Initialize(IPadWindow window)
        {
            this.window = window;
            window.Title = GettextCatalog.GetString("Strategy Controller");

            var toolbar = window.GetToolbar(PositionType.Top);

            buttonStart = new Button();
            buttonStart.Image = new Gtk.Image(Gtk.Stock.MediaPlay, Gtk.IconSize.Menu);
            buttonStart.Image.Show();
            buttonStart.TooltipText = GettextCatalog.GetString("Start");
            buttonStart.Clicked += OnBtnStartClicked;
            toolbar.Add(buttonStart);

            buttonPause = new Button();
            buttonPause.Image = new Gtk.Image(Gtk.Stock.MediaPause, Gtk.IconSize.Menu);
            buttonPause.Image.Show();
            buttonPause.TooltipText = GettextCatalog.GetString("Pause");
            buttonPause.Clicked += OnBtnPauseClicked;
            toolbar.Add(buttonPause);

            buttonStop = new Button();
            buttonStop.Image = new Gtk.Image(Gtk.Stock.MediaStop, Gtk.IconSize.Menu);
            buttonStop.Image.Show();
            buttonStop.TooltipText = GettextCatalog.GetString("Stop");
            buttonStop.Clicked += OnBtnStopClicked;
            toolbar.Add(buttonStop);
            toolbar.Add(new SeparatorToolItem());

            buttonStep = new Button();
            buttonStep.Image = new Gtk.Image(Gtk.Stock.MediaNext, Gtk.IconSize.Menu);
            buttonStep.Image.Show();
            buttonStep.TooltipText = GettextCatalog.GetString("Step");
            buttonStep.Clicked += OnBtnStepClicked;
            toolbar.Add(buttonStep);

            strategyMode = new ComboBox(Enumerable.ToArray(modeLookups.Keys));


            //    new string[] { "Backtest", "Paper", "Live" });
            strategyMode.Active = 0;
            strategyMode.Changed += OnStrategyModeChanged;
            toolbar.Add(strategyMode);

            stepEvent = new ComboBox(Enumerable.ToArray(eventLookups.Keys));
            //new string[] { "OnEvent", "OnBid", "OnAsk" });
            stepEvent.Active = 0;
            stepEvent.Changed += OnStepEventChanged;
            toolbar.Add(stepEvent);

            dePause = new HDateEdit();
            toolbar.Add(dePause);

            toolbar.ShowAll();
        }

        private void OnStrategyModeChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            TreeIter iter;
            if (!combo.GetActiveIter(out iter))
                return;
                
            string val = (string)combo.Model.GetValue(iter, 0);
            StrategyMode mode = StrategyMode.Backtest;
            if (val == "Paper")
                mode = StrategyMode.Paper;
            else if (val == "Live")
                mode = StrategyMode.Live;
              
            var f = Framework.Current;
            if (f.StrategyManager.Mode == mode)
                return;
            if (f.Mode == FrameworkMode.Simulation)
            {
                if (mode != StrategyMode.Backtest)
                {
                    Console.WriteLine(string.Format("{0} Framework::Clear Mode changed", DateTime.Now));
                    f.Clear();
                }
            }
            else if (mode == StrategyMode.Backtest)
            {
                Console.WriteLine(string.Format("{0} Framework::Clear Mode changed", DateTime.Now));
                f.Clear();
            }
            f.StrategyManager.Mode = mode;
        }

        private void OnStepEventChanged(object sender, EventArgs e)
        {
            
        }

        public void RedrawContent()
        {
        }

        public Gtk.Widget Control
        {
            get
            {
                return null;
            }
        }

        public void Dispose()
        {
        }

        private void UpdateUI()
        {
        }

        private void OnBtnStartClicked(object sender, EventArgs e)
        {
            var target = IdeApp.ProjectOperations.CurrentSelectedSolution != null && IdeApp.ProjectOperations.CurrentSelectedSolution.StartupItem != null ? 
                IdeApp.ProjectOperations.CurrentSelectedSolution.StartupItem : 
                IdeApp.ProjectOperations.CurrentSelectedBuildTarget;

            if (target == null)
                return;

            if (!(target is DotNetAssemblyProject))
                return;
             
            IAsyncOperation asyncOperation = IdeApp.ProjectOperations.Build(target);
            asyncOperation.Completed += delegate
            {
                if ((asyncOperation.Success) || (IdeApp.Preferences.RunWithWarnings && asyncOperation.SuccessWithWarnings))
                {
                    LoggingService.LogInfo("Building Success!");
                    var project = target as DotNetAssemblyProject;
                    var config = IdeApp.Workspace.ActiveConfiguration.GetConfiguration(project);
                    var outputFile = project.GetOutputFileName(config.Selector);
                    LoggingService.LogInfo("Running {0}", outputFile);

                    var executable = Assembly.LoadFile(outputFile);
                    try
                    {
                        if (executable.EntryPoint != null)
                            executable.EntryPoint.Invoke(null, new object[0]);
                        else
                            Console.WriteLine("Cannot start the project - entry point is not found.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                      //  this.SetState(SolutionRunnerState.Stopped);
                    }  
                }
            };
        }

        private void OnBtnStopClicked(object sender, EventArgs e)
        {
            Framework.Current.StrategyManager.Stop();
            Framework.Current.EventManager.Stop();
        }

        private void OnBtnPauseClicked(object sender, EventArgs e)
        {
            Framework.Current.EventManager.Pause();
        }

        private void OnBtnStepClicked(object sender, EventArgs e)
        {
            TreeIter iter;
            if (!stepEvent.GetActiveIter(out iter))
                return;
            var evt = (string)stepEvent.Model.GetValue(iter, 0);
            Framework.Current.EventManager.Step(eventLookups[evt]);
        }
    }
}