using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace GameOfLifeCnsle
{
    class Program
    {
        public static int row = 40;
        public static int column = 20;

        public static int x;
        public static int y;

        public static int[,] grid = new int[row, column];
        public static int[,] updateGrid = new int[row, column];
        static void Main(string[] args)
        {
            bool ylj = true;
            int rowi;
            int columni;

            //int[,] grid = new int[row, column];

            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    grid[rowi, columni] = 0;
                    updateGrid[rowi, columni] = 0;
                }
            }

            while (ylj)
            {

                x = Input.Validator("x-coord", row + 1, 0);
                y = Input.Validator("y-coord", column + 1, 0);
                x -= 1;
                y -= 1;

                //grid[x , y + 1] = true;
                grid[x, y] = 1;
                Console.WriteLine("end?");
                string end = Console.ReadLine();
                if (end == "d")
                {
                    ylj = false;
                }
            }

            //check();
            //Iteration();


            //check(0);
            for (int val = 0; val < 4; val++)
            {


                for (int ri = 0; ri < row; ri++)
                {
                    for (int ci = 0; ci < column; ci++)
                    {
                        updateGrid[ri, ci] = grid[ri, ci];
                    }
                }
                check();
                PrintGrid(updateGrid);

                Iteration();
                PrintGrid(grid);
                //PrintGrid(updateGrid);
                //PrintGrid(grid);

                for (int ri = 0; ri < row; ri++)
                {
                    for (int ci = 0; ci < column; ci++)
                    {
                        updateGrid[ri, ci] = grid[ri, ci];
                    }
                }
            }

        }

        static void check()
        {
            for (int ri = 0; ri < row; ri++)
            {
                for (int ci = 0; ci < column; ci++)
                {
                    int i1 = -1;
                    int c1 = -1;
                    int i2 = 1;
                    int c2 = 1;
                    if (ri == 0)
                    {
                        i1 = 0;
                    }
                    if (ci == 0)
                    {
                        c1 = 0;
                    }
                    if (ri == row - 1)
                    {
                        i2 = 0;
                    }
                    if (ci == column - 1)
                    {
                        c2 = 0;
                    }
                    for (int i = i1; i <= i2; i++)
                    {
                        for (int c = c1; c <= c2; c++)
                        {
                            if (c == 0 && i == 0)
                            {
                                continue;
                            }
                            //Console.WriteLine($"{i}, {c}");
                            if (grid[ri + i, ci + c] >= 1)
                            {
                                updateGrid[ri, ci]++;

                            }
                        }
                    }
                }
            }

        }

        static void Iteration()
        {
            int previous;
            for (int ci = 0; ci < column; ci++)
            {
                for (int ri = 0; ri < row; ri++)
                {
                    previous = grid[ri, ci];
                    if (updateGrid[ri, ci] == 3)
                    {
                        grid[ri, ci] = 1;
                    }
                    else if (updateGrid[ri, ci] == 4 && previous >= 1)
                    {
                        grid[ri, ci] = 1;
                    }
                    else
                    {
                        grid[ri, ci] = 0;
                    }
                }
            }
        }


        static void PrintGrid(int[,] array)
        {
            for (int ci = 0; ci < column; ci++)
            {
                for (int ri = 0; ri < row; ri++)
                {
                    Console.Write(array[ri, ci]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

    }

    public class Input
    {
        public static int Validator(string prompt, int max, int min)
        {
            int x = 0;
            string input;
            int val = 1;
            while (val == 1)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                bool test = Int32.TryParse(input, out x);
                if (test && x < max && x > min)
                {
                    return x;
                }
            }
            return x;
        }
    }
}
