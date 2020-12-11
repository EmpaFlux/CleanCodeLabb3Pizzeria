using CleanCodeLabb3_Pizzeria.Models;
using System;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DisplayText.DisplayMenu();
            Program program = new Program();

            var requested = new List<OrderItem>() {
                new OrderItem(OrderItemType.Pizza, "Hawaii"),
                new OrderItem(OrderItemType.Pizza, "Margerita") ,
                new OrderItem(OrderItemType.Drink, "Fanta") ,
                new OrderItem(OrderItemType.Topping, "cilantro") };
             
            var order = new Order(requested);
            order.Tally();

            Console.ReadKey();
        }

        //public List<List<string>> PlaceOrder(List<OrderItem> order)
        //{
        //    var incomingOrder = order;
        //    var pizzas = order.OfType<Pizza>().ToList();
        //    var names = pizzas.ForEach()
        //    var toppings = order.OfType<Topping>().ToList();
        //    var price = new List<string>();
        //    var orderTally = new List<List<string>>();
        //    return orderTally;
        //}
    }
}
