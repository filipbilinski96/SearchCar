using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCarApp;

namespace SearchCarApp.Tests
{
    [TestClass]
    public class SearchCarAppTests
    {
        [TestMethod]
        public void TestArraysSize()
        {
            SearchCarApp.MainWindow main = new SearchCarApp.MainWindow();
            Assert.AreEqual(main.enginesValues.Length, 6);
            Assert.AreEqual(main.carsValues.Length, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "File not found")]
        public void TestExceptionInLoadingFiles()
        {
            SearchCarApp.CarController carController = new CarController();
            carController.loadData("jakis_plik.txt");
        }

        [TestMethod]
        public void TestArrayOfCarsSize()
        {
            SearchCarApp.MainWindow main = new SearchCarApp.MainWindow();
            Assert.AreEqual(main.carController.cars.Count, 500);
        }

        [TestMethod]
        public void TestValidation()
        {
            SearchCarApp.MainWindow main = new SearchCarApp.MainWindow();
            string[] parameters = new string[8];
            for (int i = 0; i < 8; i++)
                parameters[i] = "";
            parameters[2] = "200";
            parameters[3] = "100";
            Assert.IsFalse(main.validData(parameters));
        }
    }
}
