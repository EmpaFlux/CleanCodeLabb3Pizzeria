using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum OrderItemType { Pizza, Topping, Drink }

    public abstract class Product
    {
        private string _name;
        private double _price;

        public string Name { get => _name; set => _name = value; }

        public virtual double GetPrice() { return _price; }
    }
}
