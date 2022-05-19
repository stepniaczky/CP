using Logic;
using System.Collections.ObjectModel;

namespace PresentationModel
{
    internal class ModelApi : ModelAbstractApi
    {
        private readonly LogicApi LogicLayer;

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
            return new ObservableCollection<LogicBall>(LogicLayer.LogicBalls);
        }

        public override void ClearBalls()
        {
            LogicLayer.ClearBalls();
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
