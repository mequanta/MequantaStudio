
// This file has been generated by the GUI designer. Do not modify.
namespace MequantaStudio.SmartQuant
{
	public partial class InstrumentDataWidget
	{
		private global::Gtk.UIManager UIManager;
		
		private global::Gtk.Action refreshAction;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Toolbar toolbar1;
		
		private global::Gtk.VPaned vpaned1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TreeView dsTvw;
		
		private global::Gtk.Notebook notebook1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.TreeView detailTvw;
		
		private global::Gtk.Label label3;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MequantaStudio.SmartQuant.InstrumentDataWidget
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach (this);
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Default");
			this.refreshAction = new global::Gtk.Action ("refreshAction", null, null, "gtk-refresh");
			w2.Add (this.refreshAction, null);
			this.UIManager.InsertActionGroup (w2, 0);
			this.Name = "MequantaStudio.SmartQuant.InstrumentDataWidget";
			// Container child MequantaStudio.SmartQuant.InstrumentDataWidget.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='refreshAction' action='refreshAction'/></toolbar></ui>");
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
			this.vpaned1.Position = 156;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.dsTvw = new global::Gtk.TreeView ();
			this.dsTvw.CanFocus = true;
			this.dsTvw.Name = "dsTvw";
			this.GtkScrolledWindow.Add (this.dsTvw);
			this.vpaned1.Add (this.GtkScrolledWindow);
			global::Gtk.Paned.PanedChild w5 = ((global::Gtk.Paned.PanedChild)(this.vpaned1 [this.GtkScrolledWindow]));
			w5.Resize = false;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.detailTvw = new global::Gtk.TreeView ();
			this.detailTvw.CanFocus = true;
			this.detailTvw.Name = "detailTvw";
			this.GtkScrolledWindow1.Add (this.detailTvw);
			this.notebook1.Add (this.GtkScrolledWindow1);
			// Notebook tab
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Data");
			this.notebook1.SetTabLabel (this.GtkScrolledWindow1, this.label3);
			this.label3.ShowAll ();
			this.vpaned1.Add (this.notebook1);
			this.vbox2.Add (this.vpaned1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vpaned1]));
			w9.Position = 1;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			w1.SetUiManager (UIManager);
			this.Hide ();
		}
	}
}
