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

        public int Column = 20; // the amount of columns on the grid (invalid, as it is being set in another file)
        public int Row = 20; // the amount of rows on the grid (invalid, as it is being set in another file)

        public static int Generation = 0; // the amount of generations that have passed, default is 0
        public static int Alive = 0; // the amount of alive cells on the grid, default is 0
        public static int Delay = 200; // the delay. (invalid, as delay is taken from the slider), default is 50.

        //Button[,] btnArr = new Button[rows, columns];
        //public static Button[,] btnArr = new Button[row, column];

        //public static int[,] grid = new int[row, column];
        //public static int[,] updateGrid = new int[row, column];

        public int[,] Grid; // the original grid, that is being set by the user.
        public int[,] UpdateGrid; // the grid after it has been checked for adjacencies
        public readonly Button[,] btnArr; // the graphic representation of the grid.

        public readonly SolidColorBrush GridColour = Brushes.SteelBlue; // the variable for the colour of the grid
        public readonly SolidColorBrush AliveColour = Brushes.Firebrick; // the variable for the colour of the alive cells.


        public static int Rowi; // an iterated variable for the row for loops
        public static int Columni; // an iterated variable for the column for loops

        public MainWindow(int row, int column) // the mainwindow class, which takes column and row from another files. 
        {
            GridDef Grid_Def = new GridDef();

            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.9);
            this.Width = this.Height;
            this.MaxHeight = (System.Windows.SystemParameters.PrimaryScreenHeight);
            this.MaxWidth = (System.Windows.SystemParameters.PrimaryScreenWidth);
            this.MinHeight = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.7);
            this.MinWidth = this.MinHeight;

            this.Row = row; // sets the row variable in this file to that of the row variable from GridDef.xaml.cs
            this.Column = column; // sets the column variable in this file to that of the column variable from GridDef.xaml.cs

            this.btnArr = new Button[row, column]; // sets the size of the button array multidimentional array

            this.Grid = new int[row, column]; // sets the size of the initial grid array
            this.UpdateGrid = new int[row, column]; // sets the size of the updating grid array
            




            InitializeComponent();
            Generations.Content = $"Generation: {Generation}"; // sets the content of the generation label to that of the current value
            AliveCells.Content = $"Alive: {Alive}"; // sets the content of the AliveCells label to that of the current value
            Speed_Slider.Value = 200;


            for (Columni = 0; Columni < column; Columni++) // sets the values on the grids to zero, based on their size.
            {
                for (Rowi = 0; Rowi < row; Rowi++)
                {
                    Grid[Rowi, Columni] = 0;
                    UpdateGrid[Rowi, Columni] = 0;
                }
            }


            //Button[,] btnArr = new Button[20, 20];


            //**
            for (Columni = 0; Columni < column; Columni++) // sets up the whole auto generated button array.
            {


                for (Rowi = 0; Rowi < row; Rowi++)
                {

                    btnArr[Columni, Rowi] = new Button
                    {
                        Tag = 0,
                        //btnArr[columni, rowi].Content = btnArr[columni, rowi].Tag;
                        Background = GridColour,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(0),

                        Margin = new Thickness(0.75)
                    };


                    System.Windows.Controls.Grid.SetColumn(btnArr[Columni, Rowi], Rowi + 1);
                    System.Windows.Controls.Grid.SetRow(btnArr[Columni, Rowi], Columni + 1);
                    gridMain.Children.Add(btnArr[Columni, Rowi]);

                    btnArr[Columni, Rowi].Click += SetState;
                    //this.Height = 900;

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
                //this.Width = 900;
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
                Delay = (int)slider.Value;
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
                ToCsv(Grid));

        }

        private void SetState(object sender, RoutedEventArgs e) // sets the state of the clicked button.
        {

            Button _btn = sender as Button;

            int y = (int)_btn.GetValue(System.Windows.Controls.Grid.RowProperty);
            int x = (int)_btn.GetValue(System.Windows.Controls.Grid.ColumnProperty);
            //Console.WriteLine($"{x},{y}");


            if (Grid[y - 1, x - 1] == 1)
            {
                btnArr[y - 1, x - 1].Background = GridColour;
                btnArr[y - 1, x - 1].Tag = 0;



                Grid[y - 1, x - 1] = 0;
                btnArr[y - 1, x - 1].Tag = Grid[y - 1, x - 1];
            }
            else
            {
                btnArr[y - 1, x - 1].Background = AliveColour;
                btnArr[y - 1, x - 1].Tag = 1;

                Grid[y - 1, x - 1] = 1;
                btnArr[y - 1, x - 1].Tag = Grid[y - 1, x - 1];
            }
            
            CheckIf(Grid);

            if (Alive != 0)
            {
                this.Generator.IsEnabled = true;
                this.AutoGenerator.IsEnabled = true;
            }
            else
            {
                this.Generator.IsEnabled = false;
                this.AutoGenerator.IsEnabled = false;
                Val = false;
            }

        }
        public void Generate(object sender, RoutedEventArgs e) // runs all of the logic to generate the next generation based on the user input.
        {
            for (int ri = 0; ri < Row; ri++)
            {
                for (int ci = 0; ci < Column; ci++)
                {
                    UpdateGrid[ri, ci] = Grid[ri, ci];
                }
            }

            GOLlogic.Check(this);

            GOLlogic.Iteration(this);
            CheckIf(Grid);


            Generation++;
            Generations.Content = $"Generation: {Generation}";

            if (Alive != 0)
            {
                this.Generator.IsEnabled = true;
                this.AutoGenerator.IsEnabled = true;
            }
            else
            {
                this.Generator.IsEnabled = false;
                this.AutoGenerator.IsEnabled = false;
                Val = false;
            }

            //GOLlogic.PrintGrid(grid);

            //GOLlogic.Iteration();
            //GOLlogic.PrintGrid(grid);



            for (int i = 0; i < Row; i++)
            {
                for (int c = 0; c < Column; c++)
                {

                    btnArr[i, c].Tag = Grid[i, c];
                    //btnArr[i, c].Content = btnArr[i, c].Tag;
                    UpdateGrid[i, c] = Grid[i, c];
                    if (Convert.ToInt32(btnArr[i, c].Tag) >= 1)
                    {
                        btnArr[i, c].Background = AliveColour;   // SolidColorBrush squareColor= Brushes.Firebrick;
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
            Alive = 0;
            for (int i = 0; i < Row; i++)
            {
                for (int c = 0; c < Column; c++)
                {
                    if (array[i, c] == 1)
                    {
                        Alive++;

                    }
                    AliveCells.Content = $"Alive: {Alive}";

                }
            }
        }
        private void ShowRules(object sender, RoutedEventArgs e)
        {
            Rules nW = new Rules();
            nW.Show();
        }
        private void GridSize_Click(object sender, RoutedEventArgs e)
        {
            GridDef sW = new GridDef();
            sW.Show();
            this.Close();
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

            for (Columni = 0; Columni < Column; Columni++)
            {
                for (Rowi = 0; Rowi < Row; Rowi++)
                {
                    btnArr[Rowi, Columni].Tag = 0;
                    //btnArr[rowi, columni].Content = btnArr[rowi, columni].Tag;
                    btnArr[Rowi, Columni].Background = GridColour;
                    UpdateGrid[Rowi, Columni] = 0;
                    Grid[Rowi, Columni] = 0;
                }
            }
            Generation = 0;
            Generations.Content = $"Generation: {Generation}";
            Speed_Slider.Value = 200;
            CheckIf(Grid);
            if (Alive != 0)
            {
                this.Generator.IsEnabled = true;
                this.AutoGenerator.IsEnabled = true;
            }
            else
            {
                this.Generator.IsEnabled = false;
                this.AutoGenerator.IsEnabled = false;
                Val = false;
            }

        }
        public static bool Val = false; // a value to allow the loop to run until the button is pressed again.
        private async void Auto(object sender, RoutedEventArgs e) // Runs the program whilst it is toggled, 
        {

            Val = !Val;

            if(Generation == 0)
            {
                var curDir = Directory.GetCurrentDirectory();
                File.WriteAllLines($"{curDir}/data.csv",
                    ToCsv(Grid));
            }

            while (Val)
            {
                AutoGenerator.Background = Brushes.Orange;

                Generate(this, e);


                Delay = Convert.ToInt32(Speed_Slider.Value);


                await Task.Delay(Delay);

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
            for (int i = 0; i < Column; i++)
            {
                for (int c = 0; c < Row; c++)
                {
                    Grid[i, c] = second[i, c];
                    btnArr[i, c].Tag = Grid[i, c];

                    if (Convert.ToInt32(btnArr[i, c].Tag) >= 1)
                    {
                        btnArr[i, c].Background = AliveColour;
                    }
                }
            }

            GOLlogic.Check(this);
            CheckIf(Grid);

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
            for (int ri = 0; ri < mainWindow.Row; ri++)
            {
                for (int ci = 0; ci < mainWindow.Column; ci++)
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
                    if (ri == mainWindow.Row - 1)
                    {
                        i2 = 0;
                    }
                    if (ci == mainWindow.Column - 1)
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

                            if (mainWindow.Grid[ri + i, ci + c] >= 1)
                            {
                                mainWindow.UpdateGrid[ri, ci]++;

                            }
                        }
                    }
                }
            }

        }

        public static void Iteration(MainWindow mainWindow)
        {
            int previous;
            for (int ci = 0; ci < mainWindow.Column; ci++)
            {
                for (int ri = 0; ri < mainWindow.Row; ri++)
                {
                    previous = mainWindow.Grid[ri, ci];
                    if (mainWindow.UpdateGrid[ri, ci] == 3)
                    {
                        mainWindow.Grid[ri, ci] = 1;
                    }
                    else if (mainWindow.UpdateGrid[ri, ci] == 4 && previous >= 1)
                    {
                        mainWindow.Grid[ri, ci] = 1;
                    }
                    else
                    {
                        mainWindow.Grid[ri, ci] = 0;
                    }
                }
            }
        }

        public static void PrintGrid(int[,] array, MainWindow mainWindow)
        {
            for (int ci = 0; ci < mainWindow.Column; ci++)
            {
                for (int ri = 0; ri < mainWindow.Row; ri++)
                {
                    Console.Write(array[ri, ci]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

    }


}