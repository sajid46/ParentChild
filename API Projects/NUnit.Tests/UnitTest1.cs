using System;
using NUnit.Framework;
namespace Tests
{
    public class Tests
    {
        AllMaths allMaths = new AllMaths();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_AddTwoNumbers()
        {

            double result = allMaths.AddTwoNumbers(3.5, 4.5);

            //Assert.AreEqual(8, result);
        }

        [Test]
        public void Test_MultiplyTwoNumber()
        {
            
            var result = allMaths.MultiplyTwoNumbers(3.5, 2.5);

            Assert.AreEqual(8.75, result);
        }

        [Test]
        public void Test_DivideTwoNumber()
        {

            double result = allMaths.DivideTwoNumbers(3.5, 2.5);

            Assert.AreEqual(1.4, result);
        }
    }
}