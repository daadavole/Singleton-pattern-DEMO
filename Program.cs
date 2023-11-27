using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton_pattern_DEMO
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Non safe Singleton test");
            //Testing the non thread safe Singleton version
            Singleton_non_thread_safe s1 = Singleton_non_thread_safe.GetInstance();
            Singleton_non_thread_safe s2 = Singleton_non_thread_safe.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }

            //Testing the thread safe Singleton version
            Console.WriteLine("Safe Singleton test");
            Console.WriteLine(
                "If you see the same value, then singleton was reused (yay!)",
                "If you see different values, then 2 singletons were created (booo!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
            Console.ReadKey();
        }
        public static void TestSingleton(string value)
        {
            Singleton_thread_safe singleton = Singleton_thread_safe.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}
