using CleanCodeLabb3_Pizzeria.Models;
using CleanCodeLabb3_Pizzeria.Models.Pizzas;
using CleanCodeLabb3_Pizzeria.Models.Toppings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeLabb3_Pizzeria
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayText.DisplayMenu();
            Console.ReadKey();
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
