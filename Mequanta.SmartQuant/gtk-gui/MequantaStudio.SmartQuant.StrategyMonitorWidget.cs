
// This file has been generated by the GUI designer. Do not modify.
namespace MequantaStudio.SmartQuant
{
	public partial class StrategyMonitorWidget
	{
		private global::Gtk.UIManager UIManager;
		
		private global::Gtk.Action stopAction;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Toolbar toolbar1;
		
		private global::Gtk.VPaned vpaned1;
		
		private global::Gtk.Notebook notebook1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TreeView treeview2;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.VPaned vpaned2;
		
		private global::Gtk.Notebook notebook2;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.TreeView treeview3;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Notebook notebook3;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Toolbar toolbar2;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow2;
		
		private global::Gtk.TreeView treeview4;
		
		private global::Gtk.Label label3;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MequantaStudio.SmartQuant.StrategyMonitorWidget
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach (this);
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Default");
			this.stopAction = new global::Gtk.Action ("stopAction", null, null, "gtk-stop");
			w2.Add (this.stopAction, null);
			this.UIManager.InsertActionGroup (w2, 0);
			this.Name = "MequantaStudio.SmartQuant.StrategyMonitorWidget";
			// Container child MequantaStudio.SmartQuant.StrategyMonitorWidget.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='stopAction' action='stopAction'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.vbox2.Add (this.toolbar1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.toolbar1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vpaned1 = new global::Gtk.VPaned ();
			this.vpaned1.CanFocus = true;
			this.vpaned1.Name = "vpaned1";
			this.vpaned1.Position = 88;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeview2 = new global::Gtk.TreeView ();
			this.treeview2.CanFocus = true;
			this.treeview2.Name = "treeview2";
			this.GtkScrolledWindow.Add (this.treeview2);
			this.notebook1.Add (this.GtkScrolledWindow);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
			this.notebook1.SetTabLabel (this.GtkScrolledWindow, this.label1);
			this.label1.ShowAll ();
			this.vpaned1.Add (this.notebook1);
			global::Gtk.Paned.PanedChild w6 = ((global::Gtk.Paned.PanedChild)(this.vpaned1 [this.notebook1]));
			w6.Resize = false;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.vpaned2 = new global::Gtk.VPaned ();
			this.vpaned2.CanFocus = true;
			this.vpaned2.Name = "vpaned2";
			this.vpaned2.Position = 89;
			// Container child vpaned2.Gtk.Paned+PanedChild
			this.notebook2 = new global::Gtk.Notebook ();
			this.notebook2.CanFocus = true;
			this.notebook2.Name = "notebook2";
			this.notebook2.CurrentPage = 0;
			// Container child notebook2.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.treeview3 = new global::Gtk.TreeView ();
			this.treeview3.CanFocus = true;
			this.treeview3.Name = "treeview3";
			this.GtkScrolledWindow1.Add (this.treeview3);
			this.notebook2.Add (this.GtkScrolledWindow1);
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
			this.notebook2.SetTabLabel (this.GtkScrolledWindow1, this.label2);
			this.label2.ShowAll ();
			this.vpaned2.Add (this.notebook2);
			global::Gtk.Paned.PanedChild w9 = ((global::Gtk.Paned.PanedChild)(this.vpaned2 [this.notebook2]));
			w9.Resize = false;
			// Container child vpaned2.Gtk.Paned+PanedChild
			this.notebook3 = new global::Gtk.Notebook ();
			this.notebook3.CanFocus = true;
			this.notebook3.Name = "notebook3";
			this.notebook3.CurrentPage = 0;
			// Container child notebook3.Gtk.Notebook+NotebookChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar2'/></ui>");
			this.toolbar2 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar2")));
			this.toolbar2.Name = "toolbar2";
			this.toolbar2.ShowArrow = false;
			this.vbox3.Add (this.toolbar2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.toolbar2]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.treeview4 = new global::Gtk.TreeView ();
			this.treeview4.CanFocus = true;
			this.treeview4.Name = "treeview4";
			this.GtkScrolledWindow2.Add (this.treeview4);
			this.vbox3.Add (this.GtkScrolledWindow2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow2]));
			w12.Position = 1;
			this.notebook3.Add (this.vbox3);
			// Notebook tab
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
			this.notebook3.SetTabLabel (this.vbox3, this.label3);
			this.label3.ShowAll ();
			this.vpaned2.Add (this.notebook3);
			this.vpaned1.Add (this.vpaned2);
			this.vbox2.Add (this.vpaned1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vpaned1]));
			w16.Position = 1;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			w1.SetUiManager (UIManager);
			this.Show ();
		}
	}
}
