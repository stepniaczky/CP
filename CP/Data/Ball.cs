using System.Drawing;

namespace Data
{
    public class Ball : DataApi
    {
        private readonly int _radius;
        private Point _center;
        private Point _motionDirection;

        public override int Radius { get => _radius; }
        public override Point Center { get => _center; }
        public override Point MotionDirection { get => _motionDirection; set => _motionDirection = value; }

        public Ball(int x, int y, int radius)
        {
            _center = new Point(x, y);
            _radius = radius;
        }

        public override void Move()
        {
            _center.Offset(_motionDirection);
        }
    }
}
