using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Drawing;

namespace LogicTests;

[TestClass]
public class BallTests
{
    static int testX = 10;
    static int testY = 7;
    static int testRadius = 2;
    Ball testBall = new Ball(testX, testY, testRadius);

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
        testBall.Move(0,100,0,100);

        Assert.AreEqual(testX, testBall.Center.X);
        Assert.AreEqual(testY, testBall.Center.Y);
    }

    [TestMethod]
    public void TestMoveDirectionSet()
    {
        Point testDirection = new Point(1, 0);
        testBall.MotionDirection = testDirection;
        testBall.Move(0,100,0,100);

        Assert.AreEqual(testX + testDirection.X, testBall.Center.X);
        Assert.AreEqual(testY + testDirection.Y, testBall.Center.Y);
    }

    [TestMethod]
    public void TestMoveBallOutOfBounds()
    {
        int testLeftBound = 0;
        int testRightBound = testX + testRadius;
        int testBottomBound = 0;
        int testTopBound = 100;
        Point testDirection = new Point(1, 0);

        testBall.MotionDirection = testDirection;
        testBall.Move(testLeftBound, testRightBound, testBottomBound, testTopBound);

        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X - testRadius >= testLeftBound);
        Assert.IsTrue(testBall.Center.X + testBall.MotionDirection.X + testRadius <= testRightBound);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y - testRadius >= testBottomBound);
        Assert.IsTrue(testBall.Center.Y + testBall.MotionDirection.Y + testRadius <= testTopBound);
    }
}
