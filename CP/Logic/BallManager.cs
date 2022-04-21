using System;
using System.Collections.Generic;
using Data;
using System.Drawing;

namespace Logic
{
	internal class BallManager : LogicApi
	{
		private readonly int _width;
		private readonly int _height;
		private readonly int _radius;
		private List<DataApi> _balls = new List<DataApi>();

        public override int Width { get => _width; }
		public override int Height { get => _height; }
		public override int Radius { get => _radius; }
		public override List<DataApi> Balls { get => _balls; }
		

        public BallManager(int width, int height, int radius)
		{
			_width = width;
			_height = height;
			_radius = radius;
		}

		public override void CreateBalls(int amount)
        {
			Random random = new Random();

			for (int i = 0; i < amount; i++)
            {
				Point motionDirection = new Point(random.Next(-1, 2), random.Next(-1, 2));
				int x = random.Next(_radius, _width - _radius);
				int y = random.Next(_radius, _height - _radius);

				DataApi ball = DataApi.CreateBall(x, y, _radius);
				ball.MotionDirection = motionDirection;
				_balls.Add(ball);
            }
        }
	}
}
