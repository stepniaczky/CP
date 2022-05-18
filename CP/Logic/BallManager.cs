using System;
using System.Collections.Generic;
using System.Drawing;
using Data;

namespace Logic
{
	internal class BallManager : LogicApi
	{
		private readonly int _width;
		private readonly int _height;
		private readonly int _radius;
		private readonly int _maxSpeed = 2;
		private readonly List<Ball> _balls = new List<Ball>();
		private readonly List<LogicBall> _logicBalls = new List<LogicBall>();
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
		public override List<LogicBall> LogicBalls { get => _logicBalls; }
		public override int MaxSpeed { get => _maxSpeed; }

        

        public override void CreateBalls(int amount)
        {
			Random random = new Random();

			for (int i = 0; i < amount; i++)
            {
				int speedHorizontal = 0;
				int speedVertical = 0;
				while (speedHorizontal == 0 && speedVertical == 0)
                {
					speedHorizontal = random.Next(-_maxSpeed, _maxSpeed + 1);
					speedVertical = random.Next(-_maxSpeed, _maxSpeed + 1);

				}
				Point motionDirection = new Point(speedHorizontal, speedVertical);
				int x = random.Next(_radius, _width - _radius);
				int y = random.Next(_radius, _height - _radius);

                Ball ball = new Ball(x, y, _radius)
                {
                    MotionDirection = motionDirection
                };
                _balls.Add(ball);

				_logicBalls.Add(new LogicBall(x, y, _radius));
            }
		}

        public override void ClearBalls()
        {
			Balls.Clear();
			LogicBalls.Clear();
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
			for (int i = 0; i < _balls.Count; i++)
			{
				_balls[i].Move(_width, _height);
				_logicBalls[i].Center = _balls[i].Center;
				Notify();
			}
		}
	}
}
