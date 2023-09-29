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
        public void FactTest()
        {
            var result = Factorial.Fact(10);
            Assert.AreEqual(result, 3628800);

        }
        [TestMethod()]
        public void NotFactTest()
        {
            var result = Factorial.NotFact(10);
            Assert.AreEqual(result, 3628800);
        }
    }
}