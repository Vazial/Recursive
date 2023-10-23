using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recursive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive.Tests
{
    [TestClass()]
    public class IntegralTests
    {
        [TestMethod()]
        public void LoopTest()
        {
            var result = new Integral1().Calc(0, 1, 0.0001);
            Assert.AreEqual(Math.Round(result, 3), 0.333);
        }

        [TestMethod()]
        public void RecTest()
        {
            var result = new Integral2().Calc(0, 1, 0.0001);
            Assert.AreEqual(Math.Round(result, 3), 0.333);
        }
    }
}