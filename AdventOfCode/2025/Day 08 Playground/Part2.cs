namespace Day_08_Playground
{
    public static class Part2
    {
        public static long SolvePart2(List<Point> points, List<Edge> edges)
        {
            int n = points.Count;
            var dsu = new DSU(n);
            int components = n;
            Edge lastEdge = default;

            foreach (var e in edges)
            {
                if (dsu.Union(e.A, e.B))
                {
                    components--;
                    if (components == 1)
                    {
                        lastEdge = e;
                        break;
                    }
                }
            }

            var p1 = points[lastEdge.A];
            var p2 = points[lastEdge.B];

            // X coords multiply
            return (long)p1.X * p2.X;
        }
    }
}
