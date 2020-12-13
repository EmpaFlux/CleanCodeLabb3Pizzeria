using CleanCodeLabb3_Pizzeria.Factories;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum Status { Aborted, Completed, Active}
    public class Order
    {
        private Status currentStatus;
        private List<List<string>> _summary = new List<List<string>>();
        private List<Product> _orderItems = new List<Product>();
        private double totalOrderCost = 0;

        public Order(List<OrderItem> incoming)
        {
            _orderItems.AddRange(ProductFactory.Instance.Get(incoming));
            currentStatus = Status.Active;
        }

        public void Tally()
        {
            //Pizza and drink names
            var orderItemNames = new List<string>();
            _orderItems.ForEach(item => orderItemNames.Add(item.Name));

            //Topping names
            var toppingNames = new List<string>();
            var pizzas = _orderItems.OfType<Pizza>().ToList();
            pizzas.ForEach(pizza => pizza.StandardToppings.ForEach(topping => toppingNames.Add(topping.Name)));
            pizzas.ForEach(pizza => pizza.ExtraToppings.ForEach(topping => toppingNames.Add(topping.Name)));

            //Price for all pizzas, drinks and extra toppings           
            double totalPrice = 0;
            _orderItems.ForEach(item => totalPrice += item.GetPrice());
            pizzas.ForEach(pizza => pizza.ExtraToppings.ForEach(topping => totalPrice += topping.GetPrice()));
        }

        public List<List<string>> Summary { get => _summary; set => _summary = value; }
    }
}
