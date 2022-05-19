using System.ComponentModel;
using System.Drawing;

namespace Data
{
    internal class Ball : DataApi
    {
        private readonly int _radius;
        private int _mass;
        private Point _center;
        private Point _motionDirection;
        

        public override int Radius { get => _radius; }
        public override int Mass { get => _mass; }
        public override Point Center { get => _center; }
        public override Point MotionDirection { get => _motionDirection; set => _motionDirection = value; }

        public Ball(int x, int y, int radius, int mass)
        {
            _center = new Point(x, y);
            _radius = radius;
            _mass = mass;
        }

        public override event PropertyChangedEventHandler PropertyChanged;

        public override void Move()
        {
            _center.Offset(_motionDirection);
        }
    }
}
