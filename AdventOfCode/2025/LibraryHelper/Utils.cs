using System;
using System.Diagnostics;

namespace LibraryHelper
{
    public static class Utils
    {
        public static T Measure<T>(string name, Func<T> func)
        {
            var sw = Stopwatch.StartNew();
            T result = func();
            sw.Stop();
            Console.WriteLine($"{name} took {sw.ElapsedMilliseconds} ms");
            return result;
        }
    }
}
