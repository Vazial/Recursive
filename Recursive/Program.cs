using System;
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
            Factorial.NotFact(100);
            sw.Stop();
            Console.WriteLine("Factorial : Loop       " + sw.Elapsed);

            sw.Restart();
            Factorial.Fact(100);
            sw.Stop();
            Console.WriteLine("Factorial : Recursive  " + sw.Elapsed);

            sw.Restart();

            Fibonacci.NotFib(new int[30], 30);
            sw.Stop();
            Console.WriteLine("Fibonacci : Loop       " + sw.Elapsed);

            sw.Restart();
            Fibonacci.Fib(new int[30], 30);
            sw.Stop();
            Console.WriteLine("Fibonacci : Recursive  " + sw.Elapsed);


        }
    }
}
