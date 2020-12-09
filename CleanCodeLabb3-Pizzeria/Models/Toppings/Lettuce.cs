using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Lettuce : Topping
    {
        public Lettuce()
        {
            ArticleNumber = 10;
            Name = "lettuce";
            Amount = 60.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
