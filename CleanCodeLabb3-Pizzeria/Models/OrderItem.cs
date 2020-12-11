using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum OrderItemType { Pizza, Topping, Drink }

    public class OrderItem
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }
    }
}
