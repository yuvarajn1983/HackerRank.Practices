using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankPractices.CamelCase
{
    static class Solution
    {
        public static void Run()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string input = Console.ReadLine();
            if (input[0] == 'S' || input[0] == 's')
                Console.WriteLine(SplitToken(input.Substring(2)));
            else
                Console.WriteLine(MergeToken(input.Substring(2)));
        }

        static string SplitToken(string token)
        {
            string splitTokens = string.Empty;
            if (token[0] == 'M' || token[0] == 'm')
                token = token.Substring(0, token.Length - 2);
            token = token.Substring(2);
            for (int i = 0; i < token.Length; i++)
            {
                if (i != 0 && IsUpper(token[i]))
                    splitTokens += " ";
                splitTokens += token[i].ToString().ToLower();
            }
            return splitTokens;
        }

        static string MergeToken(string token)
        {
            string mergedToken = string.Empty;
            bool classToken = token[0] == 'C' || token[0] == 'c';
            string[] tokenParts = token.Substring(2).Split(' ');
            if (tokenParts.Length > 0)
            {
                mergedToken = classToken ? MakeFirstCharUppercase(tokenParts[0]) : tokenParts[0].ToLower();
                for (int i = 1; i < tokenParts.Length; i++)
                    mergedToken += MakeFirstCharUppercase(tokenParts[0]);
            }
            mergedToken += token[0] == 'M' || token[0] == 'm' ? "()" : string.Empty;
            return mergedToken;
        }

        static string MakeFirstCharUppercase(string tokenPart)
        {
            tokenPart = tokenPart.ToLower();
            tokenPart = tokenPart[0].ToString().ToUpper() + tokenPart.Substring(1);
            return tokenPart;
        }
        static bool IsUpper(char charToCheck) => charToCheck >= 'A' && charToCheck <= 'Z';

    }
}
