using System;

namespace Logic
{
    public class Ball
    {
        private int x;
        private int y;
        private int radius;

        public Ball(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public int Radius { get => radius; set => radius = value; }

        public int Y { get => y; set => y = value; }

        public int X { get => x; set => x = value; }
    }
}
