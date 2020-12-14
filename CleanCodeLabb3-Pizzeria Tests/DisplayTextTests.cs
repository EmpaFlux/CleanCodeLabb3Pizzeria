using CleanCodeLabb3_Pizzeria.Models;
using CleanCodeLabb3_Pizzeria;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizza_Tests
{
    [TestClass]
    public class DisplayTextTests
    {
        DisplayText displayText;
        [TestInitialize]
        public void Initialize()
        {
            displayText = new DisplayText(new MockConsole());
        }
        
        [DataTestMethod]
        [DataRow(new string[] { "1", "2", "3", "q", "2" }, "Hawaii", 0)]
        [DataRow(new string[] { "1", "2", "3", "q", "2" }, "Kebab pizza", 1)]
        [DataRow(new string[] { "1", "2", "3", "q", "2" }, "Margerita", 2)]
        [DataRow(new string[] { "1", "2", "4", "q", "2" }, "Quatro Stagioni", 2)]
        [DataRow(new string[] { "2", "q", "2" }, "Kebab pizza", 0)]
        public void DisplayMenu_AddItemsToOrder_ItemIsAddedToList(string[] inputs, string expected, int indexToCheck)
        {
            string stringReaderInput = inputs[0];
            for (int i = 1; i < inputs.Length; i++)
            {
                stringReaderInput += Environment.NewLine + inputs[i];
            }
            StringReader sw = new StringReader(stringReaderInput);
            Console.SetIn(sw);
            displayText.DisplayMenu();
            var actual = displayText.orders[0].ToArray();

            Assert.AreEqual(expected, actual[indexToCheck]);
        }
        [DataTestMethod]
        public void PlaceOrder_ListOfOrderables_ReturnsListOfStringsWithAllToppingsProductsAndPrice()
        {
            //Arrange
            List<OrderItem> order = TestData.GetOrder();
            var expected = new List<List<string>>() {
                new List<string>() { "Margerita", "Cola" },
                new List<string>() { "tomato sauce", "cheese", "pineapple" },
                new List<string>() { "115.00" }
            };
            //var program = new Program();

            //Act
            //var actual = program.PlaceOrder(order);

            //Assert
            //Assert.AreEqual(expected, actual);
        }
    }
}
