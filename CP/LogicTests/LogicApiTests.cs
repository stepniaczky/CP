using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Drawing;

namespace LogicTests;

[TestClass]
public class BallTests
{
    static readonly int testX = 10;
    static readonly int testY = 7;
    static readonly int testRadius = 2;
    readonly Ball testBall = new(testX, testY, testRadius);

    [TestMethod]
    public void TestConstructor()
    {
        Assert.AreEqual(testX, testBall.Center.X);
        Assert.AreEqual(testY, testBall.Center.Y);
        Assert.AreEqual(testRadius, testBall.Radius);
    }

    [TestMethod]
    public void TestMoveDirectionNotSet()
    {
        testBall.Move(100, 100);

        Assert.AreEqual(testX, testBall.Center.X);
        Assert.AreEqual(testY, testBall.Center.Y);
    }

    [TestMethod]
    public void TestMoveDirectionSet()
    {
        Point testDirection = new(1, 0);
        testBall.MotionDirection = testDirection;
        testBall.Move(100, 100);

        Assert.AreEqual(testX + testDirection.X, testBall.Center.X);
        Assert.AreEqual(testY + testDirection.Y, testBall.Center.Y);
    }

    [TestMethod]
    public void TestMoveBallOutOfBounds()
    {

        int testWidth = testX + testRadius;
        int testHeight = 100;
        Point testDirection = new (1, 0);

        testBall.MotionDirection = testDirection;
        testBall.Move(testWidth, testHeight);

        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X - testRadius >= 0);
        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X + testRadius <= testWidth);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y - testRadius >= 0);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y + testRadius <= testHeight);
    }
}


[TestClass]
public class BallManagerTests
{
    static readonly int testWidth = 1920;
    static readonly int testHeight = 1080;
    static readonly int testRadius = testHeight / 14;
    readonly LogicApi testBallManager = LogicApi.CreateApi(testWidth, testHeight, testRadius);

    [TestMethod]
    public void TestConstructor()
    {
        Assert.AreEqual(testWidth, testBallManager.Width);
        Assert.AreEqual(testHeight, testBallManager.Height);
        Assert.AreEqual(testRadius, testBallManager.Radius);
        Assert.AreEqual(testBallManager.Balls.Count, 0);
    }

    [TestMethod]
    public void TestCreateBalls()
    {
        int testBallCount = 2;
        testBallManager.CreateBalls(testBallCount);

        Assert.AreEqual(testBallManager.Balls.Count, testBallCount);

        foreach (Ball ball in testBallManager.Balls)
        {
            Assert.IsTrue(ball.Center.X - testRadius >= 0);
            Assert.IsTrue(ball.Center.X + testRadius <= testWidth);
            Assert.IsTrue(ball.Center.Y - testRadius >= 0);
            Assert.IsTrue(ball.Center.Y + testRadius <= testHeight);
            Assert.IsTrue(ball.MotionDirection.X <= testBallManager.MaxSpeed);
            Assert.IsTrue(ball.MotionDirection.X >= -testBallManager.MaxSpeed);
            Assert.IsTrue(ball.MotionDirection.Y <= testBallManager.MaxSpeed);
            Assert.IsTrue(ball.MotionDirection.Y >= -testBallManager.MaxSpeed);
        }
    }

    [TestMethod]
    public void TestClearBalls()
    {
        testBallManager.ClearBalls();

        Assert.AreEqual(testBallManager.Balls.Count, 0);

        testBallManager.CreateBalls(2);
        testBallManager.ClearBalls();

        Assert.AreEqual(testBallManager.Balls.Count, 0);
    }

}
