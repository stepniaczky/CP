using System;
using System.Drawing;

namespace Data
{
    internal class Ball : DataApi
    {

        private readonly int _radius;
        private Point _center;
        private Point _motionDirection;
        private Random random = new Random();

        public override int Radius { get => _radius; }
        public override Point Center { get => _center; }
        public override Point MotionDirection { get => _motionDirection; set => _motionDirection = value; }

        public Ball(int x, int y, int radius)
        {
            _center = new Point(x, y);
            _radius = radius;
        }

        public override void Move(int width, int height)
        {

            while (!(0 <= (_center.X + _motionDirection.X - _radius) &&
                     width >= (_center.X + _motionDirection.X + _radius) &&
                     0 <= (_center.Y + _motionDirection.Y - _radius) &&
                     height >= (_center.Y + _motionDirection.Y + _radius)))
            {
                _motionDirection = new Point(random.Next(-1, 2), random.Next(-1, 2));
            }

            _center.Offset(_motionDirection);
        }
    }
}
