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
        public void EucTest()
        {
            var result = Euclid.Euc(12345678, 432);
            Assert.AreEqual(result, 18);
        }
        [TestMethod()]
        public void NotEucTest()
        {
            var result = Euclid.NotEuc(12345678, 432);
            Assert.AreEqual(result, 18);
        }

    }
}