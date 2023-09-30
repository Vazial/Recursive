using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Factorial
    {
        public static decimal NotFact(int nn, decimal sum)
        {
            for (int ii = nn; ii > 0; --ii)
            {
                sum *= ii;
            }
            return sum;
        }

        public static decimal Fact(int nn, decimal sum)
        {
            if (nn <= 0) { return sum; }
            return Fact(nn - 1, sum * nn);
        }
    }
}
