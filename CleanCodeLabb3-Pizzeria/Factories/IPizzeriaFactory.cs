using CleanCodeLabb3_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    internal interface IPizzeriaFactory
    {
        public OrderItem Get(string itemName);
    }
}
