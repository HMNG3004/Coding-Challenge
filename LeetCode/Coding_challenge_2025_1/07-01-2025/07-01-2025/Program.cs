public class Program
{
    public static void Main()
    {
        TestCase(["mass", "as", "hero", "superhero"], ["as", "hero"], "Test Case 1");
        TestCase(["leetcode", "et", "code"], ["et", "code"], "Test Case 2");
        TestCase(["blue", "green", "bu"], [], "Test Case 3");
    }

    public static void TestCase(string[] words, IList<string> expectation, string description)
    {
        StringMatching(words);
        StringMatching2(words);
    }

    //Brute force solution
    public static IList<string> StringMatching(string[] words)
    {
        var result = new List<string>();
        foreach(var word in words)
        {
            foreach (var other in words)
            {
                if (word != other && other.Contains(word))
                {
                    result.Add(word);
                    break;
                }
            }
        }
        return result;
    }

    //LINQ solution
    public static IList<string> StringMatching2(string[] words)
    {
        return words.Where(x => words.Where(w => w != x).Any(w => w.Contains(x))).ToList();
    }
}