using System.Collections.Generic;

namespace Logic
{
    public interface ISubject
    {
        List<LogicBall> LogicBalls { get; }

        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}
