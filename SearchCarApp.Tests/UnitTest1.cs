using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCarApp;

namespace SearchCarApp.Tests
{
    [TestClass]
    public class SearchCarAppTests
    {
        [TestMethod]
        public void TestValidation()
        {
            SearchCarApp.MainWindow main = new SearchCarApp.MainWindow();
            Assert.AreEqual(main.enginesValues.Length, 6);
            Assert.AreEqual(main.carsValues.Length, 10);
        }
    }
}
