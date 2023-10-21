using Recursive.Tester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Factorial : ITestable
    {
        public static int NotFact(int nn, int sum)
        {
            for (int ii = nn; ii > 0; --ii)
            {
                sum *= ii;
            }
            return sum;
        }

        public static int Fact(int nn, int sum)
        {
            if (nn <= 0) { return sum; }
            return Fact(nn - 1, sum * nn);
        }

        public double[] TestMethod()
        {
            return new double[] { Fact(10, 0) };
        }
    }
}
