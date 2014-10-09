using System;
using MonoDevelop.Core.Execution;
using MonoDevelop.Core;
using System.Collections.Generic;

namespace MonoDevelop.SmartQuant
{
    public class SmartQuantExecutionModeSet : IExecutionModeSet
    {
        #region IExecutionModeSet implementation
        public string Name {
            get {
                return GettextCatalog.GetString ("SmartQuant");
            }
        }

        public IEnumerable<IExecutionMode> ExecutionModes {
            get {
                yield return null;
//                foreach (DebuggerEngine engine in DebuggingService.GetDebuggerEngines ())
//                    yield return new ExecutionMode (engine.Name, engine.Name, new InternalDebugExecutionHandler (engine));
            }
        }
        #endregion
    }
}

