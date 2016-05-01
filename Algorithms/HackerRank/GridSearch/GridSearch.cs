using System;

namespace Algorithms.HackerRank.GridSearch
{
    class GridSearch
    {
        static int[,] GenerateMatrixFromInput(int rows, int cols)
        {
            string input;
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                input = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j] - '0';
                }
            }

            return matrix;
        }


        static bool FindPatternInGrid(int[,] grid, int[,] pattern, int gridRows,
            int gridCols, int patternRows, int patternCols)
        {
            int targetMatch = patternRows * patternCols;
            int matchCount, gRow, gCol, pRow, pCol;

            for (int i = 0; i < gridRows; i++)
            {
                if (gridRows - i < patternRows)
                {
                    break;
                }

                for (int j = 0; j < gridCols; j++)
                {
                    if (gridCols - j < patternCols)
                    {
                        continue;
                    }

                    gRow = i;
                    gCol = j;
                    pRow = 0;
                    pCol = 0;
                    matchCount = 0;

                    while (grid[gRow, gCol] == pattern[pRow, pCol])
                    {
                        if (pCol < patternCols - 1 && gCol < gridCols - 1)
                        {
                            gCol++;
                            pCol++;
                        }
                        else
                        {
                            gRow++;
                            gCol = j;
                            pRow++;
                            pCol = 0;
                        }

                        matchCount++;

                        if (matchCount == targetMatch)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        static void Main(string[] args)
        {
            string numTestStr = Console.ReadLine();
            int numTests = Convert.ToInt32(numTestStr);
            bool[] patternsFound = new bool[numTests];

            string[] gridRowColStr, patternRowColStr;
            int[,] grid, pattern;
            int gridRows, gridCols, patternRows, patternCols;

            for (int i = 0; i < numTests; i++)
            {
                gridRowColStr = Console.ReadLine().Split(' ');
                gridRows = Convert.ToInt32(gridRowColStr[0]);
                gridCols = Convert.ToInt32(gridRowColStr[1]);
                grid = GenerateMatrixFromInput(gridRows, gridCols);

                patternRowColStr = Console.ReadLine().Split(' ');
                patternRows = Convert.ToInt32(patternRowColStr[0]);
                patternCols = Convert.ToInt32(patternRowColStr[1]);
                pattern = GenerateMatrixFromInput(patternRows, patternCols);

                patternsFound[i] = FindPatternInGrid(grid, pattern, gridRows,
                    gridCols, patternRows, patternCols);
            }

            for (int i = 0; i < numTests; i++)
            {
                //  Comment out for HackerRank expected output  
                Console.WriteLine("Test {0} pattern found:\t{1}", i, patternsFound[i]);

                //  Uncomment for HackerRank expected output
                //if (patternsFound[i])
                //    Console.WriteLine("YES");
                //else
                //    Console.WriteLine("NO");
            }

            Console.Read();
        }
    }
}
