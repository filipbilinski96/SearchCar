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
        private ArrayList cars;

        public MainWindow()
        {
            InitializeComponent();
            cars = new ArrayList();
            loadData();
        }

        public void loadData()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("data.txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] parameters = line.Split(',');
                Car car = new Car(parameters[0], Int32.Parse(parameters[1]), parameters[2], Int32.Parse(parameters[3]), Int32.Parse(parameters[4]));
                cars.Add(car);
            }
            file.Close();

            foreach(string val in carsValues)
            {
                name.Items.Add(val);
            }
            foreach(string val in enginesValues)
            {
                engine.Items.Add(val);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            name.Items.Clear();
            engine.Items.Clear();
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
            if (validData())
            {
                carsList.ItemsSource = filtrCars();
            }
            else
            {
                MessageBox.Show("Błędne dane.");
            }
        }

        private ArrayList filtrCars()
        {
            ArrayList ans = (ArrayList) cars.Clone();
            if (name.SelectedIndex >= 0)
                foreach (Car car in cars)
                    if (car.name != name.Text)
                        ans.Remove(car);
            if (engine.SelectedIndex >= 0)
                foreach (Car car in cars)
                    if (car.engine != engine.Text)
                        ans.Remove(car);

            if (year1.Text.Length > 0)
                foreach (Car car in cars)
                    if (car.year < int.Parse(year1.Text))
                        ans.Remove(car);
            if (year2.Text.Length > 0)
                foreach (Car car in cars)
                    if (car.year > int.Parse(year2.Text))
                        ans.Remove(car);

            if (mileage1.Text.Length > 0)
                foreach (Car car in cars)
                    if (car.mileage < int.Parse(mileage1.Text))
                        ans.Remove(car);
            if (mileage2.Text.Length > 0)
                foreach (Car car in cars)
                    if (car.mileage > int.Parse(mileage2.Text))
                        ans.Remove(car);

            if (price1.Text.Length > 0)
                foreach (Car car in cars)
                    if (car.price < int.Parse(price1.Text))
                        ans.Remove(car);
            if (price2.Text.Length > 0)
                foreach (Car car in cars)
                    if (car.price > int.Parse(price2.Text))
                        ans.Remove(car);


            return ans;
        }

        private bool validData()
        {
            string regex = @"(^[0-9]+$|^$)";
            if (!(Regex.IsMatch(year1.Text, regex) && Regex.IsMatch(year2.Text, regex) && Regex.IsMatch(mileage1.Text, regex) && Regex.IsMatch(mileage2.Text, regex) && Regex.IsMatch(price1.Text, regex) && Regex.IsMatch(price2.Text, regex)))
                return false;
            if (year1.Text.Length > 0 && year2.Text.Length > 0)
                if (int.Parse(year1.Text) >= int.Parse(year2.Text))
                    return false;
            if (mileage1.Text.Length > 0 && mileage2.Text.Length > 0)
                if (int.Parse(mileage1.Text) >= int.Parse(mileage2.Text))
                    return false;
            if (price1.Text.Length > 0 && price2.Text.Length > 0)
                if (int.Parse(price1.Text) >= int.Parse(price2.Text))
                    return false;
            return true;
        }
    }
}
