using System.Windows;

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for Opening.xaml
    /// </summary>
    public partial class Opening : Window
    {
        public Opening()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridDef sW = new GridDef();
            sW.Show();
            this.Close();
        }
    }
}
