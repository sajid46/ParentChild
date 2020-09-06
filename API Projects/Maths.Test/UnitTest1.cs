using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Maths.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            MathsAll m = new MathsAll();

            //Act
            double result = m.AddTwoNumbers(3.4, 4.5);

            //Assert
            Assert.AreEqual(8, result);


        }
    }

    internal class MathsAll
    {
        public MathsAll()
        {
        }

        internal double AddTwoNumbers(double v1, double v2)
        {
            return v1 + v2;
        }
    }
}
