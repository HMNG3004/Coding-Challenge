using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_Gift_Shop
{
    public static class Part1
    {
        public static long SumRepeatedInRange(long L, long R)
        {
            long sum = 0;
            int maxDigits = R.ToString().Length;

            for (int k = 1; k <= maxDigits / 2; k++)
            {
                long pow10k = Program.Pow10(k);
                long baseVal = pow10k + 1; // 10^k + 1

                // Tính khoảng P có thể
                long minPByRange = (L + baseVal - 1) / baseVal; // ceil(L / baseVal)
                long maxPByRange = R / baseVal;                  // floor(R / baseVal)

                long minPByDigits = Program.Pow10(k - 1); // 10^(k-1)
                long maxPByDigits = pow10k - 1;   // 10^k - 1

                long lo = Math.Max(minPByRange, minPByDigits);
                long hi = Math.Min(maxPByRange, maxPByDigits);

                if (lo > hi) continue;

                for (long p = lo; p <= hi; p++)
                {
                    long n = p * pow10k + p;
                    if (n >= L && n <= R)
                    {
                        sum += n;
                    }
                }
            }

            return sum;
        }
    }
}
