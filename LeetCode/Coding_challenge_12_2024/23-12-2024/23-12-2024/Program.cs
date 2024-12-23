public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Program
{
    public static void Main()
    {

    }

    public static void TestCase()
    {

    }

    public static int MinimumOperations(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int totalSwaps = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            var currentLevel = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                currentLevel.Add(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            totalSwaps += MinSwapsToSort(currentLevel);
        }

        return totalSwaps;
    }

    public static int MinSwapsToSort(List<int> arr)
    {
        int n = arr.Count;
        var indexedArr = new List<(int value, int index)>();
        for (int i = 0; i < n; i++)
        {
            indexedArr.Add((arr[i], i));
        }

        indexedArr.Sort((a, b) => a.value.CompareTo(b.value));
        var visited = new bool[n];
        int swaps = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] || indexedArr[i].index == i)
                continue;

            int cycleSize = 0;
            int x = i;

            while (!visited[x])
            {
                visited[x] = true;
                x = indexedArr[x].index;
                cycleSize++;
            }

            if (cycleSize > 1)
            {
                swaps += cycleSize - 1;
            }
        }

        return swaps;
    }
}