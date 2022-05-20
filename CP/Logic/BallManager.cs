using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Data;

namespace Logic
{
	internal class BallManager : LogicApi
	{
		private readonly int _width;
		private readonly int _height;
		private readonly int _radius;
		private readonly int _mass = 1;
		private readonly int _maxSpeed = 2;
		private readonly List<DataApi> _balls = new List<DataApi>();
		private readonly List<LogicBall> _logicBalls = new List<LogicBall>();
		private readonly List<Thread> _threads = new List<Thread>();
		private readonly List<IObserver> _observers = new List<IObserver>();
		private object _collideBalls = new object();

		public BallManager(int width, int height, int radius)
		{
			_width = width;
			_height = height;
			_radius = radius;
		}

		public override int Width { get => _width; }
		public override int Height { get => _height; }
		public override int Radius { get => _radius; }
		public override List<DataApi> Balls { get => _balls; }
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

				if (_balls.Count > 0 )
                {
					bool invalidPosition = true;
					while (invalidPosition)
					{
						invalidPosition = false;
						x = random.Next(_radius, _width - _radius);
						y = random.Next(_radius, _height - _radius);
						foreach (DataApi otherBall in _balls)
						{
							double distance = Math.Sqrt(Math.Pow((otherBall.Center.X - x), 2) +
												Math.Pow((otherBall.Center.Y - y), 2));
							if (distance <= _radius + otherBall.Radius)
							{
								invalidPosition = true;
							}
						}
					}
				}

				DataApi ball = DataApi.CreateBall(x, y, _radius, _mass);
				ball.MotionDirection = motionDirection;

                _balls.Add(ball);
				_logicBalls.Add(new LogicBall(x, y, _radius));

            }

			CreateThreads();
		}

		private void CreateThreads()
        {
			foreach (DataApi ball in _balls)
            {
				Thread thread = new Thread(() =>
				{
					while (_balls.Count != 0)
                    {
						
						CheckEdgeCollisions(ball);
						CheckBallCollisions(ball);
						ball.Move();
						UpdatCorrespondingLogicBall(ball);
						Thread.Sleep(15);
                    }
				});

				_threads.Add(thread);
			}

			foreach (var thread in _threads)
			{
				thread.Start();
			}
		}
        

		public override void CheckEdgeCollisions(DataApi ball)
        {
			if (0 > (ball.Center.X + ball.MotionDirection.X - ball.Radius) ||
				_width < (ball.Center.X + ball.MotionDirection.X + ball.Radius))
			{
				ball.MotionDirection = new Point(-ball.MotionDirection.X, ball.MotionDirection.Y);
			}

			if (0 > (ball.Center.Y + ball.MotionDirection.Y - ball.Radius) ||
				_height < (ball.Center.Y + ball.MotionDirection.Y + ball.Radius))
			{
				ball.MotionDirection = new Point(ball.MotionDirection.X, -ball.MotionDirection.Y);
			}
		}

		public override void CheckBallCollisions(DataApi ball)
		{

			List<DataApi> collidingBalls = new List<DataApi>();
			foreach (DataApi otherBall in _balls)
			{
				if (!otherBall.Equals(ball))
				{
					double distance = Math.Sqrt(Math.Pow((ball.Center.X + ball.MotionDirection.X - (otherBall.Center.X + otherBall.MotionDirection.X)), 2) +
												Math.Pow((ball.Center.Y + ball.MotionDirection.Y - (otherBall.Center.Y + otherBall.MotionDirection.Y)), 2));

					if ((distance <= ball.Radius + otherBall.Radius))
					{
						collidingBalls.Add(otherBall);
					}
				}
			}

			
			foreach (DataApi otherBall in collidingBalls)
			{
				double ballXVelocity = (ball.MotionDirection.X * (ball.Mass - otherBall.Mass) / (ball.Mass + otherBall.Mass) +
										(2 * otherBall.Mass * otherBall.MotionDirection.X) / (ball.Mass + otherBall.Mass));
				double ballYVelocity = (ball.MotionDirection.Y * (ball.Mass - otherBall.Mass) / (ball.Mass + otherBall.Mass) +
										(2 * otherBall.Mass * otherBall.MotionDirection.Y) / (ball.Mass + otherBall.Mass));

				double otherBallXVelocity = (otherBall.MotionDirection.X * (otherBall.Mass - ball.Mass) / (ball.Mass + otherBall.Mass) +
											(2 * ball.Mass * ball.MotionDirection.X) / (ball.Mass + otherBall.Mass));
				double otherBallYVelocity = (otherBall.MotionDirection.Y * (otherBall.Mass - ball.Mass) / (ball.Mass + otherBall.Mass) +
											(2 * ball.Mass * ball.MotionDirection.Y) / (ball.Mass + otherBall.Mass));
				lock (_collideBalls)
				{
					ball.MotionDirection = new Point((int)ballXVelocity, (int)ballYVelocity);
					otherBall.MotionDirection = new Point((int)otherBallXVelocity, (int)otherBallYVelocity);
				}
			}
		}

		public override void ClearBalls()
        {
			_threads.Clear();
			_balls.Clear();
			_logicBalls.Clear();
			
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

		private void UpdatCorrespondingLogicBall(DataApi ball)
        {
			int index = _balls.IndexOf(ball);
			_logicBalls[index].Center = ball.Center;
			Notify();
		}
	}
}
