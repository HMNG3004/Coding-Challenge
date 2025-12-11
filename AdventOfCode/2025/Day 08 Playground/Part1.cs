using System.Drawing;
using System.Security.Cryptography;

namespace Day_08_Playground
{
    public static class Part1
    {
        public static long SolvePart1(int n, List<Edge> edges, int K)
        {
            int useK = Math.Min(K, edges.Count);
            var dsu = new DSU(n);

            for (int idx = 0; idx < useK; idx++)
            {
                var e = edges[idx];
                dsu.Union(e.A, e.B);
            }

            var compSize = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int root = dsu.Find(i);
                if (!compSize.ContainsKey(root)) compSize[root] = 0;
                compSize[root]++;
            }

            var sizes = new List<int>(compSize.Values);
            sizes.Sort((a, b) => b.CompareTo(a));

            if (sizes.Count < 3)
                throw new InvalidOperationException("Less than 3 circuits found.");

            long a1 = sizes[0];
            long a2 = sizes[1];
            long a3 = sizes[2];

            return a1 * a2 * a3;
        }
    }
}
