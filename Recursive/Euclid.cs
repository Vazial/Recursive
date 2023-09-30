using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Euclid
    {
        public static decimal NotEuc(decimal xx, decimal yy)
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
        public static decimal Euc(decimal xx, decimal yy)
        {
            //if (xx < yy) { throw new ArgumentException("Should swap arg1 and arg2."); }
            if (xx % yy == 0) { return yy; };
            return Euc(yy, (xx % yy));
        }
    }
}
