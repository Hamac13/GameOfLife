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

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static int column = 20;
        public static int row = 20;

        //Button[,] btnArr = new Button[rows, columns];
        public static Button[,] btnArr = new Button[row, column];
        public static int[,] grid = new int[row, column];
        public static int[,] updateGrid = new int[row, column];

        public static int rowi;
        public static int columni;

        public MainWindow()
        {
            InitializeComponent();

            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {

                    updateGrid[rowi, columni] = 0;
                }
            }


            //Button[,] btnArr = new Button[20, 20];


            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    btnArr[columni, rowi] = new Button();
                    int y = Grid.GetRow(btnArr[columni, rowi]);
                    int x = Grid.GetColumn(btnArr[columni, rowi]);
                    btnArr[columni, rowi].Tag = 0;
                    btnArr[columni, rowi].Content = btnArr[columni, rowi].Tag;
                    btnArr[columni, rowi].Background = Brushes.SteelBlue;
                    btnArr[columni, rowi].Name = "Button" + y.ToString() + x.ToString();

                    Grid.SetColumn(btnArr[columni, rowi], rowi + 1);
                    Grid.SetRow(btnArr[columni, rowi], columni + 1);
                    gridMain.Children.Add(btnArr[columni, rowi]);

                    btnArr[columni, rowi].Click += setState;

                    //Console.WriteLine($"{x},{y}");

                }
            }


            //for (int i = 0; i < 20; i++)
            //{
            //    for (int c = 0; c < 20; c++)
            //    {



            //    }
            //}
        }
        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private /*Tuple<int,int>*/ void setState(object sender, RoutedEventArgs e)
        {

            Button _btn = sender as Button;

            int y = (int)_btn.GetValue(Grid.RowProperty);
            int x = (int)_btn.GetValue(Grid.ColumnProperty);
            //Console.WriteLine($"{x},{y}");



            btnArr[y - 1, x - 1].Background = Brushes.Firebrick;
            btnArr[y - 1, x - 1].Content = 1;
            
            grid[y - 1, x - 1] = 1;
            btnArr[y - 1, x - 1].Tag = 1;

            //return Tuple.Create(x, y);


        }
        private void generate(object sender, RoutedEventArgs e)
        {
            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {

                    GOLlogic.check(rowi, columni);
                    

                }
            }


            grid = updateGrid;
            //GOLlogic.PrintGrid(grid);

            //GOLlogic.Iteration();
            GOLlogic.PrintGrid(grid);

            

            for (int i = 0; i < 20; i++)
            {
                for (int c = 0; c < 20; c++)
                {

                    btnArr[i, c].Tag = grid[i, c];
                    btnArr[i, c].Content = btnArr[i, c].Tag;
                    updateGrid[i, c] = 0;
                    


                }
            }

            //Button _btn = sender as Button;
            //int y = (int)_btn.GetValue(Grid.RowProperty);
            //int x = (int)_btn.GetValue(Grid.ColumnProperty);


            //Console.WriteLine($"{x},{y}");
            //btnArr[y + 1, x + 1].Background = Brushes.Firebrick;
            //btnArr[y + 1, x + 1].Content = 1;


        }
        private void reset(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Fuckin shitty");
            for (columni = 0; columni < 20; columni++)
            {
                for (rowi = 0; rowi < 20; rowi++)
                {
                    btnArr[rowi, columni].Tag = 0;
                    btnArr[rowi, columni].Content = btnArr[rowi, columni].Tag;
                    btnArr[rowi, columni].Background = Brushes.SteelBlue;
                    updateGrid[rowi, columni] = 0;
                    grid[rowi, columni] = 0;
                }
            }

        }
    }
    public class GOLlogic
    {
        public GOLlogic() { }
        public static void check()
        {
            for (int ri = 0; ri < MainWindow.row; ri++)
            {
                for (int ci = 0; ci < MainWindow.column; ci++)
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
                    if (ri == MainWindow.row - 1)
                    {
                        i2 = 0;
                    }
                    if (ci == MainWindow.column - 1)
                    {
                        c2 = 0;
                    }
                    for (int i = i1; i <= i2; i++)
                    {
                        for (int c = c1; c <= c2; c++)
                        {
                            //Console.WriteLine($"{i}, {c}");
                            if (MainWindow.grid[ri + i, ci + c] >= 1)
                            {
                                MainWindow.updateGrid[ri, ci]++;

                            }
                        }
                    }
                }
            }

        }

        public static void Iteration()
        {

            for (int ci = 0; ci < MainWindow.column; ci++)
            {
                for (int ri = 0; ri < MainWindow.row; ri++)
                {
                    if (3 < MainWindow.updateGrid[ri, ci] && MainWindow.updateGrid[ri, ci] <= 5)
                    {
                        MainWindow.grid[ri, ci] = 1;
                    }
                    else
                    {
                        MainWindow.grid[ri, ci] = 0;
                    }
                }
            }
        }

        public static void PrintGrid(int[,] array)
        {
            for (int ci = 0; ci < MainWindow.column; ci++)
            {
                for (int ri = 0; ri < MainWindow.row; ri++)
                {
                    Console.Write(array[ri, ci]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

    }


}









