using CleanCodeLabb3_Pizzeria.Models.Toppings;
using CleanCodeLabb3_Pizzeria.Models.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class OrderSummary
    {
        private List<List<string>> _summary = new List<List<string>>();

        public OrderSummary(List<OrderItem> orderItems)
        {

            //Pizza and drink names
            var orderItemNames = new List<string>();
            orderItems.ForEach(item => orderItemNames.Add(item.Name));

            //Topping names
            var toppingNames = new List<string>();
            var pizzas = orderItems.OfType<Pizza>().ToList();
            pizzas.ForEach(pizza => pizza.StandardToppings.ForEach(topping => toppingNames.Add(topping.Name)));
            pizzas.ForEach(pizza => pizza.ExtraToppings.ForEach(topping => toppingNames.Add(topping.Name)));

            //Price for all pizzas, drinks and extra toppings           
            double totalPrice = 0;
            orderItems.ForEach(item => totalPrice += item.Price);
            pizzas.ForEach(pizza => pizza.ExtraToppings.ForEach(topping => totalPrice += topping.ExtraToppingPrice));
        }

        public List<List<string>> Summary { get => _summary; set => _summary = value; }
    }
}
