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
    public class FibonacciTests
    {
        public readonly int[] fibNumbers = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155 };
        [TestMethod()]
        public void NotFibTest()
        {
            var max = 30;
            var nums = new decimal[max];
            Array.Copy(Fibonacci.Source, nums, Fibonacci.Source.Length);
            var result = Fibonacci.NotFib(nums, max, Fibonacci.Source.Length);
            for (int ii = 0; ii < result.Length; ii++)
            {
                Assert.AreEqual(result[ii], fibNumbers[ii]);
            }
        }

        [TestMethod()]
        public void FibTest()
        {
            var max = 30;
            var nums = new decimal[max];
            Array.Copy(Fibonacci.Source, nums, Fibonacci.Source.Length);
            var result = Fibonacci.Fib(nums, max, Fibonacci.Source.Length);
            for (int ii = 0; ii < result.Length; ii++)
            {
                Assert.AreEqual(result[ii], fibNumbers[ii]);
            }
        }

    }
}