using System;
using MonoDevelop.Ide.Gui;
using Xwt;
using MonoDevelop.Ide;

namespace MonoDevelop.SmartQuant
{
  public class ChartView: AbstractXwtViewContent
  {
    ScrollView window;

    public override Xwt.Widget Widget
    {
      get
      {
        return window;
      }
    }

    public ChartView()
    {
      window = new ScrollView();
    }

    public override void Load(string fileName)
    {
    }

    public static void Show()
    {
      ChartView chartView = null;
      foreach (var doc in IdeApp.Workbench.Documents)
      {
        ChartView v = doc.GetContent<ChartView>();
        if (v != null)
        {
          chartView = v;
          break;
        }
      }

      if (chartView == null)
        chartView = new ChartView();
      IdeApp.Workbench.OpenDocument(chartView, true);
    }
  }
}

