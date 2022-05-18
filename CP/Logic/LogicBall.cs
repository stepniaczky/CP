using System.Drawing;

namespace Logic
{
    public class LogicBall
    {
        private readonly int _radius;
        private Point _center;
        private Point _motionDirection;

        public int Radius { get => _radius; }
        public Point Center { get => _center; }
        public Point MotionDirection { get => _motionDirection; }

        public LogicBall(int x, int y, int radius)
        {
            _center = new Point(x, y);
            _radius = radius;
        }
    }
}
