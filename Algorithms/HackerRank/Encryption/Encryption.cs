using System;
using System.Text;

namespace Algorithms.HackerRank.Encryption
{
    class Encryption
    {
        static string Encrypt(string plaintext)
        {
            string condensed = plaintext.Replace(" ", "");
            StringBuilder sb = new StringBuilder();

            int pos;
            int len = condensed.Length;
            int rows = Convert.ToInt32(Math.Floor(Math.Sqrt(len)));
            int cols = Convert.ToInt32(Math.Ceiling(Math.Sqrt(len)));

            //  Alternate between incrementing rows & columns
            byte alt = 0x00;
            while (rows * cols < len)
            {
                if (alt == 0x00 && rows < cols)
                {
                    rows++;
                    alt = 0x01;
                }
                else
                {
                    cols++;
                    alt = 0x00;
                }
            }

            for (int i = 0; i < cols; i++)
            {
                pos = i;
                for (int j = 0; j < rows; j++)
                {
                    if (pos < len)
                    {
                        sb.Append(condensed[pos]);
                        pos += cols;
                    }
                }

                sb.Append(' ');
            }

            return sb.ToString();
        }


        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(Encrypt(s));
            //Console.Read();
        }
    }
}
