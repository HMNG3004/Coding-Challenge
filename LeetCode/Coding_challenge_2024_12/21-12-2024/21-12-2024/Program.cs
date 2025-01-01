public class Program
{
    public static void Main()
    {
        TestCase(5, [[0, 2], [1, 2], [1, 3], [2, 4]], [1, 8, 1, 4, 4], 6, 2, "Test case 1:");
    }

    public static void TestCase(int n, int[][] edges, int[] values, int k, int expectation, string description)
    {
        var result = MaxKDivisibleComponents(n, edges, values, k);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        List<int>[] adjacency = new List<int>[n];
        for(int i = 0; i < n; i++)
        {
            adjacency[i] = new List<int>();
        }

        foreach(var edge in edges)
        {
            int node1 = edge[0];
            int node2 = edge[1];
            adjacency[node1].Add(node2);
            adjacency[node2].Add(node1);
        }

        int[] componentCount = new int[1];
        DFS(0, -1, adjacency, values, k, componentCount);

        return componentCount[0];
    }

    public static int DFS(int currentNode, int parentNode, List<int>[] adjacency, int[] nodeValues, int k, int[] componentCount)
    {
        int sum = 0;

        foreach(var neighbor in adjacency[currentNode])
        {
            if(neighbor == parentNode)
            {
                continue;
            }
            sum += DFS(neighbor, currentNode, adjacency, nodeValues, k, componentCount);
            sum %= k;
        }

        sum += nodeValues[currentNode];
        sum %= k;

        if(sum == 0)
        {
            componentCount[0]++;
            return 0;
        }

        return sum;
    }
}