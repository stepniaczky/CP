using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            float result = Class1.Add(3, 4);
            Assert.AreEqual(7, result);
        }
    }
}