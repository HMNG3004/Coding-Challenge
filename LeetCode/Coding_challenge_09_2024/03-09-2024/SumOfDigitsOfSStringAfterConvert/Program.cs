namespace SumOfDigitsOfSStringAfterConvert
{
    public class Program
    {
        public static void Main()
        {
            TestCase1();
            TestCase2();
            TestCase3();
        }

        public static void TestCase1()
        {
            string s = "ituaazzknmlimmcqbejjgmaky";
            int k = 9;
            Console.WriteLine(GetLucky(s, k));
        }

        public static void TestCase2()
        {
            string s = "leetcode";
            int k = 2;
            Console.WriteLine(GetLucky(s, k));
        }

        public static void TestCase3()
        {
            string s = "zbax";
            int k = 5;
            Console.WriteLine(GetLucky2(s, k));
        }

        public static int GetLucky(string s, int k)
        {
            string numStr = "";
            foreach (char c in s)
            {
                int num = c - 'a' + 1;
                numStr += num.ToString();
            }

            for (int i = 0; i < k; i++)
            {
                int sum = 0;
                foreach (char digit in numStr)
                {
                    sum += digit - '0';
                }
                numStr = sum.ToString();
            }

            return int.Parse(numStr);
        }

        public static int GetLucky2(string s, int k)
        {
            var res = 0;
            foreach (char c in s)
            {
                var val = c - 'a' + 1;

                res += val % 10;
                res += val /= 10;
            }

            while (--k > 0)
            {
                var n = res;
                res = 0;

                while (n > 0)
                {
                    res += n % 10;
                    n /= 10;
                }
            }

            return res;
        }
    }
}