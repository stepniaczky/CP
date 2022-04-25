using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Drawing;

namespace Tests;

[TestClass]
public class BallTests
{
    static int testX = 10;
    static int testY = 7;
    static int testRadius = 2;
    DataApi testBall = DataApi.CreateBall(testX, testY, testRadius);

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
        Point testDirection = new Point(1, 0);
        testBall.MotionDirection = testDirection;
        testBall.Move(100, 100);

        Assert.AreEqual(testX + testDirection.X, testBall.Center.X);
        Assert.AreEqual(testY + testDirection.Y, testBall.Center.Y);
    }

    [TestMethod]
    public void TestMoveBallOutOfBounds()
    {
        
        int testWidth= testX + testRadius;
        int testHeight = 100;
        int testHorizontalDirection = 1;
        int testVerticalDirection = 1;
        Point testDirection = new Point(testHorizontalDirection, testVerticalDirection);

        testBall.MotionDirection = testDirection;
        testBall.Move(testWidth, testHeight);

        Assert.AreEqual(testBall.MotionDirection.X, -testHorizontalDirection);
        Assert.AreEqual(testBall.MotionDirection.Y, testVerticalDirection);

        Assert.AreEqual(testBall.Center.X, testX - testHorizontalDirection);
        Assert.AreEqual(testBall.Center.Y, testY + testVerticalDirection);
    }
}
