using System;
using MonoDevelop.Ide.Gui.Components;

namespace MonoDevelop.SmartQuant
{
    public class InstrumentNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get { return typeof(InstrumentNode); }
        }

        public override string ContextMenuAddinPath
        {
            get { return "/MonoDevelop/SmartQuant/ContextMenu/InstrumentPad/InstrumentNode"; }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            InstrumentNode instrument = dataObject as InstrumentNode;
            return instrument.Symbol;
        }

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, ref string label, ref Gdk.Pixbuf icon, ref Gdk.Pixbuf closedIcon)
        {
            InstrumentNode instrument = dataObject as InstrumentNode;
            label = instrument.Symbol;
            icon = Context.GetIcon("md-sq-instrument");
        }
        //        public override void BuildChildNodes (ITreeBuilder builder, object dataObject)
        //        {
        //            ThreadPool.QueueUserWorkItem (new WaitCallback (BuildChildNodesThreaded), dataObject);
        //        }
        //
        //        private void BuildChildNodesThreaded (object state)
        //        {
        //            ColumnNode node = state as ColumnNode;
        //            ITreeBuilder builder = Context.GetTreeBuilder (state);
        //            ISchemaProvider provider = node.Column.SchemaProvider;
        //
        //            if (provider.IsSchemaActionSupported (SchemaType.Constraint, SchemaActions.Schema))
        //                DispatchService.GuiDispatch (delegate {
        //                    builder.AddChild (new ConstraintsNode (node.ConnectionContext, node.Column));
        //                    builder.Expanded = true;
        //                });
        //        }
        //
        //        public override bool HasChildNodes (ITreeBuilder builder, object dataObject)
        //        {
        //            return false;
        //        }
    }
}

