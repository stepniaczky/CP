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
        Point testDirection = new Point(1, 0);

        testBall.MotionDirection = testDirection;
        testBall.Move(testWidth, testHeight);

        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X - testRadius >= 0);
        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X + testRadius <= testWidth);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y - testRadius >= 0);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y + testRadius <= testHeight);
    }
}
