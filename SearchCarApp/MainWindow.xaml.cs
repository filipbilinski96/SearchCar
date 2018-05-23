using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace SearchCarApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] enginesValues = { "1", "1.2", "1.4", "1.8", "2", "2.5" };
        public string[] carsValues = { "A1", "A3", "A4", "A5", "A6", "A7", "A8", "Q2", "Q3", "Q5" };

        public CarController carController;

        public MainWindow()
        {
            InitializeComponent();

            carController = new CarController();
            carController.loadData("data.txt");

            // Load data to comboBox
            foreach (string val in carsValues)
            {
                name.Items.Add(val);
            }
            foreach (string val in enginesValues)
            {
                engine.Items.Add(val);
            }
        }



        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            name.SelectedIndex = -1;
            engine.SelectedIndex = -1;
            year1.Text = "";
            year2.Text = "";
            price1.Text = "";
            price2.Text = "";
            mileage1.Text = "";
            mileage2.Text = "";
            carsList.ItemsSource = null;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string[] parameters = new string[8];
            parameters[0] = name.Text;
            parameters[1] = engine.Text;
            parameters[2] = year1.Text;
            parameters[3] = year2.Text;
            parameters[4] = mileage1.Text;
            parameters[5] = mileage2.Text;
            parameters[6] = price1.Text;
            parameters[7] = price2.Text;
            if (validData(parameters))
                carsList.ItemsSource = carController.filtrCars(parameters);
            else
                MessageBox.Show("Błędne dane.");
        }

        public bool validData(string[] parameters)
        {
            string regex = @"(^[0-9]+$|^$)";
            if (!(Regex.IsMatch(parameters[2], regex) && Regex.IsMatch(parameters[3], regex) && Regex.IsMatch(parameters[4], regex) && Regex.IsMatch(parameters[5], regex) && Regex.IsMatch(parameters[6], regex) && Regex.IsMatch(parameters[7], regex)))
                return false;
            if (parameters[2].Length > 0 && parameters[3].Length > 0)
                if (int.Parse(parameters[2]) >= int.Parse(parameters[3]))
                    return false;
            if (parameters[4].Length > 0 && parameters[5].Length > 0)
                if (int.Parse(parameters[4]) >= int.Parse(parameters[5]))
                    return false;
            if (parameters[6].Length > 0 && parameters[7].Length > 0)
                if (int.Parse(parameters[6]) >= int.Parse(parameters[7]))
                    return false;
            return true;
        }
    }
}
