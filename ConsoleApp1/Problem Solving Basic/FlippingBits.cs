using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerRankPractices.FlippingBits
{
    class Result
    {

        /*
         * Complete the 'flippingBits' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts LONG_INTEGER n as parameter.
         */

        public static long flippingBits(long n)
        {
            string binary = Convert.ToString(n, 2).PadLeft(32,'0');
            StringBuilder builder = new StringBuilder();
            foreach (char c in binary)
                builder.Append(c == '1' ? '0' : '1');
            return Convert.ToInt64(builder.ToString(), 2);
        }

    }

    class Solution
    {
        public static void Run(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                long n = Convert.ToInt64(Console.ReadLine().Trim());

                long result = Result.flippingBits(n);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
