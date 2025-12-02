using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_Gift_Shop
{
    public static class Part2
    {
        public static long SumRepeatedAtLeastTwice(long L, long R)
        {
            var nums = new HashSet<long>();
            int maxDigits = R.ToString().Length;

            for (int k = 1; k <= maxDigits; k++)
            {
                long pow10k = Pow10(k);

                int maxT = maxDigits / k;
                if (maxT < 2) break;

                for (int t = 2; t <= maxT; t++)
                {
                    long factor = BuildFactor(pow10k, t);

                    long lo = Math.Max(
                        DivCeil(L, factor),
                        Pow10(k - 1)
                    );

                    long hi = Math.Min(
                        R / factor,
                        pow10k - 1
                    );

                    if (lo > hi) continue;

                    for (long p = lo; p <= hi; p++)
                    {
                        long n = p * factor;
                        if (n >= L && n <= R)
                        {
                            nums.Add(n);
                        }
                    }
                }
            }

            long sum = 0;
            foreach (var n in nums)
                sum += n;

            return sum;
        }

        static long BuildFactor(long pow10k, int t)
        {
            long f = 0;
            for (int i = 0; i < t; i++)
                f = f * pow10k + 1;
            return f;
        }

        static long Pow10(int exp)
        {
            long res = 1;
            for (int i = 0; i < exp; i++) res *= 10;
            return res;
        }

        static long DivCeil(long a, long b)
        {
            return (a + b - 1) / b;
        }
    }
}
