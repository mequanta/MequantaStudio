using System;
using SmartQuant;
using Gtk;

namespace SmartQuant.Controls.Data
{
    [System.ComponentModel.ToolboxItem(true)]
    public class DataSeriesViewer : Gtk.TreeView
    {
        private DataSeries dataSeries;

        public DataSeries DataSeries
        {
            get
            {
                return this.dataSeries;
            }
            set
            {
                this.dataSeries = value;
                UpdateData();
            }
        }

        public DataSeriesViewer()
        {
        }

        private void UpdateData()
        {
        }
    }
}

