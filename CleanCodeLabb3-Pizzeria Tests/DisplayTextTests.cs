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
        [DataRow(new string[] { "5", "q", "2" }, "Coca-Cola", 0)]
        [DataRow(new string[] { "6", "q", "2" }, "Fanta", 0)]
        [DataRow(new string[] { "7", "q", "2" }, "Sprite", 0)]
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
            var actual = displayText.Orders[0].ProductItems[indexToCheck].Name;

            Assert.AreEqual(expected, actual);
        }
    }
}
