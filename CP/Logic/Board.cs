using System;
using System.Collections.Generic;
using System.Drawing;

namespace Logic
{
	public class Board
	{
        private readonly int _leftBound;
		private readonly int _rightBound;
		private readonly int _bottomBound;
		private readonly int _topBound;
		private List<Ball> _balls = new List<Ball>();
        private Random random = new Random();

        public int LeftBound { get => _leftBound; }
		public int RightBound { get => _rightBound; }
        public int BottomBound { get => _bottomBound; }
		public int TopBound { get => _topBound; }
        public List<Ball> Balls { get => _balls; }

        public Board(int leftBound, int rightBound, int bottomBound, int topBound)
        {
            _leftBound = leftBound;
            _rightBound = rightBound;
            _bottomBound = bottomBound;
            _topBound = topBound;
        }

        public void AddBall()
        {
            int _ballRadius = 1;
            int x = random.Next(_leftBound, _rightBound);
            int y = random.Next(_bottomBound, _topBound);
            _balls.Add(new Ball(x, y, _ballRadius));
        }

        public void SetRandomMotionDirection(Ball ball)
        {
            ball.MotionDirection = new Point(random.Next(-1, 2), random.Next(-1, 2));
        }

        public void UpdateBoard()
        {
            //TODO
        }


	}
}

