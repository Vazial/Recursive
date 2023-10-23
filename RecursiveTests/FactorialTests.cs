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
    public class FactorialTests
    {
        [TestMethod()]
        public void LoopTest()
        {
            var result = new Factorial1().Calc(10);
            Assert.AreEqual(result, 3628800);
            result = new Factorial1().Calc(0);
            Assert.AreEqual(result, 1);

        }
        [TestMethod()]
        public void RecTest()
        {
            var result = new Factorial2().Calc(10);
            Assert.AreEqual(result, 3628800);
            result = new Factorial2().Calc(0);
            Assert.AreEqual(result, 1);

        }
    }
}