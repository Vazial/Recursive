using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{

    // 参考 : https://atmarkit.itmedia.co.jp/ait/articles/2201/20/news015.html
    public class Integral1 : ITestable
    {
        private Func<double, double> func;

        public Integral1()
        {
            func = ((double x) => x * x);
        }

        public Integral1(Func<double, double> func)
        {
            this.func = func;
        }

        public  double Calc(double min, double max, double step, double integral = 0.0)
        {
            for (double ii = min; ii < max; ii += step)
            {
                // (f(a) + f(b)) (b - a) / 2
                integral += (func(ii) + func(ii + step)) * step / 2;
            }
            return integral;
        }

        public double[] TestMethod()
        {
            return new double[] { Calc(0, 1, 0.0001) };
        }
    }

    public class Integral2 : ITestable
    {
        private Func<double, double> func;

        public Integral2()
        {
            func = ((double x) => x * x);
        }

        public Integral2(Func<double, double> func)
        {
            this.func = func;
        }

        public double Calc(double min, double max, double step, double integral = 0.0)
        {
            if (min >= max) { return integral; }
            // (f(a) + f(b)) (b - a) / 2
            integral += (func(min) + func(min + step)) * step / 2;
            return Calc((min + step), max, step, integral);
        }

        public double[] TestMethod()
        {
            return new double[] { Calc(0, 1, 0.0001) };
        }
    }
}
