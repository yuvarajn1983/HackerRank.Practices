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

namespace HackerRankPractices.SubMatrixSum
{



    class Result
    {

        /*
         * Complete the 'flippingMatrix' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
         */

        public static int flippingMatrix(List<List<int>> matrix)
        {
            int currentMaxSum = GetSubMatrixSum(matrix);
            for (int i = 0; i < matrix.Count; i++)
            {
                ReverseRow(matrix, i);
                int newSum = GetSubMatrixSum(matrix);
                if (newSum > currentMaxSum)
                    currentMaxSum = newSum;
                else
                    ReverseRow(matrix, i); // Rearrange back
            }
            for (int j = 0; j < matrix.Count; j++)
            {
                ReverseColumn(matrix, j);
                int newSum = GetSubMatrixSum(matrix);
                if (newSum > currentMaxSum)
                    currentMaxSum = newSum;
                else
                    ReverseColumn(matrix, j); // Rearrange back
            }
            return currentMaxSum;
        }

        public static int GetSubMatrixSum(List<List<int>> matrix)
        {
            int sum = 0;
            for (int rowIndex = 0; rowIndex < matrix.Count / 2; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrix.Count / 2; columnIndex++)
                {
                    sum += matrix[rowIndex][columnIndex];
                }
            }
            return sum;
        }

        public static void ReverseRow(List<List<int>> matrix, int rowIndex)
        {
            int temp = 0;
            for (int columnIndex = 0; columnIndex < matrix.Count / 2; columnIndex++)
            {
                temp = matrix[rowIndex][columnIndex];
                matrix[rowIndex][columnIndex] = matrix[rowIndex][matrix.Count - 1 - columnIndex];
                matrix[rowIndex][matrix.Count - 1 - columnIndex] = temp;
            }
        }

        public static void ReverseColumn(List<List<int>> matrix, int columnIndex)
        {
            int temp = 0;
            for (int rowIndex = 0; rowIndex < matrix.Count / 2; rowIndex++)
            {
                temp = matrix[rowIndex][columnIndex];
                matrix[rowIndex][columnIndex] = matrix[matrix.Count - 1 - rowIndex][columnIndex];
                matrix[matrix.Count - 1 - rowIndex][columnIndex] = temp;
            }
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
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<List<int>> matrix = new List<List<int>>();

                for (int i = 0; i < 2 * n; i++)
                {
                    matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
                }

                int result = Result.flippingMatrix(matrix);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
