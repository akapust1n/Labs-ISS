using System;
using System.Collections.Generic;
using System.Text;

namespace Boyer_Moore
{
    class Program
    {
        static int[] ComputePrefix(string smallStr)
        {
            int m = smallStr.Length;
            int[] p = new int[m + 1];
            p[0] = 0;
            int k = 0;
            for (int q = 1; q < m; ++q)
            {
                k = p[q - 1];
                while (k > 0 && smallStr[k] != smallStr[q])
                {
                    k = p[k - 1];
                }
                if (smallStr[k] == smallStr[q])
                {
                    k = k + 1;
                }
                p[q] = k;
            }
            return p;
        }
        static Dictionary<char, int> GetBadSymbolsTable(string smallStr)
        {
            Dictionary<char, int> badSymbols = new Dictionary<char, int>();
            int m = smallStr.Length;
            for (int j = 0; j < m; ++j)
            {
                badSymbols.Add(smallStr[j], j);
            }
            return badSymbols;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static Dictionary<int, int> GetGoodSuffix(string smallStr)
        {
            Dictionary<int, int> table = new Dictionary<int, int>();
            int m = smallStr.Length;
            var p = ComputePrefix(smallStr);
            var p_inv = ComputePrefix(Reverse(smallStr));
            for (int j = 0; j < m + 1; ++j)
            {
                table.Add(j, m - p[m - 1] - 1);
            }
            for (int l = 0; l < m; ++l)
            {
                int j = m - p_inv[l] - 1;

                if (table[j] > l - p_inv[l])
                {
                    table[j] = l - p_inv[l];
                }
            }
            return table;
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string smallStr = "abc";
            string bigStr = "abcdefghijklpmabceee";
            int n = bigStr.Length;
            int m = smallStr.Length;

            var badSymbols = GetBadSymbolsTable(smallStr);
            var goodSuffix = GetGoodSuffix(smallStr);
            int s = 0;
            while (s <= n - m)
            {
                int j = m - 1;
                while (j > 0 && smallStr[j] == bigStr[s + j])


                    j = j - 1;
                if (j == 0)
                {
                    Console.WriteLine("Образец найден со сдвигом {0} ", s);

                    s = s + goodSuffix[0];
                }
                else
                {
                    int goodSuffixSymbol = 0;
                    goodSuffix.TryGetValue(bigStr[s + j], out goodSuffixSymbol);

                    int badSymbol = 0;
                    badSymbols.TryGetValue((char)j, out badSymbol);
                    s = s + Math.Max(badSymbol, j - goodSuffixSymbol);
                }
            }
        }
    }
}
