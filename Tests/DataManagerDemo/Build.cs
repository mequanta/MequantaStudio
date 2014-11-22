using System;
using Gtk;

namespace MequantaStudio.SmartQuant
{
    public partial class DataManagerWidget  
    {
        private void Build()
        {
            var vb = new VBox();
            var toolbar = new Toolbar();
            var tbiRefresh = new ToolButton(Stock.Refresh);
            toolbar.Insert(tbiRefresh, - 1);
            vb.PackStart(toolbar, false, false, 0);

            var hpaned = new HPaned();
            this.nbDataType = new Notebook();
            this.tvDataType = new TreeView();
            this.nbDataType.Add(this.tvDataType);
            this.nbDataType.SetTabLabelText(this.tvDataType, "Data Type");
            hpaned.Add1(this.nbDataType);

            this.nbTypeDetail = new Notebook();
            this.tvTypeDetail = new TreeView();
            this.nbTypeDetail.Add(this.tvTypeDetail);
            this.nbTypeDetail.SetTabLabelText(this.tvTypeDetail, "Data Type Details");
            hpaned.Add2(nbTypeDetail);

            vb.PackStart(hpaned);
            AddWithViewport(vb);
            ShowAll();
        }
    }
}

