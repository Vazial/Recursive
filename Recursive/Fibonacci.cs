﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Fibonacci
    {
        public static readonly int[] Source = { 0, 1 };

        public static int[] NotFib(int[] nums, int max)
        {
            //if (max >= 0) { throw new ArgumentException("Argument must be positive."); };
            Array.Copy(Source, nums, Source.Length);
            int idx = Source.Length;

            while (idx < max)
            {
                nums[idx] = nums[idx - 2] + nums[idx - 1];
                ++idx;
            }
            return nums;
        }
        public static int[] Fib(int[] nums, int max)
        {
            //if (max >= 0) { throw new ArgumentException("Argument must be positive."); };
            Array.Copy(Source, nums, Source.Length);
            return Fib(nums, max, Source.Length);
        }
        private  static int[] Fib(int[] nums, int max, int idx)
        {
            if (idx >= max) { return nums; }
            nums[idx] = nums[idx - 2] + nums[idx - 1];
            return Fib(nums, max, ++idx);
        }
    }
}