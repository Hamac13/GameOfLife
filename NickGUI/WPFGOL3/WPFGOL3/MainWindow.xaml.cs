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
        public MainWindow()
        {
            InitializeComponent();

            Button[,] btnArr = new Button[20, 20];

            for (int i = 0; i < 20; i++)
            {
                for (int c = 0; c < 20; c++)
                {
                    btnArr[i, c] = new Button();
                    btnArr[i, c].Tag = 0;
                    btnArr[i, c].Content = btnArr[i,c].Tag;
                    btnArr[i, c].Name = "Button" + i.ToString() + c.ToString();
                    Grid.SetColumn(btnArr[i, c], c + 1);
                    Grid.SetRow(btnArr[i, c], i + 1);
                    gridMain.Children.Add(btnArr[i, c]);
                }
            }
        }
    }
}
