﻿using System.Drawing;

namespace Logic
{
    public class Ball
    {
        private readonly int _radius;
        private Point _center;
        private Point _motionDirection;

        public int Radius { get => _radius; }
        public Point Center { get => _center; }
        public Point MotionDirection { get => _motionDirection; set => _motionDirection = value; }

        public Ball(int x, int y, int radius)
        {
            _center = new Point(x, y);
            _radius = radius;
        }

        public void Move()
        {
            _center.Offset(_motionDirection);
        }
    }
}
