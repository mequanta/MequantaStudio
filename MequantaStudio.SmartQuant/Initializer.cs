using MonoDevelop.Components.Commands;
using MonoDevelop.Core;

namespace MequantaStudio.SmartQuant
{
    public class Initializer : CommandHandler
    {
        protected override void Run()
        {
            SmartQuantService.PrintInfo();
        }
    }
}

