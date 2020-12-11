using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class OrderItem
    {
        private string _name;
        private double _price;
        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
    }
}
