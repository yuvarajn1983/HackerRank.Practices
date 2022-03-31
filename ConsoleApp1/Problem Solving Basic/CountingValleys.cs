using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HackerRankPractices.CountingValleys
{
    class Result
    {

        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         */

        public static int countingValleys(int steps, string path)
        {
            int numberOfValleys = 0;
            bool inValley = false;
            int depth = 0;
            foreach (char c in path)
            {
                if (!inValley && depth == 0 && c == 'D')
                    inValley = true;
                depth += c == 'U' ? 1 : -1;
                if (inValley && depth == 0)
                {
                    numberOfValleys++;
                    inValley = false;
                }
            }
            return numberOfValleys;
        }

    }

    class Solution
    {
        public static void Run(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            string path = Console.ReadLine();

            int result = Result.countingValleys(steps, path);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
