using CleanCodeLabb3_Pizzeria.Models;
using CleanCodeLabb3_Pizzeria.Models.Pizzas;
using CleanCodeLabb3_Pizzeria.Models.Toppings;
using System;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizza_Tests
{
    internal class TestData
    {
      
        internal static List<Product> GetOrder()
        {
            Margerita margerita = new Margerita();
            margerita.ExtraToppings.Add(new Pineapple());
            List<Product> _order = new List<Product>() { margerita, new Drink("Cola") };

            return _order;
        }
    }
}