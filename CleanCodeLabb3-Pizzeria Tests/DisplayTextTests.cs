using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodeLabb3_Pizzeria;
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
        [DataRow(new string[] { "1", "2", "3", "4", "2" }, "Pizza 1", 0)]
        [DataRow(new string[] { "1", "2", "3", "4", "2" }, "Pizza 2", 1)]
        [DataRow(new string[] { "1", "2", "3", "4", "2" }, "Sprite", 2)]
        [DataRow(new string[] { "2", "4", "2" }, "Pizza 2", 0)]
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
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.Fail();
        }
    }
}
