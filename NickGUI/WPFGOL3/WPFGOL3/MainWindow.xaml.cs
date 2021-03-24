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
        static int column = 20;
        static int row = 20;

        //Button[,] btnArr = new Button[rows, columns];
        Button[,] btnArr = new Button[row, column];
        
        int rowi;
        int columni;

        public MainWindow()
        {
            InitializeComponent();

            
            

            //Button[,] btnArr = new Button[20, 20];
            

            for (columni = 0; columni < column; columni++)
            {
                for (rowi = 0; rowi < row; rowi++)
                {
                    btnArr[columni, rowi] = new Button();
                    int y = Grid.GetRow(btnArr[columni, rowi]);
                    int x = Grid.GetColumn(btnArr[columni, rowi]);
                    btnArr[columni, rowi].Tag = 0;
                    btnArr[columni, rowi].Content = btnArr[columni,rowi].Tag;
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
        private void closeWindow (object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private /*Tuple<int,int>*/ void setState (object sender, RoutedEventArgs e)
        {

            Button _btn = sender as Button;

            int y = (int)_btn.GetValue(Grid.RowProperty);
            int x = (int)_btn.GetValue(Grid.ColumnProperty);
            Console.WriteLine($"{x},{y}");



            btnArr[y - 1, x - 1].Background = Brushes.Firebrick;
            btnArr[y - 1, x - 1].Content = 1;
            
            //return Tuple.Create(x, y);
            
            
        }
        private void generate(object sender, RoutedEventArgs e)
        {
            Button _btn = sender as Button;
            int y = (int)_btn.GetValue(Grid.RowProperty);
            int x = (int)_btn.GetValue(Grid.ColumnProperty);


            Console.WriteLine($"{x},{y}");
            btnArr[y + 1, x + 1].Background = Brushes.Firebrick;
            btnArr[y + 1, x + 1].Content = 1;
        }
        private void reset(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Fuckin shitty");
            for (columni = 0; columni < 20; columni++)
            {
                for (rowi = 0; rowi < 20; rowi++)
                {
                    btnArr[rowi, columni].Content = 0;
                    btnArr[rowi, columni].Tag = 0;
                    btnArr[rowi, columni].Background = Brushes.SteelBlue;
                }
            }

        }
    }
    public class GOLlogic 
    { 
        public GOLlogic() { }
        



        static void check()
        {
            int i1 = -1;
            int c1 = -1;
            int i2 = 1;
            int c2 = 1;
           
            for (int ri = 0; ri < row; ri++)
            {
                for (int ci = 0; ci < column; ci++)
                {
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
                            if (grid[ri + i, ci + c] > 0)
                            {
                                updateGrid[ri, ci]++;
                            }
                        }
                    }
                }
            }
        }
        
    }

    
}
        

    



    
    

