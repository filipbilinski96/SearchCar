using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SearchCarApp
{
    public class CarController
    {

        public ArrayList cars { get; }

        public CarController()
        {
            cars = new ArrayList();
        }

        public void loadData(string fileName)
        {
            string line;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    String[] parameters = line.Split(',');
                    Car car = new Car(parameters[0], Int32.Parse(parameters[1]), parameters[2], Int32.Parse(parameters[3]), Int32.Parse(parameters[4]));
                    cars.Add(car);
                }
                file.Close();
            }catch (IOException)
            {
                throw new Exception("File not found");
            }
        }

        public ArrayList filtrCars(string[] parameters)
        {
            ArrayList ans = (ArrayList)cars.Clone();
            if (parameters[0].Length > 0)
                foreach (Car car in cars)
                    if (car.name != parameters[0])
                        ans.Remove(car);
            if (parameters[1].Length > 0)
                foreach (Car car in cars)
                    if (car.engine != parameters[1])
                        ans.Remove(car);

            if (parameters[2].Length > 0)
                foreach (Car car in cars)
                    if (car.year < int.Parse(parameters[2]))
                        ans.Remove(car);
            if (parameters[3].Length > 0)
                foreach (Car car in cars)
                    if (car.year > int.Parse(parameters[3]))
                        ans.Remove(car);

            if (parameters[4].Length > 0)
                foreach (Car car in cars)
                    if (car.mileage < int.Parse(parameters[4]))
                        ans.Remove(car);
            if (parameters[5].Length > 0)
                foreach (Car car in cars)
                    if (car.mileage > int.Parse(parameters[5]))
                        ans.Remove(car);

            if (parameters[6].Length > 0)
                foreach (Car car in cars)
                    if (car.price < int.Parse(parameters[6]))
                        ans.Remove(car);
            if (parameters[7].Length > 0)
                foreach (Car car in cars)
                    if (car.price > int.Parse(parameters[7]))
                        ans.Remove(car);


            return ans;
        }

    }
}
