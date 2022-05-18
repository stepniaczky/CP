using System;
using System.Drawing;

namespace Data
{
    public abstract class DataApi
    {
        public abstract int Radius { get; }
        public abstract Point Center { get; }
        public abstract Point MotionDirection { get; set; }


        public abstract void Move(int width, int height);
    }
}
