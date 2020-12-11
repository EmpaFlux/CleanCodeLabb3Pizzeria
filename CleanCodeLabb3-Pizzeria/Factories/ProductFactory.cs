using CleanCodeLabb3_Pizzeria.Models;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    public sealed class ProductFactory
    {
        private ProductFactory() { }

        public static ProductFactory Instance { get; } = new ProductFactory();

        public Product Get(OrderItem orderItem)
        {
            return GetOrderItem(orderItem);
        }

        public List<Product> Get(List<OrderItem> orderItems)
        {
            var items = new List<Product>();
            foreach (var item in orderItems)
            {
                items.Add(GetOrderItem(item));
            }
            return items;
        }
     
        private Product GetOrderItem(OrderItem orderItem)
        {
            var type = orderItem.Type;
            var name = orderItem.Name;
            Product item;

            switch (type)
            {
                case OrderItemType.Pizza:
                    item = PizzaFactory.Instance.Get(name);
                    break;
                case OrderItemType.Topping:
                    item = ToppingFactory.Instance.Get(name);
                    break;
                case OrderItemType.Drink:
                    item = DrinkFactory.Instance.Get(name);
                    break;
                default:
                    item = null;
                    break;
            }
            return item;
        }
    }
}
