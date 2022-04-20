using System.Drawing;
using System;

namespace Logic
{
    public class Ball
    {
        private readonly int _radius;
        private Point _center;
        private Point _motionDirection;
        private Random random = new Random();

        public int Radius { get => _radius; }
        public Point Center { get => _center; }
        public Point MotionDirection { get => _motionDirection; set => _motionDirection = value; }

        public Ball(int x, int y, int radius)
        {
            _center = new Point(x, y);
            _radius = radius;
        }

        public void Move(int leftBound, int rightBound, int bottomBound, int topBound)
        {

            while (!(leftBound <= (_center.X + _motionDirection.X - _radius) &&
                         rightBound >= (_center.X + _motionDirection.X + _radius) &&
                         bottomBound <= (_center.Y + _motionDirection.Y - _radius) &&
                         topBound >= (_center.Y + _motionDirection.Y + _radius)))
            {
                _motionDirection = new Point(random.Next(-1, 2), random.Next(-1, 2));
            }

            _center.Offset(_motionDirection);
        }
    }
}
