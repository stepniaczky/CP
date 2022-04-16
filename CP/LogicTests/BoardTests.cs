using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace LogicTests
{
	[TestClass]
	public class BoardTests
	{
		static int testLeftBound = 0;
		static int testRightBound = 100;
		static int testTopBound = 80;
		static int testBottomBound = 0;

		Board testBoard = new Board(testLeftBound, testRightBound, testBottomBound, testTopBound);

		[TestMethod]
		public void TestConstructor()
		{
			Assert.AreEqual(testBoard.LeftBound, testLeftBound);
			Assert.AreEqual(testBoard.RightBound, testRightBound);
			Assert.AreEqual(testBoard.BottomBound, testBottomBound);
			Assert.AreEqual(testBoard.TopBound, testTopBound);
		}

		[TestMethod]
		public void TestAddBall()
        {
			Assert.AreEqual(testBoard.Balls.Count, 0);
			testBoard.AddBall();
			Assert.AreEqual(testBoard.Balls.Count, 1);
		}

		[TestMethod]
		public void TestSetRandomMotionDirection()
		{
			testBoard.AddBall();
			Assert.AreEqual(testBoard.Balls[0].MotionDirection.X, 0);
			Assert.AreEqual(testBoard.Balls[0].MotionDirection.Y, 0);

			testBoard.SetRandomMotionDirection(testBoard.Balls[0]);

			Assert.IsTrue(-1 <= testBoard.Balls[0].MotionDirection.X && testBoard.Balls[0].MotionDirection.X <= 1);
			Assert.IsTrue(-1 <= testBoard.Balls[0].MotionDirection.Y && testBoard.Balls[0].MotionDirection.Y <= 1);
		}
	}
}

