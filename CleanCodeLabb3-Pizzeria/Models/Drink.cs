using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class Drink : OrderItem
    {
        public Drink(string name, double price)
        {
            Name = name;
        }
    }
}
