using System.Windows;
using System.Windows.Controls;

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for GridDef.xaml
    /// </summary>
    public partial class GridDef : Window
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public GridDef()
        {
            InitializeComponent();



        }
        private void GridSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                this.Column = (int)slider.Value;
                this.Row = (int)slider.Value;
                //Debug.WriteLine(this.row);
            }
        }


        public void CloseWindow(object sender, RoutedEventArgs e)
        {

            MainWindow Main = new MainWindow(Row, Column);


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