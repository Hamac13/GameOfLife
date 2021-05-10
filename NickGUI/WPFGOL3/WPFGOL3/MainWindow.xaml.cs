using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public GridDef Grid_Def = new GridDef();

        public int column = 20;
        public int row = 20;

        public static int generation = 0;
        public static int alive = 0;
        public static int speed = 200;

        //Button[,] btnArr = new Button[rows, columns];
        //public static Button[,] btnArr = new Button[row, column];

        //public static int[,] grid = new int[row, column];
        //public static int[,] updateGrid = new int[row, column];

        public int[,] grid;
        public int[,] updateGrid;
        Button[,] btnArr;

        public static int rowi;
        public static int columni;

        public MainWindow(int row, int column)
        {
            GridDef Grid_Def = new GridDef();
            this.row = row;
            this.column = column;

            this.btnArr = new Button[row, column];

            this.grid = new int[row, column];
            this.updateGrid = new int[row, column];


            
            //Grid_Def.Visibility = Visibility.Hidden;

            InitializeComponent();
            Generations.Content = $"Generation: {generation}";
            AliveCells.Content = $"Alive: {alive}";
            


            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    grid[rowi, columni] = 0;
                    updateGrid[rowi, columni] = 0;
                }
            }


            //Button[,] btnArr = new Button[20, 20];



            for (columni = 0; columni < column; columni++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                RowDefinition rowDef = new RowDefinition();

                for (rowi = 0; rowi < row; rowi++)
                {

                    btnArr[columni, rowi] = new Button();

                    btnArr[columni, rowi].Tag = 0;
                    //btnArr[columni, rowi].Content = btnArr[columni, rowi].Tag;
                    btnArr[columni, rowi].Background = Brushes.SteelBlue;
                    btnArr[columni, rowi].BorderBrush = Brushes.Black;
                    btnArr[columni, rowi].BorderThickness = new Thickness(1);

                    btnArr[columni, rowi].Margin = new Thickness(0.3);


                    Grid.SetColumn(btnArr[columni, rowi], rowi + 1);
                    Grid.SetRow(btnArr[columni, rowi], columni + 1);
                    gridMain.Children.Add(btnArr[columni, rowi]);

                    btnArr[columni, rowi].Click += setState;


                    //Console.WriteLine($"{x},{y}");

                }

                colDef.Width = new GridLength(2, GridUnitType.Star);
                rowDef.Height = new GridLength(2, GridUnitType.Star);
                gridMain.RowDefinitions.Add(rowDef);
                gridMain.ColumnDefinitions.Add(colDef);
            }
            RowDefinition rowDef2 = new RowDefinition();
            rowDef2.Height = new GridLength(2, GridUnitType.Star);
            gridMain.RowDefinitions.Add(rowDef2);
            ColumnDefinition colDef2 = new ColumnDefinition();
            colDef2.Width = new GridLength(2, GridUnitType.Star);
            gridMain.ColumnDefinitions.Add(colDef2);





            //for (int i = 0; i < 20; i++)
            //{
            //    for (int c = 0; c < 20; c++)
            //    {



            //    }
            //}
        }
        private void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            Slider slider = sender as Slider;

            if (slider != null)
            {
                speed = (int)slider.Value;
                //Debug.WriteLine(this.row);
            }
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            GridDef Grid_Def = new GridDef();
            string exitMessage = "Application is closing, please press OK.";
            string exitTitle = "Application Closing";
            MessageBox.Show(exitMessage, exitTitle);
            //this.Close();
            Application.Current.Shutdown();
            //Grid_Def.Close();
        }
        private void save(object sender, RoutedEventArgs e)
        {
            string message = "Grid Saving (Grid is saved to the current directory of the .exe)";
            string title = "Saving...";
            MessageBox.Show(message, title);
            var curDir = Directory.GetCurrentDirectory();
            File.WriteAllLines($"{curDir}/data.csv",
                ToCsv(grid));

        }
        private /*Tuple<int,int>*/ void setState(object sender, RoutedEventArgs e)
        {

            Button _btn = sender as Button;

            int y = (int)_btn.GetValue(Grid.RowProperty);
            int x = (int)_btn.GetValue(Grid.ColumnProperty);
            //Console.WriteLine($"{x},{y}");


            if (grid[y - 1, x - 1] == 1)
            {
                btnArr[y - 1, x - 1].Background = Brushes.SteelBlue;
                btnArr[y - 1, x - 1].Tag = 0;



                grid[y - 1, x - 1] = 0;
                btnArr[y - 1, x - 1].Tag = grid[y - 1, x - 1];
            }
            else
            {
                btnArr[y - 1, x - 1].Background = Brushes.Firebrick;
                btnArr[y - 1, x - 1].Tag = 1;

                grid[y - 1, x - 1] = 1;
                btnArr[y - 1, x - 1].Tag = grid[y - 1, x - 1];
            }
            //return Tuple.Create(x, y);
            CheckIf(grid);


        }
        public void generate(object sender, RoutedEventArgs e)
        {
            for (int ri = 0; ri < row; ri++)
            {
                for (int ci = 0; ci < column; ci++)
                {
                    updateGrid[ri, ci] = grid[ri, ci];
                }
            }

            GOLlogic.check(this);

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
                        btnArr[i, c].Background = Brushes.Firebrick;
                    }
                    if (Convert.ToInt32(btnArr[i, c].Tag) == 0)
                    {
                        btnArr[i, c].Background = Brushes.SteelBlue;
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

        public void CheckIf(int[,] array)
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

        private void reset(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Fuckin shitty");
            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    btnArr[rowi, columni].Tag = 0;
                    //btnArr[rowi, columni].Content = btnArr[rowi, columni].Tag;
                    btnArr[rowi, columni].Background = Brushes.SteelBlue;
                    updateGrid[rowi, columni] = 0;
                    grid[rowi, columni] = 0;
                }
            }
            generation = 0;
            Generations.Content = $"Generation: {generation}";
            CheckIf(grid);

        }
        public static bool val = false;
        private async void auto(object sender, RoutedEventArgs e)
        {

            val = !val;
            while (val)
            {
                autoGenerator.Background = Brushes.Orange;

                generate(this, e);
                

                int speed = Convert.ToInt32(Speed_Slider.Value);
                

                await Task.Delay(speed);

            }
            autoGenerator.Background = Brushes.LightGray;


        }
        private void load(object sender, RoutedEventArgs e)
        {
            string loadMessage = "The program has loaded the contents of the saved csv";
            string loadTitle = "Loading......................";
            MessageBox.Show(loadMessage, loadTitle);


            loader(this, e);

        }
        public void loader(object sender, RoutedEventArgs e)
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
                    int number;
                    bool ok = int.TryParse(temp1[j, i], out number);
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
                        btnArr[i, c].Background = Brushes.Firebrick;
                    }
                }
            }

            GOLlogic.check(this);
            CheckIf(grid);

        }
        public static T[,] To2D<T>(T[][] source)
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
        public static void check(MainWindow mainWindow)
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