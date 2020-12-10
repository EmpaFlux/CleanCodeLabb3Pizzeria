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
            var incomingOrder = orderItems;
            var pizzas = orderItems.OfType<Pizza>().ToList().ForEach( (x) => x.Name) );
            var names = pizzas.ForEach()
            var toppings = orderItems.OfType<Topping>().ToList();
            var price = new List<string>();
            var orderTally = new List<List<string>>();
        }

        public List<List<string>> Summary { get => _summary; set => _summary = value; }
    }
}
