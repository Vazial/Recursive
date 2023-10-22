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
    public class EuclidTests
    {
        [TestMethod()]
        public void LoopTest()
        {
            var result = new Euclid1().Calc(12345678, 432);
            Assert.AreEqual(result, 18);
        }

        [TestMethod()]
        public void RecTest()
        {
            var result = new Euclid2().Calc(12345678, 432);
            Assert.AreEqual(result, 18);
        }
    }
}