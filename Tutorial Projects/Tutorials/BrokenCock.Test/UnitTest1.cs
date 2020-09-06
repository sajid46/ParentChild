using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrokenCock.Test
{
    [TestClass]
    public class BrokenClockTests
    {
        [TestMethod]
        public void BrokenClock_HowManyTimesTimeisEqualtoWorkingClock_NosOfTimes_()
        {
            //Arrang
            var broken = new BrokenClock();

            //Act
            int no=broken.No_TimeIsSame();

            //Assert
            Assert.AreEqual(2,no);
        }
    }
}
