
// This file has been generated by the GUI designer. Do not modify.
namespace MequantaStudio.SmartQuant
{
	public partial class CompressBarDialog
	{
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Frame frame1;
		
		private global::Gtk.Alignment GtkAlignment2;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.ComboBox combobox1;
		
		private global::Gtk.Frame frame3;
		
		private global::Gtk.Alignment GtkAlignment4;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TreeView treeview1;
		
		private global::Gtk.VButtonBox vbuttonbox1;
		
		private global::Gtk.Button button9;
		
		private global::Gtk.Button button10;
		
		private global::Gtk.Label GtkLabel4;
		
		private global::Gtk.Label GtkLabel2;
		
		private global::Gtk.Frame frame2;
		
		private global::Gtk.Alignment GtkAlignment3;
		
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.ComboBox combobox2;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.ComboBox combobox3;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label GtkLabel3;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MequantaStudio.SmartQuant.CompressBarDialog
			this.Name = "MequantaStudio.SmartQuant.CompressBarDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			// Internal child MequantaStudio.SmartQuant.CompressBarDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("label1");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.combobox1 = global::Gtk.ComboBox.NewText ();
			this.combobox1.Name = "combobox1";
			this.hbox1.Add (this.combobox1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.combobox1]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
			w4.Position = 0;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame ();
			this.frame3.Name = "frame3";
			this.frame3.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment4 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment4.Name = "GtkAlignment4";
			this.GtkAlignment4.LeftPadding = ((uint)(12));
			// Container child GtkAlignment4.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeview1 = new global::Gtk.TreeView ();
			this.treeview1.CanFocus = true;
			this.treeview1.Name = "treeview1";
			this.GtkScrolledWindow.Add (this.treeview1);
			this.hbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.GtkScrolledWindow]));
			w6.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbuttonbox1 = new global::Gtk.VButtonBox ();
			this.vbuttonbox1.Name = "vbuttonbox1";
			this.vbuttonbox1.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.button9 = new global::Gtk.Button ();
			this.button9.CanFocus = true;
			this.button9.Name = "button9";
			this.button9.UseUnderline = true;
			this.button9.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.vbuttonbox1.Add (this.button9);
			global::Gtk.ButtonBox.ButtonBoxChild w7 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1 [this.button9]));
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.button10 = new global::Gtk.Button ();
			this.button10.CanFocus = true;
			this.button10.Name = "button10";
			this.button10.UseUnderline = true;
			this.button10.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
			this.vbuttonbox1.Add (this.button10);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1 [this.button10]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.hbox2.Add (this.vbuttonbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbuttonbox1]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.GtkAlignment4.Add (this.hbox2);
			this.frame3.Add (this.GtkAlignment4);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Instruments</b>");
			this.GtkLabel4.UseMarkup = true;
			this.frame3.LabelWidget = this.GtkLabel4;
			this.vbox3.Add (this.frame3);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame3]));
			w12.Position = 1;
			this.GtkAlignment2.Add (this.vbox3);
			this.frame1.Add (this.GtkAlignment2);
			this.GtkLabel2 = new global::Gtk.Label ();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Input</b>");
			this.GtkLabel2.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel2;
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame1]));
			w15.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(12));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Bars");
			this.hbox3.Add (this.label2);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label2]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.combobox2 = global::Gtk.ComboBox.NewText ();
			this.combobox2.Name = "combobox2";
			this.hbox3.Add (this.combobox2);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.combobox2]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox4.Add (this.hbox3);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox3]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.combobox3 = global::Gtk.ComboBox.NewText ();
			this.combobox3.Name = "combobox3";
			this.hbox4.Add (this.combobox3);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.combobox3]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("existent data series");
			this.hbox4.Add (this.label3);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label3]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			this.vbox4.Add (this.hbox4);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox4]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			this.GtkAlignment3.Add (this.vbox4);
			this.frame2.Add (this.GtkAlignment3);
			this.GtkLabel3 = new global::Gtk.Label ();
			this.GtkLabel3.Name = "GtkLabel3";
			this.GtkLabel3.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Output</b>");
			this.GtkLabel3.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel3;
			this.vbox2.Add (this.frame2);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame2]));
			w24.Position = 1;
			w24.Expand = false;
			w24.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w25.Position = 0;
			// Internal child MequantaStudio.SmartQuant.CompressBarDialog.ActionArea
			global::Gtk.HButtonBox w26 = this.ActionArea;
			w26.Name = "dialog1_ActionArea";
			w26.Spacing = 10;
			w26.BorderWidth = ((uint)(5));
			w26.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w27 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w26 [this.buttonCancel]));
			w27.Expand = false;
			w27.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w28 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w26 [this.buttonOk]));
			w28.Position = 1;
			w28.Expand = false;
			w28.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Show ();
		}
	}
}