using System;
using System.Collections.Generic;
using System.Text;

namespace KNP_Matcher
{
    class Program
    {
        static int[] ComputePrefixFunction(string smallStr)
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
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string smallStr = "abc";
            string bigStr = "abcdefghijklpmabceee";
            int n = bigStr.Length;
            int m = smallStr.Length;
            var p = ComputePrefixFunction(smallStr);
            int q = 0;
            for (int i = 0; i < n; ++i)
            {
                while (q > 0 && smallStr[q] != bigStr[i])
                {
                    q = p[q];
                }
                if (smallStr[q] == bigStr[i])
                {
                    ++q;
                }
                if (q == m)
                {
                    Console.WriteLine("Образец найден со сдвигом {0} ", i - m + 1);
                    q = p[q - 1];
                }
            }
        }
    }
}
