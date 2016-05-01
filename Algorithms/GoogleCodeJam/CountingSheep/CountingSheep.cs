using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.GoogleCodeJam
{
    class CountingSheep
    {
        static short digitsLength = 10;

        static bool AllMarked(byte[] marked)
        {
            for (int i = 0; i < digitsLength; i++)
            {
                if (marked[i] == 0) return false;
            }

            return true;
        }


        static byte[] MarkNumber(byte[] marked, int current)
        {
            while (current >= 1)
            {
                marked[current % 10] = 1;
                current /= 10;
            }

            return marked;
        }


        static void Main(string[] args)
        {
            int numTests = Convert.ToInt32(Console.ReadLine());
            int j, current = 0;
            int[,] results = new int[numTests, 2];

            byte[] marked;

            for (int i = 0; i < numTests; i++)
            {
                j = 1;
                current = Convert.ToInt32(Console.ReadLine());

                if (current * j > 0)
                {
                    marked = new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    while (!AllMarked(MarkNumber(marked, current * j))) j++;
                }

                results[i, 0] = current;
                results[i, 1] = current * j;
            }

            for (int i = 0; i < numTests; i++)
            {
                Console.WriteLine("Case #{0}:\t==>\tInput:\t{1}\tOutput:\t{2}", i, results[i, 0], results[i, 1]);
            }

            Console.Read();
        }
    }
}