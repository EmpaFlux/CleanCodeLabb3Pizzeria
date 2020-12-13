using CleanCodeLabb3_Pizzeria.Models;
using System;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Data
{
    public sealed class ProductDatabase
    {
        public static ProductDatabase Instance { get; } = new ProductDatabase();
        private ProductDatabase() { }
        public List<OrderItem> GetPizzas()
        {
            var pizzaList = new List<OrderItem>()
            {
                new OrderItem(OrderItemType.Pizza, "Hawaii"),
                new OrderItem(OrderItemType.Pizza, "Kebab pizza"),
                new OrderItem(OrderItemType.Pizza, "Margerita"),
                new OrderItem(OrderItemType.Pizza, "Quatro Stagioni"),
            };
            return pizzaList;
        }
        public List<OrderItem> GetDrinks()
        {
            var drinkList = new List<OrderItem>()
            {
                new OrderItem(OrderItemType.Drink, "Coca-Cola"),
                new OrderItem(OrderItemType.Drink, "Fanta"),
                new OrderItem(OrderItemType.Drink, "Sprite"),
            };
            return drinkList;
        }
        public List<OrderItem> GetToppings()
        {
            var toppingsList = new List<OrderItem>()
            {
                new OrderItem(OrderItemType.Topping, "artichoke"),
                new OrderItem(OrderItemType.Topping, "cheese"),
                new OrderItem(OrderItemType.Topping, "cilantro"),
                new OrderItem(OrderItemType.Topping, "clam"),
                new OrderItem(OrderItemType.Topping, "ham"),
                new OrderItem(OrderItemType.Topping, "kebab"),
                new OrderItem(OrderItemType.Topping, "kebab sauce"),
                new OrderItem(OrderItemType.Topping, "lettuce"),
                new OrderItem(OrderItemType.Topping, "mushroom"),
                new OrderItem(OrderItemType.Topping, "onion"),
                new OrderItem(OrderItemType.Topping, "peperoncini"),
                new OrderItem(OrderItemType.Topping, "pineapple"),
                new OrderItem(OrderItemType.Topping, "shrimp"),
                new OrderItem(OrderItemType.Topping, "tomato"),
                new OrderItem(OrderItemType.Topping, "tomato sauce"),
            };
            return toppingsList;
        }
    }
}
