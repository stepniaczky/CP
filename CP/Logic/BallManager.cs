﻿using System;
using System.Timers;
using System.Collections.Generic;
using System.Drawing;

namespace Logic
{
	internal class BallManager : LogicApi
	{
		private readonly int _width;
		private readonly int _height;
		private readonly int _radius;
		private readonly List<Ball> _balls = new List<Ball>();
		private readonly List<IObserver> _observers = new List<IObserver>();

        public BallManager(int width, int height, int radius)
		{
			_width = width;
			_height = height;
			_radius = radius;
		}

		public override int Width { get => _width; }
		public override int Height { get => _height; }
		public override int Radius { get => _radius; }
		public override List<Ball> Balls { get => _balls; }

		public override void CreateBalls(int amount)
        {
			Random random = new Random();

			for (int i = 0; i < amount; i++)
            {
				Point motionDirection = new Point(random.Next(-2, 3), random.Next(-2, 3));
				int x = random.Next(_radius, _width - _radius);
				int y = random.Next(_radius, _height - _radius);

                Ball ball = new Ball(x, y, _radius)
                {
                    MotionDirection = motionDirection
                };
                _balls.Add(ball);
            }
		}

        public override void ClearBalls()
        {
			Balls.Clear();
			Notify();
        }

		public override void Attach(IObserver observer)
		{
			_observers.Add(observer);
		}

		public override void Detach(IObserver observer)
		{
			_observers.Remove(observer);
		}

		public override void Notify()
		{
			foreach (var observer in _observers)
			{
				observer.Update(this);
			}
		}

		public override void Tick()
		{
			foreach (Ball ball in _balls)
			{
				ball.Move(_width, _height);
				Notify();
			}
		}
	}
}
