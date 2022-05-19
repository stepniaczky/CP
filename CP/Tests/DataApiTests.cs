using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Tests
{
    [TestClass]
    public class BallTests
    {
        static readonly int testX = 10;
        static readonly int testY = 7;
        static readonly int testRadius = 2;
        static readonly int testMass = 2;
        readonly DataApi testBall = DataApi.CreateBall(testX, testY, testRadius, testMass);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(testX, testBall.Center.X);
            Assert.AreEqual(testY, testBall.Center.Y);
            Assert.AreEqual(testRadius, testBall.Radius);
            Assert.AreEqual(testMass, testBall.Mass);
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
            Point testDirection = new(1, -1);
            testBall.MotionDirection = testDirection;
            testBall.Move();

            Assert.AreEqual(testX + testDirection.X, testBall.Center.X);
            Assert.AreEqual(testY + testDirection.Y, testBall.Center.Y);
        }
    }
}
