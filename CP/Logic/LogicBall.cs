using System.Drawing;

namespace Logic
{
    public class LogicBall
    {
        private readonly int _radius;
        private Point _center;

        public int Radius { get => _radius; }
        public Point Center { get => _center; set => _center = value; }

        public LogicBall(int x, int y, int radius)
        {
            _center = new Point(x, y);
            _radius = radius;
        }
    }
}
