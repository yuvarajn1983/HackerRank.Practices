using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HackerRankPractices.PlusMinus
{
    class Result
    {
        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void plusMinus(List<int> arr)
        {
            int[] counts = new int[3];
            foreach (int num in arr)
            {
                if (num > 0)
                    counts[0]++;
                else if (num < 0)
                    counts[1]++;
                else
                    counts[2]++;
            }
            foreach (int sum in counts)
                Console.WriteLine(string.Format("{0:0.000000}", (float)sum / arr.Count()));
        }
    }
    class Solution
    {
        public static void Run(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            Result.plusMinus(arr);
        }
    }
}

