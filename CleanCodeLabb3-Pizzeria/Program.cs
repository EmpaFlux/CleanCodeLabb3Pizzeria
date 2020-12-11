using CleanCodeLabb3_Pizzeria.Models;
using CleanCodeLabb3_Pizzeria.Models.Pizzas;
using CleanCodeLabb3_Pizzeria.Models.Toppings;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeLabb3_Pizzeria
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayText displayText = new DisplayText(new ReadConsole());
            displayText.DisplayMenu();
            //using (StringReader test = new StringReader("1" + Environment.NewLine + "2" + Environment.NewLine + "4"))
            //{
            //    Console.SetIn(test);
            //    DisplayText displayText = new DisplayText(new ReadConsole());
            //    displayText.DisplayMenu();
            //}
        }

        public List<List<string>> PlaceOrder(List<OrderItem> order)
        {
            var incomingOrder = order;
            var pizzas = order.OfType<Pizza>().ToList();
            var names = pizzas.ForEach()
            var toppings = order.OfType<Topping>().ToList();
            var price = new List<string>();
            var orderTally = new List<List<string>>();
            return orderTally;
        }
    }
}
