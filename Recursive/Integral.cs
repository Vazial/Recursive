using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{

    // 参考 : https://atmarkit.itmedia.co.jp/ait/articles/2201/20/news015.html
    public class Integral
    {
        public static double func(double x)
        {
            return x * x;
        }

        public static double NotInte(double min, double max, double step, double integral = 0.0)
        {
            for (double ii = min; ii < max; ii += step)
            {
                // (f(a) + f(b)) (b - a) / 2
                integral += (func(ii) + func(ii + step)) * step / 2;
            }
            return integral;
        }

        public static double Inte(double min, double max, double step, double integral = 0.0)
        {
            if (min >= max) { return integral; }
            // (f(a) + f(b)) (b - a) / 2
            integral += (func(min) + func(min + step)) * step / 2;
            return Inte((min + step), max, step, integral);
        }
    }
}
