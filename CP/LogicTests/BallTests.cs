using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

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
    public void TestMove()
    {
        int testXOffset = 5;
        int testYOffset = 7;

        testBall.Move(testXOffset, testYOffset);

        Assert.AreEqual(testX + testXOffset, testBall.Center.X);
        Assert.AreEqual(testY + testYOffset, testBall.Center.Y);
    }
}
