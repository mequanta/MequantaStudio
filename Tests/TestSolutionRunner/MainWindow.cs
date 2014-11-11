using System;
using Gtk;
using MequantaStudio.SmartQuant;
using SmartQuant;
using System.Reflection;
using System.IO;


public partial class MainWindow: Gtk.Window
{
    private SolutionRunner runner;

    public MainWindow()
        : base(Gtk.WindowType.Toplevel)
    {
        Build();

        var f = Framework.Current;
        runner = new SolutionRunner(f);
        runner.TargetFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BollingerBands.exe");

        runner.StateChanged += OnRunnerStateChanged;
        btnStart.Clicked += OnStartButtonClicked;
        btnStop.Clicked += OnStopButtonClicked;
        btnStep.Clicked += OnStepButtonClicked;
        btnPause.Clicked += OnPauseButtonClicked;
        btnStatus.Clicked += OnStatusButtonClicked;

        foreach (var n in Enum.GetNames(typeof(StrategyMode)))
            cbxMode.AppendText(n);

        cbxMode.Changed += (sender, e) =>
        {
            if (cbxMode.ActiveText == "Backtest")
                runner.StrategyMode = StrategyMode.Backtest;
            if (cbxMode.ActiveText == "Live")
                runner.StrategyMode = StrategyMode.Live;
            if (cbxMode.ActiveText == "Paper")
                runner.StrategyMode = StrategyMode.Paper;
        };
        cbxMode.Active = 0;

        foreach (var s in runner.AvailableStepEvents.Keys)
            cbxEvent.AppendText(s);
        cbxEvent.Changed += (sender, e) => runner.StepEvent = runner.AvailableStepEvents[cbxEvent.ActiveText];
        cbxEvent.Active = 0;
        updateUI();
    }

    void HandleEventManagerStatusPaused(object sender, EventArgs e)
    {
        Gtk.Application.Invoke(delegate
        {
            this.lblEmStatus.Text = Framework.Current.EventManager.Status.ToString();
        });
    }

    void OnRunnerStateChanged(object sender, EventArgs e)
    {
        updateUI();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void OnStartButtonClicked(object o, EventArgs e)
    {
        runner.Start(new string[0]);
    }

    private void OnStopButtonClicked(object o, EventArgs e)
    {
        runner.Stop();
    }

    private void OnPauseButtonClicked(object o, EventArgs e)
    {
        runner.Pause();
    }

    private void OnStepButtonClicked(object o, EventArgs e)
    {
        runner.Step();
    }

    private void OnStatusButtonClicked(object o, EventArgs e)
    {
        Console.WriteLine("EventManager.Status: {0}", Framework.Current.EventManager.Status);
    }

    private void updateUI()
    {
        Gtk.Application.Invoke(delegate
        {
            btnStart.Sensitive = runner.StartEnabled;
            btnPause.Sensitive = runner.PauseEnabled;
            btnStop.Sensitive = runner.StopEnabled;
            btnStep.Sensitive = runner.StepEnabled;
            cbxMode.Sensitive = runner.StrategyModeEnabled;
            cbxEvent.Sensitive = runner.StepEnabled;
            dtpPause.Sensitive = runner.StepEnabled;
            lblRunnerState.Text = runner.State.ToString();
            lblEmStatus.Text = Framework.Current.EventManager.Status.ToString();
        });
    }
    protected void OnToolbarStart(object sender, EventArgs e)
    {
        Framework.Current.EventManager.Start();
    }

    protected void OnToolbarStop(object sender, EventArgs e)
    {
        Framework.Current.EventManager.Stop();
    }

    protected void OnToolbarPause(object sender, EventArgs e)
    {
        Framework.Current.EventManager.Pause();
    }

    protected void OnToolbarStep(object sender, EventArgs e)
    {
        Framework.Current.EventManager.Step(EventType.Event);
    }

    protected void OnToolbarResume(object sender, EventArgs e)
    {
        Framework.Current.EventManager.Resume();
    }
}