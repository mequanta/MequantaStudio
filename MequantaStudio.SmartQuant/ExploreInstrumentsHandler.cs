using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using Gtk;

namespace MonoDevelop.SmartQuant
{
  public class ExploreInstrumentsHandler : CommandHandler
  {
    protected override void Run()
    {
//      var pad = InstrumentPad.CurrentPad;
//      pad.BringToFront(true);
    }
    protected override void Update(CommandInfo info)
    {
      info.Enabled = true;
      info.Visible = true;
    }
  }
}

