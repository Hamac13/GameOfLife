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
            

            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    
                    
                    check(rowi, columni);
                    //grid = updateGrid;
                    CopyArray();
                    if (grid[rowi, columni] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        
                        
                        Console.Write(grid[rowi, columni]);

                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            Console.Write("\n");

            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    Console.Write(updateGrid[rowi, columni]);
                }
                Console.Write("\n");
            }

        }

        static void check(int rowi, int columni)
        {
            int i1 = -1;
            int c1 = -1;
            int i2 = 1;
            int c2 = 1;

            if (rowi == 0)
            {
                i1 = 0;
            }
            if (columni == 0)
            {
                c1 = 0;
            }
            if (rowi == row - 1)
            {
                i2 = 0;
            }
            if (columni == column - 1)
            {
                c2 = 0;
            }           
            for (int i = i1; i <= i2; i++)
            {
                for (int c = c1; c <= c2; c++)
                {
                    if (grid[rowi + i, columni + c] > 0)
                    {
                        updateGrid[rowi, columni]++;
                    }
                }
            }
        }

        static void iteration(int rowi, int columni)
        {
            
        }

        static void CopyArray()
        {
            for (int columni = 0; columni < column; columni++)
            {
                for (int rowi = 0; rowi < row; rowi++)
                {
                    grid[rowi, columni] = updateGrid[rowi, columni];
                }
            }
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
