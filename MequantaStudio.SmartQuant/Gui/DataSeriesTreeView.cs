using System;
using Gtk;
using SmartQuant;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;

namespace MequantaStudio.SmartQuant
{
    public class DataSeriesTreeView : ScrolledWindow
    {
        public class ProxyClass
        {
            int id;
            string data;

            public ProxyClass(int id)
            {
                this.id = id;
                data = null;
            }


            public void Fetch()
            {
                data = "some data " + id;
            }


            public int Id
            {
                get { return id; }
            }

            public string Data
            {
                get { return data; }
            }
        }

        [TreeNode(ListOnly = true)]
        public class MyNode : Gtk.TreeNode
        {
            protected ProxyClass proxy;

            public MyNode(int id)
            {
                proxy = new ProxyClass(id);
            }

            [Gtk.TreeNodeValue(Column = 1)]
            public ProxyClass Proxy
            {
                get { return proxy; }
            }

            [Gtk.TreeNodeValue(Column = 0)]
            public string Data
            {
                get { return proxy.Data; }
            }
        }

        public DataSeries DataSeries { get; set; }

        private ListStore store;
        private DataSeriesModel dsStore;

        private TreeView treeView;

        //        public DataSeriesTreeView(DataSeries dataSeries)
        //        {
        //            DataSeries = dataSeries;
        //            var hb = new HBox();
        //            treeView = new TreeView();
        //            var adjustment = new Adjustment(0, 0, DataSeries.Count, 1, 5, 20);
        //            var vscroll = new VScrollbar(adjustment);
        //            vscroll.ValueChanged += OnVScrollbarValueChanged;
        //            hb.PackStart(treeView, true, true, 1);
        //            hb.PackEnd(vscroll, false, true, 1);
        //            VscrollbarPolicy = PolicyType.Never;
        //            this.store = new ListStore(typeof(string));
        //            treeView.Model = this.store;
        //            treeView.AppendColumn("DateTime", new CellRendererText(), "text", 0);
        //            vscroll.Value = 0;
        //            Add(hb);
        //            Child.ShowAll();
        //        }

        public DataSeriesTreeView(DataSeries dataSeries)
        {
            DataSeries = dataSeries;
            treeView = new TreeView(new TreeModelAdapter(new DataSeriesModel(dataSeries)));
            treeView.HeadersVisible = true;
            treeView.AppendColumn("DataTime", new CellRendererText(), "text", 0);
            VscrollbarPolicy = PolicyType.Automatic;
            AddWithViewport(treeView);
            Child.ShowAll();

            treeView.VisibilityNotifyEvent
        }

        void OnVScrollbarValueChanged(object sender, EventArgs e)
        {
            var sbar = sender as Scrollbar;
            store.Clear();
            for (int i = 0; i < 20; ++i)
            {
                var idx = (int)sbar.Value + i;
                store.AppendValues(DataSeries[idx + i].DateTime.ToString());
            }
        }

        protected void CellDataFunc(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
        {
            try
            {
                string data = (string)model.GetValue(iter, 0);
                ProxyClass proxy = (ProxyClass)model.GetValue(iter, 1);
                Gtk.TreeView view = (Gtk.TreeView)column.TreeView;
                Gtk.TreePath start, end;
                bool go = view.GetVisibleRange(out start, out end);
                Gtk.TreeIter iter_start = default(Gtk.TreeIter);
                Gtk.TreeIter iter_end = default(Gtk.TreeIter);
                if (go)
                {
                    model.GetIter(out iter_start, start);
                    model.GetIter(out iter_end, end);
                }
                if (go &&
                    data == null &&
                    iter.UserData.ToInt32() >= iter_start.UserData.ToInt32() &&
                    iter.UserData.ToInt32() <= iter_end.UserData.ToInt32())
                {
                    Console.WriteLine("Lazy Loading " + proxy.Id + ", Visible: " + cell.Visible);
                    proxy.Fetch();
                }

                ((Gtk.CellRendererText)cell).Text = data;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e);
            }
        }

    }


    public class DataSeriesModel : GLib.Object, TreeModelImplementor
    {
        private DataSeries dataSeries;

        public DataSeriesModel(DataSeries dataSeries)
            : base()
        {
            this.dataSeries = dataSeries;
        }

        public GLib.GType GetColumnType(int index)
        {
            return GLib.GType.String;
        }

        object GetNodeAtPath(TreePath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            if (path.Indices.Length != 1)
                return null;
            int i = path.Indices[0];
            var item = i;
            return item;
        }

        TreeIter IterFromNode(object node)
        {
            TreeIter result = TreeIter.Zero; 
            GCHandle gch = GCHandle.Alloc(node);
            result.UserData = (IntPtr)gch;
            return result;
        }

        object NodeFromIter(TreeIter iter)
        {
            var gch = (GCHandle)iter.UserData;
            return gch.Target;
        }

        int ChildCount(object node)
        {
            return 0;
        }

        public bool GetIter(out TreeIter iter, TreePath path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            iter = TreeIter.Zero;

            object node = GetNodeAtPath(path);
            if (node == null)
                return false;

            iter = IterFromNode(node);
            return true;
        }

        public TreePath GetPath(TreeIter iter)
        {
            var gch = (GCHandle)iter.UserData;
            var o = gch.Target;
            if (o == null)
                throw new ArgumentException("iter");
            TreePath path = new TreePath();
            path.AppendIndex((int)o);
            return path;
        }

        public void GetValue(TreeIter iter, int col, ref GLib.Value value)
        {
            object node = NodeFromIter(iter);
            if (node == null)
                return;
            var idx = Convert.ToInt32(node);
            value = new GLib.Value(col == 0 ? dataSeries[idx].DateTime.ToString() : "");
        }

        public bool IterNext(ref TreeIter iter)
        {
            object node = NodeFromIter(iter);
            if (node == null)
                return false;

            int idx = Convert.ToInt32(node) + 1;

            if (idx < dataSeries.Count)
            {
                iter = IterFromNode(idx);
                return true;
            }
            return false; 
        }

        public bool IterPrevious(ref TreeIter iter)
        {
            object node = NodeFromIter(iter);
            if (node == null)
                return false;

            int idx = Convert.ToInt32(node) - 1;

            if (idx >= 0)
            {
                iter = IterFromNode(idx);
                return true;
            }

            return false;
        }

        public bool IterChildren(out TreeIter iter, TreeIter parent)
        {
            iter = TreeIter.Zero;

            if (parent.UserData == IntPtr.Zero)
            {
                iter = IterFromNode(0);
                return true;
            }

            object node = NodeFromIter(parent);
            if (node == null || ChildCount(node) <= 0)
                return false;
            return true;
        }

        public bool IterHasChild(TreeIter iter)
        {
            iter = TreeIter.Zero;
            return false; 
        }

        public int IterNChildren(TreeIter iter)
        {
            if (iter.UserData == IntPtr.Zero)
                return (int)dataSeries.Count;
            return 0;
        }

        public bool IterNthChild(out TreeIter iter, TreeIter parent, int n)
        {
            iter = TreeIter.Zero;

            if (parent.UserData == IntPtr.Zero)
            {
                if (dataSeries.Count <= n)
                    return false;
                iter = IterFromNode(n);
                return true;
            }

            object node = NodeFromIter(parent);
            if (node == null || ChildCount(node) <= n)
                return false;
            return true;
        }

        public bool IterParent(out TreeIter iter, TreeIter child)
        {
            iter = TreeIter.Zero;
            object node = NodeFromIter(child);
            if (node == null)
                return false;
            return true;
        }

        public void RefNode(TreeIter iter)
        {
        }

        public void UnrefNode(TreeIter iter)
        {
        }

        public TreeModelFlags Flags
        {
            get
            {
                return TreeModelFlags.ItersPersist | TreeModelFlags.ListOnly;
            }
        }

        public int NColumns
        {
            get
            {
                return 1;
            }
        }
    }
}
