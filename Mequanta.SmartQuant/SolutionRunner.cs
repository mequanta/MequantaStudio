using SmartQuant;
using System.Reflection;
using System.IO;
using System;
using System.Threading;
using System.Collections.Generic;

namespace MequantaStudio.SmartQuant
{
    public enum SolutionRunnerState
    {
        //       Starting,
        Started,
        //      Pausing,
        Paused,
        Stopped,
    }

    public class SolutionRunner
    {
        private Framework framework;
        private SolutionRunnerState state;

        private Dictionary<string, byte> availableStepEvents;

        public DateTime PauseDateTime { get; set; }

        public bool StartEnabled { get; private set; }

        public bool StopEnabled { get; private set; }

        public bool StepEnabled { get; private set; }

        public bool PauseEnabled { get; private set; }

        public bool StrategyModeEnabled { get; private set; }

        public bool StepEventEnabled { get; private set; }

        public byte StepEvent { get; set; }

        public Dictionary<string, byte> AvailableStepEvents
        {
            get
            {
                if (availableStepEvents == null)
                {
                    availableStepEvents = new Dictionary<string, byte>();
                    availableStepEvents.Add("OnEvent", EventType.Event);
                    availableStepEvents.Add("OnBid", EventType.Bid);
                    availableStepEvents.Add("OnAsk", EventType.Ask);
                    availableStepEvents.Add("OnTrade", EventType.Trade);
                    availableStepEvents.Add("OnBar", EventType.Bar);
                    availableStepEvents.Add("OnLevel2", EventType.Level2);
                    availableStepEvents.Add("OnFundamental", EventType.Fundamental);
                    availableStepEvents.Add("OnNews", EventType.News);
                    availableStepEvents.Add("OnExecutionReport", EventType.ExecutionReport);
                    availableStepEvents.Add("OnOrderFilled", EventType.OnOrderFilled);
                    availableStepEvents.Add("OnOrderPartiallyFilled", EventType.OnOrderPartiallyFilled);
                    availableStepEvents.Add("OnOrderCancelled", EventType.OnOrderCancelled);
                    availableStepEvents.Add("OnOrderDone", EventType.OnOrderDone);
                    availableStepEvents.Add("OnOrderReplaced", EventType.OnOrderReplaced);
                    availableStepEvents.Add("OnOrderStatusChanged", EventType.OnOrderStatusChanged);
                    availableStepEvents.Add("OnFill", EventType.OnFill);
                    availableStepEvents.Add("OnPositionOpened", EventType.OnPositionOpened);
                    availableStepEvents.Add("OnPositionClosed", EventType.OnPositionClosed);
                    availableStepEvents.Add("OnPositionChanged", EventType.OnPositionChanged);
                }
                return availableStepEvents;
            }
        }

        public StrategyMode StrategyMode
        {
            get
            {
                return this.framework.StrategyManager.Mode;
            }
            set
            {
                var oldValue = this.framework.StrategyManager.Mode;
                if (((oldValue == StrategyMode.Live || oldValue == StrategyMode.Paper) && value == StrategyMode.Backtest)
                    ||
                    (oldValue == StrategyMode.Backtest && (value == StrategyMode.Paper || value == StrategyMode.Live)))
                {
                    Console.WriteLine("{0} Framework::Clear Mode changed", DateTime.Now);
                    this.framework.Clear();
                }
                this.framework.StrategyManager.Mode = value;
            }
        }

        public string TargetFile { get; set; }

        public event EventHandler StateChanged;

        public event EventHandler SolutionStarted;
        public event EventHandler SolutionStopped;
        public event EventHandler SolutionPaused;

        public SolutionRunnerState State
        { 
            get
            {
                return this.state;
            }
            set
            {
                if (this.state == value)
                    return;
                this.state = value;
                StrategyModeEnabled = this.state == SolutionRunnerState.Stopped;
                StartEnabled = this.state == SolutionRunnerState.Stopped || this.state == SolutionRunnerState.Paused;
                PauseEnabled = this.state == SolutionRunnerState.Started;
                StepEnabled = this.state == SolutionRunnerState.Paused;
                StopEnabled = this.state != SolutionRunnerState.Stopped;
                if (StateChanged != null)
                    StateChanged(this, EventArgs.Empty);
            }
        }

        private void EmitStarted()
        {
            if (SolutionStarted != null)
                SolutionStarted(this, EventArgs.Empty);
        }

        private void EmitStopped()
        {
            if (SolutionStopped != null)
                SolutionStopped(this, EventArgs.Empty);
        }

        private void EmitPaused()
        {
            if (SolutionPaused != null)
                SolutionPaused(this, EventArgs.Empty);
        }

        public SolutionRunner(Framework framework)
        {
            this.framework = framework;
            StepEvent = AvailableStepEvents["OnEvent"];
            this.framework.EventManager.Dispatcher.EventManagerStopped += (sender, e) =>
            {
                State = SolutionRunnerState.Stopped;
            };
            State = SolutionRunnerState.Stopped;
        }

        public void Start(string[] args)
        {
            if (State == SolutionRunnerState.Started)
                return;
            if (State == SolutionRunnerState.Paused)
            {
                Resume();
                return;
            }

            if (string.IsNullOrEmpty(TargetFile) || !File.Exists(TargetFile))
                throw new ApplicationException();
            var exe = Assembly.LoadFile(TargetFile);
            if (exe.EntryPoint == null)
                throw new NotSupportedException();

            if (this.framework.Mode == FrameworkMode.Simulation)
            {
                Console.WriteLine("{0}  Calling Framework::Clear - Simulation run", DateTime.Now);
                this.framework.Clear();
            }

            // Make sure EventManager is running
            if (this.framework.EventManager.Status == EventManagerStatus.Stopped)
                this.framework.EventManager.Start();
            if (this.framework.EventManager.Status == EventManagerStatus.Paused)
                this.framework.EventManager.Resume();

            State = SolutionRunnerState.Started;

            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                try
                {
                    exe.EntryPoint.Invoke(null, new object[] { args });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    this.framework.EventManager.Stop();
 //                 State = SolutionRunnerState.Stopped;
                }
            }), null);
        }

        private void Resume()
        {
            this.framework.EventManager.Resume();
            if (State == SolutionRunnerState.Paused)
                State = SolutionRunnerState.Started;
        }

        public void Pause()
        {
            this.framework.EventManager.Pause();
            if (State == SolutionRunnerState.Started)
                State = SolutionRunnerState.Paused;
        }

        public void Stop()
        {
            this.framework.StrategyManager.Stop();
        }

        public void Step()
        {
            this.framework.EventManager.Step(StepEvent);
        }
    }
}