
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    internal class Program
    {
        static Dictionary<Tuple<int, char>, int> createTransitions(string bigStr)
        {
            Dictionary<Tuple<int, char>, int> delta = new Dictionary<Tuple<int, char>, int>();
            int m = bigStr.Length;
            for (int q = 0; q < m; ++q)
            {
                for(int a = 0; a < 256; ++a)
                {
                    int k = Math.Min(m, q + 1);
                    string temp1 = bigStr.Substring(0, k);
                    string temp2 = bigStr.Substring(0, q) + (char)a;
                    while(!temp2.Contains(temp1))
                    {
                        k -= 1;
                        temp1 = bigStr.Substring(0, k);
                    }
                    Tuple<int, char> key = new Tuple<int, char>(q, (char)a);
                    delta.Add(key, k);
                 }
             }
            return delta;
        }

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string smallStr = "abc";
            string bigStr = "abcdefghijklpmabceee";
            var delta = createTransitions(bigStr);
            int m = smallStr.Length;
            int n = bigStr.Length;
            int q = 0;
            for(int i = 0; i < n; ++i)
            {
                q = delta[Tuple.Create(q, bigStr[i])];
                if (q == m)
                {
                    q = 0;
                    Console.WriteLine("Substring located with shift {0}", (i - m + 1));
                }
           
            }
        
        }
    }
}
