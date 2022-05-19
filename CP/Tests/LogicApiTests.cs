using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Drawing;
using Data;

namespace Tests;

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

        foreach (DataApi ball in testBallManager.Balls)
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
        Assert.AreEqual(testBallManager.LogicBalls.Count, testBallCount);
    }

    [TestMethod]
    public void TestClearBalls()
    {
        testBallManager.ClearBalls();

        Assert.AreEqual(testBallManager.Balls.Count, 0);

        testBallManager.CreateBalls(2);
        testBallManager.ClearBalls();

        Assert.AreEqual(testBallManager.Balls.Count, 0);
        Assert.AreEqual(testBallManager.LogicBalls.Count, 0);
    }

    [TestMethod]
    public void TestCheckEdgeCollision()
    {
        Point testDirection = new(1, 0);
        DataApi testBall = DataApi.CreateBall(testWidth - testRadius, 100, testRadius, 1);

        testBall.MotionDirection = testDirection;
        testBallManager.CheckEdgeCollisions(testBall);
        testBall.Move();

        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X - testRadius >= 0);
        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X + testRadius <= testWidth);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y - testRadius >= 0);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y + testRadius <= testHeight);
    }

    [TestMethod]
    public void TestCheckBallCollision()
    {
        Point testDirection = new(1, 0);
        DataApi testBall = DataApi.CreateBall(testWidth - testRadius, 100, testRadius, 1);

        testBall.MotionDirection = testDirection;
        testBallManager.CheckEdgeCollisions(testBall);
        testBall.Move();

        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X - testRadius >= 0);
        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X + testRadius <= testWidth);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y - testRadius >= 0);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y + testRadius <= testHeight);
    }
}
