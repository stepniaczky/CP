using System;
using System.Drawing;

namespace Data
{
    public abstract class DataApi
    {
        public abstract int Radius { get; }
        public abstract Point Center { get; }
        public abstract Point MotionDirection { get; set; }

        public static DataApi CreateBall(int x, int y, int radius)
        {
            return new Ball(x, y, radius);
        }

        public abstract void Move();
    }
}
