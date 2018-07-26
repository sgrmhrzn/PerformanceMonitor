using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeekFive;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        Monitor monitor = new Monitor();

        [TestMethod]
        public void TestCPUUsageNotNull()
        {
            var result = monitor.getCpuUsage();
            Assert.IsNotNull(result);
        }

        public void TestRAMUsageNotNull()
        {
            var result = monitor.getAvailableRAM();
            Assert.IsNotNull(result);
        }
    }
}
