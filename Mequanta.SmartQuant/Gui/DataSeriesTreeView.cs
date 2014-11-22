using System;
using Gtk;
using SmartQuant;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MequantaStudio.SmartQuant
{
    public partial class DataSeriesTreeView : Gtk.ScrolledWindow
    {
        private int pageSize;
        private int nPages;
        private DataSeries dataSeries;
        private int currentPage;
        private ComboBox cbxPageSize;

        public DataSeries DataSeries
        {
            get
            {
                return this.dataSeries;
            }
            set
            {
                if (this.dataSeries == value)
                    return;
                this.dataSeries = value;
                double count = dataSeries.Count;
                this.nPages = (int)Math.Max(Math.Ceiling(count / pageSize), 1);
                this.currentPage = 1;
                RefreshTreeview();
                UpdateGui();
            }
        }

        public int NPages
        { 
            get
            {
                return this.nPages;
            }
        }

        public int CurrentPage
        { 
            get
            { 
                return this.currentPage;
            }
            set
            {
                if (this.currentPage == value)
                    return;
                this.currentPage = value;
                RefreshTreeview();
                UpdateGui();
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                if (this.pageSize == value)
                    return;
                this.pageSize = value;
                double count = dataSeries.Count;
                this.nPages = (int)Math.Max(Math.Ceiling(count / pageSize), 1);
                this.currentPage = 1;
                RefreshTreeview();
                UpdateGui();
            }
        }

        private ListStore store;
        private Entry pageEntry;
        private TreeView treeView;

        public DataSeriesTreeView(DataSeries dataSeries)
        {
            Build();
            this.store = new ListStore(typeof(string));
            this.pageSize = int.Parse(this.cbxPageSize.ActiveText);
            this.currentPage = this.nPages = 1;
            DataSeries = dataSeries;
        }

        private void Build()
        {
            var vb = new VBox();
            var hb = new HBox();
            var toolbar = new Toolbar();
            var tbiGoToFirst = new ToolButton(Gtk.Stock.GotoFirst);
            tbiGoToFirst.Clicked += OnGoToFirstClicked;
            var tbiGoToPrev = new ToolButton(Gtk.Stock.MediaPrevious);
            tbiGoToPrev.Clicked += OnGoToPrevClicked;
            var tbiGoToNext = new ToolButton(Gtk.Stock.MediaNext);
            tbiGoToNext.Clicked += OnGoToNextClicked;
            var tbiGoToLast = new ToolButton(Gtk.Stock.GotoLast);
            tbiGoToLast.Clicked += OnGoToLastClicked;
            var tbiJumpTo = new ToolButton(Gtk.Stock.JumpTo);
            tbiJumpTo.Clicked += OnJumpToClicked;

            this.pageEntry = new Entry("100000");
            this.pageEntry.WidthRequest = 50;
            this.pageEntry.Show();
            var tbiPageEntry = new ToolItem();
            tbiPageEntry.Add(pageEntry);
            toolbar.Insert(tbiGoToFirst, -1);
            toolbar.Insert(tbiGoToPrev, -1);
            toolbar.Insert(tbiGoToNext, -1);
            toolbar.Insert(tbiGoToLast, -1);
            toolbar.Insert(new SeparatorToolItem(), -1);
            toolbar.Insert(tbiJumpTo, -1);
            toolbar.Insert(tbiPageEntry, -1);
            hb.PackStart(toolbar, true, true, 0);
            this.cbxPageSize = new ComboBox(new string[] { "20", "50", "100", "200" });
            this.cbxPageSize.Active = 0;
            this.cbxPageSize.Changed += (sender, e) => PageSize = int.Parse(this.cbxPageSize.ActiveText);
            hb.PackEnd(this.cbxPageSize, false, false, 0);
            hb.PackEnd(new Label("Page Size: "), false, false, 0);
            vb.PackStart(hb, false, false, 0);
            treeView = new TreeView();
            treeView.Model = this.store;
            treeView.HeadersVisible = true;
            treeView.AppendColumn("DataTime", new CellRendererText(), "text", 0);
            var sw = new ScrolledWindow();
            sw.ShadowType = ShadowType.In;
            sw.Add(treeView);
            vb.PackStart(sw, true, true, 0);
            AddWithViewport(vb);
        }

        private void OnGoToFirstClicked(object sender, EventArgs e)
        {
            CurrentPage = 1;
        }

        private void OnGoToPrevClicked(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
                CurrentPage -= 1;
        }

        private void OnGoToNextClicked(object sender, EventArgs e)
        {
            if (CurrentPage < NPages)
                CurrentPage += 1;
        }

        private void OnGoToLastClicked(object sender, EventArgs e)
        {
            CurrentPage = NPages;
        }

        private void OnJumpToClicked(object sender, EventArgs e)
        {
            int page = 1;
            if (int.TryParse(this.pageEntry.Text, out page))
            {
                page = Math.Min(NPages, page);
            }
            CurrentPage = page;
        }

        private void UpdateGui()
        {
            this.pageEntry.Text = CurrentPage.ToString();
        }

        private void RefreshTreeview()
        {
            this.store.Clear();
            long count = this.pageSize;
            if (this.currentPage == this.nPages)
                count = this.dataSeries.Count - (this.currentPage - 1) * this.pageSize;
            for (int i = 0; i < count; ++i)
            {
                var obj = this.dataSeries[(this.currentPage - 1) * this.pageSize + i];
                this.store.AppendValues(obj.DateTime.ToString());
            }
            treeView.Model = this.store; 
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
