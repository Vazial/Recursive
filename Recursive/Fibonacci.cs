using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Fibonacci
    {
        public static readonly decimal[] Source = { 0, 1 };

        public static decimal[] NotFib(decimal[] nums, int max, int idx)
        {
            //if (max >= 0) { throw new ArgumentException("Argument must be positive."); };
            while (idx < max)
            {
                nums[idx] = nums[idx - 2] + nums[idx - 1];
                ++idx;
            }
            return nums;
        }

        public static decimal[] Fib(decimal[] nums, int max, int idx)
        {
            //if (max >= 0) { throw new ArgumentException("Argument must be positive."); };
            if (idx >= max) { return nums; }
            nums[idx] = nums[idx - 2] + nums[idx - 1];
            return Fib(nums, max, ++idx);
        }
    }
}
