using System;
using Xunit;
using project1;

namespace testProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            float result = Class1.Add(3, 4);
            Assert.Equal<float>(7, result);
        }
    }
}
