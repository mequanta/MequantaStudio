
// This file has been generated by the GUI designer. Do not modify.
namespace MequantaStudio.SmartQuant
{
	public partial class DataManagerWidget
	{
		private global::Gtk.UIManager UIManager;
		
		private global::Gtk.Action refreshAction;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.Toolbar toolbar1;
		
		private global::Gtk.HPaned hpaned1;
		
		private global::Gtk.Notebook notebook1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TreeView treeview1;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Notebook notebook2;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.TreeView treeview2;
		
		private global::Gtk.Label label2;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MequantaStudio.SmartQuant.DataManagerWidget
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach (this);
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Default");
			this.refreshAction = new global::Gtk.Action ("refreshAction", null, null, "gtk-refresh");
			w2.Add (this.refreshAction, null);
			this.UIManager.InsertActionGroup (w2, 0);
			this.Name = "MequantaStudio.SmartQuant.DataManagerWidget";
			// Container child MequantaStudio.SmartQuant.DataManagerWidget.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='refreshAction' action='refreshAction'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.vbox1.Add (this.toolbar1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hpaned1 = new global::Gtk.HPaned ();
			this.hpaned1.CanFocus = true;
			this.hpaned1.Name = "hpaned1";
			this.hpaned1.Position = 160;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeview1 = new global::Gtk.TreeView ();
			this.treeview1.CanFocus = true;
			this.treeview1.Name = "treeview1";
			this.GtkScrolledWindow.Add (this.treeview1);
			this.notebook1.Add (this.GtkScrolledWindow);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
			this.notebook1.SetTabLabel (this.GtkScrolledWindow, this.label1);
			this.label1.ShowAll ();
			this.hpaned1.Add (this.notebook1);
			global::Gtk.Paned.PanedChild w6 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.notebook1]));
			w6.Resize = false;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.notebook2 = new global::Gtk.Notebook ();
			this.notebook2.CanFocus = true;
			this.notebook2.Name = "notebook2";
			this.notebook2.CurrentPage = 0;
			// Container child notebook2.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.treeview2 = new global::Gtk.TreeView ();
			this.treeview2.CanFocus = true;
			this.treeview2.Name = "treeview2";
			this.GtkScrolledWindow1.Add (this.treeview2);
			this.notebook2.Add (this.GtkScrolledWindow1);
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
			this.notebook2.SetTabLabel (this.GtkScrolledWindow1, this.label2);
			this.label2.ShowAll ();
			this.hpaned1.Add (this.notebook2);
			this.vbox1.Add (this.hpaned1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hpaned1]));
			w10.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			w1.SetUiManager (UIManager);
			this.Show ();
		}
	}
}
