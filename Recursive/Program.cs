﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            Euclid.NotEuc(12345678, 432);
            sw.Stop();
            Console.WriteLine("Euclid    : Loop       " + sw.Elapsed);

            sw.Restart();
            Euclid.Euc(12345678, 432);
            sw.Stop();
            Console.WriteLine("Euclid    : Recursive  " + sw.Elapsed);

            sw.Restart();
            Factorial.NotFact(19, 20);
            sw.Stop();
            Console.WriteLine("Factorial : Loop       " + sw.Elapsed);

            sw.Restart();
            Factorial.Fact(19,20);
            sw.Stop();
            Console.WriteLine("Factorial : Recursive  " + sw.Elapsed);

            var max = 100;
            var nums = new decimal[max];
            Array.Copy(Fibonacci.Source, nums, Fibonacci.Source.Length);
            sw.Restart();
            var bb = Fibonacci.NotFib(nums, max, Fibonacci.Source.Length);
            sw.Stop();
            Console.WriteLine("Fibonacci : Loop       " + sw.Elapsed);

            max = 100;
            nums = new decimal[max];
            Array.Copy(Fibonacci.Source, nums, Fibonacci.Source.Length);
            sw.Restart();
            var aa  = Fibonacci.Fib(nums, max, Fibonacci.Source.Length);
            sw.Stop();
            Console.WriteLine("Fibonacci : Recursive  " + sw.Elapsed);


        }
    }
}
