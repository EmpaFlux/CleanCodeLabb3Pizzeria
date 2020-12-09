using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Shrimp : Topping
    {
        public Shrimp()
        {
            PriceGroup = ExtraToppingPriceGroup.B;
            ArticleNumber = 15;
            Name = "shrimp";
            Amount = 50.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
