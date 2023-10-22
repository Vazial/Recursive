using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Factorial1 : ITestable
    {
        
        public int Calc(int nn, int sum = 1)
        {
            //if (nn < 0) { throw new ArgumentException("Argument must be positive."); }
            for (int ii = nn; ii > 0; --ii)
            {
                sum *= ii;
            }
            return sum;
        }
        public double[] TestMethod()
        {
            return new double[] { Calc(10) };
        }
    }
    public class Factorial2 : ITestable
    {
        public int Calc(int nn, int sum = 1)
        {
            //if (nn < 0) { throw new ArgumentException("Argument must be positive."); }
            if (nn <= 0) { return sum; }
            return Calc(nn - 1, sum * nn);
        }

        public double[] TestMethod()
        {
            return new double[] { Calc(10) };
        }
    }
}
