public class Program
{
    public static void Main()
    {
        TestCase([[0, 1], [0, 2], [0, 3]], [[0, 1]], 3,"Test Case 1");
        TestCase([[0, 1], [0, 2], [0, 3], [2, 4], [2, 5], [3, 6], [2, 7]], [[0, 1], [0, 2], [0, 3], [2, 4], [2, 5], [3, 6], [2, 7]], 5,"Test Case 2");
    }

    public static void TestCase(int[][] edges1, int[][] edges2, int expectation, string description)
    {
        var result = MinimumDiameterAfterMerge(edges1, edges2);
        Console.WriteLine($"{description}: {(result == expectation ? "Passed" : "Failed")}");
    }

    public static int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        // Calculate the number of nodes for each tree
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;

        // Build adjacency lists for both trees
        var adjList1 = BuildAdjList(n, edges1);
        var adjList2 = BuildAdjList(m, edges2);

        // Calculate the diameters of both trees
        int diameter1 = FindDiameter(n, adjList1);
        int diameter2 = FindDiameter(m, adjList2);

        // Calculate the longest path that spans across both trees
        int combinedDiameter =
            (int)Math.Ceiling(diameter1 / 2.0) +
            (int)Math.Ceiling(diameter2 / 2.0) +
            1;

        // Return the maximum of the three possibilities
        return Math.Max(Math.Max(diameter1, diameter2), combinedDiameter);
    }

    private static List<List<int>> BuildAdjList(int size, int[][] edges)
    {
        var adjList = new List<List<int>>(size);
        for (int i = 0; i < size; i++)
        {
            adjList.Add(new List<int>());
        }
        foreach (var edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        return adjList;
    }

    private static int FindDiameter(int n, List<List<int>> adjList)
    {
        // First BFS to find the farthest node from an arbitrary node (e.g., 0)
        var firstBFS = FindFarthestNode(n, adjList, 0);
        int farthestNode = firstBFS.First;

        // Second BFS to find the diameter starting from the farthest node
        var secondBFS = FindFarthestNode(n, adjList, farthestNode);
        return secondBFS.Second;
    }

    private static (int First, int Second) FindFarthestNode(int n, List<List<int>> adjList, int sourceNode)
    {
        var queue = new Queue<int>();
        var visited = new bool[n];

        // Push source node into the queue
        queue.Enqueue(sourceNode);
        visited[sourceNode] = true;

        int maximumDistance = 0, farthestNode = sourceNode;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                int currentNode = queue.Dequeue();
                // Update farthest node
                // The farthest node is the last one that was dequeued
                farthestNode = currentNode;

                // Explore neighbors
                foreach (var neighbor in adjList[currentNode])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            if (queue.Count > 0) maximumDistance++;
        }
        return (farthestNode, maximumDistance);
    }
}