using System;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Core;
using MonoDevelop.Components.Docking;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Components;
using MonoDevelop.Ide;

namespace MequantaStudio.SmartQuant
{
    public class ProviderErrorListPad : IPadContent
    {
        Gtk.ScrolledWindow sw;
        PadTreeView view;
        Gtk.ToggleButton errorBtn, warnBtn, msgBtn;

        Gtk.ListStore store;
        Gtk.TreeModelFilter filter;
        Gtk.TreeModelSort sort;
        Gdk.Pixbuf iconWarning;
        Gdk.Pixbuf iconError;
        Gdk.Pixbuf iconInfo;

        const string showErrorsPropertyName = "SharpDevelop.TaskList.ShowErrors";
        const string showWarningsPropertyName = "SharpDevelop.TaskList.ShowWarnings";
        const string showMessagesPropertyName = "SharpDevelop.TaskList.ShowMessages";

        public Gtk.Widget Control {
            get {
                if (sw == null)
                    CreateControl ();
                return sw;
            }
        }
        void IPadContent.Initialize (IPadWindow window)
        {
            window.Title = GettextCatalog.GetString("Errors");
            DockItemToolbar toolbar = window.GetToolbar (Gtk.PositionType.Top);

            errorBtn = new Gtk.ToggleButton ();
            errorBtn.Active = (bool)PropertyService.Get (showErrorsPropertyName, true);
            errorBtn.Image = new Gtk.Image (Stock.Error, Gtk.IconSize.Menu);
            errorBtn.Image.Show ();
//            errorBtn.Toggled += new EventHandler (FilterChanged);
            errorBtn.TooltipText = GettextCatalog.GetString ("Show Errors");
//            UpdateErrorsNum();
            toolbar.Add (errorBtn);

            warnBtn = new Gtk.ToggleButton ();
            warnBtn.Active = (bool)PropertyService.Get (showWarningsPropertyName, true);
            warnBtn.Image = new Gtk.Image (Stock.Warning, Gtk.IconSize.Menu);
            warnBtn.Image.Show ();
//            warnBtn.Toggled += new EventHandler (FilterChanged);
            warnBtn.TooltipText = GettextCatalog.GetString ("Show Warnings");
//            UpdateWarningsNum();
            toolbar.Add (warnBtn);

            msgBtn = new Gtk.ToggleButton ();
            msgBtn.Active = (bool)PropertyService.Get (showMessagesPropertyName, true);
            msgBtn.Image = new Gtk.Image (Gtk.Stock.DialogInfo, Gtk.IconSize.Menu);
            msgBtn.Image.Show ();
//            msgBtn.Toggled += new EventHandler (FilterChanged);
            msgBtn.TooltipText = GettextCatalog.GetString ("Show Messages");
//            UpdateMessagesNum();
            toolbar.Add (msgBtn);

//            toolbar.Add (new SeparatorToolItem ());
//
//            logBtn = new ToggleButton ();
//            logBtn.Label = GettextCatalog.GetString ("Build Output");
//            logBtn.Image = ImageService.GetImage ("md-message-log", Gtk.IconSize.Menu);
//            logBtn.Image.Show ();
//            logBtn.TooltipText = GettextCatalog.GetString ("Show build output");
//            logBtn.Toggled += HandleLogBtnToggled;
//            toolbar.Add (logBtn);

            toolbar.ShowAll ();
        }


        void CreateControl ()
        {
//            control = new HPaned ();

//            store = new Gtk.ListStore (typeof (Gdk.Pixbuf), // image - type
//                typeof (bool),       // read?
//                typeof (Task));       // read? -- use Pango weight

//            Gtk.TreeModelFilterVisibleFunc filterFunct = new Gtk.TreeModelFilterVisibleFunc();
            filter = new Gtk.TreeModelFilter (store, null);
//            filter.VisibleFunc = filterFunct;
//
            sort = new Gtk.TreeModelSort (filter);
//            sort.SetSortFunc (VisibleColumns.Type, SeverityIterSort);
//            sort.SetSortFunc (VisibleColumns.Project, ProjectIterSort);
//            sort.SetSortFunc (VisibleColumns.File, FileIterSort);
//
            view = new PadTreeView (sort);
            view.RulesHint = true;
//            view.DoPopupMenu = (evnt) => IdeApp.CommandService.ShowContextMenu (view, evnt, CreateMenu ());
//            AddColumns ();
//            LoadColumnsVisibility ();
//            view.Columns[VisibleColumns.Type].SortColumnId = VisibleColumns.Type;
//            view.Columns[VisibleColumns.Project].SortColumnId = VisibleColumns.Project;
//            view.Columns[VisibleColumns.File].SortColumnId = VisibleColumns.File;

            sw = new CompactScrolledWindow ();
            sw.ShadowType = Gtk.ShadowType.None;
            sw.Add (view);
//            TaskService.Errors.TasksRemoved      += DispatchService.GuiDispatch<TaskEventHandler> (ShowResults);
//            TaskService.Errors.TasksAdded        += DispatchService.GuiDispatch<TaskEventHandler> (TaskAdded);
//            TaskService.Errors.TasksChanged      += DispatchService.GuiDispatch<TaskEventHandler> (TaskChanged);
//            TaskService.Errors.CurrentLocationTaskChanged += HandleTaskServiceErrorsCurrentLocationTaskChanged;
//
//            IdeApp.Workspace.FirstWorkspaceItemOpened += OnCombineOpen;
//            IdeApp.Workspace.LastWorkspaceItemClosed += OnCombineClosed;

//            view.RowActivated += new Gtk.RowActivatedHandler (OnRowActivated);

            iconWarning = sw.RenderIcon (Stock.Warning, Gtk.IconSize.Menu, "");
            iconError = sw.RenderIcon (Stock.Error, Gtk.IconSize.Menu, "");
            iconInfo = sw.RenderIcon (Gtk.Stock.DialogInfo, Gtk.IconSize.Menu, "");

//            control.Add1 (sw);
//
//            outputView = new LogView ();
//            control.Add2 (outputView);

            Control.ShowAll ();

//            control.SizeAllocated += HandleControlSizeAllocated;

//            bool outputVisible = PropertyService.Get<bool> (outputViewVisiblePropertyName, false);
//            if (outputVisible) {
//                outputView.Visible = true;
//                logBtn.Active = true;
//            } else {
//                outputView.Hide ();
//            }
//
//            sw.SizeAllocated += HandleSwSizeAllocated;



//            control.FocusChain = new Gtk.Widget [] { sw };
        }

        public void Dispose ()
        {
        }

        public void RedrawContent()
        {
        }

    }
}

