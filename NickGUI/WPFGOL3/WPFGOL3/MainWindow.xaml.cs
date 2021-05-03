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

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for GridDef.xaml
    /// </summary>
    public partial class GridDef : Window
    {
        
        public GridDef()
        {
            InitializeComponent();
            
            
            

        }
        
        public void closeWindow(object sender, RoutedEventArgs e)
        {

            MainWindow Main = new MainWindow();
            

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