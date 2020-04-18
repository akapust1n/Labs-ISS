using System;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string smallStr = "abc";
            string bigStr = "abcdefghijklpmabceee";
            int n = bigStr.Length;
            int m = smallStr.Length;
            int p = 0;
            int d = 26;
            int q = 997;
            int h = (int)Math.Pow(d, m-1) % q;
            int[] t = new int[n - m + 1];
            t[0] = 0;
            for(int i = 0; i < m; ++i)
            {
                p = (d * p + smallStr[i]) ;
                t[0] = (d * t[0] + bigStr[i]);
            }
            for(int s = 0; s < n - m; ++s)
            {
                if( p == t[s] && smallStr == bigStr.Substring(s, m))
                {
                    Console.WriteLine(String.Format("Образец найден со сдвигом {0}", s));
                }
                if(s < n - m)
                {
                    t[s+1] = (d*(t[s] - bigStr[s] * h) + bigStr[s + m]);
                 }
            }
        }
    }
}
