using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;
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
        int testHorizontalDirection = 1;
        int testVerticalDirection = 1;
        Point testDirection = new(testHorizontalDirection, testVerticalDirection);

        testBall.MotionDirection = testDirection;
        testBall.Move(testWidth, testHeight);

        Assert.AreEqual(testBall.MotionDirection.X, -testHorizontalDirection);
        Assert.AreEqual(testBall.MotionDirection.Y, testVerticalDirection);

        Assert.AreEqual(testBall.Center.X, testX - testHorizontalDirection);
        Assert.AreEqual(testBall.Center.Y, testY + testVerticalDirection);
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

        Assert.IsTrue(testBallManager.Balls[0].Center.X - testRadius >= 0);
        Assert.IsTrue(testBallManager.Balls[0].Center.X + testRadius <= testWidth);
        Assert.IsTrue(testBallManager.Balls[0].Center.Y - testRadius >= 0);
        Assert.IsTrue(testBallManager.Balls[0].Center.Y + testRadius <= testHeight);
        Assert.IsTrue(testBallManager.Balls[0].MotionDirection.X <= 1);
        Assert.IsTrue(testBallManager.Balls[0].MotionDirection.X >= -1);
        Assert.IsTrue(testBallManager.Balls[0].MotionDirection.Y <= 1);
        Assert.IsTrue(testBallManager.Balls[0].MotionDirection.Y >= -1);


        Assert.IsTrue(testBallManager.Balls[1].Center.X - testRadius >= 0);
        Assert.IsTrue(testBallManager.Balls[1].Center.X + testRadius <= testWidth);
        Assert.IsTrue(testBallManager.Balls[1].Center.Y - testRadius >= 0);
        Assert.IsTrue(testBallManager.Balls[1].Center.Y + testRadius <= testHeight);
        Assert.IsTrue(testBallManager.Balls[1].MotionDirection.X <= 1);
        Assert.IsTrue(testBallManager.Balls[1].MotionDirection.X >= -1);
        Assert.IsTrue(testBallManager.Balls[1].MotionDirection.Y <= 1);
        Assert.IsTrue(testBallManager.Balls[1].MotionDirection.Y >= -1);
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

    [TestMethod]
    public void TestGetBalls()
    {
        int testBallCount = 2;
        testBallManager.CreateBalls(testBallCount);

        List<Ball> points = testBallManager.GetBalls();

        Assert.AreEqual(points.Count, testBallCount);
    }
}
