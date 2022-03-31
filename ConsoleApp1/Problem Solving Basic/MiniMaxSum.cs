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

namespace HackerRankPractices.MiniMaxSum
{
    class Result
    {

        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void miniMaxSum(List<int> arr)
        {
            int min = arr[0], max = arr[0];
            long sum = min;
            for (int index = 1; index < arr.Count; index++)
            {
                sum += arr[index];
                if (arr[index] > max)
                    max = arr[index];
                else if (arr[index] < min)
                    min = arr[index];
            }
            Console.WriteLine("{0} {1}", sum - max, sum - min);
        }

    }

    class Solution
    {
        public static void Run(string[] args)
        {

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            Result.miniMaxSum(arr);
        }
    }
}

