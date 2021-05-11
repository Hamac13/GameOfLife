using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using System;

namespace WPFGOL3
{
    /// <summary>
    /// Interaction logic for GridDef.xaml
    /// </summary>
    public partial class GridDef : Window
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public SolidColorBrush GetAliveColour { get; set; }
        public SolidColorBrush GetGridColour { get; set; }
        

        public GridDef()
        {
            InitializeComponent();
            SolidColorBrush CurrentActiveCell = GetAliveColour;
            SolidColorBrush CurrentBackground = GetGridColour;
            BackgroundColour.Fill = CurrentBackground;
            ActiveCell.Fill = CurrentActiveCell;


        }
        private void GridSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // This controls the value of the grid size label taken from the slider.
        {
            if (sender is Slider slider)
            {
                this.Column = (int)slider.Value;
                this.Row = (int)slider.Value;
                //Debug.WriteLine(this.row);
            }
        }


        public void CloseWindow(object sender, RoutedEventArgs e) // this closes the window when the click to continue button is pressed. It opens the main grid.
        {

            MainWindow Main = new MainWindow(Row, Column, GetAliveColour, GetGridColour);


            Main.Show();

            this.Close();




        }

        public void GridColourSet_SelectionChanged(object sender, SelectionChangedEventArgs e) // Controls the colour of the grid and the previews.
        {
            
            
            if (GridColourSet.SelectedItem == Default) // The default theme
            {
                //Debug.WriteLine("test");
                this.GetAliveColour = Brushes.Firebrick;
                this.GetGridColour = Brushes.SteelBlue;
                //if (GetGridColour == Brushes.SteelBlue && GetAliveColour == Brushes.Firebrick)
                //{
                //    ActiveCell.Fill = Brushes.Firebrick;
                //    BackgroundColour.Fill = Brushes.SteelBlue;
                //}
                // The above statement does not work, as for whatever reason the rectangles that are being filled will return null
            }
            if (GridColourSet.SelectedItem == Inverted) // The default theme, but inverted.
            {
                this.GetAliveColour = Brushes.SteelBlue;
                this.GetGridColour = Brushes.Firebrick;
                if (GetGridColour == Brushes.Firebrick && GetAliveColour == Brushes.SteelBlue)
                {
                    ActiveCell.Fill = Brushes.SteelBlue;
                    BackgroundColour.Fill = Brushes.Firebrick;
                }
            }
            if(GridColourSet.SelectedItem == Lite) // The lite theme, a lighter version of the default
            {
                this.GetAliveColour = Brushes.IndianRed;
                this.GetGridColour = Brushes.LightSteelBlue;
                if (GetGridColour == Brushes.LightSteelBlue && GetAliveColour == Brushes.IndianRed)
                {
                    ActiveCell.Fill = Brushes.IndianRed;
                    BackgroundColour.Fill = Brushes.LightSteelBlue;
                }
            }
            if(GridColourSet.SelectedItem == LiteInverted) // The lite theme, but inverted.
            {

                this.GetAliveColour = Brushes.LightSteelBlue;
                this.GetGridColour = Brushes.IndianRed;
                if(GetGridColour == Brushes.IndianRed && GetAliveColour == Brushes.LightSteelBlue)
                {
                    ActiveCell.Fill = Brushes.LightSteelBlue;
                    BackgroundColour.Fill = Brushes.IndianRed;
                }
                
            }
            
            
        }

        

        //private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        //{


        //    ComboBoxItem typeItem = (ComboBoxItem)GridColourSet.SelectedItem;
        //    string value = Convert.ToString(typeItem);
        //    Debug.WriteLine(value);
        //    if (GridColourSet.SelectedItem == Default)
        //    {
        //        this.GetGridColour = Brushes.SteelBlue;
        //        this.GetAliveColour = Brushes.Firebrick;
        //        //Debug.WriteLine("test");
        //        Console.WriteLine(value);
        //    }
        //    if (GridColourSet.SelectedItem == Inverted)
        //    {
        //        this.GetGridColour = Brushes.Firebrick;
        //        this.GetAliveColour = Brushes.SteelBlue;
        //    }
        //}



        //private void setRow(object sender, RoutedEventArgs e)
        //{

        //}
        //private void setColumn(object sender, RoutedEventArgs e)
        //{

        //}

    }
}