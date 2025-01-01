public class Program
{
    public static void Main()
    {
        TestCase([[1, 2], [3, 5], [2, 2]], 2, 0.78333, "Test Case 1");
        TestCaseBruteForse([[1, 2], [3, 5], [2, 2]], 2, 0.78333, "Test Case 1");
    }

    public static void TestCase(int[][] classes, int extraStudents, double expectation, string description)
    {
        var result = MaxAverageRatio(classes, extraStudents);
        result = Math.Round(result, 5);
        Console.WriteLine(result);
        Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static void TestCaseBruteForse(int[][] classes, int extraStudents, double expectation, string description)
    {
        var result = MaxAverageRatioBruteForce(classes, extraStudents);
        result = Math.Round(result, 5);
        Console.WriteLine(result);
        Console.WriteLine($"{description} {(result == expectation ? "Passed" : "Failed")}");
    }

    public static double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        var maxHeap = new PriorityQueue<double[], double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));


        foreach (int[] singleClass in classes)
        {
            int passes = singleClass[0];
            int totalStudents = singleClass[1];
            double gain = CalculateGain(passes, totalStudents);
            maxHeap.Enqueue(new double[] { gain, passes, totalStudents }, gain);
        }

        while (extraStudents-- > 0)
        {
            var current = maxHeap.Dequeue();
            double currentGain = current[0];
            int passes = (int)current[1];
            int totalStudents = (int)current[2];

            passes++;
            totalStudents++;

            double newGain = CalculateGain(passes, totalStudents);
            maxHeap.Enqueue(new double[] { newGain, passes, totalStudents }, newGain);
        }

        double totalPassRatio = 0;
        while (maxHeap.Count > 0)
        {
            double[] current = maxHeap.Dequeue();
            int passes = (int)current[1];
            int totalStudents = (int)current[2];
            totalPassRatio += (double)passes / totalStudents;
        }

        return totalPassRatio / classes.Length;
    }

    static double CalculateGain(int passes, int totalStudents)
    {
        return (
            (double)(passes + 1) / (totalStudents + 1) -
            (double)passes / totalStudents
        );
    }

    public static double MaxAverageRatioBruteForce(int[][] classes, int extraStudents)
    {
        List<double> passRatios = new List<double>();

        // Calculate initial pass ratios
        for (int classIndex = 0; classIndex < classes.Length; classIndex++)
        {
            double initialRatio =
                (double)classes[classIndex][0] / classes[classIndex][1];
            passRatios.Add(initialRatio);
        }

        while (extraStudents > 0)
        {
            List<double> updatedRatios = new List<double>();

            // Calculate updated pass ratios if an extra student is added
            for (
                int classIndex = 0;
                classIndex < classes.Length;
                classIndex++
            )
            {
                double newRatio =
                    (double)(classes[classIndex][0] + 1) /
                    (classes[classIndex][1] + 1);
                updatedRatios.Add(newRatio);
            }

            int bestClassIndex = 0;
            double maximumGain = 0;

            // Find the class that gains the most from an extra student
            for (
                int classIndex = 0;
                classIndex < updatedRatios.Count();
                classIndex++
            )
            {
                double gain =
                    updatedRatios[classIndex] - passRatios[classIndex];
                if (gain > maximumGain)
                {
                    bestClassIndex = classIndex;
                    maximumGain = gain;
                }
            }

            // Update the selected class
            passRatios[bestClassIndex] = updatedRatios[bestClassIndex];
            classes[bestClassIndex][0]++;
            classes[bestClassIndex][1]++;

            extraStudents--;
        }

        // Calculate the total average pass ratio
        double totalPassRatio = 0;
        foreach (double passRatio in passRatios)
        {
            totalPassRatio += passRatio;
        }

        return totalPassRatio / classes.Length;
    }
}