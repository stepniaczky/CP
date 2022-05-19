﻿using System.Collections.Generic;
using System.Threading;
using Data;

namespace Logic
{
    public abstract class LogicApi : ISubject
    {
        public static LogicApi CreateApi(int width, int height, int radius)
        {
            return new BallManager(width, height, radius);
        }

        public abstract List<DataApi> Balls { get; }
        public abstract List<LogicBall> LogicBalls { get; }
        public abstract List<Thread> Threads { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract int Radius { get; }
        public abstract int MaxSpeed { get; }

       

        public abstract void CreateBalls(int amount);

        public abstract void ClearBalls();

        public abstract void Attach(IObserver observer);

        public abstract void Detach(IObserver observer);

        public abstract void Notify();

    }
}
