using System;
using System.Drawing;

namespace Logic
{
    public class Ball
    {
        private Point _center;
        private readonly int _radius;

        public Ball(int x, int y, int radius)
        {
            _center = new Point(x, y);
            _radius = radius;
        }

        public void Move(int xOffset, int yOffset)
        {
            _center.Offset(new Point(xOffset, yOffset));
        }

        public int Radius { get => _radius; }

        public Point Center { get => _center; } 
    }
}
