using System;

namespace MequantaStudio.SmartQuant.ImportExport
{
    public class Template
    {
    }

    public enum EngineState
    {
        Started,
        Paused,
        Stopped,
        Finished
    }
    public abstract class Engine
    {
        public Engine()
        {
        }
    }
}

