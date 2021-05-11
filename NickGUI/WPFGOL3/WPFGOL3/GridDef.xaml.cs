﻿using System.Windows;
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

            MainWindow Main = new MainWindow(Row, Column, GetAliveColour, GetGridColour);


            Main.Show();

            this.Close();




        }

        public void GridColourSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            if (GridColourSet.SelectedItem == Default)
            {
                //Debug.WriteLine("test");
                this.GetAliveColour = Brushes.Firebrick;
                this.GetGridColour = Brushes.SteelBlue;
                

            }
            if (GridColourSet.SelectedItem == Inverted)
            {
                this.GetAliveColour = Brushes.SteelBlue;
                this.GetGridColour = Brushes.Firebrick;
                if (GetGridColour == Brushes.Firebrick && GetAliveColour == Brushes.SteelBlue)
                {
                    ActiveCell.Fill = Brushes.SteelBlue;
                    BackgroundColour.Fill = Brushes.Firebrick;
                }
            }
            if(GridColourSet.SelectedItem == Lite)
            {
                this.GetAliveColour = Brushes.IndianRed;
                this.GetGridColour = Brushes.LightSteelBlue;
                if (GetGridColour == Brushes.LightSteelBlue && GetAliveColour == Brushes.IndianRed)
                {
                    ActiveCell.Fill = Brushes.IndianRed;
                    BackgroundColour.Fill = Brushes.LightSteelBlue;
                }
            }
            if(GridColourSet.SelectedItem == LiteInverted)
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