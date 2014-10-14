using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace MequantaStudio.SmartQuant.Commands
{
	public class ShowXwtContentViewHandler: CommandHandler
	{
		protected override void Run ()
		{
			IdeApp.Workbench.OpenDocument (new XwtView (), true);
		}

		protected override void Update (CommandInfo info)
		{
			info.Enabled = true;
		}
	}

	public class ShowGtkContentViewHandler: CommandHandler
	{
		protected override void Run ()
		{
		}

		protected override void Update (CommandInfo info)
		{
			info.Enabled = true;
		}
	}
}