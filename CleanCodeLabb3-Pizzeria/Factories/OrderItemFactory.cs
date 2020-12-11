using CleanCodeLabb3_Pizzeria.Models;
using CleanCodeLabb3_Pizzeria.Models.Pizzas;
using CleanCodeLabb3_Pizzeria.Models.Toppings;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    public sealed class OrderItemFactory: IPizzeriaFactory
    {
        private string _itemName;
        
        private OrderItemFactory() { }

        public static OrderItemFactory OrderItemFactoryInstance { get; } = new OrderItemFactory();

        public OrderItem Get(string itemName)
        {
            _itemName = itemName;
            return GetOrderItem();
        }

        private OrderItem GetOrderItem()
        {
            OrderItem orderItem;

            switch (_itemName)
            {
                case "Margerita":
                    orderItem = new Pizza() { Name = "Margerita", Price = 85, StandardToppings = new List<Topping>() {new Topping{ Name = "Cheese",  }  }
                        break;
                default:
                    break;
            }
        }
    }
}
