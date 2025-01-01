public class Solution
{
    public static void Main()
    {
        TestCase1();
        TestCase2();
    }

    public static void TestCase1()
    {
        Console.WriteLine("Test Case 1");
        string expression = "2-1-1";
        IList<int> result = DiffWaysToCompute(expression);
        Console.WriteLine("Result:" + String.Join("; ", result));
    }

    public static void TestCase2()
    {
        Console.WriteLine("Test Case 2");
        string expression = "2*3-4*5";
        IList<int> result = DiffWaysToCompute(expression);
        Console.WriteLine("Result:" + String.Join("; ", result));

    }

    private static Dictionary<string, List<int>> memo = new Dictionary<string, List<int>>();
    public static IList<int> DiffWaysToCompute(string expression)
    {
        if (memo.ContainsKey(expression))
            return memo[expression];

        var result = new List<int>();

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];
            if (c == '+' || c == '-' || c == '*')
            {
                // Divide the expression into two parts
                var left = DiffWaysToCompute(expression.Substring(0, i));
                var right = DiffWaysToCompute(expression.Substring(i + 1));

                // Compute all combinations of left and right results
                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        if (c == '+')
                            result.Add(l + r);
                        else if (c == '-')
                            result.Add(l - r);
                        else if (c == '*')
                            result.Add(l * r);
                    }
                }
            }
        }

        // If no operator was found, it means the expression is a single number
        if (result.Count == 0)
            result.Add(int.Parse(expression));

        // Memoize the result for this expression
        memo[expression] = result;
        return result;
    }
}