using System;
using System.Drawing;

namespace Logic
{
    public class Ball
    {
        private Point center;
        private int radius;

        public Ball(int x, int y, int radius)
        {
            this.center = new Point(x, y);
            this.radius = radius;
        }

        public void Move(int xOffset, int yOffset)
        {
            center.Offset(new Point(xOffset, yOffset));
        }

        public int Radius { get => radius; set => radius = value; }

        public Point Center { get => center; }
    }
}
