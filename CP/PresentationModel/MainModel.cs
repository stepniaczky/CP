using Logic;
using System.Collections.ObjectModel;
using System.Timers;

namespace PresentationModel
{
    internal class ModelApi : ModelAbstractApi
    {
        private readonly LogicApi LogicLayer;
        private Timer _timer;

        public ModelApi() : this(LogicApi.CreateApi(768, 460, 20))
        {
        }

        public ModelApi(LogicApi logicApi)
        {
            LogicLayer = logicApi ?? LogicApi.CreateApi(768, 460, 20);
        }

        public override ObservableCollection<LogicBall> CreateBalls(int ballsNumber)
        {
            LogicLayer.CreateBalls(ballsNumber);
            Start();
            return new ObservableCollection<LogicBall>(LogicLayer.LogicBalls);
        }

        public override void ClearBalls()
        {
            Stop();
            LogicLayer.ClearBalls();
        }

        public override void Start()
        {
            _timer = new Timer();
            _timer.Interval = 16;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        public override void Stop()
        {
            _timer.Dispose();
        }

        private void OnTimerElapsed(object source, ElapsedEventArgs e)
        {
            LogicLayer.Tick();
        }

        public override void AttachObserver(IObserver observer)
        {
            LogicLayer.Attach(observer);
        }

        public override void RemoveObserver(IObserver observer)
        {
            LogicLayer.Detach(observer);
        }
    }
}
