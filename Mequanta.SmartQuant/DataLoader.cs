using SmartQuant;

namespace MequantaStudio.SmartQuant
{
    public class DataLoader
    {
        public PermanentQueue<Event> OrderManagerQueue { get; private set; }

        public PermanentQueue<Event> PortfolioEventQueue { get; private set; }

        public PermanentQueue<Event> PortfolioManagerEventQueue { get; private set; }

        public DataLoader(Framework framework)
        {
            OrderManagerQueue = new PermanentQueue<Event>();
            PortfolioEventQueue = new PermanentQueue<Event>();
            PortfolioManagerEventQueue = new PermanentQueue<Event>();

            framework.EventManager.Dispatcher.ExecutionCommand += (sender, command) =>
            {
                OrderManagerQueue.Enqueue(command); 
            };

            framework.EventManager.Dispatcher.ExecutionReport += (sender, report) =>
            {
                OrderManagerQueue.Enqueue(report);
            };

            framework.EventManager.Dispatcher.OrderManagerCleared += (sender, data) =>
            {
                OrderManagerQueue.Clear();
                OrderManagerQueue.Enqueue(data);
            };

            framework.EventManager.Dispatcher.FrameworkCleared += (sender, args) =>
            {
                PortfolioEventQueue.Clear();
                PortfolioManagerEventQueue.Clear();
                PortfolioEventQueue.Enqueue(new OnFrameworkCleared(args.Framework));
            };

            framework.EventManager.Dispatcher.PositionOpened += (sender, args) =>
            {
                PortfolioEventQueue.Enqueue(new OnPositionOpened(args.Portfolio, args.Position));
            };

            framework.EventManager.Dispatcher.PositionChanged += (sender, args) =>
            {
                PortfolioEventQueue.Enqueue(new OnPositionChanged(args.Portfolio, args.Position));
            };

            framework.EventManager.Dispatcher.PositionClosed += (sender, args) =>
            {
                PortfolioEventQueue.Enqueue(new OnPositionClosed(args.Portfolio, args.Position));
            };

            framework.EventManager.Dispatcher.Fill += (sender, fill) =>
            {
                PortfolioEventQueue.Enqueue(fill);
            };

            framework.EventManager.Dispatcher.Transaction += (object sender, global::SmartQuant.OnTransaction transaction) =>
            {
                PortfolioEventQueue.Enqueue(transaction);
            };

            framework.EventManager.Dispatcher.PortfolioAdded += (sender, args) =>
            {
                PortfolioManagerEventQueue.Enqueue(new OnPortfolioAdded(args.Portfolio));
            };

            framework.EventManager.Dispatcher.PortfolioDeleted += (sender, args) =>
            {
                PortfolioManagerEventQueue.Enqueue(new OnPortfolioDeleted(args.Portfolio));
            };

            framework.EventManager.Dispatcher.PortfolioParentChanged += (sender, args) =>
            {
                PortfolioManagerEventQueue.Enqueue(new OnPortfolioParentChanged(args.Portfolio));
            };
        }
    }
}
