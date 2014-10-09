using System;
using MonoDevelop.Components.Commands;

namespace MonoDevelop.SmartQuant
{
    public class ChartCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            ChartView.Show();
        }

        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
            info.Visible = true;
        }
    }
}

