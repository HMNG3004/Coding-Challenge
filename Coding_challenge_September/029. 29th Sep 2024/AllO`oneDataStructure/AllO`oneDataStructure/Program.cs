public class AllOne
{
    private Dictionary<string, int> dict;
    private int operation;
    private string result;

    public AllOne()
    {
        dict = new Dictionary<string, int>();
        operation = 0;
        result = "";
    }

    public void Inc(string key)
    {
        operation = 0;
        if (dict.ContainsKey(key))
        {
            dict[key]++;
        }
        else
        {
            dict[key] = 1;
        }
    }

    public void Dec(string key)
    {
        operation = 0;
        if (dict.ContainsKey(key))
        {
            if (dict[key] > 1)
            {
                dict[key]--;
            }
            else
            {
                dict.Remove(key);
            }
        }
    }

    public string GetMaxKey()
    {
        if (operation == 1)
        {
            return result;
        }
        operation = 1;
        if (dict.Count > 0)
        {
            int maxVal = int.MinValue;
            string maxKey = "";
            foreach (var pair in dict)
            {
                if (pair.Value > maxVal)
                {
                    maxVal = pair.Value;
                    maxKey = pair.Key;
                }
            }
            result = maxKey;
            return maxKey;
        }
        result = "";
        return "";
    }

    public string GetMinKey()
    {
        if (operation == 2)
        {
            return result;
        }
        operation = 2;
        if (dict.Count > 0)
        {
            int minVal = int.MaxValue;
            string minKey = "";
            foreach (var pair in dict)
            {
                if (pair.Value < minVal)
                {
                    minVal = pair.Value;
                    minKey = pair.Key;
                }
            }
            result = minKey;
            return minKey;
        }
        result = "";
        return "";
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */

public class Solution
{
    public static void Main()
    {
        AllOne allOne = new AllOne();

        allOne.Inc("hello");
        allOne.Inc("goodbye");
        allOne.Inc("hello");
        allOne.Inc("hello");

        Console.WriteLine($"GetMaxKey: {allOne.GetMaxKey()}"); // Expected: "hello"

        allOne.Inc("leet");
        allOne.Inc("code");
        allOne.Inc("leet");

        allOne.Dec("hello");

        allOne.Inc("leet");
        allOne.Inc("code");
        allOne.Inc("code");

        Console.WriteLine($"GetMaxKey: {allOne.GetMaxKey()}"); // Expected: "leet"
    }
}