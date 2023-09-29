using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Factorial
    {
        public static int Fact(int nn)
        {
            if (nn <= 0) { return 1; }
            return nn * Fact(nn - 1);
        }

        public static int NotFact(int nn)
        {
            var sum = nn;
            for (int ii = (nn - 1); ii > 0; --ii)
            {
                sum *= ii;
            }
            return sum;
        }
    }
}
