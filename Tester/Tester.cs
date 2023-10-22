using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recursive;

namespace Recursive.Tester
{
    public class Tester
    {
        public static void Main(string[] args)
        {
            if ((args[0] == null) || (args[1] == null)) 
            { 
                throw new ArgumentNullException("Two class names must be specified as arguments."); 
            }

            var target1 = (ITestable)Activator.CreateInstance(GetType(args[0]));
            var target2 = (ITestable)Activator.CreateInstance(GetType(args[1]));

            var watch = new Stopwatch();

            watch.Start();
            var result1 = target1.TestMethod();
            watch.Stop();
            var Elap1 = watch.Elapsed;

            watch.Restart();
            var result2 = target2.TestMethod();
            watch.Stop();
            var Elap2 = watch.Elapsed;

            if (result1.SequenceEqual(result2))
            {
                Console.WriteLine($"実行結果 : 一致({String.Join(", ", result1)})");
                Console.WriteLine($"実行速度 : {args[0]}({Elap1}), {args[1]}({Elap2})");
            }
            else
            {
                Console.WriteLine($"実行結果 : 不一致({args[0]}({String.Join(", ", result1)}), " +
                                                    $"{args[1]}({String.Join(", ", result2)})");
            }
            Console.ReadKey();
        }

        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            throw new Exception("Class not found.");
        }
    }
}
