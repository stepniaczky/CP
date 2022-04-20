using System.Drawing;
using System;

namespace Logic
{
    public abstract class LogicApi
    {
        public abstract int Radius { get; }
        public abstract Point Center { get; }
        public abstract Point MotionDirection { get; set; }

        public abstract void Move(int leftBound, int rightBound, int bottomBound, int topBound);


        public static LogicApi CreateApi(int x, int y, int radius)
        {
            return new Ball(x, y, radius);
        }

        internal class Ball : LogicApi
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

            public override void Move(int leftBound, int rightBound, int bottomBound, int topBound)
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
}
