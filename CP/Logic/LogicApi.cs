using System.Drawing;
using System;
using System.Collections.Generic;
using Data;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract List<DataApi> Balls { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract int Radius { get; }

        public static LogicApi CreateApi(int width, int height, int radius) 
        {
            return new BallManager(width, height, radius);
        }

        public abstract void CreateBalls(int amount);
    }
}
