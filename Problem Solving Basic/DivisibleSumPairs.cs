using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace HackerRankPractices.DivisibleSumPairs
{
    public static class Solution
    {
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int result = 0;
            ar.Sort();
            for (int i = 0; i < ar.Count; i++)
            {
                for (int j = i + 1; j < ar.Count; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        result++;
                }
            }
            return result;
        }

        public static void Run()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = Solution.divisibleSumPairs(n, k, ar);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
