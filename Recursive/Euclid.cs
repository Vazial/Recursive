using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Euclid1 : ITestable
    {
        public int Calc(int xx, int yy)
        {
            //if (xx < yy) { throw new ArgumentException("Should swap arg1 and arg2."); }
            while (true)
            {
                if (xx % yy == 0) { return yy; };
                var tmp = xx;
                xx = yy;
                yy = tmp % yy;
            }
        }

        public double[] TestMethod()
        {
            return new double[] { Calc(12345678, 432) };
        }
    }

    public class Euclid2 : ITestable
    {
        public int Calc(int xx, int yy)
        {
            //if (xx < yy) { throw new ArgumentException("Should swap arg1 and arg2."); }
            if (xx % yy == 0) { return yy; };
            return Calc(yy, (xx % yy));
        }

        public double[] TestMethod()
        {
            return new double[] { Calc(12345678, 432) };
        }
    }

}
