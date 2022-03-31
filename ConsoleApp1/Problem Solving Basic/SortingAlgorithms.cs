using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankPractices
{
    public class SortingAlgorithms
    {
        public void Run()
        {
            int[] array = new int[] { 1, 23, 10, -2 };
            PrintArray(array);
            BubbleSort(array);
            PrintArray(array);
        }

        public void PrintArray(int[] array)
        {
            foreach (int n in array)
                Console.Write("{0} ", n);
            Console.Write(Environment.NewLine);
        }
        public void BubbleSort(int[] array)
        {
            int length = array.Length;
            int temp;
            for(int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
