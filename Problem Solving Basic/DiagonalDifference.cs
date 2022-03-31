using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace HackerRankPractices.DiagonalDifference
{   
    class Result
    {

        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int diagonalDifference(List<List<int>> arr)
        {
            int width = arr.Count;
            int primarySum = 0;
            int secondarySum = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                primarySum += arr[i][i];
                secondarySum += arr[i][width - i - 1];
            }
            return Math.Abs(primarySum - secondarySum);
        }

    }

    class Solution
    {
        public static void Run(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = Result.diagonalDifference(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
