using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public GridDef Grid_Def = new GridDef();

        public int column = 20; // the amount of columns on the grid (invalid, as it is being set in another file)
        public int row = 20; // the amount of rows on the grid (invalid, as it is being set in another file)

        public static int generation = 0; // the amount of generations that have passed, default is 0
        public static int alive = 0; // the amount of alive cells on the grid, default is 0
        public static int speed = 200; // the delay. (invalid, as delay is taken from the slider), default is 50.

        //Button[,] btnArr = new Button[rows, columns];
        //public static Button[,] btnArr = new Button[row, column];

        //public static int[,] grid = new int[row, column];
        //public static int[,] updateGrid = new int[row, column];

        public int[,] grid; // the original grid, that is being set by the user.
        public int[,] updateGrid; // the grid after it has been checked for adjacencies
        readonly Button[,] btnArr; // the graphic representation of the grid.

        readonly SolidColorBrush GridColour = Brushes.SteelBlue; // the variable for the colour of the grid
        readonly SolidColorBrush AliveColour = Brushes.Firebrick; // the variable for the colour of the alive cells.


        public static int rowi; // an iterated variable for the row for loops
        public static int columni; // an iterated variable for the column for loops

        public MainWindow(int row, int column) // the mainwindow class, which takes column and row from another files. 
        {
            GridDef Grid_Def = new GridDef();
            this.row = row; // sets the row variable in this file to that of the row variable from GridDef.xaml.cs
            this.column = column; // sets the column variable in this file to that of the column variable from GridDef.xaml.cs

            this.btnArr = new Button[row, column]; // sets the size of the button array multidimentional array

            this.grid = new int[row, column]; // sets the size of the initial grid array
            this.updateGrid = new int[row, column]; // sets the size of the updating grid array





            InitializeComponent();
            Generations.Content = $"Generation: {generation}"; // sets the content of the generation label to that of the current value
            AliveCells.Content = $"Alive: {alive}"; // sets the content of the AliveCells label to that of the current value



            for (columni = 0; columni < column; columni++) // sets the values on the grids to zero, based on their size.
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    grid[rowi, columni] = 0;
                    updateGrid[rowi, columni] = 0;
                }
            }


            //Button[,] btnArr = new Button[20, 20];


            //**
            for (columni = 0; columni < column; columni++) // sets up the whole auto generated button array.
            {


                for (rowi = 0; rowi < row; rowi++)
                {

                    btnArr[columni, rowi] = new Button
                    {
                        Tag = 0,
                        //btnArr[columni, rowi].Content = btnArr[columni, rowi].Tag;
                        Background = GridColour,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),

                        Margin = new Thickness(0.3)
                    };


                    Grid.SetColumn(btnArr[columni, rowi], rowi + 1);
                    Grid.SetRow(btnArr[columni, rowi], columni + 1);
                    gridMain.Children.Add(btnArr[columni, rowi]);

                    btnArr[columni, rowi].Click += SetState;


                    //Console.WriteLine($"{x},{y}");

                }
                ColumnDefinition colDef = new ColumnDefinition
                {
                    Width = new GridLength(2, GridUnitType.Star)
                };
                gridMain.ColumnDefinitions.Add(colDef);
                RowDefinition rowDef = new RowDefinition
                {
                    Height = new GridLength(2, GridUnitType.Star)
                };
                gridMain.RowDefinitions.Add(rowDef);

            }
            RowDefinition rowDef2 = new RowDefinition
            {
                Height = new GridLength(2, GridUnitType.Star)
            };
            gridMain.RowDefinitions.Add(rowDef2);
            ColumnDefinition colDef2 = new ColumnDefinition
            {
                Width = new GridLength(2, GridUnitType.Star)
            };
            gridMain.ColumnDefinitions.Add(colDef2);





            //for (int i = 0; i < 20; i++)
            //{
            //    for (int c = 0; c < 20; c++)
            //    {



            //    }
            //}
        }
        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // changes values based on the slider.
        {
            if (sender is Slider slider)
            {
                speed = (int)slider.Value;
                //Debug.WriteLine(this.row);
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e) // closes all current windows when pressed.
        {

            string exitMessage = "Application is closing, please press OK.";
            string exitTitle = "Application Closing";
            MessageBox.Show(exitMessage, exitTitle);
            //this.Close();
            Application.Current.Shutdown();
            //Grid_Def.Close();
        }
        private void Save(object sender, RoutedEventArgs e) // saves the current grid to a csv
        {
            string message = "Grid Saving (Grid is saved to the current directory of the .exe)";
            string title = "Saving...";
            MessageBox.Show(message, title);
            var curDir = Directory.GetCurrentDirectory();
            File.WriteAllLines($"{curDir}/data.csv",
                ToCsv(grid));

        }

        private void SetState(object sender, RoutedEventArgs e) // sets the state of the clicked button.
        {

            Button _btn = sender as Button;

            int y = (int)_btn.GetValue(Grid.RowProperty);
            int x = (int)_btn.GetValue(Grid.ColumnProperty);
            //Console.WriteLine($"{x},{y}");


            if (grid[y - 1, x - 1] == 1)
            {
                btnArr[y - 1, x - 1].Background = GridColour;
                btnArr[y - 1, x - 1].Tag = 0;



                grid[y - 1, x - 1] = 0;
                btnArr[y - 1, x - 1].Tag = grid[y - 1, x - 1];
            }
            else
            {
                btnArr[y - 1, x - 1].Background = AliveColour;
                btnArr[y - 1, x - 1].Tag = 1;

                grid[y - 1, x - 1] = 1;
                btnArr[y - 1, x - 1].Tag = grid[y - 1, x - 1];
            }
            //return Tuple.Create(x, y);
            CheckIf(grid);


        }
        public void Generate(object sender, RoutedEventArgs e) // runs all of the logic to generate the next generation based on the user input.
        {
            for (int ri = 0; ri < row; ri++)
            {
                for (int ci = 0; ci < column; ci++)
                {
                    updateGrid[ri, ci] = grid[ri, ci];
                }
            }

            GOLlogic.Check(this);

            GOLlogic.Iteration(this);
            CheckIf(grid);


            generation++;
            Generations.Content = $"Generation: {generation}";

            //GOLlogic.PrintGrid(grid);

            //GOLlogic.Iteration();
            //GOLlogic.PrintGrid(grid);



            for (int i = 0; i < row; i++)
            {
                for (int c = 0; c < column; c++)
                {

                    btnArr[i, c].Tag = grid[i, c];
                    //btnArr[i, c].Content = btnArr[i, c].Tag;
                    updateGrid[i, c] = grid[i, c];
                    if (Convert.ToInt32(btnArr[i, c].Tag) >= 1)
                    {
                        btnArr[i, c].Background = AliveColour;   /// SolidColorBrush squareColor= Brushes.Firebrick;
                    }
                    if (Convert.ToInt32(btnArr[i, c].Tag) == 0)
                    {
                        btnArr[i, c].Background = GridColour;
                    }



                }
            }

            //Button _btn = sender as Button;
            //int y = (int)_btn.GetValue(Grid.RowProperty);
            //int x = (int)_btn.GetValue(Grid.ColumnProperty);


            //Console.WriteLine($"{x},{y}");
            //btnArr[y + 1, x + 1].Background = Brushes.Firebrick;
            //btnArr[y + 1, x + 1].Content = 1;


        }

        public void CheckIf(int[,] array) // Checks whether the value of the array used is one, and adds one to the alive variable.
        {
            alive = 0;
            for (int i = 0; i < row; i++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (array[i, c] == 1)
                    {
                        alive++;

                    }
                    AliveCells.Content = $"Alive: {alive}";

                }
            }
        }

        public static IEnumerable<String> ToCsv<T>(T[,] data, string separator = ",") //borrowed from StackOverflow
        {
            for (int i = 0; i < data.GetLength(0); ++i)
                yield return string.Join(separator, Enumerable
                  .Range(0, data.GetLength(1))
                  .Select(j => data[i, j])); // simplest, we don't expect ',' and '"' in the items
        }

        private void ResetGrid(object sender, RoutedEventArgs e) // resets all values on the display
        {

            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    btnArr[rowi, columni].Tag = 0;
                    //btnArr[rowi, columni].Content = btnArr[rowi, columni].Tag;
                    btnArr[rowi, columni].Background = GridColour;
                    updateGrid[rowi, columni] = 0;
                    grid[rowi, columni] = 0;
                }
            }
            generation = 0;
            Generations.Content = $"Generation: {generation}";
            CheckIf(grid);

        }
        public static bool val = false; // a value to allow the loop to run until the button is pressed again.
        private async void Auto(object sender, RoutedEventArgs e) // Runs the program whilst it is toggled, 
        {

            val = !val;
            while (val)
            {
                AutoGenerator.Background = Brushes.Orange;

                Generate(this, e);


                int speed = Convert.ToInt32(Speed_Slider.Value);


                await Task.Delay(speed);

            }
            AutoGenerator.Background = Brushes.LightGray;

            
        }
        public void LoadCSV(object sender, RoutedEventArgs e) // runs the loader function, and displays a message box.
        {
            string loadMessage = "The program has loaded the contents of the saved csv";
            string loadTitle = "Loading......................";
            MessageBox.Show(loadMessage, loadTitle);


            Loader(this, e);

        }
        public void Loader(object sender, RoutedEventArgs e) // Runs code that loads the file and sets the loaded content to a 2d array from a jagged array.
        {
            var curDir = Directory.GetCurrentDirectory();
            var filePath = $"{curDir}/data.csv";
            string[][] temp = File.ReadLines(filePath)
                          .Select(line => line.Split(','))
                          .ToArray();
            var temp1 = To2D(temp);
            int[,] second = new int[temp1.GetLength(0), temp1.GetLength(1)];

            for (int j = 0; j < temp1.GetLength(0); j++)
            {
                for (int i = 0; i < temp1.GetLength(1); i++)
                {
                    bool ok = int.TryParse(temp1[j, i], out int number);
                    if (ok)
                    {
                        second[j, i] = number;
                    }
                    else
                    {
                        second[j, i] = 0;
                    }
                }
            }
            for (int i = 0; i < column; i++)
            {
                for (int c = 0; c < row; c++)
                {
                    grid[i, c] = second[i, c];
                    btnArr[i, c].Tag = grid[i, c];

                    if (Convert.ToInt32(btnArr[i, c].Tag) >= 1)
                    {
                        btnArr[i, c].Background = AliveColour;
                    }
                }
            }

            GOLlogic.Check(this);
            CheckIf(grid);

        }
        public static T[,] To2D<T>(T[][] source) // taken from stackOverflow, used to convert from jagged array to 2D array.
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }

    }
    public class GOLlogic
    {
        public GOLlogic() { }
        public static void Check(MainWindow mainWindow)
        {
            for (int ri = 0; ri < mainWindow.row; ri++)
            {
                for (int ci = 0; ci < mainWindow.column; ci++)
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
                    if (ri == mainWindow.row - 1)
                    {
                        i2 = 0;
                    }
                    if (ci == mainWindow.column - 1)
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

                            if (mainWindow.grid[ri + i, ci + c] >= 1)
                            {
                                mainWindow.updateGrid[ri, ci]++;

                            }
                        }
                    }
                }
            }

        }

        public static void Iteration(MainWindow mainWindow)
        {
            int previous;
            for (int ci = 0; ci < mainWindow.column; ci++)
            {
                for (int ri = 0; ri < mainWindow.row; ri++)
                {
                    previous = mainWindow.grid[ri, ci];
                    if (mainWindow.updateGrid[ri, ci] == 3)
                    {
                        mainWindow.grid[ri, ci] = 1;
                    }
                    else if (mainWindow.updateGrid[ri, ci] == 4 && previous >= 1)
                    {
                        mainWindow.grid[ri, ci] = 1;
                    }
                    else
                    {
                        mainWindow.grid[ri, ci] = 0;
                    }
                }
            }
        }

        public static void PrintGrid(int[,] array, MainWindow mainWindow)
        {
            for (int ci = 0; ci < mainWindow.column; ci++)
            {
                for (int ri = 0; ri < mainWindow.row; ri++)
                {
                    Console.Write(array[ri, ci]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

    }


}