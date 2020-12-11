using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class Drink : Storable
    {
        public Drink(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
