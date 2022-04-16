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
        testBall.Move();

        Assert.AreEqual(testX, testBall.Center.X);
        Assert.AreEqual(testY, testBall.Center.Y);
    }

    [TestMethod]
    public void TestMoveDirectionSet()
    {
        Point testDirection = new Point(5, 7);
        testBall.MotionDirection = testDirection;
        testBall.Move();

        Assert.AreEqual(testX + testDirection.X, testBall.Center.X);
        Assert.AreEqual(testY + testDirection.Y, testBall.Center.Y);
    }
}
