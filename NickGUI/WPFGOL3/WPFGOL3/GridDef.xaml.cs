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
using System.Windows.Shapes;
using System.Diagnostics;

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for GridDef.xaml
    /// </summary>
    public partial class GridDef : Window
    {
        public int row { get; set; }
        public int column { get; set; }

        public GridDef()
        {
            InitializeComponent();
            
            

        }
        private void GridSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            Slider slider = sender as Slider;

            if (slider != null)
            {
                this.column = (int)slider.Value;
                this.row = (int)slider.Value;
                Debug.WriteLine(this.row);
            }
        }


        public void closeWindow(object sender, RoutedEventArgs e)
        {
            
            MainWindow Main = new MainWindow(row,column);


            Main.Show();

            this.Close();




        }

        //private void setRow(object sender, RoutedEventArgs e)
        //{

        //}
        //private void setColumn(object sender, RoutedEventArgs e)
        //{

        //}

    }
}