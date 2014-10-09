using System;
using MonoDevelop.Ide.Gui.Components;

namespace MonoDevelop.SmartQuant
{
    public class InstrumentFolderNodeBuilder : TypeNodeBuilder
    {
        public override Type NodeDataType
        {
            get { return typeof(InstrumentFolderNode); }
        }

        public override string ContextMenuAddinPath
        {
            get { return "/MonoDevelop/SmartQuant/ContextMenu/InstrumentPad/InstrumentFolderNode"; }
        }

        public override string GetNodeName(ITreeNavigator thisNode, object dataObject)
        {
            return "AddinCatalog.GetString(\"Column\")";
        }

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, ref string label, ref Gdk.Pixbuf icon, ref Gdk.Pixbuf closedIcon)
        {
            InstrumentFolderNode node =  dataObject as InstrumentFolderNode;
            label = InstrumentFolderNode.Category;
            icon = Context.GetIcon("md-sq-instrumentfolder");
        }

//        public override void BuildChildNodes(ITreeBuilder builder, object dataObject)
//        {
//            ThreadPool.QueueUserWorkItem(new WaitCallback(BuildChildNodesThreaded), dataObject);
//        }
//
//        private void BuildChildNodesThreaded(object state)
//        {
//            ColumnNode node = state as ColumnNode;
//            ITreeBuilder builder = Context.GetTreeBuilder(state);
//            ISchemaProvider provider = node.Column.SchemaProvider;
//
//            if (provider.IsSchemaActionSupported(SchemaType.Constraint, SchemaActions.Schema))
//                DispatchService.GuiDispatch(delegate
//                {
//                    builder.AddChild(new ConstraintsNode(node.ConnectionContext, node.Column));
//                    builder.Expanded = true;
//                });
//        }
//
//        public override bool HasChildNodes(ITreeBuilder builder, object dataObject)
//        {
//            return false;
//        }
    }
}

