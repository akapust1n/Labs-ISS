using System;
using System.Text;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string smallStr = "abc";
            string bigStr = "abcdefghijklpmabceee";
            int m = smallStr.Length;
            int n = bigStr.Length;
            for (int i = 0; i < n - m; ++i)
            {
                if (smallStr == bigStr.Substring(i, m))
                {
                    Console.WriteLine(String.Format("Образец найден со сдвигом {0}", i));
                }
            }
        }
    }
}
