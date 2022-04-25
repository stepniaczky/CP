using System.Drawing;
using System.Timers;
using System.Collections.Generic;
using Data;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract List<Ball> Balls { get; }
        public abstract Timer Timer { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract int Radius { get; }

        public static LogicApi CreateApi(int width, int height, int radius) 
        {
            return new BallManager(width, height, radius);
        }

        public abstract void CreateBalls(int amount);

        public abstract void ClearBalls();

        public abstract List<Ball> GetBalls();

        public abstract void Start();

        public abstract void Stop();


    }
}
