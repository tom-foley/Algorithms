using System;
using System.Numerics;

namespace Algorithms.HackerRank.ExtraLongFactorials
{
    class ExtraLongFactorials
    {
        static BigInteger Factorial(int n)
        {
            if (n > 1)
            {
                return n * Factorial(n - 1);
            }

            return n;
        }


        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }
    }
}
