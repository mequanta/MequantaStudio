using MonoDevelop.Ide;
using MonoDevelop.Ide.Extensions;
using System;

namespace Mequanta.Startup
{
	class MainClass
	{
		[STAThread]
		public static int Main (string[] args)
		{
			return IdeStartup.Main(args, null);
		}
	}
}
