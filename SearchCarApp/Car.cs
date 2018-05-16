using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchCarApp
{
    class Car
    {
        public string name { get; set; }
        public int year { get; set; }
        public string engine { get; set; }
        public int mileage { get; set; }
        public int price { get; set; }

        public Car(string name, int year, string engine, int mileage, int price)
        {
            this.name = name;
            this.year = year;
            this.mileage = mileage;
            this.price = price;
            this.engine = engine;
        }

        public override string ToString()
        {
            return name + ";" + year + ";" + engine + ";" + mileage + ";" + price;
        }
    }
}
