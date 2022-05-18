using Logic;
using System.Collections.ObjectModel;

namespace PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }

        public abstract ObservableCollection<LogicBall> CreateBalls(int ballsNumber);

        public abstract void ClearBalls();

        public abstract void Start();
        public abstract void Stop();

        public abstract void AttachObserver(IObserver observer);
        public abstract void RemoveObserver(IObserver observer);
    }
}

