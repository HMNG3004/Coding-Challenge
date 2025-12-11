namespace Day_08_Playground
{
    public class DSU
    {
        private int[] parent;
        private int[] rank;

        public DSU(int n)
        {
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public bool Union(int x, int y)
        {
            int rx = Find(x);
            int ry = Find(y);
            if (rx == ry) return false;

            if (rank[rx] < rank[ry])
            {
                parent[rx] = ry;
            }
            else if (rank[rx] > rank[ry])
            {
                parent[ry] = rx;
            }
            else
            {
                parent[ry] = rx;
                rank[rx]++;
            }
            return true;
        }
    }
}
