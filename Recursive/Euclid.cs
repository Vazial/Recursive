using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Euclid
    {
        public static int NotEuc(int xx, int yy)
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
        public static int Euc(int xx, int yy)
        {
            //if (xx < yy) { throw new ArgumentException("Should swap arg1 and arg2."); }
            if (xx % yy == 0) { return yy; };
            return Euc(yy, (xx % yy));
        }
    }
}
