using CleanCodeLabb3_Pizzeria.Models;
using CleanCodeLabb3_Pizzeria;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizza_Tests
{
    [TestClass]
    public class DisplayTextTests
    {
        [DataTestMethod]
        public void PlaceOrder_ListOfOrderables_ReturnsListOfStringsWithAllToppingsProductsAndPrice()
        {
            //Arrange
            List<Product> order = TestData.GetOrder();
            var expected = new List<List<string>>() {
                new List<string>() { "Margerita", "Cola" },
                new List<string>() { "tomato sauce", "cheese", "pineapple" },
                new List<string>() { "115.00" }
            };
            var program = new Program();

            //Act
            var actual = program.PlaceOrder(order);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
