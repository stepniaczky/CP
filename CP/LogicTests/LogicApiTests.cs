using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;
using System.Drawing;

namespace LogicTests;

[TestClass]
public class BallManagerTests
{
    static int testWidth = 1920;
    static int testHeight = 1080;
    static int testRadius = testHeight / 14;
    LogicApi testBallManager = LogicApi.CreateApi(testWidth, testHeight, testRadius);

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

        List<Point> points = testBallManager.GetBalls();

        Assert.AreEqual(points.Count, testBallCount);
    }
}
