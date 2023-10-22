using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Fibonacci1 : ITestable
    {
        public static readonly int[] Source = { 0, 1 };

        public int[] Calc(int max)
        {
            //if (max >= 0) { throw new ArgumentException("Argument must be positive."); };
            var nums = new int[64];
            Array.Copy(Source, nums, Source.Length);
            return Calc(max, nums);
        }

        private int[] Calc(int max, int[] nums, int idx = 2)
        {
            while (idx < max)
            {
                nums[idx] = nums[idx - 2] + nums[idx - 1];
                ++idx;
            }
            return nums;
        }

        public double[] TestMethod()
        {
            var result = Calc(10);
            var ret = new double[result.Length];
            Array.Copy(result, ret, result.Length);
            return ret;
        }
    }
    public class Fibonacci2 : ITestable
    {
        public static readonly int[] Source = { 0, 1 };

        public int[] Calc(int max)
        {
            //if (max >= 0) { throw new ArgumentException("Argument must be positive."); };
            var nums = new int[64];
            Array.Copy(Source, nums, Source.Length);
            return Calc(max, nums);
        }

        public int[] Calc(int max, int[] nums, int idx = 2)
        {
            if (idx >= max) { return nums; }
            nums[idx] = nums[idx - 2] + nums[idx - 1];
            return Calc(max, nums, ++idx);
        }

        public double[] TestMethod()
        {
            var result = Calc(10);
            var ret = new double[result.Length];
            Array.Copy(result, ret, result.Length);
            return ret;
        }

    }
}
