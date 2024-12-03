public class CustomStack
{

    private int maxSize;
    private List<int> stack;

    public CustomStack(int maxSize)
    {
        this.maxSize = maxSize;
        this.stack = new List<int>();
    }

    public void Push(int x)
    {
        if (stack.Count < maxSize)
        {
            stack.Add(x);
        }
    }

    public int Pop()
    {
        if (stack.Count == 0)
        {
            return -1;
        }
        int topElement = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return topElement;
    }

    public void Increment(int k, int val)
    {
        int limit = Math.Min(k, stack.Count);
        for (int i = 0; i < limit; i++)
        {
            stack[i] += val;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Input simulation
        string[] operations = {
            "CustomStack", "push", "push", "pop", "push",
            "push", "push", "increment", "increment", "pop",
            "pop", "pop", "pop"
        };
        int[][] parameters = {
            new int[] { 3 }, new int[] { 1 }, new int[] { 2 }, new int[0],
            new int[] { 2 }, new int[] { 3 }, new int[] { 4 },
            new int[] { 5, 100 }, new int[] { 2, 100 }, new int[0],
            new int[0], new int[0], new int[0]
        };

        CustomStack customStack = null;
        List<object> output = new List<object>();

        for (int i = 0; i < operations.Length; i++)
        {
            switch (operations[i])
            {
                case "CustomStack":
                    customStack = new CustomStack(parameters[i][0]);
                    output.Add(null);
                    break;
                case "push":
                    customStack.Push(parameters[i][0]);
                    output.Add(null);
                    break;
                case "pop":
                    output.Add(customStack.Pop());
                    break;
                case "increment":
                    customStack.Increment(parameters[i][0], parameters[i][1]);
                    output.Add(null);
                    break;
                default:
                    throw new InvalidOperationException("Unknown operation: " + operations[i]);
            }
        }

        Console.WriteLine("Output: " + string.Join(", ", output));
    }
}