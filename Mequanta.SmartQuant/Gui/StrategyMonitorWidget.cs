using System;
using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    public partial class StrategyMonitorWidget : Gtk.ScrolledWindow, IGroupListener
    {
        public PermanentQueue<Event> Queue { get; private set; }

        public StrategyMonitorWidget()
        {
            Build();
            Queue = new PermanentQueue<Event>();
            Queue.AddReader(this);
            var f = Framework.Current;
            f.GroupDispatcher = new GroupDispatcher(f);
            f.GroupDispatcher.AddListener(this);
        }

        protected override void OnDestroyed()
        {
            Queue.RemoveReader(this);
            base.OnDestroyed();
        }
        public bool OnNewGroup(Group group)
        {
            return group.Fields.ContainsKey("Symbol") && group.Fields.ContainsKey("StrategyName") && group.Fields.ContainsKey("LogName");
        }

        public void OnNewGroupEvent(GroupEvent groupEvent)
        {
            var group = groupEvent.Group;
            switch (groupEvent.Obj.TypeId)
            {
                case DataObjectType.TimeSeriesItem:
                    TimeSeriesItem timeSeriesItem = groupEvent.Obj as TimeSeriesItem;
//                    this.manager.GetLogList(group.Fields["StrategyName"].Value.ToString(), group.Fields["Symbol"].Value.ToString())[group.Fields["LogName"].Value.ToString()].Add(timeSeriesItem.DateTime, (object) timeSeriesItem.Value);
                    break;
                case DataObjectType.Text:
                    TextInfo textInfo = groupEvent.Obj as TextInfo;
//                    this.manager.GetLogList(group.Fields["StrategyName"].Value.ToString(), group.Fields["Symbol"].Value.ToString())[group.Fields["LogName"].Value.ToString()].Add(textInfo.DateTime, (object) textInfo.Content);
                    break;
            }
        }

        public void OnNewGroupUpdate(GroupUpdate groupUpdate)
        {
            // do nothing
        }
    }
}

